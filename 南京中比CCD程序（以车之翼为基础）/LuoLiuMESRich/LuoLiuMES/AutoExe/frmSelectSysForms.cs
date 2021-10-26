using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSelectSysForms : Common.frmSelectBase
    {
        public frmSelectSysForms()
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

        private bool BindGroup()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM AutoExe_Sys_Group"));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs = dt.Select("isnull(PCode,'')=''", "SortID ASC");
            this.tvGroup.Nodes.Clear();
            TreeNode tnRoot = new TreeNode();
            tnRoot.Tag = "";
            tnRoot.Text = "所有窗口组";
            this.tvGroup.Nodes.Add(tnRoot);
            TreeNode tn;
            foreach (DataRow dr in drs)
            {
                tn = new TreeNode();
                tn.Tag = dr["Code"].ToString();
                tn.Text = dr["GroupName"].ToString();
                tnRoot.Nodes.Add(tn);
                BindGroup(dt, tn);
            }
            if (this.tvGroup.SelectedNode == null)
                this.tvGroup.SelectedNode = tnRoot;
            this.tvGroup.ExpandAll();
            return true;
        }
        private void BindGroup(DataTable dt, TreeNode tn)
        {
            DataRow[] drs = dt.Select("isnull(PCode,'')='" + tn.Tag.ToString() + "'", "SortID ASC");
            TreeNode tnChild;
            foreach (DataRow dr in drs)
            {
                tnChild = new TreeNode();
                tnChild.Tag = dr["Code"].ToString();
                tnChild.Text = dr["GroupName"].ToString();
                tn.Nodes.Add(tnChild);
                BindGroup(dt, tnChild);
            }
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM [V_AutoExe_Sys_Forms] WHERE 1=1";
            string strGroup = string.Empty;
            if (this.tvGroup.SelectedNode != null && this.tvGroup.SelectedNode.Tag != null)
                strGroup = this.tvGroup.SelectedNode.Tag.ToString();
            if (strGroup != string.Empty)
                strSql += string.Format(" AND GroupCode='{0}'", strGroup.Replace("'", "''"));
            if (this._Codes.Length > 0)
            {
                this._Codes = "|" + this._Codes + "|";
                strSql += string.Format(" AND CHARINDEX('|'+Code+'|','{0}')=0", _Codes.Replace("'", "''"));
            }
            if(this.tsbSearchValue.Text!=string.Empty)
                strSql += string.Format(" AND FormName like '%{0}%'", tsbSearchValue.Text.Replace("'", "''"));
            strSql += " order by SortID ASC";
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
        private List<SelectedSysForms> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedSysForms> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        public string _Codes = string.Empty;
        #endregion
        #region 窗体OnLoad事件
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindGroup()) return;
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
                this.SelectedData = new List<SelectedSysForms>();
                SelectedSysForms info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedSysForms();
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
                SelectedSysForms info = new SelectedSysForms();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedSysForms>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region 返回数据实体类
        public class SelectedSysForms
        {
            public SelectedSysForms()
            {
            }
            public SelectedSysForms(DataRow dr)
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
            private object _strGroupCode;
            /// <summary>
            ///
            /// </summary>
            public object GroupCode
            {
                get { return this._strGroupCode; }
                set { this._strGroupCode = value; }
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
            private object _strFormName;
            /// <summary>
            ///
            /// </summary>
            public object FormName
            {
                get { return this._strFormName; }
                set { this._strFormName = value; }
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
            private object _strProjectName;
            /// <summary>
            ///
            /// </summary>
            public object ProjectName
            {
                get { return this._strProjectName; }
                set { this._strProjectName = value; }
            }
            private object _blCheckPower;
            /// <summary>
            ///
            /// </summary>
            public object CheckPower
            {
                get { return this._blCheckPower; }
                set { this._blCheckPower = value; }
            }
            private object _iUserLevel;
            /// <summary>
            ///
            /// </summary>
            public object UserLevel
            {
                get { return this._iUserLevel; }
                set { this._iUserLevel = value; }
            }
            private object _blIsMulti;
            /// <summary>
            ///
            /// </summary>
            public object IsMulti
            {
                get { return this._blIsMulti; }
                set { this._blIsMulti = value; }
            }
            private object _iDialogType;
            /// <summary>
            ///
            /// </summary>
            public object DialogType
            {
                get { return this._iDialogType; }
                set { this._iDialogType = value; }
            }
            private object _strOpenedName;
            /// <summary>
            ///
            /// </summary>
            public object OpenedName
            {
                get { return this._strOpenedName; }
                set { this._strOpenedName = value; }
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
            private object _strPowers;
            /// <summary>
            ///
            /// </summary>
            public object Powers
            {
                get { return this._strPowers; }
                set { this._strPowers = value; }
            }
            private object _strUserLevelView;
            /// <summary>
            ///
            /// </summary>
            public object UserLevelView
            {
                get { return this._strUserLevelView; }
                set { this._strUserLevelView = value; }
            }
            private object _strIsMultiView;
            /// <summary>
            ///
            /// </summary>
            public object IsMultiView
            {
                get { return this._strIsMultiView; }
                set { this._strIsMultiView = value; }
            }
            private object _strDialogTypeView;
            /// <summary>
            ///
            /// </summary>
            public object DialogTypeView
            {
                get { return this._strDialogTypeView; }
                set { this._strDialogTypeView = value; }
            }
            private object _strParameters;
            /// <summary>
            ///
            /// </summary>
            public object Parameters
            {
                get { return this._strParameters; }
                set { this._strParameters = value; }
            }
            private object _strGroupName;
            /// <summary>
            ///
            /// </summary>
            public object GroupName
            {
                get { return this._strGroupName; }
                set { this._strGroupName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.GroupCode = dr["GroupCode"];
                this.SortID = dr["SortID"];
                this.FormName = dr["FormName"];
                this.ClassName = dr["ClassName"];
                this.ProjectName = dr["ProjectName"];
                this.CheckPower = dr["CheckPower"];
                this.UserLevel = dr["UserLevel"];
                this.IsMulti = dr["IsMulti"];
                this.DialogType = dr["DialogType"];
                this.OpenedName = dr["OpenedName"];
                this.Remark = dr["Remark"];
                this.Powers = dr["Powers"];
                this.UserLevelView = dr["UserLevelView"];
                this.IsMultiView = dr["IsMultiView"];
                this.DialogTypeView = dr["DialogTypeView"];
                this.Parameters = dr["Parameters"];
                this.GroupName = dr["GroupName"];
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

        private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindData();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tsbSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
                return;
            tsbSearch_Click(null, null);
        }
    }
}