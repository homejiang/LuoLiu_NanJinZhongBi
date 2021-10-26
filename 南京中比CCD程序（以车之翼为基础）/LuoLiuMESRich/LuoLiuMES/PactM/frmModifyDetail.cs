using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace LuoLiuMES.PactM
{
    public partial class frmModifyDetail : Common.frmBaseEdit
    {
        public frmModifyDetail()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.PactM _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        private BLLDAL.PactM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.PactM();
                return _dal;
            }
        }
        #endregion
        #region ��������
        public string PactDetailGuid = string.Empty;
        #endregion
        #region ������
        private bool BindData(string sDetailGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Pact_Detail WHERE GUID='{0}'"
                    , sDetailGuid));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.DefaultView.Count == 0)
            {
                this.ShowMsg("��ѡ�е���ϸ�����ڻ��Ѿ���ɾ����");
                return false;
            }
            DataRow dr = dt.Rows[0];
            this.tbInfo.Text = string.Format("[�����ţ�{0}][������{1}][BOM���:{2}][�����ڣ�{3}][��ע��{4}]"
                , dr["PactCode"]
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["Qty"], "#########0"), dr["BomSpec"]
                , Common.CommonFuns.FormatData.GetStringByDateTime(dr["DeliveryDate"], "yyyy-MM-dd"), dr["Remark"]);
            this.tbOrgQty.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["Qty"], "#########0");
            return true;
        }
        #endregion

        private void frmDetailAdd_Load(object sender, EventArgs e)
        {
            if (this.PactDetailGuid == string.Empty) return;
            this.BindData(this.PactDetailGuid);
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            int iPans;
            if (this.numPans.Text == string.Empty || !int.TryParse(this.numPans.Text, out iPans))
                return;
            if (iPans <= 0) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.PactDetailModify(this.PactDetailGuid, iPans, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "����ʧ�ܣ�ԭ��δ֪��";
                this.ShowMsg(strMsg);
                return;
            }
            this.ShowMsg("�����ɹ���");
            this.DialogResult = DialogResult.OK;
        }
    }
}