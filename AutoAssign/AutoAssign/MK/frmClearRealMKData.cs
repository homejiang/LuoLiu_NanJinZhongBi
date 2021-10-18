using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;

namespace AutoAssign.MK
{
    public partial class frmClearRealMKData : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.Testing _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.Testing BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.Testing();
                return _dal;
            }
        }
        #endregion 
        JPSEntity.MKBuilding _MKBuilding = null;
        public frmClearRealMKData(BLLDAL.Testing dal, JPSEntity.MKBuilding mkbuilding)
        {
            InitializeComponent();
            this._dal = dal;
            this._MKBuilding = mkbuilding;
        }
        string _PlcBatCode = string.Empty;
        bool _ExisitRealMK = false;
        short _Finished = 0;
        public void BindData(DataTable dt,string sPlcBatCode,short iFinished)
        {
            if(dt.Rows.Count>0)
            {
                DataRow dr = dt.Rows[0];
                this.tbTestCode.Text = dr["TestCode"].ToString();
                this.tbMkCode.Text = dr["Code"].ToString();
                this.tbCreateTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateTime"], "yyyy-MM-dd HH:mm:ss");
                this.tbBatCnt.Text = dr["BatCnt"].ToString();
                this.tbAsbCnt.Text = dr["AsbCnt"].ToString();
                _ExisitRealMK = true;
            }
            else
            {
                this.tbTestCode.Clear();
                this.tbMkCode.Clear();
                this.tbCreateTime.Clear();
                this.tbBatCnt.Clear();
                this.tbAsbCnt.Clear();
                _ExisitRealMK = false;
            }
            string strPlc=string.Empty;
            if(sPlcBatCode.Length>0)
            {
                strPlc = string.Format("电芯序号：{0}\r\n",sPlcBatCode);
                _PlcBatCode = sPlcBatCode;
            }
            else
            {
                _PlcBatCode = string.Empty;
            }
            if(iFinished==1)
            {
                strPlc += "插装完成状态：已完成";
            }
            _Finished = iFinished;
            this.tbPlcData.Text = strPlc;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            string strErr;
            if (this._ExisitRealMK)
            {
                //清除实施数据
                int iReturnValue;
                try
                {
                    this.BllDAL.Assemble_ClearRealMKData(out iReturnValue, out strErr);
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if(iReturnValue!=1)
                {
                    if (strErr.Length == 0) strErr = "清楚模块实时数据失败，原因未知！";
                    this.ShowMsg(strErr);
                    return;
                }
            }
            if(this._PlcBatCode.Length>0)
            {
                if(this._MKBuilding==null)
                {
                    this.ShowMsg("PLC通讯对象为空，清除失败！");
                    return;
                }
                if(!this._MKBuilding._OPCHelperMKBuilding.ClearBatCodes(out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
            }
            if(this._Finished==1)
            {
                if (this._MKBuilding == null)
                {
                    this.ShowMsg("PLC通讯对象为空，清除失败！");
                    return;
                }
                if (!this._MKBuilding._OPCHelperMKBuilding.ResetFinished(out strErr))
                {
                    this.ShowMsg(strErr);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
