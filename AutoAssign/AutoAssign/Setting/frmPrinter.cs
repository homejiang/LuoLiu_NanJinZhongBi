using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Setting
{
    public partial class frmPrinter : Common.frmBase
    {
        public frmPrinter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JPSConfig.AutoPrintTuoPan = this.checkBox1.Checked;
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Printer", "AutoPrintTuoPan", JPSConfig.AutoPrintTuoPan ? "1" : "0");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmPrinter_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = JPSConfig.AutoPrintTuoPan;
        }
    }
}
