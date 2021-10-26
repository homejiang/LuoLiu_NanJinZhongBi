using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ErrorService;
namespace UpdateERP
{
    public partial class frmUpdateVersion : Common.frmSelectBase
    {
        public frmUpdateVersion()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.UpdateVersion _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.UpdateVersion BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new UpdateERP.BLLDAL.UpdateVersion();
                return _dal;
            }
        }
        #endregion
        #region 私有属性
        private DataTable _DataTable = null;
        private DataTable _NewPDataTable = null;
        List<ProjectEntity> _ListP = null;
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            this.myDataGridView1.AutoGenerateColumns = false;
            this.dgvNewP.AutoGenerateColumns = false;
            this.BindDataGridViewCheckBox(this.myDataGridView1, this.colCheckBox);
            _DataTable = new DataTable();
            _DataTable.Columns.Add(this.GetDataGridViewCheckBoxColumn());
            _DataTable.Columns.Add("ProjectName", Type.GetType("System.String"));
            _DataTable.Columns.Add("ProjectVersion", Type.GetType("System.String"));
            _DataTable.Columns.Add("GUID", Type.GetType("System.String"));
            _DataTable.Columns.Add("FilesName", Type.GetType("System.String"));
            _DataTable.Columns.Add("DataBaseVersion", Type.GetType("System.String"));
            _DataTable.Columns.Add("DataBaseFilesName", Type.GetType("System.String"));
            _DataTable.Columns.Add("Remark", Type.GetType("System.String"));
            _DataTable.Columns.Add("CurrentRemark", Type.GetType("System.String"));
            _DataTable.DefaultView.Sort = "ProjectName";
            this.myDataGridView1.DataSource = _DataTable;
            _ListP = this.GetProjects();
            foreach (ProjectEntity p in _ListP)
            {
                DataRow drNew = _DataTable.NewRow();
                drNew["ProjectName"] = p.ProjectName;
                drNew["ProjectVersion"] = p.ProjectVersion;
                drNew["GUID"] = p.GUID;
                drNew["FilesName"] = p.GetFileNames();
                _DataTable.Rows.Add(drNew);
            }
            _NewPDataTable = new DataTable();
            _NewPDataTable.Columns.Add("ProjectGuid", Type.GetType("System.String"));
            _NewPDataTable.Columns.Add("ProjectName", Type.GetType("System.String"));
            _NewPDataTable.Columns.Add("ProjectVersion", Type.GetType("System.String"));
            _NewPDataTable.Columns.Add("ForProjectName", Type.GetType("System.String"));
            dgvNewP.DataSource = _NewPDataTable;
            return true;
        }
        private bool BindData()
        {
            if (_DataTable == null) return true;
            DataTable dt;
            try
            {
                dt = UpdateERP.BLLDAL.UpdateDAL.DoSqlCommand.GetDateTable("select *,dbo.GetfileNames(ProjectGuid) AS Filenames from Update_Version");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            List<string> listNewGuid;
            if (dt.Rows.Count > 0)
                listNewGuid = new List<string>();
            else listNewGuid = null;
            DataRow[] drs;
            foreach (DataRow dr in dt.Rows)
            {
                drs = _DataTable.Select("GUID='" + dr["ProjectGuid"].ToString() + "'");
                if (drs.Length > 0)
                {
                    drs[0]["DataBaseVersion"] = dr["Version"];
                    drs[0]["DataBaseFilesName"] = dr["Filenames"];
                }
            }
            bool blSel;
            foreach (DataRow dr in _DataTable.Rows)
            {
                drs = dt.Select("ProjectGuid='" + dr["GUID"].ToString() + "'");
                if (drs.Length == 0)
                {
                    blSel = true;
                    if (listNewGuid != null)
                    {
                        listNewGuid.Add(dr["GUID"].ToString());
                    }
                }
                else
                {
                    blSel = string.Compare(dr["ProjectVersion"].ToString(), drs[0]["Version"].ToString(), true) != 0;
                }
                if (!dr[this.DataGridViewCheckColumnName].Equals(blSel))
                    dr[this.DataGridViewCheckColumnName] = blSel;
            }
            #region 获取新增模块的名称
            if (listNewGuid != null)
            {
                DataRow[] drsP;
                string strExeName;
                foreach (string sNewPGuid in listNewGuid)
                {
                    drsP = _DataTable.Select("GUID='" + sNewPGuid + "'");
                    if (drsP.Length > 0)
                    {
                        DataRow drNewP = _NewPDataTable.NewRow();
                        drNewP["ProjectGuid"] = sNewPGuid;
                        drNewP["ProjectName"] = drsP[0]["ProjectName"];
                        drNewP["ProjectVersion"] = drsP[0]["ProjectVersion"];
                        strExeName = this.GetExps(sNewPGuid, drsP[0]["ProjectName"].ToString());
                        drNewP["ForProjectName"] = strExeName;
                        _NewPDataTable.Rows.Add(drNewP);
                    }
                }
            }
            #endregion
            return true;
        }
        #endregion
        #region 查找模块被哪些模块所应用
        private string GetExps(string sGuid,string sPName)
        {
            string strExes = "";
            if (string.Compare(sPName, "BasicData", true) != 0 && IsContain(BasicData.Version.GetCurrentVersions(), sGuid))
                strExes += "BasicData.exe|";
            if (string.Compare(sPName, "LuoLiuMES", true) != 0 && IsContain(LuoLiuMES.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuMES.exe|";
            if (string.Compare(sPName, "Common", true) != 0 && IsContain(Common.Version.GetCurrentVersions(), sGuid))
                strExes += "Common.exe|";
            if (string.Compare(sPName, "SysSetting", true) != 0 && IsContain(SysSetting.Version.GetCurrentVersions(), sGuid))
                strExes += "SysSetting.exe|";
            if (string.Compare(sPName, "EleCardComposing", true) != 0 && IsContain(EleCardComposing.Version.GetCurrentVersions(), sGuid))
                strExes += "EleCardComposing.exe|";
            if (string.Compare(sPName, "LuoLiuCCD", true) != 0 && IsContain(LuoLiuCCD.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuCCD.exe|";
            if (string.Compare(sPName, "LuoLiuDianHan", true) != 0 && IsContain(LuoLiuDianHan.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuDianHan.exe|";
            if (string.Compare(sPName, "LuoLiuMESPrinter", true) != 0 && IsContain(LuoLiuMESPrinter.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuMESPrinter.exe|";
            if (string.Compare(sPName, "LuoLiuPCBTest", true) != 0 && IsContain(LuoLiuPCBTest.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuPCBTest.exe|";
            if (string.Compare(sPName, "LuoLiuTesting", true) != 0 && IsContain(LuoLiuTesting.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuTesting.exe|";
            if (string.Compare(sPName, "AutoPrint", true) != 0 && IsContain(AutoPrint.Version.GetCurrentVersions(), sGuid))
                strExes += "AutoPrint.exe|";

            if (string.Compare(sPName, "LuoLiuEOLTest", true) != 0 && IsContain(LuoLiuEOLTest.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuEOLTest.exe|";
            if (string.Compare(sPName, "LuoLiuAgingTest", true) != 0 && IsContain(LuoLiuAgingTest.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuAgingTest.exe|";
            if (string.Compare(sPName, "LuoLiuAirtightnessTest", true) != 0 && IsContain(LuoLiuAirtightnessTest.Version.GetCurrentVersions(), sGuid))
                strExes += "LuoLiuAirtightnessTest.exe|";

            return strExes;
        }
        private bool IsContain(List<Common.MyEntity.VersionEntity> list, string sGuid)
        {
            if (list.Find(delegate(Common.MyEntity.VersionEntity entity)
            {
                return string.Compare(entity.Guid, sGuid, true) == 0;
            }) != null) return true;
            return false;
        }
        #endregion
        #region 项目实体类
        private class ProjectEntity
        {
            public ProjectEntity()
            {
            }
            public ProjectEntity(string sName,string sVersion,string sGuid)
            {
                ProjectName = sName;
                ProjectVersion = sVersion;
                GUID = sGuid;
            }
            public string ProjectName = string.Empty;
            public string ProjectVersion = string.Empty;
            public string GUID = string.Empty;
            public FileInfo[] GetFiles()
            {
                if (ProjectName.Length == 0) return null;
                //System.IO.Directory.GetFiles(
                string strRoot = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                while (strRoot.EndsWith("\\"))
                    strRoot = strRoot.Substring(0, strRoot.Length - 1);
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(strRoot);
                // return dir.GetFiles(string.Format("{0}.*", ProjectName));
                FileInfo[] fs = dir.GetFiles(string.Format("{0}.*", ProjectName));
                List<FileInfo> listFile = new List<FileInfo>();
                int iCount = 0;
                foreach (FileInfo f in fs)
                {
                    if (f.Name.ToLower().EndsWith(".manifest")) continue;
                    iCount++;
                }
                FileInfo[] ret = new FileInfo[iCount];
                iCount = 0;
                foreach (FileInfo f in fs)
                {
                    if (f.Name.ToLower().EndsWith(".manifest")) continue;
                    ret[iCount] = f;
                    iCount++;
                }
                return ret;
            }
            public string GetFileNames()
            {
                FileInfo[] files = GetFiles();
                if (files == null) return string.Empty;
                string strText = string.Empty;
                foreach (FileInfo f in files)
                {
                    //if (f.Name.ToLower().EndsWith(".manifest")) continue;
                    strText += f.Name + "、";
                }
                if (strText.Length > 0)
                    strText = strText.Substring(0, strText.Length - 1);
                return strText;
            }
        }
        #endregion
        #region  获取当前所有项目
        private List<ProjectEntity> GetProjects()
        {
            List<ProjectEntity> list = new List<ProjectEntity>();
            list.Add(new ProjectEntity(BasicData.Version.GetTitle(), BasicData.Version.GetVersion(), BasicData.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuMES.Version.GetTitle(), LuoLiuMES.Version.GetVersion(), LuoLiuMES.Version.GetGuid()));
            list.Add(new ProjectEntity(Common.Version.GetTitle(), Common.Version.GetVersion(), Common.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.DropdownMultiSelect.Version.GetTitle(), MyControl.DropdownMultiSelect.Version.GetVersion(), MyControl.DropdownMultiSelect.Version.GetGuid()));
            list.Add(new ProjectEntity(ErrorService.Version.GetTitle(), ErrorService.Version.GetVersion(), ErrorService.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyColorName.Version.GetTitle(), MyControl.MyColorName.Version.GetVersion(), MyControl.MyColorName.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyDataGridView.Version.GetTitle(), MyControl.MyDataGridView.Version.GetVersion(), MyControl.MyDataGridView.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyLabelEx.Version.GetTitle(), MyControl.MyLabelEx.Version.GetVersion(), MyControl.MyLabelEx.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyTextBox.Version.GetTitle(), MyControl.MyTextBox.Version.GetVersion(), MyControl.MyTextBox.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.NumericBox.Version.GetTitle(), MyControl.NumericBox.Version.GetVersion(), MyControl.NumericBox.Version.GetGuid()));
            list.Add(new ProjectEntity(SysSetting.Version.GetTitle(), SysSetting.Version.GetVersion(), SysSetting.Version.GetGuid()));
            list.Add(new ProjectEntity(AutoPrint.Version.GetTitle(), AutoPrint.Version.GetVersion(), AutoPrint.Version.GetGuid()));
            list.Add(new ProjectEntity(EleCardComposing.Version.GetTitle(), EleCardComposing.Version.GetVersion(), EleCardComposing.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuCCD.Version.GetTitle(), LuoLiuCCD.Version.GetVersion(), LuoLiuCCD.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuDianHan.Version.GetTitle(), LuoLiuDianHan.Version.GetVersion(), LuoLiuDianHan.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuMESPrinter.Version.GetTitle(), LuoLiuMESPrinter.Version.GetVersion(), LuoLiuMESPrinter.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuPCBTest.Version.GetTitle(), LuoLiuPCBTest.Version.GetVersion(), LuoLiuPCBTest.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuTesting.Version.GetTitle(), LuoLiuTesting.Version.GetVersion(), LuoLiuTesting.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuEOLTest.Version.GetTitle(), LuoLiuEOLTest.Version.GetVersion(), LuoLiuEOLTest.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuAgingTest.Version.GetTitle(), LuoLiuAgingTest.Version.GetVersion(), LuoLiuAgingTest.Version.GetGuid()));
            list.Add(new ProjectEntity(LuoLiuAirtightnessTest.Version.GetTitle(), LuoLiuAirtightnessTest.Version.GetVersion(), LuoLiuAirtightnessTest.Version.GetGuid()));
            list.Add(new ProjectEntity(JpsOPC.Version.GetTitle(), JpsOPC.Version.GetVersion(), JpsOPC.Version.GetGuid()));
            return list;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            if (dt == null) return;
            DataRow[] drs = dt.Select("isnull(" + this.DataGridViewCheckColumnName + ",0)=1");
            DataRow[] drsNewP;
            string strNewExes;
            foreach (DataRow dr in drs)
            {
                ProjectEntity entity=new ProjectEntity(dr["ProjectName"].ToString(), dr["ProjectVersion"].ToString(), dr["GUID"].ToString());
                drsNewP = this._NewPDataTable.Select("ProjectGuid='" + dr["GUID"].ToString() + "'");
                if (drsNewP.Length > 0)
                    strNewExes = drsNewP[0]["ForProjectName"].ToString();
                else strNewExes = string.Empty;
                try
                {
                    this.BllDAL.SaveProject(dr["ProjectName"].ToString(), dr["ProjectVersion"].ToString(), dr["GUID"].ToString()
                        , dr["Remark"].ToString(), dr["CurrentRemark"].ToString(),
                       entity.GetFiles(), strNewExes);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
            }
            this.ShowMsg("更新成功");
            BindData();
        }

        private void frmUpdateVersion_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            this.BindData();
        }

        private void btRemark_Click(object sender, EventArgs e)
        {
            if (myDataGridView1.SelectedRows.Count == 0) return;
            if (myDataGridView1.SelectedRows.Count > 1)
            {
                this.ShowMsg("请选择1行数据");
                return;
            }
            DataTable dt = myDataGridView1.DataSource as DataTable;
            DataRow dr = dt.DefaultView[myDataGridView1.SelectedRows[0].Index].Row;
            UpdateVersion.frmRemark frm = new UpdateERP.UpdateVersion.frmRemark();
            frm.Remark = dr["Remark"].ToString();
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            dr["Remark"] = frm.Remark;
        }
        private void btCurrentRemark_Click(object sender, EventArgs e)
        {
            //frmCurrentRemark
            if (myDataGridView1.SelectedRows.Count == 0) return;
            if (myDataGridView1.SelectedRows.Count > 1)
            {
                this.ShowMsg("请选择1行数据");
                return;
            }
            DataTable dt = myDataGridView1.DataSource as DataTable;
            DataRow dr = dt.DefaultView[myDataGridView1.SelectedRows[0].Index].Row;
            UpdateVersion.frmCurrentRemark frm = new UpdateERP.UpdateVersion.frmCurrentRemark();
            frm.Remark = dr["CurrentRemark"].ToString();
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            dr["CurrentRemark"] = frm.Remark;
        }

        private void btRemovePdb_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要移除所有后缀为pdb的文件吗？")) return;
            string[] arr = Directory.GetFiles(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "*.pdb");
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (string s in arr)
                {
                    if (File.Exists(s))
                    {
                        File.Delete(s);
                        sb.Append(s);
                        sb.Append("\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            UpdateVersion.frmDelFiles frm = new UpdateERP.UpdateVersion.frmDelFiles();
            frm.DelFiles = sb.ToString();
            frm.Show();
        }

        private void btUpdateExe_Click(object sender, EventArgs e)
        {
            frmUpdateExe frm = new frmUpdateExe();
            frm.ShowDialog(this);
        }
    }
}