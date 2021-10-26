using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.Material
{
    public partial class frmSelectMaterial : Common.frmSelectBase
    {
        public frmSelectMaterial()
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
        private bool BindMaterialClass()
        {
            string strSql = "SELECT * FROM JC_MaterialClass ORDER BY SortID";
            DataTable dt = null;
            try
            {
                dt = CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.tvClass.Nodes.Clear();
            TreeNode tnParent = new TreeNode();
            tnParent.Text = "所有原材料";
            tnParent.Tag = "";
            this.tvClass.Nodes.Add(tnParent);
            DataRow[] drs = dt.Select("ISNULL(ParentCode,'')=''");
            foreach (DataRow dr in drs)
            {
                TreeNode tn = new TreeNode();
                tn.Text = dr["ClassName"].ToString();
                tn.Tag = dr["Code"].ToString();
                if (dr["Remark"].ToString().Length > 0)
                    tn.ToolTipText = dr["Remark"].ToString();
                tnParent.Nodes.Add(tn);
                BindMaterialClass(tn, dr["Code"].ToString(), dt);
            }
            tnParent.ExpandAll();
            return true;
        }
        private void BindMaterialClass(TreeNode tn, string sCode, DataTable dtClass)
        {
            DataRow[] drs = dtClass.Select("ParentCode='" + sCode + "'");
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Tag = dr["Code"].ToString();
                tnNew.Text = dr["ClassName"].ToString();
                if (dr["Remark"].ToString().Length > 0)
                    tnNew.ToolTipText = dr["Remark"].ToString();
                tn.Nodes.Add(tnNew);
                this.BindMaterialClass(tnNew, dr["Code"].ToString(), dtClass);
            }
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM V_JC_MaterialSpecs_ForSelectForm WHERE ISNULL(Terminated,0)=0 AND ISNULL(MaterialTerminated,0)=0";
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn != null && tn.Tag != null && tn.Tag != string.Empty)
            {
                string strClass = GetChildClass(tn);
                if (strClass != string.Empty)
                    strSql += string.Format(" AND CHARINDEX('|'+ClassCode+'|','|{0}|')>0", strClass.Replace("'", "''"));
            }
            if (this.tbSearchValue.Text != string.Empty)
                strSql += string.Format(" AND (MaterialName LIKE '%{0}%' OR Spec LIKE '%{0}%')", this.tbSearchValue.Text.Replace("'", "''"));
            strSql += " ORDER BY MaterialName ASC,Spec ASC";
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
        private string GetChildClass(TreeNode tn)
        {
            string strClass = string.Empty;
            if (tn.Tag != null && tn.Tag.ToString() != string.Empty)
                strClass += tn.Tag.ToString() + "|";
            string strTmp;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                strTmp = GetChildClass(tnChild);
                if (strTmp != string.Empty)
                    strClass += strTmp + "|";
            }
            return strClass;
        }
        #endregion
        #region 公共属性
        private List<SelectMaterialWithSpecInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectMaterialWithSpecInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!BindMaterialClass()) return;
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
                if (drs.Length == 0)
                {
                    this.ShowMsg("请至少选中一行数据。");
                    return;
                }
                this.SelectedData = new List<SelectMaterialWithSpecInfo>();
                SelectMaterialWithSpecInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectMaterialWithSpecInfo();
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
                SelectMaterialWithSpecInfo info = new SelectMaterialWithSpecInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectMaterialWithSpecInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectMaterialWithSpecInfo
        {
            public SelectMaterialWithSpecInfo()
            {
            }
            public SelectMaterialWithSpecInfo(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strGuid;
            /// <summary>
            ///
            /// </summary>
            public object Guid
            {
                get { return this._strGuid; }
                set { this._strGuid = value; }
            }
            private object _strSpec;
            /// <summary>
            ///
            /// </summary>
            public object Spec
            {
                get { return this._strSpec; }
                set { this._strSpec = value; }
            }
            private object _strMaterialCode;
            /// <summary>
            ///
            /// </summary>
            public object MaterialCode
            {
                get { return this._strMaterialCode; }
                set { this._strMaterialCode = value; }
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
            private object _decDensity;
            /// <summary>
            ///
            /// </summary>
            public object Density
            {
                get { return this._decDensity; }
                set { this._decDensity = value; }
            }
            private object _decLossRate;
            /// <summary>
            ///
            /// </summary>
            public object LossRate
            {
                get { return this._decLossRate; }
                set { this._decLossRate = value; }
            }
            private object _decDiameter;
            /// <summary>
            ///
            /// </summary>
            public object Diameter
            {
                get { return this._decDiameter; }
                set { this._decDiameter = value; }
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
            private object _iTerminated;
            /// <summary>
            ///
            /// </summary>
            public object Terminated
            {
                get { return this._iTerminated; }
                set { this._iTerminated = value; }
            }
            private object _decMaxStorage;
            /// <summary>
            ///
            /// </summary>
            public object MaxStorage
            {
                get { return this._decMaxStorage; }
                set { this._decMaxStorage = value; }
            }
            private object _decMinStorage;
            /// <summary>
            ///
            /// </summary>
            public object MinStorage
            {
                get { return this._decMinStorage; }
                set { this._decMinStorage = value; }
            }
            private object _strMaterialName;
            /// <summary>
            ///
            /// </summary>
            public object MaterialName
            {
                get { return this._strMaterialName; }
                set { this._strMaterialName = value; }
            }
            private object _strUnitCode;
            /// <summary>
            ///
            /// </summary>
            public object UnitCode
            {
                get { return this._strUnitCode; }
                set { this._strUnitCode = value; }
            }
            private object _strUnitName;
            /// <summary>
            ///
            /// </summary>
            public object UnitName
            {
                get { return this._strUnitName; }
                set { this._strUnitName = value; }
            }
            private object _strClassCode;
            /// <summary>
            ///
            /// </summary>
            public object ClassCode
            {
                get { return this._strClassCode; }
                set { this._strClassCode = value; }
            }
            private object _strClassName;
            /// <summary>
            ///
            /// </summary>
            public object ClassName
            {
                get { return this._strClassName; }
                set { this._strClassName = value; }
            }
            private object _blMaterialTerminated;
            /// <summary>
            ///
            /// </summary>
            public object MaterialTerminated
            {
                get { return this._blMaterialTerminated; }
                set { this._blMaterialTerminated = value; }
            }
            private object _decTax;
            /// <summary>
            ///
            /// </summary>
            public object Tax
            {
                get { return this._decTax; }
                set { this._decTax = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Guid = dr["Guid"];
                this.Spec = dr["Spec"];
                this.MaterialCode = dr["MaterialCode"];
                this.SortID = dr["SortID"];
                this.Density = dr["Density"];
                this.LossRate = dr["LossRate"];
                this.Diameter = dr["Diameter"];
                this.Remark = dr["Remark"];
                this.Terminated = dr["Terminated"];
                this.MaxStorage = dr["MaxStorage"];
                this.MinStorage = dr["MinStorage"];
                this.MaterialName = dr["MaterialName"];
                this.UnitCode = dr["UnitCode"];
                this.UnitName = dr["UnitName"];
                this.ClassCode = dr["ClassCode"];
                this.ClassName = dr["ClassName"];
                this.MaterialTerminated = dr["MaterialTerminated"];
                this.Tax = dr["Tax"];
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

        private void tvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindData();
        }

        private void tbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.BindData();
        }

        private void frmSelectMaterial_Load(object sender, EventArgs e)
        {

        }

        private void btSel_Click(object sender, EventArgs e)
        {
            if (!this.MultiSelected) return;
            if (this.dgvDetail.Rows.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            //因checkbox列已经禁止排序，所以可以直接设置其选中值
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            DataRow dr;
            for (int i = 0; i < this.dgvDetail.SelectedRows.Count; i++)
            {
                dr = dt.DefaultView[this.dgvDetail.SelectedRows[i].Index].Row;
                if (dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) || !(bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = true;
            }
        }

        private void btUnSel_Click(object sender, EventArgs e)
        {
            if (!this.MultiSelected) return;
            if (this.dgvDetail.Rows.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            //因checkbox列已经禁止排序，所以可以直接设置其选中值
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            DataRow dr;
            for (int i = 0; i < this.dgvDetail.SelectedRows.Count; i++)
            {
                dr = dt.DefaultView[this.dgvDetail.SelectedRows[i].Index].Row;
                if (!dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) && (bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = false;
            }
        }
    }
}