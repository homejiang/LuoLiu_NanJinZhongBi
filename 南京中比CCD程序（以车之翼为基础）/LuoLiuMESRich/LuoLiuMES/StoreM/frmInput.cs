using Common;
using Common.MyEnums;
using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES.StoreM
{
    public partial class frmInput : Common.frmBaseEdit
    {
        public frmInput()
        {
            InitializeComponent();
        }
        #region 常量信息
        const string _CompletedText = "结束本次入库";
        const string _CancelCompletedText = "撤销结束入库";
        #endregion
        #region 窗体数据连接实例
        private BLLDAL.PackInput _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PackInput BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new LuoLiuMES.BLLDAL.PackInput();
                return _dal;
            }
        }
        #endregion
        #region 重写函数
        #endregion
        #region 处理函数
        private void SaveComBoboxValue(DataRow dr, string sColumnName, System.Windows.Forms.ComboBox comBobox)
        {
            object objValue = GetComBoboxValue(comBobox);
            if (!dr[sColumnName].Equals(objValue))
                dr[sColumnName] = objValue;
        }
        private void ProRottweilErr(Exception ex)
        {
            ProRottweilErr(ex.Message);
        }
        private void ProRottweilErr(string sMsg)
        {
            //frmAPException.ShowAPException(sMsg);
            Common.CommonFuns.SendExceptionToMES(sMsg, "");
        }
        private bool Perinit()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT Code,StorageName FROM JC_SFGStorages where  ISNULL(Terminated,0)=0 order by Code", "JC_SFGStorages", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                ProRottweilErr(ex);
                return false;
            }
            this.comStorageDesc.DisplayMember = "Text";
            this.comStorageDesc.ValueMember = "Value";
            foreach (DataRow dr in ds.Tables["JC_SFGStorages"].Rows)
            {
                this.comStorageDesc.Items.Add(new Common.MyEntity.ComboBoxItem(dr["StorageName"].ToString(), dr["Code"].ToString()));
            }
            this.comStorageDesc.SelectedIndex = -1;
            this.dgvList.AutoGenerateColumns = true;
            return true;
        }
        private bool BindData(string sInputCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT * FROM PM_Pack_Input WHERE Code='" + sInputCode.Replace("'", "''") + "'";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "PM_Pack_Input", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dt = ds.Tables["PM_Pack_Input"];
            if (dt.DefaultView.Count == 0)
            {
                if (sInputCode.Length > 0)
                {
                    this.ShowMsg("入库单\"" + sInputCode + "\"不存在或已经被删除。");
                    return false;
                }
                #region 主表新增一行数据
                DataRow drNew = dt.NewRow();
                drNew["Code"] = this.GetAutoCode(Modules.InStorage);
                drNew["Creater"] = Common.CurrentUserInfo.UserCode;
                drNew["CreaterName"] = Common.CurrentUserInfo.UserName;
                DateTime detSer;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                    return false;
                drNew["CreateTime"] = detSer;
                dt.Rows.Add(drNew);
                #endregion
                this.FormState = FormStates.New;
                
            }
            //绑定数据
            DataRow dr = dt.DefaultView[0].Row;
            this.tbCode.Text = dr["Code"].ToString();
            this.tbCreater.Text = dr["CreaterName"].ToString();
            this.tbCreateTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateTime"], "yyyy-MM-dd HH:mm");
            this.tbTaker.Tag = dr["Taker"].ToString();
            this.tbTaker.Text = dr["TakerName"].ToString();
            Common.CommonFuns.FormatData.SetComboBoxText(this.comStorageDesc, new Common.MyEntity.ComboBoxItem("", dr["StorageCode"].ToString()), 0);
            this.tbRemark.Text = dr["Remark"].ToString();
            BindOutType("03");
            this.DataSource = ds;
            if (this.FormState != FormStates.New)
                this.BindDetailData(sInputCode);
            SetFormState(this.FormState, dr["State"].Equals(DBNull.Value) ? 0 : int.Parse(dr["State"].ToString()));
            return true;
        }
        private bool BindDetailData(string sInputCode)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
            string strSql = "EXEC PM_Pack_GetInputDetail_Cgy '" + sInputCode.Replace("'", "''") + "',1";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "PM_Pack_InputDetail", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = ds.Tables["PM_Pack_InputDetail"];
            foreach (DataGridViewColumn dgvc in this.dgvList.Columns)
            {
                if (string.Compare(dgvc.DataPropertyName, "PackCode", true) == 0)
                {
                    dgvc.Visible = false;
                }
                if (string.Compare(dgvc.DataPropertyName, "TypeCode", true) == 0)
                {
                    dgvc.Visible = false;
                }
            }
            return true;
        }
        private void SetFormState(FormStates state, int iState)
        {
            bool blFormState = state == FormStates.New || state == FormStates.Edit;
            this.tsbSave.Enabled = blFormState && iState != 1;
            this.tsbDelete.Enabled = state == FormStates.Edit && iState != 1;
            this.panel2.Enabled = state == FormStates.Edit && iState != 1;
            this.btAdd.Enabled = state == FormStates.Edit && iState != 1;
            this.btWenBen.Enabled = state == FormStates.Edit && iState != 1;
            this.btRemove.Enabled = state == FormStates.Edit && iState != 1;
            this.tsbPrint.Enabled = iState == 1;
            this.tsbInput.Enabled = iState == 1;
            this.tsbCompeleted.Text = iState == 1 ? _CancelCompletedText : _CompletedText;
            if (state == FormStates.New || state == FormStates.Copy)
            {
                this.ChangeWinTitle("新建产品入库单");
            }
            else if (state == FormStates.Edit)
            {
                this.ChangeWinTitle(string.Format("产品入库单-{0}", this.PrimaryValue));
            }
        }
        private object GetComboBoxValue(ComboBox combox)
        {
            if (combox.SelectedItem == null) return DBNull.Value;
            Common.MyEntity.ComboBoxItem item = combox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null) return DBNull.Value;
            return item.Value;
        }
        private object GetMaxStartPanID()
        {
            return DBNull.Value;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(StartPanID) FROM PM_Pack_Input"));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return DBNull.Value;
            }
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 1;
            else return long.Parse(dt.Rows[0][0].ToString()) + 1;
        }
        #endregion
        #region 保存数据
        public bool SaveCheck()
        {
            if (this.FormState != FormStates.Edit && this.FormState != FormStates.New)
            {
                this.ShowMsg("当前窗体状态不允许编辑。");
                return false;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失，请重新加载数据。");
                return false;
            }
            //检查必输入项
            if (this.tbCode.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入入库单号");
                this.tbCode.Focus();
                return false;
            }
            //校验是否已经存在重复
            if (this.FormState == FormStates.New ||
                (this.FormState == FormStates.Edit && this.tbCode.Text.Trim().ToLower() != this.PrimaryValue.ToString().ToLower()))
            {
                DataTable dtCheck;
                try
                {
                    dtCheck = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT COUNT(*) FROM PM_Pack_Input WHERE Code='{0}'", this.tbCode.Text.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                if ((int)dtCheck.Rows[0][0] > 0)
                {
                    this.ShowMsg(string.Format("入库单号\"{0}\"已经存在，请您更换。", this.tbCode.Text));
                    return false;
                }
            }
            return true;
        }
        private bool ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["PM_Pack_Input"].DefaultView[0].Row;
            if (dr["Code"].ToString() != this.tbCode.Text)
                dr["Code"] = this.tbCode.Text;
            string strTaker = this.tbTaker.Tag == null ? string.Empty : this.tbTaker.Tag.ToString();
            if (dr["Taker"].ToString() != strTaker)
            {
                dr["Taker"] = strTaker;
                dr["TakerName"] = this.tbTaker.Text;
            }
            this.SaveComBoboxValue(dr, "StorageCode", this.comStorageDesc);
            
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            return true;
        }
        private bool Save(DataSet dsSouce)
        {
            if (!this.ReadForm(dsSouce)) return false;
            if (dsSouce.GetChanges() == null) return true;//没有改变则直接返回真
            try
            {
                this.BllDAL.Save(dsSouce);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (this.FormState != FormStates.Edit)
            {
                this.FormState = FormStates.Edit;
                this.ChangeWinTitle("入库单" + this.tbCode.Text);
            }
            if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
                this.PrimaryValue = this.tbCode.Text;
            return true;
        }
        private bool InputPack(string sCableCode)
        {
            object objTarget = this.GetComBoboxValue(this.comStorageDesc);
            if (objTarget.ToString().Length == 0)
            {
                this.ShowMsg("请选择外卖产品仓库。");
                this.comStorageDesc.Focus();
                return false;
            }
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.InputPack(this.PrimaryValue.ToString(), this.tbPackCode.Text, objTarget.ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "入库失败，原因未知。";
                OpenBigMsgShine(strMsg);
                return false;
            }
            return true;
        }
        #endregion
        #region 窗体加载
        private void frmInput_Load(object sender, EventArgs e)
        {
            if (!this.Perinit())
            {
                this.FormState = FormStates.None;
                return;
            }
            if (!this.BindData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()))
            {
                this.FormState = FormStates.None;
                return;
            }
        }
        #endregion
        #region 按钮工具栏
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                OpenBigMsgShine("请先保存入库单。");
                return;
            }
            if (tbCode.Text == string.Empty) return;
            string strType = this.linkOuputType.Tag == null ? string.Empty : this.linkOuputType.Tag.ToString();
            //if (strType == "") strType = "3";
            if (this.InputPack(this.tbPackCode.Text, strType))
            {
                this.BindDetailData(this.PrimaryValue.ToString());
                this.tbPackCode.Clear();
                this.tbPackCode.Focus();
                //SetCodeFouce(true);
            }
            else
            {
                //SetCodeFouce(false);
                this.tbPackCode.SelectAll();
            }

            
          
        }
        private bool InputPack(string sPackCode,string strType)
        {
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.InputPack(this.PrimaryValue.ToString(),sPackCode, strType, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
            }
            if (iReturnValue == 1)
            {
                this.ShowMsg("保存成功。");
            }
            return true;

        }
        private void btWenBen_Click(object sender, EventArgs e)
        {
            object objTarget = this.GetComBoboxValue(this.comStorageDesc);
            if (objTarget.ToString().Length == 0)
            {
                this.ShowMsg("请选择外卖产品仓库。");
                this.comStorageDesc.Focus();
                return ;
            }
            Common.Codes.frmCodes frm1 = new Common.Codes.frmCodes();
            frm1.Text = "请输入产品编号，多个用回车分割。";
            frm1.TopMost = true;
            frm1.frmCodes_ProCode += new Common.Codes.ProCode(frm_frmCodes_ProCode);
            frm1.ShowDialog(this);
            this.BindDetailData(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }

        private void btInputPacks_Click(object sender, EventArgs e)
        {
            //if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            //{
            //    OpenBigMsgShine("请先保存入库单。");
            //    return;
            //}
            //int iSortID;
            //DataTable dt;
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(SortID) FROM PM_Pack_InputDetail WHERE OCode='{0}'", this.PrimaryValue.ToString().Replace("'", "''")));
            //}
            //catch (Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(this, ex);
            //    return;
            //}
            //if (dt.Rows[0][0].Equals(DBNull.Value)) iSortID = 1;
            //else iSortID = int.Parse(dt.Rows[0][0].ToString()) + 1;
            //long lStartPanID;
            //if (!long.TryParse(this.numStartPanID.Text, out lStartPanID))
            //    lStartPanID = 0;
            //frmFGInputInputPacks frm = new frmFGInputInputPacks();
            //frm._OCode = this.PrimaryValue.ToString();
            //frm._SortID = iSortID;
            //frm._StartPanID = lStartPanID;
            //frm.ShowDialog(this);
            //this.BindDetailData(this.PrimaryValue.ToString());
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                return;
            }
            int iReturnValue;
            string strMsg;
            int iRowIndex;
            string strCode;
            string strTypeCode;
            DataTable dtList = this.dgvList.DataSource as DataTable;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                iRowIndex = this.dgvList.SelectedRows[i].Index;
                strCode = dtList.DefaultView[iRowIndex].Row["PackCode"].ToString();
                strTypeCode = dtList.DefaultView[iRowIndex].Row["TypeCode"].ToString();
                if (strCode.Length == 0) return;
                try
                {
                    this.BllDAL.CancelInputPack(this.PrimaryValue.ToString(), strCode, strTypeCode, out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "入库失败，原因未知。";
                    ShowMsg(strMsg);
                    continue;
                }


            }
            this.BindDetailData(this.PrimaryValue.ToString());
            this.tbPackCode.Focus();
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
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.FormState != FormStates.New && this.FormState != FormStates.Edit)
            {
                this.ShowMsg("当前窗体不能编辑");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据。");
                return;
            }
            //如果是送审校验，则先判断权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.InStorage);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) && !listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("对不起，您没有该模块的新增或编辑权限。");
                return;
            }
            object objTarget = this.GetComBoboxValue(this.comStorageDesc);
            if (objTarget.ToString().Length == 0)
            {
                this.ShowMsg("请选择产品仓库。");
                this.comStorageDesc.Focus();
                return;
            }
            if (!this.SaveCheck()) return;
            if (this.Save(this.DataSource.Copy()))
            {
                this.ShowMsg("保存成功。");
                if (this.PrimaryValue == null || this.PrimaryValue.ToString() != this.tbCode.Text)
                    this.PrimaryValue = tbCode.Text;
                if (this.FormState == FormStates.New)
                {
                    this.FormState = FormStates.Edit;
                    //修改标题
                    this.ChangeWinTitle("入库单" + this.PrimaryValue.ToString());
                }
                if (!this.BindData(this.PrimaryValue.ToString()))
                    this.FormState = FormStates.None;
            }
        }

        private void tsbCompeleted_Click(object sender, EventArgs e)
        {
            if (this.FormState != FormStates.New && this.FormState != FormStates.Edit)
            {
                this.ShowMsg("当前窗体不能编辑");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据。");
                return;
            }
            //如果是送审校验，则先判断权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.InStorage);
            if (this.tsbCompeleted.Text == _CompletedText)
            {
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt) && !listPower.Contains(Common.MyEnums.OperatePower.New))
                {
                    this.ShowMsg("对不起，您没有该模块的新增或编辑权限。");
                    return;
                }
                if (!this.IsUserConfirm("您确定要结束本次入库吗？\r\n注：结束入库后后此入库单下不能再添加产品。")) return;
                if (!this.SaveCheck()) return;
                if (this.Save(this.DataSource.Copy()))
                {
                    if (this.Compeleted(this.tbCode.Text))
                    {
                        this.ShowMsg("操作成功。");
                    }
                    if (!this.BindData(this.tbCode.Text))
                        this.FormState = FormStates.None;
                }
            }
            else if (this.tsbCompeleted.Text == _CancelCompletedText)
            {
                if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
                {
                    return;
                }
                if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                {
                    this.ShowMsg("对不起，您没有该模块的编辑权限，不能撤销。");
                    return;
                }
                if (!this.IsUserConfirm("您确定要撤销吗？")) return;
                int iReturnValue;
                string strMsg;
                try
                {
                    this.BllDAL.CancelCompeleted(this.PrimaryValue.ToString(), out strMsg, out iReturnValue);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (iReturnValue != 1)
                {
                    if (strMsg == string.Empty)
                        strMsg = "操作失败，原因未知。";
                    this.ShowMsg(strMsg);
                    return;
                }
                if (!this.BindData(this.PrimaryValue.ToString()))
                    this.FormState = FormStates.None;
            }
        }
        private bool Compeleted(string sOCode)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.Compeleted(sOCode, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == string.Empty)
                    strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return false;
            }
            return true;
        }
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                return;
            }
            //如果是送审校验，则先判断权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.InStorage);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("对不起，您没有该模块的删除权限。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除此入库单吗？")) return;
            string strMsg;
            int ireturnValue;
            try
            {
                this.BllDAL.Delete(this.PrimaryValue.ToString(), out strMsg, out ireturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (ireturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "删除失败，原因未知。";
                ShowMsg(strMsg);
                return;
            }
            this.ShowMsg("删除成功。");
            this.FormColse(null, false);
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {

        }

        private void tsbInput_Click(object sender, EventArgs e)
        {
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                this.ShowMsg("请先保存数据。");
                return;
            }
            //List<object> listArg = new List<object>();
            //listArg.Add(this.PrimaryValue);
            Common.OutputExcel.frmOutputExcel.OutputExcel("FGInput", this.PrimaryValue.ToString());
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }
        #endregion
        private delegate void AddMsgCallback(string sMsg);
        private void ShowMsg(string sText)
        {
            this.richTextBox1.AppendText(sText + "\r\n");
        }
        private void AddMsg(string sText)
        {
            try
            {
                AddMsgCallback stcb = new AddMsgCallback(ShowMsg);
                this.Invoke(stcb, new object[1] { sText });
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void linktaker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SysSetting.DeptUsers.frmSelectUserSample frm = new SysSetting.DeptUsers.frmSelectUserSample();
            frm.SelectedUserCodes = this.tbTaker.Tag == null ? string.Empty : this.tbTaker.Tag.ToString();
            frm.MultiSelected = true;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.tbTaker.Tag = frm.SelectedUserCodes;
            this.tbTaker.Text = frm.SelectedUserNames.Replace("|", "、");
            while (this.tbTaker.Text.StartsWith("、"))
                this.tbTaker.Text = this.tbTaker.Text.Substring(1);
            while (this.tbTaker.Text.EndsWith("、"))
                this.tbTaker.Text = this.tbTaker.Text.Substring(0, tbTaker.Text.Length - 1);
        }
        protected bool frm_frmCodes_ProCode(string sCode, out bool isErrStop)
        {
             object objTarget = this.GetComBoboxValue(this.comStorageDesc);
            isErrStop = false;
            if (sCode == string.Empty) return true;
            string strType = this.linkOuputType.Tag == null ? string.Empty : this.linkOuputType.Tag.ToString();
            //执行数据
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.InputPack(this.PrimaryValue.ToString(), sCode, strType.ToString(), out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "入库失败，原因未知。";
                AddMsg(strMsg);
                return false;
            }
            return iReturnValue == 1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void linkOuputType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //frmInputType frm = new frmInputType();
            //if (DialogResult.OK != frm.ShowDialog(this))
            //    return;
            //BindOutType(frm._Type);
        }
        private void BindOutType(string iType)
        {
            if (iType == "01")
                this.linkOuputType.Text = " 模块编号";
            else if (iType == "02")
                this.linkOuputType.Text = "模组编号";
            else if (iType == "03")
                this.linkOuputType.Text = "电池包编号";
            else
                this.linkOuputType.Text = "未知类型";
            this.linkOuputType.Tag = iType;
        }
        
    }
}
