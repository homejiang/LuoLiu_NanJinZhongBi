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

namespace AutoAssign.BasicData
{
    public partial class frmUserManager : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.BasicData _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.BasicData BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.BasicData();
                return _dal;
            }
        }
        #endregion 
        public frmUserManager()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable("select * from V_Sys_Users WHERE ISNULL(IsSuper,0)=0");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "UsersBindDatas");
                return false;
            }
            this.dgvList.DataSource = dt;
            return true; ;
        }

        private void frmProcessCode_Load(object sender, EventArgs e)
        {
            this.comDeptCode.Items.Add("操作员");
            if (Common.CurrentUserInfo.IsSuper)
                this.comDeptCode.Items.Add("管理员");
            if (this.comDeptCode.Items.Count == 1)
                this.comDeptCode.SelectedIndex = 0;
            this.BindData();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (this.BindData())
                this.ShowMsgRich("刷新成功！");
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            if(this.tbCode.Text.Length==0)
            {
                this.ShowMsg("请输入用户代码！");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT COUNT(*) FROM SYS_USERS WHERE UserCode='{0}'", this.tbCode.Text.Replace("'","''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "校验用户代码是否重号");
                return;
            }
            if(int.Parse(dt.Rows[0][0].ToString())>0)
            {
                this.ShowMsg("用户代码已经存在！");
                return;
            }
            if(this.tbName.Text.Length==0)
            {
                this.ShowMsg("请输入姓名！");
                return;
            }
            string strDeptcode;
            short iAdmin;
            if (this.comDeptCode.SelectedIndex == 0)
            {
                strDeptcode = "sys03";
                iAdmin = 0;
            }
            else if (this.comDeptCode.SelectedIndex == 1)
            {
                strDeptcode = "sys02";
                iAdmin = 1;
            }
            else
            {
                this.ShowMsg("请选择账户类型。");
                return;
            }
            string strPwd = Common.CommonFuns.EncryptDecryptService.Base64Encrypt(this.tbPwd.Text);
            string strSql = string.Format("INSERT INTO SYS_USERS(UserCode,UserName,DeptCode,Pwd,IsAdmin) VALUES('{0}','{1}','{2}','{3}',{4})"
                , this.tbCode.Text.Replace("'", "''"), this.tbName.Text.Replace("'", "''"), strDeptcode, strPwd, iAdmin);
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.insert");
                return;
            }
            this.tbCode.Clear();
            this.tbName.Clear();
            this.BindData();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            int iReturnValue;
            string strMsg;
            foreach (int row in list)
            {
                string sCode = dt.DefaultView[row].Row["UserCode"].ToString();
                try
                {
                    this.BllDAL.UserDelete(sCode, out iReturnValue, out strMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Users");
                    break;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0) strMsg = "删除失败，原因未知。";
                    this.ShowMsg(strMsg);
                    return;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbOn_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sCode = dt.DefaultView[row].Row["UserCode"].ToString();
                string strSql = string.Format("update sys_Users set Terminated=0 where Usercode='{0}'", sCode.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Terminated.0");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbOff_Click(object sender, EventArgs e)
        {
            if (!JPSFuns.CheckUserPower())
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要删除的行。");
                return;
            }
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sCode = dt.DefaultView[row].Row["UserCode"].ToString();
                string strSql = string.Format("update sys_Users set Terminated=1 where Usercode='{0}'", sCode.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Terminated.1");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.BindData();
        }

        private void tsbResetPwd_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能重置！");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("数据源为空。");
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvList);
            if (list.Count == 0)
            {
                this.ShowMsg("请选中要重置的用户。");
                return;
            }
            if (!this.IsUserConfirm("您确定要重置密码吗？\r\n重置后密码为：1234")) return;
            bool blUpdated = false;
            foreach (int row in list)
            {
                string sCode = dt.DefaultView[row].Row["UserCode"].ToString();
                string strSql = string.Format("update sys_Users set pwd='MTIzNA==' where Usercode='{0}'", sCode.Replace("'", "''"));
                try
                {
                    Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "DOSQL.delete.Terminated.1");
                    break;
                }
                blUpdated = true;
            }
            if (blUpdated)
                this.ShowMsg("重置完成！");
        }

        private void linkSelect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectUser frm = new frmSelectUser();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedRows == null || frm.SelectedRows.Count == 0) return;
            DataRow dr = frm.SelectedRows[0];
            this.tbCode.Text = dr["UserCode"].ToString();
            this.tbName.Text = dr["UserName"].ToString();
            this.tbPwd.Text = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(dr["Pwd"].ToString());
            
        }
    }
}
