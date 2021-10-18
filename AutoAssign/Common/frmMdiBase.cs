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
        #region MDI窗体TabControl控件
        //MDI窗体用于打开窗体的tabcontrol容器
        public TabControl _TabControl = null;
        #endregion
        #region MDI窗体PictureBox控件
        //MDI窗体用于关闭窗体的tabcontrol容器
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
        #region 母窗体公共事件
        /// <summary>
        /// 打开窗体实现
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="frmNew"></param>
        /// <returns></returns>
        public bool ShowChildForm(string strTitle, frmBase frmNew)
        {
            //if (this._TabControl == null)
            //{
            //    this.ShowMsg("MDI容器未指定。");
            //}
            //int iIndex = this.FindFormByTitle(strTitle);
            //if (iIndex >= 0)
            //{
            //    this._TabControl.SelectedIndex = iIndex;
            //    //重新刷新数据
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
            ////添加TAB页
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
                this.ShowMsg("MDI容器未指定。");
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
                        strNewTitle = strTitle + "(副本" + iCount.ToString() + ")";
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
                    //重新刷新数据
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
            //添加TAB页
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
        /// 将窗体显示在第1个tabpage上，这个只用于主窗体加载时调用
        /// </summary>
        /// <param name="strTitle"></param>
        /// <param name="frmNew"></param>
        /// <returns></returns>
        public bool ShowMainForm(string strTitle, frmBase frmNew)
        {
            if (this._TabControl == null)
            {
                this.ShowMsg("MDI容器未指定。");
            }
            if (this._TabControl.TabPages.Count == 0) return false;
            frmNew.FormBorderStyle = FormBorderStyle.None;
            //frmNew.Dock = DockStyle.Fill;
            frmNew.TopLevel = false;
            frmNew.ParentMDI = this;
            //添加TAB页
            System.Windows.Forms.TabPage tab = this._TabControl.TabPages[0];
            tab.Text = strTitle;
            tab.Controls.Add(frmNew);
            frmNew.Dock = DockStyle.Fill;
            frmNew.Show();
            this._TabControl.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// 关闭子窗体
        /// </summary>
        public bool CloseChildForm()
        {
            return this.CloseChildForm(true);
        }
        /// <summary>
        /// 关闭子窗体
        /// </summary>
        /// <param name="blConfirmChanged">是否校验数据已经被修改</param>
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
            //设置激活窗体
            if (this._TabControl.TabPages.Count > 0)
                this._TabControl.SelectedIndex = this._TabControl.TabPages.Count - 1;
            return true;
        }
        /// <summary>
        /// 查找标题一样的窗体,返回该窗体所在的tagPage序号
        /// </summary>
        /// <param name="strTitle">窗体title</param>
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
        #region 公共属性
        /// <summary>
        /// 如果为真表示是生产界面或检测界面打开此窗体的
        /// </summary>
        public bool OpendByChildForm = true;
        #endregion
        #region 母窗体关闭事件
        protected override void OnClosing(CancelEventArgs e)
        {
            //母窗体关闭时要调用各子窗体的关闭函数
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
        #region 设置MDI窗体的标题
        public virtual void SetMdiCaption()
        {

        }
        #endregion
    }
}