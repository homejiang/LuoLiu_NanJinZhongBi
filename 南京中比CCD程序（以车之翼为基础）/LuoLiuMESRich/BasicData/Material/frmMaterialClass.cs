using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ErrorService;
using Common;
using Common.MyEnums;

namespace BasicData.Material
{
    public partial class frmMaterialClass : frmBase
    {
        public frmMaterialClass()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.MaterialClass _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.MaterialClass BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.MaterialClass();
                return _dal;
            }
        }
        #endregion
        #region 公共属性
        private string _strPClaCode;
        /// <summary>
        /// 父级编码
        /// </summary>
        public string ParentClassCode
        {
            get { return this._strPClaCode; }
            set { this._strPClaCode = value; }
        }
        private bool _blUpdated = false;
        /// <summary>
        /// 此属性可以通知母窗体数据已经更新
        /// </summary>
        public bool IsUpdated
        {
            get { return this._blUpdated; }
            set { this._blUpdated = value; }
        }
        #endregion
        #region 处理函数
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT A.*,(select className FROM JC_MaterialClass WHERE code=A.ParentCode) AS ParentClassName FROM JC_MaterialClass A WHERE A.Code='" + strCode.Replace("'", "''") + "'", "JC_MaterialClass", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_MaterialClass"];
            DataRow dr;
            if (dt.Rows.Count == 0)
            {
                dr = dt.NewRow();
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.MaterialClass);
                if (!String.IsNullOrEmpty(this.ParentClassCode))
                {
                    DataTable dtPCla = null;
                    try
                    {
                        dtPCla = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code,ClassName FROM JC_MaterialClass WHERE Code='{0}'", this.ParentClassCode.Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dtPCla.Rows.Count > 0)
                    {
                        dr["ParentCode"] = dtPCla.Rows[0]["Code"];
                        dr["ParentClassName"] = dtPCla.Rows[0]["ClassName"];
                    }
                }
                //获取序号
                //序号获取方法：同一根目录下的最大需要
                DataTable dtSort = null;
                try
                {
                    dtSort = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(SortID) FROM JC_MaterialClass WHERE ISNULL(ParentCode,'')='{0}'", String.IsNullOrEmpty(this.ParentClassCode) ? string.Empty : this.ParentClassCode));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                int iSort;
                if (dtSort.Rows[0][0].Equals(DBNull.Value))
                    iSort = 0;
                else iSort = (int)dtSort.Rows[0][0];
                iSort++;
                dr["SortID"] = iSort;
                dt.Rows.Add(dr);
            }
            else
                dr = dt.Rows[0];
            this.tbCode.Text = dr["Code"].ToString();
            this.tbCNName.Text = dr["ClassName"].ToString();
            this.tbParentCode.Tag = dr["ParentCode"].ToString();
            this.tbParentCode.Text = dr["ParentClassName"].ToString();
            this.Remark.Text = dr["Remark"].ToString();
            this.DataSource = ds;
            //设置标题及按钮
            if (this.FormState == FormStates.New || this.FormState==FormStates.Copy)
                this.Text = "新增物料类别";
            else if (this.FormState == FormStates.Edit)
                this.Text = "编辑物料类别“" + this.tbCNName.Text + "”";
            else
                this.Text = "物料类别“" + this.tbCNName.Text + "”（只读）";
            this.btSave.Enabled = this.FormState == FormStates.New || this.FormState == FormStates.Copy || this.FormState == FormStates.Edit;
            this.btSaveNew.Enabled = this.btSave.Enabled;
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            //检查权限
            if (this.FormState != FormStates.New && this.FormState != FormStates.Copy
                && this.FormState != FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态为只读，无法保存数据，请检查。");
                return false;
            }
            // 检查必输项
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入中文名称！");
                this.tbCNName.Focus();
                return false;
            }
            //校验是否有重复
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开！");
                return false;
            }
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                || (this.FormState == FormStates.Edit && !this.DataSource.Tables["JC_MaterialClass"].DefaultView[0].Row["ClassName"].Equals(this.tbCNName.Text.Trim())))
            {
                DataTable dt = null;
                try
                {
                    dt = CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Code FROM JC_MaterialClass WHERE ClassName='{0}'", this.tbCNName.Text.Trim()));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg(string.Format("中文名称“{0}”已经存在，请更换！",this.tbCNName.Text.Trim()));
                    this.tbCNName.Focus();
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            DataRow dr = this.DataSource.Tables["JC_MaterialClass"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbCode.Text.Trim()))
                dr["Code"] = this.tbCode.Text.Trim();
            if (!dr["ClassName"].Equals(this.tbCNName.Text.Trim()))
                dr["ClassName"] = this.tbCNName.Text.Trim();
            object objPClaCode;
            if (this.tbParentCode.Tag == null || this.tbParentCode.Tag.ToString().Length == 0)
                objPClaCode = DBNull.Value;
            else objPClaCode = this.tbParentCode.Tag.ToString();
            if (!dr["ParentCode"].Equals(objPClaCode))
                dr["ParentCode"] = objPClaCode;
            if (!dr["Remark"].Equals(this.Remark.Text.Trim()))
                dr["Remark"] = this.Remark.Text.Trim();
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
        #region 按钮事件
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (!this.Save())
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btSaveNew_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            if (!this.Save())
                return;
            if (!IsUpdated)
                this.IsUpdated = true;
            this.FormState = FormStates.New;
            this.PrimaryValue = string.Empty;
            this.frmMaterialClass_Load(null, null);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 窗体事件
        private void frmMaterialClass_Load(object sender, EventArgs e)
        {
            if (this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()))
                return;
        }
        #endregion

        private void linkParentClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}