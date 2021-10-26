using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EleCardComposing
{
    public partial class frmPackCode : Common.frmBaseEdit
    {
        public frmPackCode()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
           
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
            return true;
        }
        public bool GoOn
        {
            get
            {
                return this.checkBox1.Checked;
            }
            set
            {
                this.checkBox1.Checked = value;
            }
        }
        public string PackCode
        {
            get
            {
                return this.tbPackCode.Text;
            }
        }
        private void frmCableCode_Load(object sender, EventArgs e)
        {
            this.Perinit();
        }
        MyPrinter _Printer = null;
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
                this.ShowMsgRich("标签已打印");
               
            }
            else
            {
                //此时要弹出重新打印的对话框
                frmPrintFaild frm = new frmPrintFaild(sTuoPanCode, sErr);
                frm.ShowDialog(this);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.tbPackCode.Text == string.Empty) return;
            //此时绑定成功调用打印
            this._Printer.Printing(this.tbPackCode.Text);
            //this.DialogResult = DialogResult.OK;
        }
    }
}
