using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class frmPrinterLog : Form
    {
        const string ExceptionLogDir = "frmPrinterLog";
        public static frmPrinterLog _APLogForm = null;
        public static void ShowMyLog(string sMsg)
        {
            if (_APLogForm == null || _APLogForm.IsDisposed )
            {
                if (sMsg.Length > 0) return;
                _APLogForm = new frmPrinterLog();
                _APLogForm.TopMost = true;
            }
            else if(!_APLogForm.Visible)
            {
                if (sMsg.Length > 0) return;
            }
            if (sMsg.Length > 0)
                _APLogForm.AddMsg(sMsg);
            _APLogForm.Show();
            _APLogForm.Activate();
        }
        public frmPrinterLog()
        {
            InitializeComponent();
        }
        public void AddMsg(string sMsg)
        {
            if (this.chkStop.Checked) return;
            if ((sMsg.Length + this.richTextBox1.Text.Length) > 40000)
                button1_Click(null, null);
            if (!sMsg.EndsWith("\r\n"))
                sMsg += "\r\n";
            this.richTextBox1.Text = string.Format("发生时间：{0}\r\n{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), sMsg) + this.richTextBox1.Text;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //保存文档路径
            try
            {
                if (!System.IO.Directory.Exists(ExceptionLogDir))
                {
                    System.IO.Directory.CreateDirectory(ExceptionLogDir);
                }
            }
            catch (Exception ex)
            {
               // wErrorMessage.ShowErrorDialog(this, ex);
            }
            //获取文件名
            string strFileName = DateTime.Now.ToString("yyMMddHHmmss");
            string strfullPath = ExceptionLogDir + "\\" + strFileName + ".log";
            while (System.IO.File.Exists(strfullPath))
            {
                strFileName += "_1";
                strfullPath = ExceptionLogDir + "\\" + strFileName + ".log";
            }
            System.IO.StreamWriter swLog;
            StringBuilder sbcontent = new StringBuilder();
            sbcontent.Append("-----------------存储时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------\r\n");
           // sbcontent.Append("-----------------当前操作人:" + Common.CurrentUserInfo.UserName + "-----------------\r\n");
            for (int i = 0; i < this.richTextBox1.Lines.Length; i++)
            {
                sbcontent.Append(this.richTextBox1.Lines[i]);
                sbcontent.Append("\r\n");
            }
            try
            {
                using (swLog = System.IO.File.CreateText(strfullPath))
                {

                    swLog.Write(sbcontent.ToString());		//写入文件内容
                    swLog.Close(); //保存文件
                }
            }
            catch (Exception ex)
            {
               // wErrorMessage.ShowErrorDialog(this, ex);
                //return;
            }
            this.richTextBox1.Clear();
        }
    }
}