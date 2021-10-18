using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FindIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int _Index = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this._Index >= 255)
            {
                this.richTextBox1.AppendText("结束");
                return;
            }
            string strIP = string.Format("192.168.14.{0}", _Index);
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply result = p.Send(strIP);
            if(result.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                this.richTextBox1.AppendText(strIP + "\r\n");
                return;
            }
            this._Index++;
            if (this._Index == 22) this._Index++;
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
