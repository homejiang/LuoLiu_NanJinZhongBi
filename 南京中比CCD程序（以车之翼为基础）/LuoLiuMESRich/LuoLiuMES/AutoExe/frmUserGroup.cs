using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.AutoExe
{
    public partial class frmUserGroup : Common.frmBase
    {
        public frmUserGroup()
        {
            InitializeComponent();
        }
        public string GroupName
        {
            get { return this.tbGroup.Text; }
            set { this.tbGroup.Text = value; }
        }
        public bool Expand
        {
            get { return this.chkExpand.Checked; }
            set { this.chkExpand.Checked = value; }
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.tbGroup.Text.Trim() == string.Empty)
            {
                this.ShowMsg("名称不能为空！");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void tbGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btTrue_Click(null, null);
        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            this.tbGroup.SelectAll();
        }
    }
}