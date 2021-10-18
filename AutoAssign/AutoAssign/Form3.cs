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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            _excel1 = new OperateExcel(1);
            _excel2 = new OperateExcel(2);
        }
        OperateExcel _excel1 = null;
        OperateExcel _excel2 = null;

        private void button1_Click(object sender, EventArgs e)
        {
            Listen_Socket_AnalyzeData(this.textBox1.Text);
            //string str;
            //if (!_excel1.ExcelFillinData("jiangpengsong", out str))
            //    this.richTextBox1.Text = "Excel1失败：" + str;
            //this.richTextBox1.Text = "Excel1：成功";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //string str;
            //if (!_excel2.ExcelFillinData("woshi2", out str))
            //    this.richTextBox1.Text = "Excel2失败：" + str;
            //this.richTextBox1.Text = "Excel2：成功";
        }
        private void Listen_Socket_AnalyzeData(string sData)
        {
            System.Text.RegularExpressions.Regex reg;
            System.Text.RegularExpressions.Match mc;
            string sPat1, sPat2;
            for (int i = 0; i <= 9; i++)
            {
                sPat1 = i.ToString();
                if (i == 9)
                    sPat2 = "A";
                else sPat2 = Convert.ToString(i + 1);
                
                reg = new System.Text.RegularExpressions.Regex(string.Format("{0}#.*{1}#", sPat1, sPat2), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                mc = reg.Match(sData);
                if (mc == null || mc.Value == string.Empty)
                {
                    this.ShowLogAsyn(string.Format("条码{0}:NG", i));
                }
                else
                {

                    this.ShowLogAsyn(string.Format("条码:{0}", mc.Value.Substring(2, mc.Value.Length - 4)));
                }
            }
        }
        private void ShowLogAsyn(string sMsg)
        {
            this.richTextBox1.AppendText(sMsg + "\r\n");
        }
    }
}
