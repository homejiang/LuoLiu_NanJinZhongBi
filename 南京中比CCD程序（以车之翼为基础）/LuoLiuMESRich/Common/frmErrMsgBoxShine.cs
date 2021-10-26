using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmErrMsgBoxShine : Common.frmBase
    {
        public frmErrMsgBoxShine()
        {
            InitializeComponent();
        }
        public string _Msg = string.Empty;

        private void frmInputXiangErrMsg_Load(object sender, EventArgs e)
        {
            this.labMsg.Text = _Msg;
            this.timer1.Interval = 600;
            this.timer1.Enabled = true;
            this.panel1.BackColor = Color.Red;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (panel1.BackColor == Color.Red)
                panel1.BackColor = SystemColors.Control;
            else if (panel1.BackColor == SystemColors.Control)
                panel1.BackColor = Color.Red;
            
        }
    }
}