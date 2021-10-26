using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;

namespace BasicData.BLLDAL
{
    public class Process
    {

        public void Save(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnString == string.Empty)
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
                #region 保存明细
                DataRow[] drs;
                #region 新增数据
                drs = ds.Tables["JC_Process"].Select("", "", DataViewRowState.Added);
                strSql = @"INSERT INTO JC_Process (Code,ProcessName,Remark,SortID,Terminated) 
                        SELECT @Code,@ProcessName,@Remark,@SortID,@Terminated";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProcessName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ProcessName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 400;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 更新数据
                drs = ds.Tables["JC_Process"].Select("", "", DataViewRowState.ModifiedCurrent);
                strSql = @"UPDATE JC_Process SET Code=@Code,ProcessName=@ProcessName,Remark=@Remark,Terminated=@Terminated,SortID=@SortID WHERE Code=@OriginalCode";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProcessName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ProcessName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 400;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OriginalCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 删除数据
                drs = ds.Tables["JC_Process"].Select("", "", DataViewRowState.Deleted);
                strSql = @"DELETE FROM JC_Process WHERE Code=@Code";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #endregion
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
        public void Delete(string sCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnString == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[JC_Process_Delete]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode;
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
                sqlParam.Value = Common.CurrentUserInfo.UserName;
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
    }
}
