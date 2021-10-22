using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmNjzbDebug : Form
    {
        public frmNjzbDebug()
        {
            InitializeComponent();
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JpsOPC.SJDebug.WorkState = (short)this.numericUpDown1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal dec;
            if (!decimal.TryParse(this.textBox1.Text, out dec)) return;
            JpsOPC.SJDebug.SJ_Resut1 = dec;
            JpsOPC.SJDebug.SJ_Resut2 = dec;
            JpsOPC.SJDebug.SJ_Resut3 = dec;
            JpsOPC.SJDebug.SJ_Resut4 = dec;
            JpsOPC.SJDebug.SJ_Resut5 = dec;
            JpsOPC.SJDebug.SJ_Resut6 = dec;
            JpsOPC.SJDebug.SJ_Resut7 = dec;
            JpsOPC.SJDebug.SJ_Resut8 = dec;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal dec;
            if (!decimal.TryParse(this.textBox2.Text, out dec)) return;
            JpsOPC.SJDebug.SJ_Resut9 = dec;
            JpsOPC.SJDebug.SJ_Resut10 = dec;
            JpsOPC.SJDebug.SJ_Resut11 = dec;
            JpsOPC.SJDebug.SJ_Resut12 = dec;
            JpsOPC.SJDebug.SJ_Resut13 = dec;
            JpsOPC.SJDebug.SJ_Resut14 = dec;
            JpsOPC.SJDebug.SJ_Resut15 = dec;
            JpsOPC.SJDebug.SJ_Resut16 = dec;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tbWrk.Text = JpsOPC.SJDebug.WorkState.ToString();
            this.tbR1.Text = JpsOPC.SJDebug.SJ_Resut1.ToString();
            this.tbR9.Text = JpsOPC.SJDebug.SJ_Resut9.ToString();
        }
    }
}
