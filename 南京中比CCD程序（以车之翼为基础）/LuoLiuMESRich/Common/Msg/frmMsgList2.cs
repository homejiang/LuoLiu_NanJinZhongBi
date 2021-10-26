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
    public partial class frmMsgList2 : Common.frmBaseList
    {
        public frmMsgList2()
        {
            InitializeComponent();
        }
        #region 公共属性
        public string _Args = string.Empty;//消息类型
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            #region 设置工具栏日期控件
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddDays(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.labTime.Name, false);//插入日期控件
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            tsbMsgType.Text = "所有日志";
            if (_Args.Length > 0)
            {
                this.tslinkMsgType.Visible = false;
                this.tsbMsgType.Visible = false;
                this.tsbMsgType.Tag = this._Args;
            }
            else
            {
                this.tslinkMsgType.Visible = true;
                this.tsbMsgType.Visible = true;
            }
            return true;
        }
        private bool BindData()
        {
            string strSql = "SELECT * FROM EventLogs WHERE 1=1";
            if (this.BarSearchDateTimeStart.Checked)
                strSql += " AND Times>='" + this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd") + "'";
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += " AND Times<'" + this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            if (this.tsbMsgType.Tag != null && this.tsbMsgType.Tag.ToString() != string.Empty)
            {
                string strTypes = this.tsbMsgType.Tag.ToString();
                string[] types = strTypes.Split('|');
                if (types.Length == 1)
                    strSql += " AND Arg=" + this.tsbMsgType.Tag.ToString();
                else
                {
                    strTypes = "";
                    foreach (string type in types)
                    {
                        strTypes += type + ",";
                    }
                    if (strTypes != string.Empty)
                        strTypes = strTypes.Substring(0, strTypes.Length - 1);
                    strSql += string.Format(" AND Arg in ({0})", strTypes);
                }
            }
            if (this.tstSearchValue.Text != string.Empty)
            {
                string strValue = this.tstSearchValue.Text;
                if (!strValue.StartsWith("%"))
                    strValue = "%" + strValue;
                if (!strValue.EndsWith("%"))
                    strValue += "%";
                strSql += string.Format(" AND LogText LIKE '{0}'", strValue.Replace("'", "''"));
            }
            strSql += " ORDER BY Times DESC";
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        #endregion
        #region 重写父函数
        public override void InitParameters(string[] arrs)
        {
            this._Args = arrs[0];
        }
        #endregion
        private void frmMsgList_Load(object sender, EventArgs e)
        {
            PerInit();
            //BindData();
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
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            long lTemp;
            if (!long.TryParse(dt.DefaultView[e.RowIndex]["ID"].ToString(), out lTemp))
                return;
            Msg.frmMsgInfo frm = new frmMsgInfo();
            frm._ID = lTemp;
            frm.Show();
        }
        
        private void tslinkMsgType_Click(object sender, EventArgs e)
        {
            frmSelectMsgTye frm = new frmSelectMsgTye();
            frm.MultiSelected = true;
            frm._ShowEmptyButton = true;
            string strTypes = this.tsbMsgType.Tag == null ? string.Empty : this.tsbMsgType.Tag.ToString();
            List<Common.Msg.frmSelectMsgTye.SelectedMsgType> listSel = new List<frmSelectMsgTye.SelectedMsgType>();
            Common.Msg.frmSelectMsgTye.SelectedMsgType selectedtype;
            foreach (string type in strTypes.Split('|'))
            {
                if (type == string.Empty) continue;
                selectedtype = new frmSelectMsgTye.SelectedMsgType();
                selectedtype.Arg = int.Parse(type);
                listSel.Add(selectedtype);
            }
            frm.SelectedData = listSel;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0)
            {
                this.tsbMsgType.Tag = "";
                this.tsbMsgType.Text = "所有日志";
            }
            else
            {
                strTypes = "";
                string strTypeViews = "";
                foreach (Common.Msg.frmSelectMsgTye.SelectedMsgType msgtype in frm.SelectedData)
                {
                    strTypes += msgtype.Arg.ToString() + "|";
                    strTypeViews += msgtype.MsgDesc.ToString() + "、";
                }
                if (strTypes != string.Empty)
                    strTypes = strTypes.Substring(0, strTypes.Length - 1);
                if (strTypeViews != string.Empty)
                    strTypeViews = strTypeViews.Substring(0, strTypeViews.Length - 1);
                this.tsbMsgType.Tag = strTypes;
                this.tsbMsgType.Text = strTypeViews;
            }
        }
    }
}