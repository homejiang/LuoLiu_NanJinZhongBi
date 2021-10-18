using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.Debug
{
    public partial class frmPLCValue : Form
    {
        List<int> _Caos = null;
        public frmPLCValue()
        {
            InitializeComponent();
            
        }
        public DataTable _DtSource = null;
        long _ID = 0;
        private void frmPLCValue_Load(object sender, EventArgs e)
        {
            GetData();
            this.tbMyCodeStartValue.Text = this._ID.ToString();
            //   _DtSource = new DataTable();
            //this._DtSource.Columns.Add("ID", Type.GetType("System.Int16"));
            //this._DtSource.Columns.Add("MyCode", Type.GetType("System.Int16"));
            //this._DtSource.Columns.Add("CaoIndex", Type.GetType("System.Int16"));
            //this._DtSource.Columns.Add("V", Type.GetType("System.Int16"));
            //this._DtSource.Columns.Add("Dz", Type.GetType("System.Int16"));
            //this._DtSource.Columns.Add("NGCase", Type.GetType("System.Int16"));
            //_DtSource.DefaultView.Sort = "ID asc";
            //for(int i=1;i<=20;i++)
            //{
            //    DataRow drNew = this._DtSource.NewRow();
            //    drNew["ID"] = i;
            //    this._DtSource.Rows.Add(drNew);
            //}
            //this.dgvList.DataSource = _DtSource;
        }
        private bool GetData()
        {
            string strSql = string.Format("SELECT TOP 2 * FROM DebugResult WHERE ID>{0} order by ID", this._ID);
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = dt;
            if(dt.Rows.Count>0)
            {
                this._ID = long.Parse(dt.Rows[dt.Rows.Count - 1]["ID"].ToString());
            }
            return true;
        }

        private void btNewValue_Click(object sender, EventArgs e)
        {
            //Server=.\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;
            GetData();
            this.tbMyCodeStartValue.Text = this._ID.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (dt.Rows.Count >= 1)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result1, dt.Rows[0]);
            if (dt.Rows.Count >= 2)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result2, dt.Rows[1]);
            if (dt.Rows.Count >= 3)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result3, dt.Rows[2]);
            if (dt.Rows.Count >= 4)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result4, dt.Rows[3]);
            if (dt.Rows.Count >= 5)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result5, dt.Rows[4]);
            if (dt.Rows.Count >= 6)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result6, dt.Rows[5]);
            if (dt.Rows.Count >= 7)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result7, dt.Rows[6]);
            if (dt.Rows.Count >= 8)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result8, dt.Rows[7]);
            if (dt.Rows.Count >= 9)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result9, dt.Rows[8]);
            if (dt.Rows.Count >= 10)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result10, dt.Rows[9]);
            if (dt.Rows.Count >= 11)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result11, dt.Rows[10]);
            if (dt.Rows.Count >= 12)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result12, dt.Rows[11]);
            if (dt.Rows.Count >= 13)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result13, dt.Rows[12]);
            if (dt.Rows.Count >= 14)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result14, dt.Rows[13]);
            if (dt.Rows.Count >= 15)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result15, dt.Rows[14]);
            if (dt.Rows.Count >= 16)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result16, dt.Rows[15]);
            if (dt.Rows.Count >= 17)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result17, dt.Rows[16]);
            if (dt.Rows.Count >= 18)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result18, dt.Rows[17]);
            if (dt.Rows.Count >= 19)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result19, dt.Rows[18]);
            if (dt.Rows.Count >= 20)
                this.SetPLCValue(JPSEntity.Debug.PLCResultReader.Result20, dt.Rows[19]);
            JPSEntity.Debug.PLCResultReader.IsReadNow = true;
            btNewValue_Click(null, null);
        }
        private void SetPLCValue(JPSEntity.Debug.PLCResultData result,DataRow dr)
        {
            if (dr == null)
            {
                result = new JPSEntity.Debug.PLCResultData();//清空数据
            }
            else
            {
                result.MyCode = string.Empty;// dr["MyCode"].ToString();
                result.V = dr["V"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["V"].ToString());
                result.DianZu = dr["DianZu"].Equals(DBNull.Value) ? 0M : decimal.Parse(dr["DianZu"].ToString());
                result.CaoIndex = dr["CaoIndex"].Equals(DBNull.Value) ? (short)0 : short.Parse(dr["CaoIndex"].ToString());
                result.NGCase = dr["NGCase"].Equals(DBNull.Value) ? (short)0 : short.Parse(dr["NGCase"].ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1_Click(null,null);
        }

        private void btTimerStart_Click(object sender, EventArgs e)
        {
            if(this.btTimerStart.Text== "开始")
            {
                int i;
                if(!int.TryParse(this.tbTimerIntveral.Text,out i))
                {
                    return;
                }
                this.timer1.Interval = i;
                this.timer1.Enabled = true;
                this.btTimerStart.Text = "停止";
            }
            else
            {
                this.timer1.Enabled = false;
                this.btTimerStart.Text = "开始";
            }
        }
    }
}
