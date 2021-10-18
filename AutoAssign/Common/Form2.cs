using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form2 : frmBase
    {
        public Form2()
        {
            InitializeComponent();
            this.textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(this.textBox1.Text) > DateTime.Now)
            {
                this.ShowMsg("未来");
            }
            else
                this.ShowMsg("过去");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = DateTime.Now.AddMilliseconds(double.Parse(this.textBox1.Text)).ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            char[] arr = this.textBox1.Text.ToCharArray();
            foreach(char c in arr)
            {
                this.textBox2.Text += "," + System.Convert.ToString((int)c);
            }
        }
    }
}
