using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SysSetting.DeptUsers
{
    public partial class frmSelectUserSample : Common.frmSelectBase
    {
        public frmSelectUserSample()
        {
            InitializeComponent();
        }
        #region ��������
        private string _selected = string.Empty;
        /// <summary>
        /// ѡ�е��û���ÿ���û���|�ָ�
        /// </summary>
        public string SelectedUserCodes
        {
            get
            {
                return this.ucDeptsAndUsers1.SelectedUserCodes1;
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
                return this.ucDeptsAndUsers1.SelectedUserNames1;
            }
        }
        #endregion
        private void frmSelectUserSample_Load(object sender, EventArgs e)
        {
            this.ucDeptsAndUsers1.MultiSelected = this.MultiSelected;
            this.ucDeptsAndUsers1.BindDeptAndUsers(this._selected);//����Ĭ�ϵ�ѡ���û�
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        #region ��������Ѿ�ѡ���
        private void btAllUnChecked_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(this, "��ȷ��Ҫ������ѡ�е��û�����Ϊδѡ����", "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            this.ucDeptsAndUsers1.SetAllCheckState(false);
        }
        
        #endregion
    }
}