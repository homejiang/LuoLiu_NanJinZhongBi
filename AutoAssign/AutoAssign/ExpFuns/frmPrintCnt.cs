using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmPrintCnt : Common.frmBase
    {
        public frmPrintCnt()
        {
            InitializeComponent();
        }
        public int _Cnt = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            AutoAssign.MyPrinter.AutoPrint = this.chkAutoPrint.Checked;
            if (AutoAssign.MyPrinter.AutoPrint)
            {
                int iValue = (int)this.numValue.Value;
                if (iValue <= 0)
                {
                    this.ShowMsg("请输入至少大于0的自然数。");
                    return;
                }
                this._Cnt = iValue;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmPrintCnt_Load(object sender, EventArgs e)
        {
            this.chkAutoPrint.Checked = AutoAssign.MyPrinter.AutoPrint;
            this.numValue.ReadOnly = !this.chkAutoPrint.Checked;
        }

        private void chkAutoPrint_CheckedChanged(object sender, EventArgs e)
        {
            this.numValue.ReadOnly = !this.chkAutoPrint.Checked;
        }
    }
}
