using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace ErrorService
{
	public partial class wErrorMessage : Form
	{
		public wErrorMessage()
		{
			InitializeComponent();
		}
        public Exception _ex = null;
        public bool CanbeClosed
        {
            get
            {
                return btnCancel.Visible;
            }
            set
            {
                btnCancel.Visible = value;
            }
        }
		#region �򿪴�����Ϣ����
		/// <summary>
		/// �򿪴�����Ϣ����
		/// </summary>
		/// <param name="owner">����������</param>
		/// <param name="e">������Ϣ</param>
		public static void ShowErrorDialog(IWin32Window owner, Exception e)
		{
            if (e == null)
                return;
			StringBuilder strbContent = new StringBuilder();
			ErrorLog.WriteErrorLog(e);
			#region ���ɴ�������
			strbContent.Append("����ʱ��:" + System.DateTime.Now.ToString("F") + "\r\n");
			strbContent.Append("����Դ:" + e.Source + "\r\n");
			strbContent.Append("������Ϣ:" + e.Message);
			#endregion
			wErrorMessage frmErrorMessage = new wErrorMessage();
			frmErrorMessage.ErrorMessage = strbContent.ToString();
            frmErrorMessage._ex=e;
            Form frmParent = owner as Form;
            if (frmParent != null && frmParent.TopMost)
                frmErrorMessage.TopMost = true;
			frmErrorMessage.ShowDialog(owner);
		}
        public static void ShowErrorDialog1(IWin32Window owner, Exception e,string sCauseAt)
        {
            if (e == null)
                return;
            StringBuilder strbContent = new StringBuilder();
            ErrorLog.WriteErrorLog(e);
            #region ���ɴ�������
            strbContent.Append("����ʱ��:" + System.DateTime.Now.ToString("F") + "\r\n");
            strbContent.Append("����λ��:" + sCauseAt + "\r\n");
            strbContent.Append("����Դ:" + e.Source + "\r\n");
            strbContent.Append("������Ϣ:" + e.Message);
            #endregion
            wErrorMessage frmErrorMessage = new wErrorMessage();
            frmErrorMessage.ErrorMessage = strbContent.ToString();
            frmErrorMessage._ex = e;
            Form frmParent = owner as Form;
            if (frmParent != null && frmParent.TopMost)
                frmErrorMessage.TopMost = true;
            frmErrorMessage.ShowDialog(owner);
        }
        public static void ShowErrorDialog(IWin32Window owner, Exception e,bool blCanbeClose)
        {
            if (e == null)
                return;
            StringBuilder strbContent = new StringBuilder();
            ErrorLog.WriteErrorLog(e);
            #region ���ɴ�������
            strbContent.Append("����ʱ��:" + System.DateTime.Now.ToString("F") + "\r\n");
            strbContent.Append("����Դ:" + e.Source + "\r\n");
            strbContent.Append("������Ϣ:" + e.Message);
            #endregion
            wErrorMessage frmErrorMessage = new wErrorMessage();
            frmErrorMessage.ErrorMessage = strbContent.ToString();
            frmErrorMessage.CanbeClosed = blCanbeClose;
            frmErrorMessage._ex = e;
            Form frmParent = owner as Form;
            if (frmParent != null && frmParent.TopMost)
                frmErrorMessage.TopMost = true;
            frmErrorMessage.ShowDialog(owner);
        }
        
        #endregion
        #region ��������
        /// <summary>
        /// ����������ʾ�Ĵ�����Ϣ
        /// </summary>
        public string ErrorMessage
		{
			set
			{
				this.tbErrorMessage.Text = value;
			}
		}
		#endregion
		#region �����¼�
		private void btnSendReport_Click(object sender, EventArgs e)
		{
            string strMsg = tbErrorMessage.Text;
            if (strMsg.Length > 400)
                strMsg = strMsg.Substring(0, 400);
            string strPcInfo = string.Format("����Ա��{0}�����������{1}�������IP:{2}"
                ,ErrorUserInfo.UserName, System.Net.Dns.GetHostName(), GetMyIP());
            string strProInfo = string.Format("����·����{0}\r\n���������{1}\r\n�����IP:{2}"
                 , System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                , System.Net.Dns.GetHostName(), GetMyIP());
            try
            {
                ErrorDAL.Save(strMsg, strProInfo);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex, true);
                return;
            }
            //SaveException���͵�MESϵͳ�쳣�У���������ʵ�����汣��������ظ���
            if (this._ex != null)
            {
                try
                {
                    ErrorDAL.SendException(string.Format("{0}����{1}��", this._ex.Message, strPcInfo));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex, true);
                    return;
                }
            }
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

        private void wErrorMessage_Load(object sender, EventArgs e)
        {

        }
        private string GetMyIP()
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //ע��Ŀǰֻ��ȡIP4�ĵ�ַ
                foreach (System.Net.IPAddress ip in ips)
                {

                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP += ip.ToString() + "��";
                    }
                }
                if (strIP.Length > 0) strIP = strIP.Substring(0, strIP.Length - 1);
            }
            return strIP;
        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            return;
            frmHelp frm = new frmHelp();
            frm.Show(this);
        }
	}
}