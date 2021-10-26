using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common.MyEnums;
namespace LuoLiuMES.PlanM
{
    public partial class frmPlanSimpleEdit : Common.frmBase
    {
        public frmPlanSimpleEdit()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        public BLLDAL.PlanM _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        public BLLDAL.PlanM BllDAL
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
        /// <summary>
        /// ������
        /// </summary>
        public string PactCode = string.Empty;
        #endregion
        #region ������
        private bool Perinit()
        {
            this.dgvDetail.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData(string sPactCode)
        {
            //AddCount
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_Pact_frmPlanSimpleEdit WHERE PactCode='{0}'", sPactCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            dt.Columns.Add("AddCount", Type.GetType("System.Int32"));
            dt.Columns.Add("PlanDate", Type.GetType("System.DateTime"));
            this.dgvDetail.DataSource = dt;
            return true;
        }
        
        #endregion

        private void btTrue_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("��û�мƻ��ı༭Ȩ�ޣ��޷��ύ���ݡ�");
                return;
            }
            
            DataTable dt=this.dgvDetail.DataSource as DataTable;
            if(dt==null)
            {
                this.ShowMsg("����Դ��ʧ�������´򿪡�");
                return;
            }
            DataRow[] drs;
            drs=dt.Select("isnull(AddCount,0)>0");
            if(drs.Length==0)
            {
                this.ShowMsg("����δ���üƻ�������������");
                return;
            }
            drs=dt.Select("isnull(AddCount,0)>0 AND PlanDate IS NULL");
            if(drs.Length>0)
            {
                this.ShowMsg("�����üƻ�����ʱ�䡣\r\n�Ա���Ա�ܰ������ļƻ�����ʱ�䡣");
                return;
            }
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.SavePlanSimple(dt, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "�ύ����ԭ��δ֪��";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

       

        private void frmPlanSimpleEdit_Load(object sender, EventArgs e)
        {
            Perinit();
            BindData(this.PactCode);
        }

    }
}