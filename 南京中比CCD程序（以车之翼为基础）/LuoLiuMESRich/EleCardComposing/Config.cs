using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;
using System.Data;
using System.Drawing;

namespace EleCardComposing
{
    public class Config
    {
        public static string ComposingOutputName = "锁装记录管理";
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
        ///// <summary>
        ///// 机台代码
        ///// </summary>
        //public static string MacCode = string.Empty;
        ///// <summary>
        ///// 机台名称
        ///// </summary>
        //public static string MacName = string.Empty;
        //读取配置文件
        //读取配置文件
        public class AutoComposing
        {

            public static bool Auto = true;
            /// <summary>
            /// 延时3秒
            /// </summary>
            public static int DelaySeconds = 5;
        }
        public bool ReadConfig()
        {
            //读取配置文件
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "Config.ini";
            if (!System.IO.File.Exists(strFile))
            {
                return true;
                System.Windows.Forms.MessageBox.Show("配置文件Config.ini丢失。", "系统提示");
                return false;
            }
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            string strTmp;
            int iTemp;
            float fTemp;
            try
            {
                //打印机
                string str = Common.CommonFuns.ConfigINI.GetString("Printer", "PrintMachineName", string.Empty);
                if (str.Length > 0)
                    EleCardComposing.MyPrinter.PrinterMachineName = str;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "AutoPrintTuoPan", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    EleCardComposing.MyPrinter.AutoPrint = iTemp == 1;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "QRSet_Left", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.QRSet_Left = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "QRSet_Top", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.QRSet_Top = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "WordsSet_Left", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.WordsSet_Left = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "WordsSet_Top", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.WordsSet_Top = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "QRSize", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.QRSize = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "FontSize", string.Empty);
                if (str.Length > 0 && float.TryParse(str, out fTemp))
                    MyPrinter.evFont = new Font(new FontFamily("宋体"), fTemp, FontStyle.Bold);
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "WordsRN", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    MyPrinter.WordsRN = iTemp;
                Config.ProcessCode = Common.CommonFuns.ConfigINI.GetString("Station", "ProcessCode", string.Empty);
                Config.StationCode = Common.CommonFuns.ConfigINI.GetString("Station", "StationCode", string.Empty);
                int iTmp;
                strTmp = Common.CommonFuns.ConfigINI.GetString("AutoComposing", "Auto", string.Empty);
                if (strTmp.Trim().Length > 0)
                    Config.AutoComposing.Auto = strTmp.Trim() == "1";
                strTmp = Common.CommonFuns.ConfigINI.GetString("AutoComposing", "DelaySeconds", string.Empty);
                if (strTmp.Trim().Length > 0 && int.TryParse(strTmp, out iTmp))
                    Config.AutoComposing.DelaySeconds = iTmp;
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
            //if (Config.MacCode.Length > 0)
            //{
            //    if (!this.ReadMacName()) return false;
            //}
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
    }
}
