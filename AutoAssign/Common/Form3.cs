using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddString(string.Format("panelwidth:{0}，scrollWidth:{1}", this.panel1.Width, this.panel1.HorizontalScroll.Value));
        }
        private void AddString(string sMsg)
        {

            this.richTextBox1.AppendText(sMsg + "\r\n");
        }
    }
}
