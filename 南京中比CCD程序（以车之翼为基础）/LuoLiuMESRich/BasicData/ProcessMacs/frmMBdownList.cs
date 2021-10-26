using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.ProcessMacs
{
    public partial class frmMBdownList : Common.frmBaseList
    {
        public frmMBdownList()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.MacBreakdown _dal = null;
        /// <summary>
        /// ������������ʵ��
        /// </summary>
        private BLLDAL.MacBreakdown BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdown();
                return _dal;
            }
        }
        #endregion
        #region ��������
        /// <summary>
        /// Ĭ�Ϲ���
        /// </summary>
        public string DefaultProcess = string.Empty;
        /// <summary>
        /// �̶�����
        /// </summary>
        public bool FixProcess = false;
        /// <summary>
        /// Ĭ�ϻ�̨
        /// </summary>
        public string DefaultMac = string.Empty;
        #endregion
        #region ������
        private bool PerInit()
        {
            #region ���ù��������ڿؼ�
            this.BarSearchDateTimeStart.Value = DateTime.Now.AddMonths(-1);
            this.BarSearchDateTimeStart.Checked = true;
            this.BarSearchDateTimeEnd.Value = DateTime.Now;
            this.BarSearchDateTimeEnd.Checked = false;
            this.InsertDateTimePicker(this.toolStrip1, this.tslStartTime.Name, false);//�������ڿؼ�
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
            this.ShowDataGridViewSetting_BindColumn(this.dgvList, Common.MyEnums.Modules.MacBreakdown);
            #endregion
            #region �󶨻�̨������
            if (this.DefaultMac.Length > 0)
            {
                #region ��������˻�̨Ҫ�Ի�̨Ϊ׼
                DataTable dtMac = null;
                try
                {
                    dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select MacName,ProcessName,ProcessCode from V_JC_ProcessMacs where Code='{0}' AND isnull(Terminated,0)=0 order by Sortid asc", this.DefaultMac.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtMac.Rows.Count == 0)
                {
                    this.ShowMsg("�豸����\"" + DefaultMac + "\"�����ڻ��Ѿ���ɾ����");
                    return false;
                }
                this.tscMac.ComboBox.DisplayMember = "Text";
                this.tscMac.ComboBox.ValueMember = "Value";
                this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dtMac.Rows[0]["MacName"].ToString(), DefaultMac));
                this.tscMac.SelectedIndex = 0;
                //���ù���
                this.tscProcess.ComboBox.DisplayMember = "Text";
                this.tscProcess.ComboBox.ValueMember = "Value";
                this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dtMac.Rows[0]["ProcessName"].ToString(), dtMac.Rows[0]["ProcessCode"].ToString()));
                this.tscProcess.SelectedIndex = 0;
                #endregion
            }
            else
            {
                #region �󶨹���
                DataTable dtProcess = null;
                try
                {
                    dtProcess = Common.CommonDAL.DoSqlCommand.GetDateTable("select Code,ProcessName from JC_Process where isnull(Terminated,0)=0 order by Sortid asc");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                this.tscProcess.ComboBox.DisplayMember = "Text";
                this.tscProcess.ComboBox.ValueMember = "Value";
                this.tscProcess.SelectedIndexChanged += new EventHandler(tscProcess_SelectedIndexChanged);
                int iSelIndex = -1;
                foreach (DataRow dr in dtProcess.Rows)
                {
                    if (string.Compare(this.DefaultProcess, dr["Code"].ToString(), true) == 0)
                        iSelIndex = this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                    else this.tscProcess.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                }
                this.tscProcess.ComboBox.SelectedIndex = iSelIndex;
                this.tscProcess.ComboBox.Enabled = !this.FixProcess;
                #endregion
            }
            #endregion
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData()
        {
            string strSql;
            strSql = "SELECT * FROM V_JC_MacBreakdown_List WHERE 1=1";
            //����ʱ������
            if (this.BarSearchDateTimeStart.Checked)
                strSql += " AND StartTime>='" + this.BarSearchDateTimeStart.Value.ToString("yyyy-MM-dd") + "'";
            if (this.BarSearchDateTimeEnd.Checked)
                strSql += " AND StartTime<'" + this.BarSearchDateTimeEnd.Value.AddDays(1).ToString("yyyy-MM-dd") + "'";
            
            Common.MyEntity.ComboBoxItem item = this.tscMac.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString().Length > 0)
                strSql += string.Format(" AND MacCode='{0}'", item.Value.ToString().Replace("'", "''"));
            else
            {
                item = this.tscProcess.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item != null && item.Value != null && item.Value.ToString().Length > 0)
                    strSql += string.Format(" AND ProcessCode='{0}'", item.Value.ToString().Replace("'", "''"));
            }
            strSql += " ORDER BY StartTime DESC";//�Ե�������
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
                this.DataGridViewSetting(Common.MyEnums.Modules.MacBreakdown, this.dgvList);
            }
        }
        //������ť
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            //��У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("��û���½��豸�쳣����Ȩ�ޣ�������Ҫ����ϵ����Ա���Ÿ�Ȩ�ޡ�");
                return;
            }
            if (this.DefaultMac.Length > 0)
            {
                #region У���Ƿ�˻�̨����ͣ��ά�޵�δ����
                DataTable dttemp;
                try
                {
                    dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC JC_MacBreakdown_CheckIsMacTerminated '','{0}','{1}'"
                        , this.DefaultMac.Replace("'", "''"), Common.CurrentUserInfo.UserCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (dttemp.Rows.Count > 0 && dttemp.Columns.Contains("ErrMsg"))
                {
                    this.ShowMsg(dttemp.Rows[0]["ErrMsg"].ToString());
                    return;
                }
                #endregion
            }
            frmMBdownEdit frm = new frmMBdownEdit();
            frm.MacCode = this.DefaultMac;
            frm.ProcessCode = this.DefaultProcess;
            frm.FormParent = this;
            frm.FormState = Common.MyEnums.FormStates.New;
            frm.Text = "�½��豸�쳣��";
            frm.TopMost = true;
            frm.ShowDialog(this);
            if (frm.Updated)
                this.BindData();
            //this.ShowChildForm(frm.Text, frm);
        }
        //�򿪰�ť
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
            if (listPower.Count == 0)
            {
                this.ShowMsg("��û�и�ģ����κ�Ȩ�ޡ�");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            //������ѡ�е���
            if (this.dgvList.SelectedRows.Count > _MaxOpenRows)
            {
                this.ShowMsg(string.Format("�Բ���һ�������ֻ�ܴ�{0}�����ݡ�", _MaxOpenRows));
                return;
            }
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                if (strCode == string.Empty) continue;
                this.OpenEditForm(strCode);
            }
        }
        private void OpenEditForm(string sCode)
        {
            frmMBdownEdit frm = new frmMBdownEdit();
            frm.FormParent = this;
            frm.MacCode = this.DefaultMac;
            //У��Ȩ��
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown, sCode);
            if (listPower.Count == 0)
            {
                this.ShowMsg(string.Format("��û���豸�쳣��{0}���κ�Ȩ�ޡ�", sCode));
                return;
            }
            if (listPower.Contains(Common.MyEnums.OperatePower.New) || listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                frm.FormState = Common.MyEnums.FormStates.Edit;
                frm.Text = "�豸�쳣��" + sCode;
                frm.PrimaryValue = sCode;
            }
            else
            {
                frm.FormState = Common.MyEnums.FormStates.Readonly;
                frm.Text = string.Format("�豸�쳣��{0}��ֻ����", sCode);
                frm.PrimaryValue = sCode;
            }
            frm.TopMost = true;
            frm.ShowDialog(this);
            if (frm.Updated)
                this.BindData();
        }
        //ɾ����ť
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0 || DialogResult.Yes != MessageBox.Show(this, "��ȷ��Ҫɾ��ѡ�е�" + this.dgvList.SelectedRows.Count.ToString() + "�������𣿴˲������ݽ����ɻָ���ȷ��Ҫ������", "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strCode;
            bool isDeleted = false;
            int iReturn;
            string sMsg;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                strCode = dt.DefaultView[this.dgvList.SelectedRows[i].Index].Row["Code"].ToString();
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown, strCode);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
                {
                    this.ShowMsg(string.Format("��û��Ȩ��ɾ���豸�쳣����{0}����", strCode));
                    continue;
                }
                try
                {
                    this.BllDAL.Detele(strCode, out sMsg, out iReturn);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "�豸�쳣����" + strCode + "��ɾ�����ɹ�����δ�ܻ�ȡ����ԭ�򣬿��������Ա��ϵ����ԭ��";
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
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.MacBreakdown);
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
        public override void InitParameters(string[] arrs)
        {
            this.DefaultProcess = arrs[0];
        }
        #endregion
        #region ���б��¼�
        //˫���¼�
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            string strCode = dt.DefaultView[e.RowIndex].Row["Code"].ToString();
            if (strCode.Length == 0) return;
            this.OpenEditForm(strCode);
        }
        #endregion

        private void tscProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strProcessCode = string.Empty;
            Common.MyEntity.ComboBoxItem item = this.tscProcess.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
                strProcessCode = string.Empty;
            else strProcessCode = item.Value.ToString();
            string strSql;
            if (strProcessCode.Length == 0)
                strSql = "SELECT Code,MacName FROM JC_ProcessMacs  WHERE isnull(Terminated,0)=0 ORDER BY SortID";
            else strSql = string.Format("SELECT Code,MacName FROM JC_ProcessMacs  WHERE ProcessCode='{0}' AND isnull(Terminated,0)=0 ORDER BY SortID", strProcessCode.Replace("'", "''"));
            DataTable dtMac = null;
            try
            {
                dtMac = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tscMac.Items.Clear();
            this.tscMac.ComboBox.DisplayMember = "Text";
            this.tscMac.ComboBox.ValueMember = "Value";
            this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem("-���л�̨-",""));
            foreach (DataRow dr in dtMac.Rows)
            {
                this.tscMac.ComboBox.Items.Add(new Common.MyEntity.ComboBoxItem(dr["MacName"].ToString(), dr["Code"].ToString()));
            }
            this.tscMac.SelectedIndex = 0;
        }
    }
}