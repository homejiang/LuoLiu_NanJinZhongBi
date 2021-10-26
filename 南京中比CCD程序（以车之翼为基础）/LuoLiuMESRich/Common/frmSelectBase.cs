using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmSelectBase : frmBaseList
    {
        public frmSelectBase()
        {
            InitializeComponent();
        }
        #region ѡ�е�����
        private List<DataRow> _listRow = new List<DataRow>();
        /// <summary>
        /// ѡ�е���
        /// </summary>
        public List<DataRow> SelectedRows
        {
            get
            {
                return this._listRow;
            }
            set { this._listRow = value; }
        }
        #endregion
        #region �Ƿ�����ѡ
        private bool _isMultiSelected = true;
        /// <summary>
        /// ������ѡ,Ĭ��Ϊ��ѡ
        /// </summary>
        public bool MultiSelected
        {
            get { return this._isMultiSelected; }
            set { this._isMultiSelected = value; }
        }
        #endregion
        #region �Ѿ�ѡ����еĹؼ���
        private List<object> _listContains = null;
        /// <summary>
        /// �Ѿ�ѡ����еĹؼ��֣�����ж���ؼ�������|���Ÿ���
        /// </summary>
        public List<object> listContains
        {
            get { return this._listContains; }
            set { this._listContains = value; }
        }
        #endregion
        #region �����б�ؼ�
        #region �б���ظ�ѡ��
        public DataColumn GetDataGridViewCheckBoxColumn()
        {
            return new DataColumn(DataGridViewCheckColumnName, Type.GetType("System.Boolean"));
        }
        private CheckBox DataGridViewHeaderCheckBox = null;
        private DataGridView DataGridView = null;
        public string DataGridViewCheckColumnName = "sysMyIsSelected";
        public virtual void BindDataGridViewCheckBox(DataGridView dgv, DataGridViewColumn dgvcol)
        {
            int iColumnIndex = -1;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Equals(dgvcol))
                {
                    iColumnIndex = i;
                    break;
                }
            }
            if (iColumnIndex == -1) return;
            if (this.DataGridViewHeaderCheckBox == null)
            {
                this.DataGridViewHeaderCheckBox = new CheckBox();
                this.DataGridViewHeaderCheckBox.Width = 15;
                this.DataGridViewHeaderCheckBox.Height = 14;
                dgv.Controls.Add(this.DataGridViewHeaderCheckBox);
                this.DataGridViewHeaderCheckBox.Click += new EventHandler(DataGridViewHeaderCheckBox_Click);
            }
            Rectangle rect = dgv.GetCellDisplayRectangle(iColumnIndex , -1, false);
            //����ѡ�������ʾ��ѡ������
            int iWidth = dgv.Columns[iColumnIndex].Width;
            int iHeight = dgv.ColumnHeadersHeight;
            int itopMargin = iHeight - DataGridViewHeaderCheckBox.Height;
            if (itopMargin < 0)
                itopMargin = 0;
            else
                itopMargin = itopMargin / 2;
            int ileftMargin = iWidth - DataGridViewHeaderCheckBox.Width;
            if (ileftMargin < 0)
                ileftMargin = 0;
            else
                ileftMargin = ileftMargin / 2;
            DataGridViewHeaderCheckBox.Top = rect.Top + itopMargin;
            DataGridViewHeaderCheckBox.Left = rect.Left + ileftMargin;
            this.DataGridView = dgv;
            if (dgvcol.DataPropertyName != DataGridViewCheckColumnName)
                dgvcol.DataPropertyName = DataGridViewCheckColumnName;
            //this.DataGridViewHeaderCheckBox.Tag = iColumnIndex;//��¼�к�
        }
        protected virtual void DataGridViewHeaderCheckBox_Click(object sender, EventArgs e)
        {
            if (this.DataGridView == null) return;
            DataTable dt = this.DataGridView.DataSource as DataTable;
            if (dt == null) return;
            if (!dt.Columns.Contains(DataGridViewCheckColumnName)) return;//�ֶ�sysMyIsSelected��Ҫ�ڰ��б�ʱ����
            foreach (DataRowView drv in dt.DefaultView)
            {
                if (!drv.Row[DataGridViewCheckColumnName].Equals(this.DataGridViewHeaderCheckBox.Checked))
                    drv.Row[DataGridViewCheckColumnName] = this.DataGridViewHeaderCheckBox.Checked;
            }
        }
        #endregion
        #endregion
        #region �Ƿ������ѡ��
        private bool _blallowNoneSelected = false;
        /// <summary>
        /// �Ƿ������ѡ��
        /// </summary>
        public bool AllowNoneSelected
        {
            get { return this._blallowNoneSelected; }
            set { this._blallowNoneSelected = value; }
        }
        #endregion
    }
}