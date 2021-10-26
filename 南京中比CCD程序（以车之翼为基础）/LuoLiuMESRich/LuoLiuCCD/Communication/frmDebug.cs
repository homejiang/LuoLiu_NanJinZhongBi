using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuCCD.Communication
{
    public partial class frmDebug : Common.frmBase
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            this.tbPIndex.Text = JpsOPC.Debug.ResultValue.ToString();
            this.timer1.Interval = 800;
            this.timer1.Enabled = true;
        }

        private void btMkCode_Click(object sender, EventArgs e)
        {
            JpsOPC.Debug.IsErr = this.chkError.Checked;
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            short iPIindex;
            if(!short.TryParse(this.tbPIndex.Text,out iPIindex))
            {
                this.ShowMsg("tbPIndex必须为整数！");
                return;
            }
            //赋值
            JpsOPC.Debug.ResultValue = iPIindex;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sText;
            Color cB, cF;
            if(JpsOPC.Debug.IsErr)
            {
                sText = "报警";
                cB = Color.Red;
                cF = Color.White;
            }
            else
            {
                sText = "正常";
                cB = Color.White;
                cF = Color.Black;
            }
            if (this.labIsErr.Text != sText)
                this.labIsErr.Text = sText;
            if (this.labIsErr.BackColor != cB)
                this.labIsErr.BackColor = cB;
            if (this.labIsErr.ForeColor != cF)
                this.labIsErr.ForeColor = cF;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iSpecValue;
            if(!int.TryParse(this.tbSpecValue.Text,out iSpecValue))
            {
                this.ShowMsg("请输入整数！");
                return;
            }
            JpsOPC.Debug.ResultValue = (short)iSpecValue;
            JpsOPC.Debug.Code = this.tbCode.Text;
        }
    }
}
