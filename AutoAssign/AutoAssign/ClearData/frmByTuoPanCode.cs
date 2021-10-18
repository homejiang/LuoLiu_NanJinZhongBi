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

namespace AutoAssign.ClearData
{
    public partial class frmByTuoPanCode : Common.frmBase
    {
        public frmMain1 _MainFrom = null;
        string _RealTable_Batterys = string.Empty;
        string _RealTable_Result = string.Empty;
        string _TuoPanCode = string.Empty;
        public frmByTuoPanCode(string sTestCode)
        {
            InitializeComponent();
            this.tbCode.Text = sTestCode;
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindData()
        {
            DataTable dt;
            string strSql = string.Format("SELECT BatterysTable,ResultTable FROM Testing_Main WHERE Code='{0}'"
                , this.tbCode.Text.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("检测批次号还未开始测试，没有任何托盘信息。");
                return false;
            }
            this._RealTable_Batterys = dt.Rows[0]["BatterysTable"].ToString();
            this._RealTable_Result = dt.Rows[0]["ResultTable"].ToString();
            return true;
        }
        private bool BindSN(string sTuoPanCode)
        {
            DataTable dt;
            string strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where ISNULL(A.TuoCode,'')='{2}'", this._RealTable_Result, this._RealTable_Batterys, sTuoPanCode.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("未在托盘" + sTuoPanCode + "下找到任何电芯数据，请核实输入的编号。");
                return false;
            }
            this._TuoPanCode = sTuoPanCode;
            this.dgvList.DataSource = dt;
            return true;
        }

        private void btBindData_Click(object sender, EventArgs e)
        {
            if(this.tbTuopanCode.Text.Length==0)
            {
                this.ShowMsg("请输入托盘编号。");
                return;
            }
            this.btTrue.Enabled = this.BindSN(this.tbTuopanCode.Text);
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            /*****************
             * 删除托盘下电芯数据涉及表：
             * 1、电芯表中通过系统自编到结果表中匹配，并且通过托盘找到相应数据，
             * 2、结果表中托盘满足的。
             * 3、SN表
             * 4、托盘完成表
             * 5、正式表
             * 6、实时槽内数据
             * 注意：先删除SN表再删除电芯表，这是必须的，其他顺序无所谓
             * ***************/
            if (string.Compare(this.tbTuopanCode.Text, this._TuoPanCode, true) != 0)
            {
                this.ShowMsg("请先加载托盘数据。");
                return;
            }
            List<string> listSql = new List<string>();
            //SN表
            listSql.Add(string.Format("DELETE FROM SN WHERE SN IN (SELECT A.SN FROM {0} A LEFT JOIN {1} B ON B.MyCode=A.Code WHERE B.TuoCode='{2}')"
                , this._RealTable_Batterys, this._RealTable_Result, this._TuoPanCode.Replace("'", "''")));
            //电芯表
            listSql.Add(string.Format("DELETE FROM {0} WHERE Code IN (SELECT MyCode FROM {1} WHERE TuoCode='{2}')"
                , this._RealTable_Batterys, this._RealTable_Result, this._TuoPanCode.Replace("'", "''")));
            //结果
            listSql.Add(string.Format("DELETE FROM {0} WHERE TuoCode='{1}'"
                            , this._RealTable_Result, this._TuoPanCode.Replace("'", "''")));
            //托盘表
            listSql.Add(string.Format("DELETE FROM LuoLiuAssignerSendMes.DBO.SendMes_FinishedTuoPan WHERE TuoPanCode = '{0}'"
                            , this._TuoPanCode.Replace("'", "''")));
            //正式表
            listSql.Add(string.Format("delete from IFDB.dbo.FST_PACK where BoxBarCode='{0}'"
                            , this._TuoPanCode.Replace("'", "''")));
            //实时槽内数据
            listSql.Add(string.Format("UPDATE Testing_Grooves SET GrooveBtyCont=0 WHERE TuoCode='{0}' and Code='{1}'"
                            , this._TuoPanCode.Replace("'", "''"), this.tbCode.Text.Replace("'", "''")));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "RemoveTuoPan.DoSqls");
                return;
            }
            //此时删除成功
            this.ShowMsgRich("删除成功");
            this.tbTuopanCode.Clear();
            this._TuoPanCode = string.Empty;
            this.dgvList.DataSource = null;
            this.tbTuopanCode.Focus();
            this.tbTuopanCode.Select();

            if (this._MainFrom != null)
                this._MainFrom.RefreshGroovesData();
        }

        private void frmByTuoPanCode_Load(object sender, EventArgs e)
        {
            if(!this.BindData())
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
