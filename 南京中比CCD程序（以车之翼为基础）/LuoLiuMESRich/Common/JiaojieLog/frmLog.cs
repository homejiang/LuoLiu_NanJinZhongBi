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
    public partial class frmLog : Common.frmBaseEdit
    {
        public frmLog()
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
        public string _TypeName = string.Empty;
        public string _MacCode = string.Empty;
        public bool _IsUpdated = false;
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM ERPGenius_Sys_JJieLogType WHERE Code='{0}'", _TypeCode.Replace("'", "''")), "ERPGenius_Sys_JJieLogType", false));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["ERPGenius_Sys_JJieLogType"];
            if (dt.Rows.Count > 0)
            {
                this._TypeName = dt.Rows[0]["TypeName"].ToString();
            }
            this.btSave.Enabled = this.FormState != Common.MyEnums.FormStates.Readonly;
            return true;
        }
        private bool BindData(string sGUID)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM ERPGenius_JJieLog WHERE GUID='{0}'", sGUID.Replace("'", "''")), "ERPGenius_JJieLog", false));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM ERPGenius_JJieLogDetail WHERE PGuid='{0}' ORDER BY SortID ASC", sGUID.Replace("'", "''")), "ERPGenius_JJieLogDetail", false));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            ds.Tables["ERPGenius_JJieLogDetail"].Columns["ID"].AutoIncrement = true;
            ds.Tables["ERPGenius_JJieLogDetail"].DefaultView.Sort = "SortID ASC";
            DataTable dt = ds.Tables["ERPGenius_JJieLog"];
            if (dt.DefaultView.Count == 0)
            {
                if (sGUID.Length > 0)
                {
                    this.ShowMsg("数据不存在或已经被删除。");
                    return false;
                }
                string strNewGuid = Guid.NewGuid().ToString();
                DataRow drNew = dt.NewRow();
                drNew["GUID"] = strNewGuid;
                drNew["Creater"] = Common.CurrentUserInfo.UserCode;
                drNew["CreaterName"] = Common.CurrentUserInfo.UserName;
                drNew["TypeCode"] = this._TypeCode;
                drNew["MacCode"] = this._MacCode;
                dt.Rows.Add(drNew);
                #region 添加默认的明细
                DataTable dtDefault;
                try
                {
                    dtDefault = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM ERPGenius_Sys_JJieLogTypeDetail WHERE ISNULL(Terminated,0)=0 AND ISNULL(IsDefault,0)=1 AND ISNULL(PCode,'')='{0}'"
                        , this._TypeCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                int iSortID = 0;
                foreach (DataRow dr in dtDefault.Rows)
                {
                    iSortID++;
                    DataRow drDetailNew = ds.Tables["ERPGenius_JJieLogDetail"].NewRow();
                    drDetailNew["SortID"] = iSortID;
                    drDetailNew["ItemName"] = dr["ItemName"];
                    drDetailNew["PGuid"] = strNewGuid;
                    ds.Tables["ERPGenius_JJieLogDetail"].Rows.Add(drDetailNew);
                }
                #endregion
                this.Text = string.Format("{0}正在新增\"{1}\"", Common.CurrentUserInfo.UserName, this._TypeName);
                if (this.FormState == Common.MyEnums.FormStates.Readonly)
                    this.Text += "（只读）";
            }
            else
            {
                //标题
                this.Text = string.Format("编辑{0}创建的\"{1}\"", dt.DefaultView[0].Row["CreaterName"], this._TypeName);
                if (this.FormState == Common.MyEnums.FormStates.Readonly)
                    this.Text += "（只读）";
            }
            this.dgvList.DataSource = ds.Tables["ERPGenius_JJieLogDetail"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        private void btSave_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            //if (this.DataSource.GetChanges() == null)
            //{
            //    return;
            //}
            if (this.DataSource.Tables["ERPGenius_JJieLog"].DefaultView.Count == 0) return;
            string strGuid = this.DataSource.Tables["ERPGenius_JJieLog"].DefaultView[0].Row["GUID"].ToString();
            foreach (DataRowView drv in this.DataSource.Tables["ERPGenius_JJieLogDetail"].DefaultView)
            {
                if (drv.Row["PGUID"].ToString() != strGuid)
                {
                    drv.Row["PGUID"] = strGuid;
                }
            }
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.DataSource.AcceptChanges();
            _IsUpdated = true;
            this.ShowMsg("保存成功！");
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            List<frmSelectLogTye.SelectedSysJJieLogItems> list = new List<frmSelectLogTye.SelectedSysJJieLogItems>();
            foreach (DataRowView drv in dt.DefaultView)
            {
                frmSelectLogTye.SelectedSysJJieLogItems newEntity = new frmSelectLogTye.SelectedSysJJieLogItems();
                newEntity.ItemName = drv.Row["ItemName"].ToString();
                list.Add(newEntity);
            }
            frmSelectLogTye frm = new frmSelectLogTye();
            frm._LogType = this._TypeCode;
            frm.SelectedData = list;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            int iSortID = 0;
            int itemp;
            foreach (DataRowView drv in dt.DefaultView)
            {
                if (drv.Row["SortID"].Equals(DBNull.Value)) continue;
                itemp = int.Parse(drv.Row["SortID"].ToString());
                if (itemp > iSortID)
                    iSortID = itemp;
            }
            iSortID++;
            foreach (frmSelectLogTye.SelectedSysJJieLogItems item in frm.SelectedData)
            {
                iSortID++;
                DataRow drNew = dt.NewRow();
                drNew["ItemName"] = item.ItemName;
                drNew["SortID"] = iSortID;
                dt.Rows.Add(drNew);
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中的" + list.Count.ToString() + "行数据吗？")) return;
            for (int i = list.Count; i > 0; i--)
            {
                dt.DefaultView[list[i - 1]].Row.Delete();
            }
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            int iRowIndex;
            int iRowIndex1;
            object objSort, objSort1;
            for (int i = 0; i < list.Count; i++)
            {
                iRowIndex = list[i];
                iRowIndex1 = iRowIndex - 1;
                if (iRowIndex1 < 0)
                {
                    this.ShowMsg("已经是第一行。");
                    return;
                }
                objSort = dt.DefaultView[iRowIndex].Row["SortID"];
                objSort1 = dt.DefaultView[iRowIndex1].Row["SortID"];
                dt.DefaultView[iRowIndex].Row["SortID"] = objSort1;
                dt.DefaultView[iRowIndex1].Row["SortID"] = objSort;
            }
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据。");
                return;
            }
            int iRowIndex;
            int iRowIndex1;
            object objSort, objSort1;
            for (int i = 0; i < list.Count; i++)
            {
                iRowIndex = list[i];
                iRowIndex1 = iRowIndex + 1;
                if (iRowIndex1 >= this.dgvList.Rows.Count - 1)
                {
                    this.ShowMsg("已经是最后一行。");
                    return;
                }
                objSort = dt.DefaultView[iRowIndex].Row["SortID"];
                objSort1 = dt.DefaultView[iRowIndex1].Row["SortID"];
                dt.DefaultView[iRowIndex].Row["SortID"] = objSort1;
                dt.DefaultView[iRowIndex1].Row["SortID"] = objSort;
            }
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            if (!Perinit()) return;
            if (!BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString())) return;
        }
    }
}