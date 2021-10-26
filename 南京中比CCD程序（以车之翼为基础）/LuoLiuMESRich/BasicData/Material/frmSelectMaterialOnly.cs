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
    public partial class frmSelectMaterialOnly : Common.frmSelectBase
    {
        public frmSelectMaterialOnly()
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
            tnParent.Tag = -1;
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
            string strSql = "SELECT * FROM [V_JC_Material_forSelectMaterialOnly]" + this.GetSqlWhere();
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
        /// <summary>
        /// 获取搜索条件
        /// </summary>
        /// <returns></returns>
        private string GetSqlWhere()
        {
            string strWhere = " WHERE ISNULL(Terminated,0)=0";//不显示已经停用的
            //获取选中类别
            TreeNode tn = this.tvClass.SelectedNode;
            if (tn != null && tn.Tag != null && tn.Text != "所有原材料")//&& int.TryParse(tn.Tag.ToString(), out iID) > -1)
                strWhere += " AND ClassCode='" + tn.Tag.ToString() + "'";
            if (this.tbSearchValue.Text.Length == 0) return strWhere;
            return strWhere + " AND DefaultName LIKE '%" + this.tbSearchValue.Text.Replace("'", "''") + "%'";
        }
        #endregion
        #region 公共属性
        private List<SelectedMaterialOnlyInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedMaterialOnlyInfo> SelectedData
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
                this.SelectedData = new List<SelectedMaterialOnlyInfo>();
                SelectedMaterialOnlyInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedMaterialOnlyInfo();
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
                SelectedMaterialOnlyInfo info = new SelectedMaterialOnlyInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedMaterialOnlyInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedMaterialOnlyInfo
        {
            public SelectedMaterialOnlyInfo()
            {
            }
            public SelectedMaterialOnlyInfo(DataRow dr)
            {
                this.ReadFromDataRow(dr);
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
            private object _strClassCode;
            /// <summary>
            ///
            /// </summary>
            public object ClassCode
            {
                get { return this._strClassCode; }
                set { this._strClassCode = value; }
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
            private object _strUnitCode;
            /// <summary>
            ///
            /// </summary>
            public object UnitCode
            {
                get { return this._strUnitCode; }
                set { this._strUnitCode = value; }
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
            private object _strRemark;
            /// <summary>
            ///
            /// </summary>
            public object Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
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
            private object _detCreateTime;
            /// <summary>
            ///
            /// </summary>
            public object CreateTime
            {
                get { return this._detCreateTime; }
                set { this._detCreateTime = value; }
            }
            private object _strModifier;
            /// <summary>
            ///
            /// </summary>
            public object Modifier
            {
                get { return this._strModifier; }
                set { this._strModifier = value; }
            }
            private object _detModifyTime;
            /// <summary>
            ///
            /// </summary>
            public object ModifyTime
            {
                get { return this._detModifyTime; }
                set { this._detModifyTime = value; }
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
            private object _blIsNeedDiameter;
            /// <summary>
            ///
            /// </summary>
            public object IsNeedDiameter
            {
                get { return this._blIsNeedDiameter; }
                set { this._blIsNeedDiameter = value; }
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
            private object _strClassName;
            /// <summary>
            ///
            /// </summary>
            public object ClassName
            {
                get { return this._strClassName; }
                set { this._strClassName = value; }
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
            public void ReadFromDataRow(DataRow dr)
            {
                this.MaterialCode = dr["MaterialCode"];
                this.ClassCode = dr["ClassCode"];
                this.CNName = dr["CNName"];
                this.ENName = dr["ENName"];
                this.UnitCode = dr["UnitCode"];
                this.MaxStorage = dr["MaxStorage"];
                this.MinStorage = dr["MinStorage"];
                this.Density = dr["Density"];
                this.LossRate = dr["LossRate"];
                this.Remark = dr["Remark"];
                this.Creater = dr["Creater"];
                this.CreaterName = dr["CreaterName"];
                this.CreateTime = dr["CreateTime"];
                this.Modifier = dr["Modifier"];
                this.ModifyTime = dr["ModifyTime"];
                this.Terminated = dr["Terminated"];
                this.DefaultName = dr["DefaultName"];
                this.IsNeedDiameter = dr["IsNeedDiameter"];
                this.IsSys = dr["IsSys"];
                this.ClassName = dr["ClassName"];
                this.UnitName = dr["UnitName"];
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
    }
}