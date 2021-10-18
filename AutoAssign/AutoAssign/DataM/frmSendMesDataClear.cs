using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.DataM
{
    public partial class frmSendMesDataClear : Common.frmBase
    {
        public frmSendMesDataClear()
        {
            InitializeComponent();
        }
        private void BindData()
        {
            if(this.Binding())
            {
                this.btClearSent.Enabled = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
                this.btClearUnSend.Enabled = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            }
            else
            {
                this.btClearSent.Enabled = false;
                this.btClearUnSend.Enabled = false;
            }
        }
        private bool Binding()
        {
            DataTable dt;
            string strSql = "select State,COUNT(*) AS CNT from IFDB.dbo.FST_PACK GROUP BY State";
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataRow[] drs = dt.Select("State='D'");
            if (drs.Length == 0)
                this.tbD.Text = "0";
            else this.tbD.Text = drs[0]["CNT"].ToString();

            drs = dt.Select("State='Y'");
            if (drs.Length == 0)
                this.tbY.Text = "0";
            else this.tbY.Text = drs[0]["CNT"].ToString();
            return true;
        }

        private void frmSendMesDataClear_Load(object sender, EventArgs e)
        {
            this.btClearSent.Enabled = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            this.btClearUnSend.Enabled = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            this.BindData();
        }

        private void btClearUnSend_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要清除还未上传的数据吗？、\r\n清除后MES系统将无法获取这部分数据，是否继续？")) return;
            string strSql = "delete from IFDB.dbo.FST_PACK where isnull(State,'')='D'";
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            BindData();
        }

        private void btClearSent_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要清除这些数据吗？")) return;
            string strSql = "delete from IFDB.dbo.FST_PACK where isnull(State,'')='Y'";
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strModule = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strModule.EndsWith("\\"))
                strModule += "\\";
            strModule += "导出模板.xls";
            if (!System.IO.File.Exists(strModule))
            {
                System.Windows.Forms.MessageBox.Show("模板文件《导出模板.xls》丢失。", "系统提示");
                return;
            }
            //string strModule = this.GetExcelModule("公共导出模板");
            if (strModule == string.Empty) return;
            object[] arrObj = new object[4];
            arrObj[0] = "SELECT top 10000 * FROM IFDB.DBO.FST_PACK ORDER BY Input_Time ASC";
            arrObj[1] = @"ODBC;DRIVER=SQL Server;SERVER=.\JPS2008;UID=sa;PWD=zxp;APP=Microsoft Office 2003;WSID=KFB011;DATABASE=LuoLiuAssigner";
            arrObj[2] = true;
            arrObj[3] = Common.CurrentUserInfo.UserCode;
            OperatExcelRich.OutputExcel(this, strModule, string.Format("MES数据备份_{0}.xls", DateTime.Now.ToString("yyyyMMdd")), arrObj);
        }
    }
}
