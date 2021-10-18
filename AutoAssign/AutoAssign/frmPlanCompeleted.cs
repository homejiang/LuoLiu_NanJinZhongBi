using ErrorService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign
{
    public partial class frmPlanCompeleted : Common.frmBase
    {
        frmMain1 MyForm = null;
        public frmPlanCompeleted(frmMain1 mainForm)
        {
            InitializeComponent();
            this.MyForm = mainForm;
            radioNewPlan_CheckedChanged(null, null);
        }
        string _TestCode = string.Empty;
        public void Bind(string sTestCode)
        {
            BindData(sTestCode);
            this._TestCode = sTestCode;
        }
        private bool BindData(string sTestCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TargetTuoCnt,FinishedTuoCnt FROM Testing_Main WHERE Code='{0}'", sTestCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg("未找到传入的检测批次号。");
                return false;
            }
            int iPlan, iCompeleted;
            DataRow dr = dt.Rows[0];
            if (!int.TryParse(dr["TargetTuoCnt"].ToString(), out iPlan))
                iPlan = 0;
            if (!int.TryParse(dr["FinishedTuoCnt"].ToString(), out iCompeleted))
                iCompeleted = 0;
            if(iPlan==iCompeleted)
            {
                this.labTitle.BackColor = Color.FromArgb(56, 88, 136);
                this.labTitle.ForeColor = Color.White;
                this.labTitle.Text = string.Format("当前计划的{0}个托盘已全部完成。\r\n请选择继续或终止测试",iPlan);
            }
            else
            {
                this.labTitle.BackColor = Color.FromArgb(192, 192, 0);
                this.labTitle.ForeColor = Color.Black;
                this.labTitle.Text = string.Format("当前计划的{0}个托盘已完成{1}个。\r\n请选择继续或终止测试", iPlan, iCompeleted);
            }
            return true;
        }
        public bool JPSCommand = false;
        protected override void OnClosing(CancelEventArgs e)
        {
            if (!JPSCommand)
                e.Cancel = true;
            base.OnClosing(e);
        }

        private void radioStopTest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioNewPlan_CheckedChanged(object sender, EventArgs e)
        {
            this.labNewPlan.Visible = this.radioNewPlan.Checked;
            this.tbNewPlan.Visible = this.radioNewPlan.Checked;
            this.labPlanNotice.Visible= this.radioNewPlan.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!this.radioNewPlan.Checked && !this.radioStopTest.Checked)
            {
                this.ShowMsg("请选择执行方式。");
                return;
            }
            if(this.radioNewPlan.Checked)
            {
                int iNewPlan;
                if (!int.TryParse(this.tbNewPlan.Text, out iNewPlan) && iNewPlan < 0)
                {
                    this.ShowMsg("请正确输入新的计划托数。");
                    return;
                }
                string strSql = string.Format("EXEC CreateNewTuoPlan '{0}',{1}", this._TestCode.Replace("'", "''"), iNewPlan);
                try
                {
                    Common.CommonDAL.DoSqlCommand.DoSql(strSql);
                }
                catch(Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    this.JPSCommand = true;
                    return;
                }
                //执行成功，开始
                JPSEntity.ResultControler.TuopanPlanCnt += iNewPlan;
                this.MyForm._MainControl._ResultControler.Listen_TuoPanPlanCompeleted = false;
                this.MyForm.BindTuoPlan();
                this.JPSCommand = true;
                this.Close();
            }
            else
            {
                //终止测试，通知设备
                if (this.MyForm._MainControl == null)
                {
                    this.ShowMsg("控制对象为空，操作无法执行。");
                    return;
                }
                string strErr;
                if (!this.MyForm._MainControl._OPCHelperGongYi.SetAt_SysCompeleted(out strErr))
                {
                    this.ShowMsg(strErr);
                    this.JPSCommand = true;
                    return;
                }
                //此时为写入成功，则打开监控对象
                if (!this.MyForm._MainControl.StartSysCompeletedListenning(out strErr))
                {
                    this.ShowMsg(strErr);
                    this.JPSCommand = true;
                    return;
                }
                //执行成功，等待OPC地址改变
                this.labTitle.BackColor = Color.FromArgb(56, 88, 136);
                this.labTitle.ForeColor = Color.White;
                this.labTitle.Text = "设备清料中，请稍后......";
                this.radioNewPlan.Enabled = false;
            }
        }
        public override void ShowMsg(string strMsg)
        {
            this.labErr.Text = strMsg;
        }

        private void frmPlanCompeleted_Load(object sender, EventArgs e)
        {

        }
    }
}
