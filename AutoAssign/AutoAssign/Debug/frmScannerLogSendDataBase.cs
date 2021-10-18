using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Debug
{
    public partial class frmScannerLogSendDataBase : Common.frmBase
    {
        public frmScannerLogSendDataBase()
        {
            InitializeComponent();
        }

        private void frmScannerLogSendDataBase_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = JPSConfig.ScannerLogSavetoDataBase;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            JPSConfig.ScannerLogSavetoDataBase = this.checkBox1.Checked;

            this.DialogResult = DialogResult.OK;
        }
    }
}
