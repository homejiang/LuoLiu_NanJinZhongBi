using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuDianHan
{
    public partial class frmMyException : Form
    {
        const string ExceptionLogDir = "ExceptionLog";
        private static frmMyException _APExceptionForm = null;
        public static void ShowException(string sMsg)
        {
            if (_APExceptionForm == null || _APExceptionForm.IsDisposed) _APExceptionForm = new frmMyException();
            if (sMsg.Length > 0)
                _APExceptionForm.showMsg(sMsg);
            if (!_APExceptionForm.Visible)
                _APExceptionForm.Show();
            //_APExceptionForm.Activate();
        }
        public static void APExceptionExit()
        {
            //���׹ر��쳣����
            if (_APExceptionForm != null)
                _APExceptionForm.Close();
        }
        public frmMyException()
        {
            InitializeComponent();
            this.labMac.Text = string.Format("�����豸:{0} ���쳣��Ϣ",Config.MacName);
        }
        public void AddMsg(string sMsg)
        {
            if (sMsg.Length > 4000)
                button1_Click(null, null);
            this.richTextBox1.Text = string.Format("����ʱ�䣺{0}\r\n{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sMsg) + this.richTextBox1.Text;
        }
        public void showMsg(string sMsg)
        {
            this.richTextBox1.Text = string.Format("����ʱ�䣺{0}\r\n{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), sMsg);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //�����ĵ�·��
            try
            {
                if (!System.IO.Directory.Exists(ExceptionLogDir))
                {
                    System.IO.Directory.CreateDirectory(ExceptionLogDir);
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
            }
            //��ȡ�ļ���
            string strFileName = DateTime.Now.ToString("yyMMddHHmmss");
            string strfullPath = ExceptionLogDir + "\\" + strFileName + ".log";
            while (System.IO.File.Exists(strfullPath))
            {
                strFileName += "_1";
                strfullPath = ExceptionLogDir + "\\" + strFileName + ".log";
            }
            System.IO.StreamWriter swLog;
            StringBuilder sbcontent = new StringBuilder();
            sbcontent.Append("-----------------�洢ʱ��:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "-----------------\r\n");
            sbcontent.Append("-----------------��ǰ������:" + Common.CurrentUserInfo.UserName + "-----------------\r\n");
            for (int i = 0; i < this.richTextBox1.Lines.Length; i++)
            {
                sbcontent.Append(this.richTextBox1.Lines[i]);
                sbcontent.Append("\r\n");
            }
            try
            {
                using (swLog = System.IO.File.CreateText(strfullPath))
                {

                    swLog.Write(sbcontent.ToString());		//д���ļ�����
                    swLog.Close(); //�����ļ�
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                //return;
            }
            this.richTextBox1.Clear();
        }
    }
}