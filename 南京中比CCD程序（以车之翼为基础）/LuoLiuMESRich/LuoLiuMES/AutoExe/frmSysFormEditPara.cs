using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysFormEditPara : Common.frmBaseEdit
    {
        public frmSysFormEditPara()
        {
            InitializeComponent();
        }
        public string Parameter
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}