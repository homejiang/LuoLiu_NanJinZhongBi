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
    public partial class frmDebug : Common.frmBase
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            this.tbMkCode.Text = HanJieOPC.Debug.MKCode;
            this.tbPtCnt.Text = HanJieOPC.Debug.PtCnt.ToString();
            this.tbPIndex.Text = HanJieOPC.Debug.Pindex.ToString();
            this.tbArg.Text = HanJieOPC.Debug.Arg.ToString();
            this.tbA.Text = HanJieOPC.Debug.A.ToString("#########0.###");
            this.tbV.Text = HanJieOPC.Debug.A.ToString("#########0.###");
            this.chkWritten.Checked = HanJieOPC.Debug.Writen;
        }

        private void btMkCode_Click(object sender, EventArgs e)
        {
            HanJieOPC.Debug.MKCode = this.tbMkCode.Text;
            HanJieOPC.Debug.MKCode2 = this.tbMkCode2.Text;
            short iValue;
            if (short.TryParse(this.tbPtCnt.Text, out iValue))
                HanJieOPC.Debug.PtCnt = iValue;
            else
            {
                this.ShowMsg("PtCnt必须是整数");
                return;
            }
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            short iPIindex;
            if(!short.TryParse(this.tbPIndex.Text,out iPIindex))
            {
                this.ShowMsg("tbPIndex必须为整数！");
                return;
            }
            float fA;
            if(!float.TryParse(this.tbA.Text,out fA))
            {
                this.ShowMsg("A必须为 float！");
                return;
            }
            float fV;
            if (!float.TryParse(this.tbV.Text, out fV))
            {
                this.ShowMsg("V必须为 float！");
                return;
            }
            short iArg;
            if (!short.TryParse(this.tbArg.Text, out iArg))
            {
                this.ShowMsg("tbArg必须为整数！");
                return;
            }
            //赋值
            HanJieOPC.Debug.Writen = this.chkWritten.Checked;
            HanJieOPC.Debug.Pindex = iPIindex;
            HanJieOPC.Debug.A = fA;
            HanJieOPC.Debug.V = fV;
            HanJieOPC.Debug.Arg = iArg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            short iPIindex;
            if (!short.TryParse(this.tbPIndex2.Text, out iPIindex))
            {
                this.ShowMsg("tbPIndex必须为整数！");
                return;
            }
            float fA;
            if (!float.TryParse(this.tbA2.Text, out fA))
            {
                this.ShowMsg("A必须为 float！");
                return;
            }
            float fV;
            if (!float.TryParse(this.tbV2.Text, out fV))
            {
                this.ShowMsg("V必须为 float！");
                return;
            }
            short iArg;
            if (!short.TryParse(this.tbArg2.Text, out iArg))
            {
                this.ShowMsg("tbArg必须为整数！");
                return;
            }
            //赋值
            HanJieOPC.Debug.Pindex2 = iPIindex;
            HanJieOPC.Debug.A2 = fA;
            HanJieOPC.Debug.V2 = fV;
            HanJieOPC.Debug.Arg2 = iArg;
        }
    }
}
