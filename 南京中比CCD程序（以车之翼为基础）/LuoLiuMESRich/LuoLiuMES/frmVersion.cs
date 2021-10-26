using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LuoLiuMES
{
    public partial class frmVersion : Form
    {
        public frmVersion()
        {
            InitializeComponent();
        }
        private void frmVersion_Load(object sender, EventArgs e)
        {
            List<ProjectEntity> list = this.GetProjects();
            if (list != null)
            {
                foreach (ProjectEntity entity in list)
                {
                    this.richTextBox1.AppendText(string.Format("{0}：{1}\r\n", entity.ProjectName, entity.ProjectVersion));
                }
            }
        }
        private List<ProjectEntity> GetProjects()
        {
            List<ProjectEntity> list = new List<ProjectEntity>();
       
            list.Add(new ProjectEntity(Common.Version.GetTitle(), Common.Version.GetVersion(), Common.Version.GetGuid()));
            list.Add(new ProjectEntity(ErrorService.Version.GetTitle(), ErrorService.Version.GetVersion(), ErrorService.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyColorName.Version.GetTitle(), MyControl.MyColorName.Version.GetVersion(), MyControl.MyColorName.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyDataGridView.Version.GetTitle(), MyControl.MyDataGridView.Version.GetVersion(), MyControl.MyDataGridView.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyLabelEx.Version.GetTitle(), MyControl.MyLabelEx.Version.GetVersion(), MyControl.MyLabelEx.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.MyTextBox.Version.GetTitle(), MyControl.MyTextBox.Version.GetVersion(), MyControl.MyTextBox.Version.GetGuid()));
            list.Add(new ProjectEntity(MyControl.NumericBox.Version.GetTitle(), MyControl.NumericBox.Version.GetVersion(), MyControl.NumericBox.Version.GetGuid()));

            list.Add(new ProjectEntity(SysSetting.Version.GetTitle(), SysSetting.Version.GetVersion(), SysSetting.Version.GetGuid()));
  
            return list;
        }
        #region 项目实体类
        private class ProjectEntity
        {
            public ProjectEntity()
            {
            }
            public ProjectEntity(string sName, string sVersion, string sGuid)
            {
                ProjectName = sName;
                ProjectVersion = sVersion;
                GUID = sGuid;
            }
            public string ProjectName = string.Empty;
            public string ProjectVersion = string.Empty;
            public string GUID = string.Empty;
            
        }
        #endregion
    }
}