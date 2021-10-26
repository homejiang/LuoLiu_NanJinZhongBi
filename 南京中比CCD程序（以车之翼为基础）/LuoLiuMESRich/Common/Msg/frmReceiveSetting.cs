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
    public partial class frmReceiveSetting : Common.frmBaseEdit
    {
        public frmReceiveSetting()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Msg _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Msg BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new Common.BLLDAL.Msg();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData(string sUserCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("SELECT *,dbo.Msg_GetMsgType(MsgArg) AS MsgDesc FROM Msg_Sys_Users WHERE userCode='{0}'"
                    , sUserCode.Replace("'", "''")));
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

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中你要删除的行");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("您确定要移除选中的数据吗？")) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            for (int i = list.Count; i > 0; i--)
            {
                dt.DefaultView[i - 1].Row.Delete();
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strArg = string.Empty;
            foreach (DataRowView drv in dt.DefaultView)
            {
                strArg += drv.Row["MsgArg"].ToString() + "|";
            }
            Msg.frmSelectMsgTye frm = new frmSelectMsgTye();
            frm._SelectedArgs = strArg;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm.SelectedData.Count == 0) return;
            foreach (Msg.frmSelectMsgTye.SelectedMsgType info in frm.SelectedData)
            {
                DataRow drNew = dt.NewRow();
                drNew["UserCode"] = this.PrimaryValue;
                drNew["MsgArg"] = info.Arg;
                drNew["MsgDesc"] = info.MsgDesc;
                dt.Rows.Add(drNew);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            try
            {
                this.BllDAL.SaveReceiveSetting(dt);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("保存成功。");
            this.BindData(this.PrimaryValue.ToString());
        }

        private void frmReceiveSetting_Load(object sender, EventArgs e)
        {
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                this.ShowMsg("用户代码未传入。");
                this.button1.Enabled = false;
                return;
            }
            this.button1.Enabled = this.Perinit() && this.BindData(this.PrimaryValue.ToString());
        }
    }
}