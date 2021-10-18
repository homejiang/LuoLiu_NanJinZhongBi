using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.BasicData
{
    public partial class frmSelectProductSpec : Common.frmSelectBase
    {
        short _DefaultClassValue = -1;
        public frmSelectProductSpec(short defualtClass)
        {
            InitializeComponent();
            _DefaultClassValue = defualtClass;
        }
        #region ������
        private bool Perinit()
        {
            this.dgvDetail.AutoGenerateColumns = false;
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_ProductClass where ISNULL(Terminated,0)=0", "JC_ProductClass"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "�������ݼ���");
                return false;
            }
            this.comClass.DisplayMember = "Text";
            this.comClass.Items.Add(new Common.MyEntity.ComboBoxItem("���޷���", ""));
            int iSeled=-1;
            foreach (DataRow dr in ds.Tables["JC_ProductClass"].Rows)
            {
                int iIndex=this.comClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Value"].ToString()));
                if (dr["Value"].ToString() == _DefaultClassValue.ToString())
                    iSeled = iIndex;
            }
            if (iSeled == -1) iSeled = 0;
            this.comClass.SelectedIndex = iSeled;
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
            string strSql = "SELECT * FROM V_JC_ProductSpec_Select where isnull(Terminated,0)=0";
            Common.MyEntity.ComboBoxItem item = this.comClass.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString().Length > 0)
            {
                strSql += string.Format(" and ClassValue={0}", item.Value.ToString());
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
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
                    foreach (SelectedProductSpec mac in this.SelectedData)
                    {
                        drsMac = dt.Select(string.Format("GUID='{0}'"
                            , mac.GUID.ToString()));
                        if (drsMac.Length > 0)
                            drsMac[0][this.DataGridViewCheckColumnName] = true;
                    }
                }
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region ��������
        private List<SelectedProductSpec> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectedProductSpec> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        #endregion
        #region ����OnLoad�¼�
        private void frmBsFWithAllocateInfo_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            //if (!this.BindData()) return;
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
                if (drs.Length == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("������ѡ��һ�����ݡ�");
                    return;
                }
                this.SelectedData = new List<SelectedProductSpec>();
                SelectedProductSpec info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedProductSpec();
                    info.ReadFromDataRow(dr);
                    this.SelectedData.Add(info);
                }
            }
            else
            {
                if (this.dgvDetail.SelectedRows.Count == 0 && !this.AllowNoneSelected)
                {
                    this.ShowMsg("��ѡ��һ�����ݡ�");
                    return;
                }
                if (dt.DefaultView.Count <= this.dgvDetail.SelectedRows[0].Index)
                    return;
                SelectedProductSpec info = new SelectedProductSpec();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedProductSpec>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectedProductSpec
        {
            public SelectedProductSpec()
            {
            }
            public SelectedProductSpec(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strGUID;
            /// <summary>
            ///
            /// </summary>
            public object GUID
            {
                get { return this._strGUID; }
                set { this._strGUID = value; }
            }
            private object _strSpec;
            /// <summary>
            ///
            /// </summary>
            public object Spec
            {
                get { return this._strSpec; }
                set { this._strSpec = value; }
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
            private object _strTerminatedView;
            /// <summary>
            ///
            /// </summary>
            public object TerminatedView
            {
                get { return this._strTerminatedView; }
                set { this._strTerminatedView = value; }
            }
            private object _iClassValue;
            /// <summary>
            ///
            /// </summary>
            public object ClassValue
            {
                get { return this._iClassValue; }
                set { this._iClassValue = value; }
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
            private object _strClassFullName;
            /// <summary>
            ///
            /// </summary>
            public object ClassFullName
            {
                get { return this._strClassFullName; }
                set { this._strClassFullName = value; }
            }
            private object _strScanner;
            /// <summary>
            ///
            /// </summary>
            public object Scanner
            {
                get { return this._strScanner; }
                set { this._strScanner = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.Spec = dr["Spec"];
                this.Terminated = dr["Terminated"];
                this.TerminatedView = dr["TerminatedView"];
                this.ClassValue = dr["ClassValue"];
                this.ClassName = dr["ClassName"];
                this.ClassFullName = dr["ClassFullName"];
                this.Scanner = dr["Scanner"];
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

        private void comClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}