using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.Unit
{
    public partial class frmSelectUnit : Common.frmSelectBase
    {
        public frmSelectUnit()
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
            string strSql;
            if (this.UnitType.Length == 0)
                strSql = "SELECT * FROM jc_Unit WHERE ISNULL(Terminated,0)=0 ORDER BY SortID ASC";
            else strSql = string.Format("SELECT * FROM jc_Unit WHERE ISNULL(Terminated,0)=0 AND UnitType='{0}' ORDER BY SortID ASC", this.UnitType.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataColumn dcIsSysView = new DataColumn("IsSysView", Type.GetType("System.String"), "IIF(IsSys=1,'��','��')");
            dt.Columns.Add(dcIsSysView);
            if (this.MultiSelected)
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region ��������
        private string _strUnitType = string.Empty;
        /// <summary>
        /// ��λ����
        /// </summary>
        public string UnitType
        {
            get { return this._strUnitType; }
            set { this._strUnitType = value; }
        }
        private List<SelectedUnitInfo> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectedUnitInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
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
                this.SelectedData = new List<SelectedUnitInfo>();
                SelectedUnitInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedUnitInfo();
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
                SelectedUnitInfo info = new SelectedUnitInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedUnitInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectedUnitInfo
        {
            public SelectedUnitInfo()
            {
            }
            public SelectedUnitInfo(DataRow dr)
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
            private object _strCNName;
            /// <summary>
            ///
            /// </summary>
            public object CNName
            {
                get { return this._strCNName; }
                set { this._strCNName = value; }
            }
            private object _strENName;
            /// <summary>
            ///
            /// </summary>
            public object ENName
            {
                get { return this._strENName; }
                set { this._strENName = value; }
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
            private object _blIsSys;
            /// <summary>
            ///
            /// </summary>
            public object IsSys
            {
                get { return this._blIsSys; }
                set { this._blIsSys = value; }
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
            private object _strDescription;
            /// <summary>
            ///
            /// </summary>
            public object Description
            {
                get { return this._strDescription; }
                set { this._strDescription = value; }
            }
            private object _strDefaultName;
            /// <summary>
            ///
            /// </summary>
            public object DefaultName
            {
                get { return this._strDefaultName; }
                set { this._strDefaultName = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.CNName = dr["CNName"];
                this.ENName = dr["ENName"];
                this.SortID = dr["SortID"];
                this.IsSys = dr["IsSys"];
                this.Terminated = dr["Terminated"];
                this.Description = dr["Description"];
                this.DefaultName = dr["DefaultName"];
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