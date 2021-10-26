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
    public partial class frmReport2 : Common.frmBaseList
    {
        public frmReport2()
        {
            InitializeComponent();
        }
        #region 私有属性
        public string FormGuid = string.Empty;//窗体生成时的一个值
        private ReportEntity _Entity = null;
        #endregion
        #region 公共属性
        public long _ID = -1;
        #endregion
        #region 处理函数
        private bool Perinit()
        {
            //设置默认时间值
            this.dtpDateStart.Value = DateTime.Now;
            this.dtpTimeStart.Value = DateTime.Parse("2001-01-01 08:30:01");
            this.dtpDateStart.Checked = true;
            this.dtpTimeStart.Checked = false;
            this.dtpDateEnd.Value = DateTime.Now;
            this.dtpTimeEnd.Value = DateTime.Parse("2001-01-01 08:30:01");
            this.dtpDateEnd.Checked = true;
            this.dtpTimeEnd.Checked = true;
            #region 读取报表数据
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM JC_SystemReport1 WHERE ID=" + this._ID.ToString());
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                this.ShowMsg("传入的报表不存在。(ID:" + _ID.ToString() + ")");
                return false;
            }
            ReportEntity entity = new ReportEntity();
            entity.ReadFromDataRow(dt.Rows[0]);
            this._Entity = entity;
            #endregion
            SetReportDetail();

            this.FormGuid = this.GetGUID(Common.MyEnums.Modules.None, Common.CurrentUserInfo.UserCode);//用于生成临时文件夹
            return true;
        }
        private void ShowWaitting()
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Report_GetWaittingHTMLTitle {0}", this._Entity.ID));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows[0][0].ToString() == string.Empty) return;//如果没有提示语句，就不用显示等待文本
            SetShowType(ShowType.WebBrowser);
            this.webBrowser1.DocumentText = dt.Rows[0][0].ToString();
        }
        private void ShowError()
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC Report_GetErrorHTMLTitle {0}", this._Entity.ID));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows[0][0].ToString() == string.Empty) return;//如果没有提示语句，就不用显示等待文本
            SetShowType(ShowType.WebBrowser);
            this.webBrowser1.DocumentText = dt.Rows[0][0].ToString();
        }
        private bool BindData0(string sProcedure)
        {
            DataTable dt;
            string strSql = string.Format("EXEC {0} 1", sProcedure);
            if (this._ListArg != null && this._ListArg.Count > 0)
            {
                for (int i = 0; i < this._ListArg.Count; i++)
                {
                    strSql += string.Format(",'{0}'", this._ListArg[i].Replace("'", "''"));
                }
            }
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = null;
            this.dgvList.DataSource = dt;
            foreach (DataGridViewColumn dgvc in this.dgvList.Columns)
            {
                if (dgvc.DataPropertyName.IndexOf("@") >= 0)
                {
                    dgvc.Visible = false;
                }
            }
            Stattistics(dt);
            SetShowType(ShowType.DataGridview);
            return true;
        }
        private bool BindData1(string sProcedure)
        {
            DataTable dt;
            string strSql = GetSql1(sProcedure,1);
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.dgvList.DataSource = null;
            this.dgvList.DataSource = dt;
            foreach (DataGridViewColumn dgvc in this.dgvList.Columns)
            {
                if (dgvc.DataPropertyName.IndexOf("@") >= 0)
                {
                    dgvc.Visible = false;
                }
            }
            Stattistics(dt);
            SetShowType(ShowType.DataGridview);
            return true;
        }
        private bool BindData2(ReportEntity entity)
        {
            /*
             * 此模式下为显示 html格式，传入的参数固定为：时间1、时间2、整型参数，
             * 获取方式为调用模板
             */
            if (entity == null || entity.ModuleName == null || entity.ModuleName.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return false;
            }
            string strModule = this.GetExcelModule(entity.ModuleName.ToString());
            if (strModule == string.Empty) return false;
            string strtime1, strtime2;
            if (this.dtpDateStart.Checked)
                strtime1 = string.Format("{0} {1}", this.dtpDateStart.Value.ToString("yyyy-MM-dd"), this.dtpTimeStart.Value.ToString("HH:mm"));
            else strtime1 = "2000-01-01";
            if (this.dtpDateEnd.Checked)
                strtime2 = string.Format("{0} {1}", this.dtpDateEnd.Value.ToString("yyyy-MM-dd"), this.dtpTimeEnd.Value.ToString("HH:mm"));
            else strtime2 = "2500-01-01";
            object[] arrObj = new object[6];
            arrObj[0] =strtime1;
            arrObj[1] =strtime2;
            arrObj[2] =1;
            arrObj[3] = Common.CommonDAL.DBCPrintConnString;
            arrObj[4] = true;
            arrObj[5] = Common.CurrentUserInfo.UserCode;

            string strUrl = Common.CommonFuns.GetReportHtmlByExcel(this, GetTargetReportFilesDir(), entity.ReportName.ToString(), strModule, arrObj);
            if (strUrl == string.Empty)
                ShowError();
            else
                this.webBrowser1.Navigate(strUrl);
            SetShowType(ShowType.WebBrowser);
            return true;
        }
        private string GetTargetReportFilesDir()
        {
            string strDir = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strDir.EndsWith("\\"))
                strDir += "\\";
            strDir += string.Format(@"report cache\{0}", this.FormGuid);
            return strDir;
        }
        private string GetSql1(string sProcedure, int iType)
        {
            string strtime1, strtime2;
            if (this.dtpDateStart.Checked)
                strtime1 = string.Format("'{0} {1}'", this.dtpDateStart.Value.ToString("yyyy-MM-dd"), this.dtpTimeStart.Value.ToString("HH:mm"));
            else strtime1 = "null";
            if (this.dtpDateEnd.Checked)
                strtime2 = string.Format("'{0} {1}'", this.dtpDateEnd.Value.ToString("yyyy-MM-dd"), this.dtpTimeEnd.Value.ToString("HH:mm"));
            else strtime2 = "null";
            string strSql = string.Format("EXEC {0} {1},{2},{3}", sProcedure, strtime1, strtime2, iType);
            if (this._ListArg != null && this._ListArg.Count > 0)
            {
                for (int i = 0; i < this._ListArg.Count; i++)
                {
                    strSql += string.Format(",'{0}'", this._ListArg[i].Replace("'", "''"));
                }
            }
            return strSql;
        }
        private void SetReportDetail()
        {
            if (this._Entity == null || this._Entity.ReportProcedure == null || this._Entity.ReportProcedure.ToString().Length == 0) return;
            this.linkRpName.Text = this._Entity.ReportName.ToString();
            if (this._Entity.ArgType.ToString() == "" || this._Entity.ArgType.ToString() == "0")
            {
                ShowTimeControls(false);
            }
            else
            {
                ShowTimeControls(true);
                //设置初始化时间
                DataTable dtInittime;
                if (this._Entity.InitTime1Sql.ToString() != string.Empty)
                {
                    try
                    {
                        dtInittime = Common.CommonDAL.DoSqlCommand.GetDateTable(this._Entity.InitTime1Sql.ToString());
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    if (dtInittime.Columns.Contains("InitTime") && dtInittime.Rows.Count > 0)
                    {
                        DateTime det = DateTime.Parse(dtInittime.Rows[0]["InitTime"].ToString());
                        this.dtpDateStart.Value = det;
                        this.dtpTimeStart.Value = det;
                    }
                }
                //结束时间
                if (this._Entity.InitTime2Sql.ToString() != string.Empty)
                {
                    try
                    {
                        dtInittime = Common.CommonDAL.DoSqlCommand.GetDateTable(this._Entity.InitTime2Sql.ToString());
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return;
                    }
                    if (dtInittime.Columns.Contains("InitTime") && dtInittime.Rows.Count > 0)
                    {
                        DateTime det = DateTime.Parse(dtInittime.Rows[0]["InitTime"].ToString());
                        this.dtpDateEnd.Value = det;
                        this.dtpTimeEnd.Value = det;
                    }
                }
            }
            
        }
        private void ShowTimeControls(bool blShow)
        {
            //this.linkTime.Visible = blShow;
            //dtpDateStart.Visible = blShow;
            //this.dtpTimeStart.Visible = blShow;
            //this.dtpDateEnd.Visible = blShow;
            //this.dtpTimeEnd.Visible = blShow;
            //labZhi.Visible = blShow;
            panTime.Visible = blShow;
            this.btSearch.Text = blShow ? "搜 索" : "加载数据";
        }
        private void SetShowType(ShowType type)
        {
            if (type == ShowType.WebBrowser)
            {
                if (!this.webBrowser1.Visible)
                {
                    this.webBrowser1.Visible = true;
                }
                if (this.webBrowser1.Dock != DockStyle.Fill)
                    this.webBrowser1.Dock = DockStyle.Fill;
                if (this.tlDataGrid.Visible)
                    this.tlDataGrid.Visible = false;
            }
            else
            {
                if (!this.tlDataGrid.Visible)
                {
                    this.tlDataGrid.Visible = true;
                }
                if (this.tlDataGrid.Dock != DockStyle.Fill)
                    this.tlDataGrid.Dock = DockStyle.Fill;
                if (this.webBrowser1.Visible)
                    this.webBrowser1.Visible = false;
            }
        }
        #endregion
        #region 重写函数
        List<string> _ListArg = null;
        public override void InitParameters(string[] arrs)
        {
            if (arrs.Length == 0) return;
            long iID;
            if (!long.TryParse(arrs[0], out iID))
                return;
            this._ID = iID;
            if (arrs.Length > 1)
            {
                _ListArg = new List<string>();
                for (int i = 1; i < arrs.Length; i++)
                {
                    _ListArg.Add(arrs[i]);
                }
            }
        }
        #endregion
        #region 导出Excel
        private void Output0()
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            string strModule = this.GetExcelModule(this._Entity.ModuleName.ToString());
            if (strModule == string.Empty) return;
            object[] arrObj = new object[4];
            string strSql = string.Format("EXEC {0} 2", this._Entity.ReportProcedure);
            if (this._ListArg != null && this._ListArg.Count > 0)
            {
                for (int i = 0; i < this._ListArg.Count; i++)
                {
                    strSql += string.Format(",'{0}'", this._ListArg[i].Replace("'", "''"));
                }
            }
            arrObj[0] = strSql;
            arrObj[1] = Common.CommonDAL.DBCPrintConnString;
            arrObj[2] = true;
            arrObj[3] = Common.CurrentUserInfo.UserCode;
            Common.CommonFuns.OutputExcel(this, strModule, this._Entity.ReportName.ToString() + ".xls", arrObj);
        }
        private void Output1()
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            string strModule = this.GetExcelModule(this._Entity.ModuleName.ToString());
            if (strModule == string.Empty) return;
            object[] arrObj = new object[4];
            arrObj[0] = GetSql1(this._Entity.ReportProcedure.ToString(),2).Replace("'", "''");
            arrObj[1] = Common.CommonDAL.DBCPrintConnString;
            arrObj[2] = true;
            arrObj[3] = Common.CurrentUserInfo.UserCode;
            Common.CommonFuns.OutputExcel(this, strModule, this._Entity.ReportName.ToString() + ".xls", arrObj);
        }
        private void Output2()
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            string strModule = this.GetExcelModule(this._Entity.ModuleName.ToString());
            if (strModule == string.Empty) return;
            string strtime1, strtime2;
            if (this.dtpDateStart.Checked)
                strtime1 = string.Format("{0} {1}", this.dtpDateStart.Value.ToString("yyyy-MM-dd"), this.dtpTimeStart.Value.ToString("HH:mm"));
            else strtime1 = "2000-01-01";
            if (this.dtpDateEnd.Checked)
                strtime2 = string.Format("{0} {1}", this.dtpDateEnd.Value.ToString("yyyy-MM-dd"), this.dtpTimeEnd.Value.ToString("HH:mm"));
            else strtime2 = "2500-01-01";
            object[] arrObj = new object[6];
            arrObj[0] = strtime1;
            arrObj[1] = strtime2;
            arrObj[2] = 2;
            arrObj[3] = Common.CommonDAL.DBCPrintConnString;
            arrObj[4] = true;
            arrObj[5] = Common.CurrentUserInfo.UserCode;
            Common.CommonFuns.OutputExcel(this, strModule, this._Entity.ReportName.ToString() + ".xls", arrObj);
        }
        #endregion
        private void Stattistics(DataTable dt)
        {
            long lID;
            if (this._Entity == null || this._Entity.ReportProcedure == null || this._Entity.ReportProcedure.ToString().Length == 0 || !long.TryParse(this._Entity.ID.ToString(), out lID))
            {
                this.ShowStattisticsLabel(false);
                return;
            }
            bool blHide;
            
            string strText = this._Entity.ReportStatistics == null ? string.Empty : this._Entity.ReportStatistics.ToString();
            if (strText == string.Empty)
                blHide = true;
            else
            {
                blHide = true;
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"{.+?}", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                MatchCollection matchs = reg.Matches(strText);
                string sColName;
                decimal dec;
                decimal decTotal;
                decimal decRate;
                foreach (Match m in matchs)
                {
                    Stattistics_GetColumnName(m.Value, out sColName, out decRate);
                    if (!dt.Columns.Contains(sColName)) continue;
                    //list.Add(new Common.Mythis._Entity.ComboBoxItem(sColName, DBNull.Value));
                    decTotal = 0M;
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[sColName].Equals(DBNull.Value)) continue;
                        if (decimal.TryParse(dr[sColName].ToString(), out dec))
                            decTotal += dec;
                    }
                    decTotal = decTotal / decRate;
                    strText = strText.Replace(m.Value, decTotal.ToString("#,###,###,##0.######"));
                    if (blHide)
                        blHide = false;
                }
            }
            ShowStattisticsLabel(!blHide);
            if (!blHide)
                this.labtotal.Text = strText;
        }
        private void ShowStattisticsLabel(bool blShow)
        {
            //显示统计信息
            if (blShow)
            {
                this.tlDataGrid.RowStyles[1].Height = 30F;
                this.labtotal.Visible = true;                
            }
            else
            {
                this.tlDataGrid.RowStyles[1].Height = 0F;
                this.labtotal.Text = string.Empty;
                this.labtotal.Visible = false;
            }
        }
        private void Stattistics_GetColumnName(string s,out string sColName,out decimal decRate)
        {
            sColName = "";
            decRate = 1M;
            //传入的格式必定为{字段名}
            s = s.Substring(1, s.Length - 2);
            if (s.StartsWith("[") && s.EndsWith("]"))
                s = s.Substring(1, s.Length - 2);
            string[] arr = s.Split('/');
            sColName = arr[0];
            if (arr.Length > 1)
            {
                if (arr[1] == string.Empty || !decimal.TryParse(arr[1], out decRate))
                    decRate = 1M;
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            //DateTime detNow = DateTime.Now;
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            this.ShowWaitting();
            Application.DoEvents();
            if (this._Entity.ArgType.ToString() == "" || this._Entity.ArgType.ToString() == "0")
            {
                this.BindData0(this._Entity.ReportProcedure.ToString());
            }
            else if(this._Entity.ArgType.ToString()=="1")
                this.BindData1(this._Entity.ReportProcedure.ToString());
            else if (this._Entity.ArgType.ToString() == "2")
                this.BindData2(this._Entity);
            else
            {
                this.ShowMsg("当前报表类别未设置过，请联系管理员。");
                return;
            }
            //TimeSpan ts= DateTime.Now - detNow;
            //int iTotal = ts.TotalMilliseconds;

        }
        #region 窗体事件
        private void frmProduceList_Load(object sender, EventArgs e)
        {
            this.Perinit();
        }
        public override void MyFormClose()
        {
            //删除报表文件
            string strDir = GetTargetReportFilesDir();
            if (strDir != string.Empty && System.IO.Directory.Exists(strDir))
            {
                try
                {
                    System.IO.Directory.Delete(strDir, true);
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                }
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            MyFormClose();
            base.OnClosing(e);
        }
        #endregion
        private void btOutputExcel_Click(object sender, EventArgs e)
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            if (this._Entity.ModuleName != null && string.Compare(this._Entity.ModuleName.ToString(), "@MyDataGridView",true)==0)
            {
                //此时表示直接导出mydatagridview表头和内容
                if (Common.CommonFuns.DataGridViewToExcel(this.dgvList, this._Entity.ReportName == null ? DateTime.Now.ToString("yyyyMMddHHmmss") : this._Entity.ReportName.ToString()))
                    this.ShowMsgRich("导出成功！");
                return;
            }
            if (this._Entity.ArgType.ToString() == "" || this._Entity.ArgType.ToString() == "0")
            {
                this.Output0();
            }
            else if(this._Entity.ArgType.ToString() == "1")
                this.Output1();
            else if (this._Entity.ArgType.ToString() == "2")
                this.Output2();
        }
        private void linkTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._Entity == null || this._Entity.ReportProcedure == null || this._Entity.ReportProcedure.ToString().Length == 0) return;
            frmReportTime frm = new frmReportTime();
            if (this._Entity.TimeHM1.ToString() != string.Empty)
                frm.TimeHours1 = this._Entity.TimeHM1.ToString();
            if (this._Entity.TimeHM2.ToString() != string.Empty)
                frm.TimeHours2 = this._Entity.TimeHM2.ToString();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            this.dtpDateStart.Value = frm.StartTime;
            this.dtpTimeStart.Value = frm.StartTime;
            this.dtpDateEnd.Value = frm.EndTime;
            this.dtpTimeEnd.Value = frm.EndTime;
        }

        private void linkRp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long lID;
            if (this._Entity == null || this._Entity.ID == null || !long.TryParse(this._Entity.ID.ToString(),out lID))
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            frmRemark frm = new frmRemark();
            frm._ID = lID;
            frm.Show();
        }

        private void btOutputTxt_Click(object sender, EventArgs e)
        {
            if (this._Entity == null || this._Entity.ReportProcedure.ToString().Length == 0)
            {
                this.ShowMsg("请选择报表名称。");
                return;
            }
            DataTable dt = this.dgvList.DataSource as DataTable;
            if (dt == null) return;
            if (Common.CommonFuns.DataGridViewToExcel(this.dgvList, _Entity.ReportName.ToString() + ".xls"))
                this.ShowMsgRich("导出成功！");

        }
    }
}