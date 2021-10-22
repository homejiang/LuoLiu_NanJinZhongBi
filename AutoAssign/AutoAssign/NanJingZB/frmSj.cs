using AutoAssign.JPSEntity;
using JpsOPC.OPCEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.NanJingZB
{
    public partial class frmSj : Common.frmBase
    {
        SJListen _SJListen = null;
        /// <summary>
        /// 保存成功后该值就不为0了
        /// </summary>
        string _Guid = string.Empty;
        DateTime? _StartTime = null;
        DateTime? _EndTime = null;
        public frmSj()
        {
            InitializeComponent();
            this._SJListen = new SJListen(this);
            this._SJListen.ShowErrNotice += _SJListen_ShowErrNotice;
            this._SJListen.ShowLogNotice += _SJListen_ShowLogNotice;
            this._SJListen.SJResultCompeletedNotice += _SJListen_SJResultCompeletedNotice;
            this._SJListen.SJCompeletedNotice += _SJListen_SJCompeletedNotice;
            this.dgvResult.AutoGenerateColumns = false;
            this.dgvSet.AutoGenerateColumns = false;
            this.btStart.Enabled = this.BindSet();
        }

        private void _SJListen_SJCompeletedNotice()
        {
            //此时已经完成了
            this.SetFormStyle();
        }

        private void _SJListen_SJResultCompeletedNotice(NanJingZB_SJResult result)
        {
            //显示数据
            DataTable dt = new DataTable();
            dt.Columns.Add("GrooveNo", Type.GetType("System.Int16"));
            dt.Columns.Add("ResultValue", Type.GetType("System.Decimal"));
            DataRow drNew;
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 1;
            drNew["ResultValue"] = result.SJ_Resut1;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 2;
            drNew["ResultValue"] = result.SJ_Resut2;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 3;
            drNew["ResultValue"] = result.SJ_Resut3;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 4;
            drNew["ResultValue"] = result.SJ_Resut4;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 5;
            drNew["ResultValue"] = result.SJ_Resut5;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 6;
            drNew["ResultValue"] = result.SJ_Resut6;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 7;
            drNew["ResultValue"] = result.SJ_Resut7;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 8;
            drNew["ResultValue"] = result.SJ_Resut8;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 9;
            drNew["ResultValue"] = result.SJ_Resut9;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 10;
            drNew["ResultValue"] = result.SJ_Resut10;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 11;
            drNew["ResultValue"] = result.SJ_Resut11;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 12;
            drNew["ResultValue"] = result.SJ_Resut12;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 13;
            drNew["ResultValue"] = result.SJ_Resut13;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 14;
            drNew["ResultValue"] = result.SJ_Resut14;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 15;
            drNew["ResultValue"] = result.SJ_Resut15;
            dt.Rows.Add(drNew);
            drNew = dt.NewRow();
            drNew["GrooveNo"] = 16;
            drNew["ResultValue"] = result.SJ_Resut16;
            dt.Rows.Add(drNew);
            this.dgvResult.DataSource = dt;
            //激活保存按钮
            this._EndTime = DateTime.Now;
            this.btSave.Enabled = true;
        }

        private void _SJListen_ShowLogNotice(string sMsg)
        {
            if (this.checkBox1.Checked) return;
            string sText = $"<#000000>[{DateTime.Now.ToString("HH:mm:ss")}]->{sMsg}</#000000>\r\n";
            Common.CommonFuns.AddRichTexBoxText(sText, this.rtbLog);
            this.rtbLog.Select(this.rtbLog.Text.Length, 0);
        }

        private void _SJListen_ShowErrNotice(string sMsg)
        {
            if (this.checkBox1.Checked) return;
            string sText = $"<#FF0000>[{DateTime.Now.ToString("HH:mm:ss")}]->{sMsg}</#FF0000>\r\n";
            Common.CommonFuns.AddRichTexBoxText(sText, this.rtbLog);
            this.rtbLog.Select(this.rtbLog.Text.Length, 0);
        }

        private bool BindSet()
        {
            try
            {
                this.dgvSet.DataSource = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM NanJingZB_SJSet ORDER BY GrooveNo ASC", true);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return false;
            }
            return true;
        }
        private bool Start()
        {
            if(this._SJListen.Running)
            {
                this.ShowMsg("首检控制线程已经启动，请勿重复开启。");
                return false;
            }
            //校验值
            DataTable dt = this.dgvSet.DataSource as DataTable;
            if(dt==null)
            {
                this.ShowMsg("设置值数据源为空！");
                return false;
            }
            NanJingZB_SJRVRange range = new NanJingZB_SJRVRange();
            DataRow[] drs;
            for(int i=1;i<=16;i++)
            {
                //检查每个通道是否值都包含了
                drs = dt.Select($"GrooveNo={i}");
                if(drs.Length==0)
                {
                    this.ShowMsg($"还未设置槽{i}的参数。");
                    return false;
                }
                range.SetValueFromDB(i, drs[0]["VMin"], drs[0]["VMax"], drs[0]["RMin"], drs[0]["RMax"]);
            }
            //此时我们要先保存数据
            if (dt.GetChanges() != null)
            {
                try
                {
                    Common.CommonDAL.DoSqlCommand.SaveTable(dt, "NanJingZB_SJSet");
                }
                catch (Exception ex)
                {
                    this.ShowMsg($"保存设置参数到数据库出错:{ex.Message}({ex.Source})");
                    return false;
                }
                //没有报错则表示成功
                dt.AcceptChanges();
            }
            //此时我们要启动线程了
            string sErr;
            if(!this._SJListen.StartListenning(range,out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            //保存
            string sGuid;
            if(this.SaveResult(out sGuid))
            {
                this._Guid = sGuid;
                SetFormStyle();
            }
        }
        private bool SaveResult(out string sGuid)
        {
            sGuid = string.Empty;
            if (this._StartTime==null)
            {
                this.ShowMsg("检测起始时间为空，无法保存。");
                return false;
            }
            if (this._EndTime == null)
            {
                this.ShowMsg("检测结束时间为空，无法保存。");
                return false;
            }
            if (this._Guid.Length > 0)
            {
                this.ShowMsg("当前数据已保存过，无法再次保存！");
                return false;
            }
            sGuid = Guid.NewGuid().ToString();
            List<string> list = new List<string>();
            list.Add($"INSERT INTO NanJingZB_SJRecordSet (ID,GrooveNo,Guid,VMin,VMax,RMin,RMax) SELECT GrooveNo,'{sGuid}',VMin,VMax,RMin,RMax FROM NanJingZB_SJSet");
            DataTable dtResult = this.dgvResult.DataSource as DataTable;
            if(dtResult==null)
            {
                this.ShowMsg("结果数据源为空，保存失败！");
                return false;
            }
            foreach (DataRowView drv in dtResult.DefaultView)
            {
                int iGroove = drv.Row["GrooveNo"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["GrooveNo"].ToString());
                decimal decValue = drv.Row["ResultValue"].Equals(DBNull.Value) ? -1M : decimal.Parse(drv.Row["ResultValue"].ToString());
                list.Add($"INSERT INTO NanJingZB_SJRecordResult (GrooveNo,Guid,ResultValue) values({iGroove},'{sGuid}',{decValue})");
            }
            //插入主表
            list.Add($"INSERT INTO NanJingZB_SjRecord (Guid,StartTime,EndTime) values('{sGuid}','{((DateTime)this._StartTime).ToString("yyyy-MM-dd HH:mm:ss")}','{((DateTime)this._EndTime).ToString("yyyy-MM-dd HH:mm:ss")}')");
            //开始保存
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(list);
            }
            catch(Exception ex)
            {
                this.ShowMsg($"提交至数据库出错：{ex.Message}({ex.Source})");
                return false;
            }
            return true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if(this.Start())
            {
                this._StartTime = DateTime.Now;
                this.SetFormStyle();
                this.dgvResult.DataSource = null;
            }
        }
        private void SetFormStyle()
        {
            this.btSave.Enabled = this._Guid.Length == 0;
            this.btStart.Enabled = this._SJListen != null && !this._SJListen.Running;
        }

        private void frmSj_Load(object sender, EventArgs e)
        {
            SetFormStyle();
        }
    }
}
