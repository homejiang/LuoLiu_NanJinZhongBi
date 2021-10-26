using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;
using System.Data;

namespace LuoLiuEOLTest
{
    public class EOLConfig
    {
        /// <summary>
        /// 工序代码
        /// </summary>
        public static string ProcessCode = string.Empty;
        /// <summary>
        /// 工序名称
        /// </summary>
        public static string ProcessName = string.Empty;
        /// <summary>
        /// 站点代码
        /// </summary>
        public static string StationCode = string.Empty;
        /// <summary>
        /// 站点名称
        /// </summary>
        public static string StationName = string.Empty;
        /// <summary>
        /// 机台代码
        /// </summary>
        public static string MacCode = string.Empty;
        /// <summary>
        /// 机台名称
        /// </summary>
        public static string MacName = string.Empty;
        /// <summary>
        /// 获取采集文件路径
        /// </summary>
        public static string ResultDir = string.Empty;
        public class AutoComposing
        {

            public static bool Auto = true;
            /// <summary>
            /// 延时5秒
            /// </summary>
            public static int DelaySeconds = 5;
        }
        //读取配置文件
        public bool ReadConfig()
        {
            //读取配置文件
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "Config.ini";
            if (!System.IO.File.Exists(strFile))
            {
                System.Windows.Forms.MessageBox.Show("配置文件Config.ini丢失。", "系统提示");
                return false;
            }
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            string strTmp;
            try
            {
                EOLConfig.ProcessCode = Common.CommonFuns.ConfigINI.GetString("Station", "ProcessCode", string.Empty);
                EOLConfig.StationCode = Common.CommonFuns.ConfigINI.GetString("Station", "StationCode", string.Empty);
                EOLConfig.MacCode = Common.CommonFuns.ConfigINI.GetString("Station", "MacCode", string.Empty);
                EOLConfig.ResultDir = Common.CommonFuns.ConfigINI.GetString("Station", "ResultDir", string.Empty);
                int iTmp;
                strTmp = Common.CommonFuns.ConfigINI.GetString("AutoComposing", "Auto", string.Empty);
                if (strTmp.Trim().Length > 0)
                    EOLConfig.AutoComposing.Auto = strTmp.Trim() == "1";
                strTmp = Common.CommonFuns.ConfigINI.GetString("AutoComposing", "DelaySeconds", string.Empty);
                if (strTmp.Trim().Length > 0 && int.TryParse(strTmp, out iTmp))
                    EOLConfig.AutoComposing.DelaySeconds = iTmp;

            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (EOLConfig.ProcessCode.Length > 0)
            {
                if (!this.ReadProcessName()) return false;
            }
            if (EOLConfig.StationCode.Length > 0)
            {
                if (!this.ReadStationName()) return false;
            }
            if (EOLConfig.MacCode.Length > 0)
            {
                if (!this.ReadMacName()) return false;
            }
            return true;
        }
        public bool ReadProcessName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ProcessName FROM JC_Process WHERE Code='{0}'", EOLConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            EOLConfig.ProcessName = dt.Rows[0]["ProcessName"].ToString();
            return true;
        }
        public bool ReadStationName()
        {
            DataTable dt;

            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT StationName FROM JC_Station WHERE Code='{0}'", EOLConfig.StationCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            EOLConfig.StationName = dt.Rows[0]["StationName"].ToString();
            return true;
        }
        public bool ReadMacName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'", EOLConfig.MacCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            EOLConfig.MacName = dt.Rows[0]["MacName"].ToString();
            return true;
        }
    }
}
