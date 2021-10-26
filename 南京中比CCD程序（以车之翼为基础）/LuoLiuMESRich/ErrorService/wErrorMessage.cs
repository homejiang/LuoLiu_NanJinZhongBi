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
            #region 生成错误内容
            strbContent.Append("发生时间:" + System.DateTime.Now.ToString("F") + "\r\n");
            strbContent.Append("发生位置:" + sCauseAt + "\r\n");
            strbContent.Append("错误源:" + e.Source + "\r\n");
            strbContent.Append("错误消息:" + e.Message);
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
            #region 生成错误内容
            strbContent.Append("发生时间:" + System.DateTime.Now.ToString("F") + "\r\n");
            strbContent.Append("错误源:" + e.Source + "\r\n");
            strbContent.Append("错误消息:" + e.Message);
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
            string strPcInfo = string.Format("操作员：{0}；计算机名：{1}；计算机IP:{2}"
                ,ErrorUserInfo.UserName, System.Net.Dns.GetHostName(), GetMyIP());
            string strProInfo = string.Format("程序路径：{0}\r\n计算机名：{1}\r\n计算机IP:{2}"
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
            //SaveException发送到MES系统异常中，此数据其实和上面保存的数据重复了
            if (this._ex != null)
            {
                try
                {
                    ErrorDAL.SendException(string.Format("{0}；【{1}】", this._ex.Message, strPcInfo));
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
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {

                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP += ip.ToString() + "、";
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