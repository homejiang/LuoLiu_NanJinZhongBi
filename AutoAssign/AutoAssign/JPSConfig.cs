using ErrorService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAssign
{
    public class JPSConfig
    {
        /// <summary>
        /// 目前只能取1、2、3
        /// </summary>
        public static short MacNo = 1;
        public static string MacCode = "001";
        public static string MacName = "";
        public static string StationCode = "";
        public static string Scaner1_IP = "";
        public static int Scaner1_Port = 0;
        public static bool Scaner1_Terminated = true;
        public static string Scaner2_IP = "";
        public static int Scaner2_Port = 0;
        public static bool Scaner2_Terminated = true;
        public static int Scaner_TimeoutMiilSeconds = 4000;
        /// <summary>
        /// 电池信息成功写入OPC后，等待多少毫秒，重新开启监控，担心OPC写入PLC可能没那么快的，经过测试200毫秒可以
        /// </summary>
        public static int DelayerMillScdsAfterBatDataWriteIntoOPC = 200;
        /// <summary>
        /// 电芯结果数据读取完成后等待多少时间,作业和DelayerMillScdsAfterBatDataWriteIntoOPC一样，单位：毫秒
        /// </summary>
        public static int DelayerMillScdsAfterResultSaved = 300;
        /// <summary>
        /// 主界面底部状态刷新频率，单位：毫秒
        /// </summary>
        public static int TesteStatusReaderInterval = 500;
        /// <summary>
        /// 统计数据刷新频率，根据网上的说法，子线程sleep会让出CUP，这样符合我们的预期，所以系统慢的话，这个值劲量大一点
        /// </summary>
        public static int RefreshStatisticData = 5000;
        /// <summary>
        /// 上传MES数据更新的时间间隔
        /// </summary>
        public static int RefreshSendMes = 5000;
        public static int MKBuildingSleeep = 50;
        public static int MKBuildingSleeep_NoneBatCode = 300;
        /// <summary>
        /// 读取新建过程时的延时
        /// </summary>
        public static int DelayerMiilSecondsReadSysNew = 500;
        public static int DelayerMiilSecondsReadSysCompeleted = 500;
        public static int DelayerMiilSecondsReadIsReadResult = 300;
        /// <summary>
        /// 扫描枪循环扫描线程的休眠时间，单位毫秒
        /// </summary>
        public static int SocketClientSleepMillSeconds = 100;
        public static int SocketClientDelayerMillSecondsAfterNoticePLcClearBatData = 300;
        /// <summary>
        /// 前期调试可以关闭打印功能
        /// </summary>
        public static bool AutoPrintTuoPan = false;
        /// <summary>
        /// 本机IP地址
        /// </summary>
        public static string LocalIP = "";
        /// <summary>
        /// 托盘标签打印机
        /// </summary>
        public static string TuoPanPrinter = string.Empty;
        /// <summary>
        /// 校验重复项目
        /// </summary>
        public static bool CheckSNReDefine = true;
        /// <summary>
        /// 扫描枪日志是否存储至数据库
        /// </summary>
        public static bool ScannerLogSavetoDataBase = false;
        public static bool ResultLogSavetoDataBase = false;
        /// <summary>
        /// 托盘的计划数已经完成后程序循环是的延时
        /// </summary>
        public static int DelayerMillSecondesAfterTuopanPlanCompeleted = 500;
        public static int DelayerBeforReadResult = 100;
        /// <summary>
        /// 后台空闲时读取数据
        /// </summary>
        public static int DelayerRemoteSNCopySleep = 1000;

        public class RemoteMacConfig
        {
            public static string _IP1 = string.Empty;
            public static string _IP2 = string.Empty;
            public static string _IP3 = string.Empty;
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
                short iValue;
                string str;
                float fTemp;
                //扫描枪1
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner1_IP", string.Empty);
                if (str.Length > 0)
                    JPSConfig.Scaner1_IP = str;
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner1_Port", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.Scaner1_Port = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner1_Terminated", string.Empty);
                if (str.Length > 0)
                    JPSConfig.Scaner1_Terminated = str.Trim() == "1";
                //扫描枪2
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner2_IP", string.Empty);
                if (str.Length > 0)
                    JPSConfig.Scaner2_IP = str;
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner2_Port", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.Scaner2_Port = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Scanner", "Scaner2_Terminated", string.Empty);
                if (str.Length > 0)
                    JPSConfig.Scaner2_Terminated = str.Trim() == "1";
                //读取系统设置
                str = Common.CommonFuns.ConfigINI.GetString("sysSt", "StationCode", string.Empty);
                if (str.Length > 0)
                    JPSConfig.StationCode = str;
                str = Common.CommonFuns.ConfigINI.GetString("sysSt", "MacCode", string.Empty);
                if (str.Length > 0)
                    JPSConfig.MacCode = str;
                str = Common.CommonFuns.ConfigINI.GetString("sysSt", "MacNo", string.Empty);
                if (str.Length > 0 && short.TryParse(str, out iValue))
                    JPSConfig.MacNo = iValue;
                str = Common.CommonFuns.ConfigINI.GetString("Debug", "ScannerOpc", string.Empty);
                if (str.Length > 0)
                    JPSEntity.Debug.ScannerOpc.IsDebug = str.Trim() == "1";
                str = Common.CommonFuns.ConfigINI.GetString("Debug", "PLCResult", string.Empty);
                if (str.Length > 0)
                    JPSEntity.Debug.PLCResultReader.IsDebug = str.Trim() == "1";
                //读取时间配置
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval1", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.Scaner_TimeoutMiilSeconds = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval2", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.DelayerMillScdsAfterBatDataWriteIntoOPC = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval3", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.DelayerMillScdsAfterResultSaved = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval4", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.TesteStatusReaderInterval = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval5", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.RefreshStatisticData = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Interval", "Interval6", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSConfig.RefreshSendMes = iTemp;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "AutoPrintTuoPan", string.Empty);
                if (str.Length > 0)
                    JPSConfig.AutoPrintTuoPan = str.Trim() == "1";
                //远程设备拷贝
                str = Common.CommonFuns.ConfigINI.GetString("RemoteSnCopyer", "IP1", string.Empty);
                if (str.Length > 0)
                    JPSConfig.RemoteMacConfig._IP1 = str.Trim();
                str = Common.CommonFuns.ConfigINI.GetString("RemoteSnCopyer", "IP2", string.Empty);
                if (str.Length > 0)
                    JPSConfig.RemoteMacConfig._IP2 = str.Trim();
                str = Common.CommonFuns.ConfigINI.GetString("RemoteSnCopyer", "IP3", string.Empty);
                if (str.Length > 0)
                    JPSConfig.RemoteMacConfig._IP3 = str.Trim();
                //当前设备IP
                str = Common.CommonFuns.ConfigINI.GetString("MacNet", "LocalIP", string.Empty);
                if (str.Length > 0)
                    JPSConfig.LocalIP = str.Trim();

                str = Common.CommonFuns.ConfigINI.GetString("SNClear", "MaxCount", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    JPSEntity.SNClear.MaxData = iTemp;
                //读取打印配置
                //打印机
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "PrintMachineName", string.Empty);
                if (str.Length > 0)
                    AutoAssign.MyPrinter.PrinterMachineName = str;
                str = Common.CommonFuns.ConfigINI.GetString("Printer", "AutoPrintTuoPan", string.Empty);
                if (str.Length > 0 && int.TryParse(str, out iTemp))
                    AutoAssign.MyPrinter.AutoPrint = iTemp == 1;
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
                JPSConfig.MacName = JPSConfig.MacCode;
                //if(!this.BindMac(JPSConfig.MacCode))
                //{
                //    JPSConfig.MacName = JPSConfig.MacCode;
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("配置文件读取失败！\r\n" + ex.Message, "系统提示");
                return false;
            }
            return true;
        }
        private bool BindMac(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'"
                    , sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            JPSConfig.MacName = dt.Rows[0]["MacName"].ToString();
            return true;
        }
    }
    #region 当前登录用户的信息
    public class CurrentUserInfo
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        private static string _strUserCode = "";
        /// <summary>
        /// 用户名称
        /// </summary>
        private static string _strUserName = "";
        /// <summary>
        /// 部门编码
        /// </summary>
        public static string DeptCode = "";
        /// <summary>
        /// 部门名称
        /// </summary>
        public static string DeptName = "";
        
        /// <summary>
        /// 是否管理员
        /// </summary>
        public static bool IsAdmin = false;
        /// <summary>
        /// 是否为超级用户
        /// </summary>
        public static bool IsSuper = true;
        /// <summary>
        /// 注销当前登陆
        /// </summary>
        public static void Logout()
        {
            UserCode = string.Empty;
            UserName = string.Empty;
            DeptCode = string.Empty;
            DeptName = string.Empty;
            IsAdmin = false;
            IsSuper = false;
        }
        public static bool CheckLogin()
        {
            if (UserCode != string.Empty) return true;
            Login.frmLogin frmlogin = new Login.frmLogin();
            if (System.Windows.Forms.DialogResult.OK != frmlogin.ShowDialog())
                return false;
            return true;
        }
        public static string UserCode
        {
            get
            {
                return _strUserCode;
            }
            set
            {
                _strUserCode = value;
                ErrorService.ErrorUserInfo.UserCode = value;
            }
        }
        public static string UserName
        {
            get
            {
                return _strUserName;
            }
            set
            {
                _strUserName = value;
                ErrorService.ErrorUserInfo.UserName = value;
            }
        }
    }
    #endregion
}
