using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace Common.ProcessJobs
{
    public partial class frmJobEdit : frmBase
    {
        public frmJobEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.ProcessJobs _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.ProcessJobs BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new Common.BLLDAL.ProcessJobs();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Jobs WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_Jobs", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_Jobs"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前计量单位不存在或已经被删除，请检查！");
                return false;
            }
            this.tbCode.Text = ds.Tables["JC_Jobs"].DefaultView[0].Row["Code"].ToString();
            this.tbJobName.Text = ds.Tables["JC_Jobs"].DefaultView[0].Row["JobName"].ToString();
            this.tbJobDesc.Text = ds.Tables["JC_Jobs"].DefaultView[0].Row["Jobdesc"].ToString();
            this.numSFGLenRate.BindValue = ds.Tables["JC_Jobs"].DefaultView[0].Row["SFGLenRate"];
            this.chkTerminated.Checked = !ds.Tables["JC_Jobs"].DefaultView[0].Row["Terminated"].Equals(DBNull.Value) &&
                (bool)ds.Tables["JC_Jobs"].DefaultView[0].Row["Terminated"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.DataSource.Tables["JC_Jobs"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            this.tbCode.Text = this.tbCode.Text.Trim();
            if (this.DataSource.Tables["JC_Jobs"].DefaultView[0].Row["Code"].ToString()!=this.tbCode.Text)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT Code FROM JC_Jobs WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("岗位编码“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            if (this.tbJobName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入岗位名称！");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["JC_Jobs"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体！");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_Jobs"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["JobName"].Equals(this.tbJobName.Text.Trim()))
                dr["JobName"] = this.tbJobName.Text.Trim();
            if (!dr["jobdesc"].Equals( this.tbJobDesc.Text.Trim()))
                dr["jobdesc"] = this.tbJobDesc.Text.Trim();
            if (!dr["SFGLenRate"].Equals(this.numSFGLenRate.BindValue))
                dr["SFGLenRate"] = this.numSFGLenRate.BindValue;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            if (this.DataSource.GetChanges() == null)
                return true;
            try
            {
                this.BllDAL.SaveJobs(this.DataSource.Tables["JC_Jobs"]);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #endregion
        #region 窗体按钮事件
        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmUnitEdit_Load(object sender, EventArgs e)
        {
            if (!this.PerInit()) return;
            this.BindData(this.PrimaryValue == null ? "" : this.PrimaryValue.ToString());
        }
    }
}