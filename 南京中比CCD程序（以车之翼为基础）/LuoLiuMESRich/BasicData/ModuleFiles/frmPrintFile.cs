using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using Common;
using System.IO;

namespace BasicData.ModuleFiles
{
    public partial class frmPrintFile : frmBase
    {
        public frmPrintFile()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PrintFile _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.PrintFile BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BasicData.BLLDAL.PrintFile();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        /// <summary>
        /// 窗体初始化加载信息
        /// </summary>
        /// <returns></returns>
        private bool PerInit()
        {
            this.dgvList.AutoGenerateColumns = false;
            return true;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        private bool BindData()
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            string strSql = "SELECT PrintArg,FileName,FileVersion,Times,Remark,(Case when FileEntity is null then '否' ELSE '是' end) AS FileEntityView FROM JC_PrintFile Order by PrintArg ASC";
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(strSql, "JC_PrintFile", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = ds.Tables["JC_PrintFile"];
            this.DataSource = ds;
            return true;
        }
        #endregion
        #region 保存数据
        /// <summary>
        /// 保存前校验
        /// </summary>
        /// <returns></returns>
        private bool SaveCheck()
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return false;
            }
            if (this.tbPrintArg.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入模板名称！");
                return false;
            }
            //判断单位是否已经存在
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT PrintArg FROM JC_PrintFile WHERE PrintArg='{0}'", this.tbPrintArg.Text.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                this.ShowMsg("模板名称“" + this.tbPrintArg.Text + "”已经存在，请更换");
                return false;
            }
            if (this.tbFileName.Text.Trim().Length == 0)
            {
                this.ShowMsg("请输入文件名称。");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            //读取数据
            return true;
        }
        #endregion
        #region 新增打印模板
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!this.SaveCheck())
                return;
            DataTable dt = this.DataSource.Tables["JC_PrintFile"];
            DataRow dr;
            dr = dt.NewRow();
            dr["PrintArg"] = this.tbPrintArg.Text.Trim();
            dr["FileName"] = this.tbFileName.Text.Trim();
            dr["Remark"] = this.tbRemark.Text.Trim();
            DateTime detSer;
            if (!Common.CommonFuns.GetSysCurrentDateTime(out detSer))
                return;
            dr["Times"] = detSer;
            dt.Rows.Add(dr);
            try
            {
                this.BllDAL.Save(this.DataSource);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.tbPrintArg.Text = string.Empty;
            this.tbFileName.Text = string.Empty;
            this.tbRemark.Text = string.Empty;
            this.BindData();
        }
        #endregion
        #region 工具条按钮事件
        //编辑按钮
        private void nvbtEdit_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            bool blUpdate = false;
            for (int i = 0; i < this.dgvList.SelectedRows.Count; i++)
            {
                frmPrintFileEdit frm = new frmPrintFileEdit();
                frm.PrimaryValue = this.DataSource.Tables["JC_PrintFile"].DefaultView[this.dgvList.SelectedRows[i].Index].Row["PrintArg"].ToString();
                if (DialogResult.OK == frm.ShowDialog(this))
                    blUpdate = true;
            }
            //如果用户修改过数据，则需要重新加载
            if (blUpdate)
                this.BindData();
        }
        private void nvbtRemove_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0)
                return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (DialogResult.Yes != MessageBox.Show(this, "您确定要删除选中的打印模板吗？", "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                return;
            try
            {
                for (int i = this.dgvList.SelectedRows.Count; i > 0; i--)
                {
                    this.BllDAL.Detele(dt.DefaultView[this.dgvList.SelectedRows[i - 1].Index].Row["PrintArg"].ToString());
                }
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.BindData();
        }
        //列表双击事件
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataTable dt = this.dgvList.DataSource as DataTable;
            frmPrintFileEdit frm = new frmPrintFileEdit();
            frm.PrimaryValue = dt.DefaultView[e.RowIndex].Row["PrintArg"].ToString();
            if (DialogResult.OK == frm.ShowDialog(this))
                this.BindData();
        }
        #endregion
        #region 窗体加载事件
        private void frmUnits_Load(object sender, EventArgs e)
        {
            if (!this.PerInit())
                return;
            this.BindData();
        }
        #endregion

        private void nvbtUploadFile_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            if (this.dgvList.SelectedRows.Count > 1)
            {
                this.ShowMsg("只能选中1行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strArg = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["PrintArg"].ToString();
            if (strArg == string.Empty) return;
            if (DialogResult.OK != this.openFileDialog1.ShowDialog(this)) return;
            string strFile = this.openFileDialog1.FileName;
            if (strFile.Length == 0) return;
            
            try
            {
                FileInfo fi = new FileInfo(strFile);
                FileStream fs = fi.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                this.BllDAL.Upload(strArg, bytes);
                fs.Close();
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("上传成功");
            this.BindData();
        }

        private void btDownload_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有系统管理员才能添加模板。");
                return;
            }
            if (this.dgvList.SelectedRows.Count == 0) return;
            if (this.dgvList.SelectedRows.Count > 1)
            {
                this.ShowMsg("只能选中1行数据。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            string strArg = dt.DefaultView[this.dgvList.SelectedRows[0].Index].Row["PrintArg"].ToString();
            if (strArg == string.Empty) return;
            if (Downloadfile(strArg))
                this.ShowMsg("下载成功。");
        }
        private bool Downloadfile(string sArg)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT FileEntity,[FileName],FileVersion FROM JC_PrintFile WHERE PrintArg='{0}'", sArg.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("模板\"" + sArg + "\"不存在或已经被删除。");
                return false;
            }
            if (dt.Rows[0]["FileEntity"].Equals(DBNull.Value))
            {
                this.ShowMsg("此模板还未上传文件。");
                return false;
            }
            string strName = dt.Rows[0]["FileName"].ToString();
            string strVersion = dt.Rows[0]["FileVersion"].ToString();
            int iDotIndex = strName.LastIndexOf(".");
            if (iDotIndex < 0)
            {
                this.ShowMsg("“" + strName + "”不是有效的文件名称，它至少有后缀。");
                return false;
            }
            if (strVersion.Length > 0)
            {
                strName = strName.Substring(0, iDotIndex) + strVersion + "." + strName.Substring(iDotIndex + 1);
            }
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();
            dialog.Filter = "Excel文件(*.xls)|*.xls";
            dialog.OverwritePrompt = true;
            dialog.DefaultExt = ".xls";
            dialog.FileName = Common.CommonConfig.GetDefaultOutputFolder() + "\\" + strName;
            dialog.AddExtension = true;
            if (System.Windows.Forms.DialogResult.OK != dialog.ShowDialog(this))
                return false;
            if (dialog.FileName == string.Empty)
            {
                return false;
            }
            try
            {
                System.IO.FileInfo file = new System.IO.FileInfo(dialog.FileName);
                if (file != null)
                {
                    file.Delete();
                    file = new System.IO.FileInfo(dialog.FileName);
                }
                byte[] byFile = (byte[])dt.Rows[0]["FileEntity"];
                System.IO.FileStream fs;
                fs = file.OpenWrite();
                fs.Write(byFile, 0, byFile.Length);
                fs.Close();
                fs.Dispose();
                file = null;
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                this.ShowMsg("文件“" + dialog.FileName + "”创建失败");
                return false;
            }
            return true;
        }
    }
}