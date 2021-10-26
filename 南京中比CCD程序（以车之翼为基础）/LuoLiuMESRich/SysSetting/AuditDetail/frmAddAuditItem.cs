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
        
        #region 公共属性
        /// <summary>
        /// 获取和设置审批标题
        /// </summary>
        public string Title
        {
            get { return this.tbTitle.Text; }
            set {this.tbTitle.Text=value;}
        }
        private string _selected = string.Empty;
        /// <summary>
        /// 选中的用户，每个用户用|分割
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
        /// 选中用户名称
        /// </summary>
        public string SelectedUserNames
        {
            get
            {
                return this.UCDeptAndUsers.SelectedUserNames1;
            }
        }
        #endregion 
        #region 私有属性
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
        #region 窗体加载事件
        private void frmAddPactReviewItem_Load(object sender, EventArgs e)
        {
            this.tableLayoutPanel1.Controls.Add(this.UCDeptAndUsers, 0, 1);
            this.UCDeptAndUsers.BindDeptAndUsers(this._selected);//加载默认的选中用户
        }
        #endregion
        #region 按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            //校验用户是否输入
            this.tbTitle.Text = this.tbTitle.Text.Trim();
            if (this.tbTitle.Text.Length == 0)
            {
                this.ShowMsg("请输入流程名称");
                this.tbTitle.Focus();
                return;
            }
            if (this.SelectedUserCodes.Length == 0)
            {
                if (DialogResult.Yes != MessageBox.Show("您未选择待审批人，您确定暂时不选择吗？", "操作提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
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