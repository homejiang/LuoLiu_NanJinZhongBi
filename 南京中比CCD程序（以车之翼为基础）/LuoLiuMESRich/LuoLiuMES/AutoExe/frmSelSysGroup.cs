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
    public partial class frmSelSysGroup : Common.frmBase
    {
        public frmSelSysGroup()
        {
            InitializeComponent();
        }
        #region ��������
        public string _GroupCode = string.Empty;
        /// <summary>
        /// �Ƿ���ʾ����Ϊ������İ�ť��Ĭ��Ϊ��ʾ��
        /// </summary>
        public bool _ShowButtonSetRoot = true;
        #endregion
        #region ������
        private bool Perinit()
        {
            this.btRoot.Visible = this._ShowButtonSetRoot;
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
            TreeNode tn;
            foreach (DataRow dr in drs)
            {
                tn = new TreeNode();
                tn.Tag = dr["Code"].ToString();
                tn.Text = dr["GroupName"].ToString();
                if (_GroupCode != string.Empty && string.Compare(_GroupCode, dr["Code"].ToString(), true) == 0)
                {
                    tn.Checked = true;
                }
                this.tvGroup.Nodes.Add(tn);
                BindGroup(dt, tn);
            }
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
                if (_GroupCode != string.Empty && string.Compare(_GroupCode, dr["Code"].ToString(), true) == 0)
                {
                    tnChild.Checked = true;
                }
                BindGroup(dt, tnChild);
            }
        }
        #endregion

        private void frmSelSysGroup_Load(object sender, EventArgs e)
        {
            this.Perinit();
            BindGroup();
        }

        private void tvGroup_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                //ֻ��ѡ��һ���ڵ�
                bool blDone = false;
                foreach (TreeNode tn in this.tvGroup.Nodes)
                {
                    if (tn.Checked)
                    {
                        if (!tn.Equals(e.Node))
                        {
                            tn.Checked = false;
                            blDone = true;
                            break;
                        }
                    }
                    SetNodeUnCheck(e.Node, tn, ref blDone);
                    if (blDone)
                        break;
                }
            }
        }
        private void SetNodeUnCheck(TreeNode tnSource, TreeNode tn, ref bool blDone)
        {
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (tnchild.Checked)
                {
                    if (!tnchild.Equals(tnSource))
                    {
                        tnchild.Checked = false;
                        blDone = true;
                        break;
                    }
                }
                SetNodeUnCheck(tnSource, tnchild, ref blDone);
                if (blDone)
                    break;
            }
        }
        private void GetCheckedNode(TreeNode tn, ref string sSelected)
        {
            foreach (TreeNode tnchild in tn.Nodes)
            {
                if (tnchild.Checked)
                {
                    sSelected = tnchild.Tag.ToString();
                    break;
                }
                else
                {
                    GetCheckedNode(tnchild, ref sSelected);
                    if (sSelected != string.Empty)
                        break;
                }
            }
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            //��ȡѡ�нڵ�ֵ
            string strCode = string.Empty;
            foreach (TreeNode tn in this.tvGroup.Nodes)
            {
                if (tn.Checked)
                {
                    strCode = tn.Tag.ToString();
                    break;
                }
                else
                {
                    GetCheckedNode(tn, ref strCode);
                    if (strCode != string.Empty)
                        break;
                }
            }
            if (strCode == string.Empty)
            {
                this.ShowMsg("������ѡ��һ���ڵ㡣");
                return;
            }
            _GroupCode = strCode;
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btRoot_Click(object sender, EventArgs e)
        {
            this._GroupCode = string.Empty;
            this.DialogResult = DialogResult.OK;
        }

        private void tvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
        }
    }
}