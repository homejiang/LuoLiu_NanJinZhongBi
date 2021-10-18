using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.BasicData
{
    public partial class frmProuctSpecEdit : Common.frmBase
    {
        string _Guid = string.Empty;
        short _ClassValue = -99;
        public frmProuctSpecEdit(string sGuid,short iClassValue)
        {
            InitializeComponent();
            this._Guid = sGuid;
            this._ClassValue = iClassValue;
        }
        public override void ShowMsg(string strMsg)
        {
            this.labErr.Text = strMsg;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            string strSql = string.Format("select count(*) from JC_ProductSpec where ClassValue={0} and Spec='{1}' and guid<>'{2}'", this._ClassValue, this.tbSpec.Text.Replace("'", "''"), this._Guid.Replace("'", "''"));
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            if (int.Parse(dt.Rows[0][0].ToString())>0)
            {
                this.ShowMsg("当前电芯类别下已经有该规格名称，请更换！");
                return;
            }
            string sGuid = Guid.NewGuid().ToString();
            strSql = string.Format("INSERT INTO JC_ProductSpec(GUID,Spec,ClassValue) VALUES('{0}','{1}',{2})", sGuid.Replace("'", "''"), this.tbSpec.Text.Replace("'", "''"), this._ClassValue);
            try
            {
                Common.CommonDAL.DoSqlCommandBasic.DoSql(strSql);
            }
            catch (Exception ex)
            {
                this.ShowMsg(ex.Message);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
