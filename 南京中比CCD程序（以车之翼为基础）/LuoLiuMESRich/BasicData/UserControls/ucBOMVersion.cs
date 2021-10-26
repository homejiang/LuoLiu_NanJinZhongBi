using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace BasicData.UserContorls
{
    public partial class ucBOMVersion : UserControl
    {
        public ucBOMVersion()
        {
            InitializeComponent();
        }
        #region 私有属性
        public string _SFGClass = string.Empty;
        #endregion
        #region 公共属性
        private int _id = -1;
        public object ID
        {
            get 
            { 
                if (this._id == -1)return DBNull.Value;
                return _id;
            }
        }

        #endregion
        /// <summary>
        /// 绑定版本信息
        /// </summary>
        /// <param name="objID">版本标识码</param>
        /// <param name="sSFGClass">所属半成品类别</param>
        public void Bind(object objID,string sSFGClass)
        {
            this._SFGClass = sSFGClass;
            int iID;
            if (objID == null || objID.Equals(DBNull.Value) || objID.ToString() == string.Empty || !int.TryParse(objID.ToString(), out iID))
            {
                this._id = -1;
                ClearData();
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM BOM_Sys_Version where ID=" + objID.ToString()));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.DefaultView.Count == 0)
            {
                this._id = -1;
                ClearData();
            }
            else
            {
                DataRow dr = dt.Rows[0];
                this.tbNo.Text = dr["VersionNo"].ToString();
                this.tbDesc.Text = dr["VersionSpec"].ToString();
                this.tbRemark.Text = dr["VersionDesc"].ToString();
                this._id = iID;
            }
        }
        public bool Check()
        {
            if (this._id == -1)
            {
                MessageBox.Show("请选择BOM版本号！");
                return false;
            }
            return true;
        }
        private void ClearData()
        {
            if (this.tbNo.Text != string.Empty)
                this.tbNo.Clear();
            if (this.tbDesc.Text != string.Empty)
                this.tbDesc.Clear();
            if (this.tbRemark.Text != string.Empty)
                this.tbRemark.Clear();
        }
        private void linkSelVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BOM.frmSelectBomVersion frm = new BOM.frmSelectBomVersion();
            frm.MultiSelected = false;
            frm._ClassCode = this._SFGClass;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData.Count == 0) return;
            this._id = int.Parse(frm.SelectedData[0].ID.ToString());
            this.tbNo.Text = frm.SelectedData[0].VersionNo.ToString();
            this.tbDesc.Text = frm.SelectedData[0].VersionSpec.ToString();
            this.tbRemark.Text = frm.SelectedData[0].VersionDesc.ToString();
        }
    }
}
