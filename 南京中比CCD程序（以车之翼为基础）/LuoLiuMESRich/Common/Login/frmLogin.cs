using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.Login
{
    public partial class frmLogin : Common.frmBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        #region 公共属性
        private string _strDefaultUserCode = string.Empty;
        /// <summary>
        /// 默认用户代码
        /// </summary>
        public string DefaultUserCode
        {
            get
            {
                return _strDefaultUserCode;
            }
            set
            {
                this._strDefaultUserCode = value;
            }
        }
        #endregion
        #region 处理函数
        private bool PeriInt()
        {
            //加载默认用户
            if (this.DefaultUserCode.Length > 0)
            {
                this.tbUserCode.Text = this.DefaultUserCode;
                if (!this.BindUserName(this.tbUserCode.Text))
                    return false;
                this.tbPwd.Select();
            }
            else if (Common.CurrentUserInfo.DefaultUserCode.Length > 0)
            {
                this.tbUserCode.Text = Common.CurrentUserInfo.DefaultUserCode;
                if (!this.BindUserName(this.tbUserCode.Text))
                    return false;
                this.tbPwd.Select();
            }
            return true;
        }
        private bool BindUserName(string strUserCode)
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT UserName,UserENName,DeptName,dbo.SysSetting_GetDeptFullName(DeptCode) AS DeptFullName,BanCi,BanCiName FROM V_Sys_Users WHERE UserCode='{0}'", strUserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.tbUserName.Text = dt.Rows.Count == 0 ? string.Empty : (dt.Rows[0]["UserName"].ToString().Length > 0 ? dt.Rows[0]["UserName"].ToString() : dt.Rows[0]["UserENName"].ToString());
            this.tbDeptName.Text = dt.Rows.Count == 0 ? string.Empty : dt.Rows[0]["DeptFullName"].ToString();
            this.tbBanCi.Text = dt.Rows.Count == 0 || dt.Rows[0]["BanCi"].ToString().Length == 0 ? "未分配" : dt.Rows[0]["BanCiName"].ToString();
            return true;
        }
        #endregion
        #region 窗体控件事件
        /// <summary>
        /// 登陆按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT *,dbo.SysSetting_GetDeptFullName(DeptCode) AS DeptFullName FROM V_sys_users WHERE UserCode='{0}'", this.tbUserCode.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("用户编码“" + this.tbUserCode.Text + "”不存在");
                return;
            }
            if (!dt.Rows[0]["Terminated"].Equals(DBNull.Value)
                && (bool)dt.Rows[0]["Terminated"])
            {
                this.ShowMsg("用户编码“" + this.tbUserCode.Text + "”已经被停用，如要登陆，您可以联系管理员重新启用！");
                return;
            }
            if (Common.CommonFuns.EncryptDecryptService.Base64Encrypt(this.tbPwd.Text) != dt.Rows[0]["Pwd"].ToString())
            {
                this.ShowMsg("您输入的密码不正确！");
                return;
            }
            //存储登陆信息
            Common.CurrentUserInfo.UserCode = dt.Rows[0]["UserCode"].ToString();
            Common.CurrentUserInfo.UserName = dt.Rows[0]["UserName"].ToString();
            Common.CurrentUserInfo.DeptCode = dt.Rows[0]["DeptCode"].ToString();
            Common.CurrentUserInfo.DeptName = dt.Rows[0]["DeptName"].ToString();
            Common.CurrentUserInfo.DeptFullName = dt.Rows[0]["DeptFullName"].ToString();
            Common.CurrentUserInfo.IsAdmin = !dt.Rows[0]["IsAdmin"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsAdmin"];
            Common.CurrentUserInfo.IsSuper = !dt.Rows[0]["IsSuper"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsSuper"];
            Common.CurrentUserInfo.BanCi = dt.Rows[0]["BanCi"].ToString();
            Common.CurrentUserInfo.BanCiName = dt.Rows[0]["BanCiName"].ToString();

            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {

                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP += ip.ToString() + "、";
                    }
                }
                if (strIP.Length > 0) strIP = strIP.Substring(0, strIP.Length - 1);
            }
            DateTime detSer;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                return;
            string strLog = string.Format("{0}登录，计算机：{1}（{2}），登录时间：{3}，模块标识：{4}",
                Common.CurrentUserInfo.UserName, strIP, strHostName, detSer.ToString("yyyy-MM-dd HH:mm:ss"), this.Tag == null ? string.Empty : this.Tag.ToString());
            Common.BLLDAL.Msg msg = new Common.BLLDAL.Msg();
            try
            {
                msg.SaveErpLog(strLog, 38);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }
        /// <summary>
        /// 系统设置图标事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picServerConfig_Click(object sender, EventArgs e)
        {
            //ServerConfig.frmDataBase frm = new StorageManage.ServerConfig.frmDataBase();
            //frm.ShowDialog(this);
        }
        /// <summary>
        /// 用户编码回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                tbUserCode_Leave(null, null);
                this.tbPwd.Focus();
            }
        }
        /// <summary>
        /// 登陆密码回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (this.tbUserCode.Text.Length == 0)
                    this.tbUserCode.Focus();
                else
                    this.btLogin_Click(null, null);
            }
        }
        /// <summary>
        /// 用户编码失去焦点事件，此时需要获取用户姓名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserCode_Leave(object sender, EventArgs e)
        {
            if (this.tbUserCode.Text.Length == 0) return;
            if (this.BindUserName(this.tbUserCode.Text))
                this.tbPwd.Focus();
        }
        #endregion
        #region 窗体加载
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.PeriInt();
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindUser frm = new frmFindUser();
            frm.ShowDialog(this);
            if (frm._SelUserCode.Length > 0)
            {
                this.tbUserCode.Text = frm._SelUserCode;
                tbUserCode_Leave(null, null);
            }
        }
    }
}