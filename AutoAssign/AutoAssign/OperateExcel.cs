using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop;
using System.IO;
using System.Data;
using ErrorService;


namespace AutoAssign
{
    public class OperateExcel
    {
        string _ModuleFile = string.Empty;
        public OperateExcel(short iCaoIndex)
        {
            //获取当前打印文件路径
            _ModuleFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!_ModuleFile.EndsWith("\\"))
                _ModuleFile += "\\";
            _ModuleFile += string.Format(@"Printer\Groove{0}.xls", iCaoIndex);
        }
        //通过执行宏打印
        public bool RunExcelMacro(string sPrinter, string sTuoPanCode,out string sErr)
        {
            try
            {
                #region 检查入参
                // 检查文件是否存在
                if (!File.Exists(_ModuleFile))
                {
                    sErr = string.Format("模板文件[{0}]不存在。", _ModuleFile);
                    return false;
                }
                #endregion
                #region 调用宏处理
                // 准备打开Excel文件时的缺省参数对象
                object oMissing = System.Reflection.Missing.Value;
                // 根据参数组是否为空，准备参数组对象
                object[] paraObjects = new object[] { "ExcelReport", sPrinter, sTuoPanCode };
                // 创建Excel对象示例
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                // 判断是否要求执行时Excel可见
                oExcel.Visible = false;
                //if (isShowExcel)
                //{
                //    // 使创建的对象可见
                //    oExcel.Visible = true;
                //}
                // 创建Workbooks对象
                Microsoft.Office.Interop.Excel.Workbooks oBooks = oExcel.Workbooks;
                // 创建Workbook对象
                Microsoft.Office.Interop.Excel._Workbook oBook = null;
                // 打开指定的Excel文件
                oBook = oBooks.Open(_ModuleFile,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing
                                  );
                // 执行Excel中的宏
                object rtnValue = this.RunMacro(oExcel, paraObjects);
                // 保存更改
                //oBook.Save();
                // 退出Workbook
                oBook.Close(false, oMissing, oMissing);
                #endregion
                #region 释放对象
                // 释放Workbook对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                oBook = null;
                // 释放Workbooks对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                oBooks = null;
                // 关闭Excel
                oExcel.Quit();
                // 释放Excel对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                oExcel = null;
                // 调用垃圾回收
                GC.Collect();
                #endregion
            }
            catch (Exception ex)
            {
                sErr = string.Format("Excel宏运行出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        /// <summary>
        /// 运行宏
        /// </summary>
        /// <param name="oApp"></param>
        /// <param name="oRunArgs"></param>
        /// <returns></returns>
        private object RunMacro(object oApp, object[] oRunArgs)
        {
            try
            {
                // 声明一个返回对象
                object objRtn;

                // 反射方式执行宏
                objRtn = oApp.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, oApp, oRunArgs);
                // 返回值
                return objRtn;
            }
            catch (Exception ex)
            {
                // 如果有底层异常，抛出底层异常
                if (ex.InnerException.Message.ToString().Length > 0)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
            }
        }
        public bool PrintData(string sTuoPanCode, out string sErr)
        {
            try
            {
                #region 检查入参
                // 检查文件是否存在
                if (!File.Exists(_ModuleFile))
                {
                    sErr = string.Format("模板文件[{0}]不存在。", _ModuleFile);
                    return false;
                }
                #endregion
                // 准备打开Excel文件时的缺省参数对象
                object oMissing = System.Reflection.Missing.Value;
                // 根据参数组是否为空，准备参数组对象
                // 创建Excel对象示例
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                // 判断是否要求执行时Excel可见
                oExcel.Visible = false;
                //if (isShowExcel)
                //{
                //    // 使创建的对象可见
                //    oExcel.Visible = true;
                //}
                // 创建Workbooks对象
                Microsoft.Office.Interop.Excel.Workbooks oBooks = oExcel.Workbooks;
                // 创建Workbook对象
                Microsoft.Office.Interop.Excel._Workbook oBook = null;
                // 打开指定的Excel文件
                oBook = oBooks.Open(_ModuleFile,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing
                                  );

                #region 操作Excel

                //获取第二个Sheet页
                Microsoft.Office.Interop.Excel._Worksheet ws2 = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(2);
                //第一行第一列为起始行号，第二列为结束列
                Microsoft.Office.Interop.Excel.Range rang = ws2.Cells[1, 1] as Microsoft.Office.Interop.Excel.Range;
                if (rang == null)
                {
                    sErr = string.Format("Excel赋值的单元格获取失败。");
                    return false;
                }
                rang.Value = sTuoPanCode;
                Microsoft.Office.Interop.Excel._Worksheet ws1 = (Microsoft.Office.Interop.Excel.Worksheet)oBook.Worksheets.get_Item(1);
                ws1.Select();
                ws1.PrintOutEx();
                //oBook.PrintOutEx();
                #endregion
                // 保存更改
                //oBook.SaveAs(sTargetName, System.Reflection.Missing.Value, oMissing, oMissing, oMissing, oMissing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, oMissing, oMissing, oMissing, oMissing, oMissing);
                // 退出Workbook
                oBook.Close(false, oMissing, oMissing);
                #region 释放对象
                // 释放Workbook对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                oBook = null;
                // 释放Workbooks对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                oBooks = null;
                // 关闭Excel
                oExcel.Quit();
                // 释放Excel对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                oExcel = null;
                // 调用垃圾回收
                GC.Collect();
                #endregion
            }
            catch (Exception ex)
            {
                sErr = string.Format("Excel执行出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            sErr = string.Empty;
            return true;
        }
    }
    public class OperatExcelRich
    {
        public OperatExcelRich()
        {

        }
        /// <summary>
        /// 执行宏
        /// </summary>
        /// <param name="excelFilePath"></param>
        /// <param name="macroName"></param>
        /// <param name="parameters"></param>
        /// <param name="rtnValue"></param>
        /// <param name="isShowExcel"></param>
        public void RunExcelMacro(string excelFilePath, string macroName, object[] parameters, out object rtnValue, bool isShowExcel)
        {
            try
            {
                #region 检查入参
                // 检查文件是否存在
                if (!File.Exists(excelFilePath))
                {
                    throw new System.Exception(excelFilePath + " 文件不存在");
                }
                // 检查是否输入宏名称
                if (string.IsNullOrEmpty(macroName))
                {
                    throw new System.Exception("请输入宏的名称");
                }
                #endregion
                #region 调用宏处理
                // 准备打开Excel文件时的缺省参数对象
                object oMissing = System.Reflection.Missing.Value;
                // 根据参数组是否为空，准备参数组对象
                object[] paraObjects;
                if (parameters == null)
                {
                    paraObjects = new object[] { macroName };
                }
                else
                {
                    // 宏参数组长度
                    int paraLength = parameters.Length;
                    paraObjects = new object[paraLength + 1];
                    paraObjects[0] = macroName;
                    for (int i = 0; i < paraLength; i++)
                    {
                        paraObjects[i + 1] = parameters[i];
                    }
                }
                // 创建Excel对象示例
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                // 判断是否要求执行时Excel可见
                oExcel.Visible = isShowExcel;
                //if (isShowExcel)
                //{
                //    // 使创建的对象可见
                //    oExcel.Visible = true;
                //}
                // 创建Workbooks对象
                Microsoft.Office.Interop.Excel.Workbooks oBooks = oExcel.Workbooks;
                // 创建Workbook对象
                Microsoft.Office.Interop.Excel._Workbook oBook = null;
                // 打开指定的Excel文件
                oBook = oBooks.Open(excelFilePath,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing
                                  );
                // 执行Excel中的宏
                rtnValue = this.RunMacro(oExcel, paraObjects);
                // 保存更改
                //oBook.Save();
                // 退出Workbook
                oBook.Close(false, oMissing, oMissing);
                #endregion
                #region 释放对象
                // 释放Workbook对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                oBook = null;
                // 释放Workbooks对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                oBooks = null;
                // 关闭Excel
                oExcel.Quit();
                // 释放Excel对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                oExcel = null;
                // 调用垃圾回收
                GC.Collect();
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 运行宏
        /// </summary>
        /// <param name="oApp"></param>
        /// <param name="oRunArgs"></param>
        /// <returns></returns>
        private object RunMacro(object oApp, object[] oRunArgs)
        {
            try
            {
                // 声明一个返回对象
                object objRtn;

                // 反射方式执行宏
                objRtn = oApp.GetType().InvokeMember("Run", System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod, null, oApp, oRunArgs);
                // 返回值
                return objRtn;
            }
            catch (Exception ex)
            {
                // 如果有底层异常，抛出底层异常
                if (ex.InnerException.Message.ToString().Length > 0)
                {
                    throw ex.InnerException;
                }
                else
                {
                    throw ex;
                }
            }
        }
        public void OutputExcelByMacro(string moduleExcelFilePath, string strTargetExcelFilePath, string macroName, object[] parameters, out object rtnValue, bool isShowExcel)
        {
            OutputExcelByMacro(moduleExcelFilePath, strTargetExcelFilePath, System.Reflection.Missing.Value, macroName, parameters, out rtnValue, isShowExcel);
        }
        public void OutputExcelByMacro(string moduleExcelFilePath, string strTargetExcelFilePath, object objOutType, string macroName, object[] parameters, out object rtnValue, bool isShowExcel)
        {
            try
            {
                #region 检查入参
                // 检查文件是否存在
                if (!File.Exists(moduleExcelFilePath))
                {
                    throw new System.Exception(moduleExcelFilePath + " 文件不存在");
                }
                // 检查是否输入宏名称
                if (string.IsNullOrEmpty(macroName))
                {
                    throw new System.Exception("请输入宏的名称");
                }
                #endregion
                #region 调用宏处理
                // 准备打开Excel文件时的缺省参数对象
                object oMissing = System.Reflection.Missing.Value;
                // 根据参数组是否为空，准备参数组对象
                object[] paraObjects;
                if (parameters == null)
                {
                    paraObjects = new object[] { macroName };
                }
                else
                {
                    // 宏参数组长度
                    int paraLength = parameters.Length;
                    paraObjects = new object[paraLength + 1];
                    paraObjects[0] = macroName;
                    for (int i = 0; i < paraLength; i++)
                    {
                        paraObjects[i + 1] = parameters[i];
                    }
                }
                // 创建Excel对象示例
                Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
                // 判断是否要求执行时Excel可见
                oExcel.Visible = isShowExcel;
                //if (isShowExcel)
                //{
                //    // 使创建的对象可见
                //    oExcel.Visible = true;
                //}
                // 创建Workbooks对象
                Microsoft.Office.Interop.Excel.Workbooks oBooks = oExcel.Workbooks;
                // 创建Workbook对象
                Microsoft.Office.Interop.Excel._Workbook oBook = null;
                // 打开指定的Excel文件
                oBook = oBooks.Open(moduleExcelFilePath,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                        oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing,
                                       oMissing
                                  );
                // 执行Excel中的宏
                rtnValue = this.RunMacro(oExcel, paraObjects);
                // 保存更改
                oBook.SaveAs(strTargetExcelFilePath, objOutType, oMissing, oMissing, oMissing, oMissing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, oMissing, oMissing, oMissing, oMissing, oMissing);
                // 退出Workbook
                oBook.Close(false, oMissing, oMissing);
                #endregion
                #region 释放对象
                // 释放Workbook对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                oBook = null;
                // 释放Workbooks对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                oBooks = null;
                // 关闭Excel
                oExcel.Quit();
                // 释放Excel对象
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                oExcel = null;
                // 调用垃圾回收
                GC.Collect();
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ExcelOpen(string strFilePath, bool blReadonly)
        {
            if (!File.Exists(strFilePath))
            {
                throw (new Exception("文件“" + strFilePath + "”不存在!"));
            }
            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks = null;
            try
            {

                oExcel.Visible = true;
                oExcel.DisplayAlerts = false;
                oBooks = oExcel.Workbooks;
                oBooks.Open(strFilePath, Type.Missing, blReadonly, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #region 导出Excel

        public static bool OutputExcel(System.Windows.Forms.IWin32Window owner, string sModuleFile, string sDefaultFileName, object[] arrObj)
        {
            if (sModuleFile.Length == 0) return false;
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
            dialog.FileName = sDefaultFileName;
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(owner))
                return false;
            if (dialog.FileName == string.Empty)
            {
                return false;
            }
            object objReturnValue;
            OperatExcelRich cls = new OperatExcelRich();
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
        #endregion
    }
}
