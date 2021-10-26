using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.MinPanel
{
    public partial class frmProducePanel1 : frmBase
    {
        public frmProducePanel1()
        {
            InitializeComponent();
        }
        public frmMainBase _Main1 = null;
        public bool AppExitEnabled
        {
            get { return this.linkQuite.Visible; }
            set
            {
                if (this.linkQuite.Visible ^ value)
                    this.linkQuite.Visible = value;
            }
        }
        public string _Title
        {
            set
            {
                this.label1.Text = value;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._Main1 == null)
            {
                this.ShowMsg("打开失败。");
                return;
            }
            this._Main1.Visible = true;
            this.Hide();
        }

        private void frmPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            Common.CommonFuns.FormMove.ReleaseCapture();
            Common.CommonFuns.FormMove.SendMessage(this.Handle, Common.CommonFuns.FormMove.WM_SYSCOMMAND, Common.CommonFuns.FormMove.SC_MOVE + Common.CommonFuns.FormMove.HTCAPTION, 0);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Common.CommonFuns.FormMove.ReleaseCapture();
            Common.CommonFuns.FormMove.SendMessage(this.Handle, Common.CommonFuns.FormMove.WM_SYSCOMMAND, Common.CommonFuns.FormMove.SC_MOVE + Common.CommonFuns.FormMove.HTCAPTION, 0);
        }

        private void linkQuite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!this.IsUserConfirm("您确定要退出程序吗？"))
                return;
            Application.Exit();
        }
    }
}