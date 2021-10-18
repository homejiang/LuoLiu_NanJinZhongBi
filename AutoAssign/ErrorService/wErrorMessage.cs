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
			frmErrorMessage.ShowDialog(owner);
		}
        public static void ShowErrorDialog1(IWin32Window owner, Exception e, string sCauseAt)
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
            string strProInfo = string.Format("����·����{0}\r\nPCName��{1}"
                , System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
                , System.Net.Dns.GetHostName());
            try
            {
                ErrorDAL.Save(strMsg, strProInfo);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}