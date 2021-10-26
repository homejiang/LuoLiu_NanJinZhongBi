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
        #region 公共属性
        private string _selected = string.Empty;
        /// <summary>
        /// 选中的用户，每个用户用|分割
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
        /// 选中用户名称
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
            this.ucDeptsAndUsers1.BindDeptAndUsers(this._selected);//加载默认的选中用户
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
        #region 清楚所有已经选择的
        private void btAllUnChecked_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要所有已选中的用户设置为未选中吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            this.ucDeptsAndUsers1.SetAllCheckState(false);
        }
        
        #endregion
    }
}