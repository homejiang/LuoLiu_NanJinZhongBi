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
		#region 打开错误信息窗口
		/// <summary>
		/// 打开错误信息窗口
		/// </summary>
		/// <param name="owner">窗口所有者</param>
		/// <param name="e">错误信息</param>
		public static void ShowErrorDialog(IWin32Window owner, Exception e)
		{
            if (e == null)
                return;
			StringBuilder strbContent = new StringBuilder();
			ErrorLog.WriteErrorLog(e);
			#region 生成错误内容
			strbContent.Append("发生时间:" + System.DateTime.Now.ToString("F") + "\r\n");
			strbContent.Append("错误源:" + e.Source + "\r\n");
			strbContent.Append("错误消息:" + e.Message);
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
            #region 生成错误内容
            strbContent.Append("发生时间:" + System.DateTime.Now.ToString("F") + "\r\n");
            strbContent.Append("发生位置:" + sCauseAt + "\r\n");
            strbContent.Append("错误源:" + e.Source + "\r\n");
            strbContent.Append("错误消息:" + e.Message);
            #endregion
            wErrorMessage frmErrorMessage = new wErrorMessage();
            frmErrorMessage.ErrorMessage = strbContent.ToString();
            Form frmParent = owner as Form;
            if (frmParent != null && frmParent.TopMost)
                frmErrorMessage.TopMost = true;
            frmErrorMessage.ShowDialog(owner);
        }
		#endregion
		#region 窗口属性
		/// <summary>
		/// 用于设置显示的错误信息
		/// </summary>
		public string ErrorMessage
		{
			set
			{
				this.tbErrorMessage.Text = value;
			}
		}
		#endregion
		#region 窗口事件
		private void btnSendReport_Click(object sender, EventArgs e)
		{
            string strMsg = tbErrorMessage.Text;
            if (strMsg.Length > 400)
                strMsg = strMsg.Substring(0, 400);
            string strProInfo = string.Format("程序路径：{0}\r\nPCName：{1}"
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