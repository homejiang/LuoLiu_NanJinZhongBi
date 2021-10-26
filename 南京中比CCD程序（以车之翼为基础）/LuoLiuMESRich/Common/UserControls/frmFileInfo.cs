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
    public partial class frmFileInfo : Common.frmBase
    {
        public frmFileInfo()
        {
            InitializeComponent();
        }
        #region 公共属性
        public string _PreViewFile = string.Empty;
        public string _OrgFile = string.Empty;
        #endregion
        private void frmFileInfo_Load(object sender, EventArgs e)
        {
            if (this._PreViewFile != string.Empty)
                pictureBox1.Image = Image.FromFile(this._PreViewFile);
            else
                pictureBox1.Image = global::Common.Properties.Resources.unkown;
            FileInfo file = new FileInfo(this._OrgFile);
            if (file == null) return;
            this.labFileName.Text = "文件名：" + file.Name;
            this.labSize.Text = "文件大小：" + Common.CommonFuns.FormatData.GetStringByDecimal(file.Length / 1024M, "########0.###") + " kb";
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this._PreViewFile == string.Empty)
            {
                this.ShowMsg("预览文件为空，这是不允许的。");
                return;
            }
            if (this._OrgFile == string.Empty)
            {
                this.ShowMsg("图片文件为空，这是不允许的。");
                return;
            }
            FileInfo file = new FileInfo(this._OrgFile);
            if (file == null)
            {
                this.ShowMsg("图片文件不存在或已被删除。");
                return;
            }
            if (file.Length > 1048576)
            {
                this.ShowMsg("对不起，上传到文件不能超过1M。");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}