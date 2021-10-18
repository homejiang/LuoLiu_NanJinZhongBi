using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Common.UserControls
{
    public partial class ucMsgShine : UserControl
    {
        public ucMsgShine()
        {
            InitializeComponent();
            this.HidenControls();
        }
        private void picClose_MouseHover(object sender, EventArgs e)
        {
            this.picClose.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picClose_MouseLeave(object sender, EventArgs e)
        {
            this.picClose.BorderStyle = BorderStyle.None;
        }
        public void ShowMsg(string sMsg)
        {
            sMsg = "´íÎó:" + sMsg;
            if (this.labMsg.Text != sMsg)
                this.labMsg.Text = sMsg;
            ShowControls();
        }
        public void ShowControls()
        {
            if (!this.Visible)
                this.Visible = true;
        }
        public void HidenControls()
        {
            if (this.Visible)
                this.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            HidenControls();
        }

        private void labMsg_DoubleClick(object sender, EventArgs e)
        {
            frmMsgShineDetail frm = new frmMsgShineDetail();
            frm.Msg = this.labMsg.Text;
            frm.Show();
        }
    }
}
