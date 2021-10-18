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
    public partial class frmSelectGongYi : Common.frmBase
    {
        public frmSelectGongYi()
        {
            InitializeComponent();
        }
        public JPSEnum.GongYiTypes _SelectedType = JPSEnum.GongYiTypes.None;
        private void btSame_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.GongYiTypes.Same;
            this.DialogResult = DialogResult.OK;
        }

        private void btDiffrent_Click(object sender, EventArgs e)
        {
            this._SelectedType = JPSEnum.GongYiTypes.Deffrent;
            this.DialogResult = DialogResult.OK;
        }
    }
}
