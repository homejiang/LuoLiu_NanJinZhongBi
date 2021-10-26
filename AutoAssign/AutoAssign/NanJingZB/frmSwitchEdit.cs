using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmSwitchEdit : Common.frmBase
    {
        string _TestCode = string.Empty;
        public frmSwitchEdit(string sTestCode)
        {
            InitializeComponent();
            _TestCode = sTestCode;
            this.labState.Visible = false;
        }
        int _TestState = 0;
        private bool BindTestState()
        {
            if (this._TestCode.Length == 0)
            {
                this._TestState = 0;
                return true;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable($"SELECT State FROM Testing_Main where Code='{this._TestCode.Replace("'", "''")}'");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            if (dt.Rows.Count == 0)
                this._TestState = 0;
            else
            {
                this._TestState = dt.Rows[0]["State"].Equals(DBNull.Value) ? 0 : int.Parse(dt.Rows[0]["State"].ToString());
            }
            return true;
        }
        private bool BindData()
        {
            try
            {
                this.myDataGridView1.DataSource = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM RealData_GroovesAB order by GrooveNo asc", true);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
        private void BindYaCha()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("select * from RealData_YaCha ");
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            if (dt.Rows.Count == 0)
                this.tbYaCha.Clear();
            else
            {
                this.tbYaCha.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dt.Rows[0]["YaCha"], "#########0.######");
            }
        }

        private void frmYcEdit_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = this.BindData();
            if(!this.BindTestState())
            {
                this.button1.Enabled = false;
            }
            BindYaCha();
            SetFormStyle();
        }
        private void SetFormStyle()
        {
            if(this._TestState>0)
            {
                this.myDataGridView1.Enabled = false;
                this.labState.Visible = true;
            }
            else
            {
                this.myDataGridView1.Enabled = true;
                this.labState.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Save())
            {
                this.ShowMsgRich("保存成功");
                this.button1.Enabled = this.BindData();
                BindYaCha();
            }
        }
        private bool Save()
        {
            this.textBox1.Focus();
            this.textBox1.SelectAll();
            Application.DoEvents();
            if (!SaveYacha()) return false;//保存压差
            if(this._TestState>0)
            {
                return true;
            }
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源丢失，保存失败！");
                return false;
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.SaveTable(dt, "RealData_GroovesAB");
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            List<string> listSql = new List<string>();
            foreach(DataRowView drv in dt.DefaultView)
            {
                int iQty = drv.Row["AQty"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["AQty"].ToString());
                iQty += drv.Row["BQty"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["BQty"].ToString());
                string sSql = $"UPDATE RealData_Grooves SET TuoBtyCount={iQty} WHERE GrooveNo={drv.Row["GrooveNo"].ToString()}";
                listSql.Add(sSql);
            }
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
        private bool SaveYacha()
        {
            decimal dec;
            if(!decimal.TryParse(this.tbYaCha.Text,out dec))
            {
                this.ShowMsg("请正确输入压差值");
                return false;
            }
            List<string> list = new List<string>();
            list.Add("delete from RealData_YaCha");
            list.Add($"INSERT INTO RealData_YaCha(YaCha) VALUES('{dec.ToString("########0.######")}')");
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(list);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
    }
}
