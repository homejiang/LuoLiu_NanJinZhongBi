using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.BasicData
{
    public partial class frmSelectPlan : Common.frmSelectBase
    {
        public frmSelectPlan()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
            this.comPactState.Items.Add("不限");
            this.comPactState.Items.Add("未完成");
            this.comPactState.Items.Add("已完成");
            this.comPactState.Items.Add("已被终止");
            this.comPactState.SelectedIndex = 1;
            this.comPactState.SelectedIndexChanged += new System.EventHandler(this.comPactState_SelectedIndexChanged);
            this.dtpStart.Value = DateTime.Now.AddDays(-7);
            this.dtpEnd.Value = DateTime.Now;
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvDetail.MultiSelect = this.MultiSelected;//是否允许多选
            if (this.MultiSelected)
                this.BindDataGridViewCheckBox(this.dgvDetail, this.colCheckBox);
            else
            {
                //单选无需添加复选框
                this.colCheckBox.Visible = false;
                this.dgvDetail.CellDoubleClick+=new DataGridViewCellEventHandler(dgvDetail_CellDoubleClick);
            }
            #region 绑定客户
            DataTable dt=null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable("SELECT VirCode FROM JC_Client order by VirCode asc");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
            }
            if(dt!=null)
            {
                this.comClient.Items.Clear();
                foreach(DataRow dr in dt.Rows)
                {
                    this.comClient.Items.Add(dr["VirCode"].ToString());
                }
            }
            #endregion
            this.tbPactCode.KeyDown += SearchText_KeyDown;
            this.comClient.KeyDown += SearchText_KeyDown;
            return true;
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                this.btSearch_Click(null, null);
            }
        }

        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM V_Pact_Detail_4AutoAssign where 1=1";
            if(this.tbPactCode.Text.Length>0)
            {
                strSql += string.Format(" and PactCode like '{0}'", this.tbPactCode.Text.Replace("'", "''"));
            }
            strSql += string.Format(" and CreateTime>='{0}'", this.dtpStart.Value.ToString("yyyy-MM-dd"));
            strSql += string.Format(" and CreateTime<'{0} 00:00:01'", this.dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            if (this.comClient.Text.Length > 0)
            {
                strSql += string.Format(" and ClientVirCode='{0}'", this.comClient.Text.Replace("'", "''"));
            }
            if (this.comPactState.SelectedIndex == 1)
            {
                strSql += " and isnull(CompeletedState,0)<=1";
            }
            else if (this.comPactState.SelectedIndex == 2)
            {
                strSql += " and isnull(CompeletedState,0)=2";
            }
            else if (this.comPactState.SelectedIndex == 3)
            {
                strSql += " and isnull(CompeletedState,0)=3";
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedPlanDetail> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedPlanDetail> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmBsFWithAllocateInfo_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region 工具栏控件事件
        
        //搜索按钮接收键盘事件
        private void SaarchValues_KeyDown(object sender, KeyEventArgs e)
        {
            //目前只触发回车事件
            if (e.KeyValue == 13)
                this.btSearch_Click(sender, null);
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!this.BindData()) return;
        }
        #endregion
        #region 底部按钮事件
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，请重新加载窗体。");
                return;
            }
            if (this.MultiSelected)
            {
                DataRow[] drs = dt.Select(this.DataGridViewCheckColumnName + "=1");
                if (drs.Length == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedPlanDetail>();
                SelectedPlanDetail info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedPlanDetail();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("请选中一行数据。");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedPlanDetail info = new SelectedPlanDetail();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedPlanDetail>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedPlanDetail
        {
            public SelectedPlanDetail()
            {
            }
            public SelectedPlanDetail(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strGUID;
            /// <summary>
            ///
            /// </summary>
            public object GUID
            {
                get { return this._strGUID; }
                set { this._strGUID = value; }
            }
            private object _strPactCode;
            /// <summary>
            ///
            /// </summary>
            public object PactCode
            {
                get { return this._strPactCode; }
                set { this._strPactCode = value; }
            }
            private object _detCreateTime;
            /// <summary>
            ///
            /// </summary>
            public object CreateTime
            {
                get { return this._detCreateTime; }
                set { this._detCreateTime = value; }
            }
            private object _iCompeletedState;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedState
            {
                get { return this._iCompeletedState; }
                set { this._iCompeletedState = value; }
            }
            private object _strCompeletedStateView;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedStateView
            {
                get { return this._strCompeletedStateView; }
                set { this._strCompeletedStateView = value; }
            }
            private object _strFactoryVirCode;
            /// <summary>
            ///
            /// </summary>
            public object FactoryVirCode
            {
                get { return this._strFactoryVirCode; }
                set { this._strFactoryVirCode = value; }
            }
            private object _strClientVirCode;
            /// <summary>
            ///
            /// </summary>
            public object ClientVirCode
            {
                get { return this._strClientVirCode; }
                set { this._strClientVirCode = value; }
            }
            private object _strComVirCode;
            /// <summary>
            ///
            /// </summary>
            public object ComVirCode
            {
                get { return this._strComVirCode; }
                set { this._strComVirCode = value; }
            }
            private object _detDeliveryDate;
            /// <summary>
            ///
            /// </summary>
            public object DeliveryDate
            {
                get { return this._detDeliveryDate; }
                set { this._detDeliveryDate = value; }
            }
            private object _strChengPinBOMSpec;
            /// <summary>
            ///
            /// </summary>
            public object ChengPinBOMSpec
            {
                get { return this._strChengPinBOMSpec; }
                set { this._strChengPinBOMSpec = value; }
            }
            private object _iChengPinBOMVersion;
            /// <summary>
            ///
            /// </summary>
            public object ChengPinBOMVersion
            {
                get { return this._iChengPinBOMVersion; }
                set { this._iChengPinBOMVersion = value; }
            }
            private object _strMkBOMSpec;
            /// <summary>
            ///
            /// </summary>
            public object MkBOMSpec
            {
                get { return this._strMkBOMSpec; }
                set { this._strMkBOMSpec = value; }
            }
            private object _iMkBOMVersion;
            /// <summary>
            ///
            /// </summary>
            public object MkBOMVersion
            {
                get { return this._iMkBOMVersion; }
                set { this._iMkBOMVersion = value; }
            }
            private object _iPlanQty;
            /// <summary>
            ///
            /// </summary>
            public object PlanQty
            {
                get { return this._iPlanQty; }
                set { this._iPlanQty = value; }
            }
            private object _iCompeletedQty;
            /// <summary>
            ///
            /// </summary>
            public object CompeletedQty
            {
                get { return this._iCompeletedQty; }
                set { this._iCompeletedQty = value; }
            }
            private object _iRemainQty;
            /// <summary>
            ///
            /// </summary>
            public object RemainQty
            {
                get { return this._iRemainQty; }
                set { this._iRemainQty = value; }
            }
            private object _strDianXinVirCode;
            /// <summary>
            ///
            /// </summary>
            public object DianXinVirCode
            {
                get { return this._strDianXinVirCode; }
                set { this._strDianXinVirCode = value; }
            }
            private object _strDianXinBzq;
            /// <summary>
            ///
            /// </summary>
            public object DianXinBzq
            {
                get { return this._strDianXinBzq; }
                set { this._strDianXinBzq = value; }
            }
            private object _strFxRatio;
            /// <summary>
            ///
            /// </summary>
            public object FxRatio
            {
                get { return this._strFxRatio; }
                set { this._strFxRatio = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.PactCode = dr["PactCode"];
                this.CreateTime = dr["CreateTime"];
                this.CompeletedState = dr["CompeletedState"];
                this.CompeletedStateView = dr["CompeletedStateView"];
                this.FactoryVirCode = dr["FactoryVirCode"];
                this.ClientVirCode = dr["ClientVirCode"];
                this.ComVirCode = dr["ComVirCode"];
                this.DeliveryDate = dr["DeliveryDate"];
                this.ChengPinBOMSpec = dr["ChengPinBOMSpec"];
                this.ChengPinBOMVersion = dr["ChengPinBOMVersion"];
                this.MkBOMSpec = dr["MkBOMSpec"];
                this.MkBOMVersion = dr["MkBOMVersion"];
                this.PlanQty = dr["PlanQty"];
                this.CompeletedQty = dr["CompeletedQty"];
                this.RemainQty = dr["RemainQty"];
                this.DianXinVirCode = dr["DianXinVirCode"];
                this.DianXinBzq = dr["DianXinBzq"];
                this.FxRatio = dr["FxRatio"];
            }
        }
        #endregion
        #region 列表框事件
        //行双击事件
        protected void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btTrue_Click(null, null);
        }
        #endregion

        private void comPactState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}