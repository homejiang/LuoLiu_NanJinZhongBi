using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.OutputExcel
{
    public partial class frmOutputExcel : frmBase
    {
        public frmOutputExcel()
        {
            InitializeComponent();
        }
        public DataTable _DtSource
        {
            set
            {
                if (this.dgvList.AutoGenerateColumns)
                    this.dgvList.AutoGenerateColumns = false;
                this.dgvList.DataSource = value;
            }
        }
        public string _Arg = string.Empty;
        public string _ExcelName = string.Empty;
        public static bool OutputExcel(string sType,string sValue)
        {
            return OutputExcel(sType, sValue, null);
            //DataTable dt;
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Common_GetExcelNames '{0}','{1}'"
            //        , sType.Replace("'", "''"), sValue.Replace("'", "''")));
            //}
            //catch (Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(null, ex);
            //    return false;
            //}
            //if (dt.Rows.Count == 0)
            //{
            //    MessageBox.Show("没有定义过模板。");
            //    return false;
            //}
            //string strArg = string.Empty;
            //string strExcel = string.Empty;
            //if (dt.Rows.Count == 1)
            //{
            //    strArg = dt.Rows[0]["Arg"].ToString();
            //    strExcel = dt.Rows[0]["ExcelName"].ToString();
            //}
            //else
            //{
            //    frmOutputExcel frm = new frmOutputExcel();
            //    frm._DtSource = dt;
            //    if (DialogResult.OK != frm.ShowDialog()) return false;
            //    strArg = frm._Arg;
            //    strExcel = frm._ExcelName;
            //}
            //if (strArg == string.Empty) return false;
            //frmMainBase MBase = new frmMainBase();
            //string strModule = MBase.GetExcelModule(strArg);
            //if (strModule == string.Empty) return false;
            //object[] arrObj = new object[4];
            //arrObj[0] = sValue;
            //arrObj[1] = Common.CommonDAL.DBCPrintConnString;
            //arrObj[2] = true;
            //arrObj[3] = Common.CurrentUserInfo.UserCode;
            //return Common.CommonFuns.OutputExcel(null, strModule, string.Format("{0}({1}).xls", strExcel, sValue), arrObj);
        }
        public static bool OutputExcel(string sType, string sValue,List<object> listArg)
        {
            /*  DataTable dt;
              try
              {
                  dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Common_GetExcelNames '{0}','{1}'"
                      , sType.Replace("'", "''"), sValue.Replace("'", "''")));
              }
              catch (Exception ex)
              {
                  wErrorMessage.ShowErrorDialog(null, ex);
                  return false;
              }
              if (dt.Rows.Count == 0)
              {
                  MessageBox.Show("没有定义过模板。");
                  return false;
              }
              string strArg = string.Empty;
              string strExcel = string.Empty;
              if (dt.Rows.Count == 1)
              {
                  strArg = dt.Rows[0]["Arg"].ToString();
                  strExcel = dt.Rows[0]["ExcelName"].ToString();
              }
              else
              {
                  frmOutputExcel frm = new frmOutputExcel();
                  frm._DtSource = dt;
                  if (DialogResult.OK != frm.ShowDialog()) return false;
                  strArg = frm._Arg;
                  strExcel = frm._ExcelName;
              }
              */
            string strArg = string.Empty;
            string strExcel = string.Empty;
            if (!GetExcelInfo(sType, sValue, out strArg, out strExcel)) return false;
            if (strArg == string.Empty) return false;
            return SetExcelInfo(strArg, sValue, string.Format("{0}({1}).xls", strExcel, sValue), listArg);
            /*frmMainBase MBase = new frmMainBase();
            string strModule = MBase.GetExcelModule(strArg);
            if (strModule == string.Empty) return false;
            if (listArg == null) listArg = new List<object>();
            if (listArg.Count == 0)
                listArg.Add(sValue);
            object[] arrObj = new object[listArg.Count + 3];
            for (int i = 0; i < listArg.Count; i++)
            {
                arrObj[i] = listArg[i];
            }
            arrObj[listArg.Count] = Common.CommonDAL.DBCPrintConnString;
            arrObj[listArg.Count + 1] = true;
            arrObj[listArg.Count + 2] = Common.CurrentUserInfo.UserCode;
            return Common.CommonFuns.OutputExcel(null, strModule, string.Format("{0}({1}).xls", strExcel, sValue), arrObj);*/
        }
        public static bool SetExcelInfo(string sArg,string sValue,string sTargetFileName, List<object> listArg)
        {
            frmMainBase MBase = new frmMainBase();
            string strModule = MBase.GetExcelModule(sArg);
            if (strModule == string.Empty) return false;
            if (listArg == null) listArg = new List<object>();
            if (listArg.Count == 0)
                listArg.Add(sValue);
            object[] arrObj = new object[listArg.Count + 3];
            for (int i = 0; i < listArg.Count; i++)
            {
                arrObj[i] = listArg[i];
            }
            arrObj[listArg.Count] = Common.CommonDAL.DBCPrintConnString;
            arrObj[listArg.Count + 1] = true;
            arrObj[listArg.Count + 2] = Common.CurrentUserInfo.UserCode;
            return Common.CommonFuns.OutputExcel(null, strModule, sTargetFileName, arrObj);
        }
        public static bool GetExcelInfo(string sType,string sValue,out string sArg,out string sExcel)
        {
            sArg = "";
            sExcel = "";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Common_GetExcelNames '{0}','{1}'"
                    , sType.Replace("'", "''"), sValue.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("没有定义过模板。");
                return false;
            }
            if (dt.Rows.Count == 1)
            {
                sArg = dt.Rows[0]["Arg"].ToString();
                sExcel = dt.Rows[0]["ExcelName"].ToString();
            }
            else
            {
                frmOutputExcel frm = new frmOutputExcel();
                frm._DtSource = dt;
                if (DialogResult.OK != frm.ShowDialog()) return false;
                sArg = frm._Arg;
                sExcel = frm._ExcelName;
            }
            return true;
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            this._Arg = dr["Arg"].ToString();
            this._ExcelName = dr["ExcelName"].ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            this._Arg = dr["Arg"].ToString();
            this._ExcelName = dr["ExcelName"].ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
