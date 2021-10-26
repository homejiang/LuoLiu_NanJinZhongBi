using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuCCD
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region  读取数据库配置文件
            if (!Common.CommonDAL.ReadInifile()) return;
            #endregion
            if (Common.CommonDAL.MainProgramName == "" || string.Compare(Common.CommonDAL.MainProgramName, "LuoLiuCCD.exe", true) == 0)
                Common.CommonFuns.StartUpdate(args, Version.GetCurrentVersions());
            StartPro();
            if (Common.CommonDAL.UpdateProcessID > 0)
            {
                System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(Common.CommonDAL.UpdateProcessID);
                if (p != null)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception ex)
                    {
                        ErrorService.wErrorMessage.ShowErrorDialog(null, ex);
                    }
                    Common.CommonDAL.UpdateProcessID = -1;
                }
            }

        }
        static void StartPro()
        {
            if (!Common.CommonFuns.OneInstance.IsFirst("hangzhouchenhenLuoLiuCCDHanDevelopeBychenguiyang"))
            {
                MessageBox.Show("程序已经打开！");
                return;
            }
            CcdConfig cfg = new CcdConfig();
            if (!cfg.ReadConfig())
            {
                return;
            }
            if (CcdConfig.ProcessCode.Length == 0 || CcdConfig.StationCode.Length == 0 || CcdConfig.MacCode.Length == 0)
            {
                frmStationConfig frm = new frmStationConfig();
                if (DialogResult.OK != frm.ShowDialog()) return;
            }
            if (CcdConfig.ProcessCode.Length == 0 || CcdConfig.StationCode.Length == 0 || CcdConfig.MacCode.Length == 0)
            {
                MessageBox.Show("工序编码、站点编码、设备编号不能为空！");
                return;
            }
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            frmlogin1.Tag = "LuoLiuCCD.exe-" + Common.CommonDAL.StartArg;
            Application.Run(frmlogin1);
            if (frmlogin1.DialogResult != DialogResult.OK)
                return;
            Application.Run(new frmCCD());

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
            BasicData.Version.ContainGuids(list);
            Common.Version.ContainGuids(list);
            JpsOPC.Version.ContainGuids(list);
            ErrorService.Version.ContainGuids(list);
            MyControl.MyDataGridView.Version.ContainGuids(list);
            MyControl.MyTextBox.Version.ContainGuids(list);

        }
        public static List<Common.MyEntity.VersionEntity> GetCurrentVersions()
        {
            List<Common.MyEntity.VersionEntity> listV = new List<Common.MyEntity.VersionEntity>();
            List<string> listGuids = new List<string>();
            ContainGuids(listGuids);
            if (listGuids != null)
            {
                foreach (string str in listGuids)
                    listV.Add(new Common.MyEntity.VersionEntity(str));
            }
            return listV;
        }
    }
    #endregion
}
