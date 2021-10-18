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
    public partial class frmSelectAutoMKMode : Common.frmBase
    {
        public frmSelectAutoMKMode()
        {
            InitializeComponent();
        }
        public JPSEnum.AotuMkMode _SelectedType = JPSEnum.AotuMkMode.None;
        private void btSame_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.AotuMkMode.AutoMKOnly;
            this.DialogResult = DialogResult.OK;
        }

        private void btDiffrent_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.AotuMkMode.TuoPanOnly;
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.AotuMkMode.All;
            this.DialogResult = DialogResult.OK;
        }
    }
}
