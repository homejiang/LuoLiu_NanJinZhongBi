using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicData.BOM
{
    public partial class frmMuKuai : BOM.frmBOM
    {
        string _Guid = string.Empty;
        /// <summary>
        /// 当新增时务必传入该字段值
        /// </summary>
        public string _ClassCode = BasicEntitys.SysDefaultValues.SysBOMProductClass.MuKuai;
        string _UnitCode = string.Empty;
        public frmMuKuai(string sGuid)
        {
            InitializeComponent();
            this._Guid = sGuid;
            this.ucEditFile1.OnRenameFile += new Common.UserControls.UCEditFileRenameHandler(this.ucEditFile1_OnRenameFile);
            this.ucEditFile1.OnOpenFile += new Common.UserControls.UCEditFileOpenHandler(this.ucEditFile1_OnOpenFile);
            this.ucEditFile1.OnDownloadFile += new Common.UserControls.UCEditFileDownLoadHandler(this.ucEditFile1_OnDownloadFile);
            this.ucEditFile1.OnPropertityFile += new Common.UserControls.UCEditFilePropertityHandler(this.ucEditFile1_OnPropertityFile);
            this.ucEditFile1.OnUploadFile += new Common.UserControls.UCEditFileUploadHandler(this.ucEditFile1_OnUploadFile);
            this.ucEditFile1.OnMoveFile += new Common.UserControls.UCEditFileMoveHandler(this.ucEditFile1_OnMoveFile);
            this.ucEditFile1.OnDelFile += new Common.UserControls.UCEditFileDelHandler(this.ucEditFile1_OnDelFile);
            this.tbClaName.Text = this.GetClassName(BasicEntitys.SysDefaultValues.SysBOMProductClass.MuKuai);
            this.ucBOMVersion1._SFGClass = BasicEntitys.SysDefaultValues.SysBOMProductClass.MuKuai;
        }
        #region 处理函数
        private bool Perinit()
        {
            this.dgvMaterial.AutoGenerateColumns = false;
            this.dgvSFG.AutoGenerateColumns = false;
            this.listProcess.DisplayMember = "Text";
            return true;
        }

        #endregion
        #region 加载数据
        private void BindData()
        {
            if (!this.Binding())
            {
                this.FormState = Common.MyEnums.FormStates.None;
                this.tsbSave.Enabled = false;
            }
            else
            {
                this.tsbSave.Enabled = true;
            }
            if(this.FormState==Common.MyEnums.FormStates.Copy)
            {
                this._Guid = string.Empty;
                this.FormState = Common.MyEnums.FormStates.New;
            }
            if(this._Guid.Length==0)
            {
                this.ucEditFile1.Enabled = false;
                this.tsbProcessAdd.Enabled = false;
                this.tsbProcessInsert.Enabled = false;
                this.tsbProcessDel.Enabled = false;
                this.tsbMAdd.Enabled = false;
                this.tsbMRemove.Enabled = false;
                this.tsbSFGAdd.Enabled = false;
                this.tsbSFGRemove.Enabled = false;
                this.tsbSFGUp.Enabled = false;
                this.tsbSFGDown.Enabled = false;
                this.tsbCopy.Enabled = false;
                this.tsbNew.Enabled = false;
            }
            else
            {
                this.ucEditFile1.Enabled = true;
                this.tsbProcessAdd.Enabled = true;
                this.tsbProcessInsert.Enabled = true;
                this.tsbProcessDel.Enabled = true;
                this.tsbMAdd.Enabled = true;
                this.tsbMRemove.Enabled = true;
                this.tsbSFGAdd.Enabled = true;
                this.tsbSFGRemove.Enabled = true;
                this.tsbSFGUp.Enabled = true;
                this.tsbSFGDown.Enabled = true;
                this.tsbCopy.Enabled = true;
                this.tsbNew.Enabled = true;
            }
        }
        private bool Binding()
        {
            if(this._Guid.Length==0)
            {
                //是为新增，则直接将窗口数清空即可
                this.InitFormData();
            }
            else
            {
                if(!this.BindMain(this._Guid) ||
                    !this.BindProcess(this._Guid) ||
                    !this.BindMaterial(this._Guid) ||
                    !this.BindSFG(this._Guid) || 
                    !this.BindPics(this._Guid))
                {
                    return false;
                }
            }
            return true;
        }
        private void InitFormData()
        {
            this.tbSpec.Clear();
            this.tbCreateInfo.Text = Common.CurrentUserInfo.UserName;
            this.tbRemark.Clear();
            this.tbModifyInfo.Clear();
            this.chkTerminated.Checked = true;
            this.numPerKg.Clear();
            this.numLength.Clear();
            this.numWidth.Clear();
            this.numHei.Clear();
            this.numDxCount.Clear();
            this.dgvMaterial.DataSource = null;
            this.dgvSFG.DataSource = null;
            this.listProcess.Items.Clear();
            this.BindPics(string.Empty);
        }
        private bool BindMain(string sGuid)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_BOM_Product WHERE GUID='{0}'", sGuid.Replace("'", "''")), "BOM_Product", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM BOM_Product_Structure WHERE ProGuid='{0}'", sGuid.Replace("'", "''")), "BOM_Product_Structure", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (ds.Tables["BOM_Product"].DefaultView.Count == 0)
            {
                this.ShowMsg("传入的BOM不存在或已经被删除！");
                return false;
            }
            DataRow dr = ds.Tables["BOM_Product"].DefaultView[0].Row;
            this.ucBOMVersion1.Bind(dr["VersionID"], dr["ClassCode"].ToString());
            this.tbSpec.Text = dr["Spec"].ToString();
            this.tbUnit.Text = dr["UnitName"].ToString();
            this.tbClaName.Text = dr["ClassName"].ToString();
            this.tbCreateInfo.Text = dr["CreaterName"].ToString();
            this.tbRemark.Text = dr["Remark"].ToString();
            if (dr["Modifier"].ToString().Length > 0)
                this.tbModifyInfo.Text = string.Format("{0}于{1}完成最后修改。", dr["ModifierName"], Common.CommonFuns.FormatData.GetStringByDateTime(dr["ModifyTime"], "yyyy-MM-dd HH:mm"));
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            //绑定结构数据
            DataTable dtStructure = ds.Tables["BOM_Product_Structure"];
            this.numPerKg.Text = this.GetStruValueDecimal(dtStructure, BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid.PerKg, "#########0.######");
            this.numLength.Text = this.GetStruValueDecimal(dtStructure, BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Length,"#########0.######");
            this.numWidth.Text = this.GetStruValueDecimal(dtStructure, BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Width, "#########0.######");
            this.numHei.Text = this.GetStruValueDecimal(dtStructure, BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Height, "#########0.######");
            this.numDxCount.Text = this.GetStruValueInt(dtStructure, BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid.DxCnt);
            //绑定隐藏字段
            this._ClassCode = dr["ClassCode"].ToString();
            this._UnitCode = dr["UnitCode"].ToString();
            return true;
        }
        private bool BindProcess(string sGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select ROW_NUMBER() OVER(ORDER BY SortID ASC) AS RowIndex,ProcessName,ID,ProcessCode from V_BOM_Product_Process where ProGuid='{0}'", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.listProcess.Items.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                Common.MyEntity.ComboBoxItem item = new Common.MyEntity.ComboBoxItem();
                item.Value = dr["ID"].ToString();
                item.Text = string.Format("{0}、{1}", dr["RowIndex"], dr["ProcessName"]);
                this.listProcess.Items.Add(item);
            }
            //绑定原材料的
           /* string strProcess;
            Common.MyEntity.ComboBoxItem itemSeled = this.tscMProcess.ComboBox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(itemSeled!=null && itemSeled.Value!=null)
            {
                strProcess = itemSeled.Value.ToString();
            }
            else
            {
                strProcess = string.Empty;
            }
            this.tscMProcess.ComboBox.Items.Clear();
            int iSeledIndex=0;
            Common.MyEntity.ComboBoxItem itemNew = new Common.MyEntity.ComboBoxItem();
            itemNew.Tag = string.Empty;
            itemNew.Text = "所有工序";
            this.tscMProcess.ComboBox.Items.Add(itemNew);
            foreach (DataRow dr in dt.Rows)
            {
                itemNew = new Common.MyEntity.ComboBoxItem();
                itemNew.Tag = dr["ProcessCode"].ToString();
                itemNew.Text = dr["ProcessName"].ToString();
                if (string.Compare(strProcess, dr["ProcessCode"].ToString(), true) == 0)
                    iSeledIndex = this.tscMProcess.ComboBox.Items.Add(itemNew);
                else
                {
                    this.tscMProcess.ComboBox.Items.Add(itemNew);
                }
            }
            this.tscMProcess.ComboBox.SelectedIndex = iSeledIndex;
            */
            return true;
        }
        private bool BindMaterial(string sGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select * from V_BOM_Product_Material WHERE ProGuid='{0}' order by ProcessSort ASC,MaterialName ASC,Spec ASC,SupplierName ASC"
                    , sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvMaterial.DataSource = dt;
            return true;
        }
        private bool BindSFG(string sGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select * from [V_BOM_Product_SFG] where ProGuid='{0}'", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvSFG.DataSource = dt;
            return true;
        }
        private bool BindPics(string sGuid)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM BOM_Product_Files where ProGuid='{0}' AND FileType=1 ORDER BY SortID ASC", sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return true;
            }
            List<Common.UserControls.ucEditFile.FileEntity> list = new List<Common.UserControls.ucEditFile.FileEntity>();
            Common.UserControls.ucEditFile.FileEntity entity;
            foreach (DataRow dr in dt.Rows)
            {
                entity = new Common.UserControls.ucEditFile.FileEntity();
                entity.GUID = dr["GUID"].ToString();
                entity.SortID = int.Parse(dr["SortID"].ToString());
                entity.FileName = dr["FileName"].ToString();
                entity.FileExs = dr["FileExs"].ToString();
                entity.FileSize = dr["FileSize"].Equals(DBNull.Value) ? 0 : long.Parse(dr["FileSize"].ToString());
                entity.PreViewFileGuid = dr["PreViewFileGuid"].ToString();
                entity.EntityGuid = dr["EntityGuid"].ToString();
                entity.Creater = dr["Creater"].ToString();
                entity.CreaterName = dr["CreaterName"].ToString();
                entity.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
                entity.Remark = dr["Remark"].ToString();
                list.Add(entity);
            }
            this.ucEditFile1.BindFiles(list);
            return true;
        }
        #endregion
        #region 图片编辑
        private bool ucEditFile1_OnDelFile(string sGuid)
        {
            string strSql = string.Format(@"DELETE FROM BOM_Product_Files WHERE GUID='{0}'"
                , sGuid.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            BindPics(this._Guid);
            return true;
        }

        private bool ucEditFile1_OnDownloadFile(string sGuid)
        {
            return default(bool);
        }

        private bool ucEditFile1_OnMoveFile(string sGuid, bool isLeft)
        {
           
            int iReturnValue;
            string strMsg;
            try
            {
                if (isLeft)
                    this.BllDAL.PicMoveLeft(sGuid, out strMsg, out iReturnValue);
                else this.BllDAL.PicMoveRight(sGuid, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == "") strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return false;
            }
            BindPics(this._Guid);
            return true;
        }

        private bool ucEditFile1_OnOpenFile(string sGuid)
        {
            return default(bool);
        }

        private bool ucEditFile1_OnPropertityFile(string sGuid)
        {
            return default(bool);
        }

        private bool ucEditFile1_OnRenameFile(string sGuid, string sOrgName, string sNewName)
        {
            
            string strSql = string.Format(@"UPDATE BOM_Product_Files SET [FileName]='{0}' WHERE GUID='{1}'"
                , sNewName.Replace("'", "''"), sGuid.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            BindPics(this._Guid);
            return true;
        }

        private bool ucEditFile1_OnUploadFile(string sPreViewFile, string sFile, string sPreViewFileGuid, string sEntityGuid)
        {
            int iSortID;
            #region 获取最大SortID
            DataTable dtSortID;
            try
            {
                dtSortID = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MAX(SortID) AS SortID FROM BOM_Product_Files WHERE ProGuid='{0}'"
                    , this._Guid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dtSortID.Rows[0]["SortID"].Equals(DBNull.Value))
                iSortID = 0;
            else iSortID = int.Parse(dtSortID.Rows[0]["SortID"].ToString()) + 1;
            #endregion
            FileInfo file = new FileInfo(sFile);
            if (file == null) return false;
            string strFileName = file.Name;
            string strFileExs = file.Extension;
            long lSize = file.Length;
            string strGuid = Guid.NewGuid().ToString();
            /********
             * GUID
                ProGuid
                SortID
                FileType
                FileName
                FileExs
                FileSize
                PreViewFileGuid
                EntityGuid
                Terminated
                Creater
                CreaterName
                CreateTime
                Remark
             * ************/
            string strSql = string.Format(@"INSERT INTO BOM_Product_Files (GUID,ProGuid,SortID,FileType,FileName,FileExs,FileSize,PreViewFileGuid,EntityGuid,Creater,CreaterName,CreateTime)  values('{0}','{1}',{2},{3},'{4}','{5}',{6},'{7}','{8}','{9}','{10}',getdate())"
                , strGuid.Replace("'", "''"), this._Guid.Replace("'", "''"), iSortID, 1, strFileName.Replace("'", "''")
                , strFileExs.Replace("'", "''"), lSize, sPreViewFileGuid.Replace("'", "''"), sEntityGuid.Replace("'", "''")
                , Common.CurrentUserInfo.UserCode.Replace("'", "''"), Common.CurrentUserInfo.UserName.Replace("'", "''"));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            BindPics(this._Guid);
            return true;
        }
        #endregion
        #region 工序编辑

        private void tsbProcessAdd_Click(object sender, EventArgs e)
        {
            frmProcessAdd frm = new frmProcessAdd(this._Guid, -1);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            this.BindProcess(this._Guid);
        }

        private void tsbProcessInsert_Click(object sender, EventArgs e)
        {
            if(this.listProcess.SelectedIndex==-1)
            {
                this.ShowMsg("请选中要插入的位置。");
                return;
            }
            Common.MyEntity.ComboBoxItem item = this.listProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(item==null)
            {
                this.ShowMsg("请选中要插入的位置!");
                return;
            }
            if (item.Value == null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("您选中的行ID为空！");
                return;
            }
            long lID;
            if(!long.TryParse(item.Value.ToString(),out lID))
            {
                this.ShowMsg(string.Format("您选中的行ID值“{0}”不是有效的整型！",item.Value.ToString()));
                return;
            }
            frmProcessAdd frm = new frmProcessAdd(this._Guid, lID);
            if (frm.ShowDialog(this) != DialogResult.OK)
                return;
            this.BindProcess(this._Guid);
        }
        private void tsbProcessDel_Click(object sender, EventArgs e)
        {
            if (this.listProcess.SelectedIndex == -1)
            {
                this.ShowMsg("请选中要移除的工序。");
                return;
            }
            Common.MyEntity.ComboBoxItem item = this.listProcess.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null)
            {
                this.ShowMsg("请选中要移除的工序!");
                return;
            }
            if (item.Value == null || item.Value.ToString().Length == 0)
            {
                this.ShowMsg("您选中的行ID为空！");
                return;
            }
            long lID;
            if (!long.TryParse(item.Value.ToString(), out lID))
            {
                this.ShowMsg(string.Format("您选中的行ID值“{0}”不是有效的整型！", item.Value.ToString()));
                return;
            }
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.ProcessDel(this._Guid, lID, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0) strMsg = "操作失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.BindData();
        }

        #endregion
        #region 原材料编辑
        private void tsbMAdd_Click(object sender, EventArgs e)
        {
            frmMaterialAdd frm = new frmMaterialAdd(this._Guid);
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this.BindMaterial(this._Guid);
        }

        private void tsbMRemove_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dgvMaterial.DataSource as DataTable;
            if (dt == null) return;
            List<int> list = Common.CommonFuns.GetSelectedRows(this.dgvMaterial);
            if(list.Count==0)
            {
                this.ShowMsg("请选中要删除的行！");
                return;
            }
            if (!this.IsUserConfirm("您确定要移除选中的行吗？")) return;
            int iReturnValue;
            string strMsg;
            DataRow dr;
            bool blUpdated = false;
            foreach(int row in list)
            {
                dr = dt.DefaultView[row].Row;
                try
                {
                    this.BllDAL.MaterialRemove(this._Guid, dr["GUID"].ToString(), out strMsg, out iReturnValue);
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    continue;
                }
                if(iReturnValue!=1)
                {
                    if (strMsg.Length == 0)
                        strMsg = "操作失败，原因未知！";
                    this.ShowMsg(strMsg);
                    continue;
                }
                if (!blUpdated) blUpdated = true;
            }
            if (blUpdated)
                this.BindMaterial(this._Guid);
        }
        #endregion
        #region 保存数据
        public DataSet GetDataSource(out string sErr)
        {
            sErr = string.Empty;
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM BOM_Product WHERE GUID='{0}'", this._Guid.Replace("'", "''")), "BOM_Product", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM BOM_Product_Structure WHERE ProGuid='{0}'", this._Guid.Replace("'", "''")), "BOM_Product_Structure", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                sErr = string.Format("加载数据源出错：{0}({1})", ex.Message, ex.Source);
                return null;
            }
            if (ds.Tables["BOM_Product"].DefaultView.Count == 0)
            {
                DataRow drNew = ds.Tables["BOM_Product"].NewRow();
                drNew["GUID"] = this.GetGUID(Common.MyEnums.Modules.None, string.Empty);
                drNew["ClassCode"] = BasicEntitys.SysDefaultValues.SysBOMProductClass.MuKuai;
                ds.Tables["BOM_Product"].Rows.Add(drNew);
            }
            return ds;
        }
        private bool ReadForm(DataSet dsSource)
        {
            DataRow dr = dsSource.Tables["BOM_Product"].DefaultView[0].Row;
            //if (string.Compare(this._ClassCode, dr["ClassCode"].ToString(), true) != 0)
            //    dr["ClassCode"] = this._ClassCode;
            if (string.Compare(this._UnitCode, dr["UnitCode"].ToString(), true) != 0)
                dr["UnitCode"] = this._UnitCode;
            if (!this.ucBOMVersion1.Check()) return false;
            if (!dr["VersionID"].Equals(this.ucBOMVersion1.ID))
                dr["VersionID"] = this.ucBOMVersion1.ID;
            if (dr["Spec"].ToString() != this.tbSpec.Text)
                dr["Spec"] = this.tbSpec.Text;
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text;
            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"]) ^ this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            //设置结构值
            //电芯总数
            this.SaveStruValue(dsSource.Tables["BOM_Product_Structure"], dr["GUID"].ToString(),BasicEntitys.SysDefaultValues.SysBomStruGuid.DxCnt
                , BasicData.BasicEntitys.SysDefaultValues.SysUnits.Ge, this.numDxCount.BindValue);
            //半成品高度
            this.SaveStruValue(dsSource.Tables["BOM_Product_Structure"], dr["GUID"].ToString(), BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Height
                , BasicData.BasicEntitys.SysDefaultValues.SysUnits.MM, this.numHei.BindValue);
            //半成品长度
            this.SaveStruValue(dsSource.Tables["BOM_Product_Structure"], dr["GUID"].ToString(), BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Length
                , BasicData.BasicEntitys.SysDefaultValues.SysUnits.MM, this.numLength.BindValue);
            //半成品宽度
            this.SaveStruValue(dsSource.Tables["BOM_Product_Structure"], dr["GUID"].ToString(), BasicEntitys.SysDefaultValues.SysBomStruGuid.MuKuai_Width
                , BasicData.BasicEntitys.SysDefaultValues.SysUnits.MM, this.numWidth.BindValue);
            //半成品净重
            this.SaveStruValue(dsSource.Tables["BOM_Product_Structure"], dr["GUID"].ToString(), BasicEntitys.SysDefaultValues.SysBomStruGuid.PerKg
                , BasicData.BasicEntitys.SysDefaultValues.SysUnits.MM, this.numPerKg.BindValue);
            if (dsSource.GetChanges() != null && dr["Creater"].ToString().Length > 0)
            {
                //此时需要登记最后修改信息
                if (dr["Modifier"].ToString() != Common.CurrentUserInfo.UserCode)
                    dr["Modifier"] = Common.CurrentUserInfo.UserCode;
                if (dr["ModifierName"].ToString() != Common.CurrentUserInfo.UserName)
                    dr["ModifierName"] = Common.CurrentUserInfo.UserName;
                DateTime detSer;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                    return false;
                dr["ModifyTime"] = detSer;
            }
            else
            {
                //登记创建人员
                if (dr["Creater"].ToString() != Common.CurrentUserInfo.UserCode)
                    dr["Creater"] = Common.CurrentUserInfo.UserCode;
                if (dr["CreaterName"].ToString() != Common.CurrentUserInfo.UserName)
                    dr["CreaterName"] = Common.CurrentUserInfo.UserName;
                DateTime detSer;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                    return false;
                dr["CreateTime"] = detSer;
            }
            return true;
        }
        private bool Save()
        {
            string strMsg;
            DataSet dsSource = this.GetDataSource(out strMsg);
            if (dsSource == null)
            {
                if (strMsg.Length == 0) strMsg = "操作出错，原因未知03！";
                this.ShowMsg(strMsg);
                return false;
            }
            if (!this.ReadForm(dsSource)) return false;
            try
            {
                this.BllDAL.SaveMain(dsSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this._Guid = dsSource.Tables["BOM_Product"].DefaultView[0].Row["GUID"].ToString();
            this.FormState = Common.MyEnums.FormStates.Edit;
            return true;
        }
        #endregion
        private void frmMuKuai_Load(object sender, EventArgs e)
        {
            Perinit();
            this.BindData();
        }

        private void tscMProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindMaterial(this._Guid);
        }

        private void tsbSFGAdd_Click(object sender, EventArgs e)
        {

        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(this.FormState==Common.MyEnums.FormStates.None)
            {
                this.ShowMsg("当前窗口状态无效！");
                return;
            }
            if (this.FormState == Common.MyEnums.FormStates.Readonly)
            {
                this.ShowMsg("当前窗口状态为只读！");
                return;
            }
            if(this.Save())
            {
                this.ShowMsgRich("保存成功");
                this.BindData();
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
           
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM);
            if (!listPower.Contains(Common.MyEnums.OperatePower.New))
            {
                this.ShowMsg("对不起您没有此模块的新增权限。");
                return;
            }
            this.BindData();
            if (this.FormState != Common.MyEnums.FormStates.None && this._Guid.Length==0)
            {
                this.ShowMsgRich("复制成功");
            }
        }
        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit) return;
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty) return;
            //校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.BOM);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("对不起您没有此模块的删除权限。");
                return;
            }
            if (!this.IsUserConfirm("您确定要删除选中的数据吗？")) return;
            string strMsg;
            int iReturnValue;
            try
            {
                this.BllDAL.Detele(this._Guid, out strMsg, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (iReturnValue != 1)
            {
                if (strMsg.Length == 0)
                    strMsg = "数据删除失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            this.ShowMsgRich("删除成功");
            this.FormColse(null, false);//不进行数据修改校验
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void linkUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.Unit.frmSelectUnit frm = new BasicData.Unit.frmSelectUnit();
            //frm.UnitType = BasicData.BasicEntitys.SysDefaultValues.SysUnitTypes.Length;//长度单位
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm.SelectedData.Count == 0) return;
            this.tbUnit.Text = frm.SelectedData[0].DefaultName.ToString();
            this._UnitCode = frm.SelectedData[0].Code.ToString();
        }

        private void tsbBOMParents_Click(object sender, EventArgs e)
        {
            string strMsg;
            DataSet dsSource = this.GetDataSource(out strMsg);
            if (dsSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            string sGuid = dsSource.Tables["BOM_Product"].DefaultView[0].Row["GUID"].ToString();
            BOM.frmParentBOM frm = new BasicData.BOM.frmParentBOM();
            frm.Text = string.Format("{0}的所有引用", dsSource.Tables["BOM_Product"].DefaultView[0].Row["Spec"]);
            frm._Spec = dsSource.Tables["BOM_Product"].DefaultView[0].Row["Spec"].ToString();
            frm.PrimaryValue = sGuid;
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsbBOMExp_Click(object sender, EventArgs e)
        {
            string strMsg;
            DataSet dsSource = this.GetDataSource(out strMsg);
            if (dsSource == null)
            {
                this.ShowMsg("数据源丢失。");
                return;
            }
            string sGuid = dsSource.Tables["BOM_Product"].DefaultView[0].Row["GUID"].ToString();
            BOM.frmBOMStructDetail frm = new BasicData.BOM.frmBOMStructDetail();
            frm.Text = string.Format("{0}的展开数据", dsSource.Tables["BOM_Product"].DefaultView[0].Row["Spec"]);
            frm.PrimaryValue = sGuid;
            this.ShowChildForm(frm.Text, frm);
        }

        private void tsbProcessNormal_Click(object sender, EventArgs e)
        {

        }
    }
}
