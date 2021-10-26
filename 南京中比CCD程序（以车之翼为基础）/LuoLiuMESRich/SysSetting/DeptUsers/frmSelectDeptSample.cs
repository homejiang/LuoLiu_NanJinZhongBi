using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace SysSetting.DeptUsers
{
    public partial class frmSelectDeptSample : Common.frmSelectBase
    {
        public frmSelectDeptSample()
        {
            InitializeComponent();
        }
        #region 公共属性
        private string _strSelectedDept = string.Empty;
        /// <summary>
        /// 设置获取已选中的部门
        /// </summary>
        public string SelectedDept
        {
            get 
            {
                string strDept = string.Empty;
                foreach (TreeNode tnRoot in this.tvDept.Nodes)
                {
                    if (tnRoot.Checked)
                        return tnRoot.Tag.ToString();
                    strDept= GetCheckedDeptCode(tnRoot);
                    if (strDept != string.Empty) break;
                }
                return strDept;
            }
            set { this._strSelectedDept = value; }
        }
        /// <summary>
        /// 获取部门名称
        /// </summary>
        public string SelectedDeptName
        {
            get
            {
                string strDept = string.Empty;
                foreach (TreeNode tnRoot in this.tvDept.Nodes)
                {
                    if (tnRoot.Checked)
                        return tnRoot.Text.ToString();
                    strDept= GetCheckedDeptName(tnRoot);
                    if (strDept != string.Empty) break;
                }
                return strDept;
            }
        }
        #endregion
        #region 处理函数
        private bool BindDept()
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("SELECT * FROM Sys_Department ORDER BY DeptName");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //加载根节点
            if (this.tvDept.Nodes.Count > 0) this.tvDept.Nodes.Clear();
            DataRow[] drs = dt.Select("ISNULL(ParentDetpCode,'')=''", "DeptName asc");
            foreach (DataRow dr in drs)
            {
                TreeNode tnRoot = new TreeNode();
                tnRoot.Text = dr["DeptName"].ToString();
                tnRoot.Tag = dr["DeptCode"].ToString();
                if (dr["DeptCode"].Equals(this._strSelectedDept))
                    tnRoot.Checked = true;
                this.tvDept.Nodes.Add(tnRoot);
                //绑定子节点
                this.BindDept(tnRoot, dt);
            }
            this.tvDept.ExpandAll();
            return true;
        }
        private void BindDept(TreeNode tn, DataTable dtDetp)
        {
            //绑定子节点
            if (tn.Tag == null) return;
            DataRow[] drs = dtDetp.Select(string.Format("ParentDetpCode='{0}'", tn.Tag.ToString()), "DeptName asc");
            foreach (DataRow dr in drs)
            {
                TreeNode tnchild = new TreeNode();
                tnchild.Text = dr["DeptName"].ToString();
                tnchild.Tag = dr["DeptCode"].ToString();
                if (dr["DeptCode"].Equals(this._strSelectedDept))
                    tnchild.Checked = true;
                if (dr["Description"].ToString().Length > 0)
                    tnchild.ToolTipText = dr["Description"].ToString();
                tn.Nodes.Add(tnchild);
                this.BindDept(tnchild, dtDetp);
            }
        }
        /// <summary>
        /// 递归获取选中部门
        /// </summary>
        /// <param name="tn"></param>
        /// <returns></returns>
        private string GetCheckedDeptCode(TreeNode tn)
        {
            string strDept = string.Empty;
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (tnchild.Checked)
                    return tnchild.Tag.ToString();
                strDept= this.GetCheckedDeptCode(tnchild);
                if (strDept != string.Empty) break;
            }
            return strDept;
        }
        private string GetCheckedDeptName(TreeNode tn)
        {
            string strDept = string.Empty;
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (tnchild.Checked)
                    return tnchild.Text.ToString();
                strDept= this.GetCheckedDeptCode(tnchild);
                if (strDept != string.Empty) break;
            }
            return strDept;
        }
        private void SetNodesUnChecked(TreeNode tn,TreeNode tnChecked)
        {
            if (!tn.Equals(tnChecked))
                tn.Checked = false;
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (!tnchild.Equals(tnChecked))
                {
                    tnchild.Checked = false;
                }
                this.SetNodesUnChecked(tnchild, tnChecked);
            }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmSelectDeptSample_Load(object sender, EventArgs e)
        {
            if (!this.BindDept()) return;
        }
        #endregion
        #region 窗体控件事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvDept_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                //当节点状态为选中时要将其他所有节点设置为未选中状态
                foreach (TreeNode tnRoot in this.tvDept.Nodes)
                {
                    if (!tnRoot.Equals(e.Node))
                        tnRoot.Checked = false;
                    this.SetNodesUnChecked(tnRoot, e.Node);
                }
            }
        }
        #endregion
    }
}