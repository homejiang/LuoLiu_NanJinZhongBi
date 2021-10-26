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
using Common.MyEntity;

namespace BasicData.Material
{
    public partial class frmMaterial : frmBase
    {
        public frmMaterial()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Material _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Material BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.Material();
                return _dal;
            }
        }
        #endregion
        #region 默认类别
        string _strDefaultClassID = string.Empty;
        /// <summary>
        /// 默认物料类别
        /// </summary>
        public string DefaultClassCode
        {
            get { return this._strDefaultClassID; }
            set { this._strDefaultClassID = value; }
        }
        #endregion
        #region 重写函数
        public override string GetEditFormText(string sCode, FormStates state)
        {
            //frmMaterialList frm = this.FormParent as frmMaterialList;
            //if (frm == null)
            //    frm = new frmMaterialList();
            //return frm.GetEditFormText(sCode, state);
            if (state == Common.MyEnums.FormStates.New || state == Common.MyEnums.FormStates.Copy)
                return "新增原材料";
            string strText = string.Format("原材料\"{0}\"", sCode);
            if (state == Common.MyEnums.FormStates.None)
                strText += "（加载失败）";
            else if (state == Common.MyEnums.FormStates.Readonly)
                strText += "（只读）";
            return strText;
        }
        #region 重写函数
        public override bool CheckClose()
        {
            if (this.IsDataChanged)
                return DialogResult.Yes == MessageBox.Show(this, "数据已经修改，您确定不用保存？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return true;
        }
        #endregion
        #endregion
        #region 重写窗体关闭前校验
        private bool IsDataChanged
        {
            get
            {
                if (this.FormState != Common.MyEnums.FormStates.New && this.FormState != Common.MyEnums.FormStates.Edit
                    && this.FormState != Common.MyEnums.FormStates.Copy)
                    return false;//如果窗体为不可编辑，那即为未改变
                bool isChanged = false;
                if (this.DataSource == null) return false;
                if (this.DataSource.GetChanges() != null)
                    isChanged = true;
                else
                {
                    DataSet dsTemp = this.DataSource.Copy();
                    if (!this.ReadForm(dsTemp)) return true;
                    if (dsTemp.GetChanges() != null)
                        isChanged = true;
                }
                return isChanged;
            }
        }
        #endregion
        #region 处理函数
        /// <summary>
        /// 窗体预加载项
        /// </summary>
        /// <returns></returns>
        private bool PerInit()
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT Code ,SortID,DefaultName FROM JC_Unit WHERE ISNULL(Terminated,0)=0 ORDER BY SortID ASC", "JC_Unit"));
            listSql.Add(new CommonDAL.SqlSearchEntiy("EXEC JC_Material_GetDTypeList null", "JC_Material_GetDTypeList"));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //绑定单位
            List<ComboBoxItem> listUnit = new List<ComboBoxItem>();
            foreach (DataRow dr in ds.Tables["JC_Unit"].Rows)
            {
                listUnit.Add(new ComboBoxItem(dr["DefaultName"].ToString(), dr["Code"].ToString()));
            }
            this.comUnit.DisplayMember = "Text";
            this.comUnit.ValueMember = "Value";
            this.comUnit.DataSource = listUnit;
            //获取尺寸描述
            List<ComboBoxItem> listDType = new List<ComboBoxItem>();
            foreach (DataRow dr in ds.Tables["JC_Material_GetDTypeList"].Rows)
            {
                listDType.Add(new ComboBoxItem(dr["des"].ToString(), dr["headerText"].ToString(), dr["arg"].ToString()));
            }
            this.comDType.DisplayMember = "Text";
            this.comDType.DataSource = listDType;
            this.myDataGridView1.AutoGenerateColumns = false;
            this.dgvMaterialSpec.AutoGenerateColumns = false;
            //设置列表明细不允许排序
            foreach (DataGridViewColumn col in this.dgvMaterialSpec.Columns)
            {
                if (col.SortMode != DataGridViewColumnSortMode.NotSortable)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn col in this.myDataGridView1.Columns)
            {
                if (col.SortMode != DataGridViewColumnSortMode.NotSortable)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            return true;
        }
        /// <summary>
        /// 加载窗体数据
        /// </summary>
        /// <param name="strCode">原材料编号</param>
        /// <returns></returns>
        private bool BindData(string strCode)
        {
            DataSet ds = null;
            List<CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT *,dbo.[JC_Material_FullPathClass](ClassCode) AS FullClassName FROM JC_Material WHERE MaterialCode='" + strCode.Replace("'", "''") + "'";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_Material", true));
            strSql = "SELECT * FROM V_JC_MaterialSupplier WHERE MaterialCode='" + strCode.Replace("'", "''") + "' ORDER BY SortID ASC";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "V_JC_MaterialSupplier", true));
            strSql = "SELECT * FROM JC_MaterialSpecs WHERE MaterialCode='" + strCode.Replace("'", "''") + "' ORDER BY SortID ASC";
            listSql.Add(new CommonDAL.SqlSearchEntiy(strSql, "JC_MaterialSpecs", true));
            try
            {
                ds = CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["JC_Material"];
            DataTable dtDetail = ds.Tables["V_JC_MaterialSupplier"];
            DataTable dtSpec = ds.Tables["JC_MaterialSpecs"];
            dtDetail.DefaultView.Sort = "SortID asc";
            dtSpec.DefaultView.Sort = "SortID asc";
            DataColumn dcTerminated = new DataColumn("TerminatedView", Type.GetType("System.String"));
            dcTerminated.Expression = "IIF(Terminated=1,'停用','启用')";
            dtSpec.Columns.Add(dcTerminated);
            DataRow dr;
            if (dt.DefaultView.Count == 0)
            {
                if (strCode.Length > 0)
                {
                    this.ShowMsg("原材料编号“" + strCode + "”不存在，或已经被删除！");
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
                dr["MaterialCode"] = this.GetAutoCode(Common.MyEnums.Modules.Material);
                if (this.DefaultClassCode.Length > 0)
                {
                    dr["ClassCode"] = this.DefaultClassCode;
                    DataTable dtClass;
                    try
                    {
                        dtClass = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.[JC_Material_FullPathClass]('{0}')"
                            , this.DefaultClassCode.Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    dr["FullClassName"] = dtClass.Rows[0][0];
                }
                dr["CreateTime"] = time;
                dr["Terminated"] = false;
                dr["IsNeedDiameter"] = true;
                dt.Rows.Add(dr);
            }
            else
                dr = dt.DefaultView[0].Row;
            //绑定窗体数据
            this.tbCode.Text = dr["MaterialCode"].ToString();
            this.tbMaterialName.Text = dr["CNName"].ToString();
            this.tbClass.Tag = dr["ClassCode"].ToString();
            this.tbClass.Text = dr["FullClassName"].ToString();
            this.myVirCode.Text = dr["VirCode"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comUnit, new ComboBoxItem(string.Empty, dr["UnitCode"]), 0);
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            this.ChkIsSys.Checked = !dr["IsSys"].Equals(DBNull.Value) && (bool)dr["IsSys"];
            Common.CommonFuns.FormatData.SetComboBoxText(this.comDType, new ComboBoxItem(string.Empty, dr["DiameterType"]), 0);
            this.nmbMinStorage.BindValue = dr["MinStorage"];
            this.nmbMaxStorage.BindValue = dr["MaxStorage"];
            this.tbRemark.Text = dr["Remark"].ToString();
            //decimal decTax;
            //if (!dr["Tax"].Equals(DBNull.Value))
            //    this.numTax.Text = Common.CommonFuns.FormatData.GetStringByDecimal(decimal.Parse(dr["Tax"].ToString()) * 100, "#########0.####");
            //else this.numTax.Clear();
            //加载型号
            this.dgvMaterialSpec.DataSource = ds.Tables["JC_MaterialSpecs"];
            //加载明细信息
            this.myDataGridView1.DataSource = dtDetail;
            this.DataSource = ds;//存储数据源
            SetSpecDgvDTypeVisible();//设置规格列表的尺寸列
            return true;
        }
        private void SetSpecDgvDTypeVisible()
        {
            Common.MyEntity.ComboBoxItem item = this.comDType.SelectedItem as Common.MyEntity.ComboBoxItem;
            string strHeader = item == null ? string.Empty : item.Text1;//取得标题
            string[] arrH = strHeader.Split('|');
            if (this.dgvSpecColDia1.Visible ^ (arrH.Length > 0 && arrH[0] != string.Empty))
                this.dgvSpecColDia1.Visible = (arrH.Length > 0 && arrH[0] != string.Empty);
            if (this.dgvSpecColDia2.Visible ^ arrH.Length > 1)
                this.dgvSpecColDia2.Visible = arrH.Length > 1;
            if (this.dgvSpecColDia3.Visible ^ arrH.Length > 2)
                this.dgvSpecColDia3.Visible = arrH.Length > 2;
            if (this.dgvSpecColDia1.Visible)
                this.dgvSpecColDia1.HeaderText = arrH[0];
            if (this.dgvSpecColDia2.Visible)
                this.dgvSpecColDia2.HeaderText = arrH[1];
            if (this.dgvSpecColDia3.Visible)
                this.dgvSpecColDia3.HeaderText = arrH[2];
        }
        private void SetFormState()
        {
            //根据窗体状态限制操作
            bool blEdit = this.FormState == FormStates.New || this.FormState == FormStates.Copy || this.FormState == FormStates.Edit;

            this.tsbDel.Enabled = blEdit && this.FormState == FormStates.Edit;
            this.tsbFiles.Enabled = blEdit;
            this.tsbSave.Enabled = blEdit;
            //this.nvbtSpecRemove.Enabled = this.tsbSave.Enabled;
            //this.nvbtSpecUp.Enabled = this.tsbSave.Enabled;
            //this.nvbtSpecDown.Enabled = this.tsbSave.Enabled;
            this.tsbSAdd.Enabled = this.tsbSave.Enabled;
            this.tsbSRemove.Enabled = this.tsbSave.Enabled;
            this.tsbSUp.Enabled = this.tsbSave.Enabled;
            this.tsbSDown.Enabled = this.tsbSave.Enabled;
            this.tsbSOpen.Enabled = this.FormState != FormStates.None;
            if (blEdit) this.linkClass.LinkArea = new LinkArea(0, this.linkClass.Text.Length);
            else this.linkClass.LinkArea = new LinkArea(0, 0);
            //设置窗口标题
            string strText = this.GetEditFormText(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString(), this.FormState);
            if (strText != this.Text)
                this.ChangeWinTitle(strText);
        }
        #endregion
        #region 窗体事件
        //加载窗体
        private void frmMaterial_Load(object sender, EventArgs e)
        {
            //窗体预加载数据
            if (!this.PerInit())
                return;
            if (!this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()))
                this.FormState = FormStates.None;
            SetFormState();
        }
        #endregion
        #region 保存数据
        /// <summary>
        /// 保存前校验
        /// </summary>
        /// <returns></returns>
        private bool SaveCheck()
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态不允许编辑！");
                return false;
            }
            //检查必输入项
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入物料编号。");
                this.tbCode.Focus();
                return false;
            }
            if (this.tbMaterialName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入物料名称。");
                this.tbMaterialName.Focus();
                return false;
            }
            if (this.FormState == FormStates.New ||
                (this.FormState == FormStates.Edit && string.Compare(this.tbCode.Text, this.PrimaryValue.ToString(), true) != 0))
            {
                //判断物料编码是否已经存在
                DataTable dt = null;
                try
                {
                    dt = CommonDAL.DoSqlCommand.GetDateTable("SELECT MaterialCode FROM JC_Material WHERE MaterialCode='" + this.tbCode.Text.Trim() + "'");
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (dt.Rows.Count > 0)
                {
                    this.ShowMsg(string.Format("物料编号“{0}”已经存在，请您更换！", this.tbCode.Text));
                    this.tbCode.Focus();
                    return false;
                }
            }
            if (this.tbMaterialName.Text.Length > 0)
            {
                //判断物料名称是否存在
                if (this.FormState == FormStates.New ||
                    (this.FormState == FormStates.Edit && string.Compare(this.DataSource.Tables["JC_Material"].DefaultView[0].Row["CNName"].ToString(),this.tbMaterialName.Text,true)!=0))
                {
                    DataTable dt = null;
                    try
                    {
                        dt = CommonDAL.DoSqlCommand.GetDateTable("SELECT MaterialCode FROM JC_Material WHERE CNName='" + this.tbMaterialName.Text.Trim().Replace("'", "''") + "'");
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        this.ShowMsg(string.Format("物料名称“{0}”已经存在，请您更换！", this.tbMaterialName.Text.Trim()));
                        this.tbMaterialName.Focus();
                        return false;
                    }
                }
            }
            if (this.chkTerminated.Checked) return true;
            ComboBoxItem item = this.comUnit.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString() == string.Empty)
            {
                this.ShowMsg("启用原材料前，请选择单位");
                this.comUnit.Focus();
                return false;
            }
            int iDType;
            item = this.comDType.SelectedItem as ComboBoxItem;
            if (item == null || item.Value == null || !int.TryParse(item.Value.ToString(), out iDType))
                iDType = 0;
            //校验明细是否有未写必须项的
            foreach (DataRowView drv in this.DataSource.Tables["JC_MaterialSpecs"].DefaultView)
            {
                if (drv.Row["Spec"].ToString().Length == 0)
                {
                    this.ShowMsg("要启用原材料，规格不能为空。");
                    return false;
                }
                //if (drv.Row["Density"].Equals(DBNull.Value) || decimal.Parse(drv.Row["Density"].ToString()) <= 0M)
                //{
                //    this.ShowMsg("要启用原材料，密度不能为空或0。");
                //    return false;
                //}
                //if (drv.Row["LossRate"].Equals(DBNull.Value) || decimal.Parse(drv.Row["LossRate"].ToString()) <= 0M)
                //{
                //    this.ShowMsg("要启用原材料，损耗率不能为空或0。");
                //    return false;
                //}
                if (this.dgvSpecColDia1.Visible)
                {
                    if (drv.Row["Diameter"].Equals(DBNull.Value) || decimal.Parse(drv.Row["Diameter"].ToString()) <= 0M)
                    {
                        this.ShowMsg("要启用原材料，规格明细的“" + this.dgvSpecColDia1.HeaderText + "”值不能为空。");
                        return false;
                    }
                }
                if (this.dgvSpecColDia2.Visible)
                {
                    if (drv.Row["Diameter1"].Equals(DBNull.Value) || decimal.Parse(drv.Row["Diameter1"].ToString()) <= 0M)
                    {
                        this.ShowMsg("要启用原材料，规格明细的“" + this.dgvSpecColDia2.HeaderText + "”值不能为空。");
                        return false;
                    }
                }
                if (this.dgvSpecColDia3.Visible)
                {
                    if (drv.Row["Diameter2"].Equals(DBNull.Value) || decimal.Parse(drv.Row["Diameter2"].ToString()) <= 0M)
                    {
                        this.ShowMsg("要启用原材料，规格明细的“" + this.dgvSpecColDia3.HeaderText + "”值不能为空。");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool Save(DataSet dsSource)
        {
            if (!this.ReadForm(dsSource)) return false;
            if (dsSource.GetChanges() == null) return true;//没有改变则直接返回真
            int iReturnValue;
            string sMsg;
            try
            {
                this.BllDAL.Save(dsSource, out sMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }

            return true;
        }

        private bool ReadForm(DataSet dsSource)
        {
            //只读取可编辑项
            DataRow dr = dsSource.Tables["JC_Material"].DefaultView[0].Row;
            if (dr["MaterialCode"].ToString()!=this.tbCode.Text)
                dr["MaterialCode"] = this.tbCode.Text;
            if (dr["CNName"].ToString() != this.tbMaterialName.Text)
                dr["CNName"] = this.tbMaterialName.Text;
            string strClass = this.tbClass.Tag == null ? string.Empty : this.tbClass.Tag.ToString();
            if (dr["ClassCode"].ToString() != strClass)
                dr["ClassCode"] = strClass;
            Common.MyEntity.ComboBoxItem item = this.comUnit.SelectedItem as Common.MyEntity.ComboBoxItem;
            string strUnit;
            if (item == null || item.Value == null) strUnit = string.Empty;
            else strUnit = item.Value.ToString();
            if (dr["UnitCode"].ToString() != strUnit)
                dr["UnitCode"] = strUnit;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            if ((!dr["IsSys"].Equals(DBNull.Value) && (bool)dr["IsSys"]) ^ this.ChkIsSys.Checked)
                dr["IsSys"] = this.ChkIsSys.Checked;
            if (!dr["MinStorage"].Equals(this.nmbMinStorage.BindValue))
                dr["MinStorage"] = this.nmbMinStorage.BindValue;
            if (!dr["MaxStorage"].Equals(this.nmbMaxStorage.BindValue))
                dr["MaxStorage"] = this.nmbMaxStorage.BindValue;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            if (dr["VirCode"].ToString() != this.myVirCode.Text)
                dr["VirCode"] = this.myVirCode.Text;
            item = this.comDType.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString() == string.Empty)
            {
                if (!dr["DiameterType"].Equals(DBNull.Value))
                    dr["DiameterType"] = DBNull.Value;
            }
            else
            {
                if (dr["DiameterType"].ToString() != item.Value.ToString())
                    dr["DiameterType"] = int.Parse(item.Value.ToString());
            }
            //decimal decTax;
            //if (decimal.TryParse(this.numTax.Text, out decTax))
            //{
            //    decTax = decTax / 100;
            //    if (!dr["Tax"].Equals(decTax))
            //        dr["Tax"] = decTax;
            //}
            //else
            //{
            //    if (!dr["Tax"].Equals(DBNull.Value))
            //        dr["Tax"] = DBNull.Value;
            //}
            item = this.comUnit.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                if (!dr["UnitCode"].Equals(item.Value))
                    dr["UnitCode"] = item.Value;
            }
            //保存明细
            string strMaterialCode = this.tbCode.Text.Trim();
            foreach (DataRowView drv in dsSource.Tables["V_JC_MaterialSupplier"].DefaultView)
            {
                if (drv.Row["MaterialCode"].ToString() != strMaterialCode)
                    drv.Row["MaterialCode"] = strMaterialCode;
            }
            foreach (DataRowView drv in dsSource.Tables["JC_MaterialSpecs"].DefaultView)
            {
                if (!drv.Row["MaterialCode"].Equals(strMaterialCode))
                    drv.Row["MaterialCode"] = strMaterialCode;
            }
            return true;
        }

        #endregion
        #region 工具条按钮事件
        private void btNew_Click(object sender, EventArgs e)
        {
            //校验是否有权限新建数据
            List<OperatePower> listPower = this.GetOperatePower(Common.CurrentUserInfo.UserCode, Common.MyEnums.Modules.Material, this.PrimaryValue);
            if (!listPower.Contains(OperatePower.New))
            {
                this.ShowMsg("你没有权限新增数据，如有需要，请联系管理员开放此权限！");
                return;
            }
            this.FormState = FormStates.New;
            this.PrimaryValue = null;
            this.BindData(string.Empty);
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            DataSet ds = this.DataSource.Copy();
            if (this.Save(ds))
            {
                //重新加载数据
                if (this.FormState == FormStates.New)
                    this.FormState = FormStates.Edit;
                this.PrimaryValue = this.tbCode.Text;
                this.ShowMsg("保存成功！");
                if (!this.BindData(this.PrimaryValue.ToString()))
                    this.FormState = FormStates.None;
                this.SetFormState();
                return;
            }
        }
        
        private void btDelete_Click(object sender, EventArgs e)
        {
            //删除数据
       
            if (DialogResult.Yes != MessageBox.Show(this, "删除之后数据将无法恢复，你确定是否要删除数据？“" + this.PrimaryValue.ToString() + "”吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;

         
            //校验是否有权限删除数据
            List<OperatePower> listPower = this.GetOperatePower(Common.CurrentUserInfo.UserCode, Common.MyEnums.Modules.Material, this.PrimaryValue);
            if (!listPower.Contains(OperatePower.Delete))
            {
                this.ShowMsg("你没有权限删除数据，如有需要，请联系管理员开放此权限！");
                return;
            }
            //此时可以直接删除数据
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.Detele(this.PrimaryValue.ToString(), out strMsg,out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length > 0)
                    strMsg = "删除失败，原因未知。";
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
            this.ModuleFiles(Modules.Material, this.PrimaryValue, Common.CurrentUserInfo.UserCode);
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        #endregion
        #region 供应商操作
        private void btSelectSupplier_Click(object sender, EventArgs e)
        {
            BasicData.Supplier.SelectForm.frmSupplier frm = new BasicData.Supplier.SelectForm.frmSupplier();
            frm.MultiSelected = true;
            if (DialogResult.OK != frm.ShowDialog(this) || frm.SelectedData.Count == 0)
                return;
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (string.Compare(dt.DefaultView.Sort, "SortID ASC", true) != 0)
                dt.DefaultView.Sort = "SortID ASC";
            int iSortID;
            if (dt.DefaultView.Count == 0) iSortID = 0;
            else
                iSortID = int.Parse(dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"].ToString()) + 1;

            foreach (BasicData.Supplier.SelectForm.frmSupplier.SelectedSupplierInfo info in frm.SelectedData)
            {
                DataRow drNew = dt.NewRow();
                if (dt.Select("SupplierCode='" + info.Code.ToString() + "'").Length > 0)
                {
                    this.ShowMsg("供货商“" + info.CNName.ToString() + "”已经存在了，请勿重复添加");
                    continue;
                }
                drNew["MaterialCode"] = string.Empty;
                drNew["SortID"] = iSortID;
                drNew["SupplierCode"] = info.Code;
                drNew["CNName"] = info.CNName;
                drNew["ENName"] = info.ENName;
                drNew["ShortName"] = info.ShortName;
                drNew["Address"] = info.Address;
                drNew["Country"] = info.Country;
                drNew["Province"] = info.Province;
                drNew["Tels"] = info.Tels;
                drNew["Faxs"] = info.Faxs;
                //drNew["Contacters"] = dr["Contacters"];
                dt.Rows.Add(drNew);
                iSortID = iSortID + 1;
            }
        }
        private void btRemove_Click(object sender, EventArgs e)
        {
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.myDataGridView1);
            if (list.Count == 0)
            {
                this.ShowMsg("请选择要删除的行。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中行吗？")) return;
            for (int i = list.Count; i > 0; i--)
            {
                dt.DefaultView[list[i - 1]].Row.Delete();
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null) return;
            Common.CommonFuns.DataGridViewRowUp(this.myDataGridView1, "SortID");
        }
        private void btDown_Click(object sender, EventArgs e)
        {

            if (this.DataSource == null) return;
            Common.CommonFuns.DataGridViewRowDown(this.myDataGridView1, "SortID");
        }

        private void tsbSOpen_Click(object sender, EventArgs e)
        {
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.myDataGridView1);
            if (list.Count == 0)
            {
                this.ShowMsg("请选择要打开的行。");
                return;
            }
            foreach (int row in list)
            {
                BasicData.Supplier.frmSupplier frm = new BasicData.Supplier.frmSupplier();
                frm.PrimaryValue = dt.DefaultView[row].Row["SupplierCode"].ToString();
                frm.FormState = FormStates.Readonly;
                frm.Show();
            }
        }

        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null) return;
            BasicData.Supplier.frmSupplier frm = new BasicData.Supplier.frmSupplier();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["SupplierCode"].ToString();
            frm.FormState = FormStates.Readonly;
            frm.Show();
        }
        #endregion
        #region 规格明细操作
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmMaterialspec frm = new frmMaterialspec();
            Common.MyEntity.ComboBoxItem item = this.comDType.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
            {
                this.ShowMsg("请选择尺寸描述方式。");
                this.comDType.Focus();
                return; 
            }
            frm._DTypeView = item.Text;
            frm._IsD1Show = this.dgvSpecColDia1.Visible;
            frm._IsD2Show = this.dgvSpecColDia2.Visible;
            frm._IsD3Show = this.dgvSpecColDia3.Visible;
            decimal dec;
            frm.Text = "新增原材料规格";
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            if (this.DataSource.Tables["JC_MaterialSpecs"].Select("Spec='" + frm._Spec + "'").Length > 0)
            {
                this.ShowMsg("型号“" + frm._Spec + "”已经存在了，请勿重复添加");
                return;
            }
            DataTable dt = this.DataSource.Tables["JC_MaterialSpecs"];
            if (string.Compare(dt.DefaultView.Sort, "SortID Asc", true) != 0)
                dt.DefaultView.Sort = "SortID Asc";
            int iSortid;
            if (dt.DefaultView.Count == 0)
                iSortid = 1;
            else
                iSortid = int.Parse(dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"].ToString()) + 1;
            DataRow drNew = dt.NewRow();
            drNew["GUID"] = this.GetGUID(Modules.Material, Common.CurrentUserInfo.UserCode);
            drNew["MaterialCode"] = this.tbCode.Text;
            drNew["Spec"] = frm._Spec;
            drNew["Density"] = frm._objDensity;
            drNew["LossRate"] = frm._objLossRate;
            drNew["Diameter"] = frm._objDiameter1;
            drNew["Diameter1"] = frm._objDiameter2;
            drNew["Diameter2"] = frm._objDiameter3;
            drNew["BusinessCode"] = frm._BusinessCode;
            drNew["Remark"] = frm._Remark;
            drNew["Terminated"] = frm._Terminated;
            drNew["SortID"] = iSortid;
            this.DataSource.Tables["JC_MaterialSpecs"].Rows.Add(drNew);
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvMaterialSpec.DataSource as DataTable;
            if (dt == null) return;
            Common.MyEntity.ComboBoxItem item = this.comDType.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
            {
                this.ShowMsg("请选择尺寸描述方式。");
                this.comDType.Focus();
                return;
            }
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvMaterialSpec);
            if (list.Count == 0)
            {
                this.ShowMsg("请选择要编辑的行。");
                return;
            }
            foreach (int row in list)
            {
                EditSpec(row);
            }
        }
        private void btmove_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvMaterialSpec.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvMaterialSpec);
            if (list.Count == 0)
            {
                this.ShowMsg("请选择要删除的行。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中行吗？")) return;
            for (int i = list.Count; i > 0; i--)
            {
                dt.DefaultView[list[i - 1]].Row.Delete();
            }
        }
        private void EditSpec(int iRow)
        {
            DataTable dt = this.dgvMaterialSpec.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[iRow].Row;
            frmMaterialspec frm = new frmMaterialspec();
            frm._Spec = dr["Spec"].ToString();
            frm._objLossRate = dr["LossRate"];
            frm._objDensity = dr["Density"];
            frm._objDiameter1 = dr["Diameter"];
            frm._objDiameter2 = dr["Diameter1"];
            frm._objDiameter3 = dr["Diameter2"];
            frm._BusinessCode = dr["BusinessCode"].ToString();
            frm._Remark = dr["Remark"].ToString();
            frm._Terminated = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            Common.MyEntity.ComboBoxItem item = this.comDType.SelectedItem as Common.MyEntity.ComboBoxItem;
            frm._DTypeView = item == null ? string.Empty : item.Text;
            frm._IsD1Show = this.dgvSpecColDia1.Visible;
            frm._IsD2Show = this.dgvSpecColDia2.Visible;
            frm._IsD3Show = this.dgvSpecColDia3.Visible;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (dr["Spec"].ToString() != frm._Spec)
                dr["Spec"] = frm._Spec;
            if (!dr["Density"].Equals(frm._objDensity))
                dr["Density"] = frm._objDensity;
            if (!dr["LossRate"].Equals(frm._objLossRate))
                dr["LossRate"] = frm._objLossRate;
            if (!dr["Diameter"].Equals(frm._objDiameter1))
                dr["Diameter"] = frm._objDiameter1;
            if (!dr["Diameter1"].Equals(frm._objDiameter2))
                dr["Diameter1"] = frm._objDiameter2;
            if (!dr["Diameter2"].Equals(frm._objDiameter3))
                dr["Diameter2"] = frm._objDiameter3;
            if (dr["BusinessCode"].ToString() != frm._BusinessCode)
                dr["BusinessCode"] = frm._BusinessCode;
            if (dr["Remark"].ToString() != frm._Remark)
                dr["Remark"] = frm._Remark;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ frm._Terminated)
                dr["Terminated"] = frm._Terminated;
        }
        private void dgvMaterialSpec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSpec(e.RowIndex);
        }

        private void tsbUp_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null) return;
            Common.CommonFuns.DataGridViewRowUp(this.dgvMaterialSpec, "SortID");
        }

        private void tsbDown_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null) return;
            Common.CommonFuns.DataGridViewRowDown(this.dgvMaterialSpec, "SortID");
        }
        #endregion
        #region 窗体控件事件
        private void comDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetSpecDgvDTypeVisible();
        }

        private void linkClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.Material.frmSelectMClass frm = new frmSelectMClass();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this) || frm.SelectedData.Count == 0) return;
            string strClass = frm.SelectedData[0].Code.ToString();
            DataTable dtClass;
            try
            {
                dtClass = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.[JC_Material_FullPathClass]('{0}')"
                    , strClass.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tbClass.Tag = strClass;
            this.tbClass.Text = dtClass.Rows[0][0].ToString();
        }
        #endregion
    }
}
