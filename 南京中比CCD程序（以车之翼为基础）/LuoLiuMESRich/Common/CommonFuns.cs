using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using ErrorService;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Common
{
    public class CommonFuns
    {
        #region 读取和写入ini文件
        /// <summary>
        /// 所需的API函数
        /// </summary>
        public class INIAPI
        {
            /// <summary>
            /// 提到配置文件中指定的节
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strReturnedString"></param>
            /// <param name="nSize"></param>
            /// <param name="strFileName"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileSection")]
            public static extern int GetPrivateProfileSection(
                string strSection,
                StringBuilder strReturnedString,
                int nSize,
                string strFileName
                );
            /// <summary>
            /// 得到配置文件中的指定节下指定的字串值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="strDefault"></param>
            /// <param name="strReturnedString"></param>
            /// <param name="nSize"></param>
            /// <param name="strFileName"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
            public static extern int GetPrivateProfileString(
                string strSection,
                string strKeyName,
                string strDefault,
                StringBuilder strReturnedString,
                int nSize,
                string strFileName
                );
            /// <summary>
            /// 得到配置文件中的指定节下指定的数值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="nDefault"></param>
            /// <param name="strFileName"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileInt")]
            public static extern int GetPrivateProfileInt(
                string strSection,
                string strKeyName,
                int nDefault,
                string strFileName
                );
            /// <summary>
            /// 在指定的配置文件中增加节点
            /// </summary>
            /// <param name="lpAppName"></param>
            /// <param name="lpString"></param>
            /// <param name="lpFileName"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileSection")]
            public static extern int WritePrivateProfileSection(
                string lpAppName,
                string lpString,
                string lpFileName
                );
            /// <summary>
            /// 在指定的配置文件的指定节，关键字的值
            /// </summary>
            /// <param name="lpApplicationName"></param>
            /// <param name="lpKeyName"></param>
            /// <param name="lpString"></param>
            /// <param name="lpFileName"></param>
            /// <returns></returns>
            [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
            public static extern int WritePrivateProfileString(
                string strSection,
                string strKeyName,
                string strValue,
                string strFileName
                );
        }
        /// <summary>
        /// 写入和读取操作
        /// </summary>
        public class ConfigINI
        {
            public static string INIFileName = string.Empty;
            private static string strConfigINIFile = string.Empty;
            private static void InitConfigINIFile()
            {
                strConfigINIFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!strConfigINIFile.EndsWith("\\"))
                    strConfigINIFile += "\\";
                strConfigINIFile += INIFileName;
            }
            /// <summary>
            /// 得到指定节与Key的值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="strDefaultValue"></param>
            /// <returns></returns>
            public static string GetString(string strSection, string strKeyName, string strDefaultValue)
            {
                StringBuilder strbValue = new StringBuilder(1000);
                InitConfigINIFile();
                INIAPI.GetPrivateProfileString(strSection, strKeyName, strDefaultValue, strbValue, 1000, strConfigINIFile);
                return strbValue.ToString();
            }
            /// <summary>
            /// 得到指定节与Key的值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="iDefaultValue"></param>
            /// <returns></returns>
            public static int GetInt(string strSection, string strKeyName, int iDefaultValue)
            {
                InitConfigINIFile();
                return INIAPI.GetPrivateProfileInt(strSection, strKeyName, iDefaultValue, strConfigINIFile);
            }
            /// <summary>
            /// 得到指定节与Key的值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="bDefaultValue"></param>
            /// <returns></returns>
            public static bool GetBoolean(string strSection, string strKeyName, bool bDefaultValue)
            {
                bool bValue;
                StringBuilder strbValue = new StringBuilder(1000);
                InitConfigINIFile();
                INIAPI.GetPrivateProfileString(strSection, strKeyName, bDefaultValue.ToString(), strbValue, 1000, strConfigINIFile);
                if (!bool.TryParse(strbValue.ToString(), out bValue))
                    bValue = bDefaultValue;
                return bValue;
            }
            /// <summary>
            /// 保存指定节与Key的值
            /// </summary>
            /// <param name="strSection"></param>
            /// <param name="strKeyName"></param>
            /// <param name="strValue"></param>
            public static void SetValue(string strSection, string strKeyName, string strValue)
            {
                InitConfigINIFile();
                INIAPI.WritePrivateProfileString(strSection, strKeyName, strValue, strConfigINIFile);
            }
        }
        #endregion
        #region 防止程序多次运行
        public abstract class OneInstance
        {
            /// <summary> 
            /// 用来判断一个指定的程序是否正在运行 
            /// </summary> 
            /// <param name="appId">程序名称,长一点比较好,防止有重复</param> 
            /// <returns>如果程序是第一次运行返回True,否则返回False</returns> 
            public static bool IsFirst(string appId)
            {
                bool ret = false;
                if (OpenMutex(0x1F0001, 0, appId) == IntPtr.Zero)
                {
                    CreateMutex(IntPtr.Zero, 0, appId);
                    ret = true;
                }
                return ret;
            }
            /// <summary>
            /// 判断程序是否正在运行
            /// </summary>
            /// <param name="appId"></param>
            /// <returns></returns>
            public static bool IsRunning(string appId)
            {
                bool ret = true;
                if (OpenMutex(0x1F0001, 0, appId) == IntPtr.Zero)
                    ret = false;
                return ret;
            }
            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr OpenMutex(
                uint dwDesiredAccess,  // access 
                int bInheritHandle,    // inheritance option 
                string lpName          // object name 
                );

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr CreateMutex(
                IntPtr lpMutexAttributes,  // SD 
                int bInitialOwner,                       // initial owner 
                string lpName                            // object name 
                );
        }
        #endregion
        #region 窗口拖拽
        public class FormMove
        {
            [DllImport("user32")]
            public static extern bool ReleaseCapture();
            [DllImport("user32")]
            public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
            public const int WM_SYSCOMMAND = 0x0112;
            public const int SC_MOVE = 0Xf010;
            public const int HTCAPTION = 0x0002;
        }
        #endregion
        #region 解密和加密
        public class EncryptDecryptService
        {
            #region DEC密码
            public class DESPassword
            {
                /// <summary>
                /// DES加解密的密钥
                /// </summary>
                public static string DESKey = "8^@a)2.Y";
            }
            #endregion
            /// <summary>
            /// MD5加密服务
            /// </summary>
            /// <param name="strEncrypt">密码明文</param>
            /// <returns>密码密文</returns>
            public static string MD5Encrypt(string strEncrypt)
            {
                StringBuilder strResult = new StringBuilder(1000);
                byte[] bEncrypt;
                MD5 md5 = new MD5CryptoServiceProvider();

                strEncrypt = strEncrypt == null ? string.Empty : strEncrypt;
                bEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncrypt);
                byte[] bResult = md5.ComputeHash(bEncrypt);
                //十六进制方式输出
                foreach (byte b in bResult)
                {
                    strResult.AppendFormat("{0:X2}", b);
                }
                return strResult.ToString();
            }
            /// <summary>
            /// Base64加密
            /// </summary>
            /// <param name="strEncrypt">原始字串</param>
            /// <returns>返回Base64加密后的字串</returns>
            public static string Base64Encrypt(string strEncrypt)
            {
                string strResult = string.Empty;
                byte[] buffer;
                if (strEncrypt != null)
                {
                    buffer = System.Text.Encoding.Default.GetBytes(strEncrypt);
                    strResult = System.Convert.ToBase64String(buffer);
                }
                return strResult;
            }
            /// <summary>
            /// Base64解密
            /// </summary>
            /// <param name="strDecrypt">Base64加密后的字串</param>
            /// <returns>返回原始字串</returns>
            public static string Base64Decrypt(string strDecrypt)
            {
                string strResult = string.Empty;
                try
                {
                    byte[] buffer = System.Convert.FromBase64String(strDecrypt);
                    strResult = System.Text.Encoding.Default.GetString(buffer);
                }
                catch
                {
                    strResult = string.Empty;
                }
                return strResult;
            }
            /// <summary>
            /// DES加密
            /// </summary>
            /// <param name="strDESKey">DES密钥</param>
            /// <param name="strEncrypt">要加密的明文</param>
            /// <returns>加密后的密文</returns>
            public static string DESEncrypt(string strDESKey, string strEncrypt)
            {
                StringBuilder strResult = new StringBuilder(1000);
                //密钥
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                strEncrypt = strEncrypt == null ? string.Empty : strEncrypt;

                byte[] bEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncrypt);

                des.Key = System.Text.Encoding.UTF8.GetBytes(strDESKey);
                des.IV = System.Text.Encoding.UTF8.GetBytes(strDESKey);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(bEncrypt, 0, bEncrypt.Length);
                cs.FlushFinalBlock();
                //十六进制方式输出
                foreach (byte b in ms.ToArray())
                {
                    strResult.AppendFormat("{0:X2}", b);
                }
                return strResult.ToString();
            }
            /// <summary>
            /// DES解密
            /// </summary>
            /// <param name="strDESKey">DES密钥</param>
            /// <param name="strDecrypt">要解密的密文</param>
            /// <returns>解密后的明文</returns>
            public static string DESDecrypt(string strDESKey, string strDecrypt)
            {
                string strResult;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //把十六进制转换回字节  
                byte[] bDecrypt = new byte[strDecrypt.Length / 2];
                try
                {
                    for (int i = 0; i < strDecrypt.Length / 2; i++)
                    {
                        int iResult = Convert.ToInt32(strDecrypt.Substring(i * 2, 2), 16);
                        bDecrypt[i] = (byte)iResult;
                    }
                }
                catch (Exception)
                {
                    return string.Empty;
                }

                des.Key = System.Text.Encoding.UTF8.GetBytes(strDESKey);
                des.IV = System.Text.Encoding.UTF8.GetBytes(strDESKey);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(bDecrypt, 0, bDecrypt.Length);
                try
                {
                    cs.FlushFinalBlock();
                }
                catch (Exception)
                {
                }
                strResult = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                return strResult;
            }
        }
        #endregion
        #region 转换函数
        public class FormatData
        {
            #region 将日期转换成字符窜
            /// <summary>
            /// 以yyyy-MM-dd形式格式化日期
            /// </summary>
            /// <param name="objDatetime"></param>
            /// <returns></returns>
            public static string GetStringByDateTime(object objDatetime)
            {
                return GetStringByDateTime(objDatetime, "yyyy-MM-dd");
            }
            /// <summary>
            /// 自定义格式化日期
            /// </summary>
            /// <param name="objDatetime">时间值</param>
            /// <param name="strFormat">日期格式化掩码</param>
            /// <returns></returns>
            public static string GetStringByDateTime(object objDatetime, string strFormat)
            {
                if (objDatetime == null || objDatetime.Equals(DBNull.Value))
                    return string.Empty;
                DateTime det;
                if (!DateTime.TryParse(objDatetime.ToString(), out det))
                    return string.Empty;
                return det.ToString(strFormat);
            }
            #endregion
            #region 获取Combobox列表Item集合
            public static List<Common.MyEntity.ComboBoxItem> GetComboBoxItemList(DataTable dtSource, string strDisplayMember, string strValueMember)
            {
                List<Common.MyEntity.ComboBoxItem> list = new List<Common.MyEntity.ComboBoxItem>();
                foreach (DataRowView drv in dtSource.DefaultView)
                {
                    Common.MyEntity.ComboBoxItem item = new Common.MyEntity.ComboBoxItem();
                    if (!String.IsNullOrEmpty(strDisplayMember))
                        item.Text = drv.Row[strDisplayMember].ToString();
                    if (!String.IsNullOrEmpty(strValueMember))
                        item.Value = drv.Row[strValueMember];
                    list.Add(item);
                }
                return list;
            }
            #endregion
            #region 设置和获取Combobox值
            /// <summary>
            /// 绑定ComboBox控件值
            /// </summary>
            /// <param name="control"></param>
            /// <param name="strText"></param>
            /// <param name="isAddNew"></param>
            public static void SetComboBoxText(System.Windows.Forms.ComboBox control, string strText, bool isAddNew)
            {
                if (control.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDownList)
                {
                    for (int i = 0; i < control.Items.Count; i++)
                    {
                        if (strText == control.Items[i].ToString())
                        {
                            control.SelectedIndex = i;
                            return;
                        }
                    }
                    if (isAddNew)
                        control.SelectedIndex = control.Items.Add(strText);
                }
                else
                    control.Text = strText;
            }
            /// <summary>
            /// 设置combobox值
            /// </summary>
            /// <param name="control">combobox控件</param>
            /// <param name="item"> Common.MyEntity.ComboBoxItem或其派生类</param>
            /// <param name="iType">复制方式0为value,1为text</param>
            public static void SetComboBoxText(System.Windows.Forms.ComboBox control, Common.MyEntity.ComboBoxItem item, int iType)
            {
                for (int i = 0; i < control.Items.Count; i++)
                {
                    Common.MyEntity.ComboBoxItem temp = control.Items[i] as Common.MyEntity.ComboBoxItem;
                    if (temp != null)
                    {
                        if (iType == 0)
                        {
                            //此时根据Value来判断
                            if (temp.Value != null && item.Value != null && temp.Value.ToString() == item.Value.ToString())
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }
                        else if (iType == 1)
                        {
                            //此时根据Text来判断
                            if (temp.Text == item.Text)
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }

                    }
                }
                control.SelectedIndex = -1;
            }
            public static void SetComboBoxText(System.Windows.Forms.ComboBox control, string str, int iType)
            {
                for (int i = 0; i < control.Items.Count; i++)
                {
                    Common.MyEntity.ComboBoxItem temp = control.Items[i] as Common.MyEntity.ComboBoxItem;
                    if (temp != null)
                    {
                        if (iType == 0)
                        {
                            //此时根据Value来判断
                            if (temp.Value != null  && temp.Value.ToString() == str)
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }
                        else if (iType == 1)
                        {
                            //此时根据Text来判断
                            if (temp.Text == str)
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }

                    }
                }
                control.SelectedIndex = -1;
            }
            /// <summary>
            /// 如果为空的则返回DBNull
            /// </summary>
            /// <param name="combox"></param>
            /// <returns></returns>
            public static object GetComboBoxValue(System.Windows.Forms.ComboBox combox)
            {
                if (combox.SelectedItem == null) return DBNull.Value;
                Common.MyEntity.ComboBoxItem item = combox.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item == null || item.Value == null) return DBNull.Value;
                return item.Value;
            }
            #endregion
            #region 按顺序读取值
            public static string GetStringByOrder(string str1, string str2)
            {
                return GetStringByOrder(str1, str2, string.Empty, string.Empty);
            }
            public static string GetStringByOrder(string str1, string str2, string str3)
            {
                return GetStringByOrder(str1, str2, str3, string.Empty);
            }
            /// <summary>
            /// 按顺序返回一个不为空的值
            /// </summary>
            /// <param name="str1">第1个值</param>
            /// <param name="str2">第2个值</param>
            /// <param name="str3">第3个值</param>
            /// <param name="str4">第4个值</param>
            /// <returns>参数中不为空的值</returns>
            public static string GetStringByOrder(string str1, string str2, string str3,string str4)
            {
                if (str1.Length > 0) return str1;
                if (str2.Length > 0) return str2;
                if (str3.Length > 0) return str3;
                if (str4.Length > 0) return str4;
                return string.Empty;
            }
            #endregion
            #region 将数值值根据小数位数获取相应字符窜值
            /// <summary>
            ///  将数值转换成相应字符窜
            /// </summary>
            /// <param name="objDecimal">数值</param>
            /// <param name="iCount">小数后几位</param>
            /// <returns>数值格式化后的字符窜</returns>
            public static string GetStringByDecimal(object objDecimal,int iCount)
            {
                if (objDecimal == null) return string.Empty;
                if (objDecimal.Equals(DBNull.Value)) return string.Empty;
                decimal dec;
                if (!decimal.TryParse(objDecimal.ToString(), out dec))
                    return string.Empty;
                string strFormat="##########0";
                if(iCount>0)
                {
                    strFormat+=".";
                    for(int i=0;i<iCount;i++)
                    {
                        strFormat+="#";
                    }
                }
                return GetStringByDecimal(objDecimal, strFormat);
            }
            public static string GetStringByDecimal(object objDecimal, string strFormat)
            {
                if (objDecimal == null) return string.Empty;
                if (objDecimal.Equals(DBNull.Value)) return string.Empty;
                decimal dec;
                if (!decimal.TryParse(objDecimal.ToString(), out dec))
                    return string.Empty;
                return dec.ToString(strFormat);
            }
            #endregion
            #region 获取当前班次起始时间
            public static DateTime GetCurBanciStartTime()
            {
                int itime;
                itime = int.Parse(DateTime.Now.ToString("HHmm"));
                if (itime <= 830)
                    return DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 08:30");
                if (itime > 2030)
                    return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 20:30");
                return DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 08:30");
            }
            #endregion
            #region 获取时间差以文字描述的形式返回
            /// <summary>
            /// 此函数返回形式更具时间间隔的不同而不同，5分钟以内：n分钟n秒前，以上只显示n分钟前，10小时以上，只显示n小时前
            /// </summary>
            /// <param name="detAgo">较早的时间点</param>
            /// <param name="detNow">较晚的时间点</param>
            /// <returns></returns>
            public static string GetHowLongAgo1(DateTime detAgo, DateTime detNow)
            {
                TimeSpan ts = detNow - detAgo;
                int iSec = (int)ts.TotalSeconds;//小时部分不用取，没必要精确到毫秒
                if (iSec < 0) return "时间差为负";
                string sText;
                if (iSec == 0) sText = "<0秒前";
                else if (iSec < 60) sText = iSec.ToString() + "秒前";
                else
                {
                    int iM = iSec / 60;
                    if (iM >= 5)
                    {
                        //如果超过5分钟的话一律不显示秒
                        if (iM < 60) sText = iM.ToString() + "分钟前";
                        else
                        {
                            int iH = iM / 60;
                            //超过10小时，仅显示小时部分就可以了
                            if (iH >= 10) sText = iH.ToString() + "小时前";
                            else
                            {
                                sText = string.Format("{0}小时{1}分钟前", iH, iM % 60);
                            }
                        }
                    }
                    else
                    {
                        //5分钟以内要显示秒
                        sText = string.Format("{0}分钟{1}秒前", iM, iSec % 60);
                    }
                }
                return sText;
            }
            #endregion
            #region 转换成数值
            public static bool GetDecimalFromString(string sValue,out decimal decResult,out string sErr)
            {
                decResult = 0M;
                sErr = "";
                if (sValue.Contains("E") || sValue.Contains("e"))
                {
                    //此时应该是科学计数法
                    if(!decimal.TryParse(sValue, System.Globalization.NumberStyles.Float,null, out decResult))
                    {
                        sErr = string.Format("[{0}]不是有效的数值。", sValue);
                        return false;
                    }
                    return true;
                }
                else
                {
                    if (!decimal.TryParse(sValue, out decResult))
                    {
                        sErr = string.Format("[{0}]不是有效的数值。", sValue);
                        return false;
                    }
                    return true;
                }
            }
            public static bool GetDateTimeFromString(string sValue, out DateTime detTime, out string sErr)
            {
                sErr = "";
                if (!DateTime.TryParse(sValue, out detTime))
                {
                    sErr = string.Format("[{0}]不是有效的时间。", sValue);
                    return false;
                }
                return true;
            }
            public static bool GetBoolenFromString(string sValue, out bool blValue, out string sErr)
            {
                sErr = "";
                if (!bool.TryParse(sValue, out blValue))
                {
                    //因为c#只认True或者false
                    if (sValue == "1")
                    {
                        blValue = true;
                        return true;
                    }
                    else if (sValue == "0")
                    {
                        blValue = false;
                        return true;
                    }
                    sErr = string.Format("[{0}]不是有效的布尔值。", sValue);
                    return false;
                }
                return true;
            }

            #endregion

        }
        #endregion
        #region 获取服务器当前时间
        /// <summary>
        /// 获取服务器当前时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns>获取是否成功</returns>
        public static bool GetSysCurrentDateTime(out DateTime time)
        {
            System.Data.DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT Getdate() AS CurrentTime");
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(null, ex);
                time = DateTime.MinValue;
                return false;
            }
            time = (DateTime)dt.Rows[0]["CurrentTime"];
            return true;
        }
        public static bool GetSysCurrentDateTime(out DateTime time,out string sErrMsg)
        {
            time = DateTime.MinValue;
            sErrMsg = string.Empty;
            System.Data.DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT Getdate() AS CurrentTime");
            }
            catch (Exception ex)
            {
                sErrMsg = ex.Message;
                return false;
            }
            time = (DateTime)dt.Rows[0]["CurrentTime"];
            return true;
        }
        #endregion
        #region 字符窜正则校验
        public class StringRegexCheck
        {
            /// <summary>
            /// 正则校验传入的是否为标准的颜色十六进制格式，？？？？？未编写完成
            /// </summary>
            /// <param name="strHex">颜色十六进制字符窜</param>
            /// <returns>如果符合则返回真</returns>
            public static bool CheckIsColorHexString(string strHex)
            {
                if (strHex.Length == 0) return false;
                //正则校验
                return true;
            }
            /// <summary>
            /// 校验字符窜是否被包含，即sSource中是否包含sText
            /// </summary>
            /// <param name="sSource"></param>
            /// <param name="sText"></param>
            /// <param name="ignoreCase">是否忽略大小写</param>
            /// <returns>如果sSource包含了sText，则返回真</returns>
            public static bool CheckIsContainString(string sSource, string sText, bool ignoreCase)
            {
                sSource = sSource.ToLower();
                sText = sText.ToLower();
                return sSource.IndexOf(sText) >= 0;
                //System.Text.RegularExpressions.Regex reg;
                //if (ignoreCase)
                //    reg = new System.Text.RegularExpressions.Regex(sText, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //else
                //    reg = new System.Text.RegularExpressions.Regex(sText, System.Text.RegularExpressions.RegexOptions.None);
                //return reg.IsMatch(sSource);
            }
        }
        #endregion
        #region 获取文本框对应数据库值
        /// <summary>
        /// 获取TextBox对应数据库的值
        /// </summary>
        /// <param name="text">制定textbox控件</param>
        /// <returns>如果为空返回DBNull.Value,负责返回文本值</returns>
        public static object GetTextBoxValue(System.Windows.Forms.TextBox text)
        {
            if (text.Text.Length == 0) return DBNull.Value;
            return text.Text;
        }
        #endregion
        #region 导出Excel文件
        public static bool OutputExcel(System.Windows.Forms.IWin32Window owner,string sModuleFile, string sDefaultFileName, object[] arrObj)
        {
            if (sModuleFile.Length == 0) return false;
            //string strFile = ZSFiberManage.ZsFiberMComm.ZSFiberManageConfig.Produce_OutputDetail;
            while (sModuleFile.StartsWith("\\"))
                sModuleFile = sModuleFile.Substring(1);
            if (!System.IO.File.Exists(sModuleFile))
            {
                System.Windows.Forms.MessageBox.Show("模板文件\"" + sModuleFile + "\"不存在");
                return false;
            }
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "Excel文件(*.xls)|*.xls";
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".xls";
            if (sDefaultFileName.Length == 0)
                sDefaultFileName = "导出文件.xls";
            dialog.FileName =  sDefaultFileName;
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(owner))
                return false;
            if (dialog.FileName == string.Empty)
            {
                //System.Windows.Forms.MessageBox.Show("请选择要保存的文件名");
                return false;
            }
            object objReturnValue;
            Common.OperatExcel cls = new Common.OperatExcel();
            try
            {
                cls.OutputExcelByMacro(sModuleFile, dialog.FileName, "ExcelReport", arrObj, out objReturnValue, false);
                cls.ExcelOpen(dialog.FileName, false);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(owner, ex);
                return false;
            }
            return true;
        }
        public static string GetReportHtmlByExcel(System.Windows.Forms.IWin32Window owner,string sTargetDir,string sReportName, string sModuleFile,object[] arrObj)
        {
            /***********
             * html文件路径:sTargetDir→报表名称→报表名称.htm
             * 生产前先要检索窗体Guid下文件夹“报表名称”是否存在，如果存在则移除里面的文件，然后生成html文件
             * sTargetDir:传入的存放目录
             ***********/
            if (sModuleFile.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("请传入模板文件名。");
                return string.Empty;
            }
            while (sModuleFile.StartsWith("\\"))
                sModuleFile = sModuleFile.Substring(1);
            if (!System.IO.File.Exists(sModuleFile))
            {
                System.Windows.Forms.MessageBox.Show("模板文件\"" + sModuleFile + "\"不存在");
                return string.Empty;
            }
            if (!sTargetDir.EndsWith("\\"))
                sTargetDir += "\\";
            string strDir = sTargetDir + sReportName;
            try
            {
                if (!Directory.Exists(strDir))
                    Directory.CreateDirectory(strDir);
                else
                {
                    //删除此文件夹下的文件
                    DirectoryInfo folder = new DirectoryInfo(strDir);
                    DirectoryInfo[] tempfolders = folder.GetDirectories();
                    for (int i = tempfolders.Length; i > 0; i--)
                    {
                        tempfolders[i - 1].Delete(true);
                    }
                    FileInfo[] tempfiles = folder.GetFiles();
                    for (int i = tempfiles.Length; i > 0; i--)
                    {
                        tempfiles[i - 1].Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(owner, ex);
                return string.Empty;
            }
            strDir += "\\" + sReportName + ".html";
            object objReturnValue;
            Common.OperatExcel cls = new Common.OperatExcel();
            try
            {
                cls.OutputExcelByMacro(sModuleFile, strDir, Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml, "ExcelReport", arrObj, out objReturnValue, false);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(owner, ex);
                return string.Empty;
            }
            return strDir;
        }
        #endregion
        #region 获取半成品最小长度
        /// <summary>
        /// 获取传入半成品的最小长度，单位为米
        /// </summary>
        /// <param name="sSFGClassCode">半成品类别，调用值：BOMManage.BOMEntitys.SysDefaultValues.SysBOMProductClass的静态变量成员</param>
        /// <param name="decLen"></param>
        /// <returns>返回是否成功获取了最小值</returns>
        public static bool GetSFGMinLen(string sSFGClassCode, out decimal decLen)
        {
            decLen = 0M;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Quantity FROM JC_SFGMinLen WHERE SFGClassCode='{0}'", sSFGClassCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            if (dt.Rows[0]["Quantity"].Equals(DBNull.Value)) return false;
            decLen= (decimal)dt.Rows[0]["Quantity"];
            return true;
        }
        #endregion
        #region OTDR7275公共类
        public class OTDR7275
        {
            public void WriteExpFiberLen(decimal decLen)
            {
                try
                {
                    DateTime detSer;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                    {
                        Exception ex = new Exception("服务器获取时间失败！");
                        throw (ex);
                    }
                    Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\CableERP\\OTDR7275",true);
                    if (reg == null)
                    {
                        reg = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\CableERP\\OTDR7275");
                    }
                    reg.SetValue("ExpFierLen", decLen);
                    reg.SetValue("ExpFierSetTime", detSer.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public decimal GetExpFiberLen()
            {
                try
                {
                    Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\CableERP\\OTDR7275");
                    if (reg == null)
                    {
                        return 0M;
                    }
                    decimal dec;
                    object obj = reg.GetValue("ExpFierLen");
                    if (obj == null || !decimal.TryParse(obj.ToString(), out dec))
                        return 0M;
                    return dec;
                }
                catch (Exception ex)
                {
                   throw(ex);
                }
            }
            public bool GetExpFiberSetTime(out DateTime detSetTime)
            {
                detSetTime = DateTime.MinValue;
                try
                {
                    Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\CableERP\\OTDR7275");
                    if (reg == null)
                    {
                        return false;
                    }
                    object obj = reg.GetValue("ExpFierSetTime");
                    if (obj == null || !DateTime.TryParse(obj.ToString(), out detSetTime))
                    {
                        Exception ex = new Exception("尾纤登记时间获取失败！");
                        throw (ex);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public bool GetExpFiberSetTimeHours(out decimal decHours)
            {
                decHours = 0M;
                DateTime detSer, detSetTime;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer)) return false;
                try
                {
                    this.GetExpFiberSetTime(out detSetTime);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(null,ex);
                    return false;
                }
                TimeSpan ts = detSer - detSetTime;
                decHours = (decimal)ts.TotalHours;
                return true;
            }
        }
        #endregion
        #region 提取<></>格式字符窜
        public static string GetTextFromXml(string strSource, string strNode)
        {
            if (strNode == string.Empty) return string.Empty;
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(string.Format("<{0}>.*?</{0}>", strNode), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string strText;
            System.Text.RegularExpressions.Match mc = reg.Match(strSource);
            if (mc == null || mc.Value == string.Empty)
                return string.Empty;
            strText = mc.Value;
            //截取数据
            return strText.Substring(strNode.Length + 2, strText.Length - 2 * (strNode.Length + 2) - 1);
        }
        #endregion
        #region 打开帮助窗体
        public static void SysHelp()
        {
            Common.SystemHelp.frmHelp frm = new Common.SystemHelp.frmHelp();
            frm.Show();
        }
        #endregion
        #region 运行更新程序
        public static void StartUpdate(string[] args, List<Common.MyEntity.VersionEntity> listVersion)
        {
            StartUpdate(args, listVersion, false);
        }
        public static void StartUpdate(string[] args,List<Common.MyEntity.VersionEntity> listVersion,bool blAutoKill)
        {
            //校验更新文件
            string strUpdateExe = Update.frmCheckUpdate.CheckUpdateExe();
            if (strUpdateExe.Length == 0)
                strUpdateExe = "update.exe";
            string strArgs = string.Empty;
            string strOrgArgs = string.Empty;
            if (args.Length > 0)
            {
                foreach (string str in args)
                {
                    strArgs += str;
                }
            }
            if (strArgs.Length > 0 && strArgs.ToLower().IndexOf("<UpdateProcessID>".ToLower()) >= 0 && strArgs.ToLower().IndexOf("</UpdateProcessID>".ToLower()) > 0)
            {
                strArgs = GetTextFromXml(strArgs, "UpdateProcessID");
                int iUpdateProId;
                if (int.TryParse(strArgs, out iUpdateProId))
                {
                    CommonDAL.UpdateProcessID = iUpdateProId;
                    return;
                }
            }
            else if (strArgs.Length > 0) strOrgArgs = strArgs;
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += strUpdateExe;
            if (!System.IO.File.Exists(strFile))
            {
                return;
            }
            string strGuids=string.Empty;
            foreach(Common.MyEntity.VersionEntity entity in listVersion)
            {
                strGuids+=entity.Guid+"|"+entity.Version+"@";
            }
            if(strGuids.Length>0)
                strGuids="@"+strGuids;
            System.Diagnostics.Process p = System.Diagnostics.Process.GetCurrentProcess();
            string strArg = string.Format("<MainProcessID>{0}</MainProcessID><MainFilePath>{1}</MainFilePath><Guids>{2}</Guids><AutoKill>{3}</AutoKill>"
                , p.Id.ToString(), p.MainModule.FileName, strGuids, blAutoKill ? "1" : "0");
            if (strOrgArgs.Length > 0)
            {
                strArg += string.Format("<OriginalArgs>{0}</OriginalArgs>", strOrgArgs);//存储原始参数，此内容针对类似PK8000调用程序并执行更新的情况，必须要能重新打开编辑窗口
            }
            while(strArg.IndexOf(" ")>=0)
            {
                strArg = strArg.Replace(" ", "[blank]");
            }
            try
            {
                if (Common.CommonDAL.UpdateProcessID > 0)
                {
                    //如果之前已经存在一个更新进程，则将其结束
                    System.Diagnostics.Process orgP = System.Diagnostics.Process.GetProcessById(Common.CommonDAL.UpdateProcessID);
                    if (orgP != null)
                        orgP.Kill();
                }
                Common.CommonDAL.UpdateProcessID = System.Diagnostics.Process.Start(strFile, strArg).Id;
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
        }
        #endregion
        #region 获取机台编号
        public static string GetMacSign(string sMac)
        {
            if (sMac == string.Empty) return string.Empty;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.JC_MacBreakdown_GetMacSign('{0}')", sMac.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            return dt.Rows[0][0].ToString();
        }
        #endregion
        #region 校验打印机是否有效
        public static bool CheckPrinter(string sPrinter)
        {
            return CheckPrinter(sPrinter, true);
        }
        public static bool CheckPrinter(string sPrinter,bool blAlert)
        {
            foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (string.Compare(sPrinter, s, true) == 0) return true;
            }
            if (blAlert)
                System.Windows.Forms.MessageBox.Show("打印机\""+sPrinter+"\"不存在。", "消息提示");
            return false;
        }
        #endregion
        #region 存储导出或打印所需脚本，并返回一个GUID
        public static string SaveSqlText(string sSql)
        {
            sSql = sSql.Replace("'", "''");
            string strGuid = Guid.NewGuid().ToString();
            string strSql = string.Format("INSERT INTO ExcelMacro_SqlText(GUID,SqlText) VALUES('{0}','{1}')", strGuid, sSql);
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            return strGuid;
        }
        #endregion
        #region 获取DataGridView选中行
        public static List<int> GetSelectedRows(System.Windows.Forms.DataGridView dgv)
        {
            List<int> _list = new List<int>();
            //返回选中行，从小到大的排列顺序
            if (dgv.SelectedRows.Count == 0) return _list;
            if (dgv.SelectedRows.Count == 1)
                _list.Add(dgv.SelectedRows[0].Index);
            else
            {
                if (dgv.SelectedRows[0].Index < dgv.SelectedRows[1].Index)
                {
                    for (int i = 0; i < dgv.SelectedRows.Count; i++)
                    {
                        _list.Add(dgv.SelectedRows[i].Index);
                    }
                }
                else
                {
                    for (int i = dgv.SelectedRows.Count; i > 0; i--)
                    {
                        _list.Add(dgv.SelectedRows[i - 1].Index);
                    }
                }
            }
            return _list;
        }
        #endregion
        #region 导出列表为excel文件
        public static bool DataGridViewToExcel(System.Windows.Forms.DataGridView dgv, string strFileName)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = false;
            dlg.Title = "保存为Excel文件";
            dlg.FileName = strFileName;
            bool blOk = false;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                blOk = true;
                System.IO.Stream myStream;
                myStream = dlg.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string columnTitle = "";
                try
                {
                    //写入列标题   
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (!dgv.Columns[i].Visible) continue;
                        columnTitle += dgv.Columns[i].HeaderText + "\t";
                    }
                    sw.WriteLine(columnTitle);
                    //写入列内容   
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        string columnValue = "";
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (!dgv.Columns[k].Visible) continue;
                            if (dgv.Rows[j].Cells[k].Value == null)
                                columnValue += "\t";
                            else
                                columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim() + "\t";
                        }
                        sw.WriteLine(columnValue);
                    }
                    sw.Close();
                    myStream.Close();
                }
                catch (Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                    blOk = false;
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
            return blOk;
        }
        #endregion
        #region 处理文本
        public static void AddRichTexBoxText(string strText,System.Windows.Forms.RichTextBox rtb)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"<#\w\w\w\w\w\w>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.MatchCollection matchs = reg.Matches(strText);
            string strColor;
            string strWords;
            int iIndex1, iIndex2;
            int iIndex3 = -1;
            int itextLen;
            iIndex1 = 0;
            foreach (System.Text.RegularExpressions.Match mc in matchs)
            {
                strColor = CommonFuns.GetCorlorHex(mc.Value);
                iIndex2 = mc.Index;
                iIndex3 = strText.IndexOf("</#" + strColor + ">", iIndex2);
                if (iIndex2 > 0 && iIndex2 > iIndex1)
                    rtb.AppendText(strText.Substring(iIndex1, iIndex2 - iIndex1));
                strWords = strText.Substring(iIndex2 + 9, iIndex3 - iIndex2 - 9);
                itextLen = rtb.Text.Length;
                rtb.AppendText(strWords);
                rtb.Select(itextLen, strWords.Length);
                rtb.SelectionColor = System.Drawing.ColorTranslator.FromHtml("#" + strColor);
                rtb.Select(itextLen + strWords.Length, 0);
                rtb.SelectionColor = System.Drawing.Color.Black;
                iIndex1 = iIndex3 + 10;
            }
            if (iIndex3 > 0 && strText.Length > (iIndex3 + 10))
            {
                rtb.AppendText(strText.Substring(iIndex3 + 10));
            }
            else if (iIndex3 == -1)
                rtb.AppendText(strText);
        }
        private static string GetCorlorHex(string stext)
        {
            return stext.Substring(2, 6);
        }
        #endregion
        #region 检测完成时校验是否已经提交过，否则不允许保存
        public static void SFGTestingIsCompeleted(string sSFGCode,string sProcessCode, out string strMsg, out int iReturn)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnString == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[Common_Testing_CheckIsCompeleted]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@SFGCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sSFGCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProcessCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sProcessCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserName";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
                    sqlTrain.Commit();
                else
                    sqlTrain.Rollback();
            }
            catch (Exception ex)
            {
                if (sqlTrain != null)
                    sqlTrain.Rollback();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            finally
            {
                if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }
        public static bool SFGTestingIsCompeleted(System.Windows.Forms.IWin32Window owner,string sSFGCode, string sProcessCode)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                SFGTestingIsCompeleted(sSFGCode, sProcessCode, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(owner, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == "") strMsg = "校验是否已经提交完成时失败，原因未知。";
                System.Windows.Forms.MessageBox.Show(strMsg);
                return false;
            }
            return true;
        }
        #endregion
        #region 播放声音
        public static void PlayErrMsg()
        {
            string strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strPath.EndsWith("\\"))
                strPath += "\\";
            string strFile = Common.CommonConfig.SoundErr;
            while (strFile.StartsWith("\\"))
                strFile = strFile.Substring(1);
            strPath += strFile;
            if (!System.IO.File.Exists(strPath)) return;
            System.Media.SoundPlayer play = new System.Media.SoundPlayer(strPath);
            play.Play();
            play.Dispose();
            play = null;
        }
        public static void PlayOkMsg()
        {
            string strPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strPath.EndsWith("\\"))
                strPath += "\\";
            string strFile = Common.CommonConfig.SoundOk;
            while (strFile.StartsWith("\\"))
                strFile = strFile.Substring(1);
            strPath += strFile;
            if (!System.IO.File.Exists(strPath)) return;
            System.Media.SoundPlayer play = new System.Media.SoundPlayer(strPath);
            play.Play();
            play.Dispose();
            play = null;
        }
       
        #endregion
        #region 获取树控件绑定值
        public static string GetTreeViewTag(System.Windows.Forms.TreeNode tn, string sSplitChar)
        {
            string strValue = string.Empty;
            if (tn.Tag != null && tn.Tag.ToString() != string.Empty)
                strValue += tn.Tag.ToString() + sSplitChar;
            string strTmp;
            foreach (System.Windows.Forms.TreeNode tnChild in tn.Nodes)
            {
                strTmp = GetTreeViewTag(tnChild, sSplitChar);
                if (strTmp != string.Empty)
                    strValue += strTmp + sSplitChar;
            }
            return strValue;
        }
        #endregion
        #region DataGridView行上移
        public static void DataGridViewRowUp(System.Windows.Forms.DataGridView dgv, string sSortColumn)
        {
            if (dgv == null) return;
            if (dgv.DataSource == null) return;
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null) return;
            if (!dt.Columns.Contains(sSortColumn)) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(dgv);
            if (list.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请选择行。");
                return;
            }
            if (string.Compare(dt.DefaultView.Sort, sSortColumn + " ASC", true) != 0)
                dt.DefaultView.Sort = sSortColumn + " ASC";
            int iRow;
            object objSort;
            List<int> listNew = new List<int>();
            DataRow dr1, dr2;
            for (int i = 0; i < list.Count; i++)
            {
                iRow = list[i];
                if (iRow == 0)
                {
                    System.Windows.Forms.MessageBox.Show("已经是第一行。");
                    return;
                }
                dr1 = dt.DefaultView[iRow - 1].Row;
                dr2 = dt.DefaultView[iRow].Row;
                objSort = dr1[sSortColumn];
                dr1[sSortColumn] = dr2[sSortColumn];
                dr2[sSortColumn] = objSort;
                listNew.Add(iRow - 1);
                //dgv.Rows[iRow - 1].Selected = true;
                //dgv.Rows[iRow].Selected = false;
            }
            dgv.DataSource = dt;
            dt.DefaultView.Sort = sSortColumn + " ASC";
            foreach (System.Windows.Forms.DataGridViewCell dgvc in dgv.SelectedCells)
            {
                if (dgvc.Selected)
                    dgvc.Selected = false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (dgv.Rows[list[i]].Selected)
                {
                    if (listNew.Contains(list[i]))
                    {
                        if (!dgv.Rows[list[i]].Selected)
                            dgv.Rows[list[i]].Selected = true;
                        listNew.Remove(list[i]);
                    }
                    else
                    {
                        if (dgv.Rows[list[i] - 1].Selected)
                            dgv.Rows[list[i] - 1].Selected = false;
                    }
                }
            }
            foreach (int i in listNew)
            {
                if (!dgv.Rows[i].Selected)
                    dgv.Rows[i].Selected = true;
            }
        }
        public static void DataGridViewRowDown(System.Windows.Forms.DataGridView dgv, string sSortColumn)
        {
            if (dgv == null) return;
            if (dgv.DataSource == null) return;
            DataTable dt = dgv.DataSource as DataTable;
            if (dt == null) return;
            if (!dt.Columns.Contains(sSortColumn)) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(dgv);
            if (list.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请选择行。");
                return;
            }
            if (string.Compare(dt.DefaultView.Sort, sSortColumn + " ASC", true) != 0)
                dt.DefaultView.Sort = sSortColumn + " ASC";
            int iRow;
            object objSort;
            DataRow dr1, dr2;
            List<int> listNew = new List<int>();
            for (int i = list.Count; i > 0; i--)
            {
                iRow = list[i - 1];
                if (iRow == dgv.Rows.Count - 1)
                {
                    System.Windows.Forms.MessageBox.Show("已经是最后一行。");
                    return;
                }
                dr1 = dt.DefaultView[iRow + 1].Row;
                dr2 = dt.DefaultView[iRow].Row;
                objSort = dr1[sSortColumn];
                dr1[sSortColumn] = dr2[sSortColumn];
                dr2[sSortColumn] = objSort;
                listNew.Add(iRow + 1);
                //dgv.Rows[iRow + 1].Selected = true;
                //dgv.Rows[iRow].Selected = false;
            }
            dgv.DataSource = dt;
            dt.DefaultView.Sort = sSortColumn + " ASC";
            foreach (System.Windows.Forms.DataGridViewCell dgvc in dgv.SelectedCells)
            {
                if (dgvc.Selected)
                    dgvc.Selected = false;
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (dgv.Rows[list[i]].Selected)
                {
                    if (listNew.Contains(list[i]))
                    {
                        if (!dgv.Rows[list[i]].Selected)
                            dgv.Rows[list[i]].Selected = true;
                        listNew.Remove(list[i]);
                    }
                    else
                    {
                        if (dgv.Rows[list[i] + 1].Selected)
                            dgv.Rows[list[i] + 1].Selected = false;
                    }
                }
            }
            foreach (int i in listNew)
            {
                if (!dgv.Rows[i].Selected)
                    dgv.Rows[i].Selected = true;
            }
        }
        #endregion
        #region 打开WEB
        public static void OpenWeb(string sUrl)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {
                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP = ip.ToString();
                    }
                }
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.Common_GetIEPath('{0}','{1}')", Common.WebOpen.frmFindIE.TYPE, strIP.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
            string strPath = dt.Rows[0][0].ToString();
            try
            {
                if (strPath == string.Empty)
                    System.Diagnostics.Process.Start(sUrl);
                else System.Diagnostics.Process.Start(strPath, sUrl);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                if (Common.WebOpen.frmFindIE.Open())
                    OpenWeb(sUrl);
            }
        }
        #endregion
        #region 全角字符转换成英文状态下字符
        public static string CNWordsToEN(string sText)
        {
            #region 定义要过滤的全角ASC码
            //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.,-=[]{}/~`?";
            List<int> listAsc = new List<int>();
            listAsc.Add(65345);
            listAsc.Add(65346);
            listAsc.Add(65347);
            listAsc.Add(65348);
            listAsc.Add(65349);
            listAsc.Add(65350);
            listAsc.Add(65351);
            listAsc.Add(65352);
            listAsc.Add(65353);
            listAsc.Add(65354);
            listAsc.Add(65355);
            listAsc.Add(65356);
            listAsc.Add(65357);
            listAsc.Add(65358);
            listAsc.Add(65359);
            listAsc.Add(65360);
            listAsc.Add(65361);
            listAsc.Add(65362);
            listAsc.Add(65363);
            listAsc.Add(65364);
            listAsc.Add(65365);
            listAsc.Add(65366);
            listAsc.Add(65367);
            listAsc.Add(65368);
            listAsc.Add(65369);
            listAsc.Add(65370);
            listAsc.Add(65313);
            listAsc.Add(65314);
            listAsc.Add(65315);
            listAsc.Add(65316);
            listAsc.Add(65317);
            listAsc.Add(65318);
            listAsc.Add(65319);
            listAsc.Add(65320);
            listAsc.Add(65321);
            listAsc.Add(65322);
            listAsc.Add(65323);
            listAsc.Add(65324);
            listAsc.Add(65325);
            listAsc.Add(65326);
            listAsc.Add(65327);
            listAsc.Add(65328);
            listAsc.Add(65329);
            listAsc.Add(65330);
            listAsc.Add(65331);
            listAsc.Add(65332);
            listAsc.Add(65333);
            listAsc.Add(65334);
            listAsc.Add(65335);
            listAsc.Add(65336);
            listAsc.Add(65337);
            listAsc.Add(65338);
            listAsc.Add(65297);
            listAsc.Add(65298);
            listAsc.Add(65299);
            listAsc.Add(65300);
            listAsc.Add(65301);
            listAsc.Add(65302);
            listAsc.Add(65303);
            listAsc.Add(65304);
            listAsc.Add(65305);
            listAsc.Add(65296);
            listAsc.Add(65294);
            listAsc.Add(65292);
            listAsc.Add(65293);
            listAsc.Add(65309);
            listAsc.Add(65339);
            listAsc.Add(65341);
            listAsc.Add(65371);
            listAsc.Add(65373);
            listAsc.Add(65295);
            listAsc.Add(65374);
            listAsc.Add(65344);
            listAsc.Add(65311);
            #endregion
            string sRet = string.Empty;
            int iAsc;
            foreach (char c in sText.ToCharArray())
            {
                iAsc = (int)c;
                if (listAsc.IndexOf(iAsc) >= 0)
                {
                    iAsc -= 65248;
                    Char ch = (Char)iAsc;
                    sRet += ch.ToString();
                }
                else sRet += c.ToString();
            }
            return sRet;
        }
        #endregion
        #region 发送MES系统异常到服务器
        /// <summary>
        ///  发送MES系统异常到服务器（处理部门为：系统）
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="sAudioContent"></param>
        public static void SendExceptionToMES(string sMsg, string sAudioContent)
        {
            string strSql;
            if (sAudioContent.Length > 0)
                strSql = string.Format("EXEC [SendMsg_ExcepitionDataAudio] '{0}','{1}'", sMsg.Replace("'", "''"), sAudioContent.Replace("'", "''"));
            else strSql = string.Format("EXEC [SendMsg_ExcepitionData] '{0}'", sMsg.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                ErrorService.ErrorLog.WriteErrorLog(ex);
            }
        }
        public static void SendExceptionToMES_SC(string sMsg, string sAudioContent)
        {
            string strSql;
            if (sAudioContent.Length > 0)
                strSql = string.Format("EXEC [SendMsg_ExcepitionDataAudio_SC] '{0}','{1}'", sMsg.Replace("'", "''"), sAudioContent.Replace("'", "''"));
            else strSql = string.Format("EXEC [SendMsg_ExcepitionData_SC] '{0}'", sMsg.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                ErrorService.ErrorLog.WriteErrorLog(ex);
            }
        }
        public static void SendExceptionToMES_WZ(string sMsg, string sAudioContent)
        {
            string strSql;
            if (sAudioContent.Length > 0)
                strSql = string.Format("EXEC [SendMsg_ExcepitionDataAudio_WZ] '{0}','{1}'", sMsg.Replace("'", "''"), sAudioContent.Replace("'", "''"));
            else strSql = string.Format("EXEC [SendMsg_ExcepitionData_WZ] '{0}'", sMsg.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                ErrorService.ErrorLog.WriteErrorLog(ex);
            }
        }
        public static void SendExceptionToMES_PZ(string sMsg, string sAudioContent)
        {
            string strSql;
            if (sAudioContent.Length > 0)
                strSql = string.Format("EXEC [SendMsg_ExcepitionDataAudio_PZ] '{0}','{1}'", sMsg.Replace("'", "''"), sAudioContent.Replace("'", "''"));
            else strSql = string.Format("EXEC [SendMsg_ExcepitionData_PZ] '{0}'", sMsg.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                ErrorService.ErrorLog.WriteErrorLog(ex);
            }
        }
        #endregion
        #region 获取本机IP
        public static List<string> GetMyIPs()
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            List<string> list = new List<string>();
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {

                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        list.Add(ip.ToString());
                    }
                }
            }
            return list;
        }
        #endregion
        #region 存储修改前数据（以XML形式存储）
        public static void SaveModifyXML(string sProcessCode, string sGuid, string SFGGode, string sOperator, string sXml,string sRemark)
        {
            string strSql = string.Format("INSERT INTO ModfiyXml (Times,ProcessCode,GUID,SFGCode,Operator,XML,Remark) values(getdate(),'{0}','{1}','{2}','{3}','{4}','{5}')"
                , sProcessCode.Replace("'", "''"), sGuid.Replace("'", "''"), SFGGode.Replace("'", "''"), sOperator.Replace("'", "''"), sXml.Replace("'", "''"), sRemark.Replace("'", "''"));

            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        #region 注册全局热键
        public static class Hotkey
        {
            #region 系统api
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers fsModifiers, Keys vk);

            [DllImport("user32.dll")]
            static extern bool UnregisterHotKey(IntPtr hWnd, int id);
            #endregion

            /**/
            /// <summary> 
            /// 注册快捷键 
            /// </summary> 
            /// <param name="hWnd">持有快捷键窗口的句柄</param> 
            /// <param name="fsModifiers">组合键</param> 
            /// <param name="vk">快捷键的虚拟键码</param> 
            /// <param name="callBack">回调函数</param> 
            public static void Regist(IntPtr hWnd, HotkeyModifiers fsModifiers, Keys vk, HotKeyCallBackHanlder callBack)
            {
                int id = keyid++;
                if (!RegisterHotKey(hWnd, id, fsModifiers, vk))
                    throw new Exception("regist hotkey fail.");
                keymap[id] = callBack;
            }

            /**/
            /// <summary> 
            /// 注销快捷键 
            /// </summary> 
            /// <param name="hWnd">持有快捷键窗口的句柄</param> 
            /// <param name="callBack">回调函数</param> 
            public static void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
            {
                foreach (KeyValuePair<int, HotKeyCallBackHanlder> var in keymap)
                {
                    if (var.Value == callBack)
                        UnregisterHotKey(hWnd, var.Key);
                }
            }

            /**/
            /// <summary> 
            /// 快捷键消息处理 
            /// </summary> 
            public static void ProcessHotKey(System.Windows.Forms.Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    int id = m.WParam.ToInt32();
                    HotKeyCallBackHanlder callback;
                    if (keymap.TryGetValue(id, out callback))
                    {
                        callback();
                    }
                }
            }

            const int WM_HOTKEY = 0x312;
            static int keyid = 10;
            static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

            public delegate void HotKeyCallBackHanlder();
        }
        public enum HotkeyModifiers
        {
            None = 0,
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8
        }
        #endregion
        #region 计算时间
        public static string GetRemainTimeDesc(int iMSecs)
        {
            int iSecs = iMSecs / 1000;
            int iH = 0;
            int iM = 0;
            int iS = 0;
            iM = iSecs / 60;
            iS = iSecs % 60;
            iH = iM / 60;
            iM = iM % 60;
            string strTime = string.Empty;
            if (iH > 0)
            {
                strTime = iH.ToString() + "时";
            }
            if (iM > 0)
                strTime += iM.ToString() + "分";
            else
            {
                if (iH > 0)
                    strTime += "0分";
            }
            strTime += iS.ToString() + "秒";
            return strTime;
        }
        public static string GetRemainTimeDesc_HM(int iMSecs)
        {
            int iSecs = iMSecs / 1000;
            int iH = 0;
            int iM = 0;
            int iS = 0;
            iM = iSecs / 60;
            iS = iSecs % 60;
            iH = iM / 60;
            iM = iM % 60;
            string strTime = string.Empty;
            if (iH > 0)
            {
                strTime = iH.ToString() + "时";
            }
            if (iM > 0)
                strTime += iM.ToString() + "分";
            else
            {
                if (iH > 0)
                    strTime += "0分";
            }
            return strTime;
        }
        public static string GetRemainTimeDesc_Auto(int iMSecs)
        {
            if (iMSecs > 3600000)
                return GetRemainTimeDesc_HM(iMSecs);
            else return GetRemainTimeDesc(iMSecs);
        }
        public static string GetRemainTimeDesc_Auto_Second(int iSecs)
        {
            if (iSecs > 3600)
                return GetRemainTimeDesc_HM_Second(iSecs);
            else return GetRemainTimeDesc_Scecond(iSecs);
        }
        public static string GetRemainTimeDesc_HM_Second(int iSecs)
        {
            int iH = 0;
            int iM = 0;
            int iS = 0;
            iM = iSecs / 60;
            iS = iSecs % 60;
            iH = iM / 60;
            iM = iM % 60;
            string strTime = string.Empty;
            if (iH > 0)
            {
                strTime = iH.ToString() + "时";
            }
            if (iM > 0)
                strTime += iM.ToString() + "分";
            else
            {
                if (iH > 0)
                    strTime += "0分";
            }
            return strTime;
        }
        #region 传入单位为为秒的
        public static string GetRemainTimeDesc_Scecond(int iSecs)
        {
            int iH = 0;
            int iM = 0;
            int iS = 0;
            iM = iSecs / 60;
            iS = iSecs % 60;
            iH = iM / 60;
            iM = iM % 60;
            string strTime = string.Empty;
            if (iH > 0)
            {
                strTime = iH.ToString() + "时";
            }
            if (iM > 0)
                strTime += iM.ToString() + "分";
            else
            {
                if (iH > 0)
                    strTime += "0分";
            }
            strTime += iS.ToString() + "秒";
            return strTime;
        }
        #endregion

        #endregion
        #region 存放图片文件及文件的缓存路径
        public static string GetFileCacheDir()
        {
            string strDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strDir.EndsWith("\\"))
                strDir += "\\";
            strDir += "filesCache";
            try
            {
                if (!System.IO.Directory.Exists(strDir))
                    System.IO.Directory.CreateDirectory(strDir);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            return strDir;
        }
        /// <summary>
        /// 获取文件在本地磁盘路径
        /// </summary>
        /// <param name="sFileGuid">文件GUID 标识</param>
        /// <param name="sExs">文件后缀，不包含“.”</param>
        /// <returns></returns>
        public static string GetFilePath(string sFileGuid, string sExs)
        {
            if (sFileGuid == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("文件标识为空。");
                return string.Empty;
            }
            string strP = GetFileCacheDir() + "\\" + sFileGuid + "." + sExs;
            if (File.Exists(strP)) return strP;
            //从数据库加载数据
            string strTemp = strP + ".tem!";
            //从数据库读取数据
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT FileEntity FROM Files WHERE GUID='{0}'", sFileGuid.Replace("'", "''")), false);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("文件不存在或已经被删除。");
                return string.Empty;
            }
            byte[] byFile = (byte[])dt.Rows[0]["FileEntity"];
            FileInfo fi = null;
            FileStream fs = null;
            try
            {
                fi = new System.IO.FileInfo(strTemp);
                fs = fi.OpenWrite();
                fs.Write(byFile, 0, byFile.Length);
                fs.Close();
                fs.Dispose();
                fs = null;
                fi = null;
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                    fs = null;
                }
                if (fi != null)
                {
                    fi = null;
                }
            }
            //将临时文件转成目标文件
            try
            {
                File.Move(strTemp, strP);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            return strP;
        }
        #endregion
        #region 下载文件
        public static bool SaveFile(System.Windows.Forms.IWin32Window owner, string sGuid, string sFileName, string sFileExtension)
        {
            string strFile = GetFilePath(sGuid, sFileExtension);
            if (strFile == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("文件下载失败。");
                return false;
            }
            //如果已经存在则拷贝即可
            System.Windows.Forms.SaveFileDialog frm = new System.Windows.Forms.SaveFileDialog();
            frm.Title = "保存\"" + sFileName + "\"";
            frm.OverwritePrompt = true;
            frm.FileName = sFileName;
            frm.DefaultExt = sFileExtension;
            frm.AddExtension = true;
            //frm.Filter = sFileTypeDesc + "(*" + sFileExtension + ")|*" + sFileTypeDesc;
            frm.Filter = string.Format("*.{0}|*.{0}", sFileExtension);
            //frm.RestoreDirectory = true;
            if (System.Windows.Forms.DialogResult.OK != frm.ShowDialog(owner))
                return false;
            if (frm.FileName == string.Empty)
            {
                System.Windows.Forms.MessageBox.Show("请选择要保存的文件名");
                return false;
            }
            if (strFile.Length > 0)
            {
                try
                {
                    File.Copy(strFile, frm.FileName);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(owner, ex);
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
