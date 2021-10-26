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

namespace BasicData.Company
{
    public partial class frmSelectCompany : Common.frmSelectBase
    {
        public frmSelectCompany()
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
                this.dgvDetail.CellDoubleClick += new DataGridViewCellEventHandler(dgvDetail_CellDoubleClick);
            }
            return true;
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM JC_Company WHERE 1=1";
            if (this.tbClientName.Text != string.Empty)
            {
                strSql += string.Format(" AND (CNName like '%{0}%' OR ENName like '%{0}%' OR ShortName like '%{0}%')");
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
        private List<SelectedCompanyInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedCompanyInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 返回数据实体类
        public class SelectedCompanyInfo
        {
            public SelectedCompanyInfo()
            {
            }
            public SelectedCompanyInfo(DataRow dr)
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
            private object _strAddress;
            /// <summary>
            ///
            /// </summary>
            public object Address
            {
                get { return this._strAddress; }
                set { this._strAddress = value; }
            }
            private object _strPostal;
            /// <summary>
            ///
            /// </summary>
            public object Postal
            {
                get { return this._strPostal; }
                set { this._strPostal = value; }
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
            private object _strVirCode;
            /// <summary>
            ///
            /// </summary>
            public object VirCode
            {
                get { return this._strVirCode; }
                set { this._strVirCode = value; }
            }
            private object _blIsDefault;
            /// <summary>
            ///
            /// </summary>
            public object IsDefault
            {
                get { return this._blIsDefault; }
                set { this._blIsDefault = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.CNName = dr["CNName"];
                this.ENName = dr["ENName"];
                this.ShortName = dr["ShortName"];
                this.VirCode = dr["VirCode"];
                this.Tels = dr["Tels"];
                this.Faxs = dr["Faxs"];
                this.Address = dr["Address"];
                this.Postal = dr["Postal"];
                this.Remark = dr["Remark"];
                this.IsDefault = dr["IsDefault"];
            }
        }
        #endregion
        #region 窗体工具
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MultiSelected) return;//多选情况下不执行双击选中
            //this.dgvDetail.Rows[e.RowIndex].Selected = true;
            this.btTrue_Click(null, null);
        }
        private void tbClientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.BindData();
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
                this.SelectedData = new List<SelectedCompanyInfo>();
                SelectedCompanyInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedCompanyInfo();
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
                SelectedCompanyInfo info = new SelectedCompanyInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedCompanyInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        #endregion

        private void frmSelectCompany_Load(object sender, EventArgs e)
        {
            this.Perinit();
            this.BindData();
        }
    }
}
