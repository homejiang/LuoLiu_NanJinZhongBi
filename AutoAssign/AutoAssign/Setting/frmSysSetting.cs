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
    public partial class frmSysSetting : Common.frmBase
    {
        public frmSysSetting()
        {
            InitializeComponent();
        }

        private void frmSysSetting_Load(object sender, EventArgs e)
        {
            this.numMacNo.Value = JPSConfig.MacNo;
            this.tbMacCode.Text = JPSConfig.MacCode;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.tbMacCode.Text.Length==0)
            {
                this.ShowMsg("请输入设备编码！");
                return;
            }
            JPSConfig.MacCode = this.tbMacCode.Text;
            JPSConfig.MacNo = (short)this.numMacNo.Value;
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("sysSt", "MacCode", JPSConfig.MacCode);
                Common.CommonFuns.ConfigINI.SetValue("sysSt", "MacNo", JPSConfig.MacNo.ToString());
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
