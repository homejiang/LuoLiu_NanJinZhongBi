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
    public partial class frmSelectOnOff : Common.frmBase
    {
        public frmSelectOnOff()
        {
            InitializeComponent();
        }
        public JPSEnum.OnOff _SelectedType = JPSEnum.OnOff.None;
        private void btSame_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.OnOff.On;
            this.DialogResult = DialogResult.OK;
        }

        private void btDiffrent_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.OnOff.Off;
            this.DialogResult = DialogResult.OK;
        }
    }
}
