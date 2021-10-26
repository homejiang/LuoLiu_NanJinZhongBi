using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ErrorService;

namespace BasicData.BLLDAL
{
    class Province:Common.MyInterface.IDataDAL
    {
        public void Save(DataSet ds)
        {
            int iReturnValue;
            string strMsg;
            this.Save(ds, out strMsg, out iReturnValue);
        }
        public void Detele(string strCode)
        {
            int iReturnValue;
            string strMsg;
            this.Detele(strCode, out strMsg, out iReturnValue);
        }
        #region IDataDAL 成员

        public void Save(DataSet ds, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            DataTable dt = ds.Tables["V_JC_ProvinceCountry"];
            DataRow[] drs;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                drs = dt.Select("", "", DataViewRowState.Added);
                for (int i = 0; i < drs.Length; i++)
                {
                    #region 保存新增数据
                    strSql = @"INSERT INTO JC_Province (Code,CountryCode,CNName,ENName) 
                               SELECT @Code,@CountryCode,@CNName,@ENName";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["CountryCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["CNName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["ENName"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.ModifiedCurrent);
                for (int i = 0; i < drs.Length; i++)
                {
                    #region update基本资料
                    strSql = @"UPDATE JC_Province SET Code=@Code,CountryCode=@CountryCode,CNName=@CNName,ENName=@ENName WHERE Code=@OrignalCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CountryCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["CountryCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CNName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["CNName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ENName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = drs[i]["ENName"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrignalCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["Code", DataRowVersion.Original];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.Deleted);
                for (int i = drs.Length; i > 0; i--)
                {
                    #region 删除省份信息
                    strSql = "DELETE FROM JC_Province WHERE Code=@Code";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = drs[i]["Code"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                sqlTrain.Commit();
                iReturn = 1;
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

        public void Detele(object obj, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            string[] arrTable = new string[] { "JC_Province" };
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE Code=@Code";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = obj;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                sqlTrain.Commit();
                iReturn = 1;
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

        public void SaveGroup(DataSet ds, out string strMsg, out int iReturn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeteleGroup(object obj, out string strMsg, out int iReturn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
