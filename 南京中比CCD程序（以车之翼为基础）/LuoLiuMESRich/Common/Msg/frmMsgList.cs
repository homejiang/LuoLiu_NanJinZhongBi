using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace Common.Msg
{
    public partial class frmMsgList : Common.frmBaseEdit
    {
        public frmMsgList()
        {
            InitializeComponent();
        }
        public int _RefreshInterval = 0;
        public bool _AutoRefrehs = false;//默认为自动刷新
        #region 处理函数
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("EXEC Msg_GetUserMsgList '{0}','{1}'"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''"), this.tstSearchValue.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            dt.Columns["ID"].AutoIncrement = false;
            dt.Columns["ID"].ReadOnly = false;
            dt.DefaultView.Sort = "times desc";
            this.dgvList.DataSource = dt;
            return true;
        }
        #endregion

        private void frmMsgList_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            if (_AutoRefrehs)
            {
                if (_RefreshInterval <= 0)
                    this.timer1.Interval = 30000;//默认为30秒搜索一次
                else this.timer1.Interval = _RefreshInterval;
                this.timer1.Enabled = true;
            }
            else
            {
                this.timer1.Enabled = false;
            }
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tstSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                tsbSearch_Click(null, null);
        }

        private void dgvList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt != null)
            {
                Font font = null;
                if (this.dgvList.Rows[e.RowIndex].DefaultCellStyle != null)
                    font = this.dgvList.Rows[e.RowIndex].DefaultCellStyle.Font;
                if (font == null)
                    font = this.dgvList.DefaultCellStyle.Font;
                if (font == null)
                    font = new Font("Arial", 9);
                if (dt.DefaultView[e.RowIndex].Row["IsRead"].Equals(DBNull.Value)
                    || !(bool)dt.DefaultView[e.RowIndex].Row["IsRead"])
                    font = new Font(font, FontStyle.Bold);
                else
                    font = new Font(font, FontStyle.Regular);
                if (this.dgvList.Rows[e.RowIndex].DefaultCellStyle.Font == null
                    || !this.dgvList.Rows[e.RowIndex].DefaultCellStyle.Font.Equals(font))
                    this.dgvList.Rows[e.RowIndex].DefaultCellStyle.Font = font;
            }
        }

        private void tsbRead_ButtonClick(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataTable dtCopy = dt.Copy();
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            List<long> listID = new List<long>();
            foreach (int i in list)
            {
                listID.Add(long.Parse(dtCopy.DefaultView[i].Row["ID"].ToString()));
            }
            string strSql;
            DataRow[] drs;
            foreach (long l in listID)
            {
                strSql = string.Format("UPDATE Msg_Detail set IsRead=1 where id={0}", l);
                try
                {
                    Common.CommonDAL.DoSqlCommandLog.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                drs = dtCopy.Select("ID=" + l.ToString());
                if (drs.Length > 0 && (drs[0]["IsRead"].Equals(DBNull.Value) || !(bool)drs[0]["IsRead"]))
                    drs[0]["IsRead"] = true;
            }
            if (dtCopy.GetChanges() != null)
            {
                dtCopy.AcceptChanges();
                this.dgvList.DataSource = dtCopy;
            }
        }

        private void tsbUnRead_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataTable dtCopy = dt.Copy();
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            List<long> listID = new List<long>();
            foreach (int i in list)
            {
                listID.Add(long.Parse(dtCopy.DefaultView[i].Row["ID"].ToString()));
            }
            string strSql;
            DataRow[] drs;
            foreach (long l in listID)
            {
                strSql = string.Format("UPDATE Msg_Detail set IsRead=0 where id={0}", l);
                try
                {
                    Common.CommonDAL.DoSqlCommandLog.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                drs = dtCopy.Select("ID=" + l.ToString());
                if (drs.Length > 0 && !drs[0]["IsRead"].Equals(DBNull.Value) && (bool)drs[0]["IsRead"])
                    drs[0]["IsRead"] = false;
            }
            if (dtCopy.GetChanges() != null)
            {
                dtCopy.AcceptChanges();
                this.dgvList.DataSource = dtCopy;
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataTable dtCopy = dt.Copy();
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请至少选中一行。");
                return;
            }
            if (!this.IsUserConfirm("您确定要移除选中的" + list.Count.ToString() + "行数据吗？")) return;
            List<long> listID = new List<long>();
            foreach (int i in list)
            {
                listID.Add(long.Parse(dtCopy.DefaultView[i].Row["ID"].ToString()));
            }
            List<string> listSql;
            DataRow[] drs;
            foreach (long l in listID)
            {
                listSql = new List<string>();
                listSql.Add(string.Format(@"INSERT INTO Msg_Detail_Recycle (UserCode,UserName,MsgID,Times)
                        SELECT UserCode,UserName,MsgID,getdate()
                        FROM Msg_Detail where id={0}", l));
                listSql.Add(string.Format("DELETE FROM Msg_Detail where id={0}", l));
                try
                {
                    Common.CommonDAL.DoSqlCommandLog.DoSql(listSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                drs = dtCopy.Select("ID=" + l.ToString());
                if (drs.Length > 0)
                    drs[0].Delete();
            }
            dtCopy.AcceptChanges();
            this.dgvList.DataSource = dtCopy;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.RefreshData();
        }
        private bool RefreshData()
        {
            DataTable dtSource = this.dgvList.DataSource as DataTable;
            if (dtSource == null) return this.BindData();

            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("EXEC Msg_GetUserMsgList '{0}','{1}'"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''"), this.tstSearchValue.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                throw (ex);
                //wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            string strSort = dtSource.DefaultView.Sort;
            if (strSort == string.Empty)
                strSort = "times desc";
            foreach (DataRow dr in dt.Rows)
            {
                if (dtSource.Select("ID=" + dr["ID"].ToString()).Length == 0)
                {
                    DataRow drNew = dtSource.NewRow();
                    drNew["ID"] = dr["ID"];
                    drNew["IsRead"] = dr["IsRead"];
                    drNew["OperatorName"] = dr["OperatorName"];
                    drNew["LogText"] = dr["LogText"];
                    drNew["times"] = dr["times"];
                    dtSource.Rows.Add(drNew);
                }
            }
            if (string.Compare(dtSource.DefaultView.Sort, strSort, true) != 0)
                dtSource.DefaultView.Sort = strSort;
            return true;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            long lTemp;
            if (!long.TryParse(dt.DefaultView[e.RowIndex]["MsgID"].ToString(), out lTemp))
                return;
            Msg.frmMsgInfo frm = new frmMsgInfo();
            frm._ID = lTemp;
            frm.Show();
            if (dt.DefaultView[e.RowIndex]["IsRead"].Equals(DBNull.Value) || !(bool)dt.DefaultView[e.RowIndex]["IsRead"])
                SetRowRead(e.RowIndex);
        }
        private bool SetRowRead(int iRowindex)
        {
            //设置单行是否已读
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return false;
            if (dt.DefaultView[iRowindex]["IsRead"].Equals(DBNull.Value) || !(bool)dt.DefaultView[iRowindex]["IsRead"])
            {
                dt.DefaultView[iRowindex]["IsRead"] = true;
                string strSql = string.Format("UPDATE Msg_Detail set IsRead=1 where id={0}", dt.DefaultView[iRowindex]["ID"]);
                try
                {
                    Common.CommonDAL.DoSqlCommandLog.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
            }
            //标示为普通字体
            Font font = null;
            if (this.dgvList.Rows[iRowindex].DefaultCellStyle != null)
                font = this.dgvList.Rows[iRowindex].DefaultCellStyle.Font;
            if (font == null)
                font = this.dgvList.DefaultCellStyle.Font;
            if (font == null)
                font = new Font("Arial", 9);
            if (dt.DefaultView[iRowindex].Row["IsRead"].Equals(DBNull.Value)
                || !(bool)dt.DefaultView[iRowindex].Row["IsRead"])
                font = new Font(font, FontStyle.Bold);
            else
                font = new Font(font, FontStyle.Regular);
            if (this.dgvList.Rows[iRowindex].DefaultCellStyle.Font == null
                || !this.dgvList.Rows[iRowindex].DefaultCellStyle.Font.Equals(font))
            {
                this.dgvList.Rows[iRowindex].DefaultCellStyle.Font = font;
                this.dgvList.InvalidateRow(iRowindex);//重绘此行
            }
            return true;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!dt.DefaultView[e.RowIndex]["IsRead"].Equals(DBNull.Value) && (bool)dt.DefaultView[e.RowIndex]["IsRead"])
                return;
            SetRowRead(e.RowIndex);
        }
    }
}