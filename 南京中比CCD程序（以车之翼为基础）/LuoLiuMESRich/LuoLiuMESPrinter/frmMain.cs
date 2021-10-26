using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMESPrinter
{
    public partial class frmMain : Common.frmBase
    {
        const string C_PleaseInputPBC = "PleaseInputPBC";
        #region 窗体数据连接实例
        private BLLDAL.Binding _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Binding BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Binding();
                return _dal;
            }
        }
        #endregion 
        public frmMain()
        {
            InitializeComponent();
            
        }
        MyEntitys.ReadPactInfo _ReadPactInfo = null;
        string _ChengPinCode = string.Empty;
        string _MzCode = string.Empty;
        string _PlnaGuid = string.Empty;
        #region 保护板相关
        private string _PCBCode = string.Empty;
        /// <summary>
        /// 保护板是否检测合格
        /// </summary>
        private PCBResults _PCBResult = PCBResults.None;
        /// <summary>
        /// EOL是否检测合格
        /// </summary>
        private EOLResults _EOLResult = EOLResults.None;
        private bool BindPCBData(string sPcbCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC [LuoLiuMESPrinter_GetPCBInfo]'{0}'", sPcbCode.Replace("'", "''")));
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
            this._MzCode = dr["MzCode"].ToString();
            this._PlnaGuid = dr["PlanGuid"].ToString();
            this.tbMzCode.Text = this._MzCode;
            this.tbPcbInfo.Clear();
            Common.CommonFuns.AddRichTexBoxText(dr["Info"].ToString(), this.tbPcbInfo);
            
            if (dr["Quality"].ToString() == "1")
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
            if (dr["EOLQuality"].ToString() == "1")
            {
                this._EOLResult = EOLResults.Pass;
            }
            else if (dr["EOLQuality"].ToString() == "2")
            {
                this._EOLResult = EOLResults.Failed;
            }
            else
            {
                this._EOLResult = EOLResults.None;
            }
            SetEOLResultStyle();
            this.BindPactInfo(this._PlnaGuid);
            return true;
        }
        private bool BindEOLData(string sPcbCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC [LuoLiuMESPrinter_GetEOLInfo_Cgy]'{0}'", sPcbCode.Replace("'", "''")));
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
            this.RicEOLInfo.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.RicEOLInfo.Text += dr["EOLInfo"].ToString()+"\n";
                
            }
            return true;
        }
        private void SetPCBResultStyle()
        {
            //设置监听状态
            string strText;
            Color cBk;
            Color cFore;
            if (this._PCBResult == PCBResults.Pass)
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
        private void SetEOLResultStyle()
        {
            //设置监听状态
            string strText;
            Color cBk;
            Color cFore;
            if (this._EOLResult == EOLResults.Pass)
            {
                strText = "检测合格";
                cBk = Color.Lime;
                cFore = Color.Black;
            }
            else if (this._EOLResult == EOLResults.Failed)
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
            if (this.labEOLState.Text != strText)
                this.labEOLState.Text = strText;
            if (this.labEOLState.BackColor != cBk)
                this.labEOLState.BackColor = cBk;
            if (this.labEOLState.ForeColor != cFore)
                this.labEOLState.ForeColor = cFore;
        }
        private void btBindPcbData_Click(object sender, EventArgs e)
        {
            if (this.tbPCBCode.Text.Length == 0) return;
            if (this.BindPCBData(this.tbPCBCode.Text))
            {
                this.ucAutoSaveTimerShow1.Stop();
                this._PCBCode = this.tbPCBCode.Text;
                if(JpsConfig.AutoComposing.Auto)
                {
                    Application.DoEvents();
                    AutoSaveAsyn();
                    //this.AutoSave();
                }
            }
            else
            {
                this.AcitiveTimer(200, C_PleaseInputPBC);
            }
        }
        private void AutoSaveAsyn()
        {
            Common.UserControls.AutoSaveTimerStopCallBack call = new Common.UserControls.AutoSaveTimerStopCallBack(AutoSave);
            try
            {
                this.Invoke(call);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this,ex);
            }
        }
        #endregion
        #region 相关重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if (Arg == null) return;
            if (string.Compare(Arg.ToString(), C_PleaseInputPBC, true) == 0)
            {
                this.tbPCBCode.Focus();
                this.tbPCBCode.SelectAll();
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
            this.BindOperator();
            BindTitle();
            SetPCBResultStyle();
            this._ReadPactInfo = new MyEntitys.ReadPactInfo(this, "正式");
            this._ReadPactInfo.SentPactInfoNotice += _ReadPactInfo_SentPactInfoNotice;
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            this.ClearFormData();
            return true;
        }
        private void ClearFormData()
        {
            this.tbPCBCode.Clear();
            this.tbMzCode.Clear();
            this.tbPcbInfo.Clear();
            this.rtbPactInfo.Clear();
            //清空字段
            this._PCBCode = string.Empty;
            this._MzCode = string.Empty;
            this._PlnaGuid = string.Empty;
            this._ChengPinCode = string.Empty;
            this._PCBResult = PCBResults.None;
            this.ucAutoSaveTimerShow1.Stop();
            this.SetPCBResultStyle();
            this.RicEOLInfo.Clear();
            this.AcitiveTimer(300, C_PleaseInputPBC);
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
            this.labProcess.Text = JpsConfig.ProcessName;
            this.labStation.Text = JpsConfig.StationName;
            this.labMac.Text = JpsConfig.MacName;
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
                LuoLiuMESPrinter.MyEntitys.ReadPactInfo temp = new MyEntitys.ReadPactInfo(this, "临时创建_" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                if (!temp.StartListenning(sPlanGuid, JpsConfig.StationCode, out strMsg))
                {
                    this._ReadPactInfo_SentPactInfoNotice(false, string.Format("打开临时创建的任务单数据线程时出错：{0}", strMsg));
                }
            }
            else
            {
                if (!this._ReadPactInfo.StartListenning(sPlanGuid, JpsConfig.StationCode, out strMsg))
                {
                    this._ReadPactInfo_SentPactInfoNotice(false, string.Format("打开任务单数据线程时出错：{0}", strMsg));
                }
            }
        }

        private void _ReadPactInfo_SentPactInfoNotice(bool blSucessfully, string sMsg)
        {
            if (!blSucessfully)
            {
                if (this.rtbPactInfo.ForeColor != Color.Red)
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
                if (JpsConfig.AutoComposing.Auto && JpsConfig.AutoComposing.DelaySeconds > 0)
                {
                    this.ucAutoSaveTimerShow1.Start(JpsConfig.AutoComposing.DelaySeconds);
                }
                else
                {
                    this.ClearFormData();
                    this.AcitiveTimer(200, C_PleaseInputPBC);
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
        #region 自动提交相关
        
        public void AutoSave()
        {
            if (JpsConfig.AutoComposing.DelaySeconds <= 0)
            {
                btTrue_Click(null, null);
                return;
            }
            if (!this.Save())
            {
                return;
            }
            if (this._Printer != null)
            {
                //此时绑定成功调用打印
                this._Printer.Printing(this._ChengPinCode);
            }
            else
            {
                //如果打印对象不清空，则按照打印完后再倒计时
                this.ucAutoSaveTimerShow1.Start(JpsConfig.AutoComposing.DelaySeconds);
            }
            this._PCBCode = string.Empty;
            this._PlnaGuid = string.Empty;
            this._MzCode = string.Empty;
            this.ShowMsgRich("绑定成功");
        }

        private void ucAutoSaveTimerShow1_AutoSaveTimerStopNotice()
        {
            this.ClearFormData();
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
        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.ucAutoSaveTimerShow1.IsActive())
            {
                this.ClearFormData();
                this.ucAutoSaveTimerShow1.Stop();
                return;
            }
            if (!this.Save())
            {
                this.AcitiveTimer(300, C_PleaseInputPBC);
                return;
            }
            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            //此时绑定成功调用打印
            this._Printer.Printing(this._ChengPinCode);
            
            
        }
        private bool Save()
        {
            if(this.tbPCBCode.Text.Length==0)
            {
                this.ShowMsg("请输入保护板编号。");
                return false;
            }
            if (string.Compare(this._PCBCode, this.tbPCBCode.Text, true) != 0)
            {
                this.ShowMsg("您还未加载保护板“" + this.tbPCBCode.Text + "”的数据，请按回车或点击按钮加载数据。");
                return false;
            }
            if(this._MzCode.Length==0)
            {
                this.ShowMsg("未正确加载成品编码，不能打印。");
                return false;
            }
            int iRetrnValue;
            string strMsg;
            string strCpCode;
            try
            {
                this.BllDAL.LuoLiuMESPrinterBinding(JpsConfig.ProcessCode, JpsConfig.StationCode,JpsConfig.MacCode,this._MzCode, out strCpCode, out iRetrnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iRetrnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "校验出错，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            _ChengPinCode = strCpCode;
            return true;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Perinit();
            this.WndProc(ref this._meg);
            Common.CommonFuns.Hotkey.Regist(this.Handle, Common.CommonFuns.HotkeyModifiers.None, Keys.F5, new Common.CommonFuns.Hotkey.HotKeyCallBackHanlder(this.HotKeyPupForm));
            this.KeyPreview = true;//让窗体最先获取按键事件
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

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 打印成品编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinter frm = new frmPrinter();
            frm.ShowDialog();
        }

        private void 打印机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting.frmPrinterSetting frm = new Setting.frmPrinterSetting();
            //Setting.frmPrinter frm = new Setting.frmPrinter();
            if (DialogResult.OK == frm.ShowDialog())
            {

            }
        }

        private void 当前工作站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStationConfig frm = new frmStationConfig(true);
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindTitle();
        }

        private void tbPCBCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btBindPcbData_Click(sender, null);
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmPrintedList1 frm = new DataM.frmPrintedList1();
            frm.Show();
        }

        private void 自动完成打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySetting.frmAutoComposing frm = new MySetting.frmAutoComposing();
            frm.ShowDialog(this);
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CommonFuns.StartUpdate(new string[] { }, Version.GetCurrentVersions());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tbPCBCode.Text.Length == 0) return;
            this.BindEOLData(this.tbPCBCode.Text);

        }

    }
    #region 相关枚举
    public enum PCBResults
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None = 0,
        /// <summary>
        /// 合格
        /// </summary>
        Pass = 1,
        /// <summary>
        /// 不合格
        /// </summary>
        Failed = 2
    }
    public enum EOLResults
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None = 0,
        /// <summary>
        /// 合格
        /// </summary>
        Pass = 1,
        /// <summary>
        /// 不合格
        /// </summary>
        Failed = 2
    }
    #endregion
}
