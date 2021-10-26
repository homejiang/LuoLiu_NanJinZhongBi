using Common.MyEnums;
using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.PactM
{
    public partial class frmPact : Common.frmBase
    {
        #region 常量信息
        const string _SendAuditText = "送审核";
        const string _OpenAuditDetailText = "查看审批信息";
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.PactM _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PactM BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PactM();
                return _dal;
            }
        }
        #endregion
        #region 窗口关键字段
        public string _PactCode = string.Empty;
        #endregion
        #region 私有属性
        /// <summary>
        /// 是否窗体数据已发生改变
        /// </summary>
        private bool IsDataChanged
        {
            get
            {
                bool isChanged = false;
                if (this.DataSource == null) return false;
                if (this.DataSource.GetChanges() != null)
                    isChanged = true;
                else
                {
                    DataSet dsTemp = this.DataSource.Copy();
                    this.ReadForm(dsTemp);
                    if (dsTemp.GetChanges() != null)
                        isChanged = true;
                }
                return isChanged;
            }
        }
        bool flag = true;
        private string ComVirCode = string.Empty;
        #endregion
        public frmPact(BLLDAL.PactM dal)
        {
            InitializeComponent();
            this._dal = dal;
        }
        #region 重写函数
        public override bool CheckClose()
        {
            if (this.IsDataChanged)
                return DialogResult.Yes == MessageBox.Show(this, "数据已经修改，您确定不用保存？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return true;
        }
        #endregion
        #region 处理函数
        private void SetControlEnabled(Control con, bool blEnabled)
        {
            if (con.Enabled != blEnabled)
                con.Enabled = blEnabled;
        }
        private void SetControlEnabled(LinkLabel con, bool blEnabled)
        {
            if (!blEnabled)
            {
                if (con.LinkArea != null && con.LinkArea.Length > 0)
                    con.LinkArea = new LinkArea(0, 0);
            }
            else
            {
                if (con.LinkArea == null || con.LinkArea.Length == 0)
                    con.LinkArea = new LinkArea(0, con.Text.Length);
            }
        }
        private void SetControlEnabled(ToolStripItem con, bool blEnabled)
        {
            if (con.Enabled != blEnabled)
                con.Enabled = blEnabled;
        }
        private void SetFormState(FormStates state, short iAudit, short iCompeletedState)
        {
            /*****界面控件状态分为：
             * 1、只读：即界面不管其他任何数据，仅仅是只读，这个时候一些查看类的按钮是可以点的，新建和复制也是可以点的
            ************************/
            #region 顶部工具条
            //设置工具条状态
            //保存按钮：非只读下，且还未送审的（送审后不允许修改通过保存的方式修改数据）
            SetControlEnabled(this.tsbSave, state != FormStates.Readonly && iAudit == 0);
            //新建按钮：当前已经为新建或拷贝不允许点击了，只读时允许操作。
            SetControlEnabled(this.tsbNew, state != FormStates.New && state != FormStates.Copy);
            //复制按钮：与新建按钮一致
            SetControlEnabled(this.tsbCopy, this.tsbNew.Enabled);
            //删除按钮：编辑状态下可以点击，且必须是非只读模式，如果已经送审则不允许点击
            SetControlEnabled(this.tsbDel, state != FormStates.Readonly && FormStates.Edit == state && iAudit == 0);
            //送审按钮：非只读模式下，还未送审过的都可以直接送审，已送审的则可以撤销，所以都可以编辑
            SetControlEnabled(this.tsbAudit, state != FormStates.Readonly && this.FormState == FormStates.Edit); 
            //导出Excel：目前只要保存过了就应该可以点击了，因为部分资料可能是在审核前就应该导出来，例如纸质审批单
            SetControlEnabled(this.tsbOutputExcel, this.FormState != FormStates.Copy && this.FormState != FormStates.New);
            #endregion
            #region 顶部工具条的扩展应用
            //目前扩展按钮下的信息，只有审批通过后才能看
            SetControlEnabled(this.tsbSpecialPro, iAudit == 3 || iAudit == -1);
            //SetControlEnabled(this.查看订单ToolStripMenuItem, iAudit == 3 || iAudit == -1);
            //SetControlEnabled(this.详细位置ToolStripMenuItem, iAudit == 3 || iAudit == -1);
            //SetControlEnabled(this.任务明细生产顺序统计ToolStripMenuItem, iAudit == 3 || iAudit == -1);
            //SetControlEnabled(this.生产发货单ToolStripMenuItem, iAudit == 3 || iAudit == -1);
            ////如果当前订单已经终止了，则终止按钮可以禁止掉
            //SetControlEnabled(this.终止当前生产订单ToolStripMenuItem, (iAudit == 3 || iAudit == -1) && iCompeletedState != 3);
            //SetControlEnabled(this.终止选中任务明细ToolStripMenuItem, iAudit == 3 || iAudit == -1);
            #endregion
            if(iAudit == 3 || iAudit == -1)
            {
                flag = false;
            }
            #region 明细操作
            SetControlEnabled(this.tsbdAdd, state != FormStates.Readonly && iAudit == 0);
            SetControlEnabled(this.tsbdCopy, state != FormStates.Readonly && iAudit == 0);
            SetControlEnabled(this.tsbdEdit, state != FormStates.Readonly && iAudit == 0);
            SetControlEnabled(this.tsbdRemove, state != FormStates.Readonly && iAudit == 0);
            SetControlEnabled(this.tsbdUp, state != FormStates.Readonly && iAudit == 0);
            SetControlEnabled(this.tsbdDown, state != FormStates.Readonly && iAudit == 0);
           // SetControlEnabled(this.dgvDetail_CellDoubleClick(null,e), state != FormStates.Readonly && iAudit == 0);
            #endregion
            #region 明细工具条扩展应用
            // SetControlEnabled(this.tsbdModifyData, state != FormStates.Readonly && iAudit == 3);
            #endregion
            #region 窗口控件
            SetControlEnabled(this.linkClient, this.tsbSave.Enabled);
            SetControlEnabled(this.linkCompany, this.tsbSave.Enabled);
            #endregion
            #region 设置文本显示
            this.tsbAudit.Text = iAudit == 0 ? _SendAuditText : _OpenAuditDetailText;
            if (iAudit == 0)
            {
                if (!this.tsbAudit.Image.Equals(global::LuoLiuMES.Properties.Resources.completed))
                    this.tsbAudit.Image = global::LuoLiuMES.Properties.Resources.completed;
            }
            else
            {
                if (!this.tsbAudit.Image.Equals(global::LuoLiuMES.Properties.Resources.Audited))
                    this.tsbAudit.Image = global::LuoLiuMES.Properties.Resources.Audited;
            }
            #endregion
            //设置窗口标题
            if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
            {
                this.ChangeWinTitle(this.BllDAL.PFuns_GetEditFromName(string.Empty, this.FormState));
            }
            else
            {
                this.ChangeWinTitle(this.BllDAL.PFuns_GetEditFromName(this._PactCode, this.FormState));
            }
            //明细列表中，状态仅当审核通过后才能显示，因为只有审核通过的才能关联盘
            if (this.dgvcState.Visible != (iAudit == -1 || iAudit == 3))
            {
                this.dgvcState.Visible = (iAudit == -1 || iAudit == 3);
                
            }
            
            if (this.dgvcCompeletedQty.Visible != this.dgvcState.Visible)
                this.dgvcCompeletedQty.Visible = this.dgvcState.Visible;
        }
        private void CalculaterFiberTotalLen()
        {
            //计算总长度
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null) return;
            decimal dec = 0M;
            foreach(DataRowView drv in dt.DefaultView)
            {
                if (drv.Row["Qty"].Equals(DBNull.Value)) continue;
                dec += decimal.Parse(drv.Row["Qty"].ToString());
            }
            string strText = dec.ToString("#,###,###,##0");
            if (this.TotalCnt.Text != strText)
                this.TotalCnt.Text = strText;
        }
        
        #endregion
        #region 加载数据
        private bool Perinit()
        {
            this.dgvDetail.AutoGenerateColumns = false;
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT Code,CodeName FROM JC_FactoryCode";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_FactoryCode", true));
            strSql = "SELECT Code,CodeName FROM JC_PackTypeCode";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_PackTypeCode", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //厂商代号
            this.ComGcCode.DisplayMember = "Text";
            this.ComGcCode.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_FactoryCode"].Rows)
            {
                this.ComGcCode.Items.Add(new Common.MyEntity.ComboBoxItem(dr["CodeName"].ToString(), dr["Code"].ToString()));
            }
            this.ComGcCode.SelectedIndex = -1;
            //电池组类型
            this.comPackType.DisplayMember = "Text";
            this.comPackType.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_PackTypeCode"].Rows)
            {
                this.comPackType.Items.Add(new Common.MyEntity.ComboBoxItem(dr["CodeName"].ToString(), dr["Code"].ToString()));
            }
            this.comPackType.SelectedIndex = -1;
            this.comPackYear.Items.Clear();
            this.comPackYear.Items.Add(1);
            this.comPackYear.Items.Add(2);
            this.comPackYear.Items.Add(3);
            this.comPackYear.Items.Add(4);
            this.comPackYear.Items.Add(5);
            //绑定自定义列表
            this.ShowDataGridViewSetting_BindColumn(this.dgvDetail, (int)Common.MyEnums.Modules.PactManager);
            return true;
        }
        private bool BindData(string sPactCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM V_Pact_Main WHERE PactCode='" + sPactCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Pact_Main", true));
            strSql = "SELECT * FROM Pact_MainExp WHERE PactCode='" + sPactCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Pact_MainExp", true));
            strSql = "SELECT * FROM V_Pact_Detail WHERE PactCode='" + sPactCode.Replace("'", "''") + "' order by SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Pact_Detail", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["Pact_Main"];
            DataTable dtExp = ds.Tables["Pact_MainExp"];
            DataTable dtDetail = ds.Tables["Pact_Detail"];
            dtDetail.DefaultView.Sort = "SortID ASC";
            dtExp.Columns["PactCode"].DefaultValue = string.Empty;

            //将明细表中字段设置成非只读
            foreach (DataColumn dc in dtDetail.Columns)
            {
                if (dtDetail.Columns[dc.ColumnName].ReadOnly)
                    dtDetail.Columns[dc.ColumnName].ReadOnly = false;
            }
            DataRow dr, drExp;
            if (dt.DefaultView.Count == 0)
            {
                if (sPactCode.Length > 0)
                {
                    this.ShowMsg("任务单“" + sPactCode + "”不存在，或已经被删除。");
                    return false;
                }
                #region 主表添加一新行
                dr = dt.NewRow();
                //设置默认值
                dr["PactCode"] = this.GetAutoCode((int)Common.MyEnums.Modules.PactManager);
                DateTime detCreate;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detCreate))
                    return false;
                dr["CreateTime"] = detCreate;
                dr["Creater"] = Common.CurrentUserInfo.UserCode;
                dr["CreaterName"] = Common.CurrentUserInfo.UserName;
                dt.Rows.Add(dr);
                #endregion
                #region 扩展表添加一新行
                drExp = dtExp.NewRow();
                //获取默认公司信息
                BasicData.BLLDAL.MyCompany.CompanyEntity defcompany = null;
                try
                {
                    defcompany = BasicData.BLLDAL.MyCompany.GetDefaultCompany();
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (defcompany != null)
                {
                    dt.DefaultView[0].Row["ComCode"] = defcompany.Code;//从基础信息表中获取默认公司信息
                    drExp["ComCNName"] = defcompany.CNName;//从基础信息表中获取默认公司信息
                    drExp["ComENName"] = defcompany.ENName;//从基础信息表中获取默认公司信息
                    drExp["ComShortName"] = defcompany.ShortName;//从基础信息表中获取默认公司信息
                    drExp["ComTels"] = defcompany.Tels;//从基础信息表中获取默认公司信息
                    drExp["ComFaxs"] = defcompany.Faxs;//从基础信息表中获取默认公司信息
                    drExp["ComAddress"] = defcompany.Address;//从基础信息表中获取默认公司信息
                }
                dtExp.Rows.Add(drExp);
                #endregion
            }
            else
            {
                //此时数据有获取，可能是编辑数据，也可能为复制数据
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                {
                    //if(ds.GetChanges()!=null)
                    //    return false;//如果有修改过，是不允许复制的，但这种情况是不可能存在的，因为数据直接从服务器读取过来，不做任何修改
                    string strNewCode = this.GetAutoCode((int)Common.MyEnums.Modules.PactManager);
                    #region 数据为拷贝
                    dt.Rows[0].SetAdded();//将改行设置为新增行
                    #region 设置主表默认数据
                    dt.Rows[0]["PactCode"] = strNewCode;
                    DateTime detCreate;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detCreate))
                        return false;
                    dt.Rows[0]["CreateTime"] = detCreate;
                    dt.Rows[0]["Creater"] = Common.CurrentUserInfo.UserCode;
                    dt.DefaultView[0].Row["CreaterName"] = Common.CurrentUserInfo.UserName;
                    dt.Rows[0]["AuditState"] = DBNull.Value;
                    dt.Rows[0]["AuditStateDate"] = DBNull.Value;
                    dt.Rows[0]["AuditSender"] = DBNull.Value;
                    dt.Rows[0]["AuditSenderName"] = DBNull.Value;
                    dt.Rows[0]["TotalCnt"] = DBNull.Value;
                    dt.Rows[0]["CompeletedState"] = DBNull.Value;
                    if (dt.Columns["StateView"].ReadOnly)
                        dt.Columns["StateView"].ReadOnly = false;
                    dt.Rows[0]["StateView"] = DBNull.Value;
                    #endregion
                    #region 设置扩展表信息
                    dtExp.Rows[0].SetAdded();
                    dtExp.Rows[0]["PactCode"] = strNewCode;//重置任务单号
                    #endregion
                    #region 设置明细表信息
                    string strDetailGuid,strDetailOrgGuid;
                    foreach (DataRow drtemp in dtDetail.Rows)
                    {
                        strDetailGuid = this.GetGUID((int)Common.MyEnums.Modules.PactManager, Common.CurrentUserInfo.UserCode);
                        strDetailOrgGuid = drtemp["GUID"].ToString();
                        drtemp.SetAdded();
                        drtemp["GUID"] = strDetailGuid;
                        drtemp["PactCode"] = strNewCode;
                        drtemp["CompeletedQty"] = DBNull.Value;
                        drtemp["Qty"] = DBNull.Value;
                        drtemp["CompeletedState"] = DBNull.Value;
                        
                    }
                    #endregion
                    #endregion
                    //复制和新增状态统一设置为FromStates.New,系统加载后将不会再有copy状态
                    if (this.FormState == FormStates.Copy)
                    {
                        this.FormState = FormStates.New;
                        this._PactCode = string.Empty;
                    }
                }
                dr = dt.DefaultView[0].Row;
                drExp = dtExp.DefaultView[0].Row;
            }
            //主表数据
            this.tbPactCode.Text = dr["PactCode"].ToString();
            this.tbCreateTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateTime"], "yyyy-MM-dd HH:mm");
            this.tbCreaterName.Text = dr["CreaterName"].ToString();
            this.tbPactStateView.Text = dr["StateView"].ToString();
            this.TotalCnt.Text = Common.CommonFuns.FormatData.GetStringByDecimal(dr["TotalCnt"], "#########0.###");
            this.tbRemark.Text = dr["Remark"].ToString();
            //扩展信息
            this.tbComName.Text = drExp["ComCNName"].ToString();
            this.tbComAddress.Text = drExp["ComAddress"].ToString();
            this.tbClientName.Text = drExp["ClientVirCode"].ToString();
            this.tbClientAddress.Text = drExp["ClientAddress"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.ComGcCode, new Common.MyEntity.ComboBoxItem("", drExp["FtCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comPackType, new Common.MyEntity.ComboBoxItem("", drExp["PackTypeCode"].ToString()), 0);
            this.comPackYear.Text = drExp["PackYear"].ToString();
            this.tbPackCode.Text = drExp["PackCode"].ToString();
            //绑定明细
            this.dgvDetail.DataSource = dtDetail;
            short iAuditState, iCompeletedState;
            if (!dr["AuditState"].Equals(DBNull.Value))
                iAuditState = short.Parse(dr["AuditState"].ToString());
            else iAuditState = 0;
            if (!dr["CompeletedState"].Equals(DBNull.Value))
                iCompeletedState = short.Parse(dr["CompeletedState"].ToString());
            else iCompeletedState = 0;
            this.SetFormState(this.FormState, iAuditState, iCompeletedState);
            this.DataSource = ds;
            
            return true;
        }
        private bool BindDataDetail(string sPactCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM V_Pact_Detail_Design WHERE PactCode='" + sPactCode.Replace("'", "''") + "' order by SortID";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "Pact_Detail", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvDetail.DataSource = ds.Tables["Pact_Detail"];
            return true;
        }
        #endregion
        #region 保存数据
        private bool SaveCheck()
        {
            if (this.tbPactCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("任务单号不能为空");
                return false;
            }
            if (this.tbComName.Text.Trim().Length == 0)
            {
                this.ShowMsg("公司名称不能为空");
                return false;
            }
            if (this.tbClientName.Text.Trim().Length == 0)
            {
                this.ShowMsg("客户名称不能为空");
                return false;
            }
            //品质判断是否已经选择
            object objPack = this.GetComBoboxValue(this.comPackType);
            if (objPack.ToString().Length == 0)
            {
                this.ShowMsg("请选择电池组类型。");
                this.comPackType.Focus();
                return false;
            }
            if (this.comPackYear.Text.ToString().Length == 0)
            {
                this.ShowMsg("请选择电池组年限。");
                this.comPackYear.Focus();
                return false;
            }
            object objFt = this.GetComBoboxValue(this.ComGcCode);
            if (objFt.ToString().Length == 0)
            {
                this.ShowMsg("请选择厂商代码。");
                this.ComGcCode.Focus();
                return false;
            }
            if (string.Compare(this._PactCode, this.tbPactCode.Text, true) != 0)
            {
                //此时订单号已经有改变了，则判断新的是否有重号
                DataTable dtCheck;
                try
                {
                    dtCheck = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM Pact_Main where pactCode='{0}'", this.tbPactCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "Check.PactID");
                    return false;
                }
                if (int.Parse(dtCheck.Rows[0][0].ToString()) > 0)
                {
                    this.ShowMsg(string.Format("任务单号\"{0}\"已存在，请更换！", this.tbPactCode.Text));
                    return false;
                }
            }
            return true;
        }
        private bool ReadForm(DataSet dsSource)
        {
            this.CalculaterFiberTotalLen();//计算一下总长度
            DataRow dr = dsSource.Tables["Pact_Main"].DefaultView[0].Row;
            DataRow drExp = dsSource.Tables["Pact_MainExp"].DefaultView[0].Row;
            int iAuditState;
            if (dr["AuditState"].Equals(DBNull.Value)) iAuditState = 0;
            else iAuditState = int.Parse(dr["AuditState"].ToString());
            if (iAuditState != 0)
                return true;//此时已经送审了，不用再保存数据
            //读取主表数据
            if (dr["PactCode"].ToString() != this.tbPactCode.Text)
                dr["PactCode"] = this.tbPactCode.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            decimal decTotalTotalCnt;
            if(!decimal.TryParse(this.TotalCnt.Text,out decTotalTotalCnt))
            {
                decTotalTotalCnt = 0M;
            }
           // decTotalTotalCnt = decTotalTotalCnt * 1000;//换算成米
            if (!dr["TotalCnt"].Equals(decTotalTotalCnt))
                dr["TotalCnt"] = decTotalTotalCnt;
            //扩展表信息
            if (drExp["PactCode"].ToString() != this.tbPactCode.Text)
                drExp["PactCode"] = this.tbPactCode.Text;
            this.SaveComBoboxValue(drExp, "FtCode", this.ComGcCode);
            this.SaveComBoboxValue(drExp, "PackTypeCode", this.comPackType);
            if (drExp["PackYear"].ToString() != this.comPackYear.Text)
                drExp["PackYear"] = this.comPackYear.Text;
            string sBOMGuid=string.Empty;
            //明细表
            foreach (DataRowView drv in dsSource.Tables["Pact_Detail"].DefaultView)
            {
                if (!drv.Row["PactCode"].Equals(this.tbPactCode.Text.Trim()))
                    drv.Row["PactCode"] = this.tbPactCode.Text;
                sBOMGuid = drv.Row["BomGuid"].ToString();
            }
            //获取成品编号预览
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Get_PackCode_Bom '{0}','{1}','{2}','{3}','{4}','{5}'",
                    sBOMGuid.ToString().Replace("'", "''"), this.ComGcCode.Text.ToString(), this.tbClientName.Text.ToString(), ComVirCode.ToString(),
                   this.comPackType.Text.ToString(), this.comPackYear.Text.ToString()));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "GetBOMDesc");
                return false;
            }
            this.tbPackCode.Text = dt.Rows[0]["PackCode"].ToString();
            if (drExp["PackCode"].ToString() != this.tbPackCode.Text)
                drExp["PackCode"] = this.tbPackCode.Text;
            return true;
        }
        private bool Save()
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态不允许编辑。");
                return false;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失,保存失败！");
                return false;
            }
            if (!this.SaveCheck()) return false;
            DataSet dsCopy = this.DataSource.Copy();
            return this.Save(dsCopy);
        }
        private bool Save(DataSet dsSource)
        {
            if (!this.ReadForm(dsSource)) return false;
            if (dsSource.GetChanges() == null) return true;
            string sMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.SavePact(dsSource, out sMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "DB.SavePact");
                return false;
            }
            return true;
        }
        private void SaveComBoboxValue(DataRow dr, string sColumnName, System.Windows.Forms.ComboBox comBobox)
        {
            object objValue = GetComBoboxValue(comBobox);
            if (!dr[sColumnName].Equals(objValue))
                dr[sColumnName] = objValue;
        }
        private object GetComBoboxValue(System.Windows.Forms.ComboBox comBobox)
        {
            object objValue;
            Common.MyEntity.ComboBoxItem item = comBobox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null) objValue = DBNull.Value;
            else if (item.Value == null) objValue = DBNull.Value;
            else objValue = item.Value;
            return objValue;
        }
        private bool CompeletedConfirm()
        {
            int iconfirmValue;
            string strConfirmMsg;
            int iOrgStep, iNewStep;
            iconfirmValue = -1;
            iOrgStep = 0;
            while (iconfirmValue != 1)
            {
                try
                {
                    this.BllDAL.CompleteConfirm(this._PactCode, iOrgStep, out iNewStep, out iconfirmValue, out strConfirmMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if (iconfirmValue == -1)
                {
                    if (strConfirmMsg == "")
                        strConfirmMsg = "校验未通过，原因未知。";
                    this.ShowMsg(strConfirmMsg);
                    return false;
                }
                else if (iconfirmValue == 0)
                {
                    iOrgStep = iNewStep;
                    if (!this.IsUserConfirm(strConfirmMsg)) return false;
                }
            }
            return true;
        }
        #endregion
        #region 顶部工具条按钮

        private void tsbSave_Click(object sender, EventArgs e)
        {
            //权限校验
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑生产订单的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            
            //保存数据
            if (this.Save())
            {
                this.ShowMsgRich("保存成功");
                if (this._PactCode != this.tbPactCode.Text)
                    this._PactCode = this.tbPactCode.Text;
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                    this.FormState = FormStates.Edit;
                if (!this.BindData(this._PactCode))
                {
                    this.FormState = FormStates.None;
                }
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建生产订单的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            this.FormState = FormStates.New;
            if (this.BindData(string.Empty))
            {
                this.ShowMsgRich("新建成功！");
                this._PactCode = string.Empty;
                return;
            }
            else
            {
                //加载失败在窗口设为无效
                this.FormState = FormStates.None;
                return;
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("你没有新建生产订单的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            this.FormState = FormStates.Copy;
            if (this.BindData(this._PactCode))
            {
                this.ShowMsgRich("复制成功！");
                return;
            }
            else
            {
                //加载失败在窗口设为无效
                this.FormState = FormStates.None;
                return;
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            //先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("你没有删除生产订单的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this._PactCode.Length == 0)
            {
                this.ShowMsg("请重新加载任务单");
                return;
            }
            if (!this.IsUserConfirm("删除后此任务单的所有信息将会丢失，您确定要删除生产任务单“" + this._PactCode + "”吗？")) return;
            string smsg;
            int iReturnvalue;
            try
            {
                this.BllDAL.PactDelete(this._PactCode, out iReturnvalue, out smsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnvalue != 1)
            {
                if (smsg.Length == 0)
                    smsg = "任务单“" + this._PactCode + "”删除失败。";
                this.ShowMsg(smsg);
                return;
            }
            this.DataSource = null;//清空数据源
            this.FormColse();

        }

        private void tsbAudit_Click(object sender, EventArgs e)
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态不允许编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据。");
                return;
            }
            //校验权限
            DataSet dsSource = this.DataSource.Copy();
            if (this.tsbAudit.Text == _SendAuditText)
            {
                //如果是送审校验，则先判断权限
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
                if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("你没有编辑和新建生产任务单权限，所以无法送审核。");
                    return;
                }
                //先保存数据
                if (!this.Save(dsSource)) return;
                //是否可以送审
                if (this._PactCode != this.tbPactCode.Text)
                    this._PactCode = this.tbPactCode.Text;
                //校验是否可以送审
                if (!this.CompeletedConfirm()) return;
                dsSource.AcceptChanges();
            }
            DataRow dr = dsSource.Tables["Pact_Main"].DefaultView[0].Row;
            int iAuditState = dr["AuditState"].Equals(DBNull.Value) ? 0 : int.Parse(dr["AuditState"].ToString());
            SysSetting.AuditDetail.frmAuditDetail frmAudit = new SysSetting.AuditDetail.frmAuditDetail();
            frmAudit.AuditState = iAuditState;
            frmAudit.SendAuditDate = dr["AuditStateDate"];
            frmAudit.SendAuditerName = dr["AuditSenderName"].ToString();
            frmAudit.Module = (int)Common.MyEnums.Modules.PactManager;
            frmAudit.PrimaryValue = this._PactCode;
            frmAudit.SendAuditer = dr["AuditSender"].ToString();
            frmAudit.OnClicks += new SysSetting.AuditDetail.AuditDetailClickHandle(frmAudit_OnClicks);
            frmAudit.ShowDialog(this);
        }

        protected void frmAudit_OnClicks(SysSetting.AuditDetail.ButtonType button, List<Common.MyEntity.AuditItem> datasource, int iAuditState, ref bool closeForm)
        {
            if (SysSetting.AuditDetail.ButtonType.True == button)
            {
                #region 确认送审
                //校验窗体状态是否符合要求
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                    || this._PactCode.Length == 0)
                {
                    this.ShowMsg("请先保存数据，然后送审。");
                    return;
                }
                //执行送审操作
                int iReturn = 1;
                string sMsg = string.Empty;
                try
                {
                    this.BllDAL.SendAudit(this._PactCode, Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, datasource, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    //return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "送审不成功，但原因未明确，您可以联系管理员查明原因。";
                    this.ShowMsg(sMsg);
                    //return;
                }
                this.BindData(this._PactCode.ToString());
                #endregion
            }
            else if (SysSetting.AuditDetail.ButtonType.PassAudit == button)
            {
                #region 跳过审核
                //校验窗体状态是否符合要求
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                    || this._PactCode.Length == 0)
                {
                    this.ShowMsg("请先保存数据，然后送审。");
                    return;
                }
                //校验权限，送审权限：模块编辑
                //先校验权限
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager, this._PactCode);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("你没有编辑权限，所以无法送审。");
                    return;
                }
                //执行送审操作
                int iReturn;
                string sMsg;
                try
                {
                    this.BllDAL.PassAudit(this._PactCode, Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "送审不成功，但原因未明确，您可以联系管理员查明原因。";
                    this.ShowMsg(sMsg);
                    return;
                }
                this.BindData(this._PactCode.ToString());
                #endregion
            }
            else if (SysSetting.AuditDetail.ButtonType.CancelSend == button)
            {
                #region 撤销送审
                //校验窗体状态是否符合要求
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy
                    || this._PactCode.Length == 0)
                {
                    this.ShowMsg("窗体加载状态与任务单实际状态不符，请重新加载任务单。");
                    return;
                }
                //校验权限，送审权限：模块编辑
                //先校验权限
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager, this._PactCode);
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("你没有编辑权限，所以无法撤销送审。");
                    return;
                }
                //判读是否已经有人做出评审了，如果已经有人做出评审要提示用户
                DataTable dtAudited = null;
                try
                {
                    dtAudited = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT AuditState,AuditerName,AuditDate FROM Common_ModuleAuditDetail WHERE PrimaryKeyValue='{0}' AND ModuleCode=(SELECT TOP 1 ModuleCode FROM Sys_Module WHERE EnumNo={1}) ORDER BY SortID DESC", this._PactCode, (int)Common.MyEnums.Modules.PactManager), true);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                string sAuditedMsg = string.Empty;
                int iAuditedstate = 0;
                foreach (DataRowView drv in dtAudited.DefaultView)
                {
                    iAuditedstate = drv.Row["AuditState"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["AuditState"].ToString());
                    if (iAuditedstate != 0)
                    {
                        //此时表示已经有人做出审批了
                        sAuditedMsg = string.Format("生产订单“{0}”已经由{1}于{2}审批过，状态为“{3}”,您确定要继续撤销审核吗？\r\n确认撤销审批，请按Yes\r\n不撤销审批，请按No", this._PactCode, drv.Row["AuditerName"],
                            Common.CommonFuns.FormatData.GetStringByDateTime(drv.Row["AuditDate"], "yyyy-MM-dd HH:mm:ss"), (iAuditedstate == 1 ? "通过" : "不通过"));
                        break;
                    }
                }
                if (sAuditedMsg.Length > 0)
                {
                    if (DialogResult.Yes != MessageBox.Show(this, sAuditedMsg, "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        return;
                }
                //执行送审操作
                int iReturn;
                string sMsg;
                try
                {
                    this.BllDAL.CancelAudit(this._PactCode, Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "撤销审批不成功，但原因未明确，您可以联系管理员查明原因。";
                    this.ShowMsg(sMsg);
                    return;
                }
                this.BindData(this._PactCode.ToString());
                #endregion
            }
            else if (SysSetting.AuditDetail.ButtonType.Audit == button)
            {
                #region 执行审核
                //校验窗体状态是否符合要求
                if (this._PactCode.Length == 0)
                {
                    this.ShowMsg("对不起，由于窗体状态与任务单实际状态不符合，您的审批操作无法保存。\r\n您可以试着重新打开任务单，执行审批操作,也可以联系管理员以便查明问题原因。");
                    return;
                }
                //执行送审操作
                int iReturn;
                string sMsg;
                try
                {
                    this.BllDAL.Auditing(this._PactCode, datasource, iAuditState, Common.CurrentUserInfo.UserCode, Common.CurrentUserInfo.UserName, out iReturn, out sMsg);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturn != 1)
                {
                    if (sMsg.Length == 0)
                        sMsg = "审批不成功，但原因未明确，您可以联系管理员查明原因。";
                    this.ShowMsg(sMsg);
                    return;
                }
                this.BindData(this._PactCode.ToString());
                #endregion
            }
            closeForm = true;
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        private void 终止当前光纤生产订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int iReturnValue = -1;
            string sMsg = string.Empty;
            try
            {
                this.BllDAL.PactStop(this._PactCode, Common.CurrentUserInfo.UserCode,
                    Common.CurrentUserInfo.UserName, out iReturnValue, out sMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (sMsg.Length == 0)
                    sMsg = "操作失败，原因未知。";
                this.ShowMsg(sMsg);
                return;
            }
            this.ShowMsgRich1("终止任务成功");
            return;
        }
        private void 终止选中任务明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iReturnValue = -1;
            string sMsg = string.Empty;
            try
            {
                this.BllDAL.PactStopCancel(this._PactCode, Common.CurrentUserInfo.UserCode,
                    Common.CurrentUserInfo.UserName, out iReturnValue, out sMsg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (sMsg.Length == 0)
                    sMsg = "操作失败，原因未知。";
                this.ShowMsg(sMsg);
                return;
            }
            this.ShowMsgRich1("终止任务成功");
            return;
        }
        #endregion
        #region 审核相关
        #endregion
        #region 扩展应用
        #endregion
        #region 明细操作
        private void tsbdAdd_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("明细数据的数据源丢失！");
                return;
            }
            //if (!dt.Columns["ID"].AutoIncrement)
            //    dt.Columns["ID"].AutoIncrement = true;
            if (string.Compare(dt.DefaultView.Sort, "SortID ASC", true) != 0)
                dt.DefaultView.Sort = "SortID ASC";
            frmPactDetail frm = new frmPactDetail();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._Data == null || frm._Data.GUID == null || frm._Data.GUID.ToString().Length == 0) return;
            //获取最大排序数
            int iSortID;
            if (dt.DefaultView.Count == 0) iSortID = 1;
            else
            {
                iSortID = int.Parse(dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"].ToString()) + 1;
            }
            //添加数据
            string strGuid = this.GetGUID();
            DataRow drNew = dt.NewRow();
            drNew["GUID"] = strGuid;
            drNew["PactCode"] = this._PactCode;
            drNew["BOMGuid"] = frm._Data.BOMGuid;
            drNew["BomSpec"] = frm._Data.BomSpec;
            drNew["FenCode"] = frm._Data.FenCode;
            drNew["FenCodeName"] = frm._Data.FenCodeName;
            // drNew["CompeletedQty"] = frm._Data.CompeletedQty;
            drNew["Qty"] = frm._Data.Qty;
            drNew["DeliveryDate"] = frm._Data.DeliveryDate;
            drNew["Remark"] = frm._Data.Remark;
            drNew["SortID"] = iSortID;
            drNew["VersionDesc"] = frm._Data.VersionDesc;
            dt.Rows.Add(drNew);
            
            CalculaterFiberTotalLen();
        }

        private void tsbdCopy_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("明细数据的数据源丢失！");
                return;
            }
            if (this.dgvDetail.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中要复制的行！");
                return;
            }
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("每次只能选中一行数据！");
                return;
            }
            DataRow drSelected = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row;
            if (string.Compare(dt.DefaultView.Sort, "SortID ASC", true) != 0)
                dt.DefaultView.Sort = "SortID ASC";
           
            frmPactDetail frm = new frmPactDetail();
            frmPactDetail.PactDetailEntity data = new frmPactDetail.PactDetailEntity();
            data.ReadFromDataRow(drSelected);
            frm._Data = data;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._Data == null || frm._Data.GUID == null || frm._Data.GUID.ToString().Length == 0) return;
            //获取最大排序数
            int iSortID;
            if (dt.DefaultView.Count == 0) iSortID = 1;
            else
            {
                iSortID = int.Parse(dt.DefaultView[dt.DefaultView.Count - 1].Row["SortID"].ToString()) + 1;
            }
            //添加数据
            string strGuid = this.GetGUID();
            DataRow drNew = dt.NewRow();
            drNew["GUID"] = strGuid;
            drNew["PactCode"] = this._PactCode;
            drNew["BOMGuid"] = frm._Data.BOMGuid;
            drNew["BomSpec"] = frm._Data.BomSpec;
            drNew["Qty"] = frm._Data.Qty;
            drNew["DeliveryDate"] = frm._Data.DeliveryDate;
            drNew["Remark"] = frm._Data.Remark;
            drNew["SortID"] = iSortID;
            dt.Rows.Add(drNew);
            CalculaterFiberTotalLen();
        }

        private void tsbdEdit_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("明细数据的数据源丢失！");
                return;
            }

            if (this.dgvDetail.SelectedRows.Count == 0)
            {
                this.ShowMsg("请选中要复制的行！");
                return;
            }
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("每次只能选中一行数据！");
                return;
            }
            DataRow drSelected = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row;
           
            //if (string.Compare(dt.DefaultView.Sort, "SortID ASC", true) != 0)
            //    dt.DefaultView.Sort = "SortID ASC";
            frmPactDetail frm = new frmPactDetail();
            frmPactDetail.PactDetailEntity data = new frmPactDetail.PactDetailEntity();
            data.ReadFromDataRow(drSelected);
            frm._Data = data;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._Data == null || frm._Data.GUID == null || frm._Data.GUID.ToString().Length == 0) return;

            if (drSelected["BOMGuid"].ToString() != frm._Data.BOMGuid.ToString())
                drSelected["BOMGuid"] = frm._Data.BOMGuid.ToString();
            if (drSelected["BomSpec"].ToString() != frm._Data.BomSpec.ToString())
                drSelected["BomSpec"] = frm._Data.BomSpec;
            if (drSelected["Qty"].ToString() != frm._Data.Qty.ToString())
                drSelected["Qty"] = frm._Data.Qty;
            if (drSelected["VersionDesc"].ToString() != frm._Data.VersionDesc.ToString())
                drSelected["VersionDesc"] = frm._Data.VersionDesc;
            //if (drSelected["CompeletedLen"].Equals(frm._Data.CompeletedLen))完成量是在审批合格后才能自动赋值的，但当前编辑操作肯定是送审前
            //    drSelected["CompeletedLen"] = frm._Data.CompeletedLen;
            if (drSelected["FenCode"].ToString() != frm._Data.FenCode.ToString())
                drSelected["FenCode"] = frm._Data.FenCode.ToString();
            if (drSelected["FenCodeName"].ToString() != frm._Data.FenCodeName.ToString())
                drSelected["FenCodeName"] = frm._Data.FenCodeName.ToString();
            if (!drSelected["DeliveryDate"].Equals(frm._Data.DeliveryDate))
                drSelected["DeliveryDate"] = frm._Data.DeliveryDate;
            if (drSelected["Remark"].ToString() != frm._Data.Remark.ToString())
                drSelected["Remark"] = frm._Data.Remark;
            CalculaterFiberTotalLen();
        }

        private void tsbdRemove_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            if (dt == null)
            {
                this.ShowMsg("明细数据的数据源丢失！");
                return;
            }
            List<string> listGuid = new List<string>();
            List<int> listRows = Common.CommonFuns.GetSelectedRows(this.dgvDetail);
            if (listRows.Count == 0)
            {
                this.ShowMsg("请至少选中一行数据！");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中的" + listRows.Count.ToString() + "行数据吗？")) return;
            foreach (int row in listRows)
            {
                listGuid.Add(dt.DefaultView[row].Row["GUID"].ToString());
            }
            DataRow[] drs;
            foreach (string sGuid in listGuid)
            {
                drs = dt.Select("GUID='" + sGuid + "'");
                if (drs.Length > 0) drs[0].Delete();
                
            }

            CalculaterFiberTotalLen();
        }

        private void tsbdUp_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            Common.CommonFuns.DataGridViewRowUp(this.dgvDetail, "SortID");
        }

        private void tsbdDown_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                return;
            }
            if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态不能编辑！");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，操作失败！");
                return;
            }
            Common.CommonFuns.DataGridViewRowDown(this.dgvDetail, "SortID");
        }
        #endregion

        #region 明细数据修改

        #endregion
        #region 窗体加载
        private void frmPact_Load(object sender, EventArgs e)
        {
            if (!this.Perinit() || !this.BindData(this._PactCode))
            {
                this.FormState = FormStates.None;
            }
        }
        #endregion
        #region 客户和公司工具
        private void linkCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态不允许编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据。");
                return;
            }
            BasicData.Company.frmSelectCompany frm = new BasicData.Company.frmSelectCompany();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            BasicData.Company.frmSelectCompany.SelectedCompanyInfo entity = frm.SelectedData[0];
            DataRow dr = this.DataSource.Tables["Pact_Main"].DefaultView[0].Row;
            DataRow drExp = this.DataSource.Tables["Pact_MainExp"].DefaultView[0].Row;
            if (dr["ComCode"].ToString() != entity.Code.ToString())
                dr["ComCode"] = entity.Code;
            if (drExp["ComVirCode"].ToString() != entity.VirCode.ToString())
                drExp["ComVirCode"] = entity.VirCode;
            if (drExp["ComCNName"].ToString() != entity.CNName.ToString())
                drExp["ComCNName"] = entity.CNName;
            if (drExp["ComENName"].ToString() != entity.ENName.ToString())
                drExp["ComENName"] = entity.ENName;
            if (drExp["ComShortName"].ToString() != entity.ShortName.ToString())
                drExp["ComShortName"] = entity.ShortName;
            if (drExp["ComTels"].ToString() != entity.Tels.ToString())
                drExp["ComTels"] = entity.Tels;
            if (drExp["ComFaxs"].ToString() != entity.Faxs.ToString())
                drExp["ComFaxs"] = entity.Faxs;
            if (drExp["ComAddress"].ToString() != entity.Address.ToString())
                drExp["ComAddress"] = entity.Address;
            ComVirCode = entity.VirCode.ToString();
            this.tbComName.Text = entity.CNName.ToString();
            this.tbComAddress.Text = entity.Address.ToString();
        }

        private void linkClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New && this.FormState != FormStates.Copy)
            {
                this.ShowMsg("当前窗体状态不允许编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据。");
                return;
            }
            BasicData.Client.frmSelectClient frm = new BasicData.Client.frmSelectClient();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            BasicData.Client.frmSelectClient.SelectedClientInfo entity = frm.SelectedData[0];
            DataRow dr = this.DataSource.Tables["Pact_Main"].DefaultView[0].Row;
            DataRow drExp = this.DataSource.Tables["Pact_MainExp"].DefaultView[0].Row;
            if (dr["ClientCode"].ToString() != entity.Code.ToString())
                dr["ClientCode"] = entity.Code;
            if (drExp["ClientVirCode"].ToString() != entity.VirCode.ToString())
                drExp["ClientVirCode"] = entity.VirCode;
            if (drExp["ClientCNName"].ToString() != entity.CNName.ToString())
                drExp["ClientCNName"] = entity.CNName;
            if (drExp["ClientENName"].ToString() != entity.ENName.ToString())
                drExp["ClientENName"] = entity.ENName;
            if (drExp["ClientShortName"].ToString() != entity.ShortName.ToString())
                drExp["ClientShortName"] = entity.ShortName;
            if (drExp["ClientTels"].ToString() != entity.Tels.ToString())
                drExp["ClientTels"] = entity.Tels;
            if (drExp["ClientFaxs"].ToString() != entity.Faxs.ToString())
                drExp["ClientFaxs"] = entity.Faxs;
            if (drExp["ClientAddress"].ToString() != entity.Address.ToString())
                drExp["ClientAddress"] = entity.Address;
            this.tbClientName.Text = entity.VirCode.ToString();
            this.tbClientAddress.Text = entity.Address.ToString();
            
        }
        #endregion
        #region 明细工具栏按钮
        private void 调整交货期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyDate frm = new frmModifyDate();
            frm.PactDetailGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            if (!this.BindData(this._PactCode))
                return;
        }

        private void 终止明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyState frm = new frmModifyState();
            frm.PactDetailGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            if (!this.BindData(this._PactCode))
                return;
        }

        private void 撤销终止明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 编辑备注ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyRemark frm = new frmModifyRemark();
            frm.PactDetailGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            if (!this.BindData(this._PactCode))
                return;
        }

        private void 修改任务数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyDetail frm = new frmModifyDetail();
            frm.PactDetailGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            if (!this.BindData(this._PactCode))
                return;
        }

        private void 修改工艺数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetail.SelectedRows.Count == 0) return;
            if (this.dgvDetail.SelectedRows.Count > 1)
            {
                this.ShowMsg("此操作每次只限一行。");
                return;
            }
            DataTable dt = this.dgvDetail.DataSource as DataTable;
            string strGuid = dt.DefaultView[this.dgvDetail.SelectedRows[0].Index].Row["GUID"].ToString();
            frmModifyBOM frm = new frmModifyBOM();
            frm.PactDetailGuid = strGuid;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            //加载数据
            if (!this.BindData(this._PactCode))
                return;

        }

        private void 查看订单光纤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PactManager);
            if (!listPower.Contains(OperatePower.Eidt))
            {
                this.ShowMsg("你没有计划的编辑权限。");
                return;
            }
            LuoLiuMES.PlanM.frmPlanSimpleEdit frm = new PlanM.frmPlanSimpleEdit();
            frm.PactCode = this._PactCode;
            frm.ShowDialog(this);
        }

        private void 任务明细生产顺序统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void comPackYear_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            int iAsc;
            iAsc = (int)e.KeyChar;
            if((iAsc<48 || iAsc>57 )&& iAsc!=8)
            {
                e.Handled = true;
            }

            if (iAsc >= 65280 && iAsc <= 65375)
            {
                iAsc -= 65248;
                Char ch = (Char)iAsc;
                e.KeyChar = ch;
            }
            else if (iAsc == 12288)
                e.KeyChar = (char)(32);
            if ((int)e.KeyChar >= 97 && (int)e.KeyChar <= 122)
            {
                e.KeyChar = (char)((int)e.KeyChar - 32);
            }
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flag)
            {
                List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower((int)Common.MyEnums.Modules.PactManager);
                if (!listPower.Contains(Common.MyEnums.OperatePower.New) && !listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("你没有新建或编辑的权限，如有需要请联系管理员开放该权限。");
                    return;
                }
                if (this.FormState == FormStates.Readonly || this.FormState == FormStates.None)
                {
                    this.ShowMsg("当前窗口状态不能编辑！");
                    return;
                }
                if (this.DataSource == null)
                {
                    this.ShowMsg("数据源丢失，操作失败！");
                    return;
                }
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
                DataTable dt = this.dgvDetail.DataSource as DataTable;
                if (dt == null)
                {
                    this.ShowMsg("明细数据的数据源丢失！");
                    return;
                }


                if (this.dgvDetail.SelectedRows.Count > 1)
                {
                    this.ShowMsg("每次只能选中一行数据！");
                    return;
                }

                DataRow drSelected = dt.DefaultView[e.RowIndex].Row;
                frmPactDetail frm = new frmPactDetail();
                frmPactDetail.PactDetailEntity data = new frmPactDetail.PactDetailEntity();
                data.ReadFromDataRow(drSelected);
                frm._Data = data;
                if (DialogResult.OK != frm.ShowDialog(this)) return;
                if (frm._Data == null || frm._Data.GUID == null || frm._Data.GUID.ToString().Length == 0) return;

                if (drSelected["BOMGuid"].ToString() != frm._Data.BOMGuid.ToString())
                    drSelected["BOMGuid"] = frm._Data.BOMGuid.ToString();
                if (drSelected["BomSpec"].ToString() != frm._Data.BomSpec.ToString())
                    drSelected["BomSpec"] = frm._Data.BomSpec;
                if (drSelected["Qty"].ToString() != frm._Data.Qty.ToString())
                    drSelected["Qty"] = frm._Data.Qty;
                if (!drSelected["DeliveryDate"].Equals(frm._Data.DeliveryDate))
                    drSelected["DeliveryDate"] = frm._Data.DeliveryDate;
                if (drSelected["VersionDesc"].ToString() != frm._Data.VersionDesc.ToString())
                    drSelected["VersionDesc"] = frm._Data.VersionDesc;
                CalculaterFiberTotalLen();
            }
           
        }
        #endregion


    }
}
