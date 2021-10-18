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
    public partial class frmProuctClassEdit : Common.frmBase
    {
        public short _ClassValue = -9999;
        public frmProuctClassEdit()
        {
            InitializeComponent();
            
        }
        public string ClassName
        {
            get
            {
                return this.tbClassName.Text;
            }
            set
            {
                this.tbClassName.Text = value;
            }
        }
        public override void ShowMsg(string strMsg)
        {
            this.labErr.Text = strMsg;
        }

        private void btTrue_Click(object sender, EventArgs e)
        {
            short iClassValue;
            if(!short.TryParse(this.tbPLCValue.Text,out iClassValue))
            {
                this.ShowMsg("PLC代码读取出错。");
                return;
            }

            if (this.tbClassName.Text.Length == 0)
            {
                this.ShowMsg("请输入分类名称。");
                return;
            }
            string strSql;
            DataTable dt;
            if (this._ClassValue!=iClassValue)
            {
                strSql = string.Format("select count(*) from JC_ProductClass where Value={0} ", iClassValue);
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    return;
                }
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    this.ShowMsg("当前PLC代码已经存在，请勿重复添加！");
                    return;
                }
                strSql = string.Format("select count(*) from JC_ProductClass where ClassName='{0}'", this.tbClassName.Text.Replace("'", "''"));
                try
                {
                    dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
                }
                catch (Exception ex)
                {
                    this.ShowMsg(ex.Message);
                    return;
                }
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    this.ShowMsg("当前分类名称已经存在，请勿重复添加！");
                    return;
                }
            }
            
            int iScanner;
            if (this.radioScanner1.Checked)
                iScanner = 1;
            else if (this.radioScanner1.Checked)
                iScanner = 2;
            else
            {
                iScanner = 0;
            }
            if (this._ClassValue < 0)
            {
                strSql = string.Format("INSERT INTO JC_ProductClass(Value,ClassName,Scanner) VALUES({0},'{1}',{2})", iClassValue, this.tbClassName.Text.Replace("'", "''"), iScanner);
            }
            else
            {
                strSql = string.Format("UPDATE JC_ProductClass SET Scanner={0},ClassName='{1}' WHERE Value={2}", iScanner, this.tbClassName.Text.Replace("'", "''"), iClassValue);
            }
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

        private void frmProuctClassEdit_Load(object sender, EventArgs e)
        {
            if (this._ClassValue > 0)
            {
                this.tbPLCValue.Text = this._ClassValue.ToString();
                this.tbPLCValue.ReadOnly = true;//不允许改了
            }
        }
    }
}
