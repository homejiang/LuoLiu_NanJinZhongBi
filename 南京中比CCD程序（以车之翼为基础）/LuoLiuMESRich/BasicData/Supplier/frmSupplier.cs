using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common.MyEnums;
using Common;
using Common.MyEntity;

namespace BasicData.Supplier
{
    public partial class frmSupplier : Common.frmBaseEdit
    {
        public frmSupplier()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Supplier _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Supplier BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Supplier();
                return _dal;
            }
        }
        #endregion
        #region 重写函数
        public override string GetEditFormText(string sCode, FormStates state)
        {
            string strText;
            if (state == Common.MyEnums.FormStates.New)
                strText = "新增供应商";
            else if (state == Common.MyEnums.FormStates.Copy)
                strText = string.Format("复制供应商\"{0}\"", sCode);
            else
                strText = string.Format("供应商\"{0}\"", sCode);
            if (state == Common.MyEnums.FormStates.None)
                strText += "（加载失败）";
            else if (state == Common.MyEnums.FormStates.Readonly)
                strText += "（只读）";
            return strText;
        }
        #endregion
        #region 处理函数
        private bool SetDefaultData()
        {
            //添加
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT Code as CountryCode,ISNULL(CNName,ENName) as country FROM JC_Country ORDER BY ISNULL(CNName,ENName) asc", "JC_Country", false));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comContry.DisplayMember = "Text";
            this.comContry.ValueMember = "Value";
            this.comContry.DataSource = Common.CommonFuns.FormatData.GetComboBoxItemList(ds.Tables["JC_Country"], "country", "CountryCode");
            //如果国家列表只为1个则选择该国家
            if (this.comContry.Items.Count == 1)
                this.comContry.SelectedIndex = 0;
            else
                this.comContry.SelectedIndex = -1;
            //设置供货类型下拉框值
            this.comSupplyType.Items.Clear();
            this.comSupplyType.DisplayMember = "Text";
            this.comSupplyType.ValueMember = "Value";
            this.comSupplyType.Items.Add(new ComboBoxItem("正常采购", 1));
            this.comSupplyType.Items.Add(new ComboBoxItem("调拨单位", 2));
            return true;
        }
        private bool PerInit()
        {
            this.tbOperator.ReadOnly = true;
            this.tbDate.ReadOnly = true;
            this.dgvMaterials.AutoGenerateColumns = false;
            return true;
        }
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Supplier WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Supplier", true));
            strSql = "SELECT * FROM V_JC_SupplierMaterial WHERE SupplierCode='" + strCode.Replace("'", "''") + "' ORDER BY CNName";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_SupplierMaterial", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_Supplier"];
            DataTable dtDetail = ds.Tables["V_JC_SupplierMaterial"];
            dtDetail.Columns["ClassName"].ReadOnly = false;
            dtDetail.Columns["CNName"].ReadOnly = false;
            dtDetail.Columns["ENName"].ReadOnly = false;
            dtDetail.Columns["Unit"].ReadOnly = false;
            DataRow dr;
            if (dt.DefaultView.Count == 0)
            {
                if (strCode.Length > 0)
                {
                    this.ShowMsg("供应商“" + strCode + "”不存在，或已经被删除！");
                    return false;
                }
                //添加一新行
                dr = dt.NewRow();
                DateTime time;
                if (!CommonFuns.GetSysCurrentDateTime(out time))
                {
                    this.ShowMsg("获取当前服务器时间错误！");
                    return false;
                }
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.Supplier);
                dr["CreateDate"] = time;
                dr["Creater"] = Common.CurrentUserInfo.UserCode;
                dr["CreaterName"] = Common.CurrentUserInfo.UserName;
                dr["SupplyType"] = 1;//默认为正常采购商
                dt.Rows.Add(dr);
            }
            else
                dr = dt.DefaultView[0].Row;
            this.DataSource = ds;
            this.tbSupplierCode.Text = dr["Code"].ToString();
            this.tbDate.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateDate"]);
            this.tbOperator.Text = dr["CreaterName"].ToString();
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            this.tbCNName.Text = dr["CNName"].ToString();
            this.tbENName.Text = dr["ENName"].ToString();
            this.tbShortName.Text = dr["ShortName"].ToString();
            this.tbAddress.Text = dr["Address"].ToString();
            this.tbTels.Text = dr["Tels"].ToString();
            this.tbFax.Text = dr["Faxs"].ToString();
            this.tbPostal.Text = dr["Posalcode"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comContry, new ComboBoxItem("", dr["CountryCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProvince, new ComboBoxItem("", dr["ProvinceCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comSupplyType, new ComboBoxItem("", dr["SupplyType"].ToString()), 0);
            this.tbRemark.Text = dr["Remark"].ToString();
            this.dgvMaterials.DataSource = ds.Tables["V_JC_SupplierMaterial"];
            return true;
        }
        private void SetFormState()
        {
            //根据窗体状态限制操作
            bool blEdit = this.FormState == FormStates.New || this.FormState == FormStates.Copy || this.FormState == FormStates.Edit;
            this.tsbDel.Enabled = blEdit && this.FormState == FormStates.Edit;
            this.tsbFiles.Enabled = blEdit;
            this.tsbSave.Enabled = blEdit;
            this.tsbMAdd.Enabled = this.tsbSave.Enabled;
            this.tsbMRemove.Enabled = this.tsbSave.Enabled;
            //设置窗口标题
            string strText = this.GetEditFormText(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString(), this.FormState);
            if (strText != this.Text)
                this.ChangeWinTitle(strText);
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.FormState != FormStates.New && this.FormState != FormStates.Edit && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态无法编辑！");
                return false;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新打开窗口。");
                return false;
            }
            if (this.tbSupplierCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("供应商编码不能为空！");
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("供应商编码不能为空！");
                return false;
            }
            ComboBoxItem item = this.comSupplyType.SelectedItem as ComboBoxItem;
            if (item == null || (item.Value.ToString() != "1" && item.Value.ToString() != "2"))
            {
                this.ShowMsg("请选择供货类型！");
                return false;
            }
            DataTable dt = this.DataSource.Tables["JC_Supplier"];
            //判断是否编码重复
            if (this.FormState == FormStates.New ||
                (this.FormState == FormStates.Edit && !dt.DefaultView[0].Row["Code"].Equals(this.tbSupplierCode.Text.Trim())))
            {
                DataTable dtTemp = null;
                try
                {
                    dtTemp = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code FROM JC_Supplier WHERE Code='" + this.tbSupplierCode.Text.Trim().Replace("'", "''") + "'");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtTemp.Rows.Count > 0)
                {
                    this.ShowMsg("供应商编码“" + this.tbSupplierCode.Text.Trim() + "”已经存在，请更换！");
                    return false;
                }
            }
            //判断是否全称重复
            if (this.FormState == FormStates.New ||
                (this.FormState == FormStates.Edit && !dt.DefaultView[0].Row["CNName"].Equals(this.tbCNName.Text.Trim())))
            {
                DataTable dtTemp = null;
                try
                {
                    dtTemp = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code FROM JC_Supplier WHERE CNName='" + this.tbCNName.Text.Trim().Replace("'", "''") + "'");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtTemp.Rows.Count > 0)
                {
                    this.ShowMsg("供应商“" + this.tbSupplierCode.Text.Trim() + "”已经存在，请检查！");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新加载。");
                return false;
            }
            DataSet dsSource = this.DataSource.Copy();
            if (!this.ReadForm(dsSource)) return false;
            if (dsSource.GetChanges() == null) return true;
            try
            {
                this.BllDAL.Save(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            return true; ;
        }
        private bool ReadForm(DataSet dsSource)
        {
            //读取数据
            ComboBoxItem item;
            DataRow dr = dsSource.Tables["JC_Supplier"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbSupplierCode.Text)
                dr["Code"] = this.tbSupplierCode.Text;
            if (this.chkTerminated.Checked ^ (!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]))
                dr["Terminated"] = this.chkTerminated.Checked;

            if (dr["CNName"].ToString() != this.tbCNName.Text)
                dr["CNName"] = this.tbCNName.Text;
            if (dr["ENName"].ToString() != this.tbENName.Text)
                dr["ENName"] = this.tbENName.Text;
            if (dr["ShortName"].ToString() != this.tbShortName.Text)
                dr["ShortName"] = this.tbShortName.Text;
            if (dr["Tels"].ToString() != this.tbTels.Text)
                dr["Tels"] = this.tbTels.Text;
            if (dr["Faxs"].ToString() != this.tbFax.Text)
                dr["Faxs"] = this.tbFax.Text;
            if (dr["Posalcode"].ToString() != this.tbPostal.Text)
                dr["Posalcode"] = this.tbPostal.Text;
            //选择国家
            item = this.comContry.SelectedItem as ComboBoxItem;
            string strCode = item == null || item.Value == null ? string.Empty : item.Value.ToString();
            if (dr["CountryCode"].ToString() != strCode)
                dr["CountryCode"] = strCode;

            //选择省份
            item = this.comProvince.SelectedItem as ComboBoxItem;
            strCode = item == null || item.Value == null ? string.Empty : item.Value.ToString();
            if (dr["ProvinceCode"].ToString() != strCode)
                dr["ProvinceCode"] = strCode;
            if (dr["Address"].ToString() != this.tbAddress.Text)
                dr["Address"] = this.tbAddress.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            item = this.comSupplyType.SelectedItem as ComboBoxItem;
            int iSptype;
            if (item != null && item.Value != null && int.TryParse(item.Value.ToString(), out iSptype))
            {
                if (dr["SupplyType"].ToString() != iSptype.ToString())
                    dr["SupplyType"] = iSptype;
            }
            //保存明细数据
            foreach (DataRowView drv in dsSource.Tables["V_JC_SupplierMaterial"].DefaultView)
            {
                if (drv.Row["SupplierCode"].ToString() != this.tbSupplierCode.Text)
                    drv.Row["SupplierCode"] = this.tbSupplierCode.Text;
            }
            return true;
        }
        #endregion
        #region 窗体事件
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            //先判断权限
            this.SetDefaultData();
            //窗体预加载数据
            if (!this.PerInit() || !this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()))
                this.FormState = FormStates.None;
            this.SetFormState();
        }
        public override bool CheckClose()
        {
            bool isChanged = false;
            if (this.DataSource.GetChanges() != null)
                isChanged = true;
            else
            {
                DataSet dsSource = this.DataSource.Copy();
                if (!this.ReadForm(dsSource))
                    return false;
                if (dsSource.GetChanges() != null)
                    isChanged = true;
            }
            //提示用户
            if (isChanged)
                return DialogResult.Yes == MessageBox.Show(this, "数据已经修改，您确定不用保存？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return true;
        }
        #endregion
        #region 工具条事件

        private void nvbtNew_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能新增数据。");
                return;
            }
            bool isChanged = false;
            if (this.DataSource.GetChanges() != null)
                isChanged = true;
            else
            {
                DataSet dsSource = this.DataSource.Copy();
                this.ReadForm(dsSource);
                if (dsSource.GetChanges() != null)
                    isChanged = true;
            }
            if (isChanged && DialogResult.Yes != MessageBox.Show(this, "数据已经修改，您确定不用保存？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            //重新加载数据
            this.FormState = FormStates.New;
            this.PrimaryValue = string.Empty;
            this.PerInit();
            this.BindData(string.Empty);
        }

        private void btSave_Click(object sender, EventArgs e)
        {

            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有超级管理员才能修改数据。");
                return;
            }
            //保存数据
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                //重新加载数据
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                    this.FormState = FormStates.Edit;
                this.PrimaryValue = this.tbSupplierCode.Text.Trim();
                this.ShowMsg("保存成功！");
                if (!this.BindData(this.tbSupplierCode.Text.Trim()))
                    this.FormState = FormStates.None;
                this.SetFormState();
                return;
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            //删除数据
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
            {
                if (DialogResult.Yes != MessageBox.Show(this, "数据尚未保存，您确定要直接关闭吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    return;
                this.FormColse();//退出窗体
                return;
            }
            //校验是否有权限删除数据
            List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Supplier, this.PrimaryValue);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("你没有权限删除数据，如有需要，请联系管理员开放此权限！");
                return;
            }
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除供应商“" + this.PrimaryValue.ToString() + "”吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            //此时可以直接删除数据
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Delete(this.PrimaryValue.ToString(), out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == "") strMsg = "操作失败，原因未知！";
                this.ShowMsg(strMsg);
                return;
            }
            this.FormColse();
        }

        private void btFiles_Click(object sender, EventArgs e)
        {
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy || this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
            {
                this.ShowMsg("请先保存数据，再上传文件");
                return;
            }
            this.ModuleFiles(Modules.Supplier, this.PrimaryValue, Common.CurrentUserInfo.UserCode);

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        #endregion
        #region 窗体控件事件
        //国家选择改变，需要加载省份
        private void comContry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strCode;
            if (this.comContry.SelectedItem == null)
                strCode = string.Empty;
            else
            {
                ComboBoxItem item = this.comContry.SelectedItem as ComboBoxItem;
                strCode = item.Value.ToString();
            }
            //获取省份信息
            DataTable dt = null;
            try
            {
                dt = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code,isnull(CNName,ENName) AS Province FROM JC_Province WHERE CountryCode='" + strCode.Replace("'", "''") + "' ORDER BY isnull(CNName,ENName)");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.comProvince.DisplayMember = "Text";
            this.comProvince.ValueMember = "Value";
            this.comProvince.DataSource = Common.CommonFuns.FormatData.GetComboBoxItemList(dt, "Province", "Code");
            if (this.comProvince.Items.Count == 1)
                this.comProvince.SelectedIndex = 0;
            else
                this.comProvince.SelectedIndex = -1;
        }
        #endregion
        #region 原材料操作
        //选择物料
        //INSERT INTO V_JC_SupplierMaterial (MaterialCode,SupplierCode,SortID,IsDefault,Remark,ClassName,
        //CNName,ENName,Unit,MaxStorage,MinStorage,Terminated,TerminatedView) 
        private void btSelectMaterial_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvMaterials.DataSource as DataTable;
            if (dt == null) return;
            Material.frmSelectMaterialOnly frm = new Material.frmSelectMaterialOnly();
            frm.MultiSelected = true;
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            foreach (Material.frmSelectMaterialOnly.SelectedMaterialOnlyInfo info in frm.SelectedData)
            {
                if (dt.Select("MaterialCode='" + info.MaterialCode.ToString() + "'").Length > 0) continue;
                DataRow drNew = dt.NewRow();
                drNew["MaterialCode"] = info.MaterialCode;
                drNew["SupplierCode"] = this.tbSupplierCode.Text;
                //drNew["SortID"] = 此字段在插入表时通过脚本实时读取
                drNew["ClassName"] = info.ClassName;
                drNew["CNName"] = info.CNName;
                drNew["ENName"] = info.ENName;
                drNew["Unit"] = info.UnitName;
                dt.Rows.Add(drNew);
            }
        }
        //移除
        private void btRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterials.SelectedRows.Count == 0)
                return;
            //if (DialogResult.Yes != MessageBox.Show(this, "您确定要移除", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //    return;
            DataTable dt = this.dgvMaterials.DataSource as DataTable;
            dt.DefaultView[this.dgvMaterials.SelectedRows[0].Index].Row.Delete();
            this.dgvMaterials.DataSource = this.DataSource.Tables["V_Material_Storage"];
        }

        #endregion
    }
}