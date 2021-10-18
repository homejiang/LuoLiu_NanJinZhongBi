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
    public partial class frmByCaoIndex : Common.frmBase
    {
        public frmMain1 _MainFrom = null;
        string _RealTable_Batterys = string.Empty;
        string _RealTable_Result = string.Empty;
        int _CaoIndex = 0;
        public frmByCaoIndex(string sTestCode)
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
        private bool BindCaoIndex()
        {
            DataTable dt;
            string strSql = string.Format("SELECT CaoIndex FROM {0} WHERE ISNULL(TuoCode,'')='' GROUP BY CaoIndex"
                , this._RealTable_Result);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comboBox1.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                this.comboBox1.Items.Add(dr["CaoIndex"].ToString());
            }
            return true;
        }
        private bool BindSN(int iCaoIndex)
        {
            DataTable dt;
            string strSql = string.Format("select A.*,dbo.GetQualityView(a.Quality) as QualityView,B.SN from {0} A LEFT JOIN {1} B ON B.Code=A.MyCode where ISNULL(A.CaoIndex,0)='{2}'", this._RealTable_Result, this._RealTable_Batterys, iCaoIndex);
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
                this.ShowMsg("未在槽号" + iCaoIndex.ToString() + "下找到任何电芯数据，请核实输入的槽号。");
                return false;
            }
            if(dt.Select("isnull(TuoCode,'')<>''").Length>0)
            {
                this.ShowMsg("您选中的槽中包含有托盘信息，请通过托盘编号删除！");
                return false;
            }
            this._CaoIndex = iCaoIndex;
            this.dgvList.DataSource = dt;
            return true;
        }

        private void btBindData_Click(object sender, EventArgs e)
        {
            if(this.comboBox1.Text.Length==0)
            {
                this.ShowMsg("请输入槽号。");
                return;
            }
            int iCaoIndex;
            if(!int.TryParse(this.comboBox1.Text,out iCaoIndex))
            {
                this.ShowMsg("请正确输入槽号，需要一个正整数。");
                return;
            }
            this.btTrue.Enabled = this.BindSN(iCaoIndex);
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
             * 注意：先删除SN表再删除电芯表，这是必须的，其他顺序无所谓
             * ***************/
            if (string.Compare(this._CaoIndex.ToString(), this.comboBox1.Text, true) != 0)
            {
                this.ShowMsg("请先加载槽数据。");
                return;
            }
            List<string> listSql = new List<string>();
            //SN表
            listSql.Add(string.Format("DELETE FROM SN WHERE SN IN (SELECT A.SN FROM {0} A LEFT JOIN {1} B ON B.MyCode=A.Code WHERE B.CaoIndex='{2}' AND ISNULL(B.TuoCode,'')='')"
                , this._RealTable_Batterys, this._RealTable_Result, this._CaoIndex.ToString()));
            //电芯表
            listSql.Add(string.Format("DELETE FROM {0} WHERE Code IN (SELECT MyCode FROM {1} WHERE CaoIndex='{2}' AND ISNULL(TuoCode,'')='')"
                , this._RealTable_Batterys, this._RealTable_Result, this._CaoIndex.ToString()));
            //结果
            listSql.Add(string.Format("DELETE FROM {0} WHERE CaoIndex='{1}' AND ISNULL(TuoCode,'')=''"
                            , this._RealTable_Result, this._CaoIndex.ToString()));
            //当前槽内数据
            listSql.Add(string.Format("UPDATE Testing_Grooves SET GrooveBtyCont=0 WHERE Code='{0}' and GrooveNo={1} and isnull(TuoCode,'')=''"
                            , this.tbCode.Text.Replace("'", "''"), this._CaoIndex.ToString()));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "RemoveCaodata.DoSqls");
                return;
            }
            //此时删除成功
            this.ShowMsgRich("删除成功");
            this.comboBox1.Text = string.Empty;
            this._CaoIndex = 0;
            this.dgvList.DataSource = null;
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
            else
            {
                this.BindCaoIndex();
            }
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue != 13) return;
            this.btBindData_Click(null, null);
        }
    }
}
