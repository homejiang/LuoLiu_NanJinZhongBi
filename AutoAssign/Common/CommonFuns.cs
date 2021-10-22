using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using ErrorService;
using System.Data.SqlClient;

namespace Common
{
    public class CommonFuns
    {
        #region ��ȡ��д��ini�ļ�
        /// <summary>
        /// �����API����
        /// </summary>
        public class INIAPI
        {
            /// <summary>
            /// �ᵽ�����ļ���ָ���Ľ�
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
            /// �õ������ļ��е�ָ������ָ�����ִ�ֵ
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
            /// �õ������ļ��е�ָ������ָ������ֵ
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
            /// ��ָ���������ļ������ӽڵ�
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
            /// ��ָ���������ļ���ָ���ڣ��ؼ��ֵ�ֵ
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
        /// д��Ͷ�ȡ����
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
            /// �õ�ָ������Key��ֵ
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
            /// �õ�ָ������Key��ֵ
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
            /// �õ�ָ������Key��ֵ
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
            /// ����ָ������Key��ֵ
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
        #region ��ֹ����������
        public abstract class OneInstance
        {
            /// <summary> 
            /// �����ж�һ��ָ���ĳ����Ƿ��������� 
            /// </summary> 
            /// <param name="appId">��������,��һ��ȽϺ�,��ֹ���ظ�</param> 
            /// <returns>��������ǵ�һ�����з���True,���򷵻�False</returns> 
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
            /// �жϳ����Ƿ���������
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
        #region ������ק
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
        #region ���ܺͼ���
        public class EncryptDecryptService
        {
            #region DEC����
            public class DESPassword
            {
                /// <summary>
                /// DES�ӽ��ܵ���Կ
                /// </summary>
                public static string DESKey = "8^@a)2.Y";
            }
            #endregion
            /// <summary>
            /// MD5���ܷ���
            /// </summary>
            /// <param name="strEncrypt">��������</param>
            /// <returns>��������</returns>
            public static string MD5Encrypt(string strEncrypt)
            {
                StringBuilder strResult = new StringBuilder(1000);
                byte[] bEncrypt;
                MD5 md5 = new MD5CryptoServiceProvider();

                strEncrypt = strEncrypt == null ? string.Empty : strEncrypt;
                bEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncrypt);
                byte[] bResult = md5.ComputeHash(bEncrypt);
                //ʮ�����Ʒ�ʽ���
                foreach (byte b in bResult)
                {
                    strResult.AppendFormat("{0:X2}", b);
                }
                return strResult.ToString();
            }
            /// <summary>
            /// Base64����
            /// </summary>
            /// <param name="strEncrypt">ԭʼ�ִ�</param>
            /// <returns>����Base64���ܺ���ִ�</returns>
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
            /// Base64����
            /// </summary>
            /// <param name="strDecrypt">Base64���ܺ���ִ�</param>
            /// <returns>����ԭʼ�ִ�</returns>
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
            /// DES����
            /// </summary>
            /// <param name="strDESKey">DES��Կ</param>
            /// <param name="strEncrypt">Ҫ���ܵ�����</param>
            /// <returns>���ܺ������</returns>
            public static string DESEncrypt(string strDESKey, string strEncrypt)
            {
                StringBuilder strResult = new StringBuilder(1000);
                //��Կ
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                strEncrypt = strEncrypt == null ? string.Empty : strEncrypt;

                byte[] bEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncrypt);

                des.Key = System.Text.Encoding.UTF8.GetBytes(strDESKey);
                des.IV = System.Text.Encoding.UTF8.GetBytes(strDESKey);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

                cs.Write(bEncrypt, 0, bEncrypt.Length);
                cs.FlushFinalBlock();
                //ʮ�����Ʒ�ʽ���
                foreach (byte b in ms.ToArray())
                {
                    strResult.AppendFormat("{0:X2}", b);
                }
                return strResult.ToString();
            }
            /// <summary>
            /// DES����
            /// </summary>
            /// <param name="strDESKey">DES��Կ</param>
            /// <param name="strDecrypt">Ҫ���ܵ�����</param>
            /// <returns>���ܺ������</returns>
            public static string DESDecrypt(string strDESKey, string strDecrypt)
            {
                string strResult;
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                //��ʮ������ת�����ֽ�  
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
        #region ת������
        public class FormatData
        {
            #region ������ת�����ַ���
            /// <summary>
            /// ��yyyy-MM-dd��ʽ��ʽ������
            /// </summary>
            /// <param name="objDatetime"></param>
            /// <returns></returns>
            public static string GetStringByDateTime(object objDatetime)
            {
                return GetStringByDateTime(objDatetime, "yyyy-MM-dd");
            }
            /// <summary>
            /// �Զ����ʽ������
            /// </summary>
            /// <param name="objDatetime">ʱ��ֵ</param>
            /// <param name="strFormat">���ڸ�ʽ������</param>
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
            #region ��˳���ȡֵ
            public static string GetStringByOrder(string str1, string str2)
            {
                return GetStringByOrder(str1, str2, string.Empty, string.Empty);
            }
            public static string GetStringByOrder(string str1, string str2, string str3)
            {
                return GetStringByOrder(str1, str2, str3, string.Empty);
            }
            /// <summary>
            /// ��˳�򷵻�һ����Ϊ�յ�ֵ
            /// </summary>
            /// <param name="str1">��1��ֵ</param>
            /// <param name="str2">��2��ֵ</param>
            /// <param name="str3">��3��ֵ</param>
            /// <param name="str4">��4��ֵ</param>
            /// <returns>�����в�Ϊ�յ�ֵ</returns>
            public static string GetStringByOrder(string str1, string str2, string str3,string str4)
            {
                if (str1.Length > 0) return str1;
                if (str2.Length > 0) return str2;
                if (str3.Length > 0) return str3;
                if (str4.Length > 0) return str4;
                return string.Empty;
            }
            #endregion
            #region ����ֵֵ����С��λ����ȡ��Ӧ�ַ���ֵ
            /// <summary>
            ///  ����ֵת������Ӧ�ַ���
            /// </summary>
            /// <param name="objDecimal">��ֵ</param>
            /// <param name="iCount">С����λ</param>
            /// <returns>��ֵ��ʽ������ַ���</returns>
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
            #region ���úͻ�ȡComboboxֵ
            /// <summary>
            /// ��ComboBox�ؼ�ֵ
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
            /// ����comboboxֵ
            /// </summary>
            /// <param name="control">combobox�ؼ�</param>
            /// <param name="item"> Common.MyEntity.ComboBoxItem����������</param>
            /// <param name="iType">���Ʒ�ʽ0Ϊvalue,1Ϊtext</param>
            public static void SetComboBoxText(System.Windows.Forms.ComboBox control, Common.MyEntity.ComboBoxItem item, int iType)
            {
                for (int i = 0; i < control.Items.Count; i++)
                {
                    Common.MyEntity.ComboBoxItem temp = control.Items[i] as Common.MyEntity.ComboBoxItem;
                    if (temp != null)
                    {
                        if (iType == 0)
                        {
                            //��ʱ����Value���ж�
                            if (temp.Value != null && item.Value != null && temp.Value.ToString() == item.Value.ToString())
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }
                        else if (iType == 1)
                        {
                            //��ʱ����Text���ж�
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
                            //��ʱ����Value���ж�
                            if (temp.Value != null && temp.Value.ToString() == str)
                            {
                                control.SelectedIndex = i;
                                return;
                            }
                        }
                        else if (iType == 1)
                        {
                            //��ʱ����Text���ж�
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
            /// ���Ϊ�յ��򷵻�DBNull
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
        }
        #endregion
        #region ��ȡ��������ǰʱ��
        /// <summary>
        /// ��ȡ��������ǰʱ��
        /// </summary>
        /// <param name="time"></param>
        /// <returns>��ȡ�Ƿ�ɹ�</returns>
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
        #endregion
        #region �ַ�������У��
        public class StringRegexCheck
        {
            /// <summary>
            /// ����У�鴫����Ƿ�Ϊ��׼����ɫʮ�����Ƹ�ʽ������������δ��д���
            /// </summary>
            /// <param name="strHex">��ɫʮ�������ַ���</param>
            /// <returns>��������򷵻���</returns>
            public static bool CheckIsColorHexString(string strHex)
            {
                if (strHex.Length == 0) return false;
                //����У��
                return true;
            }
            /// <summary>
            /// У���ַ����Ƿ񱻰�������sSource���Ƿ����sText
            /// </summary>
            /// <param name="sSource"></param>
            /// <param name="sText"></param>
            /// <param name="ignoreCase">�Ƿ���Դ�Сд</param>
            /// <returns>���sSource������sText���򷵻���</returns>
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
        #region ��ȡ<></>��ʽ�ַ���
        public static string GetTextFromXml(string strSource, string strNode)
        {
            if (strNode == string.Empty) return string.Empty;
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(string.Format("<{0}>.*?</{0}>", strNode), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            string strText;
            System.Text.RegularExpressions.Match mc = reg.Match(strSource);
            if (mc == null || mc.Value == string.Empty)
                return string.Empty;
            strText = mc.Value;
            //��ȡ����
            return strText.Substring(strNode.Length + 2, strText.Length - 2 * (strNode.Length + 2) - 1);
        }
        #endregion
        #region У���ӡ���Ƿ���Ч
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
                System.Windows.Forms.MessageBox.Show("��ӡ��\""+sPrinter+"\"�����ڡ�", "��Ϣ��ʾ");
            return false;
        }
        #endregion
        
        #region ��ȡDataGridViewѡ����
        public static List<int> GetSelectedRows(System.Windows.Forms.DataGridView dgv)
        {
            List<int> _list = new List<int>();
            //����ѡ���У���С���������˳��
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
        #region �����б�Ϊexcel�ļ�
        public static bool DataGridViewToExcel(System.Windows.Forms.DataGridView dgv, string strFileName)
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "Execl files (*.xls)|*.xls";
            dlg.FilterIndex = 0;
            dlg.RestoreDirectory = true;
            dlg.CreatePrompt = false;
            dlg.Title = "����ΪExcel�ļ�";
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
                    //д���б���   
                    for (int i = 0; i < dgv.ColumnCount; i++)
                    {
                        if (!dgv.Columns[i].Visible) continue;
                        columnTitle += dgv.Columns[i].HeaderText + "\t";
                    }
                    sw.WriteLine(columnTitle);
                    //д��������   
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
        #region �����ı�
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
        #region ������ʱУ���Ƿ��Ѿ��ύ��������������
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
                if (strMsg == "") strMsg = "У���Ƿ��Ѿ��ύ���ʱʧ�ܣ�ԭ��δ֪��";
                System.Windows.Forms.MessageBox.Show(strMsg);
                return false;
            }
            return true;
        }
        #endregion
        #region ��������
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
        #region ��ȡ���ؼ���ֵ
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
        #region DataGridView������
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
                System.Windows.Forms.MessageBox.Show("��ѡ���С�");
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
                    System.Windows.Forms.MessageBox.Show("�Ѿ��ǵ�һ�С�");
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
                System.Windows.Forms.MessageBox.Show("��ѡ���С�");
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
                    System.Windows.Forms.MessageBox.Show("�Ѿ������һ�С�");
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
        #region ����ʱ��
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
                strTime = iH.ToString() + "ʱ";
            }
            if (iM > 0)
                strTime += iM.ToString() + "��";
            else
            {
                if (iH > 0)
                    strTime += "0��";
            }
            strTime += iS.ToString() + "��";
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
                strTime = iH.ToString() + "ʱ";
            }
            if (iM > 0)
                strTime += iM.ToString() + "��";
            else
            {
                if (iH > 0)
                    strTime += "0��";
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
                strTime = iH.ToString() + "ʱ";
            }
            if (iM > 0)
                strTime += iM.ToString() + "��";
            else
            {
                if (iH > 0)
                    strTime += "0��";
            }
            return strTime;
        }
        #region ���뵥λΪΪ���
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
                strTime = iH.ToString() + "ʱ";
            }
            if (iM > 0)
                strTime += iM.ToString() + "��";
            else
            {
                if (iH > 0)
                    strTime += "0��";
            }
            strTime += iS.ToString() + "��";
            return strTime;
        }
        #endregion

        #endregion
        #region ��byteת��λ����������
        public static string GetStringFromByte(byte b)
        {
            string s = string.Empty;
            for (int i = 7; i >= 0; i--)
            {
                s += Convert.ToString((b >> i) & 0x01);
            }
            return s;
        }
        public static string GetByteToHex(byte[] bs)
        {
            StringBuilder sb = new StringBuilder();
            int iInxex = 0;
            foreach (byte b in bs)
            {
                string shex = Convert.ToString(b, 16);
                if (shex.Length < 2) shex = "0" + shex;
                sb.Append(string.Format("{0}��{1}\r\n", iInxex, shex));
                iInxex++;
            }
            return sb.ToString();
        }
        #endregion
        #region ��ȡ����IP
        public static List<string> GetMyIPs()
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            List<string> list = new List<string>();
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //ע��Ŀǰֻ��ȡIP4�ĵ�ַ
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
        #region �滻�ļ����Ƿ��ַ�
        public static string GetFileName(string sOrgName,string sPlace)
        {
            return sOrgName.Replace("\\", sPlace).Replace("/", sPlace).Replace(":", sPlace).Replace("*", sPlace).Replace("\"", sPlace).Replace("<", sPlace).Replace(">", sPlace).Replace("|", sPlace);
        }
        #endregion
        public static void SendExceptionToMES(string sMsg,string sAudio)
        {

        }
    }
}
