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
    public partial class frmScaner : Common.frmBase
    {
        frmMain1 _MainForm = null;
        public frmScaner(frmMain1 form)
        {
            InitializeComponent();
            _MainForm = form;
        }
        JPSEntity.SocketClient _Client = null;
        private void button1_Click(object sender, EventArgs e)
        {
            int iPort;
            if (!int.TryParse(this.tbPort.Text, out iPort))
            {
                this.ShowMsg("端口不正确");
                return;
            }
            _Client = new JPSEntity.SocketClient(null, 1, null);
            _Client.SocketClientReceveOrginalDataNotice += _Client_SocketClientReceveOrginalDataNotice;
            string strErr;
            if (!_Client.InitSocket(out strErr))
            {
                this.ShowMsg("client初始化出错:" + strErr);
                return;
            }
            if (!_Client.StartListenning(out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
        }

        private void _Client_SocketClientReceveOrginalDataNotice(string sData)
        {
            this.richTextBox1.AppendText(sData + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tbStop_Click(object sender, EventArgs e)
        {
            if (_Client != null) _Client.Running = false;
        }
    }
}
