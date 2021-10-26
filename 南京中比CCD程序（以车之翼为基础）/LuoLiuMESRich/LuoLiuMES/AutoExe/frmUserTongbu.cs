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
    public partial class frmUserTongbu : Common.frmBase
    {
        public frmUserTongbu()
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
        public string _UserCode = string.Empty;
        #endregion
        #region 处理函数
        private bool BindData(string sGuid)
        {
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_AutoExe_User_Designs_TongBu WHERE GUID='{0}'"
                , sGuid.Replace("'", "''")), "AutoExe_User_Designs", true));
            DataSet ds;
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["AutoExe_User_Designs"];
            if (dt.DefaultView.Count == 0)
            {
                DataRow drNew = dt.NewRow();
                drNew["GUID"] = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                drNew["UserCode"] = this._UserCode;
                dt.Rows.Add(drNew);
            }
            DataRow dr = dt.DefaultView[0].Row;
            this.tbDesignName.Text = dr["DesignName"].ToString();
            this.tbSourceDesign.Tag = dr["TongBuGuid"].ToString();
            this.tbSourceDesign.Text = dr["TongBuGuidName"].ToString();
            SetFormState(dr["UserCode"].ToString());
            this.DataSource = ds;
            return true;
        }
        private void SetFormState(string sUsercode)
        {
            bool blEdit = string.Compare(sUsercode, Common.CurrentUserInfo.UserCode, true) == 0 || Common.CurrentUserInfo.IsSuper || Common.CurrentUserInfo.IsAdmin;
            this.linkLabel1.Enabled = blEdit;
            this.btTrue.Enabled = blEdit;
        }
        #endregion
        #region 保存数据
        private void ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["AutoExe_User_Designs"].DefaultView[0].Row;
            if (dr["DesignName"].ToString() != this.tbDesignName.Text)
                dr["DesignName"] = this.tbDesignName.Text;
            string strSource = this.tbSourceDesign.Tag == null ? string.Empty : this.tbSourceDesign.Tag.ToString();
            if (dr["TongBuGuid"].ToString() != strSource)
                dr["TongBuGuid"] = strSource;
        }
        private bool Save(DataSet dsSource)
        {
            this.ReadForm(dsSource);
            if (dsSource.GetChanges() == null) return true;
            try
            {
                this.BllDAL.SaveUserForm(dsSource);
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
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开。");
                return;
            }
            if (this.tbDesignName.Text.Trim() == string.Empty)
            {
                this.ShowMsg("名称不能为空！");
                return;
            }
            if (this.tbSourceDesign.Tag == null || this.tbSourceDesign.Tag.ToString() == string.Empty)
            {
                this.ShowMsg("请选择您要同步的预定义方案！");
                return;
            }
            DataSet ds = this.DataSource.Copy();
            if (this.Save(ds))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            this.linkLabel1.Focus();
            this.btTrue.Enabled = this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()) && btTrue.Enabled;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开。");
                return;
            }
            frmSelYdy frm = new frmSelYdy();
            frm._DesignGuid = this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm._DesignGuid == string.Empty)
            {
                this.ShowMsg("请选择一行数据");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT DesignName FROM AutoExe_User_Designs WHERE GUID='{0}'"
                    , frm._DesignGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0) return;
            this.tbSourceDesign.Tag = frm._DesignGuid;
            this.tbSourceDesign.Text = dt.DefaultView[0].Row["DesignName"].ToString();
            if (this.tbDesignName.Text == string.Empty)
            {
                this.tbDesignName.Text = string.Format("同步\"{0}\"", this.tbSourceDesign.Text);
            }
        }
    }
}