using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common
{
    public partial class frmMainBase : Form
    {
        public frmMainBase()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            NoneMouseWheel();
        }
        #region 禁用鼠标滚轮
        
        protected void NoneMouseWheel()
        {
            foreach (Control con in this.Controls)
            {
                if (con.GetType().ToString().ToLower() == "System.Windows.Forms.ComboBox".ToLower())
                {
                    con.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
                }
                NoneMouseWheel(con);
            }
        }
        protected void NoneMouseWheel(Control conParent)
        {
            foreach (Control con in conParent.Controls)
            {
                if (con.GetType().ToString().ToLower() == "System.Windows.Forms.ComboBox".ToLower())
                {
                    con.MouseWheel += new MouseEventHandler(combobox_MouseWheel);
                }
                NoneMouseWheel(con);
            }
        }
        protected void combobox_MouseWheel(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.HandledMouseEventArgs hme = (System.Windows.Forms.HandledMouseEventArgs)e;
            hme.Handled = true;
        }
        #endregion
        #region 系统消息提示
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示用户确认窗体
        /// </summary>
        /// <param name="sText">需要用户确认的内容</param>
        /// <returns>如果返回为tru,则用户选择了Yes表示确认通过，否则不通过</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region 异步打开错误窗口
        public void ShowErrorDialogAsyn(Exception e, string sCauseAt)
        {
            ShowErrorCallBack cb = new ShowErrorCallBack(ShowErrorDialog);
            try
            {
                this.Invoke(cb, new object[2] { e, sCauseAt });
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, sCauseAt + "(tryShowErrorDialogAsyncatch)");
            }
        }
        public void ShowErrorDialog(Exception e, string sCauseAt)
        {
            wErrorMessage.ShowErrorDialog1(this, e, sCauseAt);
        }
        public delegate void ShowErrorCallBack(Exception e, string sCauseAt);
        #endregion
        #region 打开非模态消息窗口
        public void ShowMsgRich()
        {
            ShowMsgRich("保存成功！");
        }
        /// <summary>
        /// 打开消息窗口，此窗口会自动消失
        /// </summary>
        /// <param name="sMsg">要显示的消息，注：不要超过18个汉字！</param>
        public void ShowMsgRich(string sMsg)
        {
            ShowMsgRich(sMsg, 0, 150, 0.55);
        }
        /// <summary>
        /// 打开消息窗口，此窗口会自动消失
        /// </summary>
        /// <param name="sMsg">要显示的消息，注：不要超过18个汉字！默认为：保存成功!</param>
        /// <param name="ShowTime">Opacity为100%需要停留的增加时间，单位为秒，默认增加0秒</param>
        /// <param name="CloseInterval">关闭时timer控件的频率，默认为150</param>
        /// <param name="ReduceOpacity">关闭时Opacity每次剩余的百分比，默认为0.55</param>
        public void ShowMsgRich(string sMsg, int ShowTime, int CloseInterval, double ReduceOpacity)
        {
            Msg.frmMsgRich frm = new Common.Msg.frmMsgRich();
            frm.Msg = sMsg;
            frm.ShowTime = ShowTime;
            frm.CloseTimeInterval = CloseInterval;
            frm.ReduceOpacity = ReduceOpacity;
            frm.Show();
        }
        #endregion
    }
}