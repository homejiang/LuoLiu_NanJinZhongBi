using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.UserControls
{
    public partial class frmMsgShineDetail : Form
    {
        public frmMsgShineDetail()
        {
            InitializeComponent();
        }
        public string Msg
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
        private void frmMsgInfo_Load(object sender, EventArgs e)
        {
            
        }
    }
}