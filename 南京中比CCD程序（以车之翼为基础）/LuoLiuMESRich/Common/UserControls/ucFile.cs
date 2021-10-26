using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ErrorService;

namespace Common.UserControls
{
    public partial class ucFile : UserControl
    {
        public ucFile()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �ؼ������¼�
        /// </summary>
        public event UcFileHandler File_Click = null;
        /// <summary>
        /// �ؼ�˫���¼�
        /// </summary>
        public event UcFileHandler File_DbClick = null;
        public event UcFileHandler File_MouseRightClick = null;
        #region ��������
        private string _strEntityGUID = string.Empty;
        /// <summary>
        /// �ļ�GUID
        /// </summary>
        public string EntityGUID
        {
            get { return this._strEntityGUID; }
            set { this._strEntityGUID = value; }
        }
        private string _strPreViewFileGUID = string.Empty;
        /// <summary>
        /// �ļ�GUID
        /// </summary>
        public string PreViewFileGUID
        {
            get { return this._strPreViewFileGUID; }
            set { this._strPreViewFileGUID = value; }
        }
        private string _strICOPath = string.Empty;
        /// <summary>
        /// ͼ���ļ�·��
        /// </summary>
        public string ICOPath
        {
            get { return this._strICOPath; }
            set { this._strICOPath = value; }
        }
        private string _strFileName = string.Empty;
        /// <summary>
        /// �ļ�����
        /// </summary>
        public string FileName
        {
            get { return this._strFileName; }
            set { this._strFileName = value; }
        }
        private string _strFileTypeCode = string.Empty;
        /// <summary>
        /// �ļ����ͱ���
        /// </summary>
        public string FileTypeCode
        {
            get { return this._strFileTypeCode; }
            set { this._strFileTypeCode = value; }
        }
        private string _strFileExtension = string.Empty;
        /// <summary>
        /// �ļ���׺
        /// </summary>
        public string FileExtension
        {
            get { return this._strFileExtension; }
            set { this._strFileExtension = value; }
        }
        private string _strCreater = string.Empty;
        /// <summary>
        /// �ϴ���
        /// </summary>
        public string Creater
        {
            get { return this._strCreater; }
            set { this._strCreater = value; }
        }
        private string _strCreateTime = string.Empty;
        /// <summary>
        /// �ϴ�ʱ��
        /// </summary>
        public string CreateTime
        {
            get { return this._strCreateTime; }
            set { this._strCreateTime = value; }
        }
        private int _iSortID = -1;
        public int SortID
        {
            get { return this._iSortID; }
            set { this._iSortID = value; }
        }
        private Control _parentControl = null;
        /// <summary>
        /// �����ؼ�
        /// </summary>
        public Control ParentControl
        {
            get
            {
                return this._parentControl;
            }
            set
            {
                this._parentControl = value;
            }
        }
        private bool _isFocused = false;
        public bool IsFocused
        {
            get { return this._isFocused; }
            set { this._isFocused = value; }
        }
        private bool _isShowTitle = true;
        /// <summary>
        /// �Ƿ���ʾ�ļ���
        /// </summary>
        public bool IsShowTitle
        {
            get { return this._isShowTitle; }
            set { this._isShowTitle = value; }
        }
        private bool _isShowCreateInfo = true;
        /// <summary>
        /// �Ƿ񴴽���Ϣ
        /// </summary>
        public bool IsShowCreateInfo
        {
            get { return this._isShowCreateInfo; }
            set { this._isShowCreateInfo = value; }
        }
        private object _objPrimaryValue = null;
        /// <summary>
        /// �ؼ���ֵ
        /// </summary>
        public object PrimaryValue
        {
            get { return this._objPrimaryValue; }
            set { this._objPrimaryValue = value; }
        }
        private string _strCreaterTitle = "������";
        /// <summary>
        /// �����˱���
        /// </summary>
        public string CreaterTitle
        {
            get { return this._strCreaterTitle; }
            set { this._strCreaterTitle = value; }
        }
        private string _strCreateTimeTitle = "����ʱ��";
        /// <summary>
        /// ����ʱ�����
        /// </summary>
        public string CreateTimeTitle
        {
            get { return this._strCreateTimeTitle; }
            set { this._strCreateTimeTitle = value; }
        }
        private int _iFilesCount = 0;
        /// <summary>
        /// ��ʾ�ļ�����
        /// </summary>
        public int FilesCount
        {
            get { return this._iFilesCount; }
            set { this._iFilesCount = value; }
        }
        private bool _boShowFilesCount = false;
        /// <summary>
        /// �Ƿ���ʾ�ļ���,Ĭ�ϲ���ʾ
        /// </summary>
        public bool IsShowFilesCount
        {
            get { return this._boShowFilesCount; }
            set { this._boShowFilesCount = value; }
        }
        private bool _blIsPower = false;
        /// <summary>
        /// �Ƿ���Ȩ��Լ��
        /// </summary>
        public bool IsPower
        {
            get { return this._blIsPower; }
            set { this._blIsPower = value; }
        }
        private Orientation _orientation = Orientation.Vertical;
        //�ļ�����������ʾλ��
        public Orientation Orientation
        {
            get { return this._orientation; }
            set { this._orientation = value; }
        }
        #endregion
        #region ������
        /// <summary>
        /// �����ַ��ܵ��ֽ�����ȡ��ʾ�ַ���Ҫ�Ŀ��
        /// </summary>
        /// <param name="sText"></param>
        /// <returns></returns>
        private int GetWidthByString(string sText)
        {
            decimal decByteW = 6.0438M;//ÿ���ֽ�ռ�ÿ��
            decimal decTotal = decByteW * Convert.ToDecimal(System.Text.Encoding.Default.GetByteCount(sText));
            int iReturn = (int)decTotal;
            if ((decTotal - iReturn) != 0)
                iReturn++;;
            return iReturn;
        }
        public bool BindData()
        {
            if (this.Orientation == Orientation.Horizontal)
                return this.BindHorizontal();
            else return this.BindVertical();
        }
        /// <summary>
        /// ������������
        /// </summary>
        private bool BindVertical()
        {
            if (this.picICO.Dock != DockStyle.Top)
                this.picICO.Dock = DockStyle.Top;
            if (this.panTitle.Dock != DockStyle.Bottom)
                this.panTitle.Dock = DockStyle.Bottom;
            //��ӳ���
            // Label�ؼ����˿��೤
            const int LabelPadLeft = 5;
            //ͼ���������������Ĵ�С
            const int ICOWdithAdd = 14;
            //ͼ���������������Ĵ�С
            const int ICOHeightAdd = 1;
            const int UCHeightAdd = 4;
            int iUcWidth;
            if (this.ICOPath.Length == 0 || !File.Exists(this.ICOPath))
            {
                this.picICO.Image = global::Common.Properties.Resources.unkown;
                iUcWidth = global::Common.Properties.Resources.unkown.Width + ICOWdithAdd;
                this.picICO.Height = global::Common.Properties.Resources.unkown.Height + ICOHeightAdd;//���ø߶�
            }
            else
            {
                //��ʱ�û�������ͼ��
                try
                {
                    this.picICO.Image = Image.FromFile(this.ICOPath);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                //���ÿؼ���ȡ��߶�
                iUcWidth = this.picICO.Image.Width + +ICOWdithAdd;
                this.picICO.Height = this.picICO.Image.Height + ICOHeightAdd;
            }
            this.DrowICOFileCount(this.picICO.Image);
            this.DrawICOPower(this.picICO.Image);
            int iTempWidth = 0;
            int iPanHeight = 0;
            //���ÿ��
            if (this.IsShowTitle)
            {
                this.labFileName.Visible = true;
                this.labFileName.Text = this.FileName;
                iTempWidth = this.GetWidthByString(this.FileName) + LabelPadLeft * 2;
                if (iTempWidth > iUcWidth)
                    iUcWidth = iTempWidth;
                iPanHeight += 20;
                this.labFileName.Visible = true;
            }
            else
            {
                this.labFileName.Visible = false;
            }
            if (this.IsShowCreateInfo)
            {
                this.labCreater.Text = this.CreaterTitle + ":" + this.Creater;
                iTempWidth = this.GetWidthByString(this.labCreater.Text) + LabelPadLeft * 2; ;
                if (iTempWidth > iUcWidth)
                    iUcWidth = iTempWidth;
                this.labCreateTime.Text = this.CreateTimeTitle + ":" + this.CreateTime;
                iTempWidth = this.GetWidthByString(this.labCreateTime.Text) + LabelPadLeft * 2; ;
                if (iTempWidth > iUcWidth)
                    iUcWidth = iTempWidth;
                iPanHeight += 29;
                this.labCreater.Visible = true;
                this.labCreateTime.Visible = true;
            }
            else
            {
                this.labCreater.Visible = false;
                this.labCreateTime.Visible = false;
            }
            this.Width = iUcWidth + 2;//2Ϊ�ؼ���Border���
            this.panTitle.Height = iPanHeight;
            //���ø߶�
            this.Height = this.panTitle.Height + this.picICO.Height + UCHeightAdd;
            return true;
        }
        /// <summary>
        /// ���ú�������
        /// </summary>
        private bool BindHorizontal()
        {
            if (this.picICO.Dock != DockStyle.Left)
                this.picICO.Dock = DockStyle.Left;
            if (this.panTitle.Dock != DockStyle.Right)
                this.panTitle.Dock = DockStyle.Right;
            //��ӳ���
            // Label�ؼ����˿��೤
            const int LabelPadLeft = 5;
            //ͼ���������������Ĵ�С
            const int ICOWdithAdd = 1;
            //ͼ���������������Ĵ�С
            const int ICOHeightAdd = 3;
            //const int UCWidthAdd = 4;
            int iUcWidth;
            int iUcHeight;
            if (this.ICOPath.Length == 0 || !File.Exists(this.ICOPath))
            {
                this.picICO.Image = global::Common.Properties.Resources.unkown;
                iUcWidth = global::Common.Properties.Resources.unkown.Width + ICOWdithAdd;
                iUcHeight = global::Common.Properties.Resources.unkown.Height + ICOHeightAdd;
                //this.Height = iUcHeight;
            }
            else
            {
                //��ʱ�û�������ͼ��
                try
                {
                    this.picICO.Image = Image.FromFile(this.ICOPath);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                //���ÿؼ���ȡ��߶�
                iUcWidth = this.picICO.Image.Width + +ICOWdithAdd;
                iUcHeight = global::Common.Properties.Resources.unkown.Height + ICOHeightAdd;
                //this.Height = iUcHeight;
            }
            this.DrowICOFileCount(this.picICO.Image);
            this.DrawICOPower(this.picICO.Image);
            int iTempWidth = 0;
            int iPanHeight = 0;
            int iPanWidth = 0;
            //���ÿ��
            if (this.IsShowTitle)
            {
                this.labFileName.Visible = true;
                this.labFileName.Text = this.FileName;
                iTempWidth = this.GetWidthByString(this.FileName) + LabelPadLeft * 2;
                if (iTempWidth > iPanWidth)
                    iPanWidth = iTempWidth;
                iPanHeight += 20;
                this.labFileName.Visible = true;
            }
            else
            {
                this.labFileName.Visible = false;
            }
            if (this.IsShowCreateInfo)
            {
                this.labCreater.Text = this.CreaterTitle + ":" + this.Creater;
                iTempWidth = this.GetWidthByString(this.labCreater.Text) + LabelPadLeft * 2; ;
                if (iTempWidth > iPanWidth)
                    iPanWidth = iTempWidth;
                this.labCreateTime.Text = this.CreateTimeTitle + ":" + this.CreateTime;
                iTempWidth = this.GetWidthByString(this.labCreateTime.Text) + LabelPadLeft * 2; ;
                if (iTempWidth > iPanWidth)
                    iPanWidth = iTempWidth;
                iPanHeight += 29;
                this.labCreater.Visible = true;
                this.labCreateTime.Visible = true;
            }
            else
            {
                this.labCreater.Visible = false;
                this.labCreateTime.Visible = false;
            }
            this.picICO.Width = iUcWidth;
            this.Width = iUcWidth + iPanWidth + 2;//2Ϊ�ؼ���Border���
            this.panTitle.Height = iPanHeight;
            this.panTitle.Width = iPanWidth;
            //���ø߶�
            this.Height = iUcHeight > iPanHeight ? iUcHeight : iPanHeight;
            return true;
        }
        private void DrowICOFileCount(Image image)
        {
            if (!this.IsShowFilesCount || this.FilesCount == 0) return;
            string strText = this.FilesCount.ToString();
            if (strText.Length > 3) return;//ֻ
            System.Drawing.Graphics gpcMy = System.Drawing.Graphics.FromImage(image); //���뻭ͼ����
            Font font = new Font(new FontFamily("Arial"), 13, FontStyle.Bold);
            gpcMy.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (strText.Length == 1)
            {
                gpcMy.FillEllipse(Brushes.Red, image.Width - 18, 1, 18, 18);
                gpcMy.DrawString(strText, font, Brushes.White, new PointF(image.Width - 14, 2));
            }
            else if (strText.Length == 2)
            {
                gpcMy.FillEllipse(Brushes.Red, image.Width - 21, 1, 21, 18);
                gpcMy.DrawString(strText, font, Brushes.White, new PointF(image.Width - 18, 2));
            }
            else if (strText.Length == 3)
            {
                gpcMy.FillEllipse(Brushes.Red, image.Width - 30, 1, 30, 18);
                gpcMy.DrawString(strText, font, Brushes.White, new PointF(image.Width - 26, 2));
            }
            gpcMy.Dispose();
            gpcMy = null;
        }
        private void DrawICOPower(Image image)
        {
            if (!this.IsPower) return;
            System.Drawing.Graphics gpcMy = System.Drawing.Graphics.FromImage(image); //���뻭ͼ����
            Font font = new Font(new FontFamily("Arial"), 13, FontStyle.Bold);
            gpcMy.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gpcMy.FillEllipse(Brushes.Yellow, image.Width - 18, image.Height - 18, 18, 18);
            gpcMy.DrawString("��", font, Brushes.Red, new PointF(image.Width - 14, image.Height - 16));
            gpcMy.Dispose();
            gpcMy = null;
        }
        public void SetFocus(bool isFocus)
        {
            this.BorderStyle = isFocus ? BorderStyle.FixedSingle : BorderStyle.None;
            this.panTitle.BackColor = isFocus ? ColorTranslator.FromHtml("#316AC5") : Color.White;
            this.labFileName.ForeColor = isFocus ? Color.White : Color.Black;
            this.labCreater.ForeColor = this.labCreateTime.ForeColor = isFocus ? Color.White : Color.Gray;
            this.IsFocused = isFocus;
        }
        public void DisposePicture()
        {
            this.picICO.Dispose();
        }
        #endregion
        #region ��������
        public void SetToolTip(ToolTip tip,string strMsg)
        {
            tip.SetToolTip(this.picICO, strMsg);
            if (this.IsShowTitle)
                tip.SetToolTip(this.labFileName, strMsg);
            if (this.IsShowCreateInfo)
            {
                tip.SetToolTip(this.labCreater, strMsg);
                tip.SetToolTip(this.labCreateTime, strMsg);
            }
            if (this.IsShowCreateInfo || this.IsShowTitle)
                tip.SetToolTip(this.panTitle, strMsg);
        }
        #endregion
        private void ucFile_Load(object sender, EventArgs e)
        {
            this.picICO.Click += new EventHandler(ucFile_Click);
            this.panTitle.Click += new EventHandler(ucFile_Click);
            this.labFileName.Click += new EventHandler(ucFile_Click);
            this.labCreater.Click += new EventHandler(ucFile_Click);
            this.labCreateTime.Click += new EventHandler(ucFile_Click);
            //���˫���¼�
            this.picICO.DoubleClick += new EventHandler(ucFile_DoubleClick);
            this.panTitle.DoubleClick += new EventHandler(ucFile_DoubleClick);
            this.labFileName.DoubleClick += new EventHandler(ucFile_DoubleClick);
            this.labCreater.DoubleClick += new EventHandler(ucFile_DoubleClick);
            this.labCreateTime.DoubleClick += new EventHandler(ucFile_DoubleClick);
            //����Ҽ��¼�
            this.picICO.MouseClick += new MouseEventHandler(ucFile_MouseClick);
            this.panTitle.MouseClick += new MouseEventHandler(ucFile_MouseClick);
            this.labFileName.MouseClick += new MouseEventHandler(ucFile_MouseClick);
            this.labCreater.MouseClick += new MouseEventHandler(ucFile_MouseClick);
            this.labCreateTime.MouseClick += new MouseEventHandler(ucFile_MouseClick);
            //this.BindData();
        }

        private void ucFile_Click(object sender, EventArgs e)
        {
            if (this.ParentControl != null)
            {
                ucFile uc;
                foreach (Control con in this.ParentControl.Controls)
                {
                    uc = con as ucFile;
                    if (uc == null) continue;
                    if (uc.Equals(this)) continue;
                    if (uc.IsFocused)
                        uc.SetFocus(false);
                }
                if (!this.IsFocused)
                    this.SetFocus(true);
            }
            if (this.File_Click != null)
                this.File_Click(this);
        }

        private void ucFile_DoubleClick(object sender, EventArgs e)
        {
            if (this.ParentControl != null)
            {
                ucFile uc;
                foreach (Control con in this.ParentControl.Controls)
                {
                    uc = con as ucFile;
                    if (uc == null) continue;
                    if (uc.Equals(this)) continue;
                    if (uc.IsFocused)
                        uc.SetFocus(false);
                }
                if (!this.IsFocused)
                    this.SetFocus(true);
            }
            if (this.File_DbClick != null)
                this.File_DbClick(this);
        }

        private void ucFile_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (this.ParentControl != null)
            {
                ucFile uc;
                foreach (Control con in this.ParentControl.Controls)
                {
                    uc = con as ucFile;
                    if (uc == null) continue;
                    if (uc.Equals(this)) continue;
                    if (uc.IsFocused)
                        uc.SetFocus(false);
                }
                if (!this.IsFocused)
                    this.SetFocus(true);
            }
            if (this.File_MouseRightClick != null)
                File_MouseRightClick(this);
        }
    }
    public delegate void UcFileHandler(ucFile sender);
}
