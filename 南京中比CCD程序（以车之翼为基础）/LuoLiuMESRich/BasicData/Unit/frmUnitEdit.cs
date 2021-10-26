using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.Unit
{
    public partial class frmUnitEdit : frmBase
    {
        public frmUnitEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Unit _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Unit BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Unit();
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
            string strSql = "SELECT * FROM JC_Unit WHERE Code='" + strCode.Replace("'","''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_Unit", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_Unit"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前计量单位不存在或已经被删除，请检查！");
                return false;
            }
            this.tbCode.Text = ds.Tables["JC_Unit"].DefaultView[0].Row["Code"].ToString();
            this.tbCNName.Text = ds.Tables["JC_Unit"].DefaultView[0].Row["CNName"].ToString();
            this.tbENName.Text = ds.Tables["JC_Unit"].DefaultView[0].Row["ENName"].ToString();
            this.chkTerminated.Checked = !ds.Tables["JC_Unit"].DefaultView[0].Row["Terminated"].Equals(DBNull.Value) &&
                (bool)ds.Tables["JC_Unit"].DefaultView[0].Row["Terminated"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.DataSource.Tables["JC_Unit"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据未能加载，请重新打开窗口！");
                return false;
            }
            if (!this.DataSource.Tables["JC_Unit"].DefaultView[0].Row["Code"].Equals(this.tbCode.Text))
            {
                //如果编码已经修改过，则要判断是否编码已经存在了
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_Unit WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("单位编码“" + this.tbCode.Text + "”已经存在，请更换");
                    return false;
                }
            }
            if (this.tbCNName.Text.Trim().Length == 0 && this.tbENName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请至少输入一个名称！");
                return false;
            }
            if (this.DataSource == null || this.DataSource.Tables["JC_Unit"].DefaultView.Count == 0)
            {
                this.ShowMsg("数据源不正确，请重新加载窗体！");
                return false;
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_Unit"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals( this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
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