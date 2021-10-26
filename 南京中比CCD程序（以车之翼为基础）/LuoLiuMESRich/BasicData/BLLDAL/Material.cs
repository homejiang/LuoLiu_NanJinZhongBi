using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using ErrorService;


namespace BasicData.BLLDAL
{
    public class Material
    {
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
            DataRow[] drs;
            string strSql;
            DataTable dt = ds.Tables["JC_Material"];
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (dt.DefaultView[0].Row.RowState == DataRowState.Added)
                {
                    DataRow dr = dt.DefaultView[0].Row;
                    #region 基本资料
                    strSql = @"INSERT INTO JC_Material (MaterialCode,ClassCode,CNName,ENName,UnitCode,MaxStorage,MinStorage,Remark,Creater,CreaterName,CreateTime,Modifier,ModifyTime,Terminated,IsSys,DiameterType,VirCode) 
                    SELECT @MaterialCode,@ClassCode,@CNName,@ENName,@UnitCode,@MaxStorage,@MinStorage,@Remark,@Creater,@CreaterName,@CreateTime,@Modifier,@ModifyTime,@Terminated,@IsSys,@DiameterType,@VirCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["MaterialCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ClassCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ClassCode"];
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
                    sqlParam.ParameterName = "@UnitCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["UnitCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaxStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MaxStorage"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MinStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MinStorage"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 800;
                    sqlParam.Value = dr["Remark"];
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
                    sqlParam.ParameterName = "@Modifier";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Modifier"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModifyTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["ModifyTime"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@IsSys";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["IsSys"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DiameterType";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["DiameterType"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VirCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 3;
                    sqlParam.Value = dr["VirCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                else if (dt.DefaultView[0].Row.RowState == DataRowState.Modified)
                {
                    DataRow dr = dt.DefaultView[0].Row;
                    #region update基本资料
                    strSql = @"UPDATE JC_Material SET MaterialCode=@MaterialCode,ClassCode=@ClassCode,CNName=@CNName,ENName=@ENName,UnitCode=@UnitCode,MaxStorage=@MaxStorage,MinStorage=@MinStorage,Remark=@Remark,Creater=@Creater,CreaterName=@CreaterName,CreateTime=@CreateTime,Modifier=@Modifier,ModifyTime=@ModifyTime,Terminated=@Terminated,IsSys=@IsSys,DiameterType=@DiameterType,VirCode=@VirCode WHERE MaterialCode=@OrignalMaterialCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["MaterialCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ClassCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ClassCode"];
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
                    sqlParam.ParameterName = "@UnitCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["UnitCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaxStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MaxStorage"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MinStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MinStorage"];
                    sqlCom.Parameters.Add(sqlParam);


                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 800;
                    sqlParam.Value = dr["Remark"];
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
                    sqlParam.ParameterName = "@Modifier";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Modifier"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModifyTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["ModifyTime"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@IsSys";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["IsSys"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DiameterType";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["DiameterType"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VirCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 3;
                    sqlParam.Value = dr["VirCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrignalMaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dt.DefaultView[0].Row["MaterialCode", DataRowVersion.Original];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                #region 保存型号明细
                #region 新增数据
                drs = ds.Tables["JC_MaterialSpecs"].Select("", "", DataViewRowState.Added);
                strSql = @"INSERT INTO JC_MaterialSpecs (Guid,Spec,MaterialCode,SortID,Diameter,Diameter1,Diameter2,Remark,Terminated,MaxStorage,MinStorage,BusinessCode) 
                 SELECT @Guid,@Spec,@MaterialCode,@SortID,@Diameter,@Diameter1,@Diameter2,@Remark,@Terminated,@MaxStorage,@MinStorage,@BusinessCode";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Guid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["Guid"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Spec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Spec"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["MaterialCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter1";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter1"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter2";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter2"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 800;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaxStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MaxStorage"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MinStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MinStorage"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@BusinessCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["BusinessCode"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 更新数据
                drs = ds.Tables["JC_MaterialSpecs"].Select("", "", DataViewRowState.ModifiedCurrent);
                strSql = @"UPDATE JC_MaterialSpecs SET Guid=@Guid,Spec=@Spec,MaterialCode=@MaterialCode,SortID=@SortID,Diameter=@Diameter,Diameter1=@Diameter1,Diameter2=@Diameter2,Remark=@Remark,Terminated=@Terminated,MaxStorage=@MaxStorage,MinStorage=@MinStorage WHERE Guid=@Guid";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Guid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["Guid"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Spec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Spec"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["MaterialCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter1";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter1"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Diameter2";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["Diameter2"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Remark";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 800;
                    sqlParam.Value = dr["Remark"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Terminated";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["Terminated"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaxStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MaxStorage"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MinStorage";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["MinStorage"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 删除数据
                drs = ds.Tables["JC_MaterialSpecs"].Select("", "", DataViewRowState.Deleted);
                strSql = @"DELETE FROM JC_MaterialSpecs WHERE Guid=@Guid";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Guid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["Guid", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #endregion
                #region 保存客户明细
                #region 新增数据
                drs = ds.Tables["V_JC_MaterialSupplier"].Select("", "", DataViewRowState.Added);
                strSql = @"INSERT INTO JC_MaterialSuppliers (MaterialCode,SupplierCode,SortID,IsDefault,Remark) 
                            SELECT @MaterialCode,@SupplierCode,@SortID,@IsDefault,@Remark";
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

                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 更新数据
                drs = ds.Tables["V_JC_MaterialSupplier"].Select("", "", DataViewRowState.ModifiedCurrent);
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
                drs = ds.Tables["V_JC_MaterialSupplier"].Select("", "", DataViewRowState.Deleted);
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
                sqlCom.CommandText = "JC_Material_Delete";
                
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MaterialCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = obj.ToString();
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
