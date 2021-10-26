using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SysSetting
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SysSetting.DeptUsers.frmSelectUser frm = new SysSetting.DeptUsers.frmSelectUser();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
        }
    }
}