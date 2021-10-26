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
    public partial class frmSelectBdownCase : Common.frmSelectBase
    {
        public frmSelectBdownCase()
        {
            InitializeComponent();
        }
        #region ������
        private bool Perinit()
        {
            #region ���ø��ఴť
            List<Common.MyEntity.SearchButtonItem> listBarbuts = new List<Common.MyEntity.SearchButtonItem>();
            Common.MyEntity.SearchButtonItem barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "�߼�����";
            barbut.Value = 1;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "�б�����";
            barbut.Value = 2;
            listBarbuts.Add(barbut);
            barbut = new Common.MyEntity.SearchButtonItem();
            barbut.TitleName = "��ѡ";
            barbut.Value = 3;
            listBarbuts.Add(barbut);
            this.labExButtons.BackColor = Color.Transparent;
            this.labExButtons.ForeColor = Color.Black;
            this.labExButtons.TextAlign = ContentAlignment.MiddleCenter;
            this.labExButtons.IsTextChange = false;//����Ҫ�л��ı�
            this.BindMyButtons(this.labExButtons, listBarbuts, true);
            #endregion
            #region �󶨹�������
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
            this.comProcess.DisplayMember = "Text";
            this.comProcess.ValueMember = "Value";
            int iSelIndex = -1;
            foreach (DataRow dr in dtProcess.Rows)
            {
                if (string.Compare(this.DefaultProcess, dr["Code"].ToString(), true) == 0)
                    iSelIndex = this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
                else this.comProcess.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ProcessName"].ToString(), dr["Code"].ToString()));
            }
            this.comProcess.SelectedIndex = iSelIndex;
            this.comProcess.Enabled = !this.FixProcess;
            #endregion
            this.dgvDetail.AutoGenerateColumns = false;
            this.dgvDetail.MultiSelect = this.MultiSelected;//�Ƿ������ѡ
            if (this.MultiSelected)
                this.BindDataGridViewCheckBox(this.dgvDetail, this.colCheckBox);
            else
            {
                //��ѡ������Ӹ�ѡ��
                this.colCheckBox.Visible = false;
                this.dgvDetail.CellDoubleClick+=new DataGridViewCellEventHandler(dgvDetail_CellDoubleClick);
            }
            return true;
        }
        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM V_JC_MacBreakdownCase " + this.GetSqlWhere();
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            this.dgvDetail.DataSource = dt;
            return true;
        }
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        private string GetSqlWhere()
        {
            string strWhere = "WHERE ISNULL(Terminated,0)=0 ";//����ʾ�Ѿ�ͣ�õ�
            Common.MyEntity.ComboBoxItem item = this.comProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                return strWhere;
            return strWhere + string.Format(" AND (ISNULL(ProcessCode,'')='' OR ProcessCode='{0}')", item.Value.ToString().Replace("'", "''"));
        }
        #endregion
        #region ��������
        private List<SelectedMBdownCase> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectedMBdownCase> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        private string _strDefaultProcess = string.Empty;
        /// <summary>
        /// Ĭ�Ϲ������
        /// </summary>
        public string DefaultProcess
        {
            get { return this._strDefaultProcess; }
            set { this._strDefaultProcess = value; }
        }
        private bool _blFixProcess = false;
        /// <summary>
        /// �̶�����
        /// </summary>
        public bool FixProcess
        {
            get { return this._blFixProcess; }
            set { this._blFixProcess = value; }
        }
        #endregion
        #region ����OnLoad�¼�
        private void frmSelect_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region �������ؼ��¼�
        private void labExButtons_TitleChanged(MyControl.MyLabelEx.MyLabelItem originalItem, MyControl.MyLabelEx.MyLabelItem newItem)
        {
            Common.MyEntity.SearchLabelItem item = newItem.Tag as Common.MyEntity.SearchLabelItem;
            if (item.Value == 2)
            {
                this.DataGridViewSetting(Common.MyEnums.Modules.None, this.dgvDetail);
            }
            else if (item.Value == 3)
            {
                if (!this.MultiSelected)
                {
                    this.ShowMsg("��ǰ�б�ֻ��ѡ��һ�����ݣ��ù��ܲ���ʹ�á�");
                    return;
                }
                DataTable dt = this.dgvDetail.DataSource as DataTable;
                if (dt == null) return;
                foreach (DataRowView drv in dt.DefaultView)
                {
                    drv.Row[this.DataGridViewCheckColumnName] = drv.Row[this.DataGridViewCheckColumnName].Equals(DBNull.Value) ? true : !(bool)drv.Row[this.DataGridViewCheckColumnName];
                }
            }
        }
        //������ť���ռ����¼�
        private void SaarchValues_KeyDown(object sender, KeyEventArgs e)
        {
            //Ŀǰֻ�����س��¼�
            if (e.KeyValue == 13)
                this.btSearch_Click(sender, null);
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!this.BindData()) return;
        }
        #endregion
        #region �ײ���ť�¼�
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ش��塣");
                return;
            }
            if (this.MultiSelected)
            {
                DataRow[] drs = dt.Select(this.DataGridViewCheckColumnName + "=1");
                if (drs.Length == 0)
                {
                    this.ShowMsg("������ѡ��һ�����ݡ�");
                    return;
                }
                this.SelectedData = new List<SelectedMBdownCase>();
                SelectedMBdownCase info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedMBdownCase();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0)
                {
                    this.ShowMsg("��ѡ��һ�����ݡ�");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedMBdownCase info = new SelectedMBdownCase();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedMBdownCase>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectedMBdownCase
        {
            public SelectedMBdownCase()
            {
            }
            public SelectedMBdownCase(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strCode;
            /// <summary>
            ///
            /// </summary>
            public object Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }
            private object _iSortID;
            /// <summary>
            ///
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strCaseDesc;
            /// <summary>
            ///
            /// </summary>
            public object CaseDesc
            {
                get { return this._strCaseDesc; }
                set { this._strCaseDesc = value; }
            }
            private object _strLevelCode;
            /// <summary>
            ///
            /// </summary>
            public object LevelCode
            {
                get { return this._strLevelCode; }
                set { this._strLevelCode = value; }
            }
            private object _strProcessCode;
            /// <summary>
            ///
            /// </summary>
            public object ProcessCode
            {
                get { return this._strProcessCode; }
                set { this._strProcessCode = value; }
            }
            private object _strClassCode;
            /// <summary>
            ///
            /// </summary>
            public object ClassCode
            {
                get { return this._strClassCode; }
                set { this._strClassCode = value; }
            }
            private object _blTerminated;
            /// <summary>
            ///
            /// </summary>
            public object Terminated
            {
                get { return this._blTerminated; }
                set { this._blTerminated = value; }
            }
            private object _blIsSys;
            /// <summary>
            ///
            /// </summary>
            public object IsSys
            {
                get { return this._blIsSys; }
                set { this._blIsSys = value; }
            }
            private object _strProcessName;
            /// <summary>
            ///
            /// </summary>
            public object ProcessName
            {
                get { return this._strProcessName; }
                set { this._strProcessName = value; }
            }
            private object _strLevelDesc;
            /// <summary>
            ///
            /// </summary>
            public object LevelDesc
            {
                get { return this._strLevelDesc; }
                set { this._strLevelDesc = value; }
            }
            private object _strTerminatedView;
            /// <summary>
            ///
            /// </summary>
            public object TerminatedView
            {
                get { return this._strTerminatedView; }
                set { this._strTerminatedView = value; }
            }
            private object _strIsSysView;
            /// <summary>
            ///
            /// </summary>
            public object IsSysView
            {
                get { return this._strIsSysView; }
                set { this._strIsSysView = value; }
            }
            private object _strClassName;
            /// <summary>
            ///
            /// </summary>
            public object ClassName
            {
                get { return this._strClassName; }
                set { this._strClassName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.CaseDesc = dr["CaseDesc"];
                this.LevelCode = dr["LevelCode"];
                this.ProcessCode = dr["ProcessCode"];
                this.ClassCode = dr["ClassCode"];
                this.Terminated = dr["Terminated"];
                this.IsSys = dr["IsSys"];
                this.ProcessName = dr["ProcessName"];
                this.LevelDesc = dr["LevelDesc"];
                this.TerminatedView = dr["TerminatedView"];
                this.IsSysView = dr["IsSysView"];
                this.ClassName = dr["ClassName"];
            }
        }
        #endregion
        #region �б���¼�
        //��˫���¼�
        protected void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.btTrue_Click(null, null);
        }
        #endregion
    }
}