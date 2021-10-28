using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace AutoAssign
{
    public class MyPrinter
    {
        /// <summary>
        /// 是否自动调用打印
        /// </summary>
        public static bool AutoPrint = true;
        static Pen pen = new Pen(Color.Black);
        public static Font evFont = new Font(new FontFamily("宋体"), 12, FontStyle.Bold);
        public static int QRSize = 60;//二维码尺寸，单位：像素
        public static string PrinterMachineName = "";
        public static int QRSet_Rectangle = 60;
        public static float QRSet_Inch = 0.5F;
        public static int QRSet_Left = 30;
        public static int QRSet_Top = 5;
        public static int WordsSet_Left = 70;
        public static int WordsSet_Top = 15;
        public Bitmap CreateQRCode(string asset, int iSize)
        {
            EncodingOptions options = new ZXing.QrCode.QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = iSize,
                Height = iSize
            };
            Hashtable hints = new Hashtable();
            hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L);//纠错级别
            hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8");//编码格式
            options.Margin = 0;

            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = ZXing.BarcodeFormat.QR_CODE;
            writer.Options = options;
            return writer.Write(asset);
        }
        #region 打印过程
        public event PrintFinishedCallback PrintFinishedNotice = null;
        PrintDocument _PrintDocument = new PrintDocument();
        public string MyTuoPanCode = string.Empty;
        public short MyCaoIndex = 0;
        public MyPrinter()
        {
            
            this._PrintDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintA4Page);
            this._PrintDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
            this._PrintDocument.DefaultPageSettings.Margins.Top = 0;
            this._PrintDocument.DefaultPageSettings.Margins.Bottom = 0;
            this._PrintDocument.DefaultPageSettings.Margins.Left = 0;
            this._PrintDocument.DefaultPageSettings.Margins.Right = 0;
            this._PrintDocument.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            SetPrinterMachine(MyPrinter.PrinterMachineName);
        }
        #region 公共函数
        public bool SetPrinterMachine(string sMachineName)
        {
            try
            {
                if (_PrintDocument.DefaultPageSettings.PrinterSettings.PrinterName != sMachineName)
                    _PrintDocument.DefaultPageSettings.PrinterSettings.PrinterName = sMachineName;
            }
            catch(Exception ex)
            {
                this.PrintFinishedNoticeAsyn(this.MyCaoIndex, this.MyTuoPanCode, false, string.Format("设置打印机出错{0}({1})", ex.Message, ex.Source));
                return false;
            }
            return true;
        }
        public bool Printing(string sTuoPanCode, short iCaoIndex)
        {
            this.MyTuoPanCode = sTuoPanCode;
            this.MyCaoIndex = iCaoIndex;
            if (!this.SetPrinterMachine(MyPrinter.PrinterMachineName))
                return false;
            try
            {
                _PrintDocument.Print();
            }
            catch (Exception ex)
            {
                this.PrintFinishedNoticeAsyn(iCaoIndex,sTuoPanCode, false, string.Format("调用打印机出错，请检查打印机是否连接？{0}({1})", ex.Message, ex.Source));
                return false;
            }
            return true;
        }
        #endregion
        private void printDocument_PrintA4Page(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                Bitmap map = this.CreateQRCode(this.MyTuoPanCode, MyPrinter.QRSize);
                map.SetResolution(203F, 203F);
                Rectangle destRect = new Rectangle(MyPrinter.QRSet_Left, MyPrinter.QRSet_Top, QRSet_Rectangle, QRSet_Rectangle);
                ImageAttributes imageAttributes = new ImageAttributes();
                e.Graphics.DrawImage(map, destRect, 0, 0, QRSet_Inch, QRSet_Inch, GraphicsUnit.Inch, imageAttributes);
                e.Graphics.DrawString($"{this.MyCaoIndex}#{this.MyTuoPanCode}", evFont, System.Drawing.Brushes.Black, new Point(MyPrinter.WordsSet_Left, MyPrinter.WordsSet_Top));
                this.PrintFinishedNoticeAsyn(this.MyCaoIndex, this.MyTuoPanCode, true, string.Empty);
            }
            catch (Exception ex)
            {
                this.PrintFinishedNoticeAsyn(this.MyCaoIndex, this.MyTuoPanCode, false, string.Format("Printing.Err:{0}({1})", ex.Message, ex.Source));
            }
        }
        private void PrintFinishedNoticeAsyn(short iCaoIndex,string sTuoPanCode, bool blSucessful, string sErr)
        {
            //if (this.PrintFinishedNotice == null) return;
            //    PrintFinishedCallback call = new PrintFinishedCallback(CallPrintFinishedNotice);
            //try
            //{
            //    this.MyForm.Invoke(call, new object[] { iCaoIndex,sTuoPanCode, blSucessful, sErr });
            //}
            //catch (Exception ex)
            //{

            //}
            if (this.PrintFinishedNotice != null)
                this.PrintFinishedNotice(iCaoIndex, sTuoPanCode, blSucessful, sErr);
        }
        private void CallPrintFinishedNotice(short iCaoIndex, string sTuoPanCode, bool blSucessful, string sErr)
        {
            if (this.PrintFinishedNotice != null)
                this.PrintFinishedNotice(iCaoIndex, sTuoPanCode, blSucessful, sErr);
        }

        public delegate void PrintFinishedCallback(short iIndex,string sTuoPanCode, bool blSucessful, string sErr);
        #endregion
    }
}
