using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Common.UserControls
{
    public partial class frmPicView : Form
    {
        public frmPicView()
        {
            InitializeComponent();
        }
        public string _FileGuid = string.Empty;
        public string _FileExs = string.Empty;
        public string _FileName = string.Empty;
        private int _ImgWidth = 0;
        private int _ImgHeight = 0;
        private void frmPicView_Load(object sender, EventArgs e)
        {
            
            if (this._FileName != string.Empty)
                this.Text = this._FileName;
            string strFile = Common.CommonFuns.GetFilePath(this._FileGuid, this._FileExs);
            if (strFile == string.Empty)
                this.pictureBox1.Image = Common.Properties.Resources.unkown;
            else
            {
                System.Drawing.Bitmap bm = new Bitmap(strFile);
                _ImgWidth = bm.Width;
                _ImgHeight = bm.Height;
                this.pictureBox1.Width = bm.Width;
                this.pictureBox1.Height = bm.Height;
                this.pictureBox1.Image = bm;//Image.FromFile(strFile);
            }
        }
    }
}