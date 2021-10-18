using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Printer
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
            this._Printer.Printing(this.textBox1.Text, 0);
        }
        AutoAssign.MyPrinter _Printer = null;
        private void frmPrinter_Load(object sender, EventArgs e)
        {
            this._Printer = new MyPrinter();
            this._Printer.PrintFinishedNotice += _Printer_PrintFinishedNotice;
        }

        private void _Printer_PrintFinishedNotice(short iIndex, string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (blSucessful)
                MyShowMsgAsyn(true, "打印成功");
            else
            {
                MyShowMsgAsyn(false, string.Format("编号\"{0}\"打印失败：{1}", sTuoPanCode, sErr));
            }
        }
        private void MyShowMsgAsyn(bool blSucesfule,string sMsg)
        {
            if (blSucesfule)
            {
                JPSEntity.ShowMsgAsynCallBack call = new JPSEntity.ShowMsgAsynCallBack(ShowMsgRich);
                try
                {
                    this.Invoke(call, new object[] { sMsg });
                }
                catch(Exception ex)
                {

                }
            }
            else
            {
                JPSEntity.ShowMsgAsynCallBack call = new JPSEntity.ShowMsgAsynCallBack(ShowMsg);
                try
                {
                    this.Invoke(call, new object[] { sMsg });
                }
                catch (Exception ex)
                {

                }

            }

        }

    }
}
