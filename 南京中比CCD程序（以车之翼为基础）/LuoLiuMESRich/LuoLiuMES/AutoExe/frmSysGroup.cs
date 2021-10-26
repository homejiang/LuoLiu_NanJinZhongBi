using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysGroup : Common.frmBaseEdit
    {
        public frmSysGroup()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.AutoExe BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.AutoExe();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        public string _PCode = string.Empty;
        public string GroupCode
        {
            get { return tbCode.Text; }
        }
        public string GroupName
        {
            get { return this.tbGroupName.Text; }
        }
        #endregion
        #region 处理函数
        private bool BindData(string sCode)
        {
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM AutoExe_Sys_Group WHERE Code='{0}'"
                , sCode.Replace("'", "''")), "AutoExe_Sys_Group", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["AutoExe_Sys_Group"].Rows.Count == 0)
            {
                DataRow drNew = ds.Tables["AutoExe_Sys_Group"].NewRow();
                drNew["Code"] = this.GetAutoCode(Common.MyEnums.Modules.AutoExe_SysGroup);
                drNew["PCode"] = this._PCode;
                DataTable dtSort;
                try
                {
                    dtSort = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT MAX(SortID) FROM AutoExe_Sys_Group");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                int iSortID;
                if (dtSort.Rows[0][0].Equals(DBNull.Value))
                    iSortID = 1;
                else iSortID = int.Parse(dtSort.Rows[0][0].ToString()) + 1;
                drNew["SortID"] = iSortID;
                ds.Tables["AutoExe_Sys_Group"].Rows.Add(drNew);
            }
            DataRow dr = ds.Tables["AutoExe_Sys_Group"].DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();;
            this.tbGroupName.Text = dr["GroupName"].ToString();
            this.tbRemark.Text = dr["Remark"].ToString();
            BindPGroup(dr["Pcode"].ToString());
            this.DataSource = ds;
            return true;
        }
        private void BindPGroup(string sCode)
        {
            if (sCode == string.Empty)
            {
                this.tbPGroup.Text = "顶级组";
            }
            else
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.[AutoExe_GetGroupFullName]('{0}')", sCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.tbPGroup.Text = dt.Rows[0][0].ToString();
            }
            this.tbPGroup.Tag = sCode;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return false;
            }
            if (this.tbCode.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入编码");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbGroupName.Text.Trim() == string.Empty)
            {
                this.ShowMsg("请输入组名");
                this.tbGroupName.Focus();
                return false;
            }
            //校验是否编码重复
            if (string.Compare(this.PrimaryValue.ToString(), this.tbCode.Text, true) != 0)
            {
                DataTable dttemp;
                try
                {
                    dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT count(*) FROM AutoExe_Sys_Group WHERE Code='{0}'"
                        , this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if ((int)dttemp.Rows[0][0] > 0)
                {
                    this.ShowMsg("编码\"" + this.tbCode.Text + "\"已经存在，请重新输入。");
                    this.tbCode.Focus();
                    return false;
                }
            }
            return true;
        }
        private void ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["AutoExe_Sys_Group"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            if (dr["GroupName"].ToString() != this.tbGroupName.Text)
                dr["GroupName"] = this.tbGroupName.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            string strPCd = this.tbPGroup.Tag == null ? string.Empty : this.tbPGroup.Tag.ToString();
            if (dr["PCode"].ToString() != strPCd)
                dr["PCode"] = strPCd;
        }
        private bool Save(DataSet dsSource)
        {
            this.ReadForm(dsSource);
            if (dsSource.GetChanges() == null) return true;
            try
            {
                this.BllDAL.SaveSysGroup(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true;
        }
        #endregion

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            DataSet dsSource = this.DataSource.Copy();
            if (!this.Save(dsSource))
                return;
            this.DialogResult = DialogResult.OK;
        }

        private void frmSysGroup_Load(object sender, EventArgs e)
        {
            this.btTrue.Enabled = this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }

        private void linkPGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            frmSelSysGroup frm = new frmSelSysGroup();
            frm._GroupCode = this.DataSource.Tables["AutoExe_Sys_Group"].DefaultView[0].Row["PCode"].ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if ((this.tbPGroup.Tag == null ? string.Empty : this.tbPGroup.Tag.ToString()) != frm._GroupCode)
            {
                this.tbPGroup.Tag = frm._GroupCode;
                BindPGroup(frm._GroupCode);
            }
        }
    }
}