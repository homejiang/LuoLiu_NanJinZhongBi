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
    public partial class frmSysFormModifyGroup : Common.frmBaseEdit
    {
        public frmSysFormModifyGroup()
        {
            InitializeComponent();
        }
        #region 公共属性
        public string _GroupCode = string.Empty;
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT Code,GroupName FROM AutoExe_Sys_Group order by SortID");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            Common.MyEntity.ComboBoxItem item;
            foreach (DataRowView drv in dt.DefaultView)
            {
                this.comboBox1.Items.Add(new Common.MyEntity.ComboBoxItem(drv.Row["GroupName"].ToString(), drv.Row["Code"].ToString()));
            }
            return true;
        }
        #endregion

        private void frmSysFormModifyGroup_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = this.PerInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.comboBox1.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString() == string.Empty)
            {
                this.ShowMsg("请选择组！");
                return;
            }
            this._GroupCode = item.Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}