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
namespace LuoLiuDianHan.PeiFang
{
    public partial class frmPfSendPLC : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.HanJie _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.HanJie BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.HanJie();
                return _dal;
            }
        }
        #endregion 
        HanJieOPC.OPCHelperPointSetting _OpcHelper = null;
        private string _GUID = string.Empty;
        public frmPfSendPLC(string sGuid)
        {
            InitializeComponent();
            this._GUID = sGuid;
        }
       
        #region 消息处理
        public void  ShowErr(string sMsg)
        {
        }
        private void ShowLog(string sLog)
        {

        }
        #endregion

        #region  处理函数
        private bool Perinit()
        {
            this.myDataGridView1.AutoGenerateColumns = false;
            _OpcHelper = new HanJieOPC.OPCHelperPointSetting(Config.GetOPCTitle);
            _OpcHelper.IsDebug = LuoLiuDianHan.Communication.Debug.OPCDebug;
            string strErr;
            if (!this._OpcHelper.InitServer(out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            return true;
        }
        public bool GetWriteDoingData(out int iLP_Cnt, out int iRP_Cnt, out int iBC_A1, out int iBC_A2, out int iBC_A3, out int iBC_A4, out int iBC_A5, out int iBC_A6
                            , out int iBC_B1, out int iBC_B2, out int iBC_B3, out int iBC_B4, out int iBC_B5, out int iBC_B6)
        {
            iLP_Cnt = 0;
            iRP_Cnt = 0;
            iBC_A1 = 0;
            iBC_A2 = 0;
            iBC_A3 = 0;
            iBC_A4 = 0;
            iBC_A5 = 0;
            iBC_A6 = 0;

            iBC_B1 = 0;
            iBC_B2 = 0;
            iBC_B3 = 0;
            iBC_B4 = 0;
            iBC_B5 = 0;
            iBC_B6 = 0;
            if (!this.GetInt("左焊点个数", this.tbLCnt.Text, out iLP_Cnt)) return false;
            if (!this.GetInt("右焊点个数", this.tbRCnt.Text, out iLP_Cnt)) return false;
            if (!this.GetInt("工位1的左进给", this.tbBC_A1.Text, out iBC_A1)) return false;
            if (!this.GetInt("工位1的左前后", this.tbBC_A2.Text, out iBC_A2)) return false;
            if (!this.GetInt("工位1的左提升", this.tbBC_A3.Text, out iBC_A3)) return false;
            if (!this.GetInt("工位1的右进给", this.tbBC_A4.Text, out iBC_A4)) return false;
            if (!this.GetInt("工位1的右前后", this.tbBC_A5.Text, out iBC_A5)) return false;
            if (!this.GetInt("工位1的右提升", this.tbBC_A6.Text, out iBC_A6)) return false;
            if (!this.GetInt("工位2的左进给", this.tbBC_B1.Text, out iBC_B1)) return false;
            if (!this.GetInt("工位2的左前后", this.tbBC_B2.Text, out iBC_B2)) return false;
            if (!this.GetInt("工位2的左提升", this.tbBC_B3.Text, out iBC_B3)) return false;
            if (!this.GetInt("工位2的右进给", this.tbBC_B4.Text, out iBC_B4)) return false;
            if (!this.GetInt("工位2的右前后", this.tbBC_B5.Text, out iBC_B5)) return false;
            if (!this.GetInt("工位2的右提升", this.tbBC_B6.Text, out iBC_B6)) return false;
            return true;
        }
        private bool GetInt(string sTag,string tbText,out int iValue)
        {
            if(tbText.Length==0)
            {
                iValue = 0;
                this.ShowMsg(string.Format("{0}的值不正确，不能为空！"));
                return false;
            }
            else
            {
                if(!int.TryParse(tbText,out iValue))
                {
                    iValue = 0;
                    this.ShowMsg(string.Format("{0}的值不正确，不是有效整数！"));
                    return false;
                }
                return true;
            }
        }
        #endregion
        private string GetBcText(object dbValue)
        {
            return dbValue.ToString();
            //decimal dec;
            //if (dbValue == null || dbValue.Equals(DBNull.Value))
            //    return string.Empty;
            //dec = decimal.Parse(dbValue.ToString());
            //dec = dec / 1000M;

            //return dec.ToString("#########0.000");
        }

        #region 加载数据
        private bool BindData()
        {
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Mac_DianHan_PeiFang WHERE GUID='{0}'",this._GUID.Replace("'","''")), "Mac_DianHan_PeiFang", true));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM Mac_DianHan_PeiFangPoints WHERE GUID='{0}' order by Pindex asc", this._GUID.Replace("'","''")), "Mac_DianHan_PeiFangPoints", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;   
            }
            if(ds.Tables["Mac_DianHan_PeiFang"].DefaultView.Count==0)
            {
                this.ShowMsg("传入的配方不存在！");
                return false;
            }
            DataRow dr = ds.Tables["Mac_DianHan_PeiFang"].DefaultView[0].Row;
            this.tbName.Text = dr["PName"].ToString();
            this.tbLCnt.Text = dr["LP_Cnt"].ToString();
            this.tbRCnt.Text = dr["RP_Cnt"].ToString();
            //补偿数据
            this.tbBC_A1.Text = this.GetBcText(dr["BC_A1"]);
            this.tbBC_A2.Text = this.GetBcText(dr["BC_A2"]);
            this.tbBC_A3.Text = this.GetBcText(dr["BC_A3"]);
            this.tbBC_A4.Text = this.GetBcText(dr["BC_A4"]);
            this.tbBC_A5.Text = this.GetBcText(dr["BC_A5"]);
            this.tbBC_A6.Text = this.GetBcText(dr["BC_A6"]);
            this.tbBC_B1.Text = this.GetBcText(dr["BC_B1"]);
            this.tbBC_B2.Text = this.GetBcText(dr["BC_B2"]);
            this.tbBC_B3.Text = this.GetBcText(dr["BC_B3"]);
            this.tbBC_B4.Text = this.GetBcText(dr["BC_B4"]);
            this.tbBC_B5.Text = this.GetBcText(dr["BC_B5"]);
            this.tbBC_B6.Text = this.GetBcText(dr["BC_B6"]);
            DataTable dtPoints = ds.Tables["Mac_DianHan_PeiFangPoints"];
            DataColumn dc = new DataColumn("P_WorkView", typeof(string));
            dc.Expression = "IIF(isnull(P_Work,0)=1,'是','否')";
            dtPoints.Columns.Add(dc);
            this.myDataGridView1.DataSource = ds.Tables["Mac_DianHan_PeiFangPoints"];
            return true;
        }
       
        #endregion

        private void frmAddPf_Load(object sender, EventArgs e)
        {
            if (!this.Perinit()) return;
            if(!this.BindData())
            {
                this.FormState = Common.MyEnums.FormStates.None;
                return;
            }
            this.FormState = Common.MyEnums.FormStates.New;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            if(this.FormState==Common.MyEnums.FormStates.None)
            {
                this.ShowMsg("窗口状态无效！");
                return;
            }
            string strErr;
            if(!this._OpcHelper.SetWriteDoing(2,out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            System.Threading.Thread.Sleep(50);
            if (!this.WriteDoingValues()) return;
            //此时写入成功，打开进度显示
            DataTable dt = this.myDataGridView1.DataSource as DataTable;
            dt.DefaultView.Sort = "Pindex ASC";
            frmPfSendPLCProcess frm = new frmPfSendPLCProcess(dt, this._OpcHelper);
            frm.Show(this);
        }
        private bool WriteDoingValues()
        {
            int iLP_Cnt;
            int iRP_Cnt;
            int iBC_A1;
            int iBC_A2;
            int iBC_A3;
            int iBC_A4;
            int iBC_A5;
            int iBC_A6;

            int iBC_B1;
            int iBC_B2;
            int iBC_B3;
            int iBC_B4;
            int iBC_B5;
            int iBC_B6;
            if (!this.GetInt("左焊点个数", this.tbLCnt.Text, out iLP_Cnt)) return false;
            if (!this.GetInt("右焊点个数", this.tbRCnt.Text, out iRP_Cnt)) return false;
            if (!this.GetInt("工位1的左进给", this.tbBC_A1.Text, out iBC_A1)) return false;
            if (!this.GetInt("工位1的左前后", this.tbBC_A2.Text, out iBC_A2)) return false;
            if (!this.GetInt("工位1的左提升", this.tbBC_A3.Text, out iBC_A3)) return false;
            if (!this.GetInt("工位1的右进给", this.tbBC_A4.Text, out iBC_A4)) return false;
            if (!this.GetInt("工位1的右前后", this.tbBC_A5.Text, out iBC_A5)) return false;
            if (!this.GetInt("工位1的右提升", this.tbBC_A6.Text, out iBC_A6)) return false;
            if (!this.GetInt("工位2的左进给", this.tbBC_B1.Text, out iBC_B1)) return false;
            if (!this.GetInt("工位2的左前后", this.tbBC_B2.Text, out iBC_B2)) return false;
            if (!this.GetInt("工位2的左提升", this.tbBC_B3.Text, out iBC_B3)) return false;
            if (!this.GetInt("工位2的右进给", this.tbBC_B4.Text, out iBC_B4)) return false;
            if (!this.GetInt("工位2的右前后", this.tbBC_B5.Text, out iBC_B5)) return false;
            if (!this.GetInt("工位2的右提升", this.tbBC_B6.Text, out iBC_B6)) return false;
            string strErr;
            if(!this._OpcHelper.StartWriteDoing(iLP_Cnt, iRP_Cnt, iBC_A1, iBC_A2, iBC_A3, iBC_A4, iBC_A5, iBC_A6
                            , iBC_B1, iBC_B2, iBC_B3, iBC_B4, iBC_B5, iBC_B6,out strErr))
            {
                this.ShowMsg(strErr);
                return false;
            }
            return true;
        }

        private void linkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMyLogB.ShowMyLog(string.Empty);
        }
        
    }
}
