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
    public partial class frmLogin1 : Common.frmBase
    {
        public frmLogin1()
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
                return this._strDefaultUserCode;
            }
            set
            {
                this._strDefaultUserCode = value;
            }
        }
        public string MoudleEnumList = string.Empty;
        #endregion
        #region 处理函数
        private bool PeriInt()
        {
            return true;
        }
        private bool BindUserName()
        {
            DataTable dt = null;
            string strModules = this.MoudleEnumList;
            if (!strModules.StartsWith("|"))
                strModules = "|" + strModules;
            if (!strModules.EndsWith("|"))
                strModules = strModules + "|";
            string strSql = string.Format("EXEC Common_Login1_GetUserList '{0}'", strModules.Replace("'", "''"));
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comUsers.DisplayMember = "Text";
            this.comUsers.ValueMember = "Value";
            Common.MyEntity.ComboBoxItem item;
            int iSeledIndex = -1;
            foreach (DataRow dr in dt.Rows)
            {
                item = new Common.MyEntity.ComboBoxItem(string.Format("{0}({1})", dr["UserName"], dr["UserCode"]), dr["DeptName"].ToString(), dr["UserCode"].ToString());
                if (string.Compare(dr["UserCode"].ToString(), DefaultUserCode, true) == 0)
                    iSeledIndex = this.comUsers.Items.Add(item);
                else
                    this.comUsers.Items.Add(item);
            }
            this.comUsers.SelectedIndex = iSeledIndex;
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
             Common.MyEntity.ComboBoxItem item = this.comUsers.SelectedItem as Common.MyEntity.ComboBoxItem;
             if (item == null || item.Value == null || item.Value.ToString().Length == 0)
             {
                 this.ShowMsg("请选择登陆用户。");
                 this.comUsers.Focus();
             }
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT *,dbo.SysSetting_GetDeptFullName(DeptCode) AS DeptFullName FROM V_sys_users WHERE UserCode='{0}'", item.Value.ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("用户编码“" +  item.Text + "”不存在");
                return;
            }
            if (!dt.Rows[0]["Terminated"].Equals(DBNull.Value)
                && (bool)dt.Rows[0]["Terminated"])
            {
                this.ShowMsg("用户编码“" + item.Text + "”已经被停用，如要登陆，您可以联系管理员重新启用！");
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
            //this.ShowMsg(int.MaxValue.ToString().Length.ToString());
            //ServerConfig.frmDataBase frm = new StorageManage.ServerConfig.frmDataBase();
            //frm.ShowDialog(this);
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
                Common.MyEntity.ComboBoxItem item = this.comUsers.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                    this.comUsers.Focus();
                else
                    this.btLogin_Click(null, null);
            }
        }
        private void comUsers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                Common.MyEntity.ComboBoxItem item = this.comUsers.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                    this.comUsers.Focus();
                else
                    this.tbPwd.Focus();
            }
        }
        
        private void comUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //显示部门
            string strDeptName;
            Common.MyEntity.ComboBoxItem item = this.comUsers.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                strDeptName = string.Empty;
            else strDeptName = item.Text1;
            this.tbDeptName.Text = strDeptName;
        }
        #endregion
        #region 窗体加载
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.PeriInt();
            this.BindUserName();
            this.comUsers.Focus();
        }
        #endregion

    }
}