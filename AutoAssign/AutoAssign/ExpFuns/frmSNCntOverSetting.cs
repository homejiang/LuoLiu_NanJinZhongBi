using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmSNCntOverSetting : Common.frmBase
    {
        public frmSNCntOverSetting()
        {
            InitializeComponent();
        }

        private void frmSNCntOverSetting_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = (JPSEntity.SNClear.MaxData/10000).ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int iValue;
            if(!int.TryParse(this.textBox1.Text,out iValue))
            {
                this.ShowMsg("请正确输入数值。");
                return;
            }
            JPSEntity.SNClear.MaxData = iValue * 10000;
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("SNClear", "MaxCount", JPSEntity.SNClear.MaxData.ToString());
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
