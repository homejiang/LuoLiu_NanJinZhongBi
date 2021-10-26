using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.BackupData
{
    public partial class frmBackupDataList : Common.frmBase
    {
        public frmBackupDataList()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        public string _GUID = string.Empty;
        public string _SFGCode = string.Empty;
        public string _ProcessCode = string.Empty;
        public string _XML = string.Empty;
        private bool BindData()
        {
            string strSql = "select ID,Times,Operator,Remark from ModfiyXml WHERE 1=1";
            if (_SFGCode != string.Empty)
                strSql += string.Format(" AND SFGCode='{0}'", this._SFGCode.Replace("'", "''"));
            if (_GUID != string.Empty)
                strSql += string.Format(" AND GUID='{0}'", this._GUID.Replace("'", "''"));
            if (_ProcessCode != string.Empty)
                strSql += string.Format(" AND ProcessCode='{0}'", this._ProcessCode.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行！");
                return;
            }
            string strXml;
            if (!GetXmL(this.dgvList.SelectedRows[0].Index, out strXml)) return;
            this._XML = strXml;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool GetXmL(int iRowIndex,out string sXML)
        {
            sXML = string.Empty;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空！");
                return false;
            }
            string strID = dt.DefaultView[iRowIndex].Row["ID"].ToString();
            if (strID.Length == 0)
            {
                this.ShowMsg("目标ID为空！");
                return false;
            }
            string strSql = "select XML from ModfiyXml WHERE ID=" + strID;
            DataTable dtXML;
            try
            {
                dtXML = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dtXML.Rows.Count == 0)
            {
                this.ShowMsg("备份数据为空！");
                return false;
            }
            sXML = dtXML.Rows[0]["XML"].ToString();
            return true;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string strXml;
            if (!GetXmL(e.RowIndex, out strXml)) return;
            this._XML = strXml;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmBackupDataList_Load(object sender, EventArgs e)
        {
            if (BindData())
            {
                this.btTrue.Enabled = true;
                this.dgvList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellDoubleClick);
            }
            else this.btTrue.Enabled = false;
        }
    }
}