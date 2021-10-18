using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int vlaue1 = int.Parse(this.tbByte1.Text);
            int vlaue2 = int.Parse(this.tbByte2.Text);
            int vlaue3 = int.Parse(this.tbByte3.Text);
            int vlaue4 = int.Parse(this.tbByte4.Text);
            byte b1 = Convert.ToByte(vlaue1);
            byte b2 = Convert.ToByte(vlaue2);
            byte b3 = Convert.ToByte(vlaue3);
            byte b4 = Convert.ToByte(vlaue4);
            byte[] bs = new byte[] { b1, b2, b3, b4 };
            this.textBox1.Text = BitConverter.ToInt32(bs, 0).ToString();
            int itmp = vlaue4 * 256 * 256 * 256 + vlaue3 * 256 * 256 + vlaue2 * 256 + vlaue1;
            this.textBox2.Text = itmp.ToString();
        }
    }
}
