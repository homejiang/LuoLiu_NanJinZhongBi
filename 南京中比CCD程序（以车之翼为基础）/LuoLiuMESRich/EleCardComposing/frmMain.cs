using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EleCardComposing
{
    public partial class frmMain : Common.frmBase
    {
        const string C_PleaseInputPBC = "PleaseInputPBC";
        const string C_PleaseInputMk = "C_PleaseInputMk";
        #region 窗体数据连接实例
        private BLLDAL.Composing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Composing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Composing();
                return _dal;
            }
        }
        #endregion 
        EleCardComposing.MyEntitys.ReadPactInfo _ReadPactInfo = null;
        public frmMain()
        {
            InitializeComponent();
        }
        #region 窗口字段
        string _PlanGuid = string.Empty;
        /// <summary>
        /// 1：为通过结构校验用户是否输入正确；
        /// 2：仅校验总电芯数，来判断用户是否输入正确（针对分选机2盒电芯要装3个模块的问题）；
        /// </summary>
        int _Mode = 1;
        /// <summary>
        /// 当前绑定完后的模组编号
        /// </summary>
        string _MzCode = string.Empty;
        #endregion
        #region 公共函数
        public bool CheckIsReInputMKCode(string sMKcode,UserControls.ucMk1 uc)
        {
            ///校验是否其他控件已经输入了该编号
            UserControls.ucMk1 control;
            foreach(Control con in this.panContainer.Controls)
            {
                control = con as UserControls.ucMk1;
                if (control == null) continue;
                if (control.Equals(uc)) continue;
                if (control.GetMKCode() == string.Empty) continue;
                if (string.Compare(sMKcode,control.GetMKCode(), true)==0)
                {
                    this.ShowMsg("当前模块编号已经输入，请勿重复输入。");
                    return false;
                }
            }
            return true;
        }
        public bool CheckIsPactSame(string sPactCode, UserControls.ucMk1 uc)
        {
            ///校验是否和已输入的是同一个任务单号
            UserControls.ucMk1 control;
            foreach (Control con in this.panContainer.Controls)
            {
                control = con as UserControls.ucMk1;
                if (control == null) continue;
                if (control.Equals(uc)) continue;
                if (control.GetMKCode() == string.Empty) continue;
                if (control._PactCode == string.Empty) continue;
                if (string.Compare(sPactCode, control._PactCode, true) != 0)
                {
                    this.ShowMsg("当前模块绑定的任务单位“"+sPactCode+"”，与之前导入的模块的不一致。");
                    return false;
                }
            }
            return true;
        }
        public void MkInfoBindSucessful(UserControls.ucMk1 uc,int iMkCnt,string sPlanGuid,string sPactCode)
        {
            this.ucAutoSaveTimerShow1.Stop();
            this._PlanGuid = sPlanGuid;
            //通知主程序已经成功加载完了，并告知主窗体有多少模块
            if (this.panContainer.Controls.Count != iMkCnt)
            {
                //此时不一样
                this.AddMkUc(iMkCnt);
            }
            this.BindPactInfo(sPlanGuid);
            //将焦点移至下一个UC控件
            bool blFocused = false;
            bool blUcFound = false;
            UserControls.ucMk1 control;
            foreach (Control con in this.panContainer.Controls)
            {
                control = con as UserControls.ucMk1;
                if (control == null) continue;
                if (control.Equals(uc))
                {
                    blUcFound = true;
                }
                else
                {
                    if(blUcFound)
                    {
                        control.SetFocus();
                        blFocused = true;
                        break;
                    }
                }
            }
            if(!blFocused)
            {
                //此时焦点移到保护板编号输入
                this.AcitiveTimer(200, C_PleaseInputPBC);
            }
        }
        #endregion
        #region 相关重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if (Arg == null) return;
            if(string.Compare(Arg.ToString(), C_PleaseInputPBC, true)==0)
            {
                this.tbPCBCode.Focus();
                this.tbPCBCode.SelectAll();
            }
            else if (string.Compare(Arg.ToString(), C_PleaseInputMk, true) == 0)
            {
                this.ucMk11.SetFocus();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.DisposeHotKey();
            base.OnClosing(e);
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            ClearFormData();
            this.ucMk11._MainForm = this;
            this.BindOperator();
            BindTitle();
            BindModeStyle();
            SetPCBResultStyle();
            this._ReadPactInfo = new MyEntitys.ReadPactInfo(this,"正式");
            this._ReadPactInfo.SentPactInfoNotice += _ReadPactInfo_SentPactInfoNotice;
            this.AcitiveTimer(200, C_PleaseInputMk);
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            return true;
        }
        private void ClearFormData()
        {
            //清空界面
            foreach (Control con in this.panContainer.Controls)
            {
                UserControls.ucMk1 uc = con as UserControls.ucMk1;
                if (uc == null) continue;
                uc.Clear();
            }
            this.tbPCBCode.Clear();
            this.tbPcbInfo.Clear();
            this.rtbPactInfo.Clear();
            //清空字段
            this._PCBCode = string.Empty;
            this._PCBResult = PCBResults.None;
            this.SetPCBResultStyle();
            this.ucAutoSaveTimerShow1.Stop();
            //模块输入获取焦点
            this.AcitiveTimer(500, C_PleaseInputMk);
        }
        private void AddMkUc(int iMkCnt)
        {
            while (this.panContainer.Controls.Count < iMkCnt)
            {
                //添加
                UserControls.ucMk1 control = new UserControls.ucMk1();
                control._MainForm = this;
                control.Dock = DockStyle.None;
                control.Name = "panContainer_ucMk1_" + this.panContainer.Controls.Count.ToString();
                //设定尺寸
                control.Left = this.ucMk11.Left;
                control.Height = this.ucMk11.Height;
                control.Width = this.ucMk11.Width;
                control.Top = this.ucMk11.Height * this.panContainer.Controls.Count;
                
                this.Controls.Add(control);
            }
            while (this.panContainer.Controls.Count > iMkCnt)
            {
                //此时有点多，则移除
                Control con = this.Controls[this.Controls.Count - 1];
                this.Controls.Remove(con);
                con.Dispose();
                con = null;
            }

        }
        private void BindModeStyle()
        {
            //设置监听状态
            string strText;
            Color cBk;
            Color cFore;
            if (this._Mode==1)
            {
                strText = "根据结构绑定";
                cBk =SystemColors.ControlDarkDark;
                cFore = Color.White;
            }
            else if (this._Mode == 2)
            {
                strText = "按电芯数绑定";
                cBk = SystemColors.ControlDarkDark;
                cFore = Color.White;
            }
            else
            {
                strText = "未选择";
                cBk = Color.FromArgb(192, 192, 0);
                cFore = Color.Black;
            }
            if (this.labModeView.Text != strText)
                this.labModeView.Text = strText;
            if (this.labModeView.BackColor != cBk)
                this.labModeView.BackColor = cBk;
            if (this.labModeView.ForeColor != cFore)
                this.labModeView.ForeColor = cFore;
        }
        private bool BindOperator()
        {
            string strText = string.Empty;
            if (Common.CurrentUserInfo.UserCode.Length > 0)
            {
                strText = Common.CurrentUserInfo.UserName;
            }
            else strText = "已注销";
            if (this.labOperator.Text != strText)
                this.labOperator.Text = strText;
            return true;
        }
        public void BindTitle()
        {
            this.labProcess.Text = Config.ProcessName;
            this.labStation.Text = Config.StationName;
        }
        #endregion
        #region 保护板相关
        private string _PCBCode = string.Empty;
        /// <summary>
        /// 保护板是否检测合格
        /// </summary>
        private PCBResults _PCBResult = PCBResults.None;
        private bool BindPCBData(string sPcbCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC EleCardComposing_GetPCBInfo'{0}'", sPcbCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            //此时要校验数据是是否可以
            DataRow dr = dt.Rows[0];
            this.tbPcbInfo.Text = dr["Info"].ToString();
            if(dr["Quality"].ToString()=="1")
            {
                this._PCBResult = PCBResults.Pass;
            }
            else if (dr["Quality"].ToString() == "2")
            {
                this._PCBResult = PCBResults.Failed;
            }
            else
            {
                this._PCBResult = PCBResults.None;
            }
            SetPCBResultStyle();
            return true;
        }
        private void SetPCBResultStyle()
        {
            //设置监听状态
            string strText;
            Color cBk;
            Color cFore;
            if (this._PCBResult== PCBResults.Pass)
            {
                strText = "检测合格";
                cBk = Color.Lime;
                cFore = Color.Black;
            }
            else if (this._PCBResult == PCBResults.Failed)
            {
                strText = "不合格";
                cBk = Color.Maroon;
                cFore = Color.White;
            }
            else
            {
                strText = "------";
                cBk = Color.White;
                cFore = Color.Black;
            }
            if (this.labOfcListenStatus.Text != strText)
                this.labOfcListenStatus.Text = strText;
            if (this.labOfcListenStatus.BackColor != cBk)
                this.labOfcListenStatus.BackColor = cBk;
            if (this.labOfcListenStatus.ForeColor != cFore)
                this.labOfcListenStatus.ForeColor = cFore;
        }
        #endregion
        #region 消息处理
        public void ShowErr(string sErr)
        {

        }
        #endregion
        #region 订单相关
        private void BindPactInfo(string sPlanGuid)
        {
            if (this._ReadPactInfo == null) return;
            string strMsg;
            if (this._ReadPactInfo.Running)
            {
                //此时正在运行，则启用另外的线程
                EleCardComposing.MyEntitys.ReadPactInfo temp = new MyEntitys.ReadPactInfo(this, "临时创建_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                if (!temp.StartListenning(sPlanGuid, Config.StationCode, out strMsg))
                {
                    this._ReadPactInfo_SentPactInfoNotice(false, string.Format("打开临时创建的任务单数据线程时出错：{0}", strMsg));
                }
            }
            else
            {
                if (!this._ReadPactInfo.StartListenning(sPlanGuid, Config.StationCode, out strMsg))
                {
                    this._ReadPactInfo_SentPactInfoNotice(false, string.Format("打开任务单数据线程时出错：{0}", strMsg));
                }
            }
        }

        private void _ReadPactInfo_SentPactInfoNotice(bool blSucessfully, string sMsg)
        {
            if(!blSucessfully)
            {
                if(this.rtbPactInfo.ForeColor != Color.Red)
                    this.rtbPactInfo.ForeColor = Color.Red;
                if (this.rtbPactInfo.Text != sMsg)
                    this.rtbPactInfo.Text = sMsg;
            }
            else
            {
                if (this.rtbPactInfo.ForeColor != Color.Black)
                    this.rtbPactInfo.ForeColor = Color.Black;
                this.rtbPactInfo.Clear();
                Common.CommonFuns.AddRichTexBoxText(sMsg, this.rtbPactInfo);
            }
        }
        #endregion
        #region 顶部工具栏事件
        #region 用户
        private void 切换绑定模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labModeView_Click(null, null);
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CurrentUserInfo.Logout();
            this.BindOperator();
            this.ShowMsgRich("注销成功");
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            this.BindOperator();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmModifyPwd frm = new Common.Login.frmModifyPwd();
            frm.UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog(this);
        }
        #endregion
        #endregion
        #region 自动提交相关
        public bool IsMkAll()
        {
            //检查模块是否已经输入了
            foreach (Control con in this.panContainer.Controls)
            {
                UserControls.ucMk1 uc = con as UserControls.ucMk1;
                if (uc == null) continue;
                string strErr;
                if (!uc.Check(out strErr))
                {
                    return false;
                }
                if (uc.GetMKCode().Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public void AutoSave()
        {
            if(Config.AutoComposing.DelaySeconds<=0)
            {
                btTrue_Click(null, null);
                return;
            }
            if (!this.Save())
            {
                return;
            }
            this._PCBCode = string.Empty;
            this._PlanGuid = string.Empty;//调用打印
            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            //此时绑定成功调用打印
            this._Printer.Printing(this._MzCode);
            //this.ucAutoSaveTimerShow1.Start(Config.AutoComposing.DelaySeconds);
        }

        private void ucAutoSaveTimerShow1_AutoSaveTimerStopNotice()
        {
            //此时绑定成功
            ClearFormData();
            //将焦点移至第一个模块上面
            //this.ucMk11.SetFocus();
        }
        #endregion
        #region 捕捉windows快捷按钮设置
        private Message _meg;
        //处理接收的消息
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Common.CommonFuns.Hotkey.ProcessHotKey(m);
        }
        /*此处事件都由委托调用*/
        //弹出窗口
        private void HotKeyPupForm()
        {
            btTrue_Click(null, null);
        }
        //注销热键
        private void DisposeHotKey()
        {
            Common.CommonFuns.Hotkey.UnRegist(this.Handle, this.HotKeyPupForm);
        }
        #endregion
        #region 打印相关
        #region 打印
        MyPrinter _Printer = null;
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            MyPrinter.PrintFinishedCallback call = new MyPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (blSucessful)
            {
                this.ShowMsgRich("标签已打印");
                if (Config.AutoComposing.Auto && Config.AutoComposing.DelaySeconds > 0)
                {
                    this.ucAutoSaveTimerShow1.Start(Config.AutoComposing.DelaySeconds);
                }
                else
                {
                    //此时绑定成功
                    ClearFormData();
                    //将焦点移至第一个模块上面
                    //this.ucMk11.SetFocus();
                }
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
        }
        #endregion
        #endregion
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Perinit();
            this.WndProc(ref this._meg);
            Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F5, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm));
            this.KeyPreview = true;//让窗体最先获取按键事件
        }
        private void btBindPcbData_Click(object sender, EventArgs e)
        {
            if (this.tbPCBCode.Text.Length == 0) return;
            if(this.BindPCBData(this.tbPCBCode.Text))
            {
                this.ucAutoSaveTimerShow1.Stop();
                this._PCBCode = this.tbPCBCode.Text;
                //此时判断是否已经完成了
                if (Config.AutoComposing.Auto && this.IsMkAll())
                {
                    //此时要自动提交
                    AutoSave();
                }
            }
            else
            {
                this.AcitiveTimer(200, C_PleaseInputPBC);
            }
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.ucAutoSaveTimerShow1.IsActive())
            {
                this.ClearFormData();
                this.ucAutoSaveTimerShow1.Stop();
                return;
            }
            if (_Mode==0)
            {
                this.ShowMsg("您还未选中绑定模式。");
                return;
            }
            if (!this.Save()) return;
            //调用打印

            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            //此时绑定成功调用打印
            this._Printer.Printing(this._MzCode);
            
        }
        private bool Save()
        {
            List<string> listMkCode = new List<string>();
            string strErr;
            foreach (Control con in this.panContainer.Controls)
            {
                UserControls.ucMk1 uc = con as UserControls.ucMk1;
                if (uc == null) continue;
                if (!uc.Check(out strErr))
                {
                    this.ShowMsg(strErr);
                    uc.SetFocus();
                    return false;
                }
                if (uc.GetMKCode().Length == 0)
                {
                    //此时
                    if (_Mode == 1)
                    {
                        this.ShowMsg("您还有模块未输入编号！");
                        uc.SetFocus();
                        return false;
                    }
                }
                else
                    listMkCode.Add(uc.GetMKCode());
            }
            if (listMkCode.Count == 0)
            {
                this.ShowMsg("您还未导入任何模块。");
                return false;
            }
            if (this.tbPCBCode.Text.Length == 0)
            {
                this.ShowMsg("请输入保护板编码");
                this.AcitiveTimer(200, C_PleaseInputPBC);
                return false;
            }
            if (string.Compare(this.tbPCBCode.Text, this._PCBCode, true) != 0)
            {
                this.ShowMsg("请先加载保护板数据！");
                this.AcitiveTimer(200, C_PleaseInputPBC);
                return false;
            }
            if (this._PlanGuid.Length == 0)
            {
                this.ShowMsg("当前计划单号获取失败，请确认是否已经导入模块信息！");
                return false;
            }
            int iRetrnValue;
            string strMsg;
            string sMzCode;
            string sMk1, sMk2, sMk3, sMk4, sMk5, sMk6, sMk7, sMk8, sMk9, sMk10;
            if (listMkCode.Count > 0)
                sMk1 = listMkCode[0];
            else sMk1 = string.Empty;
            if (listMkCode.Count > 1)
                sMk2 = listMkCode[1];
            else sMk2 = string.Empty;
            if (listMkCode.Count > 2)
                sMk3 = listMkCode[2];
            else sMk3 = string.Empty;
            if (listMkCode.Count > 3)
                sMk4 = listMkCode[3];
            else sMk4 = string.Empty;
            if (listMkCode.Count > 4)
                sMk5 = listMkCode[4];
            else sMk5 = string.Empty;
            if (listMkCode.Count > 5)
                sMk6 = listMkCode[5];
            else sMk6 = string.Empty;
            if (listMkCode.Count > 6)
                sMk7 = listMkCode[6];
            else sMk7 = string.Empty;
            if (listMkCode.Count > 7)
                sMk8 = listMkCode[7];
            else sMk8 = string.Empty;
            if (listMkCode.Count > 8)
                sMk9 = listMkCode[8];
            else sMk9 = string.Empty;
            if (listMkCode.Count > 9)
                sMk10 = listMkCode[9];
            else sMk10 = string.Empty;
            try
            {
                this.BllDAL.EleCardComposingBinding(Config.ProcessCode, Config.StationCode, this._Mode, this._PlanGuid, sMk1, sMk2, sMk3, sMk4, sMk5, sMk6, sMk7, sMk8, sMk9, sMk10,
                    this.tbPCBCode.Text,out sMzCode, out iRetrnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(iRetrnValue!=1)
            {
                if (strMsg.Length == 0)
                    strMsg = "绑定出错，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            this._MzCode = sMzCode;
            return true;
        }

        private void labModeView_Click(object sender, EventArgs e)
        {
            if (this._Mode == 1)
                this._Mode = 2;
            else
                this._Mode = 1;
            this.BindModeStyle();
            this.ShowMsgRich("切换成功");
        }

        private void tbPCBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btBindPcbData_Click(sender, null);
        }

        private void 自动完成绑定设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySetting.frmAutoComposing frm = new MySetting.frmAutoComposing();
            frm.ShowDialog(this);
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmComposedList frm = new DataM.frmComposedList();
            frm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CommonFuns.StartUpdate(new string[] { }, Version.GetCurrentVersions());
        }

        private void 打印成品编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            frmPackCode frm = new frmPackCode();
            frm.ShowDialog(this);
        }

        private void 打印机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打印机设置ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MySetting.frmPrinterSetting frm = new MySetting.frmPrinterSetting();
            frm.ShowDialog(this);
        }
        private void 打印机设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
      
        }
    }
    #region 相关枚举
    public enum PCBResults
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None=0,
        /// <summary>
        /// 合格
        /// </summary>
        Pass=1,
        /// <summary>
        /// 不合格
        /// </summary>
        Failed=2
    }
    #endregion
}
