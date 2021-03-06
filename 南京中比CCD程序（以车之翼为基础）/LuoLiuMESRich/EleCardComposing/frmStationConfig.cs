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

namespace EleCardComposing
{
    public partial class frmStationConfig : Common.frmBase
    {
        string _ProcessCode = string.Empty;
        string _StationCode = string.Empty;
        string _MacCode = string.Empty;
        public frmStationConfig(bool blFixedProcess=false)
        {
            InitializeComponent();
            if(blFixedProcess)
            {
                this.linkProcess.LinkArea = new LinkArea(0, 0);
            }
            else
            {
                this.linkProcess.LinkArea = new LinkArea(0, this.linkProcess.Text.Length);
            }
        }

        private void frmStationConfig_Load(object sender, EventArgs e)
        {
            if (!this.BindProcess(Config.ProcessCode))
                this._ProcessCode = string.Empty;
            else this._ProcessCode = Config.ProcessCode;

            if (!this.BindStation(Config.StationCode))
                this._StationCode = string.Empty;
            else this._StationCode = Config.StationCode;

        }
        private bool BindProcess(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ProcessName FROM JC_Process WHERE Code='{0}'"
                    , sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            this.tbProcess.Text = dt.Rows[0]["ProcessName"].ToString();
            return true;
        }
        private bool BindStation(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT StationName FROM JC_Station WHERE Code='{0}'"
                    , sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            this.tbStation.Text = dt.Rows[0]["StationName"].ToString();
            return true;
        }
        private bool BindMac(string sCode)
        {
            //DataTable dt;
            //try
            //{
            //    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'"
            //        , sCode.Replace("'", "''")));
            //}
            //catch (Exception ex)
            //{
            //    wErrorMessage.ShowErrorDialog(this, ex);
            //    return false;
            //}
            //if (dt.Rows.Count == 0) return false;
            //this.tbMac.Text = dt.Rows[0]["MacName"].ToString();
            return true;
        }

        private void linkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.Process.frmSelectProcess frm = new BasicData.Process.frmSelectProcess();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this._ProcessCode = frm.SelectedData[0].Code.ToString();
            this.tbProcess.Text = frm.SelectedData[0].ProcessName.ToString();
        }

        private void linkStation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.Station.frmSelectStation frm = new BasicData.Station.frmSelectStation();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this._StationCode = frm.SelectedData[0].Code.ToString();
            this.tbStation.Text = frm.SelectedData[0].StationName.ToString();
        }

        private void linkMac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //BasicData.ProcessMacs.frmSelectMacs frm = new BasicData.ProcessMacs.frmSelectMacs();
            //frm.DefaultProcessCode = this._ProcessCode;
            //frm.MultiSelected = false;
            //if (DialogResult.OK != frm.ShowDialog(this)) return;
            //if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            //this._MacCode = frm.SelectedData[0].Code.ToString();
            //this.tbMac.Text = frm.SelectedData[0].MacName.ToString();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this._ProcessCode.Length==0)
            {
                this.ShowMsg("请选择工序");
                return;
            }
            if (this._StationCode.Length == 0)
            {
                this.ShowMsg("请选择站点");
                return;
            }
            //if (this._MacCode.Length == 0)
            //{
            //    this.ShowMsg("请选择设备号");
            //    return;
            //}
            Config.ProcessCode = this._ProcessCode;
            Config.StationCode = this._StationCode;


            Config.ProcessName = this.tbProcess.Text;
            Config.StationName = this.tbStation.Text;
            //写入配置文件呢
            Common.CommonFuns.ConfigINI.INIFileName = "Config.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("Station", "ProcessCode", Config.ProcessCode);
                Common.CommonFuns.ConfigINI.SetValue("Station", "StationCode", Config.StationCode);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
