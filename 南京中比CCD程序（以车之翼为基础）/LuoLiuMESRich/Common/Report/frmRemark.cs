using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.Text.RegularExpressions;
namespace Common.Report
{
    public partial class frmRemark : frmBaseEdit
    {
        public frmRemark()
        {
            InitializeComponent();
        }
        public long _ID = 0;
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT Remark FROM JC_SystemReport1 WHERE [ID]={0}", _ID));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("传入的报表不存在或已经被删除。(Code:" + _ID.ToString() + ")");
                return false;
            }
            this.AddText(dt.Rows[0]["Remark"].ToString());
            return true;
        }
        #region 处理文本
        private void AddText(string strText)
        {
            Regex reg = new Regex(@"<#\w\w\w\w\w\w>", RegexOptions.IgnoreCase);
            MatchCollection matchs = reg.Matches(strText);
            string strColor;
            string strWords;
            int iIndex1, iIndex2;
            int iIndex3 = -1;
            int itextLen;
            iIndex1 = 0;
            foreach (Match mc in matchs)
            {
                strColor = this.GetCorlorHex(mc.Value);
                iIndex2 = mc.Index;
                iIndex3 = strText.IndexOf("</#" + strColor + ">", iIndex2);
                if (iIndex2 > 0 && iIndex2 > iIndex1)
                    this.rtbDetail.AppendText(strText.Substring(iIndex1, iIndex2 - iIndex1));
                strWords = strText.Substring(iIndex2 + 9, iIndex3 - iIndex2 - 9);
                itextLen = this.rtbDetail.Text.Length;
                this.rtbDetail.AppendText(strWords);
                this.rtbDetail.Select(itextLen, strWords.Length);
                this.rtbDetail.SelectionColor = ColorTranslator.FromHtml("#" + strColor);
                this.rtbDetail.Select(itextLen + strWords.Length, 0);
                this.rtbDetail.SelectionColor = Color.Black;
                iIndex1 = iIndex3 + 10;
            }
            if (iIndex3 > 0 && strText.Length > (iIndex3 + 10))
            {
                this.rtbDetail.AppendText(strText.Substring(iIndex3 + 10));
            }
            else if (iIndex3 == -1)
                this.rtbDetail.AppendText(strText);
        }
        private string GetCorlorHex(string stext)
        {
            return stext.Substring(2, 6);
        }
        #endregion

        private void frmRemark_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}