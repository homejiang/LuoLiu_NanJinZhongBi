using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common.UserControls
{
    public partial class frmFileRename : Common.frmBaseEdit
    {
        public frmFileRename()
        {
            InitializeComponent();
        }
        #region ��������
        public string FileName
        {
            get
            {
                return this.tbFileName.Text + this.labExtension.Text;
            }
            set
            {
                string strFileName;
                int iIndex = value.LastIndexOf('.');
                if (iIndex >= 0)
                    strFileName = value.Substring(0, iIndex);
                else strFileName = value;
                this.tbFileName.Text = strFileName;
            }
        }
        public string FileExtension
        {
            get
            {
                return this.labExtension.Text;
            }
            set
            {
                this.labExtension.Text = value;
            }
        }
        #endregion

        private void btTure_Click(object sender, EventArgs e)
        {

            string[] arr = new string[] { ".", "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
            foreach (string str in arr)
            {
                if (this.tbFileName.Text.IndexOf(str) >= 0)
                {
                    this.ShowMsg("�ļ������ܰ��������κη���֮һ:\r\n,.,\\,/,:,*,?,\",<,>,|");
                    return;
                }
            }
            if (tbFileName.Text.Length == 0)
            {
                this.ShowMsg("�ļ�������Ϊ�ա�");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
    }
}