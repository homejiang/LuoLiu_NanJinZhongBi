using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using ErrorService;

namespace BasicData.BLLDAL
{
    public class Supplier 
    {
        public void Save(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnString== string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            string strSqls;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                DataRow[] drs;
 
                if (ds.Tables.Contains("JC_Supplier"))
                {
                    DataTable dt = ds.Tables["JC_Supplier"];
                    if (dt.DefaultView[0].Row.RowState == DataRowState.Added)
                    {
                        DataRow dr = dt.DefaultView[0].Row;
                        #region insert基本资料
                        strSql = @"INSERT INTO JC_Supplier (Code,CNName,ENName,ShortName,Address,Tels,Faxs,Posalcode,CountryCode,ProvinceCode,Creater,CreaterName,CreateDate,Remark,SupplyType,Terminated,SwCode) 
                    SELECT @Code,@CNName,@ENName,@ShortName,@Address,@Tels,@Faxs,@Posalcode,@CountryCode,@ProvinceCode,@Creater,@CreaterName,@CreateDate,@Remark,@SupplyType,@Terminated,@SwCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CNName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["CNName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ENName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ShortName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 20;
                        sqlParam.Value = dr["ShortName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Address";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Address"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Tels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Faxs";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Faxs"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Posalcode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dr["Posalcode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CountryCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["CountryCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProvinceCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ProvinceCode"];
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
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateDate";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateDate"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplyType";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["SupplyType"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SwCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["SwCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dt.DefaultView[0].Row.RowState == DataRowState.Modified)
                    {
                        DataRow dr = dt.DefaultView[0].Row;
                        #region update基本资料
                        strSql = @"UPDATE JC_Supplier SET Code=@Code,CNName=@CNName,ENName=@ENName,ShortName=@ShortName,Address=@Address,Tels=@Tels,Faxs=@Faxs,Posalcode=@Posalcode,CountryCode=@CountryCode,ProvinceCode=@ProvinceCode,Creater=@Creater,CreaterName=@CreaterName,CreateDate=@CreateDate,Remark=@Remark,SupplyType=@SupplyType,Terminated=@Terminated,SwCode=@SwCode where Code=@OriginalCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CNName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["CNName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ENName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ShortName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 20;
                        sqlParam.Value = dr["ShortName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Address";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Address"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Tels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Faxs";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Faxs"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Posalcode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dr["Posalcode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CountryCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["CountryCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProvinceCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ProvinceCode"];
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
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["CreaterName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CreateDate";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["CreateDate"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplyType";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["SupplyType"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SwCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["SwCode"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OriginalCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["Code",DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }
                if (ds.Tables.Contains("V_JC_SupplierMaterial"))
                {
                    #region 保存物料明细
                    #region 新增数据
                    drs = ds.Tables["V_JC_SupplierMaterial"].Select("", "", DataViewRowState.Added);
                    strSql = @"INSERT INTO JC_MaterialSuppliers(MaterialCode,SupplierCode,SortID,IsDefault,Remark)
                            SELECT @MaterialCode,@SupplierCode,ISNULL((SELECT MAX(SortID) FROM JC_MaterialSuppliers WHERE MaterialCode=@MaterialCode1),0)+1,@IsDefault,@Remark";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MaterialCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["MaterialCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["SupplierCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MaterialCode1";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["MaterialCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsDefault";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["IsDefault"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.Text;
                        //sqlParam.Size = 16;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["V_JC_SupplierMaterial"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE JC_MaterialSuppliers SET MaterialCode=@MaterialCode,SupplierCode=@SupplierCode,SortID=@SortID,IsDefault=@IsDefault,Remark=@Remark WHERE MaterialCode=@OriginalMaterialCode AND SupplierCode=@OriginalSupplierCode";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MaterialCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["MaterialCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["SupplierCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsDefault";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["IsDefault"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OriginalMaterialCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["MaterialCode",DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OriginalSupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["SupplierCode", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["V_JC_SupplierMaterial"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM JC_MaterialSuppliers WHERE MaterialCode=@MaterialCode AND SupplierCode=@SupplierCode";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MaterialCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["MaterialCode", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["SupplierCode", DataRowVersion.Original];
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

        public void Delete(string sCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = "";
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "JC_Supplier_Delete";

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

        public void AddFromGpLibrary(string sCode1,string sCode2, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = "";
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[JC_Supplier_AddFromGroupLibrary]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Codes1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 4000;
                sqlParam.Value =sCode1;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Codes2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 4000;
                sqlParam.Value = sCode2;
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