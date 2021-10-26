using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.BOM
{
    public partial class frmSelectBomVersion : Common.frmSelectBase
    {
        public frmSelectBomVersion()
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
            this.tbSpec.KeyDown += new KeyEventHandler(tbSearchValue_KeyDown);
            #region  绑定标题
            if (this._ClassCode != string.Empty)
            {
                DataTable dtClass;
                try
                {
                    dtClass = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ClassName FROM BOM_Sys_productClass WHERE Code='{0}'"
                        , this._ClassCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtClass.Rows.Count > 0)
                {
                    this.Text = string.Format("选择“{0}”的版本号", dtClass.Rows[0]["ClassName"]);
                }
            }
            #endregion
            return true;
        }
        private bool BindData()
        {
            //获取缆芯类别
            DataTable dt = null;
            string strSql = "SELECT * FROM BOM_Sys_Version WHERE 1=1";
            if (this._ClassCode != string.Empty)
                strSql += string.Format(" and SFGClass='{0}'", this._ClassCode);
            if (tbSpec.Text != string.Empty)
                strSql += string.Format(" AND (VersionSpec like '%{0}%' or VersionDesc like '%{0}%')", this.tbSpec.Text.Replace("'", "''"));
            string strSort = string.Empty;
            #region 获取排序方法
            if (this.dgvDetail.DataSource != null)
            {
                DataTable dtOrginal = this.dgvDetail.DataSource as DataTable;
                if (dtOrginal != null)
                    strSort = dtOrginal.DefaultView.Sort;
            }
            if (strSort == string.Empty)
                strSort = "VersionNo ASC,VersionSpec ASC";
            #endregion
            if (strSort.Length > 0)
                strSql += " ORDER BY " + strSort;
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
        private List<SelectedInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        public string _ClassCode = string.Empty;
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region 工具栏控件事件
        private void labExButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchLabelItem item = newItem.Tag as Common.MyEntity.SearchLabelItem;
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.None, this.dgvDetail);
            }
            else if (item.Value == 3)
            {
                if (!this.MultiSelected)
                {
                    this.ShowMsg("当前列表只能选择一条数据，该功能不能使用。");
                    return;
                }
                DataTable dt = this.dgvDetail.DataSource as DataTable;
                if (dt == null) return;
                foreach (DataRowView drv in dt.DefaultView)
                {
                    drv.Row[this.DataGridViewCheckColumnName] = drv.Row[this.DataGridViewCheckColumnName].Equals(DBNull.Value) ? true : !(bool)drv.Row[this.DataGridViewCheckColumnName];
                }
            }
        }
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
                this.SelectedData = new List<SelectedInfo>();
                SelectedInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedInfo();
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
                this.SelectedData = new List<SelectedInfo>();
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedInfo info = new SelectedInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedInfo
        {
            public SelectedInfo()
            {
            }
            public SelectedInfo(DataRow dr)
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
            private object _strSFGClass;
            /// <summary>
            ///
            /// </summary>
            public object SFGClass
            {
                get { return this._strSFGClass; }
                set { this._strSFGClass = value; }
            }
            private object _iVersionNo;
            /// <summary>
            ///
            /// </summary>
            public object VersionNo
            {
                get { return this._iVersionNo; }
                set { this._iVersionNo = value; }
            }
            private object _strVersionSpec;
            /// <summary>
            ///
            /// </summary>
            public object VersionSpec
            {
                get { return this._strVersionSpec; }
                set { this._strVersionSpec = value; }
            }
            private object _strVersionDesc;
            /// <summary>
            ///
            /// </summary>
            public object VersionDesc
            {
                get { return this._strVersionDesc; }
                set { this._strVersionDesc = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.ID = dr["ID"];
                this.SFGClass = dr["SFGClass"];
                this.VersionNo = dr["VersionNo"];
                this.VersionSpec = dr["VersionSpec"];
                this.VersionDesc = dr["VersionDesc"];
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

        private void tbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.BindData();
        }
    }
}