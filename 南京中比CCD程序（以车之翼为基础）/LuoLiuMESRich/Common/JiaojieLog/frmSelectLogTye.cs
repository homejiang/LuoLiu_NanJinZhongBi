using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.JiaojieLog
{
    public partial class frmSelectLogTye : Common.frmSelectBase
    {
        public frmSelectLogTye()
        {
            InitializeComponent();
        }
        #region 公共属性
        public string _LogType = string.Empty;
        #endregion
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
            string strSql = string.Format("SELECT * FROM ERPGenius_Sys_JJieLogTypeDetail WHERE PCode='{0}'"
                , this._LogType.Replace("'", "''"));
            if (this.tbSearch.Text != string.Empty)
                strSql += string.Format(" AND ItemName like '{0}'", this.tbSearch.Text.Replace("'", "''"));
            if (this.SelectedData != null && this.SelectedData.Count > 0)
            {
                string strItemNames = string.Empty;
                foreach (SelectedSysJJieLogItems cls in this.SelectedData)
                {
                    if (cls.ItemName.ToString() != string.Empty)
                        strItemNames += cls.ItemName.ToString() + "|";
                }
                if (strItemNames != string.Empty)
                {
                    strItemNames = "|" + strItemNames;
                }
                if (strItemNames != string.Empty)
                {
                    strSql += string.Format(" AND CHARINDEX('|'+ItemName+'|','{0}')=0"
                        , strItemNames.Replace("'", "''"));
                }
            }
            strSql += " order by SortID";
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
        private List<SelectedSysJJieLogItems> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedSysJJieLogItems> SelectedData
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
                this.SelectedData = new List<SelectedSysJJieLogItems>();
                SelectedSysJJieLogItems info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedSysJJieLogItems();
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
                SelectedSysJJieLogItems info = new SelectedSysJJieLogItems();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedSysJJieLogItems>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedSysJJieLogItems
        {
            public SelectedSysJJieLogItems()
            {
            }
            public SelectedSysJJieLogItems(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _iID;
            /// <summary>
            ///
            /// </summary>
            public object ID
            {
                get { return this._iID; }
                set { this._iID = value; }
            }
            private object _strPCode;
            /// <summary>
            ///
            /// </summary>
            public object PCode
            {
                get { return this._strPCode; }
                set { this._strPCode = value; }
            }
            private object _iSortID;
            /// <summary>
            ///
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strItemName;
            /// <summary>
            ///
            /// </summary>
            public object ItemName
            {
                get { return this._strItemName; }
                set { this._strItemName = value; }
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
            private object _blTerminated;
            /// <summary>
            ///
            /// </summary>
            public object Terminated
            {
                get { return this._blTerminated; }
                set { this._blTerminated = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.ID = dr["ID"];
                this.PCode = dr["PCode"];
                this.SortID = dr["SortID"];
                this.ItemName = dr["ItemName"];
                this.IsDefault = dr["IsDefault"];
                this.Terminated = dr["Terminated"];
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

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.btSearch_Click(null, null);
        }
    }
}