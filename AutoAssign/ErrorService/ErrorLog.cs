using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ErrorService
{
	#region 记录错误日志
	public class ErrorLog
	{
		/// <summary>
		/// 错误日志文件
		/// </summary>
		private static string ErrorLogFile = string.Empty;
		/// <summary>
		/// 写错误日志
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
			#region 生成错误日志路径
			if (ErrorLogFile == string.Empty)
			{
				strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
				if (!strPath.EndsWith("\\"))
					strPath += "\\";
				strPath += "ERPError.log";
				ErrorLogFile = strPath;
			}
			#endregion
			#region 生成错误内容
			strbContent.Append("发生时间:" + System.DateTime.Now.ToString("F") + "\r\n");
			strbContent.Append("错误源:" + e.Source + "\r\n");
			strbContent.Append("错误消息:" + e.Message);
			strbContent.Append("\r\n---------------------------------------------------\r\n");
			#endregion
			try
			{
				if (File.Exists(ErrorLogFile))
				{
					using (swLog = File.AppendText(ErrorLogFile))
					{
						swLog.Write(strbContent.ToString());	//写入文件内容
						swLog.Close();	//保存文件
					}
				}
				else
				{
					using (swLog = File.CreateText(ErrorLogFile))
					{
						swLog.Write(strbContent.ToString());		//写入文件内容
						swLog.Close(); //保存文件
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("非常报歉，系统运行发生错误\r\n正在试图把错误信息：\r\n[" + strbContent.ToString() + "]\r\n写入错误日志时发现错误：\r\n" + ex.Message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
	#endregion
    #region 读取版本信息
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
