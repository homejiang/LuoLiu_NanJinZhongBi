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
    public partial class frmResultLogSendDataBase : Common.frmBase
    {
        public frmResultLogSendDataBase()
        {
            InitializeComponent();
        }

        private void frmScannerLogSendDataBase_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = JPSConfig.ResultLogSavetoDataBase;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            JPSConfig.ResultLogSavetoDataBase = this.checkBox1.Checked;
            this.DialogResult = DialogResult.OK;
        }
    }
}
