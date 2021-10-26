using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace LuoLiuMES.PlanM
{
    public partial class frmModifyPlanDetail : Common.frmBaseEdit
    {
        public frmModifyPlanDetail()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.PlanM _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        private BLLDAL.PlanM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.PlanM();
                return _dal;
            }
        }
        #endregion
        #region ��������
        public string PlanGuid = string.Empty;
        #endregion
        #region ������
        private bool BindData(string sPlanGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM [V_Plan_PlanDetail] WHERE GUID='{0}'"
                    , sPlanGuid));
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
            this.tbInfo.Text = string.Format("[�����ţ�{0}][����������{1}][�ƻ�����:{2}][ʣ����:{3}][BOM���:{4}][�����ڣ�{5}][��ע��{6}][�ƻ����ʱ��:{7}]"
                , dr["PactCode"]
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["Qty"], "#########0")
                , Common.CommonFuns.FormatData.GetStringByDecimal(dr["PlanProduceQty"], "#########0")
                , dr["RemainDesc"]
                , dr["BomSpec"]
                , Common.CommonFuns.FormatData.GetStringByDateTime(dr["DeliveryDate"], "yyyy-MM-dd")
                ,dr["Remark"]
                ,Common.CommonFuns.FormatData.GetStringByDateTime(dr["PlanTime"], "yyyy-MM-dd"));
            this.tbOrgQty.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["PlanProduceQty"], "#########0");
            return true;
        }
        #endregion

        private void frmDetailAdd_Load(object sender, EventArgs e)
        {
            if (this.PlanGuid == string.Empty) return;
            this.BindData(this.PlanGuid);
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
                this.BllDAL.PlanDetailModify(this.PlanGuid, iPans, out strMsg, out iReturnValue);
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

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbOrgDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}