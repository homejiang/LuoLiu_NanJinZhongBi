using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.Text.RegularExpressions;

namespace LuoLiuMES.TraceBack
{
    public partial class frmTraceBack : Common.frmBaseEdit
    {
        #region 后退按钮数据实体
        private class Backupdata
        {
            public string SFGCode = string.Empty;
            public int SFGType = 0;
        }
        #endregion
        public frmTraceBack()
        {
            InitializeComponent();
        }
        #region 处理退回操作
        private Backupdata _CurrentBd = null;
        private List<Backupdata> _ListBd = null;
        private void RemoveBd()
        {
            if (_ListBd == null || _ListBd.Count == 0) return;
            Backupdata back = _ListBd[_ListBd.Count - 1];
            _CurrentBd = new Backupdata();
            _CurrentBd.SFGCode = back.SFGCode;
            _CurrentBd.SFGType = back.SFGType;
            _ListBd.Remove(back);
        }
        private void AddBd(string sCode,int iType)
        {
            if (_CurrentBd != null)
            {
                if (_ListBd == null)
                    _ListBd = new List<Backupdata>();
                _ListBd.Add(_CurrentBd);
            }
            _CurrentBd = new Backupdata();
            _CurrentBd.SFGCode = sCode;
            _CurrentBd.SFGType = iType;
        }
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            //绑定半成品类别
            this.comSFGTypes.DisplayMember = "Text";
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("电池包", 3));
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("模组", 2));
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("模块", 1));
            this.comSFGTypes.Items.Add(new Common.MyEntity.ComboBoxItem("电芯", 0));
            return true;
        }
        #endregion
        #region 查找半成品
        private void btSearch_Click(object sender, EventArgs e)
        {
            int iType;
            Common.MyEntity.ComboBoxItem item = this.comSFGTypes.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0 || !int.TryParse(item.Value.ToString(), out iType))
            {
                this.ShowMsg("请选择产品类型。");
                this.comSFGTypes.Focus();
                return;
            }
            if (this.tbSFGCode.Text.Length == 0)
            {
                this.ShowMsg("请输入产品编号。");
                this.tbSFGCode.Focus();
                return;
            }
            this.BindSFG(this.tbSFGCode.Text, iType);
        }
        private bool BindSFG(string sSFGCode, int iSFGType)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC TraceBack_GetSFGInfo '{0}',{1}", sSFGCode.Replace("'", "''"), iSFGType));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("数据获取失败。");
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            this.dgvSfg.DataSource = null;
            this.dgvSfg.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                this.dgvSfg.Columns[dt.Columns[i].ColumnName].DisplayIndex = i;
            }
            this.dgvcolLink.DisplayIndex = dt.Columns.Count;
            this.dgvcolLinkParent.DisplayIndex = dt.Columns.Count + 1;
            this.dgvcolBindDetail.DisplayIndex = dt.Columns.Count + 2;
            #region 设置半成品列表控件不显示的列
            foreach (DataGridViewColumn dgvc in this.dgvSfg.Columns)
            {
                if (string.Compare(dgvc.DataPropertyName, "SFGType", true) == 0)
                    dgvc.Visible = false;
                else if (string.Compare(dgvc.DataPropertyName, "SFGCode", true) == 0)
                    dgvc.Visible = false;
            }
            #endregion
            #region 初始化历史记录
            this._ListBd = null;
            this._CurrentBd = new Backupdata();
            this._CurrentBd.SFGCode = sSFGCode;
            this._CurrentBd.SFGType = iSFGType;
            #endregion
            if (dt.Rows.Count == 1)
            {
                this.BindDetail(dt.Rows[0]["SFGCode"].ToString(), int.Parse(dt.Rows[0]["SFGType"].ToString()));
            }
            return true;
        }
        private bool BindChildrens(string sCode,int iType)
        {
            DataTable dt = null;
            string strSql;
            strSql = string.Format("EXEC [TraceBack_GetChildren] '{0}',{1}", sCode, iType);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到数据。");
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            this.dgvSfg.DataSource = null;
            this.dgvSfg.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                this.dgvSfg.Columns[dt.Columns[i].ColumnName].DisplayIndex = i;
            }
            this.dgvcolLink.DisplayIndex = dt.Columns.Count;
            this.dgvcolLinkParent.DisplayIndex = dt.Columns.Count + 1;
            this.dgvcolBindDetail.DisplayIndex = dt.Columns.Count + 2;
            #region 设置半成品列表控件不显示的列
            foreach (DataGridViewColumn dgvc in this.dgvSfg.Columns)
            {
                if (string.Compare(dgvc.DataPropertyName, "SFGType", true) == 0)
                    dgvc.Visible = false;
                else if (string.Compare(dgvc.DataPropertyName, "SFGCode", true) == 0)
                    dgvc.Visible = false;
            }
            #endregion
            return true;
        }
        private bool BindParent(string sCode, int iType)
        {
            DataTable dt = null;
            string strSql;
            strSql = string.Format("EXEC [TraceBack_GetParent] '{0}',{1}", sCode, iType);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("未找到数据。");
                return false;
            }
            if (dt.Columns.Contains("ErrMsg"))
            {
                this.ShowMsg(dt.Rows[0]["ErrMsg"].ToString());
                return false;
            }
            this.dgvSfg.DataSource = null;
            this.dgvSfg.DataSource = dt;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                this.dgvSfg.Columns[dt.Columns[i].ColumnName].DisplayIndex = i;
            }
            this.dgvcolLink.DisplayIndex = dt.Columns.Count;
            this.dgvcolLinkParent.DisplayIndex = dt.Columns.Count + 1;
            this.dgvcolBindDetail.DisplayIndex = dt.Columns.Count + 2;
            #region 设置半成品列表控件不显示的列
            foreach (DataGridViewColumn dgvc in this.dgvSfg.Columns)
            {
                if (string.Compare(dgvc.DataPropertyName, "SFGType", true) == 0)
                    dgvc.Visible = false;
                else if (string.Compare(dgvc.DataPropertyName, "SFGCode", true) == 0)
                    dgvc.Visible = false;
            }
            #endregion
            return true;
        }
        #endregion
        #region 详细信息
        private void BindDetail(string sCode, int iSFGType)
        {
            this.rtbDetail.Clear();
            BindDetail_1(sCode, iSFGType);
            BindDetail_2(sCode, iSFGType);
            BindDetail_3(sCode, iSFGType);
        }
        private bool BindDetail_1(string sCode, int iSFGType)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("[TraceBack_GetSFGDetail_1] '{0}',{1}"
                    , sCode.Replace("'", "''"), iSFGType));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
                return false;
            for (int i = 0; i < dt.Columns.Count; i++)
                this.AddText(dt.Rows[0][i].ToString());
            return true;
        }
        private bool BindDetail_2(string sCode, int iSFGType)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("[TraceBack_GetSFGDetail_2] '{0}',{1}"
                    , sCode.Replace("'", "''"), iSFGType));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
                return false;
            for (int i = 0; i < dt.Columns.Count; i++)
                this.AddText(dt.Rows[0][i].ToString());
            return true;
        }
        private bool BindDetail_3(string sCode, int iSFGType)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("[TraceBack_GetSFGDetail_3] '{0}',{1}"
                    , sCode.Replace("'", "''"), iSFGType));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
                return false;
            for (int i = 0; i < dt.Columns.Count; i++)
                this.AddText(dt.Rows[0][i].ToString());
            return true;
        }
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

        private void frmTraceBack_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
        }

        private void dgvSfg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (this.dgvSfg.Columns[e.ColumnIndex].Name == this.dgvcolLink.Name)
            {
                DataTable dt = this.dgvSfg.DataSource as DataTable;
                if (dt == null) return;
                if (!dt.Columns.Contains("SFGCode")) return;
                if (!dt.Columns.Contains("SFGType")) return;
                DataRow dr = dt.DefaultView[e.RowIndex].Row;
                int iType;
                if (!int.TryParse(dr["SFGType"].ToString(), out iType))
                    iType = 0;
                if (iType == 0)
                {
                    this.ShowMsg("产品类别代码无效(Type=" + iType.ToString() + ")");
                    return;
                }
                if (this.BindChildrens(dr["SFGCode"].ToString(), iType))
                {
                    this.AddBd(dr["SFGCode"].ToString(), iType);
                }
            }
            else if (this.dgvSfg.Columns[e.ColumnIndex].Name == this.dgvcolLinkParent.Name)
            {
                DataTable dt = this.dgvSfg.DataSource as DataTable;
                if (dt == null) return;
                if (!dt.Columns.Contains("SFGCode")) return;
                if (!dt.Columns.Contains("SFGType")) return;
                DataRow dr = dt.DefaultView[e.RowIndex].Row;
                int iType;
                if (!int.TryParse(dr["SFGType"].ToString(), out iType))
                    iType = 0;
                if (iType == 0)
                {
                    this.ShowMsg("产品类别代码无效(Type=" + iType.ToString() + ")");
                    return;
                }
                if (this.BindParent(dr["SFGCode"].ToString(), iType))
                {
                    this.AddBd(dr["SFGCode"].ToString(), iType);
                }
            }
            else if (this.dgvSfg.Columns[e.ColumnIndex].Name == this.dgvcolBindDetail.Name)
            {
                DataTable dt = this.dgvSfg.DataSource as DataTable;
                if (dt == null) return;
                if (!dt.Columns.Contains("SFGCode")) return;
                if (!dt.Columns.Contains("SFGType")) return;
                DataRow dr = dt.DefaultView[e.RowIndex].Row;
                int iType;
                if (!int.TryParse(dr["SFGType"].ToString(), out iType))
                    iType = 0;
                if (iType == 0)
                {
                    this.ShowMsg("半成品类别代码无效(Type=" + iType.ToString() + ")");
                    return;
                }
                this.BindDetail(dr["SFGCode"].ToString(), iType);
            }
        }
        private void dtsbLeft_Click(object sender, EventArgs e)
        {
            if (_ListBd == null || _ListBd.Count == 0)
            {
                this.btSearch_Click(null, null);
                return;
            }
            Backupdata back = _ListBd[_ListBd.Count - 1];
            if (this.BindChildrens(back.SFGCode, back.SFGType))
            {
                this.RemoveBd();
            }
        }

        private void tbSFGCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            if (this.tbSFGCode.Text == string.Empty) return;
            btSearch_Click(null, null);
        }
    }

}