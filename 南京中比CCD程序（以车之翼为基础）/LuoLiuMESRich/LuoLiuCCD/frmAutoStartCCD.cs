using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuCCD
{
    public partial class frmAutoStartCCD : Common.frmBase
    {
        public frmAutoStartCCD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Communication.MyCcd.AutoStartCCD = this.checkBox1.Checked;
            //写入配置文件呢
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("CCD", "AutoStart", Communication.MyCcd.AutoStartCCD ? "1" : "0");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmAutoStartCCD_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = Communication.MyCcd.AutoStartCCD;
        }
    }
}
