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
namespace LuoLiuDianHan.PeiFang
{
    public partial class frmAddPf : Common.frmBase
    {
        const string BTTEXT_START = "从设备读取";
        const string BTTEXT_END = "终止读取";
        #region 窗体数据连接实例
        private BLLDAL.HanJie _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.HanJie BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.HanJie();
                return _dal;
            }
        }
        #endregion 
        int _Plan_LCnt = 0;
        int _Plan_RCnt = 0;
        private string _GUID = string.Empty;
        Communication.StartReadPeiFang _StartControler = null;
        Communication.ReadPeiFangManager _ReadControler = null;
        HanJieOPC.OPCHelperPointSetting _OpcHelper = null;
        public frmAddPf()
        {
            InitializeComponent();
            this.btTrue.Enabled = false;
            this.btFromPLC.Text = BTTEXT_START;
        }
        private bool Perinit()
        {
            _OpcHelper = new HanJieOPC.OPCHelperPointSetting(Config.GetOPCTitle);
            _OpcHelper.IsDebug = LuoLiuDianHan.Communication.Debug.OPCDebug;
            string strErr;
            if (!this._OpcHelper.InitServer(out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            _StartControler = new Communication.StartReadPeiFang(this, _OpcHelper);
            _StartControler.ReadDoingNotice += _StartControler_ReadDoingNotice;
            _ReadControler = new Communication.ReadPeiFangManager(this, _OpcHelper);
            _ReadControler.DataFromPlcNotce += _ReadControler_DataFromPlcNotce;
            _ReadControler.ReadFinishedNotice += _ReadControler_ReadFinishedNotice;
            this.myDataGridView1.AutoGenerateColumns = false;
            
            if (!this._OpcHelper.SetReadDoing(2, out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            return true;
        }
        #region 消息处理
        frmErrMsg merrForm = null;
        public frmErrMsg _ErrForm
        {
            get
            {
                if (this.merrForm == null || this.merrForm.IsDisposed)
                    this.merrForm = new frmErrMsg();
                return this.merrForm;
            }
        }
        public void ShowErr(string sMsg)
        {
            if (this._ErrForm.ErrMsg != sMsg)
                this._ErrForm.ErrMsg = sMsg;
            if (!this._ErrForm.Visible)
                this._ErrForm.Show();
        }
        private void ShowLog(string sLog)
        {

        }
        #endregion
        private void _ReadControler_ReadFinishedNotice(bool blCompeleted, int iPlanLCnt, int iPlanRCnt, int iReadLCnt, int iReadRCnt)
        {
            if(blCompeleted)
            {
                this.btTrue.Enabled = true;
                this.labProcess.Text = "读取完毕";
                //读取补偿数据
                int BC_A1;
                int BC_A2;
                int BC_A3;
                int BC_A4;
                int BC_A5;
                int BC_A6;
                int BC_B1;
                int BC_B2;
                int BC_B3;
                int BC_B4;
                int BC_B5;
                int BC_B6;
                string sErr;
                if(!this._OpcHelper.ReadBC(out BC_A1,out BC_A2,out BC_A3,out BC_A4,out BC_A5,out BC_A6,
                out BC_B1,out BC_B2,out BC_B3,out BC_B4,out BC_B5,out BC_B6,out sErr))
                {
                    //读取补偿
                    this.ShowMsg("补偿数据读取失败，错误内容：" + sErr);
                    return;
                }
                //此时读取成功，则赋值
                this.tbBC_A1.Text = this.GetBcText(BC_A1);
                this.tbBC_A2.Text = this.GetBcText(BC_A2);
                this.tbBC_A3.Text = this.GetBcText(BC_A3);
                this.tbBC_A4.Text = this.GetBcText(BC_A4);
                this.tbBC_A5.Text = this.GetBcText(BC_A5);
                this.tbBC_A6.Text = this.GetBcText(BC_A6);
                this.tbBC_B1.Text = this.GetBcText(BC_B1);
                this.tbBC_B2.Text = this.GetBcText(BC_B2);
                this.tbBC_B3.Text = this.GetBcText(BC_B3);
                this.tbBC_B4.Text = this.GetBcText(BC_B4);
                this.tbBC_B5.Text = this.GetBcText(BC_B5);
                this.tbBC_B6.Text = this.GetBcText(BC_B6);
            }
            else
            {
                this.btTrue.Enabled = false;
                this.labProcess.Text = "读取已终止";
            }
        }
        private string GetBcText(int iValue)
        {
            return iValue.ToString();
            //decimal dec = (decimal)iValue / 1000M;
            //return dec.ToString("#########0.000");
        }

        private void _ReadControler_DataFromPlcNotce(short iStart, Communication.ReadPeiFangManager.MyDataEntity data1, Communication.ReadPeiFangManager.MyDataEntity data2, Communication.ReadPeiFangManager.MyDataEntity data3, Communication.ReadPeiFangManager.MyDataEntity data4)
        {
            if (this.DataSource == null)
            {
                this.ShowLog("数据源为空，无法将从设备读取的数据加载至窗口。");
                return;
            }
            //将获取的值显示出来
            DataTable dtPoint = this.DataSource.Tables["Mac_DianHan_PeiFangPoints"];
            if (dtPoint == null)
            {
                this.ShowLog("点位数据库为空，无法将从设备读取的数据加载至窗口。");
                return;
            }
            if(data1!=null && data1.Active)
            {
                DataRow drNew = dtPoint.NewRow();
                drNew["GUID"] = this._GUID;
                drNew["Pindex"] = iStart;
                drNew["P_Work"] = data1.P_Work;
                drNew["P_Type"] = data1.P_Type;
                drNew["P_AY"] = data1.P_AY;
                drNew["P_AZ"] = data1.P_AZ;
                drNew["P_BY"] = data1.P_BY;
                drNew["P_BZ"] = data1.P_BZ;
                dtPoint.Rows.Add(drNew);
                iStart++;
            }
            if (data2 != null && data2.Active)
            {
                DataRow drNew = dtPoint.NewRow();
                drNew["GUID"] = this._GUID;
                drNew["Pindex"] = iStart;
                drNew["P_Work"] = data2.P_Work;
                drNew["P_Type"] = data2.P_Type;
                drNew["P_AY"] = data2.P_AY;
                drNew["P_AZ"] = data2.P_AZ;
                drNew["P_BY"] = data2.P_BY;
                drNew["P_BZ"] = data2.P_BZ;
                dtPoint.Rows.Add(drNew);
                iStart++;
            }
            if (data3 != null && data3.Active)
            {
                DataRow drNew = dtPoint.NewRow();
                drNew["GUID"] = this._GUID;
                drNew["Pindex"] = iStart;
                drNew["P_Work"] = data3.P_Work;
                drNew["P_Type"] = data3.P_Type;
                drNew["P_AY"] = data3.P_AY;
                drNew["P_AZ"] = data3.P_AZ;
                drNew["P_BY"] = data3.P_BY;
                drNew["P_BZ"] = data3.P_BZ;
                dtPoint.Rows.Add(drNew);
                iStart++;
            }
            if (data4 != null && data4.Active)
            {
                DataRow drNew = dtPoint.NewRow();
                drNew["GUID"] = this._GUID;
                drNew["Pindex"] = iStart;
                drNew["P_Work"] = data4.P_Work;
                drNew["P_Type"] = data4.P_Type;
                drNew["P_AY"] = data4.P_AY;
                drNew["P_AZ"] = data4.P_AZ;
                drNew["P_BY"] = data4.P_BY;
                drNew["P_BZ"] = data4.P_BZ;
                dtPoint.Rows.Add(drNew);
                iStart++;
            }
            //计算百分比
            if (iStart < 20000)
            {
                int iCnt = iStart - 10000;
                decimal decTotal = this._Plan_LCnt + this._Plan_RCnt;
                if (decTotal == 0M)
                    return;
                decimal decR = (decimal)iCnt / decTotal;
                this.labProcess.Text = decR.ToString("#########0%");
            }
            else
            {
                int iCnt = iStart - 20000;
                decimal decTotal = this._Plan_LCnt + this._Plan_RCnt;
                decimal decR = (decimal)(iCnt + this._Plan_LCnt) / decTotal;
                this.labProcess.Text = decR.ToString("#########0%");
            }
        }

        private void _StartControler_ReadDoingNotice(int iPlanLCnt, int iPlanRCnt)
        {
            this._Plan_LCnt = iPlanLCnt;
            this._Plan_RCnt = iPlanRCnt;
            this.tbLCnt.Text = this._Plan_LCnt.ToString();
            this.tbRCnt.Text = this._Plan_RCnt.ToString();
            //开启读取过程
            string strErr;
            if(!this._ReadControler.StartListenning(this._Plan_LCnt,this._Plan_RCnt,out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }

        }

        private void btFromPLC_Click(object sender, EventArgs e)
        {
            if (this.btFromPLC.Text == BTTEXT_START)
            {
                if (this._StartControler == null)
                {
                    this.ShowMsg("对象为空！");
                    return;
                }
                if (this._StartControler.Running)
                {
                    this.ShowMsg("请求已发送过，请勿重复！");
                    return;
                }
                if (this._ReadControler == null)
                {
                    this.ShowMsg("reader对象为空！");
                    return;
                }
                if (this._ReadControler.Running)
                {
                    this.ShowMsg("读取请求已发送过，请勿重复！");
                    return;
                }
                if (this.DataSource == null)
                {
                    this.ShowMsg("数据源丢失不能执行操作");
                    return;
                }
                if (this.DataSource.Tables["Mac_DianHan_PeiFangPoints"].DefaultView.Count > 0)
                {
                    for (int i = this.DataSource.Tables["Mac_DianHan_PeiFangPoints"].DefaultView.Count; i > 0; i--)
                    {
                        this.DataSource.Tables["Mac_DianHan_PeiFangPoints"].DefaultView[i - 1].Row.Delete();
                    }
                }
                if (_OpcHelper == null)
                {
                    this.ShowMsg("设备写入对象为空！");
                    return;
                }
                string strErr;
                if (!this._OpcHelper.SetReadDoing(2, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                System.Threading.Thread.Sleep(500);
                if (!this._StartControler.StartListenning(out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.labProcess.Text = "等待设备反馈...";
            }
            else
            {
                this._ReadControler.StopListenning();
                string strErr;
                if (!this._OpcHelper.SetReadDoing(2, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.ShowMsgRich("终止成功");
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this._ReadControler != null && this._ReadControler.Running)
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
        #region 数据库源处理
        private bool BindData()
        {
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM Mac_DianHan_PeiFang WHERE 1=2", "Mac_DianHan_PeiFang", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM Mac_DianHan_PeiFangPoints WHERE 1=2", "Mac_DianHan_PeiFangPoints", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;   
            }
            this._GUID = Guid.NewGuid().ToString();
            DataRow drNew = ds.Tables["Mac_DianHan_PeiFang"].NewRow();
            drNew["GUID"] = this._GUID;
            drNew["MacCode"] = Config.MacCode;
            drNew["Creater"] = Common.CurrentUserInfo.UserCode;
            ds.Tables["Mac_DianHan_PeiFang"].Rows.Add(drNew);
            DataTable dtPoints = ds.Tables["Mac_DianHan_PeiFangPoints"];
            DataColumn dc = new DataColumn("P_WorkView", typeof(string));
            dc.Expression = "IIF(isnull(P_Work,0)=1,'是','否')";
            dtPoints.Columns.Add(dc);
            //dc = new DataColumn("P_AYView", typeof(decimal));
            //dc.Expression = "P_AY/1000.000";
            //dtPoints.Columns.Add(dc);
            //dc = new DataColumn("P_AZView", typeof(decimal));
            //dc.Expression = "P_AZ/1000.000";
            //dtPoints.Columns.Add(dc);
            //dc = new DataColumn("P_BYView", typeof(decimal));
            //dc.Expression = "P_BY/1000.000";
            //dtPoints.Columns.Add(dc);
            //dc = new DataColumn("P_BZView", typeof(decimal));
            //dc.Expression = "P_BZ/1000.000";
            //dtPoints.Columns.Add(dc);
            this.DataSource = ds;
            this.myDataGridView1.DataSource = dtPoints;
            return true;
        }
        private bool Save()
        {
            DataTable dtMain = this.DataSource.Tables["Mac_DianHan_PeiFang"];
            if(dtMain.DefaultView.Count==0)
            {
                this.ShowMsg("数据源不准确！");
                return false;
            }
            if(this.tbName.Text.Length==0)
            {
                this.ShowMsg("请输入配方名称！");
                return false;
            }
            DataTable dtCount;
            try
            {
                dtCount = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM Mac_DianHan_PeiFang WHERE PName='{0}'", this.tbName.Text.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(int.Parse(dtCount.Rows[0][0].ToString())>0)
            {
                this.ShowMsg("该配方名已经存在，请更换！");
                return false;
            }
            DataRow dr = dtMain.DefaultView[0].Row;
            dr["PName"] = this.tbName.Text;
            dr["LP_Cnt"] = this._Plan_LCnt;
            dr["RP_Cnt"] = this._Plan_RCnt;
            int iValue;
            //工位1
            if (!GetIntValue("工位1的左进给", this.tbBC_A1.Text, out iValue)) return false;
            dr["BC_A1"] = iValue;
            if (!GetIntValue("工位1的左前后", this.tbBC_A2.Text, out iValue)) return false;
            dr["BC_A2"] = iValue;
            if (!GetIntValue("工位1的左提升", this.tbBC_A3.Text, out iValue)) return false;
            dr["BC_A3"] = iValue;
            if (!GetIntValue("工位1的右进给", this.tbBC_A4.Text, out iValue)) return false;
            dr["BC_A4"] = iValue;
            if (!GetIntValue("工位1的右前后", this.tbBC_A5.Text, out iValue)) return false;
            dr["BC_A5"] = iValue;
            if (!GetIntValue("工位1的右提升", this.tbBC_A6.Text, out iValue)) return false;
            dr["BC_A6"] = iValue;
            //工位2
            if (!GetIntValue("工位2的左进给", this.tbBC_B1.Text, out iValue)) return false;
            dr["BC_B1"] = iValue;
            if (!GetIntValue("工位2的左前后", this.tbBC_B2.Text, out iValue)) return false;
            dr["BC_B2"] = iValue;
            if (!GetIntValue("工位2的左提升", this.tbBC_B3.Text, out iValue)) return false;
            dr["BC_B3"] = iValue;
            if (!GetIntValue("工位2的右进给", this.tbBC_B4.Text, out iValue)) return false;
            dr["BC_B4"] = iValue;
            if (!GetIntValue("工位2的右前后", this.tbBC_B5.Text, out iValue)) return false;
            dr["BC_B5"] = iValue;
            if (!GetIntValue("工位2的右提升", this.tbBC_B6.Text, out iValue)) return false;
            dr["BC_B6"] = iValue;
            //开始保存
            try
            {
                this.BllDAL.SavePact(this.DataSource);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        private bool GetIntValue(string sTagName,string sText,out int iValue)
        {
            if(sText.Length==0)
            {
                iValue = 0;
                this.ShowMsg("保存失败，因为"+sTagName +"的值为空！");
                return false;
            }
            if(!int.TryParse(sText,out iValue))
            {
                iValue = 0;
                this.ShowMsg("保存失败，因为" + sTagName + "的值不是有效数值！");
                return false;
            }
            return true;
        }
        #endregion

        private void frmAddPf_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if(!this.BindData())
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return;
            }
            this.FormState = Common.MyEnums.FormStates.New;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.Save())
            {
                this.ShowMsgRich("保存成功");
                this.btTrue.Enabled = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void linkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMyLogB.ShowMyLog(string.Empty);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this._ReadControler.Stop = int.Parse(tbStop.Text);
        }
    }
}
