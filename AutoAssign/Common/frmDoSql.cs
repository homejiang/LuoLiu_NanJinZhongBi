using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmDoSql : Form
    {
        public frmDoSql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSql = string.Format("execute('{0}')", this.richTextBox1.Text.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch(Exception ex)
            {
                this.richTextBox2.Text = ex.Message;
                return;
            }
            this.richTextBox2.Text = "执行成功" + "---" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
