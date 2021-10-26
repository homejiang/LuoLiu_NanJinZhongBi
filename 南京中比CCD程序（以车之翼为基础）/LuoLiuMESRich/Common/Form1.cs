using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form1 : frmBaseEdit
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Report_GetWaittingHTMLTitle {0}", 1));
            }
            catch (Exception ex)
            {
                //wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.webBrowser1.DocumentText = dt.Rows[0][0].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(@"E:\Project Files\CableERP\CableERP\Common\bin\Debug\testolex\复件 日产量统计表.htm");
        }
    }
}