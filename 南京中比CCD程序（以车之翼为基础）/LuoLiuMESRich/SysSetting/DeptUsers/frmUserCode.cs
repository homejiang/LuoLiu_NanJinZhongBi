using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace SysSetting.DeptUsers
{
    public partial class frmUserCode : Common.frmBase
    {
        public frmUserCode()
        {
            InitializeComponent();
        }
        public string UserCode = string.Empty;
        public string UserName = string.Empty;
        public string DeptCode = string.Empty;
        public string DeptName = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.myTextBox1.Text.Length == 0)
            {
                this.ShowMsg("请输入工号。");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT A.UserName,A.DeptCode,B.DeptName FROM SYS_USERS A LEFT JOIN Sys_Department B ON B.DeptCode=A.DeptCode WHERE A.UserCode='{0}'", this.myTextBox1.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("工号\"" + this.myTextBox1.Text + "\"不存在。");
                return;
            }
            this.UserCode = this.myTextBox1.Text;
            this.UserName = dt.Rows[0]["UserName"].ToString();
            this.DeptCode = dt.Rows[0]["DeptCode"].ToString();
            this.DeptName = dt.Rows[0]["DeptName"].ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void myTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(null, null);
        }

        private void linkFind_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Common.Login.frmFindUser frm = new Common.Login.frmFindUser();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._SelUserCode.Length > 0)
                this.myTextBox1.Text = frm._SelUserCode;
        }
    }
}