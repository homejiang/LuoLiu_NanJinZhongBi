using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace ErrorService
{
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            try
            {
                dt = ErrorDAL.DoSqlCommand.GetDateTable("SELECT dbo.Common_System_HelpInfo()");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt == null) return;
            this.richTextBox1.Text = dt.Rows[0][0].ToString();
        }
    }
}