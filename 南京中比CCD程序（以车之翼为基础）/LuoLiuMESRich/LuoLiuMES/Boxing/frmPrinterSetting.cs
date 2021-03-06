using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuMES.Boxing
{
    public partial class frmPrinterSetting : Common.frmBase
    {
        public frmPrinterSetting()
        {
            InitializeComponent();
        }

        private void frmPrinterSetting_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = BoxPrinter.AutoPrint;
            int iSeled = -1;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (string.Compare(BoxPrinter.PrinterMachineName, printer, true) == 0)
                {
                    iSeled = this.comQyPrinters.Items.Add(printer);
                }
                else
                {
                    this.comQyPrinters.Items.Add(printer);
                }
            }
            if (iSeled != -1)
                this.comQyPrinters.SelectedIndex = iSeled;

            this.numQRSet_Left.Value =BoxPrinter.QRSet_Left;
            this.numQRSet_Top.Value = BoxPrinter.QRSet_Top;
            this.numWordsSet_Left.Value = BoxPrinter.WordsSet_Left;
            this.numWordsSet_Top.Value = BoxPrinter.WordsSet_Top;
            this.numQRSize.Value = BoxPrinter.QRSize;
            this.numFontSize.Value = (decimal)BoxPrinter.evFont.Size;
            this.numWordsRN.Value = BoxPrinter.WordsRN;

            this.chkAutoComposing.Checked = MESConfig.BoxingConfig.AutoComposing.Auto;
            this.numAutoDelayScd.Value = MESConfig.BoxingConfig.AutoComposing.DelaySeconds;
            /*
           this.numFontSize.Value = (decimal)JPSEntity.Printer.evFont.Size;
           this.chkFontBold.Checked = JPSEntity.Printer.evFont.Bold;
           this.numBkWidth.Value = (decimal)JPSEntity.Printer.BkWidth;
           this.numBkHei.Value = (decimal)JPSEntity.Printer.BkHei;
           this.numBarWidth.Value = (decimal)JPSEntity.Printer.BarWidth;
           this.numBarMarginLeft.Value = (decimal)JPSEntity.Printer.BarMarginLeft;
           this.numPixel.Value = (decimal)JPSEntity.Printer.Pixel;
           this.numQrVersion.Value = (decimal)JPSEntity.Printer.QrVersion;
           */
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            BoxPrinter.AutoPrint = this.checkBox1.Checked;
            this.DialogResult = DialogResult.OK;
            if (this.comQyPrinters.Text.Length == 0)
            {
                this.ShowMsg("请选择打印机！");
                return;
            }
            BoxPrinter.PrinterMachineName = this.comQyPrinters.Text;

            BoxPrinter.QRSet_Left = (int)this.numQRSet_Left.Value;
            BoxPrinter.QRSet_Top = (int)this.numQRSet_Top.Value;
            BoxPrinter.WordsSet_Left = (int)this.numWordsSet_Left.Value;
            BoxPrinter.WordsSet_Top = (int)this.numWordsSet_Top.Value;
            BoxPrinter.QRSize = (int)this.numQRSize.Value;
            BoxPrinter.WordsRN = (int)this.numWordsRN.Value;
            BoxPrinter.evFont = new Font(new FontFamily("宋体"), (float)this.numFontSize.Value, FontStyle.Bold);

            MESConfig.BoxingConfig.AutoComposing.Auto = this.chkAutoComposing.Checked;
            MESConfig.BoxingConfig.AutoComposing.DelaySeconds = (int)this.numAutoDelayScd.Value;
            //保存至配置文件
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "PrintMachineName", BoxPrinter.PrinterMachineName);
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "AutoPrintTuoPan", BoxPrinter.AutoPrint ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "QRSet_Left", BoxPrinter.QRSet_Left.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "QRSet_Top", BoxPrinter.QRSet_Top.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "WordsSet_Left", BoxPrinter.WordsSet_Left.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "WordsSet_Top", BoxPrinter.WordsSet_Top.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "QRSize", BoxPrinter.QRSize.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "FontSize", this.numFontSize.Value.ToString("#########0.##"));
                Common.CommonFuns.ConfigINI.SetValue("BoxPrinter", "WordsRN", BoxPrinter.WordsRN.ToString());
                Common.CommonFuns.ConfigINI.SetValue("BoxAutoComposing", "Auto", MESConfig.BoxingConfig.AutoComposing.Auto ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("BoxAutoComposing", "DelaySeconds", MESConfig.BoxingConfig.AutoComposing.DelaySeconds.ToString());
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            /*
            int iFontSize = (int)this.numFontSize.Value;
            if (this.chkFontBold.Checked)
                JPSEntity.Printer.evFont = new Font(new FontFamily("微软雅黑"), iFontSize, FontStyle.Bold);
            else JPSEntity.Printer.evFont = new Font(new FontFamily("微软雅黑"), iFontSize);
            JPSEntity.Printer.BkWidth = (int)this.numBkWidth.Value;
            JPSEntity.Printer.BkHei = (int)this.numBkHei.Value;
            JPSEntity.Printer.BarWidth = (int)this.numBarWidth.Value;
            JPSEntity.Printer.BarMarginLeft = (int)this.numBarMarginLeft.Value;
            JPSEntity.Printer.Pixel = (int)this.numPixel.Value;
            JPSEntity.Printer.QrVersion = (int)this.numQrVersion.Value;
            //保存至配置文件
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Printer", "PrintMachineName", JPSEntity.Printer.PrintMachineName);
                Common.CommonFuns.ConfigINI.SetValue("Printer", "AutoPrintTuoPan", JPSConfig.AutoPrintTuoPan ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("Printer", "FontSize", iFontSize.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Printer", "FontBold", chkFontBold.Checked ? "1" : "0");
                Common.CommonFuns.ConfigINI.SetValue("Printer", "BkWidth", JPSEntity.Printer.BkWidth.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Printer", "BkHei", JPSEntity.Printer.BkHei.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Printer", "BarWidth", JPSEntity.Printer.BarWidth.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Printer", "BarMarginLeft", JPSEntity.Printer.BarMarginLeft.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Printer", "QrVersion", JPSEntity.Printer.QrVersion.ToString());
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            string strErr;
            Bitmap img = JPSEntity.Printer.GetLabelImg("123456789012", out strErr);
            if(img==null)
            {
                if (strErr.Length == 0) strErr = "效果生成出错，原因未知。";
                this.ShowMsg(strErr);
                return;
            }
            frmPrintRreview frm = new frmPrintRreview();
            frm.Width = img.Width + 25;
            frm.Height = img.Height + 25;
            frm.ViewImage = img;
            frm.Show();
            */
        }
    }
}
