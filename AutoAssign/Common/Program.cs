using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Common
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form5());
            return;
            Common.CommonDAL.DBConnString = @"Server=.;Database=BEARING;User=sa;Password=zxp;Connect Timeout=120;";
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDoSql());
        }
    }

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
    }
}