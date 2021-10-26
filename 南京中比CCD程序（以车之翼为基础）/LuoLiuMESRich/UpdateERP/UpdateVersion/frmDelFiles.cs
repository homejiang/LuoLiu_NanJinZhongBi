using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UpdateERP.UpdateVersion
{
    public partial class frmDelFiles : Common.frmBaseEdit
    {
        public frmDelFiles()
        {
            InitializeComponent();
        }
        public string DelFiles
        {
            get
            {
                return this.richTextBox1.Text;
            }
            set
            {
                this.richTextBox1.Text = value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}