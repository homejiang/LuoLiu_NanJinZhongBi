using BasicData.Contacters;
using Common;
using Common.MyEntity;
using Common.MyEnums;
using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicData.Client
{
    public partial class frmClient : frmBase
    {
        public frmClient()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Client _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Client BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Client();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        /// <summary>
        /// 设置系统默认数据
        /// </summary>
        /// <returns></returns>
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
            // this.comSupplyType.Items.Clear();
            //this.comSupplyType.DisplayMember = "Text";
            //this.comSupplyType.ValueMember = "Value";
            // this.comSupplyType.Items.Add(new ComboBoxItem("正常采购", 1));
            // this.comSupplyType.Items.Add(new ComboBoxItem("调拨单位", 2));
            return true;
        }
        /// <summary>
        /// 窗体预先加载数据
        /// </summary>
        /// <returns></returns>
        private bool PerInit()
        {
            this.tbOperator.ReadOnly = true;
            this.tbDate.ReadOnly = true;
            //根据窗体状态限制操作
            bool isReadOnly = true;
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
            {
                isReadOnly = false;
                this.ChangeWinTitle("新建客户");
            }
            else if (this.FormState == FormStates.Edit)
            {
                isReadOnly = false;
                this.ChangeWinTitle(string.Format("客户{0}", this.PrimaryValue));
            }
            else if (this.FormState == FormStates.Readonly)
            {
                isReadOnly = true;
                this.ChangeWinTitle(string.Format("客户{0}（只读）", this.PrimaryValue));
            }
            this.btDelete.Enabled = !(isReadOnly || this.FormState == FormStates.New || this.FormState == FormStates.Copy);
            //this.btFiles.Enabled = !(this.FormState == FormStates.New || this.FormState == FormStates.Copy);
            this.btSave.Enabled = !isReadOnly;
            this.btSaveNew.Enabled = !isReadOnly;
            // this.btSelectMaterial.Enabled = !isReadOnly;
            this.btRemove.Enabled = !isReadOnly;
            //this.dgvMaterials.AutoGenerateColumns = false;
            this.dgvContacter.AutoGenerateColumns = false;
            return true;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="strCode">客户代码</param>
        /// <returns></returns>
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM JC_Client WHERE Code='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Client", true));
            // strSql = "SELECT * FROM V_JC_ClientMaterial WHERE SupplierCode='" + strCode.Replace("'", "''") +"' ORDER BY CNName";
            // listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_ClientMaterial", true));
            strSql = "SELECT * FROM V_JC_ClientContacters WHERE ClientCode='" + strCode.Replace("'", "''") + "' ORDER BY [ContacterCode]";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_ClientContacters", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_Client"];
            //DataTable dtDetail = ds.Tables["V_JC_ClientMaterial"];
            DataRow dr;
            if (dt.DefaultView.Count == 0)
            {
                if (strCode.Length > 0)
                {
                    this.ShowMsg("客户“" + strCode + "”不存在，或已经被删除！");
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
                dr["Code"] = this.GetAutoCode(Common.MyEnums.Modules.Client);
                dr["CreateDate"] = time;
                dr["Creater"] = Common.CurrentUserInfo.UserCode;
                dr["CreaterName"] = Common.CurrentUserInfo.UserName;
                // dr["SupplyType"] = 1;//默认为正常采购商
                dt.Rows.Add(dr);
            }
            else
                dr = dt.DefaultView[0].Row;
            this.DataSource = ds;
            this.tbClientCode.Text = dr["Code"].ToString();
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
            this.tbOpenBank.Text = dr["OpenBank"].ToString();
            this.tbAccount.Text = dr["Account"].ToString();
            this.tbSwift.Text = dr["SwiftCode"].ToString();
            this.tbVirCode.Text = dr["VirCode"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comContry, new ComboBoxItem("", dr["CountryCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProvince, new ComboBoxItem("", dr["ProvinceCode"].ToString()), 0);
            // Common.CommonFuns.FormatData.SetComboBoxText(this.comSupplyType, new ComboBoxItem("", dr["SupplyType"].ToString()), 0);
            this.tbRemark.Text = dr["Remark"].ToString();
            //this.dgvMaterials.DataSource = ds.Tables["V_JC_ClientMaterial"];
            //this.dgvContacter.DataSource = ds.Tables["V_JC_ClientContacters"];
            return true;
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
            if (this.tbClientCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("客户编码不能为空！");
                return false;
            }
            if (this.tbCNName.Text.Trim().Length == 0)
            {
                this.ShowMsg("客户编码不能为空！");
                return false;
            }
            // ComboBoxItem item = this.comSupplyType.SelectedItem as ComboBoxItem;
            // if (item == null || (item.Value.ToString() != "1" && item.Value.ToString() != "2"))
            //  {
            //    this.ShowMsg("请选择供货类型！");
            //   return false;
            //  }
            DataTable dt = this.DataSource.Tables["JC_Client"];
            //判断是否编码重复
            if (this.FormState == FormStates.New ||
                (this.FormState == FormStates.Edit && !dt.DefaultView[0].Row["Code"].Equals(this.tbClientCode.Text.Trim())))
            {
                DataTable dtTemp = null;
                try
                {
                    dtTemp = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code FROM JC_Client WHERE Code='" + this.tbClientCode.Text.Trim().Replace("'", "''") + "'");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtTemp.Rows.Count > 0)
                {
                    this.ShowMsg("客户编码“" + this.tbClientCode.Text.Trim() + "”已经存在，请更换！");
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
                    dtTemp = CommonDAL.DoSqlCommand.GetDateTable("SELECT Code FROM JC_Client WHERE CNName='" + this.tbCNName.Text.Trim().Replace("'", "''") + "'");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dtTemp.Rows.Count > 0)
                {
                    this.ShowMsg("客户“" + this.tbClientCode.Text.Trim() + "”已经存在，请检查！");
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            this.ReadForm(this.DataSource);
            if (this.DataSource.GetChanges() == null) return true;
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            // this.RefreshParetForm();

            return true; ;
        }

        /*private void RefreshParetForm()
        {
            throw new Exception("The method or operation is not implemented.");
        }*/
        /// <summary>
        /// 将窗体数据读入传入表集合中
        /// </summary>
        /// <param name="dsSource">存放窗体数据的表集合</param>
        private void ReadForm(DataSet dsSource)
        {
            //读取数据
            ComboBoxItem item;
            DataRow dr = dsSource.Tables["JC_Client"].DefaultView[0].Row;
            if (!dr["Code"].Equals(this.tbClientCode.Text.Trim()))
                dr["Code"] = this.tbClientCode.Text.Trim();
            if (this.chkTerminated.Checked ^ (!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]))
                dr["Terminated"] = this.chkTerminated.Checked;
            if (!dr["CNName"].Equals(this.tbCNName.Text.Trim()))
                dr["CNName"] = this.tbCNName.Text.Trim();
            if (!dr["ENName"].Equals(this.tbENName.Text.Trim()))
                dr["ENName"] = this.tbENName.Text.Trim();
            if (!dr["ShortName"].Equals(this.tbShortName.Text.Trim()))
                dr["ShortName"] = this.tbShortName.Text.Trim();
            if (!dr["Tels"].Equals(this.tbTels.Text.Trim()))
                dr["Tels"] = this.tbTels.Text.Trim();
            if (!dr["Faxs"].Equals(this.tbFax.Text.Trim()))
                dr["Faxs"] = this.tbFax.Text.Trim();
            if (!dr["Posalcode"].Equals(this.tbPostal.Text.Trim()))
                dr["Posalcode"] = this.tbPostal.Text.Trim();
            if (!dr["VirCode"].Equals(this.tbVirCode.Text.Trim()))
                dr["VirCode"] = this.tbVirCode.Text.Trim();
            if (!dr["OpenBank"].Equals(this.tbOpenBank.Text.Trim()))
                dr["OpenBank"] = this.tbOpenBank.Text.Trim();
            if (!dr["Account"].Equals(this.tbAccount.Text.Trim()))
                dr["Account"] = this.tbAccount.Text.Trim();
            if (!dr["SwiftCode"].Equals(this.tbSwift.Text.Trim()))
                dr["SwiftCode"] = this.tbSwift.Text.Trim();

            //选择国家
            if (this.comContry.SelectedItem == null && !dr["CountryCode"].Equals(DBNull.Value))
                dr["CountryCode"] = DBNull.Value;
            else
            {
                item = this.comContry.SelectedItem as ComboBoxItem;
                if (item == null && !dr["CountryCode"].Equals(DBNull.Value))
                    dr["CountryCode"] = DBNull.Value;
                else if (item != null && !dr["CountryCode"].Equals(item.Value.ToString()))
                    dr["CountryCode"] = item.Value.ToString();
            }
            //选择省份
            item = this.comProvince.SelectedItem as ComboBoxItem;
            if (item == null && !dr["ProvinceCode"].Equals(DBNull.Value))
                dr["ProvinceCode"] = DBNull.Value;
            else if (item != null && !dr["ProvinceCode"].Equals(item.Value.ToString()))
                dr["ProvinceCode"] = item.Value.ToString();
            if (!dr["Address"].Equals(this.tbAddress.Text.Trim()))
                dr["Address"] = this.tbAddress.Text.Trim();
            if (!dr["Remark"].Equals(this.tbRemark.Text.Trim()))
                dr["Remark"] = this.tbRemark.Text.Trim();
            // item = this.comSupplyType.SelectedItem as ComboBoxItem;
            // if (item != null)
            // {
            //    int iSupplyType = (int)item.Value;
            //   if (!dr["SupplyType"].Equals(iSupplyType))
            //    dr["SupplyType"] = iSupplyType;
            //   }

            //保存明细数据
            foreach (DataRowView drv in dsSource.Tables["V_JC_ClientContacters"].DefaultView)
            {
                if (!drv.Row["ClientCode"].Equals(this.tbClientCode.Text.Trim()))
                    drv.Row["ClientCode"] = this.tbClientCode.Text.Trim();
            }
        }
        #endregion
        #region 窗口加载
        private void frmClient_Load(object sender, EventArgs e)
        {
            //先判断权限
            if (this.FormState == FormStates.None)
            {
                //如果当前窗体未设置状态，则校验权限
                List<OperatePower> listPower = this.GetOperatePower(Common.CurrentUserInfo.UserCode, Common.MyEnums.Modules.Client, this.PrimaryValue);
                if (listPower.Count == 0)
                {
                    //此时用户无任何权限，则关闭当前窗体
                    this.FormColse();
                    return;
                }
                if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
                {
                    //此时表示新建
                    if (!listPower.Contains(OperatePower.New))
                    {
                        this.ShowMsg("对不起，您拥有的权限无法新建供应商,如有需要，您可以与管理联系，开放此权限。");
                        return;
                    }
                    this.FormState = FormStates.New;
                }
                else
                {
                    //此时表示编辑状态暂不用考虑删除权限，删除权限会在执行删除操作时进行判断
                    if (listPower.Contains(OperatePower.Eidt))
                    {
                        //有编辑权限
                        this.FormState = FormStates.Edit;
                    }
                    else
                    {
                        //删除权限，也当只读处理
                        this.FormState = FormStates.Readonly;
                    }
                }
            }
            if (this.FormState == FormStates.None)
            {
                this.ShowMsg("窗体状态不明，无法加载数据！");
                return;
            }
            this.SetDefaultData();
            //窗体预加载数据
            if (!this.PerInit())
                return;
            this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
        #endregion
        #region 工具栏

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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //保存数据
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                //重新加载数据
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                    this.FormState = FormStates.Edit;
                this.PrimaryValue = this.tbClientCode.Text.Trim();
                this.PerInit();
                this.BindData(this.tbClientCode.Text.Trim());
                this.ShowMsg("保存成功！");
                return;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            if (this.Save())
            {
                List<OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.Client, this.PrimaryValue);
                if (!listPower.Contains(OperatePower.New))
                {
                    if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                        this.FormState = FormStates.Edit;
                    this.PrimaryValue = this.tbClientCode.Text.Trim();
                    this.PerInit();
                    this.BindData(this.tbClientCode.Text.Trim());
                    this.ShowMsg("数据保存成功！\r\n但您没有新建客户权限，如有需要请联系管理员开放该权限!");
                }
                else
                {
                    //重新加载数据
                    this.FormState = FormStates.New;
                    this.PrimaryValue = string.Empty;
                    this.PerInit();
                    this.BindData(string.Empty);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
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
            try
            {
                this.BllDAL.Detele(this.PrimaryValue.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.FormColse();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            frmContacter frm = new frmContacter();
            frm.Text = "新增联系人";
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                //添加前，先校验是否已经存在该联系人了
                if (this.DataSource.Tables["V_JC_ClientContacters"].Select("ContacterCode='" + frm.ContacterCode + "'").Length > 0)  //ContacterCode需要转变成ContacterCode
                {
                    this.ShowMsg("联系人“" + frm.ContacterCode + "”已经存在了，请勿重复添加");
                    return;
                }
                DataSet ds = this.DataSource;
                if (ds == null) return;
                DataTable dt = ds.Tables["V_JC_ClientContacters"];
                int iSortid;
                if (dt.DefaultView.Count == 0)
                    iSortid = 1;
                else
                    iSortid = int.Parse(dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"].ToString()) + 1;
                DataRow drNew = dt.NewRow();
                drNew["ClientCode"] = this.tbClientCode.Text;
                drNew["ContacterCode"] = frm.ContacterCode;
                drNew["Code"] = frm.ContacterCode;
                drNew["CNName"] = frm.CNName;
                drNew["Sex"] = frm.Sex;
                drNew["SexView"] = frm.SexView;
                drNew["Tels"] = frm.Tel;
                drNew["Postion"] = frm.Post;
                drNew["MobileTels"] = frm.MobileTel;
                drNew["Emails"] = frm.Email;
                drNew["Faxs"] = frm.Fax;
                drNew["Remark"] = frm.Remark;
                drNew["SortID"] = iSortid;

                this.DataSource.Tables["V_JC_ClientContacters"].Rows.Add(drNew);
            }
            this.dgvContacter.DataSource = this.DataSource.Tables["V_JC_ClientContacters"];
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (this.dgvContacter.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvContacter.DataSource as DataTable;
            DataRow dr = dt.DefaultView[this.dgvContacter.SelectedRows[0].Index].Row;
            frmContacter frm = new frmContacter();
            frm.ContacterCode = dr["ContacterCode"].ToString();
            //frm.ContacterCode = dr["ContacterCode"].ToString();
            frm.CNName = dr["ContactCNName"].ToString();
            frm.Sex = dr["Sex"].Equals(DBNull.Value) ? 0 : (int)dr["Sex"];
            frm.Tel = dr["Tels"].ToString();
            frm.Post = dr["Postion"].ToString();
            frm.MobileTel = dr["MobileTels"].ToString();
            frm.Email = dr["Emails"].ToString();
            frm.Fax = dr["Faxs"].ToString();
            frm.Remark = dr["Remark"].ToString();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (!dr["ContacterCode"].Equals(frm.ContacterCode))
                    dr["ContacterCode"] = frm.ContacterCode;
                if (!dr["Code"].Equals(frm.ContacterCode))
                    dr["Code"] = frm.ContacterCode;
                if (!dr["CNName"].Equals(frm.CNName))
                    dr["CNName"] = frm.CNName;
                if (!dr["Sex"].Equals(frm.Sex))
                    dr["Sex"] = frm.Sex;
                if (!dr["SexView"].Equals(frm.SexView))
                    dr["SexView"] = frm.SexView;
                if (!dr["Tels"].Equals(frm.Tel))
                    dr["Tels"] = frm.Tel;
                if (!dr["Postion"].Equals(frm.Post))
                    dr["Postion"] = frm.Post;
                if (!dr["MobileTels"].Equals(frm.MobileTel))
                    dr["MobileTels"] = frm.MobileTel;
                if (!dr["Emails"].Equals(frm.Email))
                    dr["Emails"] = frm.Email;
                if (!dr["Faxs"].Equals(frm.Fax))
                    dr["Faxs"] = frm.Fax;
                if (!dr["Remark"].Equals(frm.Remark))
                    dr["Remark"] = frm.Remark;

            }
            this.dgvContacter.DataSource = this.DataSource.Tables["V_JC_ClientContacters"];
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (this.dgvContacter.SelectedRows.Count == 0)
                return;
            //if (DialogResult.Yes != MessageBox.Show(this, "您确定要移除", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //    return;
            DataTable dt = this.dgvContacter.DataSource as DataTable;
            dt.DefaultView[this.dgvContacter.SelectedRows[0].Index].Row.Delete();
            this.dgvContacter.DataSource = this.DataSource.Tables["V_JC_ClientContacters"];
        }
        

        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvContacter.DataSource as DataTable;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            frmContacter frm = new frmContacter();
            frm.ContacterCode = dr["ContacterCode"].ToString();
            frm.CNName = dr["ContactCNName"].ToString();
            frm.Sex = dr["Sex"].Equals(DBNull.Value) ? 0 : (int)dr["Sex"];
            frm.Tel = dr["Tels"].ToString();
            frm.Post = dr["Postion"].ToString();
            frm.MobileTel = dr["MobileTels"].ToString();
            frm.Email = dr["Emails"].ToString();
            frm.Fax = dr["Faxs"].ToString();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                if (!dr["ContacterCode"].Equals(frm.ContacterCode))
                    dr["ContacterCode"] = frm.ContacterCode;
                if (!dr["Code"].Equals(frm.ContacterCode))
                    dr["Code"] = frm.ContacterCode;
                if (!dr["CNName"].Equals(frm.CNName))
                    dr["CNName"] = frm.CNName;
                if (!dr["Sex"].Equals(frm.Sex))
                    dr["Sex"] = frm.Sex;
                if (!dr["SexView"].Equals(frm.SexView))
                    dr["SexView"] = frm.SexView;
                if (!dr["Tels"].Equals(frm.Tel))
                    dr["Tels"] = frm.Tel;
                if (!dr["Postion"].Equals(frm.Post))
                    dr["Postion"] = frm.Post;
                if (!dr["MobileTels"].Equals(frm.MobileTel))
                    dr["MobileTels"] = frm.MobileTel;
                if (!dr["Emails"].Equals(frm.Email))
                    dr["Emails"] = frm.Email;
                if (!dr["Faxs"].Equals(frm.Fax))
                    dr["Faxs"] = frm.Fax;
                if (!dr["Remark"].Equals(frm.Remark))
                    dr["Remark"] = frm.Remark;

            }
            this.dgvContacter.DataSource = this.DataSource.Tables["V_JC_ClientContacters"];
        }
        #endregion

    }
}
