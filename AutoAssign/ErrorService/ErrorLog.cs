using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ErrorService
{
	#region ��¼������־
	public class ErrorLog
	{
		/// <summary>
		/// ������־�ļ�
		/// </summary>
		private static string ErrorLogFile = string.Empty;
		/// <summary>
		/// д������־
		/// </summary>
		/// <param name="e"></param>
		public static void WriteErrorLog(Exception e)
		{
            return;
			string strPath;
			StreamWriter swLog;
			StringBuilder strbContent = new StringBuilder();
			if (e == null)
				return;
			#region ���ɴ�����־·��
			if (ErrorLogFile == string.Empty)
			{
				strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
				if (!strPath.EndsWith("\\"))
					strPath += "\\";
				strPath += "ERPError.log";
				ErrorLogFile = strPath;
			}
			#endregion
			#region ���ɴ�������
			strbContent.Append("����ʱ��:" + System.DateTime.Now.ToString("F") + "\r\n");
			strbContent.Append("����Դ:" + e.Source + "\r\n");
			strbContent.Append("������Ϣ:" + e.Message);
			strbContent.Append("\r\n---------------------------------------------------\r\n");
			#endregion
			try
			{
				if (File.Exists(ErrorLogFile))
				{
					using (swLog = File.AppendText(ErrorLogFile))
					{
						swLog.Write(strbContent.ToString());	//д���ļ�����
						swLog.Close();	//�����ļ�
					}
				}
				else
				{
					using (swLog = File.CreateText(ErrorLogFile))
					{
						swLog.Write(strbContent.ToString());		//д���ļ�����
						swLog.Close(); //�����ļ�
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("�ǳ���Ǹ��ϵͳ���з�������\r\n������ͼ�Ѵ�����Ϣ��\r\n[" + strbContent.ToString() + "]\r\nд�������־ʱ���ִ���\r\n" + ex.Message, "������Ϣ", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
	#endregion
    #region ��ȡ�汾��Ϣ
    public class Version
    {
        public static string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public static string GetGuid()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attrs = ass.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            Guid id = new Guid(((System.Runtime.InteropServices.GuidAttribute)attrs[0]).Value);
            return id.ToString();
        }
        public static string GetTitle()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attributes = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);
            System.Reflection.AssemblyTitleAttribute titleAttribute = (System.Reflection.AssemblyTitleAttribute)attributes[0];
            return titleAttribute.Title;
        }
        public static string GetStrForUpdate()
        {
            return GetGuid() + "|" + GetVersion();
        }
        public static void ContainGuids(List<string> list)
        {
            if (list == null)
                list = new List<string>();
            string str = GetStrForUpdate();
            if (!list.Contains(str))
                list.Add(str);
        }
    }
    #endregion
}
