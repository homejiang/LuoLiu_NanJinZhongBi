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
    public partial class frmSelectSwitchMode : Common.frmBase
    {
        public frmSelectSwitchMode()
        {
            InitializeComponent();
        }
        public JPSEnum.SwitchModes? _SelectedType = null;
        private void btSame_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.SwitchModes.普通分档;
            this.DialogResult = DialogResult.OK;
        }

        private void btDiffrent_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.SwitchModes.分AB档;
            this.DialogResult = DialogResult.OK;
        }
    }
}
