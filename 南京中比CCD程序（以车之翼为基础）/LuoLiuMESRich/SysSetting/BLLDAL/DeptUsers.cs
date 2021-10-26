using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;
using Common;

namespace SysSetting.BLLDAL
{
    public class DeptUsers:Common.MyInterface.IDataDAL
    {
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
        #region IDataDAL 成员

        public void Save(DataSet ds, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            string strSql;
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                DataRow[] drs;
                if (ds.Tables.Contains("Sys_Users"))
                {
                    drs = ds.Tables["Sys_Users"].Select("", "", DataViewRowState.Added);
                    foreach (DataRow dr in drs)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Sys_Users(UserCode,UserName,UserENName,Pwd,DeptCode,MobileTel,Tel,Email,HomeAddress,Terminated,IsSuper,IsAdmin,PowerGroupCode)
                                    SELECT @UserCode,@UserName,@UserENName,@Pwd,@DeptCode,@MobileTel,@Tel,@Email,@HomeAddress,@Terminated,@IsSuper,@IsAdmin,@PowerGroupCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserENName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Pwd";
                        sqlParam.SqlDbType = SqlDbType.VarChar;
                        sqlParam.Value = dr["Pwd"];
                        sqlParam.Size = 400;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DeptCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["DeptCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MobileTel";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["MobileTel"];
                        sqlParam.Size = 100;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tel";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["Tel"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Email";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["Email"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@HomeAddress";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["HomeAddress"];
                        sqlParam.Size = 200;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["Terminated"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsSuper";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsSuper"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsAdmin";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsAdmin"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PowerGroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["PowerGroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_Users"].Select("", "", DataViewRowState.ModifiedCurrent);
                    foreach (DataRow dr in drs)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Sys_Users SET UserCode=@UserCode,UserName=@UserName,UserENName=@UserENName,Pwd=@Pwd,DeptCode=@DeptCode,MobileTel=@MobileTel,Tel=@Tel,Email=@Email,HomeAddress=@HomeAddress,Terminated=@Terminated,IsSuper=@IsSuper,IsAdmin=@IsAdmin,PowerGroupCode=@PowerGroupCode WHERE UserCode=@OrignalUserCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserENName"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Pwd";
                        sqlParam.SqlDbType = SqlDbType.VarChar;
                        sqlParam.Value = dr["Pwd"];
                        sqlParam.Size = 400;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DeptCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["DeptCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MobileTel";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["MobileTel"];
                        sqlParam.Size = 100;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tel";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["Tel"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Email";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["Email"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@HomeAddress";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["HomeAddress"];
                        sqlParam.Size = 200;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OrignalUserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode", DataRowVersion.Original];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["Terminated"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsSuper";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsSuper"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsAdmin";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["IsAdmin"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PowerGroupCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["PowerGroupCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_Users"].Select("", "", DataViewRowState.Deleted);
                    foreach (DataRow dr in drs)
                    {
                        #region 删除数据
                        strSql = @"DELETE FROM Sys_Users WHERE UserCode=@UserCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode", DataRowVersion.Original];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }
                if (ds.Tables.Contains("Sys_UsersPowers"))
                {
                    drs = ds.Tables["Sys_UsersPowers"].Select("", "", DataViewRowState.Added);
                    foreach (DataRow dr in drs)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Sys_UsersPowers(UserCode,ModuleCode,NewPower,EditPower,DeletePower,ReadonlyPower)
                                    SELECT @UserCode,@ModuleCode,@NewPower,@EditPower,@DeletePower,@ReadonlyPower";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@NewPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["NewPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@EditPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["EditPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DeletePower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["DeletePower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ReadonlyPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["ReadonlyPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_UsersPowers"].Select("", "", DataViewRowState.ModifiedCurrent);
                    foreach (DataRow dr in drs)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Sys_UsersPowers SET UserCode=@UserCode,ModuleCode=@ModuleCode,NewPower=@NewPower,EditPower=@EditPower,DeletePower=@DeletePower,ReadonlyPower=@ReadonlyPower WHERE ID=@ID";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UserCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["UserCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlParam.Size = 50;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@NewPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["NewPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@EditPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["EditPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DeletePower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["DeletePower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ReadonlyPower";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Value = dr["ReadonlyPower"];
                        sqlParam.Size = 1;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["ID", DataRowVersion.Original];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    drs = ds.Tables["Sys_UsersPowers"].Select("", "", DataViewRowState.Deleted);
                    foreach (DataRow dr in drs)
                    {
                        #region 删除数据
                        strSql = @"DELETE FROM Sys_UsersPowers WHERE ID=@ID";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Value = dr["ID",DataRowVersion.Original];
                        sqlParam.Size = 4;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
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
            if (CommonDAL.DBConnString == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            string[] arrTable = new string[] { "Sys_Users", "Sys_UsersPowers" };
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE UserCode=@UserCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@UserCode";
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

            strMsg = string.Empty;
            iReturn = -1;
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
            string strSql;
            DataTable dt = ds.Tables["Sys_Department"];
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                DataRow[] drs;
                drs = dt.Select("", "", DataViewRowState.Added);
                foreach (DataRow dr in drs)
                {
                    #region insert基本资料
                    strSql = @"INSERT INTO Sys_Department(DeptCode,DeptName,DeptShortName,Description,ParentDetpCode)
                                    SELECT @DeptCode,@DeptName,@DeptShortName,@Description,@ParentDetpCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptShortName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptShortName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Description";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["Description"];
                    sqlParam.Size = 200;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ParentDetpCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["ParentDetpCode"];
                    sqlParam.Size = 30;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.ModifiedCurrent);
                foreach (DataRow dr in drs)
                {
                    #region update基本资料
                    strSql = @"UPDATE Sys_Department SET DeptCode=@DeptCode,DeptName=@DeptName,DeptShortName=@DeptShortName,Description=@Description,ParentDetpCode=@ParentDetpCode WHERE DeptCode=@OrignalDeptCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptCode"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptShortName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptShortName"];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Description";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["Description"];
                    sqlParam.Size = 200;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ParentDetpCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["ParentDetpCode"];
                    sqlParam.Size = 30;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrignalDeptCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptCode", DataRowVersion.Original];
                    sqlParam.Size = 50;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.Deleted);
                foreach (DataRow dr in drs)
                {
                    #region 删除数据
                    strSql = @"DELETE FROM Sys_Department WHERE DeptCode=@DeptCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Value = dr["DeptCode", DataRowVersion.Original];
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

        public void DeteleGroup(object obj, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            string strSql;
            string[] arrTable = new string[] { "Sys_Department" };
            try
            {
                sqlConn = new SqlConnection(CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE DeptCode=@DeptCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DeptCode";
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

        #endregion
    }
}
