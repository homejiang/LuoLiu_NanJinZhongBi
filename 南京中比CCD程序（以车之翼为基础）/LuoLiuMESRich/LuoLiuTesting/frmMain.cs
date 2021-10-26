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

namespace LuoLiuTesting
{
    public partial class frmMain : Common.frmProduceBase
    {
        string _Code = string.Empty;
        public string _BOMGuid = string.Empty;
        Communication.MyTesting _Listen = null;
        #region 隐藏字段
        /// <summary>
        /// 当前作业提交后的GUID，该值是在成功保存结果后从数据库返回的
        /// </summary>
        string _GUID = string.Empty;
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion
        public frmMain()
        {
            InitializeComponent();
        }
        #region 重写函数
        public override void AcitiveTimer_Doing(object Arg)
        {
            if (Arg == null) return;
            if (string.Compare(Arg.ToString(), "NewTest", true) == 0)
            {
                //模块编号获取焦点
                this.tbMkCode.Focus();
                this.tbMkCode.Select();
            }
        }
        #endregion
        #region 加载数据
        public void BindTitle()
        {
            this.ucTitle1.Process = TestingConfig.ProcessName;
            this.ucTitle1.Station = TestingConfig.StationName;
            this.ucTitle1.Mac = TestingConfig.MacName;
        }
        private bool BindData(string sCode)
        {
            if (!this.BindSFGInfo(sCode)) return false;
            if (!this.BindMaterial(sCode)) return false;
            this.BindHistory(sCode);
            this.ucStatistic11.MyRefresh(LuoLiuTesting.TestingConfig.ProcessCode, LuoLiuTesting.TestingConfig.MacCode, this._BOMGuid);
            if (this._Code != sCode)
                this._Code = sCode;
            return true;
        }
        private bool BindSFGInfo(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process1_GetSFGInfo '{0}','{1}'"
                    , sCode.Replace("'", "''"), LuoLiuTesting.TestingConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                //此时有错误，当前工序加载失败
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("基础信息加载失败！");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this._BOMGuid = dr["BOMGuid"].ToString();
            this.tbDxCnt.Text = dr["DxCnt"].ToString();
            this.tbBOMDesc.Text = dr["BOMDesc"].ToString();
            this.rtbPactInfo.Clear();
            this.rtbProcess.Clear();
            Common.CommonFuns.AddRichTexBoxText(dr["PlanInfo"].ToString(), this.rtbPactInfo);
            Common.CommonFuns.AddRichTexBoxText(dr["ProcessInfo"].ToString(), this.rtbProcess);
            return true;
        }
        private bool BindMaterial(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("exec Process1_GetMaterials '{0}','{1}'"
                    , sCode.Replace("'", "''"), LuoLiuTesting.TestingConfig.ProcessCode.Replace("'", "''")));
                //dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Produce_SFG1_Materials WHERE Code='{0}' AND ProcessCode='{1}'"
                //   , sCode.Replace("'", "''"), LuoLiuCCD.CcdConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            List<Common.UserControls.MaterialEntity> list = new List<Common.UserControls.MaterialEntity>();
            foreach (DataRow dr in dt.Rows)
            {
                Common.UserControls.MaterialEntity entity = new Common.UserControls.MaterialEntity(dr);
                list.Add(entity);
            }
            this.ucMaterial1.InitMaterial(list);
            return true;
        }
        private bool BindHistory(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT EndTime,Quality FROM Produce_SFG1_Process WHERE Code='{0}' AND ProcessCode='{1}' AND isnull(State,0)<>-1 order by EndTime ASC"
                    , sCode.Replace("'", "''"), LuoLiuTesting.TestingConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            string str = string.Empty;
            string sResult;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Quality"].ToString() == "1")
                    sResult = "合格";
                else if (dr["Quality"].ToString() == "2") sResult = "不合格";
                else if (dr["Quality"].ToString() == "") sResult = "待定";
                else sResult = "unkown";

                str += string.Format("{0}->{1}\r\n", Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm"), sResult);
            }
            if (str.Length > 1)
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
            this._Listen = new Communication.MyTesting(this);
            this._Listen.CCDResultNotice += _Listen_CCDResultNotice;
            this.InitFormData();

            //设置标题信息
            this.ucTitle1.Process = TestingConfig.ProcessName;
            this.ucTitle1.Mac = TestingConfig.MacName;
            this.ucTitle1.Station = TestingConfig.StationName;
            this.ucTitle1.BOMClassName = TestingConfig.BOMClassName;
            this.BindOperator();
            this.BindTitle();
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
            return true;
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

            this.SetResult(0);
            this.tbMkCode.ReadOnly = false;
            this.btRead.Enabled = true;
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
            //此时启动成功
            this.RefreshStateView();
        }
        private bool SendToRemote(short iValue)
        {
            //提交数据库
            int iReturnValue;
            string strMsg;
            string sGuid;
            try
            {
                this.BllDAL.CompeletedProcess(this._Code, LuoLiuTesting.TestingConfig.ProcessCode, LuoLiuTesting.TestingConfig.MacCode, LuoLiuTesting.TestingConfig.StationCode, iValue, DBNull.Value, DateTime.Now, out sGuid, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "保存结果失败，原因未知！";
                this.ShowMsg(strMsg);
                return false;
            }
            this._GUID = sGuid;
            return true;
        }
        private void _Listen_CCDResultNotice(short iValue)
        {
            if (!SendToRemote(iValue)) return;
            //测试已经有结果了
            SetResult(iValue);

        }
        private void SetResult(short iValue)
        {
            Color cB, cF;
            string strText;
            if (iValue == 1)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格";
            }
            else if (iValue == 2)
            {
                cB = Color.Red;
                cF = Color.White;
                strText = "不合格";
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
        #region 窗口控件事件
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Perinit();
        }
        private void btFinished_Click(object sender, EventArgs e)
        {
            //结束当前测试，这里做一个限制还未完成的测试不能直接清除，避免用户操作失误
            if (this._Code.Length == 0) return;//还未加载成功过，直接退出
            if (this._GUID.Length == 0)
            {
                this.ShowMsg("当前产品还未有检测结果，您不能结束测试！");
                return;
            }
            if (this._Listen != null && this._Listen.Running)
            {
                this.ShowMsg("请先结束当前通讯状态！");
                return;
            }
            //保存原材料结果
            string sErr;
            if (!this.ucMaterial1.Check(out sErr))
            {
                this.ShowMsg(sErr);
                return;
            }
            //保存原材料数据
            List<Common.UserControls.MaterialEntity> materials = this.ucMaterial1.GetMaterils(out sErr);
            if (materials == null)
            {
                this.ShowMsg(sErr);
                return;
            }
            try
            {
                this.BllDAL.SaveMaterial(this._GUID, materials);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.InitFormData();
            this.ucStatistic11.Refresh();
            //处理鼠标焦点
            this.AcitiveTimer(200, "NewTest");
        }
        private void tbTuoPan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btRead_Click(null, null);
        }
        private void btRead_Click(object sender, EventArgs e)
        {
            if (this.tbMkCode.Text.Length == 0) return;
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            //判断是否已经有测试在进行
            if (this._Listen != null && this._Listen.Running)
            {
                this.ShowMsg("当前有测试还在进行，您可以直接终止它，以便开始新的测试。");
                return;
            }
            
            if (this.BindData(this.tbMkCode.Text))
            {
                //加载成功，则自动开启测试
                if (!this.btStartRead.Enabled)
                    this.btStartRead.Enabled = true;
                if (!this.btFinished.Enabled)
                    this.btFinished.Enabled = true;
                this.tbMkCode.ReadOnly = true;
                this.btRead.Enabled = false;
                //播放正常声音
                Common.CommonFuns.PlayOkMsg();
                if (Communication.MyTesting.AutoStartCCD)
                {
                    btStartRead_Click(null, null);
                }
            }
            else
            {
                if (this.btStartRead.Enabled)
                    this.btStartRead.Enabled = false;
                if (this.btFinished.Enabled)
                    this.btFinished.Enabled = false;
            }
        }
        private void ucTitle1_SetBOMClass(object sender, EventArgs e)
        {
            //选择BOM类型
            BasicData.BOM.frmSelectBOMClass frm = new BasicData.BOM.frmSelectBOMClass();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            //写入
            TestingConfig.BOMClassCode = frm.SelectedData[0].Code.ToString();
            TestingConfig.BOMClassName = frm.SelectedData[0].ClassName.ToString();
            //写入配置文件
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Station", "BOMClassCode", TestingConfig.BOMClassCode);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.ucTitle1.BOMClassName = TestingConfig.BOMClassName;
            this.ShowMsgRich("设置成功");
        }
        #endregion
        #region 消息处理
        public override void ShowErr(string sErr)
        {

        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshStateView();
        }

        private void 设置当前测试对象ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucTitle1_SetBOMClass(null, null);
        }
    }
}
