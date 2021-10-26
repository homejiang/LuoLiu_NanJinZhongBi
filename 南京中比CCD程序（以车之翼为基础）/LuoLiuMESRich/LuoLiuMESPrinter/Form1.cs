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

namespace LuoLiuMESPrinter
{
    public partial class Form1 :Common.frmBase
    {
        
        #region 窗体数据连接实例
        private BLLDAL.DB _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.DB BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.DB();
                return _dal;
            }
        }
        #endregion 
        public Form1()
        {
            InitializeComponent();
            this.dgvDx.AutoGenerateColumns = false;
            //初始化打印输出
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            BindOperator();
        }
        private void BindOperator()
        {
            this.labOperator.Text = Common.CurrentUserInfo.UserName;
        }
        #region 成品编码
        private void InitCpCodeDownDraws()
        {
            List<string> list = new List<string>();
            //工厂代码
            list.Add("OAK");
            this.InitCpCodeDownDraws(this.comCp1, list, "OAK");
            list = new List<string>();
            //产品类型
            list.Add("M");
            this.InitCpCodeDownDraws(this.comCp2, list, "M");
            //电池类型
            list = new List<string>();
            list.Add("E");
            this.InitCpCodeDownDraws(this.comCp3, list, "E");
            //产品类型
            list = new List<string>();
            list.Add("00");
            this.InitCpCodeDownDraws(this.comCp4, list, "00");
            //客户编码
            list = new List<string>();
            list.Add("O0");
            list.Add("01");
            list.Add("02");
            list.Add("03");
            list.Add("04");
            list.Add("05");
            list.Add("06");
            list.Add("07");
            list.Add("08");
            list.Add("09");
            list.Add("10");
            list.Add("11");
            list.Add("12");
            list.Add("13");
            list.Add("14");
            list.Add("15");
            list.Add("16");
            list.Add("17");
            list.Add("18");
            list.Add("19");
            list.Add("20");
            list.Add("21");
            list.Add("22");
            this.InitCpCodeDownDraws(this.comCp5, list, "0O");
            //产品类型
            list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");
            list.Add("F");
            list.Add("G");
            list.Add("H");
            list.Add("I");
            list.Add("J");
            list.Add("K");
            list.Add("L");
            list.Add("M");
            list.Add("N");
            list.Add("O");
            list.Add("P");
            list.Add("Q");
            list.Add("R");
            list.Add("S");
            list.Add("T");
            list.Add("U");
            list.Add("V");
            list.Add("W");
            list.Add("X");
            list.Add("Y");
            list.Add("Z");
            this.InitCpCodeDownDraws(this.comCp6, list, "A");
            //版本
            list = new List<string>();
            list.Add("0");
            this.InitCpCodeDownDraws(this.comCp7, list, "0");
            //生产线
            list = new List<string>();
            list.Add("01");
            list.Add("02");
            list.Add("03");
            list.Add("04");
            list.Add("05");
            list.Add("06");
            list.Add("07");
            this.InitCpCodeDownDraws(this.comCp8, list, "03");
            //工厂代码
            list = new List<string>();
            list.Add("A");
            this.InitCpCodeDownDraws(this.comCp9, list, "A");
        }
        private void InitCpCodeDownDraws(ComboBox combox,List<string> listItems,string sDefaultCode)
        {
            combox.Items.Clear();
            foreach(string s in listItems)
            {
                combox.Items.Add(s);
            }
            combox.Text = sDefaultCode;
        }
        private bool CPSerialRefresh()
        {
            //加载当前序列号
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT MaxSerial FROM Temp_PrinterMaxSerial");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            int iSerial;
            if (dt.Rows.Count == 0)
                iSerial = 0;
            else
            {
                if (dt.Rows[0]["MaxSerial"].Equals(DBNull.Value))
                    iSerial = 0;
                else iSerial = int.Parse(dt.Rows[0]["MaxSerial"].ToString());
            }
            iSerial++;
            string strCode = iSerial.ToString();
            while (strCode.Length < 7)
                strCode = "0" + strCode;
            this.tbCpSerial.Text = strCode;
            return true;
        }
        private void linkCpSerial_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this.CPSerialRefresh())
            {
                this.ShowMsgRich("刷新成功！");
            }
        }
        private void yyMMddRefresh()
        {
            this.tbCpY.Text = "9";
            int iM = DateTime.Now.Month;
            if (iM == 10)
                this.tbCpM.Text = "A";
            else if (iM == 11)
                this.tbCpM.Text = "B";
            else if (iM == 12)
                this.tbCpM.Text = "C";
            else
                this.tbCpM.Text = iM.ToString();
            int iDay = DateTime.Now.Day;
            if (iDay == 10)
                this.tbCpDay.Text = "A";
            else if (iDay == 11)
                this.tbCpDay.Text = "B";
            else if (iDay == 12)
                this.tbCpDay.Text = "C";
            else if (iDay == 13)
                this.tbCpDay.Text = "D";
            else if (iDay == 14)
                this.tbCpDay.Text = "E";
            else if (iDay == 15)
                this.tbCpDay.Text = "F";
            else if (iDay == 16)
                this.tbCpDay.Text = "G";
            else if (iDay == 17)
                this.tbCpDay.Text = "H";
            else if (iDay == 18)
                this.tbCpDay.Text = "J";
            else if (iDay == 19)
                this.tbCpDay.Text = "K";
            else if (iDay == 20)
                this.tbCpDay.Text = "L";
            else if (iDay == 21)
                this.tbCpDay.Text = "M";
            else if (iDay == 22)
                this.tbCpDay.Text = "N";
            else if (iDay == 23)
                this.tbCpDay.Text = "P";
            else if (iDay == 24)
                this.tbCpDay.Text = "R";
            else if (iDay == 25)
                this.tbCpDay.Text = "S";
            else if (iDay == 26)
                this.tbCpDay.Text = "T";
            else if (iDay == 27)
                this.tbCpDay.Text = "V";
            else if (iDay == 28)
                this.tbCpDay.Text = "W";
            else if (iDay == 29)
                this.tbCpDay.Text = "X";
            else if (iDay == 30)
                this.tbCpDay.Text = "Y";
            else if (iDay == 31)
                this.tbCpDay.Text = "0";
            else
                this.tbCpDay.Text = iDay.ToString();
        }
        #endregion
        #region 绝缘板
        private void SetJueYuanStyle()
        {
            this.tbJueYuanBan2.ReadOnly = this.tbJueYuanBan1.Text.Length == 0;
            this.tbJueYuanBan3.ReadOnly = this.tbJueYuanBan2.Text.Length == 0;
            this.tbJueYuanBan4.ReadOnly = this.tbJueYuanBan3.Text.Length == 0;
        }
        private void tbJueYuanBan1_TextChanged(object sender, EventArgs e)
        {
            SetJueYuanStyle();
        }

        private void tbJueYuanBan2_TextChanged(object sender, EventArgs e)
        {
            SetJueYuanStyle();
        }

        private void tbJueYuanBan3_TextChanged(object sender, EventArgs e)
        {
            SetJueYuanStyle();
        }

        private void tbJueYuanBan4_TextChanged(object sender, EventArgs e)
        {
            SetJueYuanStyle();
        }
        #endregion
        #region 电芯数据
        private bool BindDx(string sMkCode)
        {
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = string.Format("SELECT * FROM Produce_Assign_TuoPan WHERE TuoPan='{0}'",
                    sMkCode.Replace("'", "''"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Produce_Assign_TuoPan"));
            strSql = string.Format("SELECT * FROM Produce_Assign_Dx WHERE TuoPan='{0}'",
                    sMkCode.Replace("'", "''"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Produce_Assign_Dx"));
            strSql = string.Format("SELECT Min(DianZu) AS DianZuMin,MAX(DianZu) AS DianZuMax,MIN(V) AS VMin,MAX(V) AS VMax FROM Produce_Assign_Dx WHERE TuoPan='{0}'",
                    sMkCode.Replace("'", "''"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "tongJi"));
            DataSet ds;
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["Produce_Assign_TuoPan"];
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("模块条码不存在！");
                return false;
            }
            DataRow dr = ds.Tables["tongJi"].Rows[0];
            string sMin = dr["DianZuMin"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["DianZuMin"], "#########0.#####");
            string sMax = dr["DianZuMax"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["DianZuMax"], "#########0.#####");
            this.tbRangeR.Text = string.Format("{0}~{1}", sMin, sMax);
            sMin = dr["VMin"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["VMin"], "#########0.#####");
            sMax = dr["VMax"].Equals(DBNull.Value) ? "NULL" : Common.CommonFuns.FormatData.GetStringByDecimal(dr["VMax"], "#########0.#####");
            this.tbRangeV.Text = string.Format("{0}~{1}", sMin, sMax);
            this.tbDxCnt.Text = ds.Tables["Produce_Assign_Dx"].DefaultView.Count.ToString();
            this.dgvDx.DataSource = ds.Tables["Produce_Assign_Dx"];
            return true;
        }
        string _MkCode = string.Empty;
        private void btBindDxDetail_Click(object sender, EventArgs e)
        {
            if (this.tbMkCode.Text.Length == 0) return;
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            if(this.BindDx(this.tbMkCode.Text))
            {
                this._MkCode = this.tbMkCode.Text;
                this.AcitiveTimer(200, "BtTrue");
            }
        }
        #endregion
        #region 打印
        MyPrinter _Printer = null;
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            MyPrinter.PrintFinishedCallback call = new MyPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr });
            }
            catch(Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if(blSucessful)
            {
                this.ShowMsgRich("标签已打印");
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
        }
        #endregion
        public override void AcitiveTimer_Doing(object Arg)
        {
            if(Arg!=null && string.Compare(Arg.ToString(), "BtTrue", true)==0)
            {
                this.btTrue.Focus();
                this.btTrue.Select();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitCpCodeDownDraws();
            CPSerialRefresh();
            yyMMddRefresh();
            SetJueYuanStyle();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            if (this.comCp1.Text.Length == 0 || this.comCp2.Text.Length == 0 || this.comCp3.Text.Length == 0 || this.comCp4.Text.Length == 0
                || this.comCp5.Text.Length == 0 || this.comCp6.Text.Length == 0 || this.comCp7.Text.Length == 0 || this.comCp8.Text.Length == 0
                 || this.comCp9.Text.Length == 0 || this.tbCpY.Text.Length== 0 || this.tbCpM.Text.Length == 0 || this.tbCpDay.Text.Length == 0 || this.tbCpSerial.Text.Length == 0)
            {
                this.ShowMsg("请完善成品编码的组成！");
                return;
            }
            string strCode = this.comCp1.Text + this.comCp2.Text + this.comCp3.Text + this.comCp4.Text + this.comCp5.Text + this.comCp6.Text + this.comCp7.Text + this.comCp8.Text + this.comCp9.Text+ this.tbCpY.Text + this.tbCpM.Text + this.tbCpDay.Text + this.tbCpSerial.Text;
            if(strCode.Length!=24)
            {
                this.ShowMsg("成品编码必须是24位的，请检查编码组成选择是否正确。");
                return;
            }
            if(this.tbJueYuanBan1.Text.Length==0)
            {
                this.ShowMsg("请输入绝缘板编码");
                return;
            }
            if (this._MkCode.Length == 0)
            {
                this.ShowMsg("当前还未加载模块编码。");
                return;
            }
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Temp_Printer_Binding(strCode, this.tbJueYuanBan1.Text, this.tbJueYuanBan2.Text, this.tbJueYuanBan3.Text, this.tbJueYuanBan4.Text,
                    this._MkCode, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return ;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return ;
            }
            this.ClearFormData();//无论打印是否成功，都是需要清空界面的
            //执行成功，打印条码

            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            this._Printer.Printing(strCode);
        }
        private void ClearFormData()
        {
            this.CPSerialRefresh();
            this.yyMMddRefresh();
            this.tbJueYuanBan1.Clear();
            this.tbJueYuanBan2.Clear();
            this.tbJueYuanBan3.Clear();
            this.tbJueYuanBan4.Clear();
            this.SetJueYuanStyle();
            this._MkCode = string.Empty;
            this.tbMkCode.Clear();
            this.tbDxCnt.Clear();
            this.tbRangeR.Clear();
            this.tbRangeV.Clear();
            this.dgvDx.DataSource = null;
        }

        private void 打印成品编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPrinter frm = new frmPrinter();
            frm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 成品编码管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 打印机设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Setting.frmPrinterSetting frm = new Setting.frmPrinterSetting();
            //Setting.frmPrinter frm = new Setting.frmPrinter();
            if (DialogResult.OK == frm.ShowDialog())
            {

            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            this.BindOperator();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            this.BindOperator();
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmPrintedList frm = new DataM.frmPrintedList();
            frm.Show();
        }

        private void tbMkCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btBindDxDetail_Click(null, null);
        }

        private void 序列号最大值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataM.frmMaxSerial frm = new DataM.frmMaxSerial();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.CPSerialRefresh();
        }
    }
}
