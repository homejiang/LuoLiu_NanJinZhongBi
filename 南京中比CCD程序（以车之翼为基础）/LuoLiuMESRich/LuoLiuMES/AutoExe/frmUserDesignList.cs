using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmUserDesignList : Common.frmBaseList
    {
        public frmUserDesignList()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        public string _DesignGuid = string.Empty;
        #region ������
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_AutoExe_User_Designs_List WHERE UserCode='{0}' ORDER BY DesignName asc"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''")));
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

        private void frmUserDesignList_Load(object sender, EventArgs e)
        {
            this.dgvList.AutoGenerateColumns = false;
            this.BindData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog(this);
            this.BindData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("��ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            bool blTb;
            DataTable dtTb;
            try
            {
                dtTb = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TongBuGuid FROM AutoExe_User_Designs WHERE GUID='{0}'"
                    , dr["GUID"].ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dtTb.Rows.Count == 0)
            {
                this.ShowMsg("���������ڻ��Ѿ���ɾ����");
                return;
            }
            if (dtTb.Rows[0]["TongBuGuid"].ToString() != string.Empty)
            {
                frmUserTongbu frm = new frmUserTongbu();
                frm._UserCode = Common.CurrentUserInfo.UserCode;
                frm.PrimaryValue = dr["GUID"].ToString();
                if (DialogResult.OK != frm.ShowDialog(this))
                    return;
            }
            else
            {
                frmUserForms frm = new frmUserForms();
                frm._UserCode = Common.CurrentUserInfo.UserCode;
                frm.PrimaryValue = dr["GUID"].ToString();
                frm.ShowDialog(this);
            }
            this.BindData();
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("��ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("��ȷ��Ҫ�Ƴ�ѡ�е�������")) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelUserDesign(dr["GUID"].ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "ɾ��ʧ�ܣ�ԭ��δ֪��";
                this.ShowMsg(strMsg);
                return;
            }
            this.BindData();
        }

        private void tsbDefault_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("��ѡ��һ����Ҫ����ΪĬ�ϵ����ݡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.UserDesignSetDefault(dr["GUID"].ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }

        private void tsbUse_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("��ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row;
            _DesignGuid = dr["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            _DesignGuid = dr["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserTongbu frm = new LuoLiuMES.AutoExe.frmUserTongbu();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm.PrimaryValue = string.Empty;
            if (DialogResult.OK == frm.ShowDialog(this))
            {
                this.BindData();
            }
        }
    }
}