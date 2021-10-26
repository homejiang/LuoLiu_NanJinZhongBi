using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.IO;

namespace Common.WebOpen
{
    public partial class frmFindIE : Common.frmBase
    {
        public const string TYPE = "openWeb";
        public frmFindIE()
        {
            InitializeComponent();
        }
        public static bool Open()
        {
            Common.WebOpen.frmFindIE frm = new frmFindIE();
            return DialogResult.OK == frm.ShowDialog();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.tbPath.Text != string.Empty)
            {
                //校验路径是否正确
                if (!File.Exists(this.tbPath.Text))
                {
                    this.ShowMsg("文件【" + this.tbPath.Text + "】不存在！");
                    return;
                }
            }
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {
                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP = ip.ToString();
                    }
                }
            }
            if(strIP==string.Empty)
            {
                this.ShowMsg("当前IP地址获取出错！");
                return;
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(string.Format("EXEC JC_OpenExe_Save '{0}','{1}','{2}'"
                    , strIP.Replace("'", "''"), TYPE, this.tbPath.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmFindIE_Load(object sender, EventArgs e)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {
                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP = ip.ToString();
                    }
                }
            }
            this.tbIP.Text = strIP;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Common_GetIEPath('{0}','{1}')", Common.WebOpen.frmFindIE.TYPE, strIP.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
            this.tbPath.Text = dt.Rows[0][0].ToString();
        }

        private void linkSelPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.openFileDialog1.Filter = "exe文件|*.exe|所有文件|*.*";
            if (DialogResult.OK != this.openFileDialog1.ShowDialog(this)) return;
            string strFile = this.openFileDialog1.FileName;
            if (strFile == string.Empty) return;
            this.tbPath.Text = strFile;
        }
    }
}