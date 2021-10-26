using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES.AutoExe
{
    public partial class frmSysFormEditPower : Common.frmBaseEdit
    {
        public frmSysFormEditPower()
        {
            InitializeComponent();
        }
        public int _EnumNo=-1;
        public string _Powers;
        public string _MoudleName = string.Empty;
        public bool BindData()
        {
            if (_EnumNo > 0)
            {
                this.tbEnumNo.Text = _EnumNo.ToString();
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC AutoExe_SysForm_GetMoudleInfo {0}"
                        , _EnumNo));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return false;
                }
                this.tbModuleInfo.Text = dt.Rows[0]["ModuleInfo"].ToString();
            }
            string str = "、" + _Powers + "、";
            this.chkCk.Checked = str.IndexOf("、查看、") >= 0;
            this.chkXz.Checked = str.IndexOf("、新增、") >= 0;
            this.chkBj.Checked = str.IndexOf("、编辑、") >= 0;
            this.chkSc.Checked = str.IndexOf("、删除、") >= 0;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int iEnumNo;
            if (!int.TryParse(this.tbEnumNo.Text, out iEnumNo))
            {
                this.ShowMsg("枚举值必须为数值。");
                return;
            }
            //获取模块名
            string strMName = string.Empty;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ModuleName FROM Sys_Module WHERE EnumNo={0}", iEnumNo));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            if (dt.Rows.Count == 0)
                _MoudleName = "未定义";
            else _MoudleName = dt.Rows[0]["ModuleName"].ToString();
            _EnumNo = iEnumNo;
            string str = string.Empty;
            if (this.chkCk.Checked)
                str += "查看、";
            if (this.chkXz.Checked)
                str += "新增、";
            if (this.chkBj.Checked)
                str += "编辑、";
            if (this.chkSc.Checked)
                str += "删除、";
            if (str != string.Empty)
                str = str.Substring(0, str.Length - 1);
            this._Powers = str;
            this.DialogResult = DialogResult.OK;
        }
        private void tbEnumNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            int iEnumNo;
            if (!int.TryParse(this.tbEnumNo.Text, out iEnumNo))
            {
                this.ShowMsg("请输入数值。");
                return;
            }
            else
            {
                DataTable dt;
                try
                {
                    dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC AutoExe_SysForm_GetMoudleInfo {0}"
                        , iEnumNo));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                this.tbModuleInfo.Text = dt.Rows[0]["ModuleInfo"].ToString();
            }
        }

        private void frmSysFormEditPower_Load(object sender, EventArgs e)
        {
            this.btTrue.Enabled = BindData();
        }
    }
}