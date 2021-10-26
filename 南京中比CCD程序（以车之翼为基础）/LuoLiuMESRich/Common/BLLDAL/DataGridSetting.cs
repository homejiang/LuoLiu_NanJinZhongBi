using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;

namespace Common.BLLDAL
{
    public class DataGridSetting: Common.MyInterface.IDataDAL
    {
        public void Save(DataTable dt)
        {
            DataSet ds = new DataSet();
            if (dt.TableName.ToUpper() != "Sys_DataGridViewSetting".ToUpper())
                dt.TableName = "Sys_DataGridViewSetting";
            ds.Tables.Add(dt);
            int iReturnValue;
            string strMsg;
            this.Save(ds, out strMsg, out iReturnValue);
            ds.Tables.Remove(dt);
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
            DataTable dt = ds.Tables["Sys_DataGridViewSetting"];
            string strSql;
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
                    strSql = @"INSERT INTO Sys_DataGridViewSetting (ModuleEnumNo,UserCode,DataGridViewID,TitleName,SortID,ColWidth,IsHidden,isFrozen,BackColor,ForeColor,FontSize) 
                                SELECT @ModuleEnumNo,@UserCode,@DataGridViewID,@TitleName,@SortID,@ColWidth,@IsHidden,@isFrozen,@BackColor,@ForeColor,@FontSize";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModuleEnumNo";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["ModuleEnumNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@UserCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["UserCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DataGridViewID";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["DataGridViewID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@TitleName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["TitleName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ColWidth";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["ColWidth"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@IsHidden";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["IsHidden"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@isFrozen";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["isFrozen"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@BackColor";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["BackColor"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ForeColor";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ForeColor"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FontSize";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["FontSize"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.ModifiedCurrent);
                foreach (DataRow dr in drs)
                {
                    #region update基本资料
                    strSql = @"UPDATE Sys_DataGridViewSetting SET ModuleEnumNo=@ModuleEnumNo,UserCode=@UserCode,DataGridViewID=@DataGridViewID,TitleName=@TitleName,SortID=@SortID,ColWidth=@ColWidth,IsHidden=@IsHidden,isFrozen=@isFrozen,BackColor=@BackColor,ForeColor=@ForeColor,FontSize=@FontSize WHERE ID=@ID";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModuleEnumNo";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["ModuleEnumNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@UserCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["UserCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@DataGridViewID";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["DataGridViewID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@TitleName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["TitleName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SortID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["SortID"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ColWidth";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["ColWidth"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@IsHidden";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["IsHidden"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@isFrozen";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["isFrozen"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@BackColor";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["BackColor"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ForeColor";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["ForeColor"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@FontSize";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = dr["FontSize"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Value = dr["ID"];
                    sqlParam.Size = 4;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                drs = dt.Select("", "", DataViewRowState.Deleted);
                foreach (DataRow dr in drs)
                {
                    #region delete基本资料
                    strSql = @"DELETE FROM Sys_DataGridViewSetting WHERE ID=@ID";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ID";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Value = dr["ID"];
                    sqlParam.Size = 4;
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

        public void Detele(object obj, out string strMsg, out int iReturn)
        {
            throw new Exception("The method or operation is not implemented.");
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
