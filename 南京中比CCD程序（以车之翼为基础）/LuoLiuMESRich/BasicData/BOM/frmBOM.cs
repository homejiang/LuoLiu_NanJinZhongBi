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

namespace BasicData.BOM
{
    public partial class frmBOM : Common.frmBase
    {
        #region 窗体数据连接实例
        public BLLDAL.BOMBase _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.BOMBase BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.BOMBase();
                return _dal;
            }
        }
        #endregion
        public frmBOM()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取结构值
        /// </summary>
        /// <param name="dtSource">来自BOM_Product_Structure的数据源</param>
        /// <param name="sStruCode">结构唯一标识，数据来源：BasicData.BasicEntitys.SysDefaultValues.SysBomStruGuid</param>
        /// <returns></returns>
        public virtual string GetStruValueDecimal(DataTable dtSource, string sStruCode,string sFormat)
        {
            DataRow[] drs = dtSource.Select(string.Format("StructGuid='{0}'", sStruCode));
            if (drs.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                string strValue = drs[0]["StructValue"].ToString();
                if (strValue.Length == 0) return string.Empty;
                decimal dec;
                if (!decimal.TryParse(strValue, out dec)) return string.Empty;
                if (sFormat.Length == 0) sFormat = "#########0.######";
                return dec.ToString(sFormat);
            }
        }
        public virtual string GetStruValueInt(DataTable dtSource, string sStruCode)
        {
            DataRow[] drs = dtSource.Select(string.Format("StructGuid='{0}'", sStruCode));
            if (drs.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                string strValue = drs[0]["StructValue"].ToString();
                if (strValue.Length == 0) return string.Empty;
                decimal ivalue;
                if (!decimal.TryParse(strValue, out ivalue)) return string.Empty;
                return ivalue.ToString("#########0");
            }
        }
        public virtual void SaveStruValue(DataTable dtSource, string sBomGuid, string sStruCode, object sUnit, object objVaue)
        {
            DataRow dr;
            DataRow[] drs = dtSource.Select("StructGuid='" + sStruCode + "'");
            if (drs.Length == 0)
            {
                dr = dtSource.NewRow();
                dr["GUID"] = Guid.NewGuid();
                dr["ProGuid"] = sBomGuid;
                dr["StructGuid"] = sStruCode;
                //dr["UnitCode"] = sUnit;
            }
            else dr = drs[0];
            if (objVaue == null) objVaue = DBNull.Value;
            if (dtSource.Columns["StructValue"].DataType == Type.GetType("System.Decimal"))
            {
                decimal dec1;
                //确保objVaue为数值型
                if (objVaue.Equals(DBNull.Value) || !decimal.TryParse(objVaue.ToString(), out dec1))
                    objVaue = DBNull.Value;
                else objVaue = dec1;
                if (!dr["StructValue"].Equals(objVaue))
                    dr["StructValue"] = objVaue;
            }
            else
            {
                //此时为字符型，注意这里必须要将""转成null，否则cast(structvalue as decimal(19,0))时会报错
                if (objVaue.ToString() == string.Empty)
                    objVaue = DBNull.Value;
                if (objVaue == DBNull.Value)
                {
                    if (!dr["StructValue"].Equals(DBNull.Value))
                        dr["StructValue"] = DBNull.Value;
                }
                else
                {
                    if (dr["StructValue"].ToString() != objVaue.ToString())
                        dr["StructValue"] = objVaue.ToString();
                }
            }
            //新增行的情况
            if (drs.Length == 0)
            {
                dtSource.Rows.Add(dr);
            }
        }
        public string GetClassName(string sClassCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT ClassName FROM BOM_Sys_ProductClass WHERE Code='{0}'", sClassCode.Replace("'", "''")));
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            if(dt.Rows.Count==0)
            {
                this.ShowMsg(string.Format("传入的类别编码\"{0}\"无效。", sClassCode));
                return string.Empty;
            }
            return dt.Rows[0]["ClassName"].ToString();
        }
    }
}
