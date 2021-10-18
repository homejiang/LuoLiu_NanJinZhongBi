using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.RecordPagesManager
{
    public partial class ucRecordPage : UserControl
    {
        Form _ParentForm = null;
        public event GoToPage GoToPage_Going = null;
        public ucRecordPage()
        {
            InitializeComponent();
        }
        public void SetParentForm(Form form)
        {
            _ParentForm = form;
            string strName = form.GetType().ToString();
            //从数据库查询出设置信息
            int iCount = this.GetRecordsCountPerPage(strName);
            this.SetPageRowsCount(iCount);
        }
        public int GetRecordsCountPerPage(string sFormFullName)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT PageRowsCount FROM Common_RecordPagesManager WHERE UserCode='{0}' AND FormFullName='{1}'"
                    , Common.CurrentUserInfo.UserCode, sFormFullName.Replace("''", "")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return 200;
            }
            if (dt.Rows.Count == 0) return 200;
            if (dt.Rows[0][0].Equals(DBNull.Value)) return 200;
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkPerPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sMsg;
            if (!this.PrePage(out sMsg))
            {
                this.ShowMsg(sMsg);
            }
        }

        private void linkNextPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string sMsg;
            if (!this.NextPage(out sMsg))
            {
                this.ShowMsg(sMsg);
            }
        }

        private void linkGoPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmJumpTo frm = new frmJumpTo(10000);
            if (frm.ShowDialog(this) != DialogResult.OK) return;
            string strMsg;
            if (!this.SkipPageIndex(frm.CurrIndex, out strMsg))
                this.ShowMsg(strMsg);
        }

        private void linkPageCount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPageRowsCount frm = new frmPageRowsCount(_ParentForm.GetType().ToString());
            frm.PageRowsCount = this.PageRowsCount;
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.SetPageRowsCount(frm.PageRowsCount);
        }
        #region 功能实现
        public int PageRowsCount = 200;
        /// <summary>
        /// 页数，从1开始计数
        /// </summary>
        public int PageIndex = 0;
        /// <summary>
        /// 总数据量
        /// </summary>
        int TotalRowCount = 0;
        private void ShowPageIndexDesc()
        {
            if (this.tbPageIndex == null) return;
            int iPgCnt = GetPageCount();
            tbPageIndex.Text = string.Format("{0}/{1}", this.PageIndex, iPgCnt);
        }
        private int GetPageCount()
        {
            if (PageRowsCount <= 0) return 0;
            int iPgCnt = this.TotalRowCount / PageRowsCount;
            if ((this.TotalRowCount % PageRowsCount) > 0)
                iPgCnt++;
            return iPgCnt;
        }
        private void SetTotalRowsCount(int iCount)
        {
            this.TotalRowCount = iCount;
            ShowPageIndexDesc();
        }
        #region 功能函数
        private bool SkipPageIndex(int iPageIndex, out string sMsg)
        {
            int iMin = (iPageIndex - 1) * this.PageRowsCount + 1;
            if (iMin > this.TotalRowCount)
            {
                sMsg = "无法跳到指定页。";
                return false;
            }
            sMsg = "";
            int iMax = iMin + this.PageRowsCount;
            this.PageIndex = iPageIndex;
            ShowPageIndexDesc();
            if (this.GoToPage_Going != null)
                this.GoToPage_Going(iMin, iMax);
            return true;
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        public bool NextPage(out string sMsg)
        {
            int iIndex = PageIndex + 1;
            int iMin = (iIndex - 1) * this.PageRowsCount + 1;
            if (iMin > this.TotalRowCount)
            {
                sMsg = "没有下一页了";
                return false;
            }
            sMsg = "";
            int iMax = iMin + this.PageRowsCount;
            PageIndex = iIndex;
            ShowPageIndexDesc();
            if (this.GoToPage_Going != null)
                this.GoToPage_Going(iMin, iMax);
            return true;
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        private bool PrePage(out string sMsg)
        {
            int iIndex = PageIndex - 1;
            if (iIndex <= 0)
            {
                sMsg = "没有上一页了";
                return false;
            }
            int iMin = (iIndex - 1) * this.PageRowsCount + 1;
            sMsg = "";
            int iMax = iMin + this.PageRowsCount;
            PageIndex = iIndex;
            ShowPageIndexDesc();
            if (this.GoToPage_Going != null)
                this.GoToPage_Going(iMin, iMax);
            return true;
        }

        #endregion
        #region 公共函数
        public void SetPageRowsCount(int iRowCount)
        {
            this.PageRowsCount = iRowCount;
            if (this.tbPageRowCount != null)
                this.tbPageRowCount.Text = PageRowsCount.ToString();
        }
        public void InitPage(int iTotalRowsCount)
        {
            this.PageIndex = 0;
            SetTotalRowsCount(iTotalRowsCount);
        }
        #endregion
        public delegate void GoToPage(int iMinRowsIndex, int MaxRowsIndex);
        #endregion
    }
}
