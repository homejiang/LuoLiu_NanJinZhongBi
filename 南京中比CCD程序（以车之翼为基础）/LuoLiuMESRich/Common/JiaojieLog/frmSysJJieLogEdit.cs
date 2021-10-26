using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.JiaojieLog
{
    public partial class frmSysJJieLogEdit : Common.frmBaseEdit
    {
        public frmSysJJieLogEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.JiaoJieLog _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.JiaoJieLog BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.JiaoJieLog();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public string _TypeCode = string.Empty;
        #endregion
        #region 重写函数
        public override void InitParameters(string[] arrs)
        {
            this._TypeCode = arrs[0];
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindList()
        {
            DataTable dt;
            string strSql = "SELECT * FROM ERPGenius_Sys_JJieLogType WHERE 1=1";
            if (_TypeCode != string.Empty)
                strSql += string.Format(" AND Code='{0}' ", _TypeCode.Replace("'", "''"));
            strSql += " ORDER BY TypeName ASC";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.listType.DisplayMember = "Text";
            this.listType.ValueMember = "Value";
            foreach (DataRow dr in dt.Rows)
            {
                Common.MyEntity.ComboBoxItem item = new Common.MyEntity.ComboBoxItem();
                item.Text = dr["TypeName"].ToString();
                item.Value = dr["Code"].ToString();
                this.listType.Items.Add(item);
            }
            if (this._TypeCode != string.Empty && this.listType.Items.Count>0)
            {
                this.listType.SelectedIndex = 0;
            }
            return true;
        }
        private string _Code = string.Empty;
        private bool BindDetail(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM ERPGenius_Sys_JJieLogTypeDetail WHERE PCode='{0}' AND ISNULL(Terminated,0)=0 ORDER BY SortID ASC"
                    , sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            _Code = sCode;
            return true;
        }
        #endregion
        private void btSave_Click(object sender, EventArgs e)
        {
            if (_Code == string.Empty) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            for (int i = dt.DefaultView.Count; i > 0; i--)
            {
                if (dt.DefaultView[i - 1].Row["ItemName"].ToString() == string.Empty)
                    dt.DefaultView[i - 1].Row.Delete();
            }
            foreach (DataRowView drv in dt.DefaultView)
            {
                if (drv.Row["PCode"].ToString() != _Code)
                    drv.Row["PCode"] = _Code;
            }
            try
            {
                this.BllDAL.SaveSysTypeDetail(dt);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("保存成功。");
            BindDetail(_Code);
        }
        private void listType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.listType.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value==null || item.Value.ToString()==string.Empty) return;
            this.BindDetail(item.Value.ToString());
        }
        private void btDel_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            int iRowIndex;
            for (int i = list.Count; i > 0; i--)
            {
                iRowIndex = list[i - 1];
                dt.DefaultView[iRowIndex].Delete();
            }
        }
        private void frmSysJJieLogEdit_Load(object sender, EventArgs e)
        {
            this.Perinit();
            this.BindList();
        }
    }
}