using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            if (!int.TryParse(this.textBox1.Text, out i)) return;
            byte b = Convert.ToByte(i);
            this.textBox2.Text = GetStringFromByte(b);
        }
        private string GetStringFromByte(byte b)
        {
            string s = string.Empty;
            for (int i = 7; i >= 0; i--)
            {
                s += Convert.ToString((b >> i) & 0x01);
            }
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime det1 = DateTime.Parse("2016-09-09 09:09:09.001");
            DateTime det2 = DateTime.Parse("2016-09-09 09:09:09.600");
            TimeSpan ts = det2 - det1;
            this.textBox1.Text = ts.TotalSeconds.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime time1 = DateTime.Parse(this.textBox3.Text);
            DateTime time2 = DateTime.Parse(this.textBox4.Text);
            TimeSpan ts = time2 - time1;
            this.textBox5.Text = ts.TotalMilliseconds.ToString();
        }
    }
}