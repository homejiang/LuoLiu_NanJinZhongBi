using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;

namespace AutoAssign.BLLDAL
{
    public class PeiFang
    {
        public void SavePeiFang(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnStringBasic == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnStringBasic);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (ds.Tables.Contains("PeiFang_Main"))
                {
                    DataTable dt = ds.Tables["PeiFang_Main"];
                    DataRow dr = dt.DefaultView[0].Row;
                    if (dr.RowState == DataRowState.Added)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO PeiFang_Main (GUID,PeiFangName,Creater,CreaterName,CreateTime,ModeIsNeter,ModeIsScaner,ProductSpec,GongYiType,ProcessCode,Terminated,ProductClassValue) 
                    SELECT @GUID,@PeiFangName,@Creater,@CreaterName,@CreateTime,@ModeIsNeter,@ModeIsScaner,@ProductSpec,@GongYiType,@ProcessCode,@Terminated,@ProductClassValue";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PeiFangName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["PeiFangName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Creater";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["Creater"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreaterName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModeIsNeter";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["ModeIsNeter"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModeIsScaner";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["ModeIsScaner"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProductSpec";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ProductSpec"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GongYiType";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["GongYiType"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProcessCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["ProcessCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProductClassValue";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["ProductClassValue"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        #region update基本资料
                        strSql = @"UPDATE PeiFang_Main SET PeiFangName=@PeiFangName,Creater=@Creater,CreaterName=@CreaterName,CreateTime=@CreateTime,ModeIsNeter=@ModeIsNeter,ModeIsScaner=@ModeIsScaner,ProductSpec=@ProductSpec,GongYiType=@GongYiType,ProcessCode=@ProcessCode,Terminated=@Terminated,ProductClassValue=@ProductClassValue WHERE GUID=@GUID";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PeiFangName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["PeiFangName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Creater";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["Creater"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreaterName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModeIsNeter";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["ModeIsNeter"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModeIsScaner";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["ModeIsScaner"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProductSpec";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ProductSpec"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GongYiType";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["GongYiType"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProcessCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["ProcessCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProductClassValue";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["ProductClassValue"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }
                if (ds.Tables.Contains("PeiFang_Grooves"))
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = ds.Tables["PeiFang_Grooves"].Select("", "", DataViewRowState.Added);
                    strSql = @"INSERT INTO PeiFang_Grooves (GUID,GrooveNo,Vmin,Vmax,DianZuMin,DianZuMax,Quality,QualityDesc,TuoBtyCount,SendMes) 
                    SELECT @GUID,@GrooveNo,@Vmin,@Vmax,@DianZuMin,@DianZuMax,@Quality,@QualityDesc,@TuoBtyCount,@SendMes";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GrooveNo";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["GrooveNo"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Vmin";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Vmin"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Vmax";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Vmax"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZuMin";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZuMin"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZuMax";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZuMax"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Quality";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["Quality"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@QualityDesc";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["QualityDesc"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoBtyCount";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["TuoBtyCount"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SendMes";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["SendMes"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["PeiFang_Grooves"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE PeiFang_Grooves SET GUID=@GUID,GrooveNo=@GrooveNo,Vmin=@Vmin,Vmax=@Vmax,DianZuMin=@DianZuMin,DianZuMax=@DianZuMax,Quality=@Quality,QualityDesc=@QualityDesc,TuoBtyCount=@TuoBtyCount,SendMes=@SendMes WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GrooveNo";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["GrooveNo"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Vmin";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Vmin"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Vmax";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Vmax"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZuMin";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZuMin"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZuMax";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZuMax"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Quality";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["Quality"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@QualityDesc";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["QualityDesc"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoBtyCount";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["TuoBtyCount"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SendMes";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["SendMes"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.BigInt;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ID"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["PeiFang_Grooves"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM PeiFang_Grooves WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.BigInt;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                }
                
                sqlTrain.Commit();
            }
            catch (Exception ex)
            {
                if (sqlTrain != null)
                    sqlTrain.Rollback();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            finally
            {
                if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }
        #region 删除订单
        public void PeiFangDelete(string sGuid, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnStringBasic == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnStringBasic);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[PeiFang_Delete]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserName";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
            }
            catch (Exception ex)
            {
                if (sqlTrain != null)
                    sqlTrain.Rollback();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            finally
            {
                if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }
        }
        #endregion
    }
}
