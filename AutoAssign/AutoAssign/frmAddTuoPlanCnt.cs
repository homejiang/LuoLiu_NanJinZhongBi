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
    public partial class frmAddTuoPlanCnt : Common.frmBase
    {
        string _TestCode = string.Empty;
        frmMain1 _MainForm = null;
        public frmAddTuoPlanCnt(string sTextCode, frmMain1 mainForm)
        {
            InitializeComponent();
            this._TestCode = sTextCode;
            this._MainForm = mainForm;
            this.labTitle.Text = "重置计划模块数";
        }
        public int ResetCount = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string strSql;
            int icnt;
            if(!int.TryParse(this.textBox1.Text,out icnt))
            {
                this.ShowMsg("请输入重置数量。");
                return;
            }
            strSql = string.Format("update Testing_Main set TargetMKCnt={0} where Code='{1}'", icnt, this._TestCode.Replace("'", "''"));
            /**********以后统一了
            if (this._MainForm != null && this._MainForm._AutoMKOnOff == JPSEnum.OnOff.On)
            {
                strSql = string.Format("update Testing_Main set TargetMKCnt={0} where Code='{1}'", icnt, this._TestCode.Replace("'", "''"));

            }
            else if (this._MainForm != null && this._MainForm._AutoMKOnOff == JPSEnum.OnOff.Off)
            {
                strSql = string.Format("update Testing_Main set TargetTuoCnt={0} where Code='{1}'", icnt, this._TestCode.Replace("'", "''"));
            }
            else
            {
                strSql = string.Empty;
            }
            ***************/
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch(Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.ResetCount = icnt;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
