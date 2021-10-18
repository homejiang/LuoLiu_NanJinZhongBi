using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Setting
{
    public partial class frmScannerSetting : Common.frmBase
    {
        public frmScannerSetting()
        {
            InitializeComponent();
        }

        private void frmScannerSetting_Load(object sender, EventArgs e)
        {
            this.tbScanner1_IP.Text = JPSConfig.Scaner1_IP;
            this.tbScanner1_Port.Text = JPSConfig.Scaner1_Port.ToString();
            this.chkTerminated1.Checked = JPSConfig.Scaner1_Terminated;
            this.tbScanner2_IP.Text = JPSConfig.Scaner2_IP;
            this.tbScanner2_Port.Text = JPSConfig.Scaner2_Port.ToString();
            this.chkTerminated2.Checked = JPSConfig.Scaner2_Terminated;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            //校验
            IPAddress ip;
            int iPort;
            if (!this.chkTerminated1.Checked)
            {
                if(!IPAddress.TryParse(this.tbScanner1_IP.Text,out ip))
                {
                    this.ShowMsg("请正确输入扫描枪1的IP地址。");
                    return;
                }
                JPSConfig.Scaner1_IP = this.tbScanner1_IP.Text;
                if(!int.TryParse(this.tbScanner1_Port.Text,out iPort))
                {
                    this.ShowMsg("请正确输入扫描枪1的端口号。");
                    return;
                }
                JPSConfig.Scaner1_Port = iPort;
                JPSConfig.Scaner1_Terminated = false;
            }
            else
            {
                JPSConfig.Scaner1_Terminated = true;
                JPSConfig.Scaner1_IP = this.tbScanner1_IP.Text;
                if (!int.TryParse(this.tbScanner1_Port.Text, out iPort))
                {
                    iPort = 0;
                }
                JPSConfig.Scaner1_Port = iPort;
            }
            if (!this.chkTerminated2.Checked)
            {
                if (!IPAddress.TryParse(this.tbScanner2_IP.Text, out ip))
                {
                    this.ShowMsg("请正确输入扫描枪2的IP地址。");
                    return;
                }
                JPSConfig.Scaner2_IP = this.tbScanner2_IP.Text;
                if (!int.TryParse(this.tbScanner2_Port.Text, out iPort))
                {
                    this.ShowMsg("请正确输入扫描枪2的端口号。");
                    return;
                }
                JPSConfig.Scaner2_Port = iPort;
                JPSConfig.Scaner2_Terminated = false;
            }
            else
            {
                JPSConfig.Scaner2_Terminated = true;
                JPSConfig.Scaner2_IP = this.tbScanner2_IP.Text;
                if (!int.TryParse(this.tbScanner2_Port.Text, out iPort))
                {
                    iPort = 0;
                }
                JPSConfig.Scaner2_Port = iPort;
            }
            //写入配置文件
            
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner1_IP", JPSConfig.Scaner1_IP);
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner1_Port", JPSConfig.Scaner1_Port.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner1_Terminated", JPSConfig.Scaner1_Terminated ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner2_IP", JPSConfig.Scaner2_IP);
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner2_Port", JPSConfig.Scaner2_Port.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Scanner", "Scaner2_Terminated", JPSConfig.Scaner2_Terminated ? "1" : "0");
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
