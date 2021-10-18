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
    public partial class frmMKAutomation : Common.frmBase
    {
        JpsOPC.OPCHelperMKBuilding _OpcHelper = null;
        public frmMKAutomation(JpsOPC.OPCHelperMKBuilding opcHelper)
        {
            InitializeComponent();
            if(opcHelper!=null)
            {
                this.timer1.Interval = 800;
                this.timer1.Enabled = true;
            }
        }

        private void frmMKAutomation_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.tbBatCodes_timer.Text != JpsOPC.JPSDebug.MKAutomationDebug.BatCodes)
                this.tbBatCodes_timer.Text = JpsOPC.JPSDebug.MKAutomationDebug.BatCodes;
            if ((short)this.numFinished_Timer.Value != JpsOPC.JPSDebug.MKAutomationDebug.Finished)
                this.numFinished_Timer.Value = JpsOPC.JPSDebug.MKAutomationDebug.Finished;
            if (this.tbMKCode_Timer.Text != JpsOPC.JPSDebug.MKAutomationDebug.MKCode)
                this.tbMKCode_Timer.Text = JpsOPC.JPSDebug.MKAutomationDebug.MKCode;

        }
        public override void ShowMsg(string strMsg)
        {
            this.tbErr.Text = strMsg;
        }

        private void btReadOPCBatCodes_Click(object sender, EventArgs e)
        {
            this.tbBatCodes_timer.Text = JpsOPC.JPSDebug.MKAutomationDebug.BatCodes;
        }

        private void btWriteOPCBatCodes_Click(object sender, EventArgs e)
        {
            JpsOPC.JPSDebug.MKAutomationDebug.BatCodes = this.tbBatCodes.Text;
        }

        private void btWriteOPCFinished_Click(object sender, EventArgs e)
        {
            JpsOPC.JPSDebug.MKAutomationDebug.Finished = (short)this.numFinished.Value;
        }

        private void btClearMKCode_Click(object sender, EventArgs e)
        {
            JpsOPC.JPSDebug.MKAutomationDebug.MKCode = string.Empty;
        }
    }
    
}
