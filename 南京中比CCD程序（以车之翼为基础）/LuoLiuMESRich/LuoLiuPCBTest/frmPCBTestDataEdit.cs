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

namespace LuoLiuPCBTest
{
    public partial class frmPCBTestDataEdit : Common.frmBaseEdit
    {
        public frmPCBTestDataEdit()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.PCBProduct _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.PCBProduct BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PCBProduct();
                return _dal;
            }
        }
        #endregion
        private string ActiveTable = string.Empty;

        #region 函数处理
        private bool Perinit()
        {
            this.dgHisRecord.AutoGenerateColumns = false;
             return true;
        }
        private void SetResult(short iValue)
        {
            Color cB, cF;
            string strText;
            if (iValue == 1)
            {
                cB = Color.Lime;
                cF = Color.Black;
                strText = "合格";
            }
            else if (iValue == 2)
            {
                cB = Color.Red;
                cF = Color.White;
                strText = "不合格";
            }
            else
            {
                cB = Color.White;
                cF = Color.Black;
                strText = "------";
            }
            if (this.labResult.Text != strText)
                this.labResult.Text = strText;
            if (this.labResult.ForeColor != cF)
                this.labResult.ForeColor = cF;
            if (this.labResult.BackColor != cB)
                this.labResult.BackColor = cB;
        }
        private bool BindData(string sGUID)
        {
            //业务数据库读取数据
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM V_PCB_TestData_Cgy WHERE GUID='{0}'", sGUID.Replace("'", "''")), "PCB_TestData", true));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }

            //绑定生产数据
            DataRow dr = ds.Tables["PCB_TestData"].Rows[0];
            this.tbPcbCode.Text = dr["PcbCode"].ToString();
            this.tbCellCount.Text = dr["CellCount"].ToString();
            this.tbRemark.Text = dr["Remark"].ToString();
            this.tbLotNumber.Text = dr["LotNumber"].ToString();
            this.tbModel.Text = dr["Model"].ToString();
            this.tbSpendTime.Text = dr["SpendTime"].ToString() ;
            this.tbStartTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["StartTime"].ToString(), "yyyy-MM-dd HH:ss:mm");
            this.tbEndTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["EndTime"].ToString(), "yyyy-MM-dd HH:ss:mm");
            this.myTester.Tag = dr["Operator"].ToString();
            this.myTester.Text = dr["OperatorName"].ToString();
            this.myMacCode.Tag= dr["MacCode"].ToString();
            this.myMacCode.Text = dr["MacName"].ToString();
            this.myStation.Tag = dr["StationCode"].ToString();
            this.myStation.Text = dr["StationName"].ToString();
            ActiveTable = dr["ActiveTable"].ToString();
            this.SetResult(short.Parse(dr["Quality"].ToString()));
            //实时数据库读取参数

            DataSet dsRead = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSqlRead = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSqlRead.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM " + ActiveTable + " WHERE GUID='{0}'", sGUID.Replace("'", "''")), "Mac_PCB_Parameters", true));
            try
            {
               dsRead = Common.CommonDAL.DoSqlCommand.GetDateSet(listSqlRead);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            //绑定明细
            this.dgHisRecord.DataSource = dsRead.Tables["Mac_PCB_Parameters"];
            this.DataSource = ds;
            return true;
        }
        private object GetComboBoxValue(ComboBox combox)
        {
            if (combox.SelectedItem == null) return DBNull.Value;
            Common.MyEntity.ComboBoxItem item = combox.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null) return DBNull.Value;
            return item.Value;
        }
        #endregion
        #region 窗体加载
        private void frmPCBTestDataEdit_Load(object sender, EventArgs e)
        {
            //先判断权限，用户只要有只读权限就可以打开
            // 先校验权限
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PCBManage);
            if (listPower.Count == 0)
            {
                this.ShowMsg("你没有权限查看此模块，窗口将自动关闭。");
                this.FormColse();
                return;
            }
            if (!this.Perinit()) return;
            this.FormState = Common.MyEnums.FormStates.Edit;
            if (this.PrimaryValue == null || this.PrimaryValue.ToString().Length == 0)
            {
                return;
            }
            string sGUID = this.PrimaryValue.ToString();
            this.BindData(sGUID);
        }
        #endregion
        #region 控件按钮
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PCBManage);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Delete))
            {
                this.ShowMsg("你没有此模块的删除权限。");
                return;
            }
            DialogResult result = MessageBox.Show(this, "您确定要删除此信息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            else if (result == DialogResult.Yes)
            {
                this.DelPCBTestData(this.PrimaryValue.ToString(), ActiveTable);
            }
            this.FormColse(null, false);
        }
        private void 文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失,请重新加载预制棒监测纤信息。");
                return;
            }
            List<Common.MyEnums.OperatePower> listPower = this.GetOperatePower(Common.MyEnums.Modules.PCBManage);
            if (!listPower.Contains(Common.MyEnums.OperatePower.Eidt))
            {
                this.ShowMsg("你没有权限查看此模块。");
                return;
            }

            DataSet dsSource = this.DataSource.Copy();
            if (SaveModifyLog(this.PrimaryValue.ToString()))
            {
                if (this.Save(dsSource))
                {
                    this.ShowMsgRich();
                    this.BindData(this.PrimaryValue.ToString());
                }
            }
        }
        private void linkUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit && this.FormState != Common.MyEnums.FormStates.New)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失,请重新加载信息。");
                return;
            }
            Common.Login.frmFindUser frm = new Common.Login.frmFindUser();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (this.DataSource.Tables["PCB_TestData"].DefaultView[0].Row["Operator"].ToString().ToLower() != frm._SelUserCode.ToLower())
            {

                DataTable dt = null;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT *,dbo.SysSetting_GetDeptFullName(DeptCode) AS DeptFullName FROM V_sys_users WHERE UserCode='{0}'", frm._SelUserCode.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.myTester.Tag = dt.Rows[0]["UserCode"].ToString();
                this.myTester.Text = dt.Rows[0]["UserName"].ToString();
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit && this.FormState != Common.MyEnums.FormStates.New)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失,请重新加载信息。");
                return;
            }
            BasicData.ProcessMacs.frmSelectMacs frm = new BasicData.ProcessMacs.frmSelectMacs();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (this.DataSource.Tables["PCB_TestData"].DefaultView[0].Row["MacCode"].ToString() != frm.SelectedData[0].Code.ToString())
            {

                this.myMacCode.Tag = frm.SelectedData[0].Code.ToString();
                this.myMacCode.Text = frm.SelectedData[0].MacName.ToString();
            }

        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.FormState != Common.MyEnums.FormStates.Edit && this.FormState != Common.MyEnums.FormStates.New)
            {
                this.ShowMsg("当前窗体状态不能编辑。");
                return;
            }
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源丢失,请重新加载信息。");
                return;
            }
            BasicData.Station.frmSelectStation frm = new BasicData.Station.frmSelectStation();
            if (DialogResult.OK != frm.ShowDialog(this))
                return;
            if (this.DataSource.Tables["PCB_TestData"].DefaultView[0].Row["StationCode"].ToString() != frm.SelectedData[0].Code.ToString())
            {

                this.myStation.Tag = frm.SelectedData[0].Code.ToString();
                this.myStation.Text = frm.SelectedData[0].StationName.ToString();
            }

        }
        #endregion

        #region 保存数据
        private void DelPCBTestData(string sGuid,string sActiveTable)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.DelPCBTestData(sGuid, sActiveTable, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
            if (iReturnValue == 0)
            {
                if (!this.IsUserConfirm(strMsg)) return;
            }
            else if (iReturnValue != 1)
            {
                if (strMsg == "") strMsg = "数据插入失败，请联系管理员。";
                this.ShowMsg(strMsg);
                return;
            }
        }
        private bool ReadForm(DataSet ds)
        {
            DataRow dr = ds.Tables["PCB_TestData"].DefaultView[0].Row;
            dr["PcbCode"] = this.tbPcbCode.Text;
            //读取输入的生产参数
            if (!dr["CellCount"].Equals(this.tbCellCount.Text))
                dr["CellCount"] = this.tbCellCount.Text;
            if (dr["LotNumber"].ToString() != this.tbLotNumber.Text)
                dr["LotNumber"] = this.tbLotNumber.Tag.ToString();
            if (dr["Model"].ToString() != this.tbModel.Text)
                dr["Model"] = this.tbModel.Text.ToString();
            if (dr["Remark"].ToString() != this.tbRemark.Text)
                dr["Remark"] = this.tbRemark.Text.ToString();
            if (dr["StartTime"].ToString() != this.tbStartTime.Text)
                dr["StartTime"] = this.tbStartTime.Text.ToString();
            if (dr["EndTime"].ToString() != this.tbEndTime.Text)
                dr["EndTime"] = this.tbEndTime.Text.ToString();
            if (dr["SpendTime"].ToString() != this.tbSpendTime.Text)
                dr["SpendTime"] = this.tbSpendTime.Text.ToString();
            if (dr["MacCode"].ToString() != this.myMacCode.Tag.ToString())
                dr["MacCode"] = this.myMacCode.Tag.ToString();
            if (dr["StationCode"].ToString() != this.myStation.Tag.ToString())
                dr["StationCode"] = this.myStation.Tag.ToString();
            if (dr["Operator"].ToString() != this.myTester.Tag.ToString())
                dr["Operator"] = this.myTester.Tag.ToString();
            if (dr["OperatorName"].ToString() != this.myTester.Text)
                dr["OperatorName"] = this.myTester.Text;
            return true;
        }
        private bool Save(DataSet ds)
        {
            if (!this.ReadForm(ds)) return false;
            if (ds.GetChanges() == null) return true;
            string sError;
            int iReturnValue;
            try
            {
                this.BllDAL.Save(ds, out sError, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (sError.Length == 0)
                    sError = "操作失败,原因未知";
                this.ShowMsg(sError);
                return false;
            }
            return true;
        }
        private bool SaveModifyLog(string sGuid)
        {
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.ModifyFinished(sGuid, out iReturnValue, out strMsg);
            }
            catch (Exception ex)
            {
                ErrorService.wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strMsg == "") strMsg = "数据修改失败，请联系管理员。";
                this.ShowMsg(strMsg);
                return false;
            }

            return true;
        }


        #endregion

       
    }
}
