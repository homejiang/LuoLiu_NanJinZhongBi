using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.UserControls
{
    public partial class ucGongYiFiles : UserControl
    {
        public ucGongYiFiles()
        {
            InitializeComponent();
        }
        private List<Common.MyEntity.ComboBoxItem> _GongYiFiles = null;
        #region 处理函数
        public bool BindData(List<Common.MyEntity.ComboBoxItem> list)
        {
            while (panel1.Controls.Count < list.Count)
            {
                System.Windows.Forms.LinkLabel link = new LinkLabel();
                link.AutoSize = true;
                link.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                link.Name = "ucGongYiFiles-Link-" + panel1.Controls.Count.ToString();
                link.Size = new System.Drawing.Size(131, 13);
                link.TabStop = true;
                link.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                link.VisitedLinkColor = System.Drawing.Color.Blue;
                link.LinkClicked+=new LinkLabelLinkClickedEventHandler(link_LinkClicked);
                this.panel1.Controls.Add(link);
            }
            while (panel1.Controls.Count > list.Count)
            {
                Control con = panel1.Controls[panel1.Controls.Count - 1];
                panel1.Controls.Remove(con);
                con.Dispose();
            }
            //绑定数据
            Control con1;
            int iLeft=10;
            int iTop = 0;
            for (int i = 0; i < this.panel1.Controls.Count; i++)
            {
                con1 = this.panel1.Controls[i];
                if (con1.Text != list[i].Text)
                    con1.Text = list[i].Text;
                if (con1.Tag == null || con1.Tag.ToString() != list[i].Value.ToString())
                    con1.Tag = list[i].Value;
                con1.Left = iLeft;
                if (iTop == 0)
                {
                    iTop = this.Height - con1.Height;
                    iTop = iTop / 2;
                }
                if (con1.Top != iTop)
                    con1.Top = iTop;
                iLeft += con1.Width + 10;
            }
            this._GongYiFiles = list;
            return true;
        }
        public List<string> GetGongYi()
        {
            List<string> list = new List<string>();
            if (_GongYiFiles != null)
            {
                foreach (Common.MyEntity.ComboBoxItem item in _GongYiFiles)
                {
                    list.Add(item.Value.ToString());
                }
            }
            return list;
        }
        public void Clear()
        {
            List<Common.MyEntity.ComboBoxItem> list = new List<Common.MyEntity.ComboBoxItem>();
            BindData(list);
        }
        #endregion
        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Windows.Forms.LinkLabel link = sender as System.Windows.Forms.LinkLabel;
            if (link == null || link.Tag == null || link.Tag.ToString() == string.Empty) return;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select htmlURL from GongYiFiles where GUID='{0}'", link.Tag.ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("文件未找到。");
                return;
            }
            string strUrl = dt.Rows[0]["htmlURL"].ToString();
            if (strUrl == "")
            {
                this.ShowMsg("文件还未解析，请稍后。");
                return;
            }
            string strHost = this.GetURL("PDM-GongYi", "");
            if (strHost == "")
            {
                return;
            }
            if (!strHost.EndsWith("/") && !strHost.EndsWith("\\"))
                strHost += "/";
            strUrl = strHost + strUrl;
            Common.CommonFuns.OpenWeb(strUrl);
        }
        #region 获取系统所需URL路径
        public string GetURL(string sType, string sArg)
        {
            string strHostName = System.Net.Dns.GetHostName();
            string strIP = string.Empty;
            if (strHostName != string.Empty)
            {
                System.Net.IPAddress[] ips = System.Net.Dns.GetHostAddresses(strHostName);
                //注：目前只读取IP4的地址
                foreach (System.Net.IPAddress ip in ips)
                {
                    if (ip.AddressFamily.Equals(System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        strIP = ip.ToString();
                    }
                }
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("select dbo.Common_GetURL('{0}','{1}','{2}')"
                    , sType, sArg, strIP.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return string.Empty;
            }
            if (dt.Rows.Count == 0 || dt.Rows[0][0].ToString()==string.Empty)
            {
                this.ShowMsg("web服务器路径获取失败。");
                return string.Empty;
            }
            return dt.Rows[0][0].ToString();
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
    }
}
