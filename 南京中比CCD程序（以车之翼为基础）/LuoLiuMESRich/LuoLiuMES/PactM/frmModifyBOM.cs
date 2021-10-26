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
    public partial class frmModifyBOM : Common.frmBaseEdit
    {
        public frmModifyBOM()
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
        private bool Perinit()
        {
            //�������б�
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "select GUID,Spec from V_BOM_Product_Cgy where isnull(Terminated,0)=0 ORDER BY Spec asc";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "BOM_Product", true));

            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //�������˵�
            Common.MyEntity.ComboBoxItem item;
            this.comBom.DisplayMember = "Text";
            foreach (DataRow dr in ds.Tables["bom_product"].Rows)
            {
                item = new Common.MyEntity.ComboBoxItem(dr["Spec"].ToString(), dr["GUID"].ToString());
                this.comBom.Items.Add(item);
            }

            return true;
        }
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
            this.tbOrgBOM.Text = dr["BomSpec"].ToString();
            return true;
        }
        #endregion

        private void frmDetailAdd_Load(object sender, EventArgs e)
        {
            if (this.PactDetailGuid == string.Empty) return;
            if (!Perinit()) return;
            this.BindData(this.PactDetailGuid);
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item;
            item = this.comBom.SelectedItem as Common.MyEntity.ComboBoxItem;
            string strSql = string.Format(" EXEC [Update_Pact_Detail_BOM] '{0}','{1}','{2}','{3}','{4}','{5}'"
               , item.Value.ToString(), item.Text.ToString(), this.tbOrgBOM.Text.ToString(), PactDetailGuid.Replace("'", "''"),
                Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName);
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("�����ɹ���");
            this.DialogResult = DialogResult.OK;
        }
    }
}