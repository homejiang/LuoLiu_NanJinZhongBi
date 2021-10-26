using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace SysSetting.DeptUsers
{
    public partial class ucDeptsAndUsers : System.Windows.Forms.UserControl
    {
        public ucDeptsAndUsers()
        {
            InitializeComponent();
        }
        #region ��������
        /// <summary>
        /// ���ַ�����ʽ����ѡ���û�����
        /// </summary>
        public string SelectedUserCodes1
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (TreeNode tn in this.treeView1.Nodes)
                {
                    this.GetUserCodes(tn, sb);
                }
                string strUserCodes = sb.ToString();
                if (strUserCodes.StartsWith("|"))
                    strUserCodes = strUserCodes.Substring(1);
                if (strUserCodes.EndsWith("|"))
                    strUserCodes = strUserCodes.Substring(0, strUserCodes.Length - 1);
                return strUserCodes;
            }
        }
        /// <summary>
        /// ��������ʽ����ѡ���û�����
        /// </summary>
        public string[] SelectedUserCodes2
        {
            get
            {
                return this.SelectedUserCodes1.Split('|');
            }
        }
        /// <summary>
        /// ѡ���û�����
        /// </summary>
        public string SelectedUserNames1
        {
            get 
            {
                StringBuilder sb = new StringBuilder();
                foreach (TreeNode tn in this.treeView1.Nodes)
                {
                    this.GetUserNames(tn, sb);
                }
                string strUserNames = sb.ToString();
                if (strUserNames.StartsWith("|"))
                    strUserNames = strUserNames.Substring(1);
                if (strUserNames.EndsWith("|"))
                    strUserNames = strUserNames.Substring(0, strUserNames.Length - 1);
                return strUserNames;
            }
        }
        private bool _isMultiSelected = true;
        /// <summary>
        /// ������ѡ,Ĭ��Ϊ��ѡ
        /// </summary>
        public bool MultiSelected
        {
            get { return this._isMultiSelected; }
            set { this._isMultiSelected = value; }
        }
        #endregion
        #region ��������
        /// <summary>
        /// �������и�ѡ��״̬
        /// </summary>
        /// <param name="blchecked"></param>
        public void SetAllCheckState(bool blchecked)
        {
            foreach (TreeNode tnroot in this.treeView1.Nodes)
                this.SetAllCheckState(tnroot, blchecked);
        }
        private void SetAllCheckState(TreeNode tn,bool blchecked)
        {
            tn.Checked = blchecked;
            foreach (TreeNode tnchild in tn.Nodes)
            {
                tnchild.Checked = blchecked;
                this.SetAllCheckState(tnchild, blchecked);
            }
        }
        #endregion
        #region ������
        private void GetUserCodes(TreeNode tn, StringBuilder sb)
        {
            if (tn.Checked && tn.ImageIndex == 0 && tn.Tag != null)
            {
                sb.Append("|");
                sb.Append(tn.Tag.ToString());
            }
            foreach (TreeNode child in tn.Nodes)
            {
                this.GetUserCodes(child, sb);
            }
        }
        private void GetUserNames(TreeNode tn, StringBuilder sb)
        {
            if (tn.Checked && tn.ImageIndex == 0 && tn.Tag != null)
            {
                sb.Append("|");
                sb.Append(tn.Text.ToString());
            }
            foreach (TreeNode child in tn.Nodes)
            {
                this.GetUserNames(child, sb);
            }
        }
        private void SetUserCodeSelected(TreeNode tn, string str)
        {
            if (tn.ImageIndex == 0 && tn.Tag != null)
            {
                tn.Checked = str.IndexOf("|" + tn.Tag.ToString().ToLower() + "|") >= 0;
            }
            foreach (TreeNode child in tn.Nodes)
            {
                this.SetUserCodeSelected(child, str);
            }
        }
        private void SetNodeCheck(TreeNode tn, bool blchecked)
        {
            tn.Checked = blchecked;
            foreach (TreeNode child in tn.Nodes)
            {
                if (child.Checked ^ blchecked)
                    child.Checked = blchecked;
                this.SetNodeCheck(child, blchecked);
            }
        }
        #endregion
        #region ��ȡѡ�нڵ㣨��Ե�ѡ�����
        private TreeNode GetCheckedNode(TreeNode tn,TreeNode tnExcept)
        {
            if (tn.Equals(tnExcept)) return null;
            if (tn.ImageIndex != 0)
            {
                TreeNode tntemp;
                //��ʱ��Ҫ�����ӽڵ�
                foreach (TreeNode tnchild in tn.Nodes)
                {
                    tntemp = this.GetCheckedNode(tnchild, tnExcept);
                    if (tntemp != null) return tntemp;
                }
            }
            else if (tn.Checked) return tn;
            return null;
        }
        #endregion
        #region �󶨲��ź��û�
        public bool BindDeptAndUsers(string strUsercodes)
        {
            //������������û�
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listsql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listsql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT DeptCode,ParentDetpCode,DeptShortName,DeptName,DeptENName FROM Sys_Department order by ParentDetpCode ASC", "Sys_Department"));
            listsql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT UserCode,DeptCode,ISNULL(UserName,UserENName) AS UserName FROM  Sys_Users WHERE ISNULL(Terminated,0)=0 ORDER BY ISNULL(UserName,UserENName) ASC", "Sys_Users"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listsql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.treeView1.Nodes.Clear();
            TreeNode tnRoot;
            DataRow[] drsRoot = ds.Tables["Sys_Department"].Select("ISNULL(ParentDetpCode,'')=''");
            foreach (DataRow dr in drsRoot)
            {
                tnRoot = new TreeNode();
                tnRoot.Text = Common.CommonFuns.FormatData.GetStringByOrder(dr["DeptShortName"].ToString(), dr["DeptName"].ToString(), dr["DeptENName"].ToString());
                tnRoot.Tag = dr["DeptCode"].ToString();
                tnRoot.ImageIndex = 1;
                this.treeView1.Nodes.Add(tnRoot);
                this.BindUser(ds.Tables["Sys_Department"], tnRoot, ds.Tables["Sys_Users"], strUsercodes);
            }
            //ֻչ���ܲ��ţ��Ӳ�����Ա����չ�����������ڲ�����Ա
            //this.treeView1.ExpandAll();
            //���û�
            return true;
        }
        private void BindUser(DataTable dt, TreeNode tn,DataTable dtUsers,string strUsercodes)
        {
            if (tn.Tag == null) return;
            if (strUsercodes.Length > 0)
            {
                if (!strUsercodes.StartsWith("|"))
                    strUsercodes = "|" + strUsercodes;
                if (!strUsercodes.EndsWith("|"))
                    strUsercodes += "|";
                strUsercodes = strUsercodes.ToLower();
            }
            //�󶨸ò������û�
            DataRow[] drUsers = dtUsers.Select(string.Format("DeptCode='{0}'", tn.Tag.ToString()));
            foreach (DataRow dr in drUsers)
            {
                TreeNode tnUser = new TreeNode();
                tnUser.Text = dr["UserName"].ToString();
                tnUser.Tag = dr["UserCode"].ToString();
                tnUser.Checked = strUsercodes.IndexOf("|" + dr["UserCode"].ToString().ToLower() + "|") >= 0;
                tnUser.ImageIndex = 0;
                tn.Nodes.Add(tnUser);
            }
            DataRow[] drs = dt.Select(string.Format("ParentDetpCode='{0}'", tn.Tag));
            foreach (DataRow dr in drs)
            {
                TreeNode tnNew = new TreeNode();
                tnNew.Text = Common.CommonFuns.FormatData.GetStringByOrder(dr["DeptShortName"].ToString(), dr["DeptName"].ToString(), dr["DeptENName"].ToString());
                tnNew.Tag = dr["DeptCode"].ToString();
                tnNew.ImageIndex = 1;
                tn.Nodes.Add(tnNew);
                this.BindUser(dt, tnNew, dtUsers, strUsercodes);
            }
        }
        #endregion
        #region ���弰�ؼ��¼�
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!this.MultiSelected)
            {
                #region ��ʱΪ��ѡ
                //����ǵ�ѡ���������û��
                if (e.Node.ImageIndex != 0)
                    return;
                bool blChecked = e.Node.Checked;
                if (blChecked)
                {
                    TreeNode tnCheced = null;
                    foreach (TreeNode tn in this.treeView1.Nodes)
                    {
                        tnCheced = this.GetCheckedNode(tn,e.Node);
                        if (tnCheced != null) break;
                    }
                    if (tnCheced != null)
                        tnCheced.Checked = false;
                }
                #endregion
                return;
            }
            if (e.Node.ImageIndex != 0)
            {
                //��ʱ��ʾΪ����
                foreach (TreeNode tn in e.Node.Nodes)
                    this.SetNodeCheck(tn, e.Node.Checked);
            }
            if (e.Node.Parent != null)
            {
                TreeNode tnParent;
                if (!e.Node.Checked)
                {
                    tnParent = e.Node.Parent;
                    while (tnParent != null)
                    {
                        if (tnParent.Checked)
                            tnParent.Checked = false;
                        tnParent = tnParent.Parent;
                    }
                    if (e.Node.Parent.Checked)
                        e.Node.Parent.Checked = false;
                    this.treeView1.SelectedImageIndex = 0;
                }
            }
        }
        private bool NodesAllChecked(TreeNode tn)
        {
            if (!tn.Checked) return false;
            foreach (TreeNode child in tn.Nodes)
            {
                if (!this.NodesAllChecked(child))
                    return false;
            }
            return true;
        }
        #endregion
    }
}
