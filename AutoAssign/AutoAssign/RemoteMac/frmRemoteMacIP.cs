using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.RemoteMac
{
    public partial class frmRemoteMacIP : Common.frmBase
    {
        public frmRemoteMacIP()
        {
            InitializeComponent();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            System.Net.IPAddress ip;
            if (this.tbLocalIP.Text.Length > 0)
            {
                if (!System.Net.IPAddress.TryParse(this.tbLocalIP.Text, out ip))
                {
                    this.ShowMsg("请正确输入本机IP地址！");
                    return;
                }
            }
            else
            {
                this.ShowMsg("本机IP地址不能为空！");
                return;
            }
            if (this.tbIP1.Text.Length > 0)
            {
                if (!System.Net.IPAddress.TryParse(this.tbIP1.Text, out ip))
                {
                    this.ShowMsg(string.Format("请正确输入{0}的IP地址！", this.labMac1.Text));
                    return;
                }
            }
            if (this.tbIP2.Text.Length > 0)
            {
                if (!System.Net.IPAddress.TryParse(this.tbIP2.Text, out ip))
                {
                    this.ShowMsg(string.Format("请正确输入{0}的IP地址！", this.labMac2.Text));
                    return;
                }
            }
            if (this.tbIP3.Text.Length > 0)
            {
                if (!System.Net.IPAddress.TryParse(this.tbIP3.Text, out ip))
                {
                    this.ShowMsg(string.Format("请正确输入{0}的IP地址！", this.labMac3.Text));
                    return;
                }
            }
            JPSConfig.LocalIP = this.tbLocalIP.Text;
            JPSConfig.RemoteMacConfig._IP1 = this.tbIP1.Text;
            JPSConfig.RemoteMacConfig._IP2 = this.tbIP2.Text;
            JPSConfig.RemoteMacConfig._IP3 = this.tbIP3.Text;
            //保存至配置文件
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("MacNet", "LocalIP", JPSConfig.LocalIP);
                Common.CommonFuns.ConfigINI.SetValue("RemoteSnCopyer", "IP1", JPSConfig.RemoteMacConfig._IP1);
                Common.CommonFuns.ConfigINI.SetValue("RemoteSnCopyer", "IP2", JPSConfig.RemoteMacConfig._IP2);
                Common.CommonFuns.ConfigINI.SetValue("RemoteSnCopyer", "IP3", JPSConfig.RemoteMacConfig._IP3);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmRemoteMacIP_Load(object sender, EventArgs e)
        {
            this.tbLocalIP.Text = JPSConfig.LocalIP;
            if(JPSConfig.MacNo==1)
            {
                this.labMac1.Text = "设备2";
                this.labMac2.Text = "设备3";
                this.labMac3.Text = "设备4";
            }
            else if (JPSConfig.MacNo == 2)
            {
                this.labMac1.Text = "设备1";
                this.labMac2.Text = "设备3";
                this.labMac3.Text = "设备4";
            }
            else if (JPSConfig.MacNo == 3)
            {
                this.labMac1.Text = "设备1";
                this.labMac2.Text = "设备2";
                this.labMac3.Text = "设备4";
            }
            else if (JPSConfig.MacNo == 4)
            {
                this.labMac1.Text = "设备1";
                this.labMac2.Text = "设备2";
                this.labMac3.Text = "设备3";
            }
            this.tbIP1.Text = JPSConfig.RemoteMacConfig._IP1;
            this.tbIP2.Text = JPSConfig.RemoteMacConfig._IP2;
            this.tbIP3.Text = JPSConfig.RemoteMacConfig._IP3;
        }
        
    }
}
