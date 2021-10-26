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

namespace AutoAssign.DataM
{
    public partial class frmTestedData : Common.frmBase
    {
        string _RealTable_Batterys=string.Empty;
        string _RealTable_Result = string.Empty;
        string _TestCode;
        GrooveDetialBtyStatisticControler _GrooveDetialBtyStatisticControler = null;
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
        public frmTestedData(string sTestCode)
        {
            InitializeComponent();
            _TestCode = sTestCode;
            this.dgvSwitch.AutoGenerateColumns = false;
            this.tbTestCode.Text = _TestCode;
            this.dgvGroove.AutoGenerateColumns = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvUnMES.AutoGenerateColumns = false;
            this._GrooveDetialBtyStatisticControler = new GrooveDetialBtyStatisticControler(this);
            this._GrooveDetialBtyStatisticControler.GrooveStatisticFnisheNotice += _GrooveDetialBtyStatisticControler_GrooveStatisticFnisheNotice;
            this._GrooveDetialBtyStatisticControler.TuoPanStatisticFnishedNotice += _GrooveDetialBtyStatisticControler_TuoPanStatisticFnishedNotice;
            tvTuoPan.Nodes[0].Tag = 1;
            tvTuoPan.Nodes[1].Tag = 2;
            tvTuoPan.Nodes[2].Tag = 3;
            tvTuoPan.Nodes[3].Tag = 4;
            tvTuoPan.Nodes[4].Tag = 5;
            tvTuoPan.Nodes[5].Tag = 6;
            tvTuoPan.Nodes[6].Tag = 7;
            tvTuoPan.Nodes[7].Tag = 8;
            tvTuoPan.Nodes[8].Tag = 9;
            tvTuoPan.Nodes[9].Tag = 10;
            tvTuoPan.Nodes[10].Tag = 11;
            tvTuoPan.Nodes[11].Tag = 12;
            tvTuoPan.Nodes[12].Tag = 13;
            tvTuoPan.Nodes[13].Tag = 14;
            tvTuoPan.Nodes[14].Tag = 15;
            tvTuoPan.Nodes[15].Tag = 16;
            tvTuoPan.Nodes[16].Tag = 17;
            tvTuoPan.Nodes[17].Tag = 18;

        }

        private void _GrooveDetialBtyStatisticControler_TuoPanStatisticFnishedNotice(bool blSucessful, List<TuoPanData> tuoPans1, List<TuoPanData> tuoPans2, List<TuoPanData> tuoPans3, List<TuoPanData> tuoPans4, List<TuoPanData> tuoPans5, List<TuoPanData> tuoPans6, List<TuoPanData> tuoPans7, List<TuoPanData> tuoPans8, List<TuoPanData> tuoPans9, List<TuoPanData> tuoPans10, List<TuoPanData> tuoPans11, List<TuoPanData> tuoPans12, List<TuoPanData> tuoPans13, List<TuoPanData> tuoPans14, List<TuoPanData> tuoPans15, List<TuoPanData> tuoPans16, List<TuoPanData> tuoPans17, List<TuoPanData> tuoPans18)
        {
            //绑定托盘
            if (blSucessful)
            {
                this.BindCaoNotes(tvTuoPan.Nodes[0], tuoPans1);
                this.BindCaoNotes(tvTuoPan.Nodes[1], tuoPans2);
                this.BindCaoNotes(tvTuoPan.Nodes[2], tuoPans3);
                this.BindCaoNotes(tvTuoPan.Nodes[3], tuoPans4);
                this.BindCaoNotes(tvTuoPan.Nodes[4], tuoPans5);
                this.BindCaoNotes(tvTuoPan.Nodes[5], tuoPans6);
                this.BindCaoNotes(tvTuoPan.Nodes[6], tuoPans7);
                this.BindCaoNotes(tvTuoPan.Nodes[7], tuoPans8);
                this.BindCaoNotes(tvTuoPan.Nodes[8], tuoPans9);
                this.BindCaoNotes(tvTuoPan.Nodes[9], tuoPans10);
                this.BindCaoNotes(tvTuoPan.Nodes[10], tuoPans11);
                this.BindCaoNotes(tvTuoPan.Nodes[11], tuoPans12);
                this.BindCaoNotes(tvTuoPan.Nodes[12], tuoPans13);
                this.BindCaoNotes(tvTuoPan.Nodes[13], tuoPans14);
                this.BindCaoNotes(tvTuoPan.Nodes[14], tuoPans15);
                this.BindCaoNotes(tvTuoPan.Nodes[15], tuoPans16);
                this.BindCaoNotes(tvTuoPan.Nodes[16], tuoPans17);
                this.BindCaoNotes(tvTuoPan.Nodes[17], tuoPans18);
            }
            else
            {
                foreach (TreeNode tn in this.tvTuoPan.Nodes)
                {
                    BindCaoNotesShiBai(tn);
                }
            }
        }
        private void BindCaoNotesShiBai(TreeNode tn)
        {
            TreeNode tnChild;
            if(tn.Nodes.Count==0)
            {
                tnChild = new TreeNode();
                tn.Nodes.Add(tnChild);
            }
            else
            {
                tnChild = tn.Nodes[0];
            }
            tnChild.Text = "加载失败";
            tnChild.Tag = "";
            tn.ExpandAll();
        }
        private void BindCaoNotes(TreeNode tn, List<TuoPanData> tuoPans)
        {
            if (tn.Nodes.Count > 0)
                tn.Nodes.Clear();
            if(tuoPans!=null)
            {
                foreach(TuoPanData data in tuoPans)
                {
                    TreeNode tnChild = new TreeNode();
                    tnChild.Text = string.Format("{0}({1})", data.TuoCode, data.BtyCount);
                    tnChild.Tag = data.TuoCode;
                    tn.Nodes.Add(tnChild);
                }
            }
            tn.Collapse();
        }

        private void _GrooveDetialBtyStatisticControler_GrooveStatisticFnisheNotice(bool blSucessful, List<GrooveStatisticResult> reuslts)
        {
            DataTable dt = this.dgvGroove.DataSource as DataTable;
            if (dt == null) return;
            if(!blSucessful)
            {
                //此时失败，就直接显示失败
                foreach(DataRowView drv in dt.DefaultView)
                {
                    drv.Row["BtyCnt"] = "加载失败";
                    drv.Row["Btyrate"] = "加载失败";
                }
            }
            else
            {
                int iCaoIndex;
                GrooveStatisticResult entity;
                foreach (DataRowView drv in dt.DefaultView)
                {
                    if (drv.Row["grooveNo"].Equals(DBNull.Value))
                        iCaoIndex = 0;
                    else iCaoIndex = short.Parse(drv.Row["grooveNo"].ToString());
                    entity = reuslts.Find(delegate (GrooveStatisticResult temp)
                     {
                         return temp.CaoIndex == iCaoIndex;
                     });
                    if(entity==null)
                    {
                        drv.Row["BtyCnt"] = 0;
                        drv.Row["Btyrate"] = "";
                    }
                    else
                    {
                        drv.Row["BtyCnt"] = entity.BtyCount;
                        drv.Row["Btyrate"] = entity.RateText;
                    }
                }
            }
        }

        private bool BindData()
        {
            //此时有，则要加载初始化数据
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_Tested_Main where Code='{0}'", _TestCode.Replace("'", "''")), "V_Tested_Main"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [V_Tested_Grooves] where Code='{0}'", _TestCode.Replace("'", "''")), "V_Tested_Grooves"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM [Testing_FinishedTuoPan] where TestCode='{0}'", _TestCode.Replace("'", "''")), "Testing_FinishedTuoPan"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return false;
            }
            DataTable dt = ds.Tables["V_Tested_Main"];
            DataTable dtDetail = ds.Tables["V_Tested_Grooves"];
            DataRow dr = dt.DefaultView[0].Row;
            this.tbModeView.Text = JPSFuns.GetModeView(dr["ModeIsNeter"], dr["ModeIsScaner"]);
            this.tbProductSpec.Text = dr["Spec"].ToString();
            //this.tbProductClass.Text = dr["ClassName"].ToString();
            this.tbProductClass.Text = string.Format("{0}({1})", dr["ClassName"].ToString(), dr["Value"].ToString());
            this.tbGongYiType.Text = dr["GongYiTypeName"].ToString();
            this.tbCapacity.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["Capacity"], "#########0.######");
            this.tbStateView.Text = dr["StateView"].ToString();
            this.tbMacCode.Text = dr["MacCode"].ToString();
            this.tbOperatorName.Text = dr["OperatorName"].ToString();
            //人工编辑的数据
            this.tbMbatchNum.Text = dr["MbatchNum"].ToString();
            this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"], "yyyy-MM-dd HH:mm:ss");
            this.tbEndTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"], "yyyy-MM-dd HH:mm:ss");
            //订单相关2019-07-11
            this.tbOrderNo.Text = dr["OrderNo"].ToString();
            this.tbPactCode.Text = dr["PactCode"].ToString();
            //表对象
            this._RealTable_Batterys = dr["BatterysTable"].ToString();
            this._RealTable_Result = dr["ResultTable"].ToString();
            //绑定明细
            this.dgvGroove.DataSource = dtDetail;
            this.dgvUnMES.DataSource = ds.Tables["Testing_FinishedTuoPan"];
            string strErr;
            if(!this._GrooveDetialBtyStatisticControler.StartStatistic(this._RealTable_Result, out strErr))
            {
                this.ShowMsg(strErr);
            }
            SetDataGridViewRowStyle();
            this.BindSwitch(_TestCode);
            this.BindYaCha(_TestCode);
            return true;
        }
        private void SetDataGridViewRowStyle()
        {
            return;
            DataTable dt = this.dgvGroove.DataSource as DataTable;
            DataRow dr;
            Color color = Color.FromArgb(219, 225, 236);
            Color cNoBk, cNoFore;
            short iQuality;
            for (int i = 0; i < this.dgvGroove.Rows.Count; i++)
            {
                if (dt != null)
                {
                    dr = dt.DefaultView[i].Row;
                    if (dr["Quality"].Equals(DBNull.Value)) iQuality = 0;
                    else iQuality = short.Parse(dr["Quality"].ToString());
                    if (iQuality == 0)
                    {
                        cNoBk = Color.White;
                        cNoFore = Color.Gray;
                    }
                    else if (iQuality == 1)
                    {
                        cNoBk = Color.FromArgb(55, 88, 136);
                        cNoFore = Color.White;
                    }
                    else
                    {
                        cNoBk = Color.Maroon;
                        cNoFore = Color.White;
                    }
                    this.dgvGroove[0, i].Style.BackColor = cNoBk;
                    this.dgvGroove[0, i].Style.ForeColor = cNoFore;
                }
                if ((i % 2) == 0) continue;
                for (int j = 1; j < this.dgvGroove.Columns.Count; j++)
                {
                    this.dgvGroove[j, i].Style.BackColor = color;
                    //this.dgvGroove.Rows[i].DefaultCellStyle.BackColor = Color.Black;
                }
            }
        }
        #region  消息处理
        public void ShowErrAysn(string sMsg)
        {

        }
        public void ShowErr(string sMsg)
        {
            if (this._ErrForm.ErrMsg != sMsg)
                this._ErrForm.ErrMsg = sMsg;
            if (!this._ErrForm.Visible)
                this._ErrForm.Show();
        }

        #endregion
        #region 上传MES定义
        private void btSendMes_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvUnMES.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvUnMES);
            if(list.Count==0)
            {
                this.ShowMsg("请选中要上传MES的数据行。");
                return;
            }
            bool blupdated = false;
            foreach(int row in list)
            {
                string strTp = dt.DefaultView[row].Row["TuoPanCode"].ToString();
                if(this.SendMes(strTp))
                {
                    blupdated = true;
                }
            }
            if(blupdated)
            {
                this.BindData();
            }
        }
        private bool SendMes(string sTuoPanCode)
        {
            string strSql = string.Format("INSERT INTO LuoLiuAssignerSendMes.DBO.SendMes_FinishedTuoPan(TuoPanCode,TestCode,FinishedTime,DxCnt) SELECT TuoPanCode,TestCode,FinishedTime,DxCnt FROM Testing_FinishedTuoPan WHERE TuoPanCode='{0}';DELETE FROM Testing_FinishedTuoPan WHERE TuoPanCode='{0}'",sTuoPanCode.Replace("'","''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #endregion
        private void frmTestedData_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tvTuoPan_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sOrgTableName = this._RealTable_Result + "_YuanShi";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable($"SELECT name FROM SYSOBJECTS WHERE xtype='u' and name='{sOrgTableName}'");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(dt.Rows.Count>0)
            {
                BindResult_ContainOrgDxInfo(sOrgTableName);
            }
            else
            {
                BindResult();
            }
        }
        private void BindResult()
        {
            TreeNode tn = this.tvTuoPan.SelectedNode;
            if (tn == null || tn.Tag == null)
            {
                this.dgvList.DataSource = null;
            }
            else
            {
                string strSql = string.Empty;
                if (tn.Tag.ToString().Length == 0)
                {
                    TreeNode tnP = tn.Parent;
                    if (tnP != null && tnP.Tag != null && tnP.Tag.ToString().Length > 0)
                    {
                        strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where ISNULL(A.CaoIndex,'')={2}", this._RealTable_Result, this._RealTable_Batterys, tnP.Tag.ToString().Replace("'", "''"));
                    }
                }
                if (strSql.Length == 0)
                {
                    strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where ISNULL(A.TuoCode,'')='{2}'", this._RealTable_Result, this._RealTable_Batterys, tn.Tag.ToString().Replace("'", "''"));
                }
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.dgvList.DataSource = dt;
            }
        }
        private void BindResult_ContainOrgDxInfo(string sOrgTable)
        {
            TreeNode tn = this.tvTuoPan.SelectedNode;
            if (tn == null || tn.Tag == null)
            {
                this.dgvList.DataSource = null;
            }
            else
            {
                string strSql = string.Empty;
                if (tn.Tag.ToString().Length == 0)
                {
                    TreeNode tnP = tn.Parent;
                    if (tnP != null && tnP.Tag != null && tnP.Tag.ToString().Length > 0)
                    {
                        strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN,c.SN as OrgSN,C.OrgCap,C.OrgR,C.OrgV from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode LEFT JOIN {2} C ON C.MyCode=a.MyCode where ISNULL(A.CaoIndex,'')={3}", this._RealTable_Result, this._RealTable_Batterys,sOrgTable, tnP.Tag.ToString().Replace("'", "''"));
                    }
                }
                if (strSql.Length == 0)
                {
                    strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN,c.SN as OrgSN,C.OrgCap,C.OrgR,C.OrgV  from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode LEFT JOIN {2} C ON C.MyCode=a.MyCode where ISNULL(A.TuoCode,'')='{3}'", this._RealTable_Result, this._RealTable_Batterys, sOrgTable, tn.Tag.ToString().Replace("'", "''"));
                }
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.dgvList.DataSource = dt;
            }
        }
        private void btSearchSNCode_Click(object sender, EventArgs e)
        {
            if(this.tbSnCode.Text.Length==0)
            {
                this.ShowMsg("请输入电芯编号！");
                return;
            }
            DataTable dt;
            string strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where b.SN like '%{2}%'", this._RealTable_Result,this._RealTable_Batterys, this.tbSnCode.Text.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvList.DataSource = dt;
        }

        private void tbSnCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btSearchSNCode_Click(null, null);
        }

        private void btClearDataByTuoPan_Click(object sender, EventArgs e)
        {
            ClearData.frmByTuoPanCode frm = new ClearData.frmByTuoPanCode(this._TestCode);
            frm.ShowDialog();
            this.BindData();
        }

        private void btClearDataByCaoIndex_Click(object sender, EventArgs e)
        {
            ClearData.frmByCaoIndex frm = new ClearData.frmByCaoIndex(this._TestCode);
            frm.ShowDialog();
            this.BindData();
        }

        private void btTuoPanOutputCSV_Click(object sender, EventArgs e)
        {
            ExpFuns.frmCSVTestResult frm = new ExpFuns.frmCSVTestResult(this._TestCode, this._RealTable_Batterys, this._RealTable_Result);
            frm.ShowDialog(this);
        }
        private void BindSwitch(string sTestCode)
        {
            try
            {
                this.dgvSwitch.DataSource = Common.CommonDAL.DoSqlCommand.GetDateTable($"select * from Testing_GroovesAB where Code='{sTestCode.Replace("'", "''")}' order by GrooveNo asc");
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
            }
        }
        private void BindYaCha(string sTestCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable($"select * from Testing_YaCha where Code='{sTestCode.Replace("'", "''")}'");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            if (dt.Rows.Count == 0)
                this.tbYacha.Clear();
            else
            {
                this.tbYacha.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dt.Rows[0]["YaCha"], "#########0.######");
            }
        }
    }
}
