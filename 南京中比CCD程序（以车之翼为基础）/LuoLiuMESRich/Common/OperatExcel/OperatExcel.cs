using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Office.Interop;
using System.IO;
namespace Common
{
    public  class OperatExcel
    {
        public OperatExcel()
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
        public void OutputExcelByMacro(string moduleExcelFilePath,string strTargetExcelFilePath, string macroName, object[] parameters, out object rtnValue, bool isShowExcel)
        {
            OutputExcelByMacro(moduleExcelFilePath, strTargetExcelFilePath, System.Reflection.Missing.Value, macroName, parameters, out rtnValue, isShowExcel);
        }
        public void OutputExcelByMacro(string moduleExcelFilePath, string strTargetExcelFilePath,object objOutType, string macroName, object[] parameters, out object rtnValue, bool isShowExcel)
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
        public bool ExcelOpen(string strFilePath,bool blReadonly)
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
        
    }
}
