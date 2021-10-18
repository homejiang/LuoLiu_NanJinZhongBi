using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoAssign.APLog
{
    public partial class frmMKBuildingLog : Form
    {
        public bool _Closing = false;
        const string ExceptionLogDir = "MKBuildingLog";
        public JPSEntity.MKBuilding _Listen = null;
        public static frmMKBuildingLog _APLogForm = null;
        public static void MyExit()
        {
            if (_APLogForm != null && !_APLogForm.IsDisposed)
            {
                _APLogForm._Closing = true;
                _APLogForm.Close();
            }
        }
        public static void ShowMyLog(JPSEntity.MKBuilding listen)
        {
            if (_APLogForm == null)
                _APLogForm = new frmMKBuildingLog();
            if (_APLogForm._Listen == null || !_APLogForm._Listen.Equals(listen))
                _APLogForm._Listen = listen;
            if (!_APLogForm.Visible)
                _APLogForm.Show();
            //_APLogForm.Activate();
            _APLogForm._Listen.IsShowLog = true;
        }
        public static void ShowMyLog(string sMsg)
        {
            if (_APLogForm == null || _APLogForm.IsDisposed )
            {
                if (sMsg.Length > 0) return;
                _APLogForm = new frmMKBuildingLog();
                _APLogForm.TopMost = true;
            }
            else if(!_APLogForm.Visible)
            {
                if (sMsg.Length > 0) return;
            }
            if (sMsg.Length > 0)
                _APLogForm.AddMsg(sMsg);
        }
        public frmMKBuildingLog()
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
            if (!_Closing)
            {
                e.Cancel = true;
                this.Hide();
            }
            if (_APLogForm != null && _APLogForm._Listen != null)
                _APLogForm._Listen.IsShowLog = false;
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

        private void frmMKBuildingLog_Load(object sender, EventArgs e)
        {
            if (this._Listen != null)
            {
                this.chkStatus.Checked = this._Listen.IsShowLog_ReadAll;
               
            }
            else
            {
                this.chkStatus.Enabled = false;
                
            }
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            this._Listen.IsShowLog_ReadAll = this.chkStatus.Checked;
        }
        
    }
}