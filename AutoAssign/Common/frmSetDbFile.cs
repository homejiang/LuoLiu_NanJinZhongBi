using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common
{
    public partial class frmSetDbFile : Common.frmBase
    {
        public frmSetDbFile()
        {
            InitializeComponent();
        }
        public string DBPath
        {
            get { return this.tbDbFile.Text; }
            set { this.tbDbFile.Text = value; }
        }

        private void linkSelDb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            fdialog.InitialDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//将默认路径设置为当前程序所在路径
            fdialog.Filter = "Access File(*.mdb)|*.mdb";//过滤出文件后缀
            fdialog.Multiselect = false;//不允许多选
            if (DialogResult.OK != fdialog.ShowDialog(this)) return;
            this.tbDbFile.Text = fdialog.FileName;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            //先要校验是否文件已正确选择
            if (this.tbDbFile.Text == string.Empty)
            {
                this.ShowMsg("请选择数据库文件。");
                return;
            }
            if (!System.IO.File.Exists(this.tbDbFile.Text))
            {
                this.ShowMsg("文件“"+this.tbDbFile.Text+"”不存在！");
                return;
            }
            //存储路径到config.ini文件中
            Common.CommonDAL.DoSqlCommandLocal.INIFileName = "Server.ini";
            try
            {
                //此属于对外部文件的操作，可能会受外部文件未知因素的影响，所以需要用try-catch扑捉错误，并将错误信息显示给客户，以便解决
                Common.CommonFuns.ConfigINI.SetValue("DBFile", "FullPath", this.tbDbFile.Text);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return ;
            }
            //设定路径
            Common.CommonDAL.LocalDBConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password=atlascopco", this.tbDbFile.Text);
            this.DialogResult = DialogResult.OK;//标识执行正确且关闭窗口
        }

        private void frmSetDbFile_Load(object sender, EventArgs e)
        {
            //读取已经设置好的数据，如果还未设置过也无所谓
            Common.CommonDAL.DoSqlCommandLocal.INIFileName = "Server.ini";
            string strPath = string.Empty;
            try
            {
                //此属于对外部文件的操作，可能会受外部文件未知因素的影响，所以需要用try-catch扑捉错误，并将错误信息显示给客户，以便解决
                strPath = Common.CommonFuns.ConfigINI.GetString("DBFile", "FullPath", string.Empty);//读取配置文件种的数据库物理路径
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
            this.tbDbFile.Text = strPath;
        }
    }
}