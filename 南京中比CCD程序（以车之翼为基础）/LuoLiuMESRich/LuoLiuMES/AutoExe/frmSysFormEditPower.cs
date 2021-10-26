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
            string str = "��" + _Powers + "��";
            this.chkCk.Checked = str.IndexOf("���鿴��") >= 0;
            this.chkXz.Checked = str.IndexOf("��������") >= 0;
            this.chkBj.Checked = str.IndexOf("���༭��") >= 0;
            this.chkSc.Checked = str.IndexOf("��ɾ����") >= 0;
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int iEnumNo;
            if (!int.TryParse(this.tbEnumNo.Text, out iEnumNo))
            {
                this.ShowMsg("ö��ֵ����Ϊ��ֵ��");
                return;
            }
            //��ȡģ����
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
                _MoudleName = "δ����";
            else _MoudleName = dt.Rows[0]["ModuleName"].ToString();
            _EnumNo = iEnumNo;
            string str = string.Empty;
            if (this.chkCk.Checked)
                str += "�鿴��";
            if (this.chkXz.Checked)
                str += "������";
            if (this.chkBj.Checked)
                str += "�༭��";
            if (this.chkSc.Checked)
                str += "ɾ����";
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
                this.ShowMsg("��������ֵ��");
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