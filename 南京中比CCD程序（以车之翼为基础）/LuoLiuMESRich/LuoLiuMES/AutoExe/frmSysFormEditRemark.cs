using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysFormEditRemark : Common.frmBaseEdit
    {
        public frmSysFormEditRemark()
        {
            InitializeComponent();
        }
        public string _BodyHtml = string.Empty;
        public bool _Saved = false;
        private bool _UnSaved = false;
        private void frmSysFormEditRemark_Load(object sender, EventArgs e)
        {
            this.htmlRemark.ShowExpButton("�˳��༭(����������)");
            this.htmlRemark.ShowSaveButton = true;
            this.htmlRemark.BodyHTML = _BodyHtml;
        }

        private void htmlRemark_OnSave(HtmlElement documentBody)
        {
            _BodyHtml = this.htmlRemark.GetBodyHTML();
            _Saved = true;
            //this.DialogResult = DialogResult.OK;
        }

        private void htmlRemark_OnExpButton(HtmlElement documentBody)
        {
            if (!this.IsUserConfirm("��ȷ�������汾�α༭������")) return;
            _Saved = false;
            _UnSaved = true;
            this.Close();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_UnSaved)
            {
                if (this.htmlRemark.GetBodyHTML() != _BodyHtml)
                {
                    if (!this.IsUserConfirm("�����Ѿ��ı䣬��ȷ����������"))
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                _Saved = true;
            }
            base.OnClosing(e);
        }
    }
}