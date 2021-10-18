using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;
namespace AutoAssign
{
    public partial class Form1 : Common.frmBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int iCount;
            if(!int.TryParse(this.tbCount.Text,out iCount))
            {
                this.ShowMsg("数量不正确");
                return;
            }
            StringBuilder sb = new StringBuilder();
            int iIndex = 0;
            string strCode;
            for(int i = 0; i < iCount; i++)
            {
                iIndex++;
                if(iIndex>1000)
                {
                    this.richTextBox1.AppendText(sb.ToString());
                    sb = new StringBuilder();
                    iIndex = 0;
                }
                strCode = i.ToString();
                while(strCode.Length<24)
                {
                    strCode = "0" + strCode;
                }
                sb.Append(strCode + "@");
            }
            if (sb.ToString().Length > 0)
                this.richTextBox1.AppendText(sb.ToString());
            this.ShowMsg("完成");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime det1 = DateTime.Now;
            for (int i = 0; i < 20; i++)
            {
                string sPattern = this.textBox1.Text;
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Match mc = reg.Match(this.richTextBox1.Text);
                //if (mc == null)
                //{
                //    this.ShowMsg("未匹配到文本");
                //    return;
                //}
                //if (mc.Value == string.Empty)
                //{
                //    this.ShowMsg("未找到文本内容");
                //    return;
                //}
            }
            DateTime det2 = DateTime.Now;
            TimeSpan ts = det2 - det1;
            this.ShowMsg(ts.TotalMilliseconds.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime det1 = DateTime.Now;
            DataTable dt;
            try
            {
                dt=Common.CommonDAL.DoSqlCommand.GetDateTable(this.richTextBox1.Text);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            int i = 0;
            StringBuilder sb = new StringBuilder();
            foreach(DataRow dr in dt.Rows)
            {
                i++;
                if(i>=2000)
                {
                    try
                    {
                        Common.CommonDAL.DoSqlCommand.DoSql(sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    sb = new StringBuilder();
                    i = 0;
                }
                sb.Append(string.Format("INSERT INTO SN2(sn) values('{0}');", dr["sn"].ToString()));
            }
            if(sb.ToString().Length>0)
            {
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(sb.ToString());
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
            }
            DateTime det2 = DateTime.Now;
            TimeSpan ts = det2 - det1;
            this.ShowMsg(ts.TotalMilliseconds.ToString());
        }
    }
}
