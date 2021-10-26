using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.Material
{
    public partial class frmSelectMClass : Common.frmSelectBase
    {
        public frmSelectMClass()
        {
            InitializeComponent();
        }
        #region 公共属性
        private List<SelectedClassInfo> _selectedData = null;
        /// <summary>
        /// 选中的数据
        /// </summary>
        public List<SelectedClassInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region 处理函数
        private bool BindData()
        {
            DataTable dtM;
            try
            {
                dtM = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM JC_MaterialClass");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            TreeNode tn;
            foreach (DataRow drM in dtM.Select("ISNULL(ParentCode,'')=''"))
            {
                tn = new TreeNode();
                tn.Tag = drM["code"].ToString();
                tn.Text = drM["className"].ToString();
                tn.Checked = IsExist(drM["code"].ToString());
                if (tn.Checked)
                    this._tncheck = tn;
                this.tvList.Nodes.Add(tn);
                BindChilds(drM["code"].ToString(), dtM, tn);
            }
            this.tvList.ExpandAll();
            return true;
        }
        private bool IsExist(string sCode)
        {
            if (this.SelectedData == null || this.SelectedData.Count == 0) return false;
            SelectedClassInfo cls = this.SelectedData.Find(delegate(SelectedClassInfo clstemp)
            {
                return string.Compare(sCode, clstemp.Code.ToString(), true) == 0;
            });
            return cls != null;
        }
        private void BindChilds(string sCode, DataTable dtM, TreeNode tn)
        {
            TreeNode tnNew;
            foreach (DataRow drM in dtM.Select("ISNULL(ParentCode,'')='" + sCode + "'"))
            {
                tnNew = new TreeNode();
                tnNew.Tag = drM["code"].ToString();
                tnNew.Text = drM["className"].ToString();
                tnNew.Checked = IsExist(drM["code"].ToString());
                if (tnNew.Checked)
                    this._tncheck = tnNew;
                tn.Nodes.Add(tnNew);
                BindChilds(drM["code"].ToString(), dtM, tnNew);
            }
        }
        #endregion
        private TreeNode _tncheck = null;
        private void tvList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.MultiSelected && e.Node.Checked)
            {
                if (_tncheck != null && _tncheck.Checked)
                    _tncheck.Checked = false;
                _tncheck = e.Node;
            }
        }
        private void frmSelectMClass_Load(object sender, EventArgs e)
        {
            BindData();
            if (!this.MultiSelected)
                this.tvList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterCheck);
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in this.tvList.Nodes)
                ClearChecked(tn);
        }
        private void ClearChecked(TreeNode tn)
        {
            if (tn.Checked)
                tn.Checked = false;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                if (tnChild.Checked)
                    tnChild.Checked = false;
                ClearChecked(tnChild);
            }
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            List<SelectedClassInfo> list = new List<SelectedClassInfo>();
            foreach (TreeNode tn in this.tvList.Nodes)
                GetChecked(tn, list);
            if (list.Count == 0)
            {
                if (!this.IsUserConfirm("您未选择一个人类，请确定吗？")) return;
            }
            this.SelectedData = list;
            this.DialogResult = DialogResult.OK;
        }
        private void GetChecked(TreeNode tn, List<SelectedClassInfo> list)
        {
            if (tn.Checked)
                list.Add(new SelectedClassInfo(tn.Tag.ToString(), tn.Text));
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (tnchild.Checked)
                    list.Add(new SelectedClassInfo(tnchild.Tag.ToString(), tnchild.Text));
                GetChecked(tnchild, list);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 返回数据实体类
        public class SelectedClassInfo
        {
            public SelectedClassInfo()
            {
            }
            public SelectedClassInfo(string sCode,string sName)
            {
                this._strCode = sCode;
                this._strClassName = sName;
            }
            public SelectedClassInfo(DataRow dr)
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
            private object _strParentCode;
            /// <summary>
            ///
            /// </summary>
            public object ParentCode
            {
                get { return this._strParentCode; }
                set { this._strParentCode = value; }
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
            private object _strClassName;
            /// <summary>
            ///
            /// </summary>
            public object ClassName
            {
                get { return this._strClassName; }
                set { this._strClassName = value; }
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
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.ParentCode = dr["ParentCode"];
                this.SortID = dr["SortID"];
                this.ClassName = dr["ClassName"];
                this.Remark = dr["Remark"];
            }
        }
        #endregion
    }
}