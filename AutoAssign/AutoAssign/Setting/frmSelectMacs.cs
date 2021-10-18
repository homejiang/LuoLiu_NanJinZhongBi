using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.Setting
{
    public partial class frmSelectMacs : Common.frmSelectBase
    {
        public frmSelectMacs()
        {
            InitializeComponent();
        }
        #region ������
        private bool Perinit()
        {
            
            #region �󶨹�������
            DataTable dtProcess = null;
            try
            {
                dtProcess = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable("SELECT Code,ProcessName FROM JC_Process ORDER BY SortID ASC,ProcessName ASC");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            foreach (DataRow dr in dtProcess.Rows)
            {
                if (this.DefaultProcessCode.Length > 0)
                {
                    if (string.Compare(this.DefaultProcessCode, dr["Code"].ToString(), true) == 0)
                        this.DefaultProcessName = dr["ProcessName"].ToString();
                }
                this.comSearchValue.Items.Add(dr["ProcessName"].ToString());
            }
            #endregion
            #region ����Ĭ��ֵ
            this.comSearchValue.Text = this.DefaultProcessName;
            this.comSearchValue.Enabled = !this.FixProcess;
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
            string strSql = "SELECT * FROM V_JC_ProcessMacs " + this.GetSqlWhere();
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.MultiSelected)
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
                if (this.SelectedData != null && this.SelectedData.Count > 0)
                {
                    DataRow[] drsMac;
                    foreach (SelectMacInfo mac in this.SelectedData)
                    {
                        drsMac = dt.Select(string.Format("Code='{0}'"
                            , mac.Code.ToString()));
                        if (drsMac.Length > 0)
                            drsMac[0][this.DataGridViewCheckColumnName] = true;
                    }
                }
            }
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
            if (this.comSearchValue.Text.Length == 0) return strWhere;
            return strWhere + string.Format(" AND ProcessName LIKE '{0}'", this.comSearchValue.Text.Replace("'", "''"));
        }
        #endregion
        #region ��������
        private List<SelectMacInfo> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectMacInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        private string _strDefaultProcessName = string.Empty;
        /// <summary>
        /// Ĭ�Ϲ�������
        /// </summary>
        public string DefaultProcessName
        {
            get { return this._strDefaultProcessName; }
            set { this._strDefaultProcessName = value; }
        }
        private string _strDefaultProcessCode = string.Empty;
        /// <summary>
        /// Ĭ�Ϲ������
        /// </summary>
        public string DefaultProcessCode
        {
            get { return this._strDefaultProcessCode; }
            set { this._strDefaultProcessCode = value; }
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
        private void frmBsFWithAllocateInfo_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if (!this.BindData()) return;
        }
        #endregion
        #region �������ؼ��¼�
       
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
                this.SelectedData = new List<SelectMacInfo>();
                SelectMacInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectMacInfo();
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
                SelectMacInfo info = new SelectMacInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectMacInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectMacInfo
        {
            private object _strCode;
            /// <summary>
            ///�豸����
            /// </summary>
            public object Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }
            private object _iSortID;
            /// <summary>
            ///�����ֶ�
            /// </summary>
            public object SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
            private object _strProcessCode;
            /// <summary>
            ///�������
            /// </summary>
            public object ProcessCode
            {
                get { return this._strProcessCode; }
                set { this._strProcessCode = value; }
            }
            private object _strProcessName;
            /// <summary>
            ///��������
            /// </summary>
            public object ProcessName
            {
                get { return this._strProcessName; }
                set { this._strProcessName = value; }
            }
            private object _strMacName;
            /// <summary>
            ///�豸����
            /// </summary>
            public object MacName
            {
                get { return this._strMacName; }
                set { this._strMacName = value; }
            }
            private object _strAddress;
            /// <summary>
            ///�豸���λ������
            /// </summary>
            public object Address
            {
                get { return this._strAddress; }
                set { this._strAddress = value; }
            }
            private object _strRemark;
            /// <summary>
            ///�豸��ע��Ϣ
            /// </summary>
            public object Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
            }
            /// <summary>
            /// ��DataRow�ж�ȡ��������ֵ
            /// </summary>
            /// <param name="dr"></param>
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.ProcessCode = dr["ProcessCode"];
                this.MacName = dr["MacName"];
                this.Address = dr["Address"];
                this.Remark = dr["Remark"];
                this.ProcessName = dr["ProcessName"];
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