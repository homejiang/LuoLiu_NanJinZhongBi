using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;

namespace BasicData.ModuleFiles
{
    public partial class frmPrintFileEdit : frmBase
    {
        public frmPrintFileEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PrintFile _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PrintFile BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.PrintFile();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool PerInit()
        {
            return true;
        }
        private bool BindData(string strPrintArg)
        {
            DataSet ds=null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT PrintArg,FileName,FileVersion,Times,Remark FROM JC_PrintFile WHERE PrintArg='" + strPrintArg.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_PrintFile", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["JC_PrintFile"].DefaultView.Count == 0)
            {
                this.ShowMsg("当前模板不存在或已经被删除，请检查！");
                return false;
            }
            this.tbPrintArg.Text = ds.Tables["JC_PrintFile"].DefaultView[0].Row["PrintArg"].ToString();
            this.tbFileName.Text = ds.Tables["JC_PrintFile"].DefaultView[0].Row["FileName"].ToString();
            this.tbFileVersion.Text = ds.Tables["JC_PrintFile"].DefaultView[0].Row["FileVersion"].ToString();
            this.tbRemark.Text = ds.Tables["JC_PrintFile"].DefaultView[0].Row["Remark"].ToString();
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return false;
            }
            if (this.tbPrintArg.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入模板名称！");
                return false;
            }
            if (this.tbFileName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入文件名称。");
                return false;
            }
            return true;
            if (this.DataSource.Tables["JC_PrintFile"].DefaultView[0].Row["PrintArg"].ToString() != this.tbPrintArg.Text)
            {
                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT PrintArg FROM JC_PrintFile WHERE PrintArg='{0}'", this.tbPrintArg.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg("模板名称“" + this.tbPrintArg.Text + "”已经存在，请更换");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_PrintFile"].DefaultView[0].Row;
            if (dr["PrintArg"].ToString()!=this.tbPrintArg.Text.Trim())
                dr["PrintArg"] = this.tbPrintArg.Text.Trim();
            if (dr["FileName"].ToString() != this.tbFileName.Text.Trim())
                dr["FileName"] = this.tbFileName.Text.Trim();
            if (dr["FileVersion"].ToString() != this.tbFileVersion.Text.Trim())
                dr["FileVersion"] = this.tbFileVersion.Text.Trim();
            if (dr["Remark"].ToString() != this.tbRemark.Text.Trim())
                dr["Remark"] = this.tbRemark.Text.Trim();
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