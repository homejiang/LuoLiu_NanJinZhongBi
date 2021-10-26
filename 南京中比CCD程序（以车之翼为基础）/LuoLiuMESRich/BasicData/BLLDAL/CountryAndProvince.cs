using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ErrorService;
using Common;

namespace BasicData.BLLDAL
{
    public class CountryAndProvince
    {
        #region 国家操作
        /// <summary>
        /// 保存国家信息
        /// </summary>
        /// <param name="ds"></param>
        public static void SaveCountry(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (CommonDAL.DBConnString == string.Empty)
            {
                CommonDAL.ExceptionIsEmpty ex = new CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            DataTable dt = ds.Tables["JC_Country"];
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (dt.DefaultView[0].Row.RowState == DataRowState.Added)
                {
                    #region insert基本资料
                    strSql = @"INSERT INTO JC_Country(CountryCode,CNName,ENName)
                                    SELECT @CountryCode,@CNName,@ENName";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["CountryCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["CNName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["ENName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                else if (dt.DefaultView[0].Row.RowState == DataRowState.Modified)
                {
                    #region update基本资料
                    strSql = @"UPDATE JC_Country SET CountryCode=@CountryCode,CNName=@CNName,ENName=@ENName WHERE CountryCode=@OrignalCountryCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["CountryCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["CNName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["ENName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrignalCountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["CountryCode", DataRowVersion.Original];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
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
        /// <summary>
        /// 删除国家信息
        /// </summary>
        /// <param name="strCountryCode"></param>
        public static void DeleteCountry(string strCountryCode)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (CommonDAL.DBConnString == string.Empty)
            {
                CommonDAL.ExceptionIsEmpty ex = new CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            string[] arrTable = new string[] { "JC_Country"};
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE CountryCode=@CountryCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = strCountryCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
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
        #endregion
        #region 省份操作
        /// <summary>
        /// 保存省份信息
        /// </summary>
        /// <param name="ds"></param>
        public static void SaveProvince(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (CommonDAL.DBConnString == string.Empty)
            {
                CommonDAL.ExceptionIsEmpty ex = new CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            DataTable dt = ds.Tables["V_ProvinceCountry"];
            DataRow[] drs;
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString );
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                drs = dt.Select("","",DataViewRowState.Added);
                for (int i=0;i<drs.Length;i++)
                {
                    #region 保存新增数据
                    strSql = @"INSERT INTO JC_Province(ProvinceCode,CNName,ENName,CountryCode)
                                    SELECT @ProvinceCode,@CNName,@ENName,@CountryCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProvinceCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ProvinceCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["CNName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ENName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["CountryCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("","",DataViewRowState.ModifiedCurrent);
                for (int i = 0; i < drs.Length; i++)
                {
                    #region update基本资料
                    strSql = @"UPDATE JC_Province SET ProvinceCode=@ProvinceCode,CNName=@CNName,ENName=@ENName,CountryCode=@CountryCode WHERE ProvinceCode=@OrignalProvinceCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProvinceCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ProvinceCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["CNName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ENName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["CountryCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrignalProvinceCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ProvinceCode", DataRowVersion.Original];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.Deleted);
                for (int i = drs.Length; i > 0; i--)
                {
                    #region 删除省份信息
                    strSql = "DELETE FROM JC_Province WHERE ProvinceCode=@ProvinceCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProvinceCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["ProvinceCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
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
        /// <summary>
        /// 删除省份信息
        /// </summary>
        /// <param name="strCountryCode"></param>
        public static void DeleteProvince(string strCountryCode)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (CommonDAL.DBConnString == string.Empty)
            {
                CommonDAL.ExceptionIsEmpty ex = new CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            string[] arrTable = new string[] { "JC_Province" };
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString );
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE ProvinceCode=@ProvinceCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProvinceCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = strCountryCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
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
        #endregion
    }
}
