using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.BOM
{
    public partial class frmPackageList : Common.frmBaseList
    {
        string _ClassCode = BasicEntitys.SysDefaultValues.SysBOMProductClass.Package;
        public frmPackageList()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.BOMBase _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        private BLLDAL.BOMBase BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.BOMBase();
                return _dal;
            }
        }
        #endregion
        
        #region ������
        private bool PerInit()
        {
            #region ����������
            List<Common.MyEntity.SearchLabelItem> listSearchItem = new List<Common.MyEntity.SearchLabelItem>();
            //��ӹ��
            Common.MyEntity.SearchLabelItem item = new Common.MyEntity.SearchLabelItem();
            item.TitleName = "���";
            item.Value = 1;
            item.UseLike = true;
            item.StringFormat = "Spec LIKE '%{0}%'";
            item.CanInput = true;
            item.DropdownItemsLoaded = true;
            listSearchItem.Add(item);
            this.ToolBarDropdownTitles_Bind(this.tsdropSearchTitle, listSearchItem);
            #endregion
            
            //���б��ֶ�
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.BOM);
            this.dgvList.AutoGenerateColumns = false;
            //�󶨰汾����
            BasicData.BLLDAL.BOMBase Bombase = new BLLDAL.BOMBase();
            Bombase.BindVersionDropDownList(this._ClassCode, this.tscomVersion.ComboBox);
            this.tscomVersion.ComboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            return true;
        }
        private bool BindData()
        {
            string strSort = string.Empty;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt != null)
                strSort = dt.DefaultView.Sort;
            if (strSort.Length == 0)
                strSort = "  Spec ASC";
            string strSql = string.Format("SELECT * FROM [V_BOMManage_GetProductList] WHERE ClassCode='{0}'"
                , this._ClassCode.Replace("'", "''"));
            Common.MyEntity.ComboBoxItem item = this.tscomVersion.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString() != string.Empty)
                strSql += string.Format(" AND VersionID={0}", item.Value.ToString());
            if (this.tsComboSearchValue.Text.Length > 0)
            {
                Common.MyEntity.SearchLabelItem selItem = this.ToolBarDropdownTitles_GetSearchLabelItem(this.tsdropSearchTitle);
                if (selItem != null )
                {
                    //��ӹ���������
                    strSql += " AND " + string.Format(selItem.StringFormat, this.tsComboSearchValue.Text.Replace("'", "''"));
                }
            }
            strSql += " ORDER BY " + strSort;
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
        #region  ��д���ຯ��
        /// <summary>
        /// ˢ�µ�ǰ����
        /// </summary>
        /// <returns></returns>
        public override bool RefreshParetForm(object objArg)
        {
            return this.BindData();
        }
        public override void ToolBarDropdownTitlesClick_Pro(object objOrginal, object objNew)
        {
            Common.MyEntity.SearchLabelItem item = objNew as Common.MyEntity.SearchLabelItem;
            if (item == null) return;
            this.tsComboSearchValue.Items.Clear();
            if (!item.DropdownItemsLoaded)
            {
                //��������
                
            }
            if (item.DropdownItems != null)
            {
                foreach (string str in item.DropdownItems)
                    this.tsComboSearchValue.Items.Add(str);
            }
            if (item.CanInput)
            {
                if (this.tsComboSearchValue.DropDownStyle != ComboBoxStyle.DropDown)
                    this.tsComboSearchValue.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                if (this.tsComboSearchValue.DropDownStyle != ComboBoxStyle.DropDownList)
                    this.tsComboSearchValue.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        #endregion
        #region �������¼�
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvList.SelectedRows.Count == 0) return;
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("�Բ�����û�д�ģ���ɾ��Ȩ�ޡ�");
                return;
            }
            if (!this.IsUserConfirm("��ȷ��Ҫɾ��ѡ�е�ģ����")) return;
            string strGuid;
            string strMsg;
            int iReturnValue;
            int ideletedCount = 0;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strGuid = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["GUID"].ToString();
                try
                {
                    this.BllDAL.Detele(strGuid, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    continue;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "ģ��ɾ��ʧ�ܣ�ԭ��δ֪��";
                    this.ShowMsg(strMsg);
                    continue;
                }
                ideletedCount++;
            }
            if (ideletedCount > 0)
                this.BindData();
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strGuid;
            string strSpec;//�����ʾTabpage�ı�����
            //������ѡ�е���
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("�Բ���һ�������ֻ�ܴ�{0}�����ݡ�", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strGuid = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Guid"].ToString();
                strSpec = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Spec"].ToString();
                if (strGuid == string.Empty) continue;
                this.OpenEdit(strGuid, strSpec);
            }
        }
        private void OpenEdit(string sGuid,string sSpec)
        {
            frmPackage frm = new frmPackage(sGuid);
            frm.FormParent = this;
            //У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM, sGuid);
            if (listPower.Count == 0)
            {
                this.ShowMsg("��û��Ȩ�޴򿪣���Ϊ��û�������κ�Ȩ�ޡ�");
                return;
            }
            if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.Text = "��ذ�" + sSpec;
                this.ShowChildForm(frm.Text, frm);
            }
            else
            {
                frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm.Text = string.Format("��ذ�{0}��ֻ����", sSpec);
                this.ShowChildForm(frm.Text, frm);
            }
        }
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //��У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("��û���½���Ȩ�ޣ�������Ҫ����ϵ����Ա���Ÿ�Ȩ�ޡ�");
                return;
            }
            frmPackage frm = new frmPackage(string.Empty);
            frm.FormParent = this;
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.Text = "�½���ذ�BOM�ṹ";
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsComboSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.tsbSearch_Click(null, null);
        }
        #endregion
        #region �������
        private void �߼�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void �б���ʾ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DataGridViewSetting(Common.MyEnums.Modules.None, this.dgvList);
        }
        #endregion   
        #region �б��¼�
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strStrandGuid;
            string strSpec;//�����ʾTabpage�ı�����
            strStrandGuid = dt.DefaultView[e.RowIndex].Row["Guid"].ToString();
            strSpec = dt.DefaultView[e.RowIndex].Row["Spec"].ToString();
            if (strStrandGuid == string.Empty) return;
            this.OpenEdit(strStrandGuid, strSpec);
        }
        #endregion
        #region ����OnLoad�¼�
        private void frmStrandList_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            this.BindData();
        }
        #endregion
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("��û���½���Ȩ�ޣ�������Ҫ����ϵ����Ա���Ÿ�Ȩ�ޡ�");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("������ѡ��һ��!");
                return;
            }
            if (list.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("�Բ���һ�������ֻ��ѡ��{0}�����ݡ�", _MaxOpenRows));
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            foreach (int row in list)
            {
                frmPackage frm = new frmPackage(dt.DefaultView[row].Row["GUID"].ToString());
                frm.FormParent = this;
                frm.FormState = Common.MyEnums.FormStates.Copy;
                //ע����ΪҪͬʱ�򿪶�����壬���Դ�������ֱ���Ҫ��һ����������ù������������
                frm.Text = "���Ƶ�ذ�(" + dt.DefaultView[row].Row["Spec"].ToString() + ")";
                this.ShowChildForm(frm.Text, frm);
            }
        }
    }
}