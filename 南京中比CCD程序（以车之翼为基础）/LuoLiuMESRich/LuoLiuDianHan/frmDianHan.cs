using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuDianHan
{
    public partial class frmDianHan : Common.frmProduceBase
    {
        #region 工序相关字段
        public string _ProcessCode = string.Empty;
        public string _StationCode = string.Empty;
        public string _MacCode = string.Empty;
        #endregion
        public Communication.MyHanJieA _MyHanJieA = null;
        public DataTable _DtSource1 = null;
        #region 隐藏字段
        string _BOMGuid;
        string _BOMGuid2;
        string _MKCode = string.Empty;
        string _MKCode2 = string.Empty;
        /// <summary>
        /// 对应字段Produce_SFG1_Process.GUID
        /// </summary>
        string _Guid = string.Empty;
        string _Guid2 = string.Empty;
        /// <summary>
        /// 动态表的序号
        /// </summary>
        int _TableN = 0;
        int _TableN2 = 0;
        #endregion
        public frmDianHan()
        {
            InitializeComponent();
            this._ProcessCode = Config.ProcessCode;
            this._MacCode = Config.MacCode;
            this._StationCode = Config.StationCode;
            this.调试ToolStripMenuItem.Enabled = Communication.Debug.OPCDebug;
            this.调试配方ToolStripMenuItem.Enabled = Communication.Debug.OPCDebug;
        }
        private void frmDianHan_Load(object sender, EventArgs e)
        {
            Perinit();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
        #region 处理函数
        private bool Perinit()
        {
            BindOperator();
            BindTitle();
            this.timer1.Interval = 800;
            this.timer1.Enabled = true;
            this.ConnectMac();
            return true;
        }
        public void BindTitle()
        {
            this.ucTitle1.Process = Config.ProcessName;
            this.ucTitle1.Station = Config.StationName;
            this.ucTitle1.Mac = Config.MacName;
        }
        private void BindData(string sMkCode)
        {
            if (sMkCode.Length == 0)
            {
                this.tbMkCode.Clear();
                this.tbDxCnt.Clear();
                this.tbBOMDesc.Clear();
                this.rtbPactInfo.Clear();
                //this.rtbProcess.Clear();
                
                this._BOMGuid = string.Empty;
                this._MKCode = string.Empty;
                this._Guid = string.Empty;
                this._TableN = 0;
            }
            else
            {
                if (BindSFGInfo(sMkCode))
                    this._MKCode = sMkCode;
            }
        }
        private bool BindSFGInfo(string sMkCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process1_GetSFGInfo '{0}','{1}'"
                    , sMkCode.Replace("'", "''"), this._ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                //此时有错误，当前工序加载失败
                this.ShowErr(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("基础信息加载失败！");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbMkCode.Text = sMkCode;
            this._BOMGuid = dr["BOMGuid"].ToString();
            this.tbDxCnt.Text = dr["DxCnt"].ToString();
            this.tbBOMDesc.Text = dr["BOMDesc"].ToString();
            this.rtbPactInfo.Clear();
            //this.rtbProcess.Clear();
            Common.CommonFuns.AddRichTexBoxText(dr["PlanInfo"].ToString(), this.rtbPactInfo);
            //Common.CommonFuns.AddRichTexBoxText(dr["ProcessInfo"].ToString(), this.rtbProcess);
            return true;
        }
        private void BindData2(string sMkCode)
        {
            if (sMkCode.Length == 0)
            {
                this.tbMkCode2.Clear();
                this._BOMGuid2 = string.Empty;
                this.tbDxCnt2.Clear();
                this.tbBOMDesc2.Clear();
                this.rtbPactInfo2.Clear();
                //this.rtbProcess2.Clear();

                this._BOMGuid2 = string.Empty;
                this._MKCode2 = string.Empty;
                this._Guid2 = string.Empty;
                this._TableN2 = 0;
            }
            else
            {
                if (BindSFGInfo2(sMkCode))
                    this._MKCode2 = sMkCode;
            }
        }
        private bool BindSFGInfo2(string sMkCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Process1_GetSFGInfo '{0}','{1}'"
                    , sMkCode.Replace("'", "''"), this._ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                //此时有错误，当前工序加载失败
                this.ShowErr(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("基础信息加载失败！");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbMkCode2.Text = sMkCode;
            this._BOMGuid2 = dr["BOMGuid"].ToString();
            this.tbDxCnt2.Text = dr["DxCnt"].ToString();
            this.tbBOMDesc2.Text = dr["BOMDesc"].ToString();
            this.rtbPactInfo2.Clear();
            //this.rtbProcess2.Clear();
            Common.CommonFuns.AddRichTexBoxText(dr["PlanInfo"].ToString(), this.rtbPactInfo2);
            //Common.CommonFuns.AddRichTexBoxText(dr["ProcessInfo"].ToString(), this.rtbProcess2);
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
        private void InitFormData()
        {
            this.tbMkCode.Clear();
            this.tbDxCnt.Clear();
            this.tbBOMDesc.Clear();
            this.rtbPactInfo.Clear();
           // this.rtbProcess.Clear();
            this.tbPIndex.Clear();
            this.tbPtCnt.Clear();
            this.tbPtCntRemain.Clear();

            this.tbMkCode2.Clear();
            this.tbDxCnt2.Clear();
            this.tbBOMDesc2.Clear();
            this.rtbPactInfo2.Clear();
            //this.rtbProcess2.Clear();
            //清空隐藏字段
            this._BOMGuid = string.Empty;
            this._MKCode = string.Empty;
            this._Guid = string.Empty;
            this._TableN = 0;

            this._BOMGuid2 = string.Empty;
            this._MKCode2 = string.Empty;
            this._Guid2 = string.Empty;
            this._TableN2 = 0;

            //清空实时数据
            this.tbPt_CurrentPoint1.Clear();
            this.tbPt_PeiFang1.Clear();
            this.tbPt_A1.Clear();
            this.tbPt_V1.Clear();
            this.tbPt_CurrentPoint2.Clear();
            this.tbPt_PeiFang2.Clear();
            this.tbPt_A2.Clear();
            this.tbPt_V2.Clear();
        }
        #endregion
        #region 设备通讯相关
        public bool ConnectMac()
        {
            if (_MyHanJieA == null)
            {
                this._MyHanJieA = new Communication.MyHanJieA(this);
                this._MyHanJieA.SetStation(Config.ProcessCode, Config.StationCode, Config.MacCode);
                this._MyHanJieA.ClearTaskNotice += _MyHanJieA_ClearTaskNotice;
                this._MyHanJieA.FoundNewMKCodeNotice += _MyHanJieA_FoundNewMKCodeNotice;
                this._MyHanJieA.HanDianParamtersNotice += _MyHanJieA_HanDianParamtersNotice;
            }
            string sErr;
            if(!this._MyHanJieA.ConnectMac(out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            return true;
        }
        bool _NoticedEndTime = false;
        private void _MyHanJieA_HanDianParamtersNotice(HanJieOPC.DianHanDataEntity data)
        {
            int iIndex = data.Pt_CurrentPoint1 + 1;
            if(data.Pt_CurrentPoint2 > iIndex)
            {
                iIndex = data.Pt_CurrentPoint2;
            }
            int iRemain = data.Rt_PointCnt - iIndex;
            this.SetText(tbPIndex, iIndex);
            this.SetText(tbPtCntRemain, iRemain);
            this.SetText(tbPtCnt, data.Rt_PointCnt);
            //点位参数
            this.SetText(this.tbPt_CurrentPoint1, data.Pt_CurrentPoint1);
            this.SetText(this.tbPt_PeiFang1, data.Pt_PeiFang1);
            this.SetText(this.tbPt_A1, data.Pt_A1);
            this.SetText(this.tbPt_V1, data.Pt_V1);

            this.SetText(this.tbPt_CurrentPoint2, data.Pt_CurrentPoint2);
            this.SetText(this.tbPt_PeiFang2, data.Pt_PeiFang2);
            this.SetText(this.tbPt_A2, data.Pt_A2);
            this.SetText(this.tbPt_V2, data.Pt_V2);
            if(iRemain<=0)
            {
                //此时已经结束了，则要通知完成
                if(!_NoticedEndTime)
                {
                    if(this.NoticeEndTime())
                    {
                        this._NoticedEndTime = true;
                    }
                }
            }
        }
        private bool NoticeEndTime()
        {
            List<string> listSql = new List<string>();
            if(this._Guid.Length>0)
            {
                listSql.Add(string.Format("update Produce_SFG1_Process set EndTime=GETDATE(),STATE=1 where GUID='{0}'", this._Guid.Replace("'","''")));
            }
            if (this._Guid2.Length > 0)
            {
                listSql.Add(string.Format("update Produce_SFG1_Process set EndTime=GETDATE(),STATE=1 where GUID='{0}'", this._Guid2.Replace("'", "''")));
            }
            if(listSql.Count>0)
            {
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(listSql);
                }
                catch(Exception ex)
                {
                    this.ShowErr(string.Format("通知服务器结束焊接时出错：{0}({1})", ex.Message, ex.Source));
                    return false;
                }
            }
            return true;
        }
        private void SetText(TextBox tb,int iValue)
        {
            if (tb.Text != iValue.ToString())
                tb.Text = iValue.ToString();
        }
        private void SetText(TextBox tb, decimal decValue)
        {
            string stText = decValue.ToString("#########0.###");
            if (tb.Text != stText)
                tb.Text = stText;
        }

        private void _MyHanJieA_FoundNewMKCodeNotice(string sMkCode1, string sGuid1, int iTableN1, string sMkCode2, string sGuid2, int iTableN2, int iTotalPtCnt)
        {
            this._Guid = sGuid1;
            if(string.Compare(sMkCode1,this._MKCode,true)!=0)
            {
                this._Guid = sGuid1;
                this._TableN = iTableN1;
                this.tbPIndex.Clear();
                this.tbPtCnt.Text = iTotalPtCnt.ToString();
                this.BindData(sMkCode1);
                _NoticedEndTime = false;
            }
            //第2个模块
            if (string.Compare(sMkCode2, this._MKCode2, true) != 0)
            {
                this._Guid2 = sGuid2;
                this._TableN = iTableN1;
                this.tbPIndex.Clear();
                this.tbPtCnt.Text = iTotalPtCnt.ToString();
                this.BindData2(sMkCode2);
                _NoticedEndTime = false;
            }
        }

        private void _MyHanJieA_ClearTaskNotice()
        {
            //清空窗口
            InitFormData();
        }

        public void RefreshStatus()
        {
            string sText;
            Color cB, cF;
            if (this._MyHanJieA == null)
            {
                sText = "通讯对象为空";
                cB = Color.Red;
                cF = Color.White;
            }
            else
            {
                if (!this._MyHanJieA.Running)
                {
                    sText = "脱机";
                    cB = Color.LightGray;
                    cF = Color.Black;
                }
                else
                {
                    //此时要看通讯对象返回
                    Communication.CommunicationStates state = this._MyHanJieA.GetCommunicationState();
                    if (state == Communication.CommunicationStates.GuidEmpty)
                    {
                        sText = "通讯中，但无任务。";
                        cB = Color.Yellow;
                        cF = Color.Black;
                    }
                    else if (state == Communication.CommunicationStates.Interrupted)
                    {
                        sText = "中断";
                        cB = Color.Red;
                        cF = Color.White;
                    }
                    else if (state == Communication.CommunicationStates.Stoped)
                    {
                        sText = "已脱机";
                        cB = Color.LightGray;
                        cF = Color.Black;
                    }
                    else if (state == Communication.CommunicationStates.Normal)
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
        #region 消息
        public override void ShowMsg(string strMsg)
        {
            frmMyException.ShowException(strMsg);
        }
        public override void ShowErr(string sErr)
        {
            if (this.chkStopShowErr.Checked) return;
            this.rtbErrMsg.Text = string.Format("{0}\r\n{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), sErr);
        }
        #endregion
        #region 顶部工具栏
        private void 初始化设备连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._MyHanJieA != null)
            {
                //先关闭设备连接
                this._MyHanJieA.DisconnectMac();
            }
            //重新连接
            Thread.Sleep(1000);
            if(this.ConnectMac())
            {
                this.ShowMsgRich("连接成功！");
            }
        }


        private void 断开设备连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._MyHanJieA != null)
            {
                //先关闭设备连接
                this._MyHanJieA.DisconnectMac();
            }
        }

        private void 历史绑定记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmDianHanHistory frm = new DataM.frmDianHanHistory(Config.MacCode);
            frm.Show(this);
        }

        private void 清空窗口数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFormData();
        }

        private void 当前工作站ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStationConfig frm = new frmStationConfig(false);
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindTitle();
            if (this._MyHanJieA != null)
            {
                this._MyHanJieA.SetStation(this._ProcessCode, this._StationCode, this._MacCode);
            }
        }
        #endregion
        private void 调试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communication.frmDebug frm = new Communication.frmDebug();
            frm.Show();
        }
        private void 查看错误信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyException.ShowException("");
        }
        private void 扫码监听日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyLog.ShowMyLog(string.Empty);
        }

        private void 焊点结果监听ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyLogB.ShowMyLog(string.Empty);
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            this.BindOperator();
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CurrentUserInfo.Logout();
            this.BindOperator();
            this.ShowMsgRich("注销成功");
        }

        private void 查看当前模块电焊数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 点焊机配方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeiFang.frmPfList frm = new PeiFang.frmPfList(Config.MacCode);
            frm.Show();
        }

        private void 模块1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this._Guid.Length==0)
            {
                this.ShowMsg("模块1没有加载任何模块数据。");
                return;
            }
            DataM.frmDianHanPoints frm = new DataM.frmDianHanPoints(this._Guid);
            frm.Show();
        }

        private void 模块2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._Guid2.Length == 0)
            {
                this.ShowMsg("模块2没有加载任何模块数据。");
                return;
            }
            DataM.frmDianHanPoints frm = new DataM.frmDianHanPoints(this._Guid);
            frm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CommonFuns.StartUpdate(new string[] { }, LuoLiuDianHan.Version.GetCurrentVersions());
        }

        private void 调试配方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communication.frmDebug4Pf frm = new Communication.frmDebug4Pf();
            frm.Show();
        }

        private void 添加点焊配方ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeiFang.frmAddPf frm = new PeiFang.frmAddPf();
            if(frm.ShowDialog(this)==DialogResult.OK)
            {
                PeiFang.frmPfList frmList = new PeiFang.frmPfList(this._MacCode);
                frm.Show();
            }
        }
    }
}
