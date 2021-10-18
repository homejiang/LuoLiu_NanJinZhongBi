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
        #region ����������
        
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
        #region ϵͳ��Ϣ��ʾ
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// ��ʾ�û�ȷ�ϴ���
        /// </summary>
        /// <param name="sText">��Ҫ�û�ȷ�ϵ�����</param>
        /// <returns>�������Ϊtru,���û�ѡ����Yes��ʾȷ��ͨ��������ͨ��</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region �첽�򿪴��󴰿�
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
        #region �򿪷�ģ̬��Ϣ����
        public void ShowMsgRich()
        {
            ShowMsgRich("����ɹ���");
        }
        /// <summary>
        /// ����Ϣ���ڣ��˴��ڻ��Զ���ʧ
        /// </summary>
        /// <param name="sMsg">Ҫ��ʾ����Ϣ��ע����Ҫ����18�����֣�</param>
        public void ShowMsgRich(string sMsg)
        {
            ShowMsgRich(sMsg, 0, 150, 0.55);
        }
        /// <summary>
        /// ����Ϣ���ڣ��˴��ڻ��Զ���ʧ
        /// </summary>
        /// <param name="sMsg">Ҫ��ʾ����Ϣ��ע����Ҫ����18�����֣�Ĭ��Ϊ������ɹ�!</param>
        /// <param name="ShowTime">OpacityΪ100%��Ҫͣ��������ʱ�䣬��λΪ�룬Ĭ������0��</param>
        /// <param name="CloseInterval">�ر�ʱtimer�ؼ���Ƶ�ʣ�Ĭ��Ϊ150</param>
        /// <param name="ReduceOpacity">�ر�ʱOpacityÿ��ʣ��İٷֱȣ�Ĭ��Ϊ0.55</param>
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