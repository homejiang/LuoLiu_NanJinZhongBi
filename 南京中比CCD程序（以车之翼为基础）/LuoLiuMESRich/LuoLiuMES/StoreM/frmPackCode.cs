using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.StoreM
{
    public partial class frmPackCode : Common.frmBaseEdit
    {
        public frmPackCode()
        {
            InitializeComponent();
        }
        public bool GoOn
        {
            get
            {
                return this.checkBox1.Checked;
            }
            set
            {
                this.checkBox1.Checked = value;
            }
        }
        public string PackCode
        {
            get
            {
                return this.tbPackCode.Text;
            }
        }
        private void frmCableCode_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tbPackCode.Text == string.Empty) return;
            this.DialogResult = DialogResult.OK;
        }
    }
}
