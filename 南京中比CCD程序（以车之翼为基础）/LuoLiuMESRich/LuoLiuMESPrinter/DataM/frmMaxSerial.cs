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

namespace LuoLiuMESPrinter.DataM
{
    public partial class frmMaxSerial : Common.frmBase
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
        public frmMaxSerial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Temp_Printer_SetMaxSerial((int)this.numericUpDown1.Value, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DeleteTestingData");
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "删除失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmMaxSerial_Load(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM Temp_PrinterMaxSerial");
            }
            catch(Exception EX)
            {
                wErrorMessage.ShowErrorDialog(this, EX);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.numericUpDown1.Value = 0;
            }
            else
            {
                if (dt.Rows[0]["MaxSerial"].Equals(DBNull.Value))
                    this.numericUpDown1.Value = 0;
                else this.numericUpDown1.Value = int.Parse(dt.Rows[0]["MaxSerial"].ToString());
            }
        }
    }
}
