using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.Setting
{
    public partial class frmSysInterval : Common.frmBase
    {
        public frmSysInterval()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int iScaner_TimeoutMiilSeconds;
            int iDelayerMillScdsAfterBatDataWriteIntoOPC;
            int iDelayerMillScdsAfterResultSaved;
            int iTesteStatusReaderInterval;
            int iRefreshStatisticData;
            int iRefreshSendMes;
            string strErr;
            if (!this.GetInt32(this.tbScaner_TimeoutMiilSeconds, "", out iScaner_TimeoutMiilSeconds)) return;
            if (!this.GetInt32(this.tbDelayerMillScdsAfterBatDataWriteIntoOPC, "", out iDelayerMillScdsAfterBatDataWriteIntoOPC)) return;
            if (!this.GetInt32(this.tbDelayerMillScdsAfterResultSaved, "", out iDelayerMillScdsAfterResultSaved)) return;
            if (!this.GetInt32(this.tbTesteStatusReaderInterval, "", out iTesteStatusReaderInterval)) return;
            if (!this.GetInt32(this.tbRefreshStatisticData, "", out iRefreshStatisticData)) return;
            if (!this.GetInt32(this.tbRefreshSendMes, "", out iRefreshSendMes)) return;
            JPSConfig.Scaner_TimeoutMiilSeconds = iScaner_TimeoutMiilSeconds;
            JPSConfig.DelayerMillScdsAfterBatDataWriteIntoOPC = iDelayerMillScdsAfterBatDataWriteIntoOPC;
            JPSConfig.DelayerMillScdsAfterResultSaved = iDelayerMillScdsAfterResultSaved;
            JPSConfig.TesteStatusReaderInterval = iTesteStatusReaderInterval;
            JPSConfig.RefreshStatisticData = iRefreshStatisticData;
            JPSConfig.RefreshSendMes = iRefreshSendMes;
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval1", JPSConfig.Scaner_TimeoutMiilSeconds.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval2", JPSConfig.DelayerMillScdsAfterBatDataWriteIntoOPC.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval3", JPSConfig.DelayerMillScdsAfterResultSaved.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval4", JPSConfig.TesteStatusReaderInterval.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval5", JPSConfig.RefreshStatisticData.ToString());
                Common.CommonFuns.ConfigINI.SetValue("Interval", "Interval6", JPSConfig.RefreshSendMes.ToString());
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmSysInterval_Load(object sender, EventArgs e)
        {
            this.tbScaner_TimeoutMiilSeconds.Text = JPSConfig.Scaner_TimeoutMiilSeconds.ToString();
            this.tbDelayerMillScdsAfterBatDataWriteIntoOPC.Text = JPSConfig.DelayerMillScdsAfterBatDataWriteIntoOPC.ToString();
            this.tbDelayerMillScdsAfterResultSaved.Text = JPSConfig.DelayerMillScdsAfterResultSaved.ToString();
            this.tbTesteStatusReaderInterval.Text = JPSConfig.TesteStatusReaderInterval.ToString();
            this.tbRefreshStatisticData.Text = JPSConfig.RefreshStatisticData.ToString();
            this.tbRefreshSendMes.Text = JPSConfig.RefreshSendMes.ToString();
        }
        private bool GetInt32(TextBox tb,string sTitle,out int iVaue)
        {
            iVaue = 0;
            if (tb.Text.Length==0)
            {
                this.ShowMsg("请正确输入\"" + sTitle + "\"的值。");
                return false;
            }
            if(!int.TryParse(tb.Text,out iVaue))
            {
                this.ShowMsg("请正确输入\"" + sTitle + "\"的值。");
                return false;
            }
            if (iVaue < 0)
            {
                this.ShowMsg("请正确输入\"" + sTitle + "\"的值，必须大于0的整数。");
                return false;
            }
            return true;
        }
        public override void ShowMsg(string strMsg)
        {
            this.labMsg.Text = strMsg;
        }
    }
}
