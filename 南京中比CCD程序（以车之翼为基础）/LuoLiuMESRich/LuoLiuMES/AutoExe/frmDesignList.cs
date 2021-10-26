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
    public partial class frmDesignList : Common.frmBaseList
    {
        public frmDesignList()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            #region 设置工具栏combox搜索标题
            //加载搜索项
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "用户名称";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "UserName LIKE '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "方案名称";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "DesignName LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            #region 只有管理员才有权编辑数据
            bool blIsAdmin = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            this.tsbAdd.Enabled = blIsAdmin;
            this.toolStripButton1.Enabled = blIsAdmin;
            //this.tsbEdit.Enabled = blIsAdmin;
            this.tsbRemove.Enabled = blIsAdmin;
            this.tsbDefault.Enabled = blIsAdmin;
            this.tsbEdit.Text = blIsAdmin ? "编辑" : "查看";
            #endregion
            return true;
        }
        private bool BindDeptAndUser()
        {
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT DeptCode,ParentDetpCode,DeptName FROM Sys_Department", "Sys_Department"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT Usercode,userName,DeptCode FROM Sys_Users", "Sys_Users"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dtDept = ds.Tables["Sys_Department"];
            DataTable dtUser = ds.Tables["Sys_Users"];
            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "所有部门";
            this.treeView1.Nodes.Add(tnRoot);
            DataRow[] drs = dtDept.Select("ISNULL(ParentDetpCode,'')=''", "DeptName ASC");
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Tag = "DEPT&" + dr["DeptCode"].ToString();
                tnNew.Text = dr["DeptName"].ToString();
                tnRoot.Nodes.Add(tnNew);
                BindUser(tnNew, dr["DeptCode"].ToString(), dtUser);
                BindDept(tnNew, dr["DeptCode"].ToString(), dtDept, dtUser);
            }
            tnRoot.Expand();
            return true;
        }
        private void BindDept(TreeNode tn,string sDeptCode,DataTable dtDept,DataTable dtUser)
        {
            DataRow[] drs = dtDept.Select("ParentDetpCode='" + sDeptCode + "'", "DeptName ASC");
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Tag = "DEPT&" + dr["DeptCode"].ToString();
                tnNew.Text = dr["DeptName"].ToString();
                tn.Nodes.Add(tnNew);
                BindUser(tnNew, dr["DeptCode"].ToString(), dtUser);
                BindDept(tnNew, dr["DeptCode"].ToString(), dtDept, dtUser);
            }
        }
        private void BindUser(TreeNode tnDept,string sDeptCode,DataTable dt)
        {
            DataRow[] drs = dt.Select("DeptCode='" + sDeptCode + "'", "UserName ASC");
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Tag ="USER&"+dr["UserCode"].ToString();
                tnNew.Text = dr["UserName"].ToString();
                tnDept.Nodes.Add(tnNew);
            }
        }
        private bool BindData()
        {
            DataTable dt;
            string strSql="SELECT * FROM V_AutoExe_User_Designs_List WHERE ISNULL(UserCode,'')<>''";
            TreeNode tn = this.treeView1.SelectedNode;
            string strTag = string.Empty;
            if (tn != null && tn.Tag != null)
                strTag = tn.Tag.ToString();
            if (strTag != string.Empty)
            {
                if (strTag.IndexOf("USER&") == 0)
                {
                    #region 此时选中了用户
                    strSql += " AND UserCode='" + strTag.Substring(5).Replace("'", "''") + "'";
                    #endregion
                }
                else if (strTag.IndexOf("DEPT&") == 0)
                {
                    #region 此时用户选中了部门
                    //需要遍历改部门下所有子部门
                    string strDeptCodes = "|" + strTag.Substring(5) + "|";
                    GetChildDeptCode(tn, ref strDeptCodes);
                    strSql += string.Format(" AND CHARINDEX('|'+DeptCode+'|','{0}')>0", strDeptCodes.Replace("'", "''"));
                    #endregion
                }
            }
            if (this.tstSearchValue.Text!=string.Empty)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tslTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tstSearchValue.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY UserName ASC,DesignName ASC";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private void GetChildDeptCode(TreeNode tn,ref string sDeptCodes)
        {
            foreach (TreeNode tnChild in tn.Nodes)
            {
                if (tnChild.Tag != null && tnChild.Tag.ToString().IndexOf("DEPT&") == 0)
                {
                    sDeptCodes += tnChild.Tag.ToString().Substring(5) + "|";
                    GetChildDeptCode(tnChild, ref sDeptCodes);
                }
            }
        }
        #endregion
        #region 窗体OnLoad事件
        private void frmDesignList_Load(object sender, EventArgs e)
        {
            Perinit();
            this.BindDeptAndUser();
            BindData();
        }
        #endregion

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BindData();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tstSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            tsbSearch_Click(null, null);
        }
        #region 工具条按钮事件
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            string strUserCode = string.Empty;
            TreeNode tn = this.treeView1.SelectedNode;
            if (tn != null && tn.Tag != null)
                strUserCode = tn.Tag.ToString();
            if (strUserCode.IndexOf("USER&") != 0)
            {
                this.ShowMsg("请在左边窗体中选择1个用户。");
                return;
            }
            else strUserCode = strUserCode.Substring(5);
            AutoExe.frmUserForms frm = new frmUserForms();
            frm._UserCode = strUserCode;
            frm.ShowDialog(this);
            this.BindData();
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string strUserCode = string.Empty;
            TreeNode tn = this.treeView1.SelectedNode;
            if (tn != null && tn.Tag != null)
                strUserCode = tn.Tag.ToString();
            if (strUserCode.IndexOf("USER&") != 0)
            {
                this.ShowMsg("请在左边窗体中选择1个用户。");
                return;
            }
            else strUserCode = strUserCode.Substring(5);
            AutoExe.frmUserTongbu frm = new LuoLiuMES.AutoExe.frmUserTongbu();
            frm._UserCode = strUserCode;
            frm.PrimaryValue = string.Empty;
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                this.BindData();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            bool blTb;
            DataTable dtTb;
            try
            {
                dtTb = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TongBuGuid FROM AutoExe_User_Designs WHERE GUID='{0}'"
                    , dr["GUID"].ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dtTb.Rows.Count == 0)
            {
                this.ShowMsg("方案不存在或已经被删除！");
                return;
            }
            if (dtTb.Rows[0]["TongBuGuid"].ToString() != string.Empty)
            {
                frmUserTongbu frm = new frmUserTongbu();
                frm._UserCode = dr["UserCode"].ToString();
                frm.PrimaryValue = dr["GUID"].ToString();
                if (DialogResult.OK != frm.ShowDialog(this))
                    return;
            }
            else
            {
                frmUserForms frm = new frmUserForms();
                frm._UserCode = dr["UserCode"].ToString();
                frm.PrimaryValue = dr["GUID"].ToString();
                frm.ShowDialog(this);
            }
            this.BindData();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("您确定要移除选中的数据吗？")) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            int iReturnValue;
            string strMsg;
            string strGuid;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strGuid = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["GUID"].ToString();
                try
                {
                    this.BllDAL.DelUserDesign(strGuid, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == string.Empty)
                        strMsg = "删除失败，原因未知。";
                    this.ShowMsg(strMsg);
                    return;
                }
            }
            this.BindData();
        }

        private void tsbDefault_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行需要设置为默认的数据。");
                return;
            }
            if (this.dgvList.SelectedRows.Count >1)
            {
                this.ShowMsg("只能选中一条数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.UserDesignSetDefault(dr["GUID"].ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            bool blTb;
            DataTable dtTb;
            try
            {
                dtTb = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TongBuGuid FROM AutoExe_User_Designs WHERE GUID='{0}'"
                    , dr["GUID"].ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dtTb.Rows.Count == 0)
            {
                this.ShowMsg("方案不存在或已经被删除！");
                return;
            }
            if (dtTb.Rows[0]["TongBuGuid"].ToString() != string.Empty)
            {
                frmUserTongbu frm = new frmUserTongbu();
                frm._UserCode = dr["UserCode"].ToString();
                frm.PrimaryValue = dr["GUID"].ToString();
                if (DialogResult.OK != frm.ShowDialog(this))
                    return;
            }
            else
            {
                frmUserForms frm = new frmUserForms();
                frm._UserCode = dr["UserCode"].ToString();
                frm.PrimaryValue = dr["GUID"].ToString();
                frm.ShowDialog(this);
            }
            this.BindData();
        }
    }
}