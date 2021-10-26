using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.AutoExe
{
    public partial class frmUserFormEdit : Common.frmBaseEdit
    {
        public frmUserFormEdit()
        {
            InitializeComponent();
        }
        #region 公共属性
        public DataRow _DataRow = null;
        public DataSet _DsSource = null;
        #endregion
        private void frmUserFormEdit_Load(object sender, EventArgs e)
        {
            this.button1.Enabled = BindData();
        }
        private bool BindData()
        {
            if (this._DataRow == null)
            {
                this.ShowMsg("未传入数据！");
                return false;
            }
            this.tbFormCode.Text = this._DataRow["FormCode"].ToString();
            this.tbGroupName.Tag = this._DataRow["GroupGuid"].ToString();
            this.tbGroupName.Text = this._DataRow["GroupName"].ToString();
            this.tbFormName.Text = this._DataRow["FormName"].ToString();
            this.chkUnderline.Checked = !this._DataRow["Underline"].Equals(DBNull.Value) && (bool)this._DataRow["Underline"];
            this.chkFontBold.Checked = !this._DataRow["FontBold"].Equals(DBNull.Value) && (bool)this._DataRow["FontBold"];
            SetForeColor(this._DataRow["ForeColor"].ToString());
            return true;
        }
        private void SetForeColor(string strColorHex)
        {
            if (strColorHex == string.Empty)
            {
                this.tbForeColor.Text = "[未设置]";
                this.tbForeColor.Tag = null;
                this.tbForeColor.BackColor = Color.White;
                chkForeColorNone.Checked = true;
                this.linkForeColor.Enabled = false;
            }
            else
            {
                this.tbForeColor.Text = "";
                this.tbForeColor.BackColor = ColorTranslator.FromHtml(strColorHex);
                this.tbForeColor.Tag = strColorHex;
                chkForeColorNone.Checked = false;
                this.linkForeColor.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbFormName.Text.Trim() == string.Empty)
            {
                this.ShowMsg("窗体名称不能为空！");
                return;
            }
            string strGroup = this.tbGroupName.Tag == null ? string.Empty : this.tbGroupName.Tag.ToString();
            if (this._DataRow["GroupGuid"].ToString() != strGroup)
            {
                this._DataRow["GroupGuid"] = strGroup;
                this._DataRow["GroupName"] = this.tbGroupName.Text;
                //修改SortID，追加到新组的最后
                int iSortID;
                DataRow[] drs = this._DsSource.Tables["AutoExe_User_Forms"].Select("GroupGuid='" + strGroup + "'", "SortID DESC");
                if (drs.Length == 0) iSortID = 1;
                else iSortID = (int)drs[0]["SortID"] + 1;
                this._DataRow["SortID"] = iSortID;
            }
            if (this._DataRow["FormName"].ToString() != this.tbFormName.Text)
                this._DataRow["FormName"] = this.tbFormName.Text;
            if ((!this._DataRow["Underline"].Equals(DBNull.Value) && (bool)this._DataRow["Underline"]) ^ this.chkUnderline.Checked)
                this._DataRow["Underline"] = this.chkUnderline.Checked;
            if ((!this._DataRow["FontBold"].Equals(DBNull.Value) && (bool)this._DataRow["FontBold"]) ^ this.chkFontBold.Checked)
                this._DataRow["FontBold"] = this.chkFontBold.Checked;
            string strForecolor = this.tbForeColor.Tag == null ? string.Empty : this.tbForeColor.Tag.ToString();
            if (this._DataRow["ForeColor"].ToString() != strForecolor)
                this._DataRow["ForeColor"] = strForecolor;
            this.DialogResult = DialogResult.OK;
        }

        private void linkGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserFormSelGroup frm = new frmUserFormSelGroup();
            List<Common.MyEntity.ComboBoxItem> listGroup = new List<Common.MyEntity.ComboBoxItem>();
            foreach (DataRowView drv in this._DsSource.Tables["AutoExe_User_Group"].DefaultView)
                listGroup.Add(new Common.MyEntity.ComboBoxItem(drv.Row["GroupName"].ToString(), drv.Row["GUID"].ToString()));
            frm._ListGroup = listGroup;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm._SelectedItem == null) return;
            if (this.tbGroupName.Tag == null || this.tbGroupName.Tag.ToString() != frm._SelectedItem.Value.ToString())
            {
                this.tbGroupName.Tag = frm._SelectedItem.Value.ToString();
                this.tbGroupName.Text = frm._SelectedItem.Text;
            }
        }

        private void linkForeColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (DialogResult.OK != this.colorDialog1.ShowDialog(this)) return;
            string strColorHex = ColorTranslator.ToHtml(this.colorDialog1.Color);
            if (this.tbForeColor.Tag == null || this.tbForeColor.Tag.ToString() != strColorHex)
            {
                SetForeColor(strColorHex);
            }
        }

        private void chkForeColorNone_CheckedChanged(object sender, EventArgs e)
        {
            this.linkForeColor.Enabled = !this.chkForeColorNone.Checked;
            if (this.chkForeColorNone.Checked)
                SetForeColor(string.Empty);
        }
    }
}