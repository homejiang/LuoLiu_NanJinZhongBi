using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoAssign.RecordPagesManager
{
    public partial class frmPageRowsCount : Common.frmBase
    {
        string _ParentFormName = string.Empty;
        public frmPageRowsCount(string parentFormName)
        {
            InitializeComponent();
            _ParentFormName = parentFormName;
        }
        public int PageRowsCount
        {
            get
            {
                return (int)this.numericUpDown1.Value;
            }
            set
            {
                this.numericUpDown1.Value = (decimal)value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.numericUpDown1.Value<=0M)
            {
                this.ShowMsg("请输入大于0的正整数。");
                return;
            }
            if(this.checkBox1.Checked)
            {
                if(_ParentFormName.Length==0)
                {
                    this.ShowMsg("翻页控件的父级窗口获取错误！");
                    return;
                }
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(string.Format("EXEC Common_RecordPagesManager_SetCount '{0}','{1}',{2}"
                        , Common.CurrentUserInfo.UserCode, _ParentFormName.Replace("''", ""), (int)this.numericUpDown1.Value));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(null, ex);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        public override void ShowMsg(string strMsg)
        {
            this.labMsg.Text = strMsg;
        }
    }
}
