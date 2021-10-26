using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuoLiuMES.MESConfig
{
    public class MkConfig
    {
        public static string MkOuptutTypeName = "模块管理";
    }
    public class BoxingConfig
    {
        public static string DefaultBoxType = string.Empty;
        public static string OuptutTypeName = "装托管理";
        public class AutoComposing
        {

            public static bool Auto = true;
            /// <summary>
            /// 延时3秒
            /// </summary>
            public static int DelaySeconds = 5;
        }
        public bool ReadInidata()
        {
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "Server.ini";
            if (!System.IO.File.Exists(strFile))
            {
                System.Windows.Forms.MessageBox.Show("配置文件Server.ini丢失。", "系统提示");
                return false;
            }
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                int iTemp;
                string str;
                float fTemp;
                //读取打印配置
                //打印机
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "PrintMachineName", string.Empty);
                if (str.Length > 0)
                    Boxing.BoxPrinter.PrinterMachineName = str;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "AutoPrintTuoPan", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.AutoPrint = iTemp == 1;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "QRSet_Left", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.QRSet_Left = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "QRSet_Top", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.QRSet_Top = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "WordsSet_Left", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.WordsSet_Left = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "WordsSet_Top", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.WordsSet_Top = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "QRSize", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.QRSize = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "FontSize", string.Empty);
                if (str.Length > 0 && float.TryParse(str, out fTemp))
                    Boxing.BoxPrinter.evFont = new Font(new FontFamily("宋体"), fTemp, FontStyle.Bold);
                str = Common.CommonFuns.ConfigINI.GetString("BoxPrinter", "WordsRN", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    Boxing.BoxPrinter.WordsRN = iTemp;

                //JpsConfig.ProcessCode = Common.CommonFuns.ConfigINI.GetString("Station", "ProcessCode", string.Empty);
                //JpsConfig.StationCode = Common.CommonFuns.ConfigINI.GetString("Station", "StationCode", string.Empty);
                //JpsConfig.MacCode = Common.CommonFuns.ConfigINI.GetString("Station", "MacCode", string.Empty);
                int iTmp;
                string strTmp = Common.CommonFuns.ConfigINI.GetString("BoxAutoComposing", "Auto", string.Empty);
                if (strTmp.Trim().Length > 0)
                    MESConfig.BoxingConfig.AutoComposing.Auto = strTmp.Trim() == "1";
                strTmp = Common.CommonFuns.ConfigINI.GetString("BoxAutoComposing", "DelaySeconds", string.Empty);
                if (strTmp.Trim().Length > 0 && int.TryParse(strTmp, out iTmp))
                    MESConfig.BoxingConfig.AutoComposing.DelaySeconds = iTmp;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("配置文件读取失败！\r\n" + ex.Message, "系统提示");
                return false;
            }
            return true;
        }
    }

}
