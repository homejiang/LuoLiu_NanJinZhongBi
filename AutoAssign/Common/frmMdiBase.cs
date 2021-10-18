using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmMdiBase : frmMainBase
    {
        public frmMdiBase()
        {
            InitializeComponent();
        }
        #region MDI����TabControl�ؼ�
        //MDI�������ڴ򿪴����tabcontrol����
        public TabControl _TabControl = null;
        #endregion
        #region MDI����PictureBox�ؼ�
        //MDI�������ڹرմ����tabcontrol����
        private PictureBox _pictureBox = null;
        public PictureBox _PictureBox
        {
            get { return this._pictureBox; }
            set
            {
                if (value != null)
                {
                    value.Click += new EventHandler(value_Click);
                    value.MouseHover += new EventHandler(value_MouseHover);
                    value.MouseLeave += new EventHandler(value_MouseLeave);
                }
            }
        }
        protected void value_Click(object sender, EventArgs e)
        {
            this.CloseChildForm();
        }
        protected void value_MouseHover(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
                pic.BorderStyle = BorderStyle.FixedSingle;
        }
        protected void value_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic != null)
                pic.BorderStyle = BorderStyle.None;
        }
        #endregion
        #region ĸ���幫���¼�
        /// <summary>
        /// �򿪴���ʵ��
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="frmNew"></param>
        /// <returns></returns>
        public bool ShowChildForm(string strTitle, frmBase frmNew)
        {
            //if (this._TabControl == null)
            //{
            //    this.ShowMsg("MDI����δָ����");
            //}
            //int iIndex = this.FindFormByTitle(strTitle);
            //if (iIndex >= 0)
            //{
            //    this._TabControl.SelectedIndex = iIndex;
            //    //����ˢ������
            //    frmBase frmtemp = null;
            //    foreach (Control con in this._TabControl.TabPages[iIndex].Controls)
            //    {
            //        frmtemp = con as frmBase;
            //        if (frmtemp != null)
            //        {
            //            frmtemp.RefreshParetForm(null);
            //            break;
            //        }
            //    }
            //    return true;
            //}
            //frmNew.FormBorderStyle = FormBorderStyle.None;
            ////frmNew.Dock = DockStyle.Fill;
            //frmNew.TopLevel = false;
            //frmNew.ParentMDI = this;
            ////���TABҳ
            //System.Windows.Forms.TabPage newTab = new TabPage();
            //newTab.Text = strTitle;
            //newTab.Controls.Add(frmNew);
            //this._TabControl.Controls.Add(newTab);
            //frmNew.Dock = DockStyle.Fill;
            //frmNew.Show();
            //this._TabControl.SelectedIndex = this._TabControl.TabPages.Count - 1;
            //return true;
            return ShowChildForm(strTitle, frmNew, false);
        }
        public bool ShowChildForm(string strTitle, frmBase frmNew,bool blNew)
        {
            if (this._TabControl == null)
            {
                this.ShowMsg("MDI����δָ����");
            }
            int iIndex = this.FindFormByTitle(strTitle);
            if (iIndex >= 0)
            {
                if (blNew)
                {
                    int iCount = 1;
                    string strNewTitle=strTitle;
                    while (true)
                    {
                        strNewTitle = strTitle + "(����" + iCount.ToString() + ")";
                        iIndex = this.FindFormByTitle(strNewTitle);
                        if (iIndex < 0)
                            break;
                        iCount++;
                        if (iCount > 200) break;
                    }
                    strTitle = strNewTitle;
                }
                else
                {
                    this._TabControl.SelectedIndex = iIndex;
                    //����ˢ������
                    frmBase frmtemp = null;
                    foreach (Control con in this._TabControl.TabPages[iIndex].Controls)
                    {
                        frmtemp = con as frmBase;
                        if (frmtemp != null)
                        {
                            frmtemp.RefreshParetForm(null);
                            break;
                        }
                    }
                    return true;
                }
            }
            frmNew.FormBorderStyle = FormBorderStyle.None;
            //frmNew.Dock = DockStyle.Fill;
            frmNew.TopLevel = false;
            frmNew.ParentMDI = this;
            //���TABҳ
            System.Windows.Forms.TabPage newTab = new TabPage();
            newTab.Text = strTitle;
            newTab.Controls.Add(frmNew);
            this._TabControl.Controls.Add(newTab);
            frmNew.Dock = DockStyle.Fill;
            frmNew.Show();
            this._TabControl.SelectedIndex = this._TabControl.TabPages.Count - 1;
            return true;
        }
        /// <summary>
        /// ��������ʾ�ڵ�1��tabpage�ϣ����ֻ�������������ʱ����
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="frmNew"></param>
        /// <returns></returns>
        public bool ShowMainForm(string strTitle, frmBase frmNew)
        {
            if (this._TabControl == null)
            {
                this.ShowMsg("MDI����δָ����");
            }
            if (this._TabControl.TabPages.Count == 0) return false;
            frmNew.FormBorderStyle = FormBorderStyle.None;
            //frmNew.Dock = DockStyle.Fill;
            frmNew.TopLevel = false;
            frmNew.ParentMDI = this;
            //���TABҳ
            System.Windows.Forms.TabPage tab = this._TabControl.TabPages[0];
            tab.Text = strTitle;
            tab.Controls.Add(frmNew);
            frmNew.Dock = DockStyle.Fill;
            frmNew.Show();
            this._TabControl.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// �ر��Ӵ���
        /// </summary>
        public bool CloseChildForm()
        {
            return this.CloseChildForm(true);
        }
        /// <summary>
        /// �ر��Ӵ���
        /// </summary>
        /// <param name="blConfirmChanged">�Ƿ�У�������Ѿ����޸�</param>
        /// <returns></returns>
        public bool CloseChildForm(bool blConfirmChanged)
        {
            if (_TabControl == null)
                return false;
            if (this._TabControl.TabPages.Count == 0) return false;
            if (this._TabControl.SelectedIndex <= 0) return false;
            TabPage tb = this._TabControl.TabPages[this._TabControl.SelectedIndex];
            if (tb.Controls.Count == 0) return false;
            frmBase frm = tb.Controls[0] as frmBase;
            if (frm == null) return false;
            if (blConfirmChanged)
            {
                if (!frm.CheckClose())
                    return false;
            }
            frm.MyFormClose();
            this._TabControl.TabPages.Remove(tb);
            //���ü����
            if (this._TabControl.TabPages.Count > 0)
                this._TabControl.SelectedIndex = this._TabControl.TabPages.Count - 1;
            return true;
        }
        /// <summary>
        /// ���ұ���һ���Ĵ���,���ظô������ڵ�tagPage���
        /// </summary>
        /// <param name="strTitle">����title</param>
        /// <returns></returns>
        private int FindFormByTitle(string strTitle)
        {
            if (this._TabControl == null) return -1;
            for (int i = 0; i < this._TabControl.TabPages.Count; i++)
            {
                if (this._TabControl.TabPages[i].Controls.Count == 0)
                    continue;
                if (this._TabControl.TabPages[i].Text == strTitle)
                    return i;
            }
            return -1;
        }
        #endregion
        #region ��������
        /// <summary>
        /// ���Ϊ���ʾ����������������򿪴˴����
        /// </summary>
        public bool OpendByChildForm = true;
        #endregion
        #region ĸ����ر��¼�
        protected override void OnClosing(CancelEventArgs e)
        {
            //ĸ����ر�ʱҪ���ø��Ӵ���Ĺرպ���
            if (_TabControl != null)
            {
                frmBase frm;
                foreach (TabPage page in _TabControl.TabPages)
                {
                    if (page.Controls.Count > 0)
                    {
                        frm = page.Controls[0] as frmBase;
                        if (frm != null)
                        {
                            frm.MyFormClose();
                        }
                    }
                }
            }
            base.OnClosing(e);
        }
        #endregion
        #region ����MDI����ı���
        public virtual void SetMdiCaption()
        {

        }
        #endregion
    }
}