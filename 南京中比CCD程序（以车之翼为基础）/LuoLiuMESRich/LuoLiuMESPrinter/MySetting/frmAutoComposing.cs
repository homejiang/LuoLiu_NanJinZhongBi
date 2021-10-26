using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuMESPrinter.MySetting
{
    public partial class frmAutoComposing : Common.frmBase
    {
        public frmAutoComposing()
        {
            InitializeComponent();
        }

        private void frmAutoComposing_Load(object sender, EventArgs e)
        {
            this.chkAutoComposing.Checked = JpsConfig.AutoComposing.Auto;
            this.numAutoDelayScd.Value = JpsConfig.AutoComposing.DelaySeconds;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            JpsConfig.AutoComposing.Auto = this.chkAutoComposing.Checked;
            JpsConfig.AutoComposing.DelaySeconds = (int)this.numAutoDelayScd.Value;

            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("AutoComposing", "Auto", JpsConfig.AutoComposing.Auto ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("AutoComposing", "DelaySeconds", JpsConfig.AutoComposing.DelaySeconds.ToString());
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
