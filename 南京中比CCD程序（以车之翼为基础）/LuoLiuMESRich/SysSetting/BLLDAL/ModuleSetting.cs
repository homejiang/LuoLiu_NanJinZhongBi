using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;

namespace SysSetting.BLLDAL
{
    public class ModuleSetting:Common.MyInterface.IDataDAL
    {

        public void SaveGroup(DataSet ds, out string strMsg, out int iReturn)
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (ds.Tables.Contains("Sys_ModuleGroup"))
                {
                    DataTable dt = ds.Tables["Sys_ModuleGroup"];
                    if (dt.DefaultView[0].Row.RowState == DataRowState.Added)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Sys_ModuleGroup(GroupCode,SortID,GroupName,Description)
                                    SELECT @GroupCode,@SortID,@GroupName,@Description";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dt.DefaultView[0].Row["GroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dt.DefaultView[0].Row["SortID"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dt.DefaultView[0].Row["GroupName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Description";
                        sqlParam.SqlDbType = SqlDbType.Text;
                        sqlParam.Value = dt.DefaultView[0].Row["Description"];
                        sqlParam.Size = 16;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dt.DefaultView[0].Row.RowState == DataRowState.Modified)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Sys_ModuleGroup SET GroupCode=@GroupCode,SortID=@SortID,GroupName=@GroupName,Description=@Description WHERE GroupCode=@OrignalGroupCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dt.DefaultView[0].Row["GroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dt.DefaultView[0].Row["SortID"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dt.DefaultView[0].Row["GroupName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Description";
                        sqlParam.SqlDbType = SqlDbType.Text;
                        sqlParam.Value = dt.DefaultView[0].Row["Description"];
                        sqlParam.Size = 16;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OrignalGroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dt.DefaultView[0].Row["GroupCode", DataRowVersion.Original];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }
                iReturn = 1;
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

        public void DeteleGroup(object strCode, out string strMsg, out int iReturn)
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
            string[] arrTable = new string[] { "Sys_ModuleGroup", "Sys_Module" };
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE GroupCode=@GroupCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@GroupCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = strCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                iReturn = 1;
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
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (ds.Tables.Contains("Sys_Module"))
                {
                    DataTable dt = ds.Tables["Sys_Module"];
                    DataRow[] drs = ds.Tables["Sys_Module"].Select("", "", DataViewRowState.Added);
                    foreach (DataRow dr in drs)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Sys_Module(ModuleCode,SortID,GroupCode,ModuleName,EnumNo,CanNew,CanEdit,CanDelete,NeedAudit,IsAutoCode)
                                    SELECT @ModuleCode,@SortID,@GroupCode,@ModuleName,@EnumNo,@CanNew,@CanEdit,@CanDelete,@NeedAudit,@IsAutoCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["SortID"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["GroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleName"];
                        sqlParam.Size = 100;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@EnumNo";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["EnumNo"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanNew";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanNew"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanEdit";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanEdit"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanDelete";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanDelete"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@NeedAudit";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["NeedAudit"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsAutoCode";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsAutoCode"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_Module"].Select("", "", DataViewRowState.ModifiedCurrent);
                    foreach (DataRow dr in drs)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Sys_Module SET ModuleCode=@ModuleCode,SortID=@SortID,GroupCode=@GroupCode,ModuleName=@ModuleName,EnumNo=@EnumNo,CanNew=@CanNew,CanEdit=@CanEdit,CanDelete=@CanDelete,NeedAudit=@NeedAudit,IsAutoCode=@IsAutoCode WHERE ModuleCode=@OrignalModuleCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["SortID"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["GroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleName"];
                        sqlParam.Size = 100;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@EnumNo";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["EnumNo"];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanNew";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanNew"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanEdit";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanEdit"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CanDelete";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["CanDelete"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@NeedAudit";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["NeedAudit"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsAutoCode";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsAutoCode"];
                        sqlParam.Size = 1;
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
                iReturn = 1;
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

        public void Detele(object strCode, out string strMsg, out int iReturn)
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
            string[] arrTable = new string[] { "Sys_Module" };
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE ModuleCode=@ModuleCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModuleCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = strCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                iReturn = 1;
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

        public void SaveGroup(DataSet ds)
        {
            int iReturnValue;
            string strMsg;
            this.SaveGroup(ds, out strMsg, out iReturnValue);
        }

        public void DeteleGroup(object strCode)
        {

            int iReturnValue;
            string strMsg;
            this.DeteleGroup(strCode, out strMsg, out iReturnValue);
        }

        public void Save(DataSet ds)
        {

            int iReturnValue;
            string strMsg;
            this.Save(ds,out strMsg, out iReturnValue);
        }

        public void Detele(object strCode)
        {

            int iReturnValue;
            string strMsg;
            this.Detele(strCode, out strMsg, out iReturnValue);
        }

    }
}
