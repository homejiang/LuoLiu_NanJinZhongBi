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
        #region ������������ʵ��
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// ������������ʵ��
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
        #region ������
        private bool Perinit()
        {
            #region ���ù�����combox��������
            //����������
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "�û�����";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "UserName LIKE '%{0}%'";
            item.Value = 1;
            listSearchItem.Add(item);
            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "��������";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "DesignName LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tslTitle, listSearchItem);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            #region ֻ�й���Ա����Ȩ�༭����
            bool blIsAdmin = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            this.tsbAdd.Enabled = blIsAdmin;
            this.toolStripButton1.Enabled = blIsAdmin;
            //this.tsbEdit.Enabled = blIsAdmin;
            this.tsbRemove.Enabled = blIsAdmin;
            this.tsbDefault.Enabled = blIsAdmin;
            this.tsbEdit.Text = blIsAdmin ? "�༭" : "�鿴";
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
            tnRoot.Text = "���в���";
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
                    #region ��ʱѡ�����û�
                    strSql += " AND UserCode='" + strTag.Substring(5).Replace("'", "''") + "'";
                    #endregion
                }
                else if (strTag.IndexOf("DEPT&") == 0)
                {
                    #region ��ʱ�û�ѡ���˲���
                    //��Ҫ�����Ĳ����������Ӳ���
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
        #region ����OnLoad�¼�
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
        #region ��������ť�¼�
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            string strUserCode = string.Empty;
            TreeNode tn = this.treeView1.SelectedNode;
            if (tn != null && tn.Tag != null)
                strUserCode = tn.Tag.ToString();
            if (strUserCode.IndexOf("USER&") != 0)
            {
                this.ShowMsg("������ߴ�����ѡ��1���û���");
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
                this.ShowMsg("������ߴ�����ѡ��1���û���");
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
                this.ShowMsg("��ѡ��һ�����ݡ�");
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
                this.ShowMsg("���������ڻ��Ѿ���ɾ����");
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
                this.ShowMsg("��ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("��ȷ��Ҫ�Ƴ�ѡ�е�������")) return;
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
                        strMsg = "ɾ��ʧ�ܣ�ԭ��δ֪��";
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
                this.ShowMsg("��ѡ��һ����Ҫ����ΪĬ�ϵ����ݡ�");
                return;
            }
            if (this.dgvList.SelectedRows.Count >1)
            {
                this.ShowMsg("ֻ��ѡ��һ�����ݡ�");
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
                this.ShowMsg("���������ڻ��Ѿ���ɾ����");
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