using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common.Msg
{
    public partial class frmMySetting : Common.frmBaseEdit
    {
        public frmMySetting()
        {
            InitializeComponent();
        }
        #region 窗体数据连接实例
        private BLLDAL.Msg _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        private BLLDAL.Msg BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new Common.BLLDAL.Msg();
                return _dal;
            }
        }
        #endregion
        #region 处理函数
        private bool BindData(string sUserCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("SELECT * FROM Msg_Sys_MySeting WHERE userCode='{0}'"
                    , sUserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return true;
            }
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.chkMainIsReceive.Checked = !dr["MainIsReceive"].Equals(DBNull.Value) && (bool)dr["MainIsReceive"];
                this.chkMainIsAuto.Checked = !dr["MainIsAuto"].Equals(DBNull.Value) && (bool)dr["MainIsAuto"];
                this.tbMainInterval.Text = dr["MainInterval"].ToString();
                this.chkDeskIsStart.Checked = !dr["DeskIsStart"].Equals(DBNull.Value) && (bool)dr["DeskIsStart"];
                this.tbDeskInterval.Text = dr["DeskInterval"].ToString();
            }
            SetFormState();
            return true;
        }
        private void SetFormState()
        {
            this.chkMainIsAuto.Enabled = this.chkMainIsReceive.Checked;
            this.tbMainInterval.Enabled = this.chkMainIsReceive.Checked;
            this.tbDeskInterval.Enabled = this.chkDeskIsStart.Checked;
        }
        #endregion
        private void chkMainIsReceive_CheckedChanged(object sender, EventArgs e)
        {
            SetFormState();
        }
        private void chkDeskIsStart_CheckedChanged(object sender, EventArgs e)
        {
            SetFormState();
        }
        private void btTrue_Click(object sender, EventArgs e)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("SELECT * FROM Msg_Sys_MySeting WHERE userCode='{0}'"
                    , this.PrimaryValue.ToString().Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
            {
                DataRow drNew = dt.NewRow();
                drNew["UserCode"] = this.PrimaryValue.ToString();
                dt.Rows.Add(drNew);
            }
            DataRow dr = dt.Rows[0];
            if ((!dr["MainIsReceive"].Equals(DBNull.Value) && (bool)dr["MainIsReceive"]) ^ this.chkMainIsReceive.Checked)
                dr["MainIsReceive"] = this.chkMainIsReceive.Checked;
            if ((!dr["MainIsAuto"].Equals(DBNull.Value) && (bool)dr["MainIsAuto"]) ^ this.chkMainIsAuto.Checked)
                dr["MainIsAuto"] = this.chkMainIsAuto.Checked;
            long lTemp;
            if (this.chkMainIsReceive.Checked && this.chkMainIsAuto.Checked)
            {
                if (this.tbMainInterval.Text == string.Empty || !long.TryParse(this.tbMainInterval.Text, out lTemp))
                {
                    this.ShowMsg("请正确设置主程序消息设置中的自动刷新间隔的值，需要一个正整数。");
                    return;
                }
                if (dr["MainInterval"].ToString() != lTemp.ToString())
                    dr["MainInterval"] = lTemp;
            }
            //读取桌面消息设置
            if ((!dr["DeskIsStart"].Equals(DBNull.Value) && (bool)dr["DeskIsStart"]) ^ this.chkDeskIsStart.Checked)
                dr["DeskIsStart"] = this.chkDeskIsStart.Checked;
            if (this.chkDeskIsStart.Checked)
            {
                if (this.tbDeskInterval.Text == string.Empty || !long.TryParse(this.tbDeskInterval.Text, out lTemp))
                {
                    this.ShowMsg("请正确设置开机启动消息设置中的自动刷新间隔的值，需要一个正整数。");
                    return;
                }
                if (dr["DeskInterval"].ToString() != lTemp.ToString())
                    dr["DeskInterval"] = lTemp;
            }
            try
            {
                this.BllDAL.SaveMySetting(dt);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("保存成功。");
        }
        private void frmMySetting_Load(object sender, EventArgs e)
        {
            DeskFileCheck();//检测进程启动文件是否存在
            if (this.PrimaryValue == null || this.PrimaryValue.ToString() == string.Empty)
            {
                this.ShowMsg("参数传入错误。");
                this.btTrue.Enabled = false;
                return;
            }
            this.BindData(this.PrimaryValue.ToString());
        }
        private void DeskFileCheck()
        {
            //校验ERPLogMsg是否存在，如果不存在，则用设置此程序
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "ERPLogMsg.exe";
            if (System.IO.File.Exists(strFile))
                this.labDeskFileCheck.Visible = false;
            else this.labDeskFileCheck.Visible = true;
        }
    }
}