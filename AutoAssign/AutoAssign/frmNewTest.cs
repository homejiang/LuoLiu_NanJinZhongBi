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
    public partial class frmNewTest : Common.frmBase
    {
        public frmNewTest()
        {
            InitializeComponent();
        }
        public void ClearErr()
        {
            this.label1.Text = string.Empty;
            jpsCommand = false;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!jpsCommand)
                e.Cancel = true;
            base.OnClosing(e);
        }
        bool jpsCommand = false;
        public void MyClose()
        {
            jpsCommand = true;
            this.Close();

        }
        public void ShowErr(string sMsg)
        {
            jpsCommand = true;
            this.labNotice.ForeColor = Color.Maroon;
            this.labNotice.Text = "设备初始化出错。";
            this.label1.Text = sMsg;
        }
    }
}
