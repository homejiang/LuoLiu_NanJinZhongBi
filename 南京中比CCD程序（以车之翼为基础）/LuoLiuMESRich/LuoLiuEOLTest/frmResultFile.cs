using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuEOLTest
{
    public partial class frmResultFile : Common.frmProduceBase
    {
        public frmResultFile()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() != DialogResult.OK) return;
            this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == string.Empty)
            {
                this.ShowMsg("请输入路径。");
                return;
            }
            if (!System.IO.Directory.Exists(this.textBox1.Text))
            {
                this.ShowMsg("您输入的文件路径不存在。");
                return;
            }
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Station", "ResultDir", this.textBox1.Text);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            EOLConfig.ResultDir = this.textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void frmResultFile_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = EOLConfig.ResultDir;
        }
    }
}
