using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Threading;

namespace AutoAssign.ExpFuns
{
    public partial class frmToExcel : Common.frmBase
    {
        JPSEntity.MyCsvWriter _MyCsvWriter = null;
        string _TestCode = string.Empty;
        string _BatTableName = string.Empty;
        string _ResultTableName = string.Empty;
        #region 常量
        const string BTText_Start = "开始导出";
        const string BTText_Stop = "终止";
        const string BTText_Exportting = "导出进行中";
        const string BTText_complate = "重新导出";
        #endregion
        int _MaxValue = 0;
        int _Value = 0;
        public frmToExcel(string sTestCode, string sBatTable, string sResultTable)
        {
            InitializeComponent();
            this._TestCode = sTestCode;
            this._BatTableName = sBatTable;
            this._ResultTableName = sResultTable;
            this.label1.Text = string.Format("分选批次{0}数据导出Excel", sTestCode);
        }
        public frmToExcel()
        {
            InitializeComponent();
        }
        public void AddValue(int iAddValue)
        {
            this._Value += iAddValue;
            if (_MaxValue == 0)
            {
                this.labProgress.Width = this.panContainer.Width;
                this.labProgress.Text = "100%";
                return;
            }
            string strText;
            int iWidth;
            if (this._Value >= this._MaxValue)
            {
                strText = "100%";
                iWidth = this.panContainer.Width;
            }
            else
            {
                decimal dec = (decimal)this._Value / (decimal)this._MaxValue;
                strText = dec.ToString("#########0%");
                dec = dec * (decimal)this.panContainer.Width;
                iWidth = (int)dec;
                if (iWidth > this.panContainer.Width)
                    iWidth = this.panContainer.Width;
            }
            //计算进度条长度
            this.labProgress.Width = iWidth;
            if (iWidth > 10)
                this.labProgress.Text = strText;
        }
        public void Init(int iMaxValue)
        {
            this._MaxValue = iMaxValue;
            this.labProgress.Width = 0;
            this.labProgress.Text = string.Empty;
            this._Value = 0;
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            this.btTrue.Enabled = false;
            if (this.btTrue.Text != BTText_Stop)
            {
                string strFile;
                if (this.tbTarget.Text.Length == 0)
                {
                    this.ShowMsg("请设置目标文件名！");
                }
                if (File.Exists(this.tbTarget.Text))
                {
                    this.ShowMsg("文件名已经存在了！");
                    return;
                }
                strFile = this.tbTarget.Text;
                string strErr;
                this.btTrue.Text = BTText_Exportting;
                this.panContainer.Visible = true;
                this.Init(100);
                if (!Save2Excel(strFile, out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
                this.Close();
                this.ShowMsgRich("导出成功！");
                //this.btTrue.Text = BTText_complate;
                //this.btTrue.Enabled = true;
            }
        }

        private bool Save2Excel(string strFile, out string strErr)
        {
            strErr = "";
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("EXEC [dbo].[Tested_Grooves_1] '{0}' ,'{1}'", this._ResultTableName.Replace("'", "''"), this._BatTableName.Replace("'", "''")), "合格"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("EXEC [dbo].[Tested_Grooves_2] '{0}' ,'{1}'", this._ResultTableName.Replace("'", "''"), this._BatTableName.Replace("'", "''")), "不合格"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("EXEC [dbo].[Tested_Grooves_0] '{0}' ,'{1}'", this._ResultTableName.Replace("'", "''"), this._BatTableName.Replace("'", "''")), "其他"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                strErr = ex.Message;

            }
            _MyCsvWriter_CsvSaveFinishedNotice(false, false, 50);

            if (ds == null) { this.ShowMsg("可能数据已经被清除，未找到任何数据"); this.Close(); } 

            try
            {
                ExcelRender.RenderToExcel(ds, strFile);
            }
            catch (Exception ex)
            {
                strErr = string.Format("写入Excel数据时出错：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            //Thread _thread = new Thread(() => ExcelRender.RenderToExcel(ds, strFile));
            //_thread.IsBackground = true;
            //try
            //{
            //    _thread.Start();
            //}
            //catch (Exception ex)
            //{
            //    strErr = string.Format("写入Excel数据时出错：{0}({1})", ex.Message, ex.Source);
            //    return false;
            //}
            _MyCsvWriter_CsvSaveFinishedNotice(true, true, 100);
            return true;
        }

        private void linkTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "EXCEL文件(*.xls)|*.xls";
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".xls";
            dialog.FileName = string.Format("批次{0}数据_{1}.xls", this._TestCode, DateTime.Now.ToString("yyyyMMddHHmmss"));
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(this))
                return;
            if (dialog.FileName == string.Empty)
            {
                return;
            }
            this.tbTarget.Text = dialog.FileName;
            this.btTrue.Enabled = true;
            if (btTrue.Text == BTText_complate) btTrue.Text = BTText_Start;
        }

        private void _MyCsvWriter_CsvSaveFinishedNotice(bool blStop, bool blSucessfully, int iCount)
        {
            //更新当前进度
            if (blSucessfully)
            {
                this.AddValue(iCount);
                if (blStop)
                {
                    SetStatus(ClearStates.Compeleted);
                }
                else
                {
                    SetStatus(ClearStates.Writing);
                }
            }
            else
            {
                if (blStop)
                    SetStatus(ClearStates.Error);
            }
        }
        public void SetStatus(ClearStates state)
        {
            string strStatuText;
            if (state == ClearStates.Error)
            {
                strStatuText = BTText_Stop;
            }
            else if (state == ClearStates.Writing)
            {
                strStatuText = BTText_Stop;

            }
            else if (state == ClearStates.Compeleted)
            {
                strStatuText = BTText_Start;
            }
            else
            {
                //此时为.Compeleted
                strStatuText = "？？";
            }
            if (this.btTrue.Text != strStatuText)
                this.btTrue.Text = strStatuText;
        }
        public enum ClearStates
        {
            Error = 0,
            Compeleted = 1,
            Writing = 2
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.btTrue.Text == BTText_Stop)
            {
                e.Cancel = true;
                this.ShowMsg("请先终止！");
                return;
            }
            base.OnClosing(e);
        }

        private void frmToExcel_Load(object sender, EventArgs e)
        {
            this._MyCsvWriter = new JPSEntity.MyCsvWriter(this);
            this._MyCsvWriter.CsvSaveFinishedNotice += _MyCsvWriter_CsvSaveFinishedNotice;
        }
        /// <summary>
        /// datatable 存入excel
        /// </summary>
        public class ExcelRender
        {
            /// <summary>
            /// 自动设置Excel列宽
            /// </summary>
            /// <param name="sheet">Excel表</param>
            private static void AutoSizeColumns(ISheet sheet)
            {
                if (sheet.PhysicalNumberOfRows > 0)
                {
                    IRow headerRow = sheet.GetRow(0);

                    for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                }
            }
            /// <summary>
            /// 保存Excel文档流到文件
            /// </summary>
            /// <param name="ms">Excel文档流</param>
            /// <param name="fileName">文件名</param>
            private static void SaveToFile(MemoryStream ms, string fileName)
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();

                    fs.Write(data, 0, data.Length);
                    fs.Flush();

                    data = null;
                }
            }
            /// <summary>
            /// DataSet转换成Excel文档流，并保存到文件
            /// </summary>
            /// <param name="DataSet"></param>
            /// <param name="fileName">保存的路径</param>
            public static void RenderToExcel(DataSet ds, string fileName)
            {
                MemoryStream ms = new MemoryStream();
                IWorkbook workbook = new HSSFWorkbook();
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    DataTable table = ds.Tables[i];
                    ISheet sheet = workbook.CreateSheet(table.TableName);

                    IRow headerRow = sheet.CreateRow(0);

                    // handling header.
                    foreach (DataColumn column in table.Columns)
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.Caption);//If Caption not set, returns the ColumnName value

                    // handling value.
                    int rowIndex = 1;

                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);

                        foreach (DataColumn column in table.Columns)
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                        }

                        rowIndex++;
                    }
                    AutoSizeColumns(sheet);

                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;
                }
                SaveToFile(ms, fileName);
            }
        }
    }
}
