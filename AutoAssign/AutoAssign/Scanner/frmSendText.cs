using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Scanner
{
    public partial class frmSendText : Common.frmBase
    {
        public frmSendText()
        {
            InitializeComponent();
        }
        public string _SelectedText = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                this.ShowMsg("请输入要发送的文本");
                return;
            }
            this._SelectedText = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void frmSendText_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "LON";
        }
    }
}
