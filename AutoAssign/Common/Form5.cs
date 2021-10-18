using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iStart = int.Parse(this.tbStart.Text);
            int iEnd = int.Parse(this.tbEnd.Text);
            if (!this.checkBox1.Checked)
            {
                for (int i = iStart; i <= iEnd; i++)
                {
                    this.richTextBox1.AppendText(string.Format(this.textBox1.Text, i) + "\r\n");
                }
            }
            else
            {

                int iStart1 = int.Parse(this.tbStart1.Text);
                //int iEnd1 = int.Parse(this.tbEnd1.Text);
                for (int i = iStart; i <= iEnd; i++)
                {
                    this.richTextBox1.AppendText(string.Format(this.textBox1.Text, i, iStart1) + "\r\n");
                    iStart1++;
                }
            }
        }
    }
}
