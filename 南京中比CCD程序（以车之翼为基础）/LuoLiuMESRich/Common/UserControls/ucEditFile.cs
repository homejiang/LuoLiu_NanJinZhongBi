using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.IO;

namespace Common.UserControls
{
    public partial class ucEditFile : UserControl
    {
        public ucEditFile()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Files _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Files BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new Common.BLLDAL.Files();
                return _dal;
            }
        }
        #endregion
        #region 事件
        public event UCEditFileUploadHandler OnUploadFile = null;
        public event UCEditFileDelHandler OnDelFile = null;
        public event UCEditFileMoveHandler OnMoveFile = null;
        public event UCEditFileRenameHandler OnRenameFile = null;
        public event UCEditFileDownLoadHandler OnDownloadFile = null;
        public event UCEditFilePropertityHandler OnPropertityFile = null;
        public event UCEditFileOpenHandler OnOpenFile = null;
        #endregion
        #region 公共属性
        private string _strParentGuid = string.Empty;
        public string ParentGuid
        {
            get { return this._strParentGuid; }
            set { this._strParentGuid = value; }
        }
        private bool _blUpdated = false;
        /// <summary>
        /// 数据是否更新
        /// </summary>
        public bool Updated
        {
            get
            {
                return this._blUpdated;
            }
            set
            {
                this._blUpdated = value;
            }
        }
        private bool _blReadonly = false;
        public bool ReadOnly
        {
            get { return this._blReadonly; }
            set 
            {
                this._blReadonly = value;
                //if (this.新增文件ToolStripMenuItem.Visible ^ !value) this.新增文件ToolStripMenuItem.Visible = !value;
                //if (this.左移ToolStripMenuItem.Visible ^ !value) this.左移ToolStripMenuItem.Visible = !value;
                //if (this.右移ToolStripMenuItem.Visible ^ !value) this.右移ToolStripMenuItem.Visible = !value;
                //if (this.删除ToolStripMenuItem.Visible ^ !value) this.删除ToolStripMenuItem.Visible = !value;
                //if (this.重命名ToolStripMenuItem.Visible ^ !value) this.重命名ToolStripMenuItem.Visible = !value;
            }
        }
        #endregion
        #region 系统消息提示
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 显示用户确认窗体
        /// </summary>
        /// <param name="sText">需要用户确认的内容</param>
        /// <returns>如果返回为tru,则用户选择了Yes表示确认通过，否则不通过</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "操作提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region 处理函数
        private bool Perint()
        {
            return true;
        }
        public bool BindFiles(List<FileEntity> list)
        {
            //显示文件
            Control con;
            while (this.panel1.Controls.Count > list.Count)
            {
                con = this.panel1.Controls[this.panel1.Controls.Count - 1];
                this.panel1.Controls.Remove(con);
                con.Dispose();
                con = null;
            }
            Common.UserControls.ucFile ucfile;
            while (this.panel1.Controls.Count < list.Count)
            {
                ucfile = new Common.UserControls.ucFile();
                ucfile.Name = this.Name + "_" + this.panel1.Controls.Count.ToString();
                ucfile.File_DbClick+=new UcFileHandler(ucfile_File_DbClick);
                this.panel1.Controls.Add(ucfile);
            }
            for (int i = 0; i < list.Count; i++)
            {
                ucfile = this.panel1.Controls[i] as Common.UserControls.ucFile;
                if (ucfile == null) continue;
                ucfile.PrimaryValue = list[i].GUID;
                ucfile.FileName = list[i].FileName;
                ucfile.SortID = list[i].SortID;
                ucfile.FileExtension = list[i].FileExs;
                ucfile.Creater = list[i].Creater;
                ucfile.CreaterTitle = "上传人";
                ucfile.CreateTime = Common.CommonFuns.FormatData.GetStringByDateTime(list[i].CreateTime, "yyyy-MM-dd HH:mm");
                ucfile.CreateTimeTitle = "上传时间";
                ucfile.ICOPath = Common.CommonFuns.GetFilePath(list[i].PreViewFileGuid, list[i].FileExs);
                ucfile.EntityGUID = list[i].EntityGuid;
                ucfile.PreViewFileGUID = list[i].PreViewFileGuid;
                ucfile.ParentControl = this.panel1;
                ucfile.BindData();
                ucfile.File_MouseRightClick += new Common.UserControls.UcFileHandler(ucfile_File_MouseRightClick);
                //设置文件类型，已经添加的文件不能在选择了，用户只能删除原有的才能选择
            }
            SetUcPosition();
            return true;
        }
        private void SetUcPosition()
        {
            int iTop;
            int iLeft;
            int iTopAdd = 1;
            int iLeftAdd = 3;
            iTop = iTopAdd;
            iLeft = 0;
            Control ucfile;
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                iLeft += iLeftAdd;
                ucfile = this.panel1.Controls[i];
                if (ucfile == null) continue;
                if (ucfile.Left != iLeft)
                    ucfile.Left = iLeft;
                if (ucfile.Top != iTop)
                    ucfile.Top = iTop;
                iLeft += ucfile.Width;
                if (i < (this.panel1.Controls.Count - 1))
                {
                    if ((iLeft + this.panel1.Controls[i + 1].Width) > this.panel1.Width)
                    {
                        //此时下一个加载已经超过了panle控件的宽度
                        iLeft = 0;
                        iTop += ucfile.Height + iTopAdd;
                    }
                }
            }
        }
        private void SetSelFile()
        {
            //初始化注销，此处需要修改成一个弹出框
            ////this.ucSelFile.ParentControl = this.splitContainer1.Panel2;
            //string strFile = this.tbFilePath.Text;
            //if (strFile.Length == 0)
            //{
            //    this.ucSelFile.Visible = false;
            //    return;
            //}
            //if (!File.Exists(strFile))
            //{
            //    this.ucSelFile.Visible = false;
            //    return;
            //}
            //this.ucSelFile.Visible = true;
            //try
            //{
            //    FileInfo file = new FileInfo(strFile);
            //    this.ucSelFile.FileName = file.Name;
            //    this.ucSelFile.CreaterTitle = "创建时间";
            //    this.ucSelFile.Creater = file.CreationTime.ToString("yyyy-MM-dd HH:mm");
            //    this.ucSelFile.CreateTimeTitle = "最后修改时间";
            //    this.ucSelFile.CreateTime = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm");
            //    //添加图标
            //    NewsManager.UserControls.ucRadioButtons.RadioButtonsItem item = this.ucRadioButtons1.GetSelectedItem();
            //    if (item == null || item.ICOGUID.Length == 0)
            //        this.ucSelFile.ICOPath = string.Empty;
            //    else
            //        this.ucSelFile.ICOPath = this.ICOMBllDAL.GetICOFile(item.ICOGUID, item.ICOFileExtension, true);
            //    this.ucSelFile.BindData();
            //}
            //catch (Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(this, ex);
            //    return;
            //}
        }
        private int GetMaxSortID()
        {
            int iSortID = -1;
            //判断是否此排序字段已经被使用了
            Common.UserControls.ucFile uc;
            foreach (Control con in this.panel1.Controls)
            {
                uc = con as Common.UserControls.ucFile;
                if (uc == null) continue;
                if (uc.SortID > iSortID)
                {
                    iSortID = uc.SortID;
                }
            }
            return iSortID + 1;
        }
        public Bitmap CreatePicView(string lcFilename, int lnHeight)
        {
            System.Drawing.Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(lcFilename);
                System.Drawing.Imaging.ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;
                lnRatio = (decimal)lnHeight / loBMP.Height;
                lnNewHeight = lnHeight;
                decimal lnTemp = loBMP.Width * lnRatio;
                lnNewWidth = (int)lnTemp;
                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.FillRectangle(Brushes.White, 0, 0, lnNewWidth, lnNewHeight);
                g.DrawImage(loBMP, 0, 0, lnNewWidth, lnNewHeight);
                loBMP.Dispose();
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return null;
            }
            return bmpOut;
        }
        #endregion
        #region 窗体控件事件
        private void btSelFile_Click(object sender, EventArgs e)
        {
            
        }
        protected void ucfile_File_MouseRightClick(Common.UserControls.ucFile sender)
        {
            SetMenuItemEnabled(0);
            this.contextMenuStrip1.Tag = sender;
            this.contextMenuStrip1.Show(Cursor.Position);
        }
        protected void ucfile_File_DbClick(ucFile uc)
        {
            if (uc == null) return;
            if (this.OnOpenFile == null || !this.OnOpenFile(uc.PrimaryValue == null ? string.Empty : uc.PrimaryValue.ToString()))
            {
                frmPicView frm = new frmPicView();
                frm._FileExs = uc.FileExtension;
                frm._FileGuid = uc.EntityGUID;
                frm.Show();
            }
        }
        #endregion
        #region 右键菜单事件
        private void SetMenuItemEnabled(int iType)
        {
            //设置右键菜单按钮样式，
            //0：都可以使用
            //1：只启用新增
            bool blEdit = !this.ReadOnly;
            if (iType == 0)
            {
                if (this.新增文件ToolStripMenuItem.Enabled ^ blEdit)
                    this.新增文件ToolStripMenuItem.Enabled = blEdit;
                if (this.左移ToolStripMenuItem.Enabled ^ blEdit)
                    this.左移ToolStripMenuItem.Enabled = blEdit;
                if (this.右移ToolStripMenuItem.Enabled ^ blEdit)
                    this.右移ToolStripMenuItem.Enabled = blEdit;
                if (this.删除ToolStripMenuItem.Enabled ^ blEdit)
                    this.删除ToolStripMenuItem.Enabled = blEdit;
                if (this.重命名ToolStripMenuItem.Enabled ^ blEdit)
                    this.重命名ToolStripMenuItem.Enabled = blEdit;

                if (!this.打开ToolStripMenuItem.Enabled)
                    this.打开ToolStripMenuItem.Enabled = true;
                if (!this.下载ToolStripMenuItem.Enabled)
                    this.下载ToolStripMenuItem.Enabled = true;
                if (!this.属性ToolStripMenuItem.Enabled)
                    this.属性ToolStripMenuItem.Enabled = true;

            }
            else if (iType == 1)
            {
                if (this.新增文件ToolStripMenuItem.Enabled ^ blEdit)
                    this.新增文件ToolStripMenuItem.Enabled = blEdit;
                if (this.打开ToolStripMenuItem.Enabled)
                    this.打开ToolStripMenuItem.Enabled = false;
                if (this.左移ToolStripMenuItem.Enabled)
                    this.左移ToolStripMenuItem.Enabled = false;
                if (this.右移ToolStripMenuItem.Enabled)
                    this.右移ToolStripMenuItem.Enabled = false;
                if (this.删除ToolStripMenuItem.Enabled)
                    this.删除ToolStripMenuItem.Enabled = false;
                if (this.重命名ToolStripMenuItem.Enabled)
                    this.重命名ToolStripMenuItem.Enabled = false;
                if (this.下载ToolStripMenuItem.Enabled)
                    this.下载ToolStripMenuItem.Enabled = false;
                if (this.属性ToolStripMenuItem.Enabled)
                    this.属性ToolStripMenuItem.Enabled = false;
            }
        }
        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null) return;
            if (this.OnDownloadFile == null || !this.OnDownloadFile(uc.PrimaryValue == null?string.Empty: uc.PrimaryValue.ToString()))
            {
                Common.CommonFuns.SaveFile(this, uc.EntityGUID, uc.FileName, uc.FileExtension);
            }
        }
        private void 新增文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilter = "位图文件(*.bmp)|*.bmp";
            strFilter += "|JPEG(*.jpeg;*.jpg;*.jpe;*.jfif)|*.jpeg;*.jpg;*.jpe;*.jfif";
            strFilter += "|GIF(*.gif)|*.gif";
            strFilter += "|TIFF(*.tif;*.tiff)|*.tif;*.tiff";
            strFilter += "|PNG(*.png)|*.png";
            strFilter += "|所有图片文件|*.bmp;*.jpeg;*.jpg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png";
            this.openFileDialog1.Filter = strFilter;
            this.openFileDialog1.FilterIndex = 6;//此属性序号是从1开始的，6即选中“所有图片文件”
            if (DialogResult.OK != this.openFileDialog1.ShowDialog(this))
                return;
            string strfile = this.openFileDialog1.FileName;
            //创建预览文件
            Bitmap im = this.CreatePicView(strfile, 100);
            if (im == null) return;
            string strPreViewFileGuid = Guid.NewGuid().ToString();//预览图片标识
            string strEntityGuid = Guid.NewGuid().ToString();//原始图片标识
            string strPreViewFilePath = Common.CommonFuns.GetFileCacheDir() + "\\" + strPreViewFileGuid + ".jpeg";
            try
            {
                im.Save(strPreViewFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            //显示文件信息
            frmFileInfo finfo = new frmFileInfo();
            finfo._PreViewFile = strPreViewFilePath;
            finfo._OrgFile = strfile;
            if (DialogResult.OK != finfo.ShowDialog(this)) return;
            #region 开始上传服务器
            Common.ProcessBar.frmProcessing fprocess = new Common.ProcessBar.frmProcessing();
            fprocess.frmProcessBar_Processing += new Common.ProcessBar.ProcessBar_Processing(fprocess_frmProcessBar_Processing);
            mPreViewFile = strPreViewFilePath;
            mFile = strfile;
            mPreViewFileGuid = strPreViewFileGuid;
            mEntityGuid = strEntityGuid;
            fprocess.ShowDialog(this);
            if (fprocess.Sucessful)
            {
                if (this.OnUploadFile != null)
                {
                    this.OnUploadFile(strPreViewFilePath, strfile, strPreViewFileGuid, strEntityGuid);
                }
            }
            #endregion
            this.SetSelFile();
        }
        string mPreViewFile = string.Empty;
        string mFile = string.Empty;
        string mPreViewFileGuid = string.Empty;
        string mEntityGuid = string.Empty;
        protected void fprocess_frmProcessBar_Processing(object sender, System.Windows.Forms.ProgressBar control, ref bool Sucessful)
        {
            Sucessful = false;
            control.Maximum = 2;
            //上传预览图片
            try
            {
                FileInfo fileInfo = new FileInfo(mPreViewFile);
                FileStream fs = fileInfo.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                fs = null;
                fileInfo = null;
                this.BllDAL.UploadFile(mPreViewFileGuid, bytes);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            control.Value = 1; Application.DoEvents();
            //上传原始图片
            try
            {
                FileInfo fileInfo = new FileInfo(mFile);
                FileStream fs = fileInfo.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                fs = null;
                fileInfo = null;
                this.BllDAL.UploadFile(mEntityGuid, bytes);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            control.Value = 2; Application.DoEvents();
            Sucessful = true;
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (!this.IsUserConfirm("您确定要删除文件\"" + uc.FileName + "\""))
                return;
            if (this.OnDelFile != null)
            {
                this.OnDelFile(uc.PrimaryValue.ToString());
            }
        }
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            frmFileRename frm = new frmFileRename();
            frm.FileName = uc.FileName;
            frm.FileExtension = uc.FileExtension;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (this.OnRenameFile != null)
            {
                this.OnRenameFile(uc.PrimaryValue.ToString(), uc.FileName, frm.FileName);
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null) return;
            if (this.OnOpenFile == null || !this.OnOpenFile(uc.PrimaryValue == null?string.Empty: uc.PrimaryValue.ToString()))
            {
                frmPicView frm = new frmPicView();
                frm._FileExs = uc.FileExtension;
                frm._FileGuid = uc.EntityGUID;
                frm.Show();
            }
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OnPropertityFile != null)
            {
                Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
                if (uc == null || uc.PrimaryValue == null) return;
                this.OnPropertityFile(uc.PrimaryValue.ToString());
            }
        }


        private void 左移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (this.OnMoveFile != null)
            {
                this.OnMoveFile(uc.PrimaryValue.ToString(), true);
            }
            
        }
        private void 右移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (this.OnMoveFile != null)
            {
                this.OnMoveFile(uc.PrimaryValue.ToString(), false);
            }
        }
        #endregion
        #region ucEditFile事件

        private void ucEditFile_Resize(object sender, EventArgs e)
        {
            SetUcPosition();
        }

        private void ucEditFile_Load(object sender, EventArgs e)
        {
            if (!this.Perint())
            {
                this.Enabled = false;
                return;
            }
        }
        #endregion
        #region 文件实体
        public class FileEntity
        {
            /// <summary>
            /// 所在数据行的标识
            /// </summary>
            public string GUID = string.Empty;
            public int SortID = -1;
            public string FileName = string.Empty;
            public string FileExs = string.Empty;
            public long FileSize = 0;
            public string PreViewFileGuid = string.Empty;
            public string EntityGuid = string.Empty;
            public bool Terminated = false;
            public string Creater = string.Empty;
            public string CreaterName = string.Empty;
            public DateTime CreateTime = DateTime.MinValue;
            public string Remark = string.Empty;
        }
        #endregion
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (this.ReadOnly) return;//只读情况下不能打开新增按钮
            //此时为右键，打开右键菜单，但是此种触发只能执行右键菜单的新增功能，有别于ucFile控件触发
            SetMenuItemEnabled(1);
            this.contextMenuStrip1.Tag = null;
            this.contextMenuStrip1.Show(Cursor.Position);
        }
    }
    public delegate bool UCEditFileUploadHandler(string sPreViewFile, string sFile, string sPreViewFileGuid, string sEntityGuid);
    public delegate bool UCEditFileDelHandler(string sGuid);
    public delegate bool UCEditFileMoveHandler(string sGuid,bool isLeft);
    public delegate bool UCEditFileRenameHandler(string sGuid,string sOrgName,string sNewName);
    public delegate bool UCEditFileDownLoadHandler(string sGuid);
    public delegate bool UCEditFilePropertityHandler(string sGuid);
    public delegate bool UCEditFileOpenHandler(string sGuid);
}
