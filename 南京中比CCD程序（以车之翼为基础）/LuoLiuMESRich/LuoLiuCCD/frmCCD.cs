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

namespace LuoLiuCCD
{
    public partial class frmCCD : Common.frmProduceBase
    {
        string _Code = string.Empty;
        public string _BOMGuid = string.Empty;
        Communication.MyHanJieA _Listen = null;
        #region 隐藏字段
        /// <summary>
        /// 当前作业提交后的GUID，该值是在成功保存结果后从数据库返回的
        /// </summary>
        string _GUID = string.Empty;
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.Process1 _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Process1 BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Process1();
                return _dal;
            }
        }
        #endregion 
        public frmCCD()
        {
            InitializeComponent();
            this.dgDxs.AutoGenerateColumns = false;
            调试ToolStripMenuItem.Visible = Communication.Debug.OPCDebug;
        }
        #region 重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if (Arg == null) return;
            if(string.Compare(Arg.ToString(), "NewTest", true)==0)
            {
                //模块编号获取焦点
                this.tbMkCode.Focus();
                this.tbMkCode.Select();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
        #endregion
        #region 加载数据
        public void BindTitle()
        {
            this.ucTitle1.Process = CcdConfig.ProcessName;
            this.ucTitle1.Station = CcdConfig.StationName;
            this.ucTitle1.Mac = CcdConfig.MacName;
        }
        private bool BindData(string sCode)
        {
            if (sCode.Length == 0)
            {
                //此时清空窗口

                if (this._Code != string.Empty)
                {
                    InitFormData();
                }
                
            }
            else
            {
                this.tbMkCode.Text = sCode;
                if (!this.BindSFGInfo(sCode)) return false;
                if (!this.BindMaterial(sCode)) return false;
                this.BindHistory(sCode);
                this.ucStatistic11.MyRefresh(LuoLiuCCD.CcdConfig.ProcessCode, LuoLiuCCD.CcdConfig.MacCode, this._BOMGuid);
                if (this._Code != sCode)
                    this._Code = sCode;
            }
            return true;
        }
        private bool BindSFGInfo(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process1_GetSFGInfo '{0}','{1}'"
                    ,sCode.Replace("'","''"), LuoLiuCCD.CcdConfig.ProcessCode.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Columns.Contains("ErrMsg"))
            {
                //此时有错误，当前工序加载失败
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("基础信息加载失败！");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this._BOMGuid= dr["BOMGuid"].ToString();
            this.tbDxCnt.Text = dr["DxCnt"].ToString();
            this.tbBOMDesc.Text = dr["BOMDesc"].ToString();
            this.rtbPactInfo.Clear();
            this.rtbProcess.Clear();
            Common.CommonFuns.AddRichTexBoxText(dr["PlanInfo"].ToString(), this.rtbPactInfo);
            Common.CommonFuns.AddRichTexBoxText(dr["ProcessInfo"].ToString(), this.rtbProcess);
            BindDxs(dr["TuoPanCode"].ToString(), dr["DxTable"].ToString());
            return true;
        }
        private bool BindMaterial(string sCode)
        {
            //DataTable dt;
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("exec Process1_GetMaterials '{0}','{1}'"
            //        , sCode.Replace("'", "''"), LuoLiuCCD.CcdConfig.ProcessCode.Replace("'", "''")));
            //    //dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Produce_SFG1_Materials WHERE Code='{0}' AND ProcessCode='{1}'"
            //    //   , sCode.Replace("'", "''"), LuoLiuCCD.CcdConfig.ProcessCode.Replace("'", "''")));
            //}
            //catch (Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(this, ex);
            //    return false;
            //}
            //List<Common.UserControls.MaterialEntity> list = new List<Common.UserControls.MaterialEntity>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    Common.UserControls.MaterialEntity entity = new Common.UserControls.MaterialEntity(dr);
            //    list.Add(entity);
            //}
            //this.ucMaterial1.InitMaterial(list);
            return true;
        }
        private void BindDxs(string sTuopanCode,string sDxTable)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM LuoLiuMESDynamicTable.dbo.{0} WHERE TuoPan='{1}'"
                    , sDxTable, sTuopanCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgDxs.DataSource = dt;
        }
        private bool BindHistory(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT EndTime,Quality FROM Produce_SFG1_Process WHERE Code='{0}' AND ProcessCode='{1}' AND isnull(State,0)<>-1 order by EndTime ASC"
                    , sCode.Replace("'", "''"), LuoLiuCCD.CcdConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            string str = string.Empty;
            string sResult;
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["Quality"].ToString() == "1")
                    sResult = "合格";
                else if (dr["Quality"].ToString() == "2") sResult = "不合格";
                else if (dr["Quality"].ToString() == "") sResult = "待定";
                else sResult = "unkown";

                str += string.Format("{0}->{1}\r\n", Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm"), sResult);
            }
            if(str.Length>1)
            {
                str = str.Substring(0, str.Length - 2);
            }
            if (str.Length == 0) str = "无历史记录";
            if (this.tbHistory.Text != str)
                this.tbHistory.Text = str;
            return true;
        }
        private bool BindOperator()
        {
            string strText = string.Empty;
            if (Common.CurrentUserInfo.UserCode.Length > 0)
            {
                strText = Common.CurrentUserInfo.UserName;
            }
            else strText = "已注销";
            if (this.ucTitle1.Operator != strText)
                this.ucTitle1.Operator = strText;
            return true;
        }
        #endregion
        #region 功能函数
        private bool Perinit()
        {
            this._Listen = new Communication.MyHanJieA(this);
            this._Listen.NewShowMKCodeNotice += _Listen_NewShowMKCodeNotice;
            this.InitFormData();

            //设置标题信息
            this.ucTitle1.Process = CcdConfig.ProcessName;
            this.ucTitle1.Mac = CcdConfig.MacName;
            this.ucTitle1.Station = CcdConfig.StationName;
            this.BindOperator();
            this.BindTitle();
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
            this._Listen.SetStation(CcdConfig.ProcessCode, CcdConfig.StationCode, CcdConfig.MacCode);
            string strErr;
            if(!this._Listen.StartListenning(out strErr))
            {
                this.ShowErr(strErr);
                return false;
            }
            return true;
        }

        private void _Listen_NewShowMKCodeNotice(string sMKCode, string sGuid, short iSpecValue)
        {
            //显示CCD数据
            if (string.Compare(sMKCode, this._Code, true) != 0)
                BindData(sMKCode);
            this.SetResult(iSpecValue);
        }

        private void InitFormData()
        {
            //清空隐藏字段
            this._Code = string.Empty;
            this._GUID = string.Empty;
            //控件内容清除
            this.tbMkCode.Clear();
            this.tbDxCnt.Clear();
            this.tbBOMDesc.Clear();
            this.rtbPactInfo.Clear();
            this.rtbProcess.Clear();
            this.tbHistory.Clear();
            this.dgDxs.DataSource = null;
            this.SetResult(0);
            this.tbMkCode.ReadOnly = false;
            this.btRead.Enabled = true;
        }
        private bool TakeTuoPan(string sTuoPan)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.TakeTuoPan(sTuoPan, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "托盘领用失败，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            return true;
        }
        private bool RefreshStateView()
        {
            bool blRunning;
            if (this._Listen != null && this._Listen.Running)
                blRunning = true;
            else blRunning = false;
            Color cB, cF;
            string strText;
            if (blRunning)
            {
                if (this._Listen.Interrupt)
                {
                    cB = Color.Red;
                    cF = Color.White;
                    strText = "通讯中断";
                }
                else
                {
                    cB = Color.Lime;
                    cF = Color.Black;
                    strText = "结果获取中...";
                }
                if (this.btRead.Enabled)
                {
                    this.btRead.Enabled = false;
                }
            }
            else
            {
                cB = Color.White;
                cF = Color.Black;
                strText = "空闲";
                if (!this.btRead.Enabled)
                {
                    this.btRead.Enabled = true;
                }
            }
            if (this.labListenStatus.Text != strText)
                this.labListenStatus.Text = strText;
            if (this.labListenStatus.ForeColor != cF)
                this.labListenStatus.ForeColor = cF;
            if (this.labListenStatus.BackColor != cB)
                this.labListenStatus.BackColor = cB;

            return true;
        }
        public void RefreshStatus()
        {
            string sText;
            Color cB, cF;
            if (this._Listen == null)
            {
                sText = "通讯对象为空";
                cB = Color.Red;
                cF = Color.White;
            }
            else
            {
                if (!this._Listen.Running)
                {
                    sText = "脱机";
                    cB = Color.LightGray;
                    cF = Color.Black;
                }
                else
                {
                    //此时要看通讯对象返回
                    LuoLiuCCD.Communication.MyHanJieA.CommunicationStates state = this._Listen.GetCommunicationState();
                    if (state == LuoLiuCCD.Communication.MyHanJieA.CommunicationStates.GuidEmpty)
                    {
                        sText = "通讯中，但无任务。";
                        cB = Color.Yellow;
                        cF = Color.Black;
                    }
                    else if (state == LuoLiuCCD.Communication.MyHanJieA.CommunicationStates.Interrupted)
                    {
                        sText = "中断";
                        cB = Color.Red;
                        cF = Color.White;
                    }
                    else if (state == LuoLiuCCD.Communication.MyHanJieA.CommunicationStates.Stoped)
                    {
                        sText = "已脱机";
                        cB = Color.LightGray;
                        cF = Color.Black;
                    }
                    else if (state == LuoLiuCCD.Communication.MyHanJieA.CommunicationStates.Normal)
                    {
                        sText = "正常通讯";
                        cB = Color.Lime;
                        cF = Color.Black;
                    }
                    else
                    {
                        sText = "未知";
                        cB = Color.White;
                        cF = Color.Black;
                    }
                }
            }
            if (this.labListenStatus.Text != sText)
                this.labListenStatus.Text = sText;
            if (this.labListenStatus.BackColor != cB)
                this.labListenStatus.BackColor = cB;
            if (this.labListenStatus.ForeColor != cF)
                this.labListenStatus.ForeColor = cF;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshStatus();
        }
        #endregion
        #region 测试结果处理
        private void btStartRead_Click(object sender, EventArgs e)
        {
            if (this._Listen == null)
            {
                this.ShowErr("通讯实例为空，启动失败。");
                return;
            }
            string strErr;
            if (!this._Listen.StartListenning(out strErr))
            {
                this.ShowErr(strErr);
                return;
            }
        }
        private bool SendToRemote(short iValue)
        {
            //提交数据库
            int iReturnValue;
            string strMsg;
            string sGuid;
            try
            {
                this.BllDAL.CompeletedProcess(this._Code, LuoLiuCCD.CcdConfig.ProcessCode, LuoLiuCCD.CcdConfig.MacCode, LuoLiuCCD.CcdConfig.StationCode, iValue, DBNull.Value, DateTime.Now, out sGuid, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "保存结果失败，原因未知！";
                this.ShowMsg(strMsg);
                return  false;
            }
            this._GUID = sGuid;
            return true;
        }
        private void SetResult(short iValue)
        {
            Color cB, cF;
            string strText;
            if (iValue == 1)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格(A)";
            }
            else if (iValue == 2)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格(B)";
            }
            else if (iValue == 3)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格(C)";
            }
            else if (iValue == 4)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格(D)";
            }
            else if (iValue == 5)
            {
                cB = Color.Red;
                cF = Color.White;
                strText = "NG";
            }
            else
            {
                cB = Color.White;
                cF = Color.Black;
                strText = "------";
            }
            if (this.labResult.Text != strText)
                this.labResult.Text = strText;
            if (this.labResult.ForeColor != cF)
                this.labResult.ForeColor = cF;
            if (this.labResult.BackColor != cB)
                this.labResult.BackColor = cB;
        }
        #endregion
        #region 消息处理
        public override void ShowErr(string sErr)
        {
            if (this.chkStopShowErr.Checked) return;
            this.rtbErrMsg.Text = string.Format("{0}\r\n{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), sErr);
        }
        #endregion
        #region 窗口控件事件
        private void frmCCD_Load(object sender, EventArgs e)
        {
            this.Perinit();
        }
        
        
        #endregion
        #region 顶部菜单
        private void 终止结果读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._Listen!=null && this._Listen.Running)
            {
                this._Listen.StopListenning();
                this.ShowMsgRich("执行成功");
            }
        }
        #endregion
        private void 清空窗口数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._Listen != null && this._Listen.Running)
            {
                this.ShowMsg("设备通讯中，不能清空窗口数据！");
                return;
            }
            if (!this.IsUserConfirm("您确定要清空窗口数据吗？")) return;
            this.InitFormData();
        }

        private void 当前工作站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStationConfig frm = new frmStationConfig(true);
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.ucTitle1.Process = CcdConfig.ProcessName;
            this.ucTitle1.Mac = CcdConfig.MacName;
            this.ucTitle1.Station = CcdConfig.StationName;
        }

        private void 调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communication.frmDebug frm = new Communication.frmDebug();
            frm.Show();
        }

        private void tsbMsfForm_Click(object sender, EventArgs e)
        {
            Common.frmMyLog.ShowMyLog("");
        }
        

        private void tbMkCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
        }

        private void 撤销模块领用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._Code.Length == 0)
            {
                this.ShowMsg("您还未领用模块！");
                return;
            }
            if (this._Listen != null && this._Listen.Running)
            {
                this.ShowMsg("设备通讯中，不能清撤销当前模块领用！");
                return;
            }
            if (!this.IsUserConfirm("您确定要撤销吗？")) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.TakeMyMKCancel(this._Code, BasicData.BasicEntitys.SysDefaultValues.SysProcesses.CCD, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            //此时已经成功移除
            this.ShowMsgRich("撤销成功！");
            this.InitFormData();

        }

        private void ucMaterial1_RefreshMaterialItemDataNotice(short RefrehsType, bool blSucesful, string sMsg)
        {
            if (blSucesful)
            {
                this.ShowMsgRich("刷新成功！");
            }
            else
            {
                if (sMsg.Length == 0)
                    sMsg = "刷新失败，原因未知。";
                this.ShowMsg(sMsg);
            }
        }

        private void 自动读取测试结果ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAutoStartCCD frm = new frmAutoStartCCD();
            frm.ShowDialog(this);
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

        private void 导航ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 设备异常单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看登录信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btRead_Click(object sender, EventArgs e)
        {
            if (this.tbMkCode.Text.Length == 0) return;
            if (this.BindData(this.tbMkCode.Text))
            {
                this.ShowMsgRich("刷新成功");
                return;
            }
        }

        private void 历史绑定记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmCCDHistory frm = new DataM.frmCCDHistory(CcdConfig.MacCode);
            frm.Show();
        }

        private void 连接设备ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._Listen.Running)
            {
                this.ShowMsg("已经连接，请勿重复操作。");
                return;
            }
            this._Listen.SetStation(CcdConfig.ProcessCode, CcdConfig.StationCode, CcdConfig.MacCode);
            string strErr;
            if (!this._Listen.StartListenning(out strErr))
            {
                this.ShowErr(strErr);
                return;
            }
            this.ShowMsgRich("连接成功");
        }

        private void 断开设备连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._Listen.StopListenning();
            this.ShowMsgRich("操作成功");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CommonFuns.StartUpdate(new string[] { }, LuoLiuCCD.Version.GetCurrentVersions());
        }
    }
}
