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
    public partial class frmClearSN : Common.frmSelectBase
    {
        public frmClearSN()
        {
            InitializeComponent();
            this.MultiSelected = true;
        }
        
        #region ������
        private bool Perinit()
        {
            
            this.dtpStart.Value = DateTime.Now.AddMonths(-1);
            this.dtpStart.Checked = false;
            this.dtpEnd.Value = DateTime.Now.AddDays(-15);
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
            
            this.tbPici.KeyDown += SearchText_KeyDown;
            return true;
        }

        private void SearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==13)
            {
                this.btSearch_Click(null, null);
            }
        }

        private bool BindData()
        {
            DataTable dt = null;
            string strSql = "SELECT * FROM NanJingZB_DXOrgData WHERE 1=1";
            if(this.tbPici.Text.Length>0)
            {
                strSql += string.Format(" and InputCode like '{0}'", this.tbPici.Text.Replace("'", "''"));
            }
            strSql += string.Format(" and Times<'{0} 00:00:01'", this.dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd"));
            if (this.dtpStart.Checked)
                strSql += string.Format(" and Times>='{0} 00:00:01'", this.dtpStart.Value.ToString("yyyy-MM-dd"));
            strSql += "order by Times asc";
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
            {
                dt.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            }
            this.dgvDetail.DataSource = dt;
            return true;
        }
        #endregion
        #region ��������
        private List<SelectedRemoteSN> _selectedData = null;
        /// <summary>
        /// ѡ�е�����
        /// </summary>
        public List<SelectedRemoteSN> SelectedData
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
                this.SelectedData = new List<SelectedRemoteSN>();
                SelectedRemoteSN info;
                foreach (DataRow dr in drs)
                {
                    info = new SelectedRemoteSN();
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
                SelectedRemoteSN info = new SelectedRemoteSN();
                info.ReadFromDataRow(dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row);
                this.SelectedData = new List<SelectedRemoteSN>();
                this.SelectedData.Add(info);
            }
            this.DialogResult = DialogResult.OK;
            this.FormColse();
        }
        #endregion
        #region ��������ʵ����
        public class SelectedRemoteSN
        {
            public SelectedRemoteSN()
            {
            }
            public SelectedRemoteSN(DataRow dr)
            {
                this.ReadFromDataRow(dr);
            }
            private object _strSN;
            /// <summary>
            ///
            /// </summary>
            public object SN
            {
                get { return this._strSN; }
                set { this._strSN = value; }
            }
            private object _strInputCode;
            /// <summary>
            ///
            /// </summary>
            public object InputCode
            {
                get { return this._strInputCode; }
                set { this._strInputCode = value; }
            }
            public void ReadFromDataRow(DataRow dr)
            {
                this.SN = dr["SN"];
                this.InputCode = dr["InputCode"];
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

        private void comPactState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.BindData();
        }

        private void btSeled_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (list.Count == 0) return;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            foreach(int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                if (dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) || !(bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = true;
            }
        }

        private void btUnSel_Click(object sender, EventArgs e)
        {
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (list.Count == 0) return;
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            foreach (int row in list)
            {
                DataRow dr = dt.DefaultView[row].Row;
                if (!dr[this.DataGridViewCheckColumnName].Equals(DBNull.Value) && (bool)dr[this.DataGridViewCheckColumnName])
                    dr[this.DataGridViewCheckColumnName] = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ɾ����о
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ش��塣");
                return;
            }
            List<SelectedRemoteSN> listSeled = new List<SelectedRemoteSN>();
            DataRow[] drs = dt.Select(this.DataGridViewCheckColumnName + "=1");
            if (drs.Length == 0 && !this.AllowNoneSelected)
            {
                this.ShowMsg("������ѡ��һ�����ݡ�");
                return;
            }
            SelectedRemoteSN info;
            foreach (DataRow dr in drs)
            {
                info = new SelectedRemoteSN();
                info.ReadFromDataRow(dr);
                listSeled.Add(info);
            }
            for (int i = 0; i < listSeled.Count; i = i + 10)
            {
                List<string> listSql = new List<string>();
                for (int j = 0; j < 10; j++)
                {
                    if (listSeled.Count > i + j)
                    {
                        listSql.Add($"DELETE FROM NanJingZB_DXOrgData WHERE InputCode='{listSeled[i + j].InputCode.ToString().Replace("'", "''")}' AND SN='{listSeled[i + j].SN.ToString().Replace("'", "''")}'");
                    }
                }
                if (listSql.Count > 0)
                {
                    try
                    {
                        Common.CommonDAL.DoSqlCommand.DoSql(listSql);
                    }
                    catch (Exception ex)
                    {
                        this.ShowMsg(ex.Message);
                        return;
                    }
                }
            }
            this.ShowMsgRich("ִ�����");
            this.BindData();
        }
    }
}