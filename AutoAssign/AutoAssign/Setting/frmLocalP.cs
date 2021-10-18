using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Setting
{
    public partial class frmLocalP : Common.frmBase
    {
        public static bool ReadIP()
        {
            if (JPSConfig.LocalIP.Length == 0)
            {
                List<string> listIP = new List<string>();
                string strHostName = System.Net.Dns.GetHostName();
                if (strHostName != string.Empty)
                {
                    System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                    //注：目前只读取IP4的地址
                    foreach (System.Net.IPAddress ip in ips)
                    {

                        if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                        {
                            if (ip.ToString().Length == 0) continue;
                            listIP.Add(ip.ToString());
                        }
                    }
                }
                if (listIP.Count == 1)
                {
                    JPSConfig.LocalIP = listIP[0];//赋值
                    return true;
                }
                else
                {
                    frmLocalP frm = new frmLocalP();
                    if (DialogResult.OK != frm.ShowDialog()) return false;
                    return true;
                }
            }
            return true;
        }
        public frmLocalP()
        {
            InitializeComponent();

        }
        public override void ShowMsg(string strMsg)
        {
            this.labErr.Text = strMsg;
        }
        private void frmLocalP_Load(object sender, EventArgs e)
        {
            string strHostName = System.Net.Dns.GetHostName();
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                int iSelIndex = -1;
                foreach (System.Net.IPAddress ip in ips)
                {

                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        if (ip.ToString().Length == 0) continue;

                        int iTemp = this.comboBox1.Items.Add(ip.ToString());
                        if (string.Compare(JPSConfig.LocalIP, ip.ToString(), true) == 0)
                            iSelIndex = iTemp;
                    }
                }
                this.comboBox1.SelectedIndex = iSelIndex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex==-1)
            {
                this.ShowMsg("请选择IP地址。");
                return;
            }
            if(this.comboBox1.Text.Length==0)
            {
                this.ShowMsg("IP地址不能为空！");
                return;
            }
            JPSConfig.LocalIP = this.comboBox1.Text;
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("MacNet", "LocalIP", JPSConfig.LocalIP);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
