using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

namespace ErrorService
{
    public class ErrorDAL
    {
        public static string DBConnString = "";
        public static string DBConnStringERPLog = "";
        public static void Save(string sMsg, string sProInfo)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (DBConnString == string.Empty)
            {
                return;
            }
            string strSql;
            try
            {
                sqlConn = new SqlConnection(DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                #region insert基本资料
                strSql = @"INSERT INTO JC_ErrorService (Msg,ProInfo,UserCode,UserName,Times)
            SELECT @Msg,@ProInfo,@UserCode,@UserName,getdate()";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Msg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Value = sMsg;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProInfo";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Value = sProInfo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = ErrorUserInfo.UserCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserName";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = ErrorUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                sqlTrain.Commit();
                #endregion
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
        public static void SendException(string sMsg)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (DBConnStringERPLog == string.Empty)
            {
                return;
            }
            string strSql;
            try
            {
                sqlConn = new SqlConnection(DBConnStringERPLog);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                #region insert基本资料
                strSql = "SendMsg_ExcepitionData1 @Log,1";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Log";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 4000;
                sqlParam.Value = sMsg;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                sqlTrain.Commit();
                #endregion
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
        public static class DoSqlCommand
        {
            #region  获取DATATABLE
            public static DataTable GetDateTable(string strSql)
            {
                try
                {
                    return GetDateTable(strSql, false);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public static DataTable GetDateTable(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataTable dtReturn = new DataTable();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBConnString == string.Empty)
                {
                    throw (new Exception("连接数据库的字符窜为空"));
                    return null;
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnString);
                    sqlCom = new SqlCommand(strSql, sqlConn);
                    sqlDA = new SqlDataAdapter(sqlCom);
                    if (isSchemaSource)
                        sqlDA.FillSchema(dtReturn, SchemaType.Source);
                    sqlDA.Fill(dtReturn);
                    return dtReturn;
                }
                catch (Exception ex)
                {
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
    #region 当前登录用户的信息
    public class ErrorUserInfo
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        public static string UserCode = "";
        /// <summary>
        /// 用户名称
        /// </summary>
        public static string UserName = "";
        /// <summary>
        /// 注销当前登陆
        /// </summary>
        public static void Logout()
        {
            UserCode = string.Empty;
            UserName = string.Empty;
        }
    }
    #endregion
}
