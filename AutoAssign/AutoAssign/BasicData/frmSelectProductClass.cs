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
    public partial class frmSelectProductClass : Common.frmSelectBase
    {
        public frmSelectProductClass()
        {
            InitializeComponent();
        }
        #region ������
        private bool Perinit()
        {
            
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
            string strSql = "SELECT * FROM JC_ProductSpec where isnull(Terminated,0)=0";
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
            public void ReadFromDataRow(DataRow dr)
            {
                this.GUID = dr["GUID"];
                this.Spec = dr["Spec"];
                this.Terminated = dr["Terminated"];
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