using ErrorService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuoLiuDianHan
{
    public class Config
    {
        public static string ProcessCode = "04";
        public static string StationCode = string.Empty;
        public static string MacCode = string.Empty;
        public static string ProcessName = string.Empty;
        public static string StationName = string.Empty;
        public static string MacName = string.Empty;
        public static string GetOPCTitle
        {
            get
            {
                if (Config.MacCode == "0401") return "dianhanji.No1."; 
                if (Config.MacCode == "0402") return "dianhanji.No2.";
                if (Config.MacCode == "0403") return "dianhanji.No3.";
                if (Config.MacCode == "0404") return "dianhanji.No4.";
                return string.Empty;
            }
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
                Config.ProcessCode = Common.CommonFuns.ConfigINI.GetString("Station", "ProcessCode", string.Empty);
                Config.StationCode = Common.CommonFuns.ConfigINI.GetString("Station", "StationCode", string.Empty);
                Config.MacCode = Common.CommonFuns.ConfigINI.GetString("Station", "MacCode", string.Empty);
                strTmp = Common.CommonFuns.ConfigINI.GetString("Debug", "OPCDebug", string.Empty);
                LuoLiuDianHan.Communication.Debug.OPCDebug = strTmp == "1";
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (Config.ProcessCode.Length > 0)
            {
                if (!this.ReadProcessName()) return false;
            }
            if (Config.StationCode.Length > 0)
            {
                if (!this.ReadStationName()) return false;
            }
            if (Config.MacCode.Length > 0)
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
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ProcessName FROM JC_Process WHERE Code='{0}'", Config.ProcessCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            Config.ProcessName = dt.Rows[0]["ProcessName"].ToString();
            return true;
        }
        public bool ReadStationName()
        {
            DataTable dt;

            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT StationName FROM JC_Station WHERE Code='{0}'", Config.StationCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            Config.StationName = dt.Rows[0]["StationName"].ToString();
            return true;
        }
        public bool ReadMacName()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'", Config.MacCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            Config.MacName = dt.Rows[0]["MacName"].ToString();
            return true;
        }
    }
    public class ReadPeiFangManagerConfig
    {
        public static int ReadPIndexDelayer = 700;
        public static int SendPLCPIndexDelayer = 5;
    }
}
