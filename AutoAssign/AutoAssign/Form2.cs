using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class Form2 : Common.frmBase
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            this.button2.Click += bt_Click;
        }
        

        private void btDel_Click(object sender, EventArgs e)
        {
            this.button2.Click -= bt_Click;
        }
        private void bt_Click(object sender, EventArgs e)
        {
            this.ShowMsg("haha");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] arr = this.tbBits.Text.ToCharArray();
            bool[] bits = new bool[arr.Length];
            for(int i=0;i<arr.Length;i++)
            {
                bits[i] = arr[i].ToString() == "1";
            }
            try
            {
                this.tbInt32.Text = JPSFuns.GetInt32ByBit(bits).ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbBits_TextChanged(object sender, EventArgs e)
        {
            if(this.tbBits.Text.Length==0)
            {
                this.tbBitsMoir.Clear();
            }
            else
            {
                this.tbBitsMoir.Text = new string(this.tbBits.Text.ToCharArray().Reverse().ToArray());
                tbBitLens.Text = this.tbBits.Text.Length.ToString();
                //this.tbBitsMoir.Text = this.tbBits.Text.Substring(this.tbBits.Text.Length - 1) + this.tbBitsMoir.Text;
            }
        }
    }
}
