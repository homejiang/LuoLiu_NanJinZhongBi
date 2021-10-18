using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.BasicData
{
    public partial class frmSelectMode : Common.frmBase
    {
        public frmSelectMode()
        {
            InitializeComponent();
        }
        public bool _ModeIsNeter;
        public bool _ModeIsScaner;
        public override void ShowMsg(string strMsg)
        {
            this.labErr.Text = strMsg;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(!this.radNet0.Checked && !this.radNet1.Checked)
            {
                this.ShowMsg("请选中网络版还是单机版。");
                return;
            }
            if (!this.radSN0.Checked && !this.radSN1.Checked)
            {
                this.ShowMsg("请选中扫码还是不扫码。");
                return;
            }
            //if(this.radNet1.Checked && this.radSN0.Checked)
            //{
            //    this.ShowMsg("网络版必须扫码！");
            //    return;
            //}
            this._ModeIsNeter = this.radNet1.Checked;
            this._ModeIsScaner = this.radSN1.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
