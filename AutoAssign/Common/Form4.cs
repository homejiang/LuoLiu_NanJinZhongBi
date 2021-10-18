using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class Form4 : Form
    {
        public static bool ChongFu(string sDxSN, string sOtherScannerText)
        {
            //sOtherScannerText的格式为“,X,X,X,X,”
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(string.Format(",{0},", sDxSN), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Match mc = reg.Match(sOtherScannerText);
            if (mc == null || String.IsNullOrEmpty(mc.Value) || mc.Value.Length == 0) return false;
            return true;
        }
        public Form4()
        {
            InitializeComponent();
        }
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9a-zA-Z#]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        private void button3_Click(object sender, EventArgs e)
        {
            reg = new System.Text.RegularExpressions.Regex(this.tbReg.Text, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.MatchCollection mcs = reg.Matches(this.rtbSource.Text);
            foreach (System.Text.RegularExpressions.Match mc in mcs)
            {
                if (mc == null || mc.Value == string.Empty)
                {
                    this.rtbResult.AppendText("无数据匹配\r\n");
                }
                else
                {
                    this.rtbResult.AppendText("哈"+mc.Value + "哦\r\n");
                }
            }
        }
        List<DateTime> ListTimes = new List<DateTime>();
        private void AddTime()
        {
            if (this.ListTimes.Count >= 20)
            {
                this.ListTimes.RemoveAt(0);
            }
            this.ListTimes.Add(DateTime.Now);
        }
        public void InitSpeed()
        {
            ListTimes = new List<DateTime>();
        }
        public double GetSpeed()
        {
            //读取速度
            if (ListTimes.Count <= 1) return 0D;
            TimeSpan ts = ListTimes[ListTimes.Count - 1] - ListTimes[0];
            double db = ts.TotalSeconds;
            double dbCount = 20D * (ListTimes.Count - 1);
            return 3600D  * dbCount / db;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.AddTime();
            this.tbReg.Text = GetSpeed().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(ChongFu(this.tbReg.Text,this.rtbSource.Text))
            {
                MessageBox.Show("重号了");
            }
            else
            {
                MessageBox.Show("OK");
            }
        }
    }
}
