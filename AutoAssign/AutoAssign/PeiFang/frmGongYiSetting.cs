using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.PeiFang
{
    public partial class frmGongYiSetting : Common.frmBase
    {
        public frmGongYiSetting()
        {
            InitializeComponent();
        }
        public UserControls.ucMyGroove _MyGroove = null;
        private void button1_Click(object sender, EventArgs e)
        {
            this._MyGroove = this.uc1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
