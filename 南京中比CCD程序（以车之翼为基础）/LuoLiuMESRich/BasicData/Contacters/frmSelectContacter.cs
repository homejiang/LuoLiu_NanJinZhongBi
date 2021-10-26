using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.Contacters
{
    public partial class frmSelectContacter : Common.frmSelectBase
    {
        public frmSelectContacter()
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
            string strSql = "SELECT * FROM JC_Contacters WHERE 1=1";
            if (this.tbClientName.Text != string.Empty)
            {
                strSql += string.Format(" AND (CNName like '%{0}%' OR ENName like '%{0}%')");
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
        private List<SelectedContacterInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedContacterInfo> SelectedData
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
                this.SelectedData = new List<SelectedContacterInfo>();
                SelectedContacterInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedContacterInfo();
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
                SelectedContacterInfo info = new SelectedContacterInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedContacterInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedContacterInfo
        {
            public SelectedContacterInfo()
            {
            }
            public SelectedContacterInfo(DataRow dr)
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
            private object _strPostion;
            /// <summary>
            ///
            /// </summary>
            public object Postion
            {
                get { return this._strPostion; }
                set { this._strPostion = value; }
            }
            private object _iSex;
            /// <summary>
            ///
            /// </summary>
            public object Sex
            {
                get { return this._iSex; }
                set { this._iSex = value; }
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
            private object _strMobileTels;
            /// <summary>
            ///
            /// </summary>
            public object MobileTels
            {
                get { return this._strMobileTels; }
                set { this._strMobileTels = value; }
            }
            private object _strEmails;
            /// <summary>
            ///
            /// </summary>
            public object Emails
            {
                get { return this._strEmails; }
                set { this._strEmails = value; }
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
            private object _strSexView;
            /// <summary>
            ///
            /// </summary>
            public object SexView
            {
                get { return this._strSexView; }
                set { this._strSexView = value; }
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
                this.Postion = dr["Postion"];
                this.Sex = dr["Sex"];
                this.Tels = dr["Tels"];
                this.MobileTels = dr["MobileTels"];
                this.Emails = dr["Emails"];
                this.Faxs = dr["Faxs"];
                this.SexView = dr["SexView"];
                this.Remark = dr["Remark"];
                this.DefaultName = dr["DefaultName"];
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
        
        private void tbClientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.BindData();
        }
    }
}