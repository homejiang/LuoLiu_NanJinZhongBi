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

namespace AutoAssign.Setting
{
    public partial class frmStationConfig : Common.frmBase
    {
        string _ProcessCode = string.Empty;
        string _StationCode = string.Empty;
        string _MacCode = string.Empty;
        public frmStationConfig(bool blFixedProcess=false)
        {
            InitializeComponent();
            
        }

        private void frmStationConfig_Load(object sender, EventArgs e)
        {
            this.numMacNo.Value = JPSConfig.MacNo;

            if (!this.BindStation(JPSConfig.StationCode))
                this._StationCode = string.Empty;
            else this._StationCode = JPSConfig.StationCode;

            if (!this.BindMac(JPSConfig.MacCode))
                this._MacCode = string.Empty;
            else this._MacCode = JPSConfig.MacCode;
        }
        private bool BindStation(string sCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(string.Format("SELECT StationName FROM JC_Station WHERE Code='{0}'"
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
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandRemoteMES.GetDateTable(string.Format("SELECT MacName FROM JC_ProcessMacs WHERE Code='{0}'"
                    , sCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return false;
            this.tbMac.Text = dt.Rows[0]["MacName"].ToString();
            return true;
        }
        

        private void linkStation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectStation frm = new frmSelectStation();
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this._StationCode = frm.SelectedData[0].Code.ToString();
            this.tbStation.Text = frm.SelectedData[0].StationName.ToString();
        }

        private void linkMac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSelectMacs frm = new frmSelectMacs();
            frm.DefaultProcessCode = this._ProcessCode;
            frm.MultiSelected = false;
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm.SelectedData == null || frm.SelectedData.Count == 0) return;
            this._MacCode = frm.SelectedData[0].Code.ToString();
            this.tbMac.Text = frm.SelectedData[0].MacName.ToString();
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if (this._StationCode.Length == 0)
            {
                this.ShowMsg("请选择站点");
                return;
            }
            if (this._MacCode.Length == 0)
            {
                this.ShowMsg("请选择设备号");
                return;
            }
            JPSConfig.StationCode = this._StationCode;
            JPSConfig.MacCode = this._MacCode;
            JPSConfig.MacName = this.tbMac.Text;
            JPSConfig.MacNo = (short)this.numMacNo.Value;
            //写入配置文件呢
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            try
            {
                Common.CommonFuns.ConfigINI.SetValue("sysSt", "StationCode", JPSConfig.StationCode);
                Common.CommonFuns.ConfigINI.SetValue("sysSt", "MacCode", JPSConfig.MacCode);
                Common.CommonFuns.ConfigINI.SetValue("sysSt", "MacNo", JPSConfig.MacNo.ToString());
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
