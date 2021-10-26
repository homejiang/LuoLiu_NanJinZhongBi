using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.Client
{
    public partial class frmSelectClient : Common.frmSelectBase
    {
        public frmSelectClient()
        {
            InitializeComponent();
        }
        #region 处理函数
        private bool Perinit()
        {
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
            return true;
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM JC_Client WHERE 1=1";
            if (this.tbClientName.Text != string.Empty)
            {
                strSql += string.Format(" AND (CNName like '%{0}%' OR ENName like '%{0}%' OR ShortName like '%{0}%')"
                    , this.tbClientName.Text.Replace("'", "''"));
            }
            strSql += " ORDER BY Code ASC";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region 公共属性
        private List<SelectedClientInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedClientInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region 工具栏控件事件
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
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
                if (drs.Length == 0)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectedClientInfo>();
                SelectedClientInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedClientInfo();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0)
                {
                    this.ShowMsg("请选中一行数据。");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedClientInfo info = new SelectedClientInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedClientInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedClientInfo
        {
            public SelectedClientInfo()
            {
            }
            public SelectedClientInfo(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strCode;
            /// <summary>
            ///
            /// </summary>
            public object Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }
            private object _strCNName;
            /// <summary>
            ///
            /// </summary>
            public object CNName
            {
                get { return this._strCNName; }
                set { this._strCNName = value; }
            }
            private object _strENName;
            /// <summary>
            ///
            /// </summary>
            public object ENName
            {
                get { return this._strENName; }
                set { this._strENName = value; }
            }
            private object _strShortName;
            /// <summary>
            ///
            /// </summary>
            public object ShortName
            {
                get { return this._strShortName; }
                set { this._strShortName = value; }
            }
            private object _strAddress;
            /// <summary>
            ///
            /// </summary>
            public object Address
            {
                get { return this._strAddress; }
                set { this._strAddress = value; }
            }
            private object _strTels;
            /// <summary>
            ///
            /// </summary>
            public object Tels
            {
                get { return this._strTels; }
                set { this._strTels = value; }
            }
            private object _strFaxs;
            /// <summary>
            ///
            /// </summary>
            public object Faxs
            {
                get { return this._strFaxs; }
                set { this._strFaxs = value; }
            }
            private object _strCreater;
            /// <summary>
            ///
            /// </summary>
            public object Creater
            {
                get { return this._strCreater; }
                set { this._strCreater = value; }
            }
            private object _strCreaterName;
            /// <summary>
            ///
            /// </summary>
            public object CreaterName
            {
                get { return this._strCreaterName; }
                set { this._strCreaterName = value; }
            }
            private object _detCreateDate;
            /// <summary>
            ///
            /// </summary>
            public object CreateDate
            {
                get { return this._detCreateDate; }
                set { this._detCreateDate = value; }
            }
            private object _strPostalcode;
            /// <summary>
            ///
            /// </summary>
            public object Postalcode
            {
                get { return this._strPostalcode; }
                set { this._strPostalcode = value; }
            }
            private object _strCountryCode;
            /// <summary>
            ///
            /// </summary>
            public object CountryCode
            {
                get { return this._strCountryCode; }
                set { this._strCountryCode = value; }
            }
            private object _strProvinceCode;
            /// <summary>
            ///
            /// </summary>
            public object ProvinceCode
            {
                get { return this._strProvinceCode; }
                set { this._strProvinceCode = value; }
            }
            private object _strPosalcode;
            /// <summary>
            ///
            /// </summary>
            public object Posalcode
            {
                get { return this._strPosalcode; }
                set { this._strPosalcode = value; }
            }
            private object _strRemark;
            /// <summary>
            ///
            /// </summary>
            public object Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
            }
            /// <summary>
            ///
            /// </summary>
            private object _strVirCode;
            /// <summary>
            ///
            /// </summary>
            public object VirCode
            {
                get { return this._strVirCode; }
                set { this._strVirCode = value; }
            }
            private object _strOpenBank;
            /// <summary>
            ///
            /// </summary>
            public object OpenBank
            {
                get { return this._strOpenBank; }
                set { this._strOpenBank = value; }
            }
            private object _strAccount;
            /// <summary>
            ///
            /// </summary>
            public object Account
            {
                get { return this._strAccount; }
                set { this._strAccount = value; }
            }
            private object _strSwiftCode;
            /// <summary>
            ///
            /// </summary>
            public object SwiftCode
            {
                get { return this._strSwiftCode; }
                set { this._strSwiftCode = value; }
            }
            private object _blIsSys;
            /// <summary>
            ///
            /// </summary>
            public object IsSys
            {
                get { return this._blIsSys; }
                set { this._blIsSys = value; }
            }
            private object _blTerminated;
            /// <summary>
            ///
            /// </summary>
            public object Terminated
            {
                get { return this._blTerminated; }
                set { this._blTerminated = value; }
            }
            private object _strDefaultName;
            /// <summary>
            ///
            /// </summary>
            public object DefaultName
            {
                get { return this._strDefaultName; }
                set { this._strDefaultName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.CNName = dr["CNName"];
                this.ENName = dr["ENName"];
                this.ShortName = dr["ShortName"];
                this.Address = dr["Address"];
                this.Tels = dr["Tels"];
                this.Faxs = dr["Faxs"];
                this.Creater = dr["Creater"];
                this.CreaterName = dr["CreaterName"];
                this.CreateDate = dr["CreateDate"];
                this.Postalcode = dr["Postalcode"];
                this.CountryCode = dr["CountryCode"];
                this.ProvinceCode = dr["ProvinceCode"];
                this.Posalcode = dr["Posalcode"];
                this.Remark = dr["Remark"];
                this.OpenBank = dr["OpenBank"];
                this.Account = dr["Account"];
                this.SwiftCode = dr["SwiftCode"];
                this.IsSys = dr["IsSys"];
                this.Terminated = dr["Terminated"];
                this.DefaultName = dr["DefaultName"];
                this.VirCode = dr["VirCode"];
            }

        }
        #endregion
        #region 列表框事件
        //行双击事件
        protected void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MultiSelected) return;//多选情况下不执行双击选中
            //this.dgvDetail.Rows[e.RowIndex].Selected = true;
            this.btTrue_Click(null, null);
        }
        #endregion
        #region 更多操作事件
        private void 列表显示设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataGridViewSetting(Common.MyEnums.Modules.None, this.dgvDetail);
        }
        #endregion

        private void tbClientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}