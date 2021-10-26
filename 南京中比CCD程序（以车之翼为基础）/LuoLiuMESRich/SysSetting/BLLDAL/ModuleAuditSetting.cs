using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;
using Common;

namespace SysSetting.BLLDAL
{
    public class ModuleAuditSetting : Common.MyInterface.IDataDAL
    {
        public void Save(DataSet ds)
        {
            int iReturnValue;
            string strMsg;
            this.Save(ds, out strMsg, out iReturnValue);
        }
        ///// <summary>
        ///// 获取系统设置的审批流程
        ///// </summary>
        ///// <param name="strModuleCode">对应模块代码</param>
        ///// <returns>以Sys_ModuleAuditDetail表为基础的表结构，包含待审人姓名，多人以“|”分割</returns>
        //public static DataTable GetSysSettedAuditDetail(string strModuleCode)
        //{
        //    DataSet ds = null;
        //    List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<CommonDAL.SqlSearchEntiy>();
        //    listSql.Add(new CommonDAL.SqlSearchEntiy(string.Format("SELECT *,dbo.Common_GetWaitAuditerNames(WaitAuditer) AS WaitAuditerName FROM Sys_ModuleAuditSetting WHERE ModuleCode='{0}' ORDER BY SortID ASC", strModuleCode.Replace("'", "''")), "Sys_ModuleAuditSetting"));
        //    listSql.Add(new CommonDAL.SqlSearchEntiy("SELECT * FROM Sys_ModuleAuditDetail WHERE 1=2", "Sys_ModuleAuditDetail"));
        //    try
        //    {
        //        ds = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(listSql,true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    DataTable dt = ds.Tables["Sys_ModuleAuditSetting"];
        //    DataTable dtRet = ds.Tables["Sys_ModuleAuditDetail"];
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        DataRow drNew = dtRet.NewRow();
        //        drNew["ModuleCode"] = strModuleCode;
        //        drNew["SortID"] = dr["SortID"];
        //        drNew["FlowName"] = dr["FlowName"];
        //        drNew["WaitAuditer"] = dr["WaitAuditer"];
        //        drNew["WaitAuditerName"] = dr["WaitAuditerName"];
        //        dtRet.Rows.Add(drNew);
        //    }
        //    return dtRet;
        //}
        ///// <summary>
        ///// 获取系统设置的审批流程
        ///// </summary>
        ///// <param name="module">对应的模块</param>
        ///// <returns>以Sys_ModuleAuditDetail表为基础的表结构，包含待审人姓名，多人以“|”分割</returns>
        //public static DataTable GetSysSettedAuditDetail(Common.MyEnums.Modules module)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT TOP 1 ModuleCode FROM Sys_Module WHERE EnumNo={0}", (int)module, false));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //    if (dt.Rows.Count == 0) return null;
        //    return GetSysSettedAuditDetail(dt.Rows[0]["ModuleCode"].ToString());
        //}
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
                if (ds.Tables.Contains("Sys_ModuleAuditSetting"))
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = ds.Tables["Sys_ModuleAuditSetting"].Select("", "", DataViewRowState.Added);
                    strSql = @"INSERT INTO Sys_ModuleAuditSetting(ModuleCode,SortID,FlowName,WaitAuditer)
                            SELECT @ModuleCode,@SortID,@FlowName,@WaitAuditer";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FlowName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["FlowName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@WaitAuditer";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["WaitAuditer"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["Sys_ModuleAuditSetting"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE Sys_ModuleAuditSetting SET ModuleCode=@ModuleCode,SortID=@SortID,FlowName=@FlowName,WaitAuditer=@WaitAuditer WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModuleCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ModuleCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FlowName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["FlowName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@WaitAuditer";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["WaitAuditer"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["ID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["Sys_ModuleAuditSetting"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM Sys_ModuleAuditSetting WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["ID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
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
