using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using SysSetting.DeptUsers;
namespace SysSetting.AuditDetail
{
    public partial class frmAddAuditItem :Common.frmSelectBase
    {
        public frmAddAuditItem()
        {
            InitializeComponent();
        }
        
        #region ��������
        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public string Title
        {
            get { return this.tbTitle.Text; }
            set {this.tbTitle.Text=value;}
        }
        private string _selected = string.Empty;
        /// <summary>
        /// ѡ�е��û���ÿ���û���|�ָ�
        /// </summary>
        public string SelectedUserCodes
        {
            get
            {
                return this.UCDeptAndUsers.SelectedUserCodes1;
            }
            set
            {
                this._selected = value;
            }
        }
        /// <summary>
        /// ѡ���û�����
        /// </summary>
        public string SelectedUserNames
        {
            get
            {
                return this.UCDeptAndUsers.SelectedUserNames1;
            }
        }
        #endregion 
        #region ˽������
        private ucDeptsAndUsers _ucDeptAndUsers = null;
        private ucDeptsAndUsers UCDeptAndUsers
        {
            get
            {
                if (_ucDeptAndUsers == null)
                {
                    this._ucDeptAndUsers = new ucDeptsAndUsers();
                    this._ucDeptAndUsers.Dock = DockStyle.Fill;
                    System.Drawing.Font font = new Font("",12);
                    this._ucDeptAndUsers.Font = font;
                }
                return this._ucDeptAndUsers;
            }
        }
        #endregion
        #region ��������¼�
        private void frmAddPactReviewItem_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Controls.Add(this.UCDeptAndUsers, 0, 1);
            this.UCDeptAndUsers.BindDeptAndUsers(this._selected);//����Ĭ�ϵ�ѡ���û�
        }
        #endregion
        #region ��ť�¼�
        private void btTrue_Click(object sender, EventArgs e)
        {
            //У���û��Ƿ�����
            this.tbTitle.Text = this.tbTitle.Text.Trim();
            if (this.tbTitle.Text.Length == 0)
            {
                this.ShowMsg("��������������");
                this.tbTitle.Focus();
                return;
            }
            if (this.SelectedUserCodes.Length == 0)
            {
                if (DialogResult.Yes != MessageBox.Show("��δѡ��������ˣ���ȷ����ʱ��ѡ����", "��������", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #endregion
    }

}