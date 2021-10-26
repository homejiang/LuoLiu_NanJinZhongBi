using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuMESPrinter
{
    public partial class frmPrintFaild : Common.frmBase
    {
        MyPrinter _Printer = null;
        string _Code = string.Empty;
        public frmPrintFaild(string sCode,string sMsg)
        {
            InitializeComponent();
            this._Code = sCode;
            this.labMsg.Text = "错误内容：" + sMsg;
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
        }
        private void _Printer_PrintFinishedNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            MyPrinter.PrintFinishedCallback call = new MyPrinter.PrintFinishedCallback(PrinterNotice);
            try
            {
                this.Invoke(call, new object[] { sTuoPanCode, blSucessful, sErr });
            }
            catch (Exception ex)
            {

            }
        }
        private void PrinterNotice(string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (blSucessful)
            {
                this.DialogResult = DialogResult.OK;
                this.ShowMsgRich("标签已打印");
            }
            else
            {
                this.ShowMsg(sErr);
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            this._Printer.Printing(this._Code);
        }
    }
}
