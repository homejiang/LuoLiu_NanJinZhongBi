using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.Run(new Form4());
            //return;
            if (!Common.CommonFuns.OneInstance.IsFirst("hangzhouchenhenAutoAssignDevelopeByJiangPengsong"))
            {
                MessageBox.Show("程序已经打开！");
                return;
            }
            if (!Common.CommonDAL.ReadInifile()) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new RemoteMac.frmCopy());
            //return;
            
            JPSConfig initData = new JPSConfig();
            if (!initData.ReadInidata()) return;
            if (!Setting.frmLocalP.ReadIP())
            {
                MessageBox.Show("IP地址读取出错，程序退出！");
                return;
            }
            //Common.CommonDAL.DBConnString = @"Server=.\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;";
            //Common.CommonDAL.DBConnStringBasic = @"Server=.\JPS2008;Database=LuoLiuAssignerBasic;User=sa;Password=zxp;Connect Timeout=120;";
            Login.frmLogin frmlogin = new Login.frmLogin();
            if (DialogResult.OK != frmlogin.ShowDialog())
                return;
            //Application.Run(new Form1());return;
            //Application.Run(new PeiFang.frmPeiFangEdit()); return;
            Application.Run(new frmMain1());
           // Application.Run(new Form2());
        }

    }
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
    }
    #endregion
}
