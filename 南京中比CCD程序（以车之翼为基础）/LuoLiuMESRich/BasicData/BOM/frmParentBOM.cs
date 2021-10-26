using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.IO;
namespace BasicData.BOM
{
    public partial class frmParentBOM : Common.frmBase
    {
        public frmParentBOM()
        {
            InitializeComponent();
        }
        private void frmBOMUpdate_Load(object sender, EventArgs e)
        {
            this.myDataGridView1.AutoGenerateColumns = true;
            this.labTitle.Text = string.Format("所有引用“{0}”的BOM结构", this._Spec);
            this.BindParentBOM(this.PrimaryValue.ToString());
        }
        public string _Spec = string.Empty;
        public bool BindParentBOM(string sBOMGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC [BOMManage_GetBOMParents] '{0}'"
                    , sBOMGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            this.myDataGridView1.DataSource = dt;
            return true;
        }
        private void linkOutPut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.DataGridViewToExcel(this.myDataGridView1);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
        }
        #region 导出Excel

        private void DataGridViewToExcel(DataGridView dgv)
        {
            string strFileName = string.Format("{0}的所有引用.xls", this._Spec);
            strFileName = strFileName.Replace("*", "╳");
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "Excel文件(*.xls)|*.xls";
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".xls";
            dialog.FileName = Common.CommonConfig.GetDefaultOutputFolder() + "\\" + strFileName;
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(this))
                return;
            if (dialog.FileName == string.Empty)
            {
                return;
            }
            Stream myStream;
            myStream = dialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string columnTitle = "";
            try
            {
                //写入列标题   
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        columnTitle += "\t";
                    }
                    columnTitle += dgv.Columns[i].HeaderText;
                }
                sw.WriteLine(columnTitle);

                //写入列内容   
                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                    string columnValue = "";
                    for (int k = 0; k < dgv.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            columnValue += "\t";
                        }
                        if (dgv.Rows[j].Cells[k].Value == null)
                            columnValue += "";
                        else
                            columnValue += dgv.Rows[j].Cells[k].Value.ToString().Trim();
                    }
                    sw.WriteLine(columnValue);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion
    }
}