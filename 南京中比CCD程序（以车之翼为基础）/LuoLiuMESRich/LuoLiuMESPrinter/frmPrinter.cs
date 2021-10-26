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
    public partial class frmPrinter : Common.frmBase
    {
        public frmPrinter()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.labLen.Text = string.Format("标签长度：{0} 位", this.textBox1.Text.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0)
            {
                this.ShowMsg("请输入标签编号。");
                return;
            }
            if (this._Printer == null)
            {
                this.ShowMsg("打印机对象为空！");
                return;
            }
            this._Printer.Printing(this.textBox1.Text);
        }
        LuoLiuMESPrinter.MyPrinter _Printer = null;
        private void frmPrinter_Load(object sender, EventArgs e)
        {
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
        }

        private void _Printer_PrintFinishedNotice( string sTuoPanCode, bool blSucessful, string sErr)
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
                this.ShowMsgRich("标签已打印");
            }
            else
            {
                if (sErr.Length == 0) sErr = "打印失败，原因未知！";
                this.ShowMsg(sErr);
            }
        }

    }
}
