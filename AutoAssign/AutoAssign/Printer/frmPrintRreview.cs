using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Printer
{
    public partial class frmPrintRreview : Common.frmBase
    {
        public frmPrintRreview()
        {
            InitializeComponent();
        }
        public Image ViewImage
        {
            set
            {
                if (this.pictureBox1.SizeMode != PictureBoxSizeMode.CenterImage)
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                this.pictureBox1.Image = value;
            }
        }
    }
}
