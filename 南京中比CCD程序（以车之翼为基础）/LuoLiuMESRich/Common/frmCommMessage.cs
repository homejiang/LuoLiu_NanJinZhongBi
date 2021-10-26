using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmCommMessage : Form
    {
        public frmCommMessage()
        {
            InitializeComponent();
        }
        
        public RichTextBox _TextBox
        {
            get
            {
                return this.richTextBox1;
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
            frmMainBase frmParent = this.Owner as frmMainBase;
            if (frmParent != null && !frmParent.MsgFormClosing()) return;
            this.Hide();
        }

        private void frmCommMessage_Shown(object sender, EventArgs e)
        {
            frmMainBase frmParent = this.Owner as frmMainBase;
            if (frmParent != null) frmParent.MsgFormShowed();
        }
    }
}