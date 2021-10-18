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
    public partial class frmDebug : Common.frmBase
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            this.btOpc.Enabled = JPSEntity.Debug.ScannerOpc.IsDebug;
            this.chkBat_Bool1.Checked = JPSEntity.Debug.ScannerOpc.Bat_Bool1;
            this.chkBat_Bool2.Checked = JPSEntity.Debug.ScannerOpc.Bat_Bool2;
        }

        private void btOpc_Click(object sender, EventArgs e)
        {
            JPSEntity.Debug.ScannerOpc.Bat_Bool1 = this.chkBat_Bool1.Checked;
            JPSEntity.Debug.ScannerOpc.Bat_Bool2 = this.chkBat_Bool2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JpsOPC.OPCHelperGongYi.Debug_sysNew= (short)this.numSysNew.Value;
        }

        private void btCompeleted_Click(object sender, EventArgs e)
        {
            JpsOPC.OPCHelperGongYi.Debug_SysCompeleted = (short)this.numCompeleted.Value;
        }
    }
}
