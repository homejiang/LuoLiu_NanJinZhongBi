using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;

namespace Common.BLLDAL
{
    public class Files
    {
        public void UploadFile(string sGuid,  byte[] bysFileData)
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
                strSql = @"INSERT INTO Files (GUID,FileEntity) 
                        SELECT @GUID,@FileEntity";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Value = sGuid;
                sqlParam.Size = 50;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@FileEntity";
                sqlParam.SqlDbType = SqlDbType.Image;
                sqlParam.Value = bysFileData;
                sqlCom.Parameters.Add(sqlParam);
                
                sqlCom.ExecuteNonQuery();
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
