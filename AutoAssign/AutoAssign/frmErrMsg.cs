using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class frmErrMsg : Common.frmBase
    {
        public frmErrMsg()
        {
            InitializeComponent();
        }
        public string ErrMsg
        {
            get
            {
                return this.tbMsg.Text;
            }
            set 
            {
                this.tbMsg.Text = value;
            }
        }
        private void frmErrMsg_Load(object sender, EventArgs e)
        {
            //this.button1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}