using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.Update
{
    public partial class frmCheckUpdate : frmBase
    {
        public static string CheckUpdateExe()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("select FileName from UpdateExe");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            string strFileName;
            if (dt.Rows.Count > 0)
                strFileName = dt.Rows[0]["FileName"].ToString();
            else strFileName = string.Empty;
            if (strFileName.Length == 0) return string.Empty;
            string strdir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strdir.EndsWith("\\"))
                strdir += "\\";
            strdir = strdir + strFileName;
            if (System.IO.File.Exists(strdir)) return strFileName;
            //不存在要下载
            frmCheckUpdate frm = new frmCheckUpdate();
            frm.UpdateExeName = strFileName;
            frm.ShowDialog();
            return strFileName;
        }
        public string UpdateExeName
        {
            set
            {
                this.labtitle.Text = string.Format("未找到系统必须的文件{0}，系统正在为您重新下载。", value);
            }
        }
        public frmCheckUpdate()
        {
            InitializeComponent();
        }

        private void frmCheckUpdate_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            Application.DoEvents();
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
        }
        private bool Downloadfile()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM UpdateExe");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowErr("未找到文件数据。");
                return false;
            }
            if (dt.Rows[0]["UpdateEXEEntity"].Equals(DBNull.Value))
            {
                this.ShowErr("服务器目标文件为空。");
                return false;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += strName;
            //再次检测是否存在
            if (System.IO.File.Exists(strFile))
                return true;

            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(strFile);
                if (file != null)
                {
                    file.Delete();
                    file = new System.IO.FileInfo(strFile);
                }
                byte[] byFile = (byte[])dt.Rows[0]["UpdateEXEEntity"];
                System.IO.FileStream fs;
                fs = file.OpenWrite();
                fs.Write(byFile, 0, byFile.Length);
                fs.Close();
                fs.Dispose();
                file = null;
            }
            catch (Exception ex)
            {
                this.ShowErr(ex.Message);
                return false;
            }
            return true;
        }
        private void ShowErr(string sMsg)
        {
            this.labResult.ForeColor = Color.Red;
            this.labResult.Text = sMsg;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (Downloadfile())
            {
                this.labResult.ForeColor = Color.Blue;
                this.labResult.Text = "文件已成功下载，您可以点击“关闭”来关闭此窗口。";
            }
            this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}