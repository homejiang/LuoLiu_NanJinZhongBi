using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.ExpFuns
{
    public partial class frmGetTuoFromRemoteMac : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion 
        string _NewTestCode = string.Empty;
        public frmMain1 _MainFrom = null;
        string _TuoPanCode = string.Empty;
        Common.SqlServerCommand _SqlCmd = null;
        string _ResultTable = string.Empty;
        string _BatterysTable = string.Empty;
        string _TestCode = string.Empty;
        string _NewTuopanCode = string.Empty;
        string _NewResultTable = string.Empty;
        string _NewBatteryTable = string.Empty;
        public frmGetTuoFromRemoteMac(string sTestCode)
        {
            InitializeComponent();
            _NewTestCode = sTestCode;
            //this.tbCode.Text = sTestCode;
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindNewTuoPanCode()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TuoCode FROM Testing_Grooves WHERE Code='{0}' AND GrooveNo=1", _NewTestCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("当前测试还没有生产托盘号，不能导入！");
                return false;
            }
            if(dt.Rows[0]["TuoCode"].ToString().Length==0)
            {
                this.ShowMsg("当前测试还没有生产托盘号，无法导入！");
                return false;
            }
            _NewTuopanCode = dt.Rows[0]["TuoCode"].ToString();
            this.labTitle.Text = string.Format("当前托盘号：{0}", dt.Rows[0]["TuoCode"].ToString());
            
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ResultTable,BatterysTable FROM Testing_Main WHERE Code='{0}'", _NewTestCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("当前测试数据不完整，请确认是否开始测试了？");
                return false;
            }
            if (dt.Rows[0]["ResultTable"].ToString().Length == 0)
            {
                this.ShowMsg("当前测试数据不完整，请确认已经开始测试了。");
                return false;
            }
            this._NewResultTable = dt.Rows[0]["ResultTable"].ToString();
            this._NewBatteryTable = dt.Rows[0]["BatterysTable"].ToString();
            return true;
        }
        private void btBindData_Click(object sender, EventArgs e)
        {
            if(!this.radioMac1.Checked && !this.radioMac2.Checked && !this.radioMac3.Checked)
            {
                this.ShowMsg("请选择远程设备。");
                return;
            }
            if(this.tbTuopanCode.Text.Length==0)
            {
                this.ShowMsg("请输入托盘编号。");
                return;
            }
            this.btTrue.Enabled = this.FindingTestMain(this.tbTuopanCode.Text);
        }
        private bool FindingTestMain(string sTuoPanCode)
        {
            string strIP;
            if (this.radioMac1.Checked)
                strIP = JPSConfig.RemoteMacConfig._IP1;
            else if (this.radioMac2.Checked)
                strIP = JPSConfig.RemoteMacConfig._IP2;
            else if (this.radioMac3.Checked)
                strIP = JPSConfig.RemoteMacConfig._IP3;
            else
            {
                this.ShowMsg("请选择远程设备。");
                return false;
            }
            if (strIP.Length == 0)
            {
                this.ShowMsg("还未远程设备的IP地址。");
                return false;
            }
            else
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply result = p.Send(strIP);
                if(result.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    this.ShowMsg("当前设备无法连通IP：" + strIP);
                    return false;
                }
            }
            this._SqlCmd = new Common.SqlServerCommand(string.Format(@"Server={0}\JPS2008;Database=LuoLiuAssigner;User=sa;Password=zxp;Connect Timeout=120;", strIP));
            DataTable dt;
            try
            {
                dt = this._SqlCmd.GetDateTable(string.Format("SELECT TOP 500 Code,ResultTable,BatterysTable FROM Testing_Main where ISNULL(State,0)<>0 ORDER BY StartTime DESC"));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["ResultTable"].ToString().Length == 0 || dr["BatterysTable"].ToString().Length == 0) continue;
                string strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where ISNULL(A.TuoCode,'')='{2}'", dr["ResultTable"].ToString(), dr["BatterysTable"].ToString(), sTuoPanCode.Replace("'", "''"));
                DataTable dtSn;
                try
                {
                    dtSn = this._SqlCmd.GetDateTable(strSql);
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    continue;
                }
                if(dtSn.Rows.Count>0)
                {
                    //此时找到了
                    this._ResultTable = dr["ResultTable"].ToString();
                    this._BatterysTable = dr["BatterysTable"].ToString();
                    this._TuoPanCode = sTuoPanCode;
                    this._TestCode= dr["Code"].ToString();
                    this.dgvList.DataSource = dtSn;
                    return true;
                }
            }
            this.ShowMsg("未在远程设备上找到该托盘编号。");
            return false;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            /*****************
             * 导入托盘涉及的表：
             * 1、电芯表Testing_Batterys_XXXXXXXXX
             * 2、结果表Testing_Result_XXXXXXXXX
             * 3、Testing_Grooves中第1个槽数据
             * ***************/
            if (string.Compare(this.tbTuopanCode.Text, this._TuoPanCode, true) != 0)
            {
                this.ShowMsg("请先加载托盘数据。");
                return;
            }
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format(@"SELECT A.*
            FROM {0} A LEFT JOIN {1} B ON B.MyCode = A.Code
            WHERE B.TuoCode = '{2}'", this._BatterysTable, this._ResultTable, this._TuoPanCode.Replace("'", "''")), "BatterysTable"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format(@"SELECT * FROM {0} WHERE TuoCode = '{1}'", this._ResultTable, this._TuoPanCode.Replace("'", "''")), "ResultTable"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format(@"SELECT * FROM Testing_Grooves WHERE Code='{0}' AND TuoCode='{1}'", this._TestCode.Replace("'", "''"), this._TuoPanCode.Replace("'", "''")), "Testing_Grooves"));

            try
            {
                ds = this._SqlCmd.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            #region 读取当前槽的ID
            DataTable dtGrooveID;
            try
            {
                dtGrooveID = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ID FROM Testing_Grooves WHERE Code='{0}' AND GrooveNo=1"
                    , this._NewTestCode.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if(dtGrooveID.Rows.Count==0)
            {
                this.ShowMsg("未能读取到当前槽的唯一标识ID。");
                return;
            }
            long iGrooveID;
            if (!long.TryParse(dtGrooveID.Rows[0]["ID"].ToString(), out iGrooveID))
            {
                this.ShowMsg(string.Format("[{0}]不是预期的Grooveid值。", dtGrooveID.Rows[0]["ID"].ToString()));
                return;
            }
            #endregion
            //存储数据
            foreach (DataRow dr in ds.Tables["BatterysTable"].Rows)
            {
                dr.SetAdded();
            }
            foreach (DataRow dr in ds.Tables["ResultTable"].Rows)
            {
                dr.SetAdded();
                dr["TuoCode"] = this._NewTuopanCode;
                dr["GrooveID"] = iGrooveID;
            }
            try
            {
                this.BllDAL.DaoruSnDetails(ds.Tables["BatterysTable"], ds.Tables["ResultTable"], this._NewTestCode, this._NewBatteryTable, this._NewResultTable);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmByTuoPanCode_Load(object sender, EventArgs e)
        {
            if(!BindNewTuoPanCode())
            {
                this.btBindData.Enabled = false;
                this.btTrue.Enabled = false;
            }
        }

        private void tbTuopanCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            this.btBindData_Click(null, null);
        }
    }
}
