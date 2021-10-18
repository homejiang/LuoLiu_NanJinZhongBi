using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.BasicData
{
    public partial class frmSelectUser : Common.frmSelectBase
    {
        public frmSelectUser()
        {
            InitializeComponent();
        }
        #region 窗体事件
        private void frmSelectMaterial_Load(object sender, EventArgs e)
        {
            this.dgvUser.AutoGenerateColumns = false;
            this.BindDept();
            this.PerInit();
            //this.BindData();
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            this.dgvUser.AutoGenerateColumns = false;
            //设置搜索条件
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "用户姓名";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "UserName LIKE '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "用户编码";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "UserCode LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "用户英文名";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.StringFormat = "UserENName like '%{0}%'";
            item.Value = 3;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tsDropTitle, listSearchItem);
            #endregion
            #region 设置combox回车事件
            this.SetBarSearchEnterKey(this.tsCombox);
            #endregion
            if (!this.MultiSelected)
            {
                //此时不为多选
                dgvSelected.Visible = false;
                this.dgvUser.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
                dgvSelected.DataPropertyName = "IsSelected";
            return true;
        }
        private bool BindDept()
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable("SELECT * FROM Sys_Department ORDER BY DeptName");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            TreeNode tnParent = new TreeNode();
            tnParent.Text = "所有部门";
            tnParent.Tag = "";
            this.tvDept.Nodes.Add(tnParent);
           
            DataRow[] drs = dt.Select("ISNULL(ParentDetpCode,'')=''", "DeptName asc");
            foreach (DataRow dr in drs)
            {
                TreeNode tnRoot = new TreeNode();
                tnRoot.Text = dr["DeptName"].ToString();
                tnRoot.Tag = dr["DeptCode"].ToString();
                tnParent.Nodes.Add(tnRoot);
                //绑定子节点
                this.BindDept(tnRoot, dt);
            }
            //设置初始化展开，只需将根节点展开即可，其他都收拢，否则会因为部门太多拉得太长
            this.tvDept.CollapseAll();
            tnParent.Expand();
            this.tvDept.SelectedNode = tnParent;
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
                if (dr["Description"].ToString().Length > 0)
                    tnchild.ToolTipText = dr["Description"].ToString();
                tn.Nodes.Add(tnchild);
                this.BindDept(tnchild, dtDetp);
            }
        }
        private bool BindData()
        {
            string strSql = "SELECT CAST(0 AS BIT) AS IsSelected,* FROM V_Sys_Users WHERE ISNULL(Terminated,0)=0";
            //获取选中类别
            TreeNode tn = this.tvDept.SelectedNode;
            if (tn != null && tn.Tag != null && tn.Tag.ToString() != string.Empty)
            {
                string strDepts = string.Empty;
                GetSelDept(ref strDepts, tn);
                if (strDepts.Length > 0)
                {
                    strSql += string.Format(" AND CHARINDEX('|'+DeptCode+'|','{0}')>0"
                        , "|" + strDepts.Replace("'", "''") + "|");
                }
            }
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsDropTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY UserName";
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.listContains!=null && this.listContains.Count > 0)
            {
                DataRow[] drs;
                foreach (object obj in listContains)
                {
                    drs = dt.Select("UserCode='" + obj.ToString() + "'");
                    foreach (DataRow dr in drs)
                        dr["IsSelected"] = true;
                }
            }
            this.dgvUser.DataSource = dt;
            return true;
        }
        private void GetSelDept(ref string sDeptCode, TreeNode tn)
        {
            if (tn == null || tn.Tag == null || tn.Tag.ToString() == string.Empty) return;
            sDeptCode += tn.Tag.ToString() + "|";
            foreach (TreeNode tnchild in tn.Nodes)
                this.GetSelDept(ref sDeptCode, tnchild);
        }
        #endregion
        #region  重写父类函数
        //重写搜索时间
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        #endregion
        #region 按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvUser.DataSource as DataTable;
            if (this.MultiSelected)
            {
                foreach (DataRowView drv in dt.DefaultView)
                {
                    if (!drv.Row["IsSelected"].Equals(DBNull.Value) && (bool)drv.Row["IsSelected"])
                    {
                        this.SelectedRows.Add(drv.Row);
                        if (!this.MultiSelected) break;
                    }
                }
            }
            else
            {
                if (this.dgvUser.SelectedRows.Count == 0)
                {
                    this.ShowMsg("请至少选中一行。");
                    return;
                }
                this.SelectedRows.Add(dt.DefaultView[this.dgvUser.SelectedRows[0].Index].Row);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void tvClass_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.BindData();
        }
        #endregion
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.MultiSelected)
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0)
                {
                    //此时用户点击的为选择行
                    if (this.dgvSelected.HeaderText == "选择")
                        this.dgvSelected.HeaderText = "选择√";
                    else
                        this.dgvSelected.HeaderText = "选择";
                    DataGridViewCheckBoxCell chkCell;
                    for (int i = 0; i < this.dgvUser.Rows.Count; i++)
                    {
                        chkCell = this.dgvUser.Rows[i].Cells[0] as DataGridViewCheckBoxCell;
                        chkCell.Value = this.dgvSelected.HeaderText == "选择√";
                    }
                    this.dgvUser.Update();
                }
            }
            
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelected)
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex < 0) return;
                btTrue_Click(null, null);
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
    }
}