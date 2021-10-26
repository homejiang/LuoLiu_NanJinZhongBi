using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.Boxing
{
    public partial class frmRemoveItem : Common.frmBase
    {
        const string ActiveTimer_INPUTITMECODE = "InputItemCode";
        #region 窗体数据连接实例
        private BLLDAL.Boxing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Boxing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Boxing();
                return _dal;
            }
        }
        #endregion
        frmBoxing _MainForm = null;
        public override void AcitiveTimer_Doing(object Arg)
        {
            if(Arg!=null && Arg.ToString()== ActiveTimer_INPUTITMECODE)
            {
                this.tbItemCode.Focus();
                this.tbItemCode.SelectAll();
            }
        }
        public frmRemoveItem(string sBoxCode,frmBoxing frm)
        {
            InitializeComponent();
            this.tbBoxCode.Text = sBoxCode;
            this.chkGoon.Checked = true;
            _MainForm = frm;
        }
        public override void ShowMsg(string strMsg)
        {
            this.labMsg.Text = strMsg;
        }
        private bool Remove()
        {
            if (this.tbItemCode.Text.Length == 0)
            {
                this.ShowMsg("请输入电池包编号 ");
                return false;
            }
            int iReturnValue;
            string strMsg;
            int iBoxedCnt;
            decimal decNet;
            try
            {
                this.BllDAL.RemoveItem(this.tbBoxCode.Text, this.tbItemCode.Text, out iBoxedCnt, out decNet, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return false;
            }
            //更新主窗体
            if (this._MainForm != null)
            {
                this._MainForm.RefreshBoxedCount(this.tbItemCode.Text,this.tbBoxCode.Text, iBoxedCnt, decNet);
            }
            return true;
        }
        private void btRemove_Click(object sender, EventArgs e)
        {
            if(!Remove())
            {
                this.AcitiveTimer(200, ActiveTimer_INPUTITMECODE);
                return;
            }
            if(this.chkGoon.Checked)
            {
                this.tbItemCode.Clear();
                this.AcitiveTimer(200, ActiveTimer_INPUTITMECODE);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmRemoveItem_Load(object sender, EventArgs e)
        {
            this.AcitiveTimer(200, ActiveTimer_INPUTITMECODE);
        }

        private void tbItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btRemove_Click(sender, null);
        }
    }
}
