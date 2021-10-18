using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        MyPrinter _MyPrinter = null;

        private void button1_Click(object sender, EventArgs e)
        {
            _MyPrinter.SetPrinterMachine(this.comQyPrinters.Text);
            _MyPrinter.Printing(this.textBox1.Text, 8);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            _MyPrinter = new MyPrinter();
            _MyPrinter.PrintFinishedNotice += _MyPrinter_PrintFinishedNotice;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                this.comQyPrinters.Items.Add(printer);
            }
        }

        private void _MyPrinter_PrintFinishedNotice(short iIndex, string sTuoPanCode, bool blSucessful, string sErr)
        {
            string str = string.Format("Index:{0},Tuopan:{1},Sucessful:{2},Err:{3}"
                , iIndex, sTuoPanCode, blSucessful, sErr);
            this.textBox2.Text = str;
        }
    }
}
