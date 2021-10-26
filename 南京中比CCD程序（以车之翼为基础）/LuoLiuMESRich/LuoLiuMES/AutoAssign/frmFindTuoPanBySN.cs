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
namespace LuoLiuMES.AutoAssign
{
    public partial class frmFindTuoPanBySN : Common.frmBase
    {
        public string _TuoPan = string.Empty;
        string _SN = string.Empty;
        public frmFindTuoPanBySN(string sSN)
        {
            InitializeComponent();
            _SN = sSN;
        }
        private bool Finding()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT a.name FROM LuoLiuMESDynamicTable.DBO.SYSOBJECTS a left join LuoLiuMESDynamicTable.DBO.syscolumns b on b.id=a.id WHERE a.name LIKE 'Produce_Assign_Dx_%' AND a.xtype='U' and b.name='TuoPan'");
            }
            catch(Exception ex)
            {
                ShowErr(ex);
                return false;
            }
            foreach(DataRow dr in dt.Rows)
            {
                DataTable dtFind;
                try
                {
                    dtFind = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TuoPan FROM LuoLiuMESDynamicTable.DBO.{0} WHERE DxSn='{1}'"
                        , dr["name"].ToString(), this._SN));
                }
                catch(Exception ex)
                {
                    ShowErr(ex);
                    return false;
                }
                if(dtFind.Rows.Count>0)
                {
                    //此时找到了
                    _TuoPan = dtFind.Rows[0]["TuoPan"].ToString();
                    return true;
                }
            }
            this.ShowErr("找不到该电芯的任何记录。");
            return false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.Finding())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        public void ShowErr(Exception ex)
        {
            ShowErr(ex.Message);
        }
        public void ShowErr(string strMsg)
        {
            this.labMsg.ForeColor = Color.Red;
            this.labMsg.Text = strMsg;
        }

        private void frmFindTuoPanBySN_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 500;
            this.timer1.Enabled = true;
        }
    }
}
