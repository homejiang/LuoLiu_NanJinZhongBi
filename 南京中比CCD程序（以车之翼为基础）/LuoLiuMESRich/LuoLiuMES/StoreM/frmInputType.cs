using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.StoreM
{
    public partial class frmInputType : Common.frmBaseEdit
    {
        public frmInputType()
        {
            InitializeComponent();
        }
        public string _Type;
        private void btType1_Click(object sender, EventArgs e)
        {
            _Type = "03";
            this.DialogResult = DialogResult.OK;
        }

        private void btType2_Click(object sender, EventArgs e)
        {

            _Type = "02";
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Type = "01";
            this.DialogResult = DialogResult.OK;
        }
        
    
    }
}