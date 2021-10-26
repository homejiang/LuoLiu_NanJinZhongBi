using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ErrorService;
using System.Data;

namespace LuoLiuMES.BLLDAL
{
    public class PackInput
    {
        public void Save(System.Data.DataSet ds)
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
                if (ds.Tables.Contains("PM_Pack_Input"))
                {
                    DataTable dt = ds.Tables["PM_Pack_Input"];
                    DataRow dr = dt.DefaultView[0].Row;
                    if (dr.RowState == DataRowState.Added)
                    {
                        #region insert��������
                        strSql = @"INSERT INTO PM_Pack_Input (Code,Creater,CreaterName,CreateTime,Taker,TakerName,StorageCode,Remark) 
                            SELECT @Code,@Creater,@CreaterName,@CreateTime,@Taker,@TakerName,@StorageCode,@Remark";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Creater";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Creater"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreaterName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Taker";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dr["Taker"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TakerName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["TakerName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StorageCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["StorageCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        #region update��������
                        strSql = @"UPDATE PM_Pack_Input SET Code=@Code,Creater=@Creater,CreaterName=@CreaterName,CreateTime=@CreateTime,Taker=@Taker,TakerName=@TakerName,StorageCode=@StorageCode,Remark=@Remark WHERE Code=@OrignalCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Creater";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Creater"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreaterName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Taker";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dr["Taker"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TakerName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["TakerName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StorageCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["StorageCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OrignalCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["Code", DataRowVersion.Original];
                        sqlParam.Size = 30;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                        #region ����ؼ��ָı���Ҫ�޸���ϸ�йؼ���
                        //if (dr["Code", DataRowVersion.Original].ToString() != dr["Code", DataRowVersion.Current].ToString())
                        //{
                        //    strSql = @"UPDATE PM_Pack_InputDetail SET OCode=@Code WHERE OCode=@OrignalCode";
                        //    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        //    sqlParam = new SqlParameter();
                        //    sqlParam.ParameterName = "@OCode";
                        //    sqlParam.SqlDbType = SqlDbType.NVarChar;
                        //    sqlParam.Size = 30;
                        //    sqlParam.Value = dr["OCode"];
                        //    sqlCom.Parameters.Add(sqlParam);
                        //    sqlParam = new SqlParameter();
                        //    sqlParam.ParameterName = "@OrignalCode";
                        //    sqlParam.SqlDbType = SqlDbType.NVarChar;
                        //    sqlParam.Value = dr["Code", DataRowVersion.Original];
                        //    sqlParam.Size = 30;
                        //    sqlCom.Parameters.Add(sqlParam);
                        //    sqlCom.ExecuteNonQuery();
                        //}
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
        public void InputPack(string sOutputCode,string sPackCode,string sTypeCode, out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "PM_Pack_Input_InputPack_Cgy";
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sOutputCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PackCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sPackCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TypeCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTypeCode;
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
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
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
        public void CancelInputPack(string sOutputCode, string sPackCode,string sTypeCode, out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "PM_Pack_Input_CancelInputPack_Cgy";
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sOutputCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PackCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sPackCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TypeCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTypeCode;
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
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
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
        public void Delete(string sOutputCode,  out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[PM_Pack_Input_Delete_Cgy]";
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sOutputCode;
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
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
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
        #region ȷ��/��������
        public void Compeleted(string sCode, out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[PM_Pack_Input_Compeleted_Cgy]";
                //��Ӳ���
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@OCode";
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
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
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
        public void CancelCompeleted(string sCode, out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[PM_Pack_Input_CancelCompeleted_Cgy]";
                //��Ӳ���
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@OCode";
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
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ErrMsg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 400;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturn = -1;
                else
                    iReturn = (int)sqlCom.Parameters["@ReturnValue"].Value;
                strMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturn == 1)
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
