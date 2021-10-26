using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSql = "update jc_sfgstore set storagecode='''sys2002''' where processcode='''sys001''' and storagecode<>'sys2002'";
            try
            {
                CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            MessageBox.Show("成功！");
        }
    }
}