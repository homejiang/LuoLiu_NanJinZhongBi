using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.RecordPagesManager
{
    public partial class frmJumpTo : Common.frmBase
    {
        public frmJumpTo(int maxValue)
        {
            InitializeComponent();
            this.numericUpDown1.Maximum = maxValue;
        }
        public int CurrIndex
        {
            get
            {
                return (int)this.numericUpDown1.Value;
            }
            set
            {
                this.numericUpDown1.Value = (decimal)value;
            }
        }
        private void frmJumpTo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.numericUpDown1.Value <= 0M)
            {
                this.ShowMsg("请输入大于0的正整数。");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        public override void ShowMsg(string strMsg)
        {
            this.labMsg.Text = strMsg;
        }
    }
}
