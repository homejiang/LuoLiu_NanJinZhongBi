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
    public partial class frmBOMStructDetail : Common.frmBase
    {
        public frmBOMStructDetail()
        {
            InitializeComponent();
            this.dgvSFG.AutoGenerateColumns = true;
            this.dgvMaterial.AutoGenerateColumns = true;
        }
        private string _Spec = string.Empty;
        private void frmBOMStructDetail_Load(object sender, EventArgs e)
        {
            DataSet ds;
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(string.Format("EXEC BOMManage_GetStructDetail '{0}'"
                    , this.PrimaryValue.ToString().Replace("'", "''")), false);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.dgvSFG.DataSource = ds.Tables[0];
            this.dgvMaterial.DataSource = ds.Tables[1];
        }

        private void linkSFGOutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._Spec == string.Empty)
                BindSpec();
            try
            {
                this.DataGridViewToExcel(this.dgvSFG);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
        }

        private void linkMaterialOutput_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._Spec == string.Empty)
                BindSpec();
            try
            {
                this.DataGridViewToExcel(this.dgvMaterial);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
        }
        private void BindSpec()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Spec FROM BOM_Product WHERE GUID='{0}'"
                    , this.PrimaryValue.ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count > 0)
                this._Spec = dt.Rows[0]["Spec"].ToString();
        }
        #region 导出Excel

        private void DataGridViewToExcel(DataGridView dgv)
        {
            string strFileName;
            if(dgv.Equals(this.dgvSFG))
                strFileName = string.Format("{0}的子件明细.xls",this._Spec);
            else
                strFileName = string.Format("{0}的所需原材料.xls", this._Spec);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}