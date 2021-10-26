using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;

namespace BasicData.BLLDAL
{
    public class OutputFile
    {   
        public void Save(DataSet ds)
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
                #region 保存明细
                DataRow[] drs;
                #region 新增数据
                drs = ds.Tables["JC_OutputFile"].Select("", "", DataViewRowState.Added);
                strSql = @"INSERT INTO JC_OutputFile (outArg,FileName,FileVersion,Times,Remark) 
                    SELECT @outArg,@FileName,@FileVersion,@Times,@Remark";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@outArg";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["outArg"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FileName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["FileName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FileVersion";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["FileVersion"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Times";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Times"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 400;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 更新数据
                drs = ds.Tables["JC_OutputFile"].Select("", "", DataViewRowState.ModifiedCurrent);
                strSql = @"UPDATE JC_OutputFile SET outArg=@outArg,FileName=@FileName,FileVersion=@FileVersion,Times=@Times,Remark=@Remark WHERE outArg=@outArgOrginal";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@outArg";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["outArg"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FileName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["FileName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FileVersion";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["FileVersion"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Times";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Times"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 400;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@outArgOrginal";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["outArg", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 删除数据
                drs = ds.Tables["JC_OutputFile"].Select("", "", DataViewRowState.Deleted);
                strSql = @"DELETE FROM JC_OutputFile WHERE outArg=@outArg";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@outArg";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["outArg", DataRowVersion.Original];
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
        public void Upload(string soutArg, byte[] bytes)
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
                strSql = @"UPDATE JC_OutputFile SET FileEntity=@FileEntity,Times=Getdate() WHERE outArg=@outArg";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@outArg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = soutArg;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@FileEntity";
                sqlParam.SqlDbType = SqlDbType.Image;
                sqlParam.Value = bytes;
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
        public void Detele(string soutArg)
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
                strSql = "DELETE FROM JC_OutputFile WHERE outArg=@outArg";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@outArg";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = soutArg;
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
