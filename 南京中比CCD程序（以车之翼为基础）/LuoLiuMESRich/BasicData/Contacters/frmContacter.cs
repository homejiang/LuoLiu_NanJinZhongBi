using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common;
using ErrorService;

namespace BasicData.Contacters
{
    public partial class frmContacter : frmBase
    {
        public frmContacter()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Contacters _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Contacters BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Contacters();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            //this.tbContactCode.ReadOnly = true;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Contacters Where Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Contacters", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }

            this.DataSource = ds;
          
            return true;
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 联系人编号
        /// </summary>
        public string ContacterCode
        {
            get { return this.tbContactCode.Text; }
            set { this.tbContactCode.Text = value; }
        }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string CNName
        {
            get { return this.txCNName.Text; }
            set { this.txCNName.Text = value; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string ENName
        {
            get { return this.txENName.Text; }
            set { this.txENName.Text = value; }
        }
        /// <summary>
        /// 联系人称呼
        /// </summary>
        public int Sex
        {
            get 
            {
                if (this.radioBoy.Checked) return 1;
                if (this.radioGirl.Checked) return 2;
                return 0;
            }
            set 
            {
                if (value == 1)
                    this.radioBoy.Checked = true;
                else if (value == 2)
                    this.radioGirl.Checked = true;
                else
                {
                    this.radioBoy.Checked = false;
                    this.radioGirl.Checked = false;
                }
            }
        }
        public string SexView
        {
            get 
            {
                if (this.radioBoy.Checked) return "先生";
                if (this.radioGirl.Checked) return "女士";
                return "未知";
            }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Post
        {
            get { return this.tbPost.Text; }
            set { this.tbPost.Text = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get { return this.tbTels.Text; }
            set { this.tbTels.Text = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobileTel
        {
            get { return this.tbMobileTel.Text; }
            set { this.tbMobileTel.Text = value; }
        }
        /// <summary>
        /// 电子邮件地址
        /// </summary>
        public string Email
        {
            get { return this.tbEmail.Text; }
            set { this.tbEmail.Text = value; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return this.tbFax.Text; }
            set { this.tbFax.Text = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark
        {
            get { return this.tbRemark.Text; }
            set { this.tbRemark.Text = value; }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.Check()) return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool Check()
        {
            if (this.txCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入名称");
                this.txCNName.Focus();
                return false;
            }
            if (!this.radioBoy.Checked && !this.radioGirl.Checked)
            {
                this.ShowMsg("请选择先生还是女士");
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            this.Close();
        }

       private void frmContacter_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;

          this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
    }
}