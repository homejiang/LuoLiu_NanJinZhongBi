using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.ProcessJobs
{
    public partial class frmSelectJobs : Common.frmSelectBase
    {
        public frmSelectJobs()
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
            string strSql = "SELECT * FROM JC_Jobs WHERE ISNULL(Terminated,0)=0";
            if (this._ProcessCode != string.Empty)
                strSql += string.Format(" AND ProcessCode='{0}'", this._ProcessCode.Replace("'", "''"));
            strSql += " Order by SortID ASC";
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
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region ��������
        private List<SelectedJobInfo> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectedJobInfo> SelectedData
        {
            get { return this._selectedData; }
            set { this._selectedData = value; }
        }
        public string _ProcessCode = string.Empty;
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
                if (this.SelectedData == null)
                    this.SelectedData = new List<SelectedJobInfo>();
                SelectedJobInfo info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedJobInfo();
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
                SelectedJobInfo info = new SelectedJobInfo();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                if (this.SelectedData == null)
                    this.SelectedData = new List<SelectedJobInfo>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectedJobInfo
        {
            public SelectedJobInfo()
            {
            }
            public SelectedJobInfo(DataRow dr)
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
            private object _strJobName;
            /// <summary>
            ///
            /// </summary>
            public object JobName
            {
                get { return this._strJobName; }
                set { this._strJobName = value; }
            }
            private object _blIsDefault;
            /// <summary>
            ///
            /// </summary>
            public object IsDefault
            {
                get { return this._blIsDefault; }
                set { this._blIsDefault = value; }
            }
            private object _strJobDesc;
            /// <summary>
            ///
            /// </summary>
            public object JobDesc
            {
                get { return this._strJobDesc; }
                set { this._strJobDesc = value; }
            }
            private object _decSFGLenRate;
            /// <summary>
            ///
            /// </summary>
            public object SFGLenRate
            {
                get { return this._decSFGLenRate; }
                set { this._decSFGLenRate = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.Code = dr["Code"];
                this.SortID = dr["SortID"];
                this.JobName = dr["JobName"];
                this.JobDesc = dr["JobDesc"];
                this.SFGLenRate = dr["SFGLenRate"];
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