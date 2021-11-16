using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FindIP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float f;
            if(!float.TryParse(this.textBox1.Text,out f))
            {
                this.textBox2.Text = "Error";
            }
            else
            {
                this.textBox2.Text = f.ToString("#########0.#####");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal dec;
          //  if(!decimal.TryParse(this.textBox1.Text, System.Globalization.NumberStyles.Float,,out dec))
            if (!decimal.TryParse(this.textBox1.Text, out dec))
                {
                }
        }
    }
}
