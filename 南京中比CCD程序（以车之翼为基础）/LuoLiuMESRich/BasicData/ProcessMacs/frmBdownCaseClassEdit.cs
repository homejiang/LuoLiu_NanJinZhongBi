using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.ProcessMacs
{
    public partial class frmBdownCaseClassEdit : frmBase
    {
        public frmBdownCaseClassEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MacBreakdownCaseClass _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MacBreakdownCaseClass BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MacBreakdownCaseClass();
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
            string strSql = "SELECT * FROM JC_MacBreakdownCaseClass WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_MacBreakdownCaseClass", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_MacBreakdownCaseClass"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前异常类别不存在或已经被删除，请检查！");
                return false;
            }
            DataRow dr=ds.Tables["JC_MacBreakdownCaseClass"].DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbDesc.Text = dr["ClassName"].ToString();
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            this.DataSource = ds;
            SetFormState();
            return true;
        }
        private void SetFormState()
        {
            
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {

            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失！");
                return false;
            }
            if (this.DataSource.Tables["JC_MacBreakdownCaseClass"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            if (string.Compare(this.DataSource.Tables["JC_MacBreakdownCaseClass"].DefaultView[0].Row["Code"].ToString(), this.tbCode.Text, true) != 0)
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_MacBreakdownCaseClass WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("异常类别代码“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            if (this.tbDesc.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入异常类别描述！");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_MacBreakdownCaseClass"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["ClassName"].Equals(this.tbDesc.Text.Trim()))
                dr["ClassName"] = this.tbDesc.Text.Trim();
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            if (this.DataSource.GetChanges() == null)
                return true;
            try
            {
                this.BllDAL.Save(this.DataSource);
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