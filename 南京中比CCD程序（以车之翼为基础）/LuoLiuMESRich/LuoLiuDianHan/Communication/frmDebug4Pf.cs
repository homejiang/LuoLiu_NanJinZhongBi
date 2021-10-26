using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuDianHan.Communication
{
    public partial class frmDebug4Pf : Form
    {
        public frmDebug4Pf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iValue = (int)this.numBc.Value;
            HanJieOPC.PointSetDebug.BC_A1 = iValue++;
            HanJieOPC.PointSetDebug.BC_A2 = iValue++;
            HanJieOPC.PointSetDebug.BC_A3 = iValue++;
            HanJieOPC.PointSetDebug.BC_A4 = iValue++;
            HanJieOPC.PointSetDebug.BC_A5 = iValue++;
            HanJieOPC.PointSetDebug.BC_A6 = iValue++;

            HanJieOPC.PointSetDebug.BC_B1 = iValue++;
            HanJieOPC.PointSetDebug.BC_B2 = iValue++;
            HanJieOPC.PointSetDebug.BC_B3 = iValue++;
            HanJieOPC.PointSetDebug.BC_B4 = iValue++;
            HanJieOPC.PointSetDebug.BC_B5 = iValue++;
            HanJieOPC.PointSetDebug.BC_B6 = iValue++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HanJieOPC.PointSetDebug.Read_Doing = (short)numReadDoing.Value;
            HanJieOPC.PointSetDebug.LP_Cnt= (short)numLCnt.Value;
            HanJieOPC.PointSetDebug.RP_Cnt = (short)numRCnt.Value;
        }
        int _Value = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            HanJieOPC.PointSetDebug.PIndex = (short)numPIndex.Value;
            HanJieOPC.PointSetDebug.P1_Work = true;
            HanJieOPC.PointSetDebug.P2_Work = false;
            HanJieOPC.PointSetDebug.P3_Work = true;
            HanJieOPC.PointSetDebug.P4_Work = true;
 
            HanJieOPC.PointSetDebug.P1_Type = _Value++;
            HanJieOPC.PointSetDebug.P1_AY = _Value++;
            HanJieOPC.PointSetDebug.P1_AZ = _Value++;
            HanJieOPC.PointSetDebug.P1_BY = _Value++;
            HanJieOPC.PointSetDebug.P1_BZ = _Value++;

            HanJieOPC.PointSetDebug.P2_Type = _Value++;
            HanJieOPC.PointSetDebug.P2_AY = _Value++;
            HanJieOPC.PointSetDebug.P2_AZ = _Value++;
            HanJieOPC.PointSetDebug.P2_BY = _Value++;
            HanJieOPC.PointSetDebug.P2_BZ = _Value++;

            HanJieOPC.PointSetDebug.P3_Type = _Value++;
            HanJieOPC.PointSetDebug.P3_AY = _Value++;
            HanJieOPC.PointSetDebug.P3_AZ = _Value++;
            HanJieOPC.PointSetDebug.P3_BY = _Value++;
            HanJieOPC.PointSetDebug.P3_BZ = _Value++;

            HanJieOPC.PointSetDebug.P4_Type = _Value++;
            HanJieOPC.PointSetDebug.P4_AY = _Value++;
            HanJieOPC.PointSetDebug.P4_AZ = _Value++;
            HanJieOPC.PointSetDebug.P4_BY = _Value++;
            HanJieOPC.PointSetDebug.P4_BZ = _Value++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numReadDoing.Value = HanJieOPC.PointSetDebug.Read_Doing;
            numLCnt.Value = HanJieOPC.PointSetDebug.LP_Cnt;
            numRCnt.Value = HanJieOPC.PointSetDebug.RP_Cnt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numPIndex.Value = HanJieOPC.PointSetDebug.PIndex;
        }
    }
}
