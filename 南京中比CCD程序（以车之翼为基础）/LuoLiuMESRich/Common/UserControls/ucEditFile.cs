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
        #region ������������ʵ��
        private BLLDAL.Files _dal = null;
        /// <summary>
        /// ������������ʵ��
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
        #region �¼�
        public event UCEditFileUploadHandler OnUploadFile = null;
        public event UCEditFileDelHandler OnDelFile = null;
        public event UCEditFileMoveHandler OnMoveFile = null;
        public event UCEditFileRenameHandler OnRenameFile = null;
        public event UCEditFileDownLoadHandler OnDownloadFile = null;
        public event UCEditFilePropertityHandler OnPropertityFile = null;
        public event UCEditFileOpenHandler OnOpenFile = null;
        #endregion
        #region ��������
        private string _strParentGuid = string.Empty;
        public string ParentGuid
        {
            get { return this._strParentGuid; }
            set { this._strParentGuid = value; }
        }
        private bool _blUpdated = false;
        /// <summary>
        /// �����Ƿ����
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
                //if (this.�����ļ�ToolStripMenuItem.Visible ^ !value) this.�����ļ�ToolStripMenuItem.Visible = !value;
                //if (this.����ToolStripMenuItem.Visible ^ !value) this.����ToolStripMenuItem.Visible = !value;
                //if (this.����ToolStripMenuItem.Visible ^ !value) this.����ToolStripMenuItem.Visible = !value;
                //if (this.ɾ��ToolStripMenuItem.Visible ^ !value) this.ɾ��ToolStripMenuItem.Visible = !value;
                //if (this.������ToolStripMenuItem.Visible ^ !value) this.������ToolStripMenuItem.Visible = !value;
            }
        }
        #endregion
        #region ϵͳ��Ϣ��ʾ
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// ��ʾ�û�ȷ�ϴ���
        /// </summary>
        /// <param name="sText">��Ҫ�û�ȷ�ϵ�����</param>
        /// <returns>�������Ϊtru,���û�ѡ����Yes��ʾȷ��ͨ��������ͨ��</returns>
        public virtual bool IsUserConfirm(string sText)
        {
            return DialogResult.Yes == MessageBox.Show(this, sText, "������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        #endregion
        #region ������
        private bool Perint()
        {
            return true;
        }
        public bool BindFiles(List<FileEntity> list)
        {
            //��ʾ�ļ�
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
                ucfile.CreaterTitle = "�ϴ���";
                ucfile.CreateTime = Common.CommonFuns.FormatData.GetStringByDateTime(list[i].CreateTime, "yyyy-MM-dd HH:mm");
                ucfile.CreateTimeTitle = "�ϴ�ʱ��";
                ucfile.ICOPath = Common.CommonFuns.GetFilePath(list[i].PreViewFileGuid, list[i].FileExs);
                ucfile.EntityGUID = list[i].EntityGuid;
                ucfile.PreViewFileGUID = list[i].PreViewFileGuid;
                ucfile.ParentControl = this.panel1;
                ucfile.BindData();
                ucfile.File_MouseRightClick += new Common.UserControls.UcFileHandler(ucfile_File_MouseRightClick);
                //�����ļ����ͣ��Ѿ���ӵ��ļ�������ѡ���ˣ��û�ֻ��ɾ��ԭ�еĲ���ѡ��
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
                        //��ʱ��һ�������Ѿ�������panle�ؼ��Ŀ��
                        iLeft = 0;
                        iTop += ucfile.Height + iTopAdd;
                    }
                }
            }
        }
        private void SetSelFile()
        {
            //��ʼ��ע�����˴���Ҫ�޸ĳ�һ��������
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
            //    this.ucSelFile.CreaterTitle = "����ʱ��";
            //    this.ucSelFile.Creater = file.CreationTime.ToString("yyyy-MM-dd HH:mm");
            //    this.ucSelFile.CreateTimeTitle = "����޸�ʱ��";
            //    this.ucSelFile.CreateTime = file.LastWriteTime.ToString("yyyy-MM-dd HH:mm");
            //    //���ͼ��
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
            //�ж��Ƿ�������ֶ��Ѿ���ʹ����
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
        #region ����ؼ��¼�
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
        #region �Ҽ��˵��¼�
        private void SetMenuItemEnabled(int iType)
        {
            //�����Ҽ��˵���ť��ʽ��
            //0��������ʹ��
            //1��ֻ��������
            bool blEdit = !this.ReadOnly;
            if (iType == 0)
            {
                if (this.�����ļ�ToolStripMenuItem.Enabled ^ blEdit)
                    this.�����ļ�ToolStripMenuItem.Enabled = blEdit;
                if (this.����ToolStripMenuItem.Enabled ^ blEdit)
                    this.����ToolStripMenuItem.Enabled = blEdit;
                if (this.����ToolStripMenuItem.Enabled ^ blEdit)
                    this.����ToolStripMenuItem.Enabled = blEdit;
                if (this.ɾ��ToolStripMenuItem.Enabled ^ blEdit)
                    this.ɾ��ToolStripMenuItem.Enabled = blEdit;
                if (this.������ToolStripMenuItem.Enabled ^ blEdit)
                    this.������ToolStripMenuItem.Enabled = blEdit;

                if (!this.��ToolStripMenuItem.Enabled)
                    this.��ToolStripMenuItem.Enabled = true;
                if (!this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = true;
                if (!this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = true;

            }
            else if (iType == 1)
            {
                if (this.�����ļ�ToolStripMenuItem.Enabled ^ blEdit)
                    this.�����ļ�ToolStripMenuItem.Enabled = blEdit;
                if (this.��ToolStripMenuItem.Enabled)
                    this.��ToolStripMenuItem.Enabled = false;
                if (this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = false;
                if (this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = false;
                if (this.ɾ��ToolStripMenuItem.Enabled)
                    this.ɾ��ToolStripMenuItem.Enabled = false;
                if (this.������ToolStripMenuItem.Enabled)
                    this.������ToolStripMenuItem.Enabled = false;
                if (this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = false;
                if (this.����ToolStripMenuItem.Enabled)
                    this.����ToolStripMenuItem.Enabled = false;
            }
        }
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null) return;
            if (this.OnDownloadFile == null || !this.OnDownloadFile(uc.PrimaryValue == null?string.Empty: uc.PrimaryValue.ToString()))
            {
                Common.CommonFuns.SaveFile(this, uc.EntityGUID, uc.FileName, uc.FileExtension);
            }
        }
        private void �����ļ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strFilter = "λͼ�ļ�(*.bmp)|*.bmp";
            strFilter += "|JPEG(*.jpeg;*.jpg;*.jpe;*.jfif)|*.jpeg;*.jpg;*.jpe;*.jfif";
            strFilter += "|GIF(*.gif)|*.gif";
            strFilter += "|TIFF(*.tif;*.tiff)|*.tif;*.tiff";
            strFilter += "|PNG(*.png)|*.png";
            strFilter += "|����ͼƬ�ļ�|*.bmp;*.jpeg;*.jpg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png";
            this.openFileDialog1.Filter = strFilter;
            this.openFileDialog1.FilterIndex = 6;//����������Ǵ�1��ʼ�ģ�6��ѡ�С�����ͼƬ�ļ���
            if (DialogResult.OK != this.openFileDialog1.ShowDialog(this))
                return;
            string strfile = this.openFileDialog1.FileName;
            //����Ԥ���ļ�
            Bitmap im = this.CreatePicView(strfile, 100);
            if (im == null) return;
            string strPreViewFileGuid = Guid.NewGuid().ToString();//Ԥ��ͼƬ��ʶ
            string strEntityGuid = Guid.NewGuid().ToString();//ԭʼͼƬ��ʶ
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
            //��ʾ�ļ���Ϣ
            frmFileInfo finfo = new frmFileInfo();
            finfo._PreViewFile = strPreViewFilePath;
            finfo._OrgFile = strfile;
            if (DialogResult.OK != finfo.ShowDialog(this)) return;
            #region ��ʼ�ϴ�������
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
            //�ϴ�Ԥ��ͼƬ
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
            //�ϴ�ԭʼͼƬ
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
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (!this.IsUserConfirm("��ȷ��Ҫɾ���ļ�\"" + uc.FileName + "\""))
                return;
            if (this.OnDelFile != null)
            {
                this.OnDelFile(uc.PrimaryValue.ToString());
            }
        }
        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.OnPropertityFile != null)
            {
                Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
                if (uc == null || uc.PrimaryValue == null) return;
                this.OnPropertityFile(uc.PrimaryValue.ToString());
            }
        }


        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (this.OnMoveFile != null)
            {
                this.OnMoveFile(uc.PrimaryValue.ToString(), true);
            }
            
        }
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.UserControls.ucFile uc = this.contextMenuStrip1.Tag as Common.UserControls.ucFile;
            if (uc == null || uc.PrimaryValue == null) return;
            if (this.OnMoveFile != null)
            {
                this.OnMoveFile(uc.PrimaryValue.ToString(), false);
            }
        }
        #endregion
        #region ucEditFile�¼�

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
        #region �ļ�ʵ��
        public class FileEntity
        {
            /// <summary>
            /// ���������еı�ʶ
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
            if (this.ReadOnly) return;//ֻ������²��ܴ�������ť
            //��ʱΪ�Ҽ������Ҽ��˵������Ǵ��ִ���ֻ��ִ���Ҽ��˵����������ܣ��б���ucFile�ؼ�����
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
