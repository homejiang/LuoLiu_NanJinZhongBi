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
    public partial class frmPactList : Common.frmBaseList
    {
        public frmPactList()
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
                    _dal = new BLLDAL.PactM();
                return _dal;
            }
        }
        #endregion
        #region ������
        private bool PerInit()
        {
            #region ���ù��������ڿؼ�
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddMonths(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tslCreateTime.Name, false);//�������ڿؼ�
            #endregion
            #region ���ø��������ť
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "�߼�����";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "�б��ֶ���ʾ";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            this.InsertMyButtons(this.toolStrip1, this.tsbSearch.Name, listBarbuts,true,true);//���뵽������ť����
            this.BarSearchMyButtons.TitleChanged+=new MyControl.MyLabelExChageTitleEventHandler(BarSearchMyButtons_TitleChanged);
            #endregion
            #region ���б��ֶ�
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.None);
            #endregion
            #region ���ù�����combox��������
            //����������
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "�������";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "PatCode LIKE '{0}'";
            item.Value = 1;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "�ͻ�";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "ClientCNName LIKE '%{0}%'";
            item.Value = 2;
            listSearchItem.Add(item);

            item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "��ע";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            item.UseLike = true;
            item.StringFormat = "Remark LIKE '%{0}%'";
            item.Value = 3;
            listSearchItem.Add(item);
            ToolBarDropdownTitles_Bind(this.tsDropTitle, listSearchItem);
            #endregion
            #region ����combox�س��¼�
            this.SetBarSearchEnterKey(this.tsCombox);
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM V_Pact_Main_List WHERE 1=1";
            //����commbox��������
            if (this.tsCombox.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem shItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsDropTitle);
                if (shItem != null && shItem.StringFormat.Length > 0)
                {
                    strSql += string.Format(" AND " + shItem.StringFormat, this.tsCombox.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY CreateTime DESC";//�Ե�������
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
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
        #region �������¼�
        //combox�����л��¼�
        protected void BarSearchMyButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchButtonItem item = newItem.Tag as Common.MyEntity.SearchButtonItem;
            if (item == null) return;
            //����valueֵ��ִ�в�ͬ�Ĺ���
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.PactManager, this.dgvList);
            }
        }
        //������ť
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //��У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("��û���½�Ȩ�ޣ�������Ҫ����ϵ����Ա���Ÿ�Ȩ�ޡ�");
                return;
            }
            frmPact frm = new frmPact(this.BllDAL);
            frm.FormParent = this;
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.Text = this.BllDAL.PFuns_GetEditFromName(string.Empty, Common.MyEnums.FormStates.New);
            this.ShowChildForm(frm.Text, frm);
        }
        //�򿪰�ť
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            //������ѡ�е���
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("�Բ���һ�������ֻ�ܴ�{0}�����ݡ�", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                if (strPactCode == string.Empty) continue;
                this.OpenEditForm(strPactCode);
            }
        }
        private void OpenEditForm(string sPactCode)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            //������ѡ�е���
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("�Բ���һ�������ֻ�ܴ�{0}�����ݡ�", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                if (strPactCode == string.Empty) continue;
                frmPact frm = new frmPact(this.BllDAL);
                frm.FormParent = this;
                frm._PactCode = strPactCode;
                //У��Ȩ��
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager, strPactCode);
                if (listPower.Count == 0)
                {
                    this.ShowMsg(string.Format("��û��Ȩ�޴򿪣���Ϊ��û�������κ�Ȩ�ޡ�", strPactCode));
                    continue;
                }
                if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    frm.FormState = Common.MyEnums.FormStates.Edit;
                    frm.Text = this.BllDAL.PFuns_GetEditFromName(sPactCode, Common.MyEnums.FormStates.Edit);
                    
                    this.ShowChildForm(frm.Text, frm);
                }
                else
                {
                    frm.FormState = Common.MyEnums.FormStates.Readonly;
                    frm.Text = this.BllDAL.PFuns_GetEditFromName(sPactCode, Common.MyEnums.FormStates.Readonly);
                    this.ShowChildForm(frm.Text, frm);
                }
            }
        }
        //ɾ����ť
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "��ȷ��Ҫɾ��ѡ�е�" + this.dgvList.SelectedRows.Count.ToString() + "�������𣿴˲������ݽ����ɻָ���ȷ��Ҫ������", "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strPactCode;
            bool isDeleted = false;
            int iReturn;
            string sMsg;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strPactCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString();
                try
                {
                    this.BllDAL.PactDelete(strPactCode, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "ɾ��������" + dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["PactCode"].ToString() + "��ʧ�ܣ�ԭ��δ֪��";
                    this.ShowMsg(sMsg);
                    continue;
                }
                else if (!isDeleted)
                    isDeleted = true;
            }
            if (isDeleted)
                this.BindData();
        }
        //�رմ���
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        //������ť
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        #endregion
        #region �����¼�
        private void frmGPactList_Load(object sender, EventArgs e)
        {
            //���ж�Ȩ�ޣ��û�ֻҪ��ֻ��Ȩ�޾Ϳ��Դ�
            // ��У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PactManager);
            if (listPower.Count == 0)
            {
                this.ShowMsg("��û��Ȩ�޲鿴��ģ�飬���ڽ��Զ��رա�");
                this.FormColse();
                return;
            }
            if (!this.PerInit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region  ��д���ຯ��
        /// <summary>
        /// ˢ�µ�ǰ����
        /// </summary>
        /// <returns></returns>
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        //��д����ʱ��
        public override void DoBarSearch()
        {
            this.tsbSearch_Click(null, null);
        }
        #endregion
        #region ���б��¼�
        //˫���¼�
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strPactCode = dt.DefaultView[e.RowIndex].Row["PactCode"].ToString();
            if (strPactCode.Length == 0) return;
            this.OpenEditForm(strPactCode);
        }
        #endregion

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            //��У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("��û���½�Ȩ�ޣ�������Ҫ����ϵ����Ա���Ÿ�Ȩ�ޡ�");
                return;
            }
            if (this.dgvList.SelectedRows.Count > 1)
            {
                this.ShowMsg("���Ʋ���һ����ֻ�ܸ���һ�����񵥡�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strPactCode = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["PactCode"].ToString();
            frmPact frm = new frmPact(this.BllDAL);
            frm.FormParent = this;
            frm._PactCode = strPactCode;
            frm.FormState = Common.MyEnums.FormStates.Copy;
            frm.Text = this.BllDAL.PFuns_GetEditFromName(strPactCode, Common.MyEnums.FormStates.Copy);
            this.ShowChildForm(frm.Text, frm);
        }
    }
}