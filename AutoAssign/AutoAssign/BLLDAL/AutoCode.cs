using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;
using Common;

namespace AutoAssign.BLLDAL
{
    public class AutoCode
    {
        public void Save(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (CommonDAL.DBConnString == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                DataRow[] drs;
                if (ds.Tables.Contains("Sys_AutoCode"))
                {
                    drs = ds.Tables["Sys_AutoCode"].Select("", "", DataViewRowState.Added);
                    foreach (DataRow dr in drs)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Sys_AutoCode(ModuleCode,CodeRule,SerialLen)
                                    SELECT @ModuleCode,@CodeRule,@SerialLen";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CodeRule";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["CodeRule"];
                        sqlParam.Size = 200;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SerialLen";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["SerialLen"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_AutoCode"].Select("", "", DataViewRowState.ModifiedCurrent);
                    foreach (DataRow dr in drs)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Sys_AutoCode SET ModuleCode=@ModuleCode,CodeRule=@CodeRule,SerialLen=@SerialLen WHERE ModuleCode=@OrignalModuleCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CodeRule";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["CodeRule"];
                        sqlParam.Size = 200;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SerialLen";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["SerialLen"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OrignalModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode", DataRowVersion.Original];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
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

    }
}
