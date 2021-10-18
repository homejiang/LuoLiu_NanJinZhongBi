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
namespace AutoAssign.ExpFuns
{
    public partial class frmSendPrintCmd : Common.frmBase
    {
        JPSEntity.PrinterControl _Printer = null;
        string _TestCode = string.Empty;
        public frmSendPrintCmd(JPSEntity.PrinterControl printer,string sTestCode)
        {
            InitializeComponent();
            this._Printer = printer;
            this._TestCode = sTestCode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                this.ShowMsg("请选择槽号！");
                return;
            }
            if (this.textBox1.Text.Length==0)
            {
                this.ShowMsg("请输入托盘号！");
                return;
            }
            if(_Printer==null)
            {
                this.ShowMsg("打印对象为空！");
                return;
            }
            if(this._Printer.RequestPrint((short)(this.comboBox1.SelectedIndex + 1), this.textBox1.Text))
            {
                this.DialogResult = DialogResult.OK; 
            }

        }

        private void frmSendPrintCmd_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                this.comboBox1.Items.Add("槽" + i.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._TestCode.Length == 0) return;
            if (this.comboBox1.SelectedIndex == -1) return;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select ResultTable from Testing_Main where Code='{0}'",this._TestCode.Replace("'","''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0) return;
            string strResultTable = dt.Rows[0]["ResultTable"].ToString();
            if (strResultTable.Length == 0) return;
            string strSql = string.Format(@"select TOP 1 A.TuoPanCode from LuoLiuAssignerSendMes.dbo.SendMes_FinishedTuoPan A LEFT JOIN {0} B ON B.TuoCode=A.TuoPanCode
                where A.TestCode='{1}' AND B.CaoIndex={2}  order by A.FinishedTime desc", strResultTable, this._TestCode, this.comboBox1.SelectedIndex + 1);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, strSql);
                return;
            }
            if (dt.Rows.Count == 0) return;
            this.textBox1.Text = dt.Rows[0]["TuoPanCode"].ToString();
        }
    }
}
