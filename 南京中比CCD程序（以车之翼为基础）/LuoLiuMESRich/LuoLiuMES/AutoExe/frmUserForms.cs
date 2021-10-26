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
    public partial class frmUserForms : Common.frmBaseEdit
    {
        public frmUserForms()
        {
            InitializeComponent();
        }
        #region ������������ʵ��
        private BLLDAL.AutoExe _dal = null;
        /// <summary>
        /// ������������ʵ��
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
        #region ��������
        public bool _YuDingYi = false;
        public string _UserCode = string.Empty;
        #endregion
        #region ������
        private bool Perinit()
        {
            this.listGroup.DisplayMember = "Text";
            this.listGroup.ValueMember = "Value";
            this.dgvForms.AutoGenerateColumns = false;
            this.labTooltip.Visible = !this._YuDingYi;
            this.chkDefault.Visible = !this._YuDingYi;
            this.Text = this._YuDingYi ? "Ԥ����Ӧ����Ʒ���" : "�û��Զ���Ӧ����Ʒ���";
            return true;
        }
        private bool BindDesign(string sGuid)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM AutoExe_User_Designs WHERE GUID='{0}'",
                sGuid.Replace("'", "''")), "AutoExe_User_Designs"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM AutoExe_User_Group WHERE DesignGuid='{0}' ORDER BY SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Group"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_AutoExe_User_Forms WHERE DesignGuid='{0}' ORDER BY SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Forms"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dtDesign = ds.Tables["AutoExe_User_Designs"];
            DataTable dtGroup = ds.Tables["AutoExe_User_Group"];
            DataTable dtForm = ds.Tables["AutoExe_User_Forms"];
            #region ������ͼ�ֶ�
            DataColumn dc= new DataColumn("UnderlineView", Type.GetType("System.String"));
            dc.Expression = "IIF(isnull(Underline,0)=1,'��','��')";
            dtForm.Columns.Add(dc);
            dc = new DataColumn("FontBoldView", Type.GetType("System.String"));
            dc.Expression = "IIF(isnull(FontBold,0)=1,'��','��')";
            dtForm.Columns.Add(dc);
            //����
            dtForm.Columns["ID"].AutoIncrement = true;
            #endregion
            if (dtDesign.DefaultView.Count == 0)
            {
                DataRow drNew = dtDesign.NewRow();
                drNew["GUID"] = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                DataTable dttemp;
                int itype = this._YuDingYi ? 2 : 1;
                try
                {
                    dttemp = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC AutoExe_User_GetNewDesgin '{0}',{1}",
                        this._UserCode.Replace("'", "''"), itype));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                drNew["DesignName"] = dttemp.Rows[0]["DesignName"];
                if (!this._YuDingYi)
                {
                    if (_UserCode == string.Empty)
                    {
                        this.ShowMsg("δ���������û�����������ϵ����Ա�Ա���������");
                        return false;
                    }
                    drNew["UserCode"] = this._UserCode;
                }
                dtDesign.Rows.Add(drNew);
            }
            this.DataSource = ds;
            DataRow drDesign = dtDesign.DefaultView[0].Row;
            this.tbDesignName.Text = drDesign["DesignName"].ToString();
            this.chkDefault.Checked = !drDesign["IsDefault"].Equals(DBNull.Value) && (bool)drDesign["IsDefault"];
            this.BindGroup(string.Empty, ds.Tables["AutoExe_User_Group"]);
            this.BindForm(string.Empty, ds.Tables["AutoExe_User_Forms"]);
            SetFormState(drDesign["UserCode"].ToString());
            return true;
        }
        private bool BindGroup(string sSelecedGuids,DataTable dtGroup)
        {
            if (sSelecedGuids != string.Empty)
                sSelecedGuids = "|" + sSelecedGuids + "|";
            this.listGroup.Items.Clear();
            DataRow dr;
            Common.MyEntity.ComboBoxItem group;
            for (int i = 0; i < dtGroup.DefaultView.Count; i++)
            {
                dr = dtGroup.DefaultView[i].Row;
                group = new Common.MyEntity.ComboBoxItem();
                group.Text = dr["GroupName"].ToString();
                group.Value = dr["GUID"].ToString();
                this.listGroup.Items.Add(group);
                if (sSelecedGuids != string.Empty)
                {
                    if (sSelecedGuids.IndexOf("|" + dr["GUID"].ToString() + "|") >= 0)
                        this.listGroup.SetSelected(i, true);
                }
            }
            return true;
        }
        private bool BindForm(string sSelectedIDs,DataTable dt)
        {
            string strGroup = string.Empty;
            if (this.listGroup.SelectedItem != null)
            {
                Common.MyEntity.ComboBoxItem item = this.listGroup.SelectedItem as Common.MyEntity.ComboBoxItem;
                if (item != null)
                    strGroup = item.Value.ToString();
            }
            if (strGroup == string.Empty)
                this.dgvForms.DataSource = dt;
            else
            {
                if (sSelectedIDs != string.Empty)
                    sSelectedIDs = "|" + sSelectedIDs + "|";
                DataRow[] drs = dt.Select("GroupGuid='" + strGroup + "'", "SortID ASC");
                DataTable dtForm = dt.Clone();
                dtForm.Columns["ID"].AutoIncrement = false;
                foreach (DataRow dr in drs)
                {
                    dtForm.Rows.Add(dr.ItemArray);
                }
                this.dgvForms.DataSource = dtForm;
                //����ѡ����
                for (int i = 0; i < dtForm.DefaultView.Count; i++)
                {
                    if (sSelectedIDs.IndexOf("|" + dtForm.DefaultView[i].Row["ID"].ToString() + "|") >= 0)
                        this.dgvForms.Rows[i].Selected = true;
                    else
                        this.dgvForms.Rows[i].Selected = false;
                }
            }
            return true;
        }
        private void SetFormState(string sDesignUserCode)
        {
            //���ô���ɱ༭�ԣ�ֻ�����û����Ա��Ȩ�ޱ༭
            bool blEdit = string.Compare(sDesignUserCode, Common.CurrentUserInfo.UserCode, true) == 0 || Common.CurrentUserInfo.IsSuper || Common.CurrentUserInfo.IsAdmin;
            toolStrip1.Enabled = blEdit;
            this.tsb2Add.Enabled = blEdit;
            this.tsb2Edit.Enabled = blEdit;
            this.tsb2Remove.Enabled = blEdit;
            this.tsb2Up.Enabled = blEdit;
            this.tsb2Down.Enabled = blEdit;
            this.btSave.Enabled = blEdit;
        }
        #endregion
        #region ��������
        private bool SaveCheck()
        {
            if (this.tbDesignName.Text == string.Empty)
            {
                this.ShowMsg("����д������������ơ���");
                return false;
            }
            return true;
        }
        private bool ReadForm(DataSet dsSource)
        {
            DataRow drDesign = dsSource.Tables["AutoExe_User_Designs"].DefaultView[0].Row;
            if (drDesign["DesignName"].ToString() != this.tbDesignName.Text)
                drDesign["DesignName"] = this.tbDesignName.Text;
            if (this._YuDingYi)
            {
                //Ԥ���岻��Ҫ����Ĭ��
                if (!drDesign["IsDefault"].Equals(DBNull.Value))
                    drDesign["IsDefault"] = DBNull.Value;
            }
            else
            {
                if ((!drDesign["IsDefault"].Equals(DBNull.Value) && (bool)drDesign["IsDefault"]) ^ this.chkDefault.Checked)
                    drDesign["IsDefault"] = this.chkDefault.Checked;
            }
            foreach (DataRowView drv in dsSource.Tables["AutoExe_User_Group"].DefaultView)
            {
                if (drv.Row["DesignGuid"].ToString() != drDesign["GUID"].ToString())
                    drv.Row["DesignGuid"] = drDesign["GUID"];
            }
            return true;
        }
        private bool Save(DataSet dsSource)
        {
            if (!this.ReadForm(dsSource)) return false;
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
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() != dsSource.Tables["AutoExe_User_Designs"].DefaultView[0].Row["GUID"].ToString())
                this.PrimaryValue = dsSource.Tables["AutoExe_User_Designs"].DefaultView[0].Row["GUID"].ToString();
            return true;
        }
        #endregion
        #region ģ�������
        private void listGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
        }
        private void tsb1Add_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            string strGroupName = string.Empty;
            while (true)
            {
                frmUserGroup frm = new frmUserGroup();
                frm.GroupName = strGroupName;
                if (DialogResult.OK != frm.ShowDialog(this)) return;
                if (this.DataSource.Tables["AutoExe_User_Group"].Select("GroupName='" + frm.GroupName + "'").Length > 0)
                {
                    this.ShowMsg("������" + frm.GroupName + "���Ѿ����ڣ��������");
                    strGroupName = frm.GroupName;
                    continue;
                }
                else
                {
                    DataTable dtGroup = this.DataSource.Tables["AutoExe_User_Group"];
                    DataRow drNew = dtGroup.NewRow();
                    drNew["GUID"] = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                    drNew["GroupName"] = frm.GroupName;
                    drNew["IsExpand"] = frm.Expand;
                    if (string.Compare(dtGroup.DefaultView.Sort, "SortID ASC", true) != 0)
                        dtGroup.DefaultView.Sort = "SortID ASC";
                    int iSortID;
                    if (dtGroup.DefaultView.Count == 0)
                        iSortID = 1;
                    else iSortID = (int)dtGroup.DefaultView[dtGroup.DefaultView.Count - 1].Row["SortID"] + 1;
                    drNew["SortID"] = iSortID;
                    dtGroup.Rows.Add(drNew);
                    this.BindGroup(drNew["GUID"].ToString(), dtGroup);
                    this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
                    break;
                }
            }

        }

        private void tsb1Edit_Click(object sender, EventArgs e)
        {
            if (this.listGroup.SelectedItem == null) return;
            Common.MyEntity.ComboBoxItem item = this.listGroup.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null) return;
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            DataTable dtGroup = this.DataSource.Tables["AutoExe_User_Group"];
            DataRow dr = dtGroup.Select("GUID='" + item.Value.ToString() + "'")[0];
            string strGroupName = dr["GroupName"].ToString();
            while (true)
            {
                frmUserGroup frm = new frmUserGroup();
                frm.GroupName = strGroupName;
                frm.Expand = !dr["IsExpand"].Equals(DBNull.Value) && (bool)dr["IsExpand"];
                if (DialogResult.OK != frm.ShowDialog(this)) return;
                if (dtGroup.Select("GroupName='" + frm.GroupName + "' AND GUID<>'" + item.Value.ToString() + "'").Length > 0)
                {
                    this.ShowMsg("������" + frm.GroupName + "���Ѿ����ڣ��������");
                    strGroupName = frm.GroupName;
                    continue;
                }
                else
                {
                    if (dr["GroupName"].ToString() != frm.GroupName)
                        dr["GroupName"] = frm.GroupName;
                    if ((!dr["IsExpand"].Equals(DBNull.Value) && (bool)dr["IsExpand"]) ^ frm.Expand)
                        dr["IsExpand"] = frm.Expand;
                    this.BindGroup(dr["GUID"].ToString(), dtGroup);
                    //this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
                    break;
                }
            }
        }

        private void tsb1Remove_Click(object sender, EventArgs e)
        {
            if (this.listGroup.SelectedItem == null) return;
            Common.MyEntity.ComboBoxItem item = this.listGroup.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null) return;
            string strGroup = item.Value.ToString();
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            if (!this.IsUserConfirm("��ȷ��Ҫ�Ƴ�ѡ�е�����")) return;
            if (this.DataSource.Tables["AutoExe_User_Forms"].Select("GroupGuid='" + item.Value.ToString() + "'").Length > 0)
            {
                this.ShowMsg("ģ���顰" + item.Text + "���»�����ģ�飬�����Ƴ��������Ƴ���Щģ������Ƴ����顣");
                return;
            }
            DataRow[] drs = this.DataSource.Tables["AutoExe_User_Group"].Select("GUID='" + item.Value.ToString() + "'");
            if (drs.Length > 0)
                drs[0].Delete();
            this.BindGroup(string.Empty, this.DataSource.Tables["AutoExe_User_Group"]);
            this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
        }

        private void tsb1Up_Click(object sender, EventArgs e)
        {
            int index = this.listGroup.SelectedIndex;
            if (index <= 0) return;
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            DataRow dr = this.DataSource.Tables["AutoExe_User_Group"].DefaultView[index].Row;
            DataRow dr1 = this.DataSource.Tables["AutoExe_User_Group"].DefaultView[index-1].Row;
            object objSort = dr["SortID"];
            dr["SortID"] = dr1["SortID"];
            dr1["SortID"] = objSort;
            this.BindGroup(dr["GUID"].ToString(), this.DataSource.Tables["AutoExe_User_Group"]);
        }

        private void tsb1Down_Click(object sender, EventArgs e)
        {
            int index = this.listGroup.SelectedIndex;
            if (index < 0 || index >= this.listGroup.Items.Count - 1) return;
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            DataRow dr = this.DataSource.Tables["AutoExe_User_Group"].DefaultView[index].Row;
            DataRow dr1 = this.DataSource.Tables["AutoExe_User_Group"].DefaultView[index + 1].Row;
            object objSort = dr["SortID"];
            dr["SortID"] = dr1["SortID"];
            dr1["SortID"] = objSort;
            this.BindGroup(dr["GUID"].ToString(), this.DataSource.Tables["AutoExe_User_Group"]);
        }
        #region  ��������
        private void ��ϵͳĬ���п���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM AutoExe_Sys_Group ORDER BY SortID ASC", "AutoExe_Sys_Group"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM [V_AutoExe_User_GetSysForms] ORDER BY SortID ASC", "AutoExe_Sys_Forms"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            DataTable dtSGroup = ds.Tables["AutoExe_Sys_Group"];
            DataTable dtSForm = ds.Tables["AutoExe_Sys_Forms"];
            DataTable dtUGroup = this.DataSource.Tables["AutoExe_User_Group"];
            DataTable dtUForm = this.DataSource.Tables["AutoExe_User_Forms"];
            int iGroupSort;
            string strGroupGuid;
            DataRow[] drs;
            if(string.Compare(dtUGroup.DefaultView.Sort,"",true)!=0)
                dtUGroup.DefaultView.Sort="SortID ASC";
            if (dtUGroup.DefaultView.Count == 0)
                iGroupSort = 1;
            else iGroupSort = (int)dtUGroup.DefaultView[dtUGroup.DefaultView.Count - 1].Row["SortID"] + 1;
            foreach (DataRowView drv in dtSGroup.DefaultView)
            {
                DataRow drNew = dtUGroup.NewRow();
                strGroupGuid=this.GetGUID(Common.MyEnums.Modules.None,Common.CurrentUserInfo.UserCode);
                drNew["GUID"] = strGroupGuid;
                drNew["SortID"] = iGroupSort;
                drNew["GroupName"] = drv.Row["GroupName"];
                dtUGroup.Rows.Add(drNew);
                iGroupSort++;
                #region ��Ӵ���
                drs = dtSForm.Select("GroupCode='" + drv.Row["Code"].ToString() + "'", "SortID ASC");
                foreach (DataRow dr in drs)
                {
                    DataRow drFNew = dtUForm.NewRow();
                    drFNew["GroupGuid"] = strGroupGuid;
                    drFNew["SortID"] = dr["SortID"];
                    drFNew["FormCode"] = dr["Code"];
                    drFNew["FormName"] = dr["FormName"];
                    drFNew["IsMultiView"] = dr["IsMultiView"];
                    //drFNew["ForeColor"] = dr[""];
                    //drFNew["Underline"] = dr[""];
                    //drFNew["FontBold"] = dr[""];
                    drFNew["GroupName"] = dr["GroupName"];
                    drFNew["Powers"] = dr["Powers"];
                    drFNew["UserLevelView"] = dr["UserLevelView"];
                    dtUForm.Rows.Add(drFNew);
                }
                #endregion
            }
            this.BindGroup(string.Empty, this.DataSource.Tables["AutoExe_User_Group"]);
            this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
        }
        #endregion
        #endregion
        #region ���幤��������
        private void tsb2Add_Click(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.listGroup.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null)
            {
                this.ShowMsg("��ѡ��ģ���飡");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            DataTable dtForm = this.DataSource.Tables["AutoExe_User_Forms"];
            string strCodes = string.Empty;
            foreach (DataRowView drv in dtForm.DefaultView)
            {
                strCodes += drv.Row["FormCode"].ToString() + "|";
            }
            frmSelectSysForms frm = new frmSelectSysForms();
            frm._Codes = strCodes;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (string.Compare(dtForm.DefaultView.Sort, "SortID ASC", true) != 0)
                dtForm.DefaultView.Sort = "SortID ASC";
            int iSortID;
            if (dtForm.DefaultView.Count == 0)
                iSortID = 1;
            else iSortID = (int)dtForm.DefaultView[dtForm.DefaultView.Count - 1].Row["SortID"] + 1;
            DataRow drNew;
            string strSelIDs=string.Empty;
            foreach (frmSelectSysForms.SelectedSysForms info in frm.SelectedData)
            {
                drNew = dtForm.NewRow();
                drNew["GroupGuid"] = item.Value;
                drNew["SortID"] = iSortID;
                drNew["FormCode"] = info.Code;
                drNew["FormName"] = info.FormName;
                drNew["IsMultiView"] = info.IsMultiView;
                drNew["Powers"] = info.Powers;
                drNew["UserLevelView"] = info.UserLevelView;
                drNew["GroupName"] = info.GroupName;
                dtForm.Rows.Add(drNew);
                iSortID++;
                strSelIDs += drNew["ID"].ToString() + "|";
            }
            this.BindForm(strSelIDs, dtForm);
        }
        private void tsb2Edit_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("��ѡ��һ�����ݡ�");
                return;
            }
            if (this.dgvForms.SelectedRows.Count >1)
            {
                this.ShowMsg("һ��ֻ�ܱ༭һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[this.dgvForms.SelectedRows[0].Index].Row;
            DataRow[] drs = this.DataSource.Tables["AutoExe_User_Forms"].Select("ID=" + dr["ID"].ToString() + "");
            frmUserFormEdit frm = new frmUserFormEdit();
            frm._DataRow = drs[0];
            frm._DsSource = this.DataSource;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindForm(dr["ID"].ToString(), this.DataSource.Tables["AutoExe_User_Forms"]);
        }

        private void tsb2Remove_Click(object sender, EventArgs e)
        {
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("������ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            if (!this.IsUserConfirm("��ȷ��Ҫ�Ƴ�ѡ�е�����"))
                return;
            string strID;
            DataRow[] drs;
            for (int i = 0; i < this.dgvForms.SelectedRows.Count; i++)
            {
                strID = dt.DefaultView[this.dgvForms.SelectedRows[i].Index].Row["ID"].ToString();
                drs = this.DataSource.Tables["AutoExe_User_Forms"].Select("ID=" + strID + "");
                if (drs.Length > 0)
                    drs[0].Delete();
            }
            this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
        }

        private void tsb2Up_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����ԴΪ�գ�");
                return;
            }
            if (this.listGroup.SelectedItem == null)
            {
                this.ShowMsg("��ѡ��һ��ģ���飬�ڽ���");
                return;
            }
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("������ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr;
            string sIDs = string.Empty;
            //ע������Ǵ���������������
            for (int i = 0; i < this.dgvForms.Rows.Count; i++)
            {
                if (!this.dgvForms.Rows[i].Selected)
                    continue;
                dr = dt.DefaultView[i].Row;
                if (MoveUp(long.Parse(dr["ID"].ToString()), dr["GroupGuid"].ToString(), this.DataSource.Tables["AutoExe_User_Forms"]))
                    sIDs += dr["ID"].ToString() + "|";
            }
            this.BindForm(sIDs, this.DataSource.Tables["AutoExe_User_Forms"]);
        }
        private bool MoveUp(long lID, string sGroupGuid, DataTable dtForm)
        {
            int iSort1,iSort2;
            DataRow dr1, dr2;
            DataRow[] drs = dtForm.Select("ID=" + lID.ToString() + "");
            if (drs.Length == 0)
            {
                this.ShowMsg("δ������Դ���ҵ��������ݡ�");
                return false;
            }
            dr1 = drs[0];//��Ҫ���Ƶ���
            iSort1 = (int)dr1["SortID"];
            drs = dtForm.Select(string.Format("GroupGuid='{0}' AND SortID<{1}", sGroupGuid, iSort1), "SortID DESC");
            if (drs.Length == 0)
            {
                this.ShowMsg("�Ѿ�������һ���ˡ�");
                return false;
            }
            dr2 = drs[0];
            iSort2=(int)dr2["SortID"];
            //У��SortID
            dr1["SortID"] = iSort2;
            dr2["SortID"] = iSort1;
            return true;
        }
        private bool MoveDown(long lID, string sGroupGuid,DataTable dtForm)
        {
            int iSort1, iSort2;
            DataRow dr1, dr2;
            DataRow[] drs = dtForm.Select("ID=" + lID.ToString() + "");
            if (drs.Length == 0)
            {
                this.ShowMsg("δ������Դ���ҵ��������ݡ�");
                return false;
            }
            dr1 = drs[0];//��Ҫ���Ƶ���
            iSort1 = (int)dr1["SortID"];
            drs = dtForm.Select(string.Format("GroupGuid='{0}' AND SortID>{1}", sGroupGuid, iSort1), "SortID ASC");
            if (drs.Length == 0)
            {
                this.ShowMsg("�Ѿ�������һ���ˡ�");
                return false;
            }
            dr2 = drs[0];
            iSort2 = (int)dr2["SortID"];
            //У��SortID
            dr1["SortID"] = iSort2;
            dr2["SortID"] = iSort1;
            return true;
        }
        private void tsb2Down_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����ԴΪ�գ�");
                return;
            }
            if (this.listGroup.SelectedItem == null)
            {
                this.ShowMsg("��ѡ��һ��ģ���飬�ڽ���");
                return;
            }
            if (this.dgvForms.SelectedRows.Count == 0)
            {
                this.ShowMsg("������ѡ��һ�����ݡ�");
                return;
            }
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr;
            string sIDs = string.Empty;
            //ע������Ǵ���������������
            for (int i = this.dgvForms.Rows.Count - 1; i >= 0; i--)
            {
                if (!this.dgvForms.Rows[i].Selected)
                    continue;
                dr = dt.DefaultView[i].Row;
                if (this.MoveDown(long.Parse(dr["ID"].ToString()), dr["GroupGuid"].ToString(), this.DataSource.Tables["AutoExe_User_Forms"]))
                    sIDs += dr["ID"].ToString() + "|";
            }
            this.BindForm(sIDs, this.DataSource.Tables["AutoExe_User_Forms"]);
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck()) return;
            DataSet ds = this.DataSource.Copy();
            if (this.Save(ds))
            {
                this.ShowMsg("����ɹ���");
                this.BindDesign(this.PrimaryValue.ToString());
            }
        }
        #endregion
        #region ����onLoad�¼�
        private void frmSysForms_Load(object sender, EventArgs e)
        {
            Perinit();
            btSave.Enabled = this.BindDesign(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString()) && btSave.Enabled;
        }
        #endregion

        private void dgvForms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataTable dt = this.dgvForms.DataSource as DataTable;
            if (dt == null) return;
            DataRow dr = dt.DefaultView[e.RowIndex].Row;
            DataRow[] drs = this.DataSource.Tables["AutoExe_User_Forms"].Select("ID=" + dr["ID"].ToString() + "");
            frmUserFormEdit frm = new frmUserFormEdit();
            frm._DataRow = drs[0];
            frm._DsSource = this.DataSource;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.BindForm(dr["ID"].ToString(), this.DataSource.Tables["AutoExe_User_Forms"]);
        }

        private void �ӷ������п���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            frmSelYdy frm = new frmSelYdy();
            frm._DesignGuid = this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm._DesignGuid == string.Empty)
            {
                this.ShowMsg("��ѡ��һ������");
                return;
            }
            if (CopyUserDesign(frm._DesignGuid))
            {
                this.BindGroup(string.Empty, this.DataSource.Tables["AutoExe_User_Group"]);
                this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
            }

        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("����Դ��ʧ�������¼��ء�");
                return;
            }
            frmSelUsers frm = new frmSelUsers();
            frm._DesignGuid = this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (frm._DesignGuid == string.Empty)
            {
                this.ShowMsg("��ѡ��һ������");
                return;
            }
            if (CopyUserDesign(frm._DesignGuid))
            {
                this.BindGroup(string.Empty, this.DataSource.Tables["AutoExe_User_Group"]);
                this.BindForm(string.Empty, this.DataSource.Tables["AutoExe_User_Forms"]);
            }
        }
        private bool CopyUserDesign(string sGuid)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM AutoExe_User_Group WHERE DesignGuid='{0}' ORDER BY SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Group"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_AutoExe_User_Forms WHERE DesignGuid='{0}' ORDER BY SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Forms"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            DataTable dtYGroup = ds.Tables["AutoExe_User_Group"];
            DataTable dtYForm = ds.Tables["AutoExe_User_Forms"];
            DataTable dtUGroup = this.DataSource.Tables["AutoExe_User_Group"];
            DataTable dtUForm = this.DataSource.Tables["AutoExe_User_Forms"];
            int iGroupSort;
            string strGroupGuid;
            DataRow[] drs;
            if (string.Compare(dtUGroup.DefaultView.Sort, "", true) != 0)
                dtUGroup.DefaultView.Sort = "SortID ASC";
            if (dtUGroup.DefaultView.Count == 0)
                iGroupSort = 1;
            else iGroupSort = (int)dtUGroup.DefaultView[dtUGroup.DefaultView.Count - 1].Row["SortID"] + 1;
            foreach (DataRowView drv in dtYGroup.DefaultView)
            {
                DataRow drNew = dtUGroup.NewRow();
                strGroupGuid = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);
                drNew["GUID"] = strGroupGuid;
                drNew["SortID"] = iGroupSort;
                drNew["GroupName"] = drv.Row["GroupName"];
                dtUGroup.Rows.Add(drNew);
                iGroupSort++;
                #region ��Ӵ���
                drs = dtYForm.Select("GroupGuid='" + drv.Row["GUID"].ToString() + "'", "SortID ASC");
                foreach (DataRow dr in drs)
                {
                    DataRow drFNew = dtUForm.NewRow();
                    drFNew["GroupGuid"] = strGroupGuid;
                    drFNew["SortID"] = dr["SortID"];
                    drFNew["FormCode"] = dr["FormCode"];
                    drFNew["FormName"] = dr["FormName"];
                    drFNew["IsMultiView"] = dr["IsMultiView"];
                    drFNew["ForeColor"] = dr["ForeColor"];
                    drFNew["Underline"] = dr["Underline"];
                    drFNew["FontBold"] = dr["FontBold"];
                    drFNew["GroupName"] = dr["GroupName"];
                    drFNew["Powers"] = dr["Powers"];
                    drFNew["UserLevelView"] = dr["UserLevelView"];
                    dtUForm.Rows.Add(drFNew);
                }
                #endregion
            }
            return true;
        }
    }
}