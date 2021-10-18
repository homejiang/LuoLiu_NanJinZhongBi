using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
namespace AutoAssign.Login
{
    public partial class frmModifyPwd : Common.frmBase
    {
        public frmModifyPwd()
        {
            InitializeComponent();

        }
        public string UserCode = string.Empty;

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("��ǰ����״̬�����޸ġ�");
                return;
            }
            //����ԭʼ�����Ƿ���ȷ
            DataTable dt = null;
            string strPwd = this.tbOrgPad.Text;
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Encrypt(strPwd);
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT pwd FROM sys_Users WHERE UserCode='{0}'", UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("�û�����\"" + this.UserCode + "\"�����ڻ��Ѿ���ɾ����");
                return;
            }
            if (dt.Rows[0]["pwd"].ToString() != strPwd)
            {
                this.ShowMsg("�������ԭʼ���벻��ȷ��");
                this.tbOrgPad.Focus();
                return;
            }
            if (this.tbNewPwd1.Text==string.Empty)
            {
                this.ShowMsg("�����������롣");
                this.tbNewPwd1.Focus();
                return;
            }
            //У��2�����������Ƿ���ȷ
            if (this.tbNewPwd1.Text != this.tbNewPwd2.Text)
            {
                this.ShowMsg("��2������������Ĳ�һ����");
                this.tbNewPwd2.Focus();
                return;
            }
            //ִ���������
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Encrypt(this.tbNewPwd1.Text);
            string strSql = string.Format("UPDATE sys_Users SET Pwd='{0}' WHERE UserCode='{1}'", strPwd.Replace("'", "''"), UserCode.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("��������ɹ���");
            this.DialogResult = DialogResult.OK;
        }

        private void frmModifyPwd_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT UserName,DeptName FROM v_sys_Users WHERE UserCode='{0}'", UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return;
            }
            else
            {
                this.FormState = Common.MyEnums.FormStates.Edit;
                this.tbDeptName.Text = dt.Rows[0]["DeptName"].ToString();
                this.tbUserCode.Text = this.UserCode;
                this.tbUserName.Text = dt.Rows[0]["UserName"].ToString();
            }
            this.tbOrgPad.Select();
        }
    }
}