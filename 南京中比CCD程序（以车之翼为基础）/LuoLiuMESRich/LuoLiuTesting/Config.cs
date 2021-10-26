using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;
using System.Data;

namespace LuoLiuTesting
{
    public class TestingConfig
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
        /// BOM半成品类型编码
        /// </summary>
        public static string BOMClassCode = string.Empty;
        /// <summary>
        /// BOM半成品类型名称
        /// </summary>
        public static string BOMClassName = string.Empty;
        //读取配置文件
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
                TestingConfig.ProcessCode = Common.CommonFuns.ConfigINI.GetString("Station", "ProcessCode", string.Empty);
                TestingConfig.StationCode = Common.CommonFuns.ConfigINI.GetString("Station", "StationCode", string.Empty);
                TestingConfig.MacCode = Common.CommonFuns.ConfigINI.GetString("Station", "MacCode", string.Empty);
                TestingConfig.BOMClassCode = Common.CommonFuns.ConfigINI.GetString("Station", "BOMClassCode", string.Empty);
                strTmp = Common.CommonFuns.ConfigINI.GetString("Debug", "OPCDebug", string.Empty);
                Communication.Debug.SerialPortDebug = strTmp == "1";
                strTmp = Common.CommonFuns.ConfigINI.GetString("CCD", "AutoStart", string.Empty);
                if (strTmp.Length > 0)
                    Communication.MyTesting.AutoStartCCD = strTmp == "1";
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (TestingConfig.ProcessCode.Length > 0)
            {
                if (!this.ReadProcessName()) return false;
            }
            if (TestingConfig.StationCode.Length > 0)
            {
                if (!this.ReadStationName()) return false;
            }
            if (TestingConfig.MacCode.Length > 0)
            {
                if (!this.ReadMacName()) return false;
            }
            if (TestingConfig.BOMClassCode.Length > 0)
            {
                if (!this.ReadBOMClassName()) return false;
            }
            return true;
        }
        public bool ReadProcessName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ProcessName FROM JC_Process WHERE Code='{0}'", TestingConfig.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            TestingConfig.ProcessName = dt.Rows[0]["ProcessName"].ToString();
            return true;
        }
        public bool ReadStationName()
        {
            DataTable dt;

            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT StationName FROM JC_Station WHERE Code='{0}'", TestingConfig.StationCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            TestingConfig.StationName = dt.Rows[0]["StationName"].ToString();
            return true;
        }
        public bool ReadMacName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'", TestingConfig.MacCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            TestingConfig.MacName = dt.Rows[0]["MacName"].ToString();
            return true;
        }
        public bool ReadBOMClassName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ClassName FROM BOM_Sys_ProductClass WHERE Code='{0}'", TestingConfig.BOMClassCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            TestingConfig.BOMClassName = dt.Rows[0]["ClassName"].ToString();
            return true;
        }
    }
}
