using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.PeiFang
{
    public partial class frmSelectPf : Common.frmBaseList
    {
        public frmSelectPf()
        {
            InitializeComponent();
            this.dgvGrooves.AutoGenerateColumns = false;
            this.dgvList.AutoGenerateColumns = false;
        }
        public string _SeledGuid = string.Empty;

        private bool BindData()
        {
            string strSql = "SELECT * FROM [V_PeiFang_Main_ForSelect] WHERE 1=1";
            if (this.tbPeifangName.Text.Length > 0)
                strSql += string.Format(" AND PeiFangName like '%{0}%'", this.tbPeifangName.Text.Replace("'", "''"));
            if(this.comModeIsNeter.SelectedIndex>0)
            {
                if (this.comModeIsNeter.SelectedIndex == 1)
                    strSql += " AND ISNULL(ModeIsNeter,0)=1";
                else
                    strSql += " AND ISNULL(ModeIsNeter,0)=0";
            }
            if (this.comModeIsScaner.SelectedIndex > 0)
            {
                if (this.comModeIsScaner.SelectedIndex == 1)
                    strSql += " AND ISNULL(ModeIsScaner,0)=1";
                else
                    strSql += " AND ISNULL(ModeIsScaner,0)=0";
            }
            if (this.comGongYiType.SelectedIndex > 0)
            {
                if (this.comGongYiType.SelectedIndex == 1)
                    strSql += " AND ISNULL(GongYiType,0)=1";
                else
                    strSql += " AND ISNULL(GongYiType,0)=2";
            }
            Common.MyEntity.ComboBoxItem item = this.comProcessCode.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString().Length > 0)
            {
                strSql += string.Format(" and ProcessCode='{0}'", item.Value.ToString().Replace("'", "''"));
            }
            item = this.comProductSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item != null && item.Value != null && item.Value.ToString().Length > 0)
            {
                strSql += string.Format(" and ProductSpec='{0}'", item.Value.ToString().Replace("'", "''"));
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if(list.Count>0)
            {
                for(int i=list.Count;i>0;i--)
                {
                    if (this.dgvList.Rows[i - 1].Selected)
                        this.dgvList.Rows[i - 1].Selected = false;
                }
            }
            this.dgvGrooves.DataSource = null;
            return true;
        }
        private bool BindGrooves(string sGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT * FROM V_PeiFang_Grooves WHERE GUID='{0}'", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvGrooves.DataSource = dt;
            return true;
        }
        private void frmPfList_Load(object sender, EventArgs e)
        {
            this.comModeIsNeter.Items.Add("不限");
            this.comModeIsNeter.Items.Add("网络版");
            this.comModeIsNeter.Items.Add("单机版");
            this.comModeIsNeter.SelectedIndex = 0;
            this.comModeIsScaner.Items.Add("不限");
            this.comModeIsScaner.Items.Add("扫码");
            this.comModeIsScaner.Items.Add("不扫码");
            this.comModeIsScaner.SelectedIndex = 0;
            this.comGongYiType.Items.Add("不限工艺");
            this.comGongYiType.Items.Add("同工艺");
            this.comGongYiType.Items.Add("多工艺");
            this.comGongYiType.SelectedIndex = 0;
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_ProductSpec where ISNULL(Terminated,0)=0", "JC_ProductSpec"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_Process where ISNULL(Terminated,0)=0", "JC_Process"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "基础数据加载");
            }
            if (ds != null)
            {
                this.comProcessCode.DisplayMember = "Text";
                this.comProcessCode.Items.Add(new Common.MyEntity.ComboBoxItem("不限工序", string.Empty));
                foreach (DataRow dr in ds.Tables["JC_Process"].Rows)
                {
                    this.comProcessCode.Items.Add(new Common.MyEntity.ComboBoxItem(dr["Code"].ToString(), dr["Code"].ToString()));
                }
                this.comProcessCode.SelectedIndex = 0;
                this.comProductSpec.DisplayMember = "Text";
                this.comProductSpec.Items.Add(new Common.MyEntity.ComboBoxItem("不限电芯规格", string.Empty));
                foreach (DataRow dr in ds.Tables["JC_ProductSpec"].Rows)
                {
                    this.comProductSpec.Items.Add(new Common.MyEntity.ComboBoxItem(dr["Spec"].ToString(), dr["GUID"].ToString()));
                }
                this.comProductSpec.SelectedIndex = 0;
            }
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
            //BindData();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void tstValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                BindData();
        }
        private void myDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失！");
                return;
            }
            _SeledGuid = dt.DefaultView[e.RowIndex].Row["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }
        int _SelectedRow = -1;
        private void myDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvList.SelectedRows.Count == 0) return;
            int iIndex = this.dgvList.SelectedRows[0].Index;
            if (iIndex == this._SelectedRow) return;
            string strGuid = dt.DefaultView[iIndex].Row["GUID"].ToString();
            if (!this.BindGrooves(strGuid))
            {
                this.dgvGrooves.DataSource = null;
            }
            this._SelectedRow = iIndex;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this.dgvList.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中一行！");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失！");
                return;
            }
            _SeledGuid = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["GUID"].ToString();
            this.DialogResult = DialogResult.OK;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.BindData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void tbPeifangName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.BindData();
        }

        private void comModeIsNeter_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void comModeIsScaner_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.BindData();
        }

        private void comGongYiType_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.BindData();
        }

        private void comProductSpec_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.BindData();
        }

        private void comProcessCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            this.BindData();
        }

        private void dgvList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (this.dgvList.SelectedRows.Count == 0) return;
            int iIndex = this.dgvList.SelectedRows[0].Index;
            if (iIndex == this._SelectedRow) return;
            string strGuid = dt.DefaultView[iIndex].Row["GUID"].ToString();
            if (!this.BindGrooves(strGuid))
            {
                this.dgvGrooves.DataSource = null;
            }
            this._SelectedRow = iIndex;
        }
    }
}