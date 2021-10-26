using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ErrorService;

namespace BasicData.BLLDAL
{
    public class BOMBase
    {
        #region 功能函数
        #region 绑定版本下拉
        public void BindVersionDropDownList(string sSFGClass, System.Windows.Forms.ComboBox control)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT dbo.[BOMM_GetBOMVersion](VersionNo,VersionSpec) as BOMVersion,ID FROM BOM_Sys_version where SFGClass='{0}' order by VersionNo asc,VersionSpec asc"
                    , sSFGClass.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return;
            }
            if (control.DisplayMember != "Text")
                control.DisplayMember = "Text";
            control.Items.Clear();
            if (dt.Rows.Count > 0)
            {
                Common.MyEntity.ComboBoxItem item;
                if (dt.Rows.Count > 0)
                {
                    item = new Common.MyEntity.ComboBoxItem();
                    item.Text = "所有版本";
                    item.Value = "";
                    control.Items.Add(item);
                }
                foreach (DataRow dr in dt.Rows)
                {
                    item = new Common.MyEntity.ComboBoxItem();
                    item.Text = dr["BOMVersion"].ToString();
                    item.Value = dr["ID"].ToString();
                    control.Items.Add(item);
                }
            }
            if (control.Items.Count > 0) control.SelectedIndex = 0;
        }
        #endregion
        #endregion
        #region 保存BOM版本信息数据
        public void SaveBOMVersion(DataTable ds)
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
                DataRow[] drs;
                #region 新增数据
                drs = ds.Select("", "", DataViewRowState.Added);
                strSql = @"INSERT INTO BOM_Sys_Version (SFGClass,VersionNo,VersionSpec,VersionDesc) 
                                SELECT @SFGClass,@VersionNo,@VersionSpec,@VersionDesc";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SFGClass";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["SFGClass"].ToString();
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionNo";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Value = dr["VersionNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionSpec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["VersionSpec"].ToString();
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionDesc";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["VersionDesc"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 更新数据
                drs = ds.Select("", "", DataViewRowState.ModifiedCurrent);
                strSql = @" UPDATE BOM_Sys_Version SET SFGClass=@SFGClass,VersionNo=@VersionNo,VersionSpec=@VersionSpec,VersionDesc=@VersionDesc WHERE ID=@ID";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SFGClass";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["SFGClass"].ToString();
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionNo";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Value = dr["VersionNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionSpec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["VersionSpec"].ToString();
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@VersionDesc";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 200;
                    sqlParam.Value = dr["VersionDesc"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ID";
                    sqlParam.SqlDbType = SqlDbType.BigInt;
                    sqlParam.Value = dr["ID", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                #region 删除数据
                drs = ds.Select("", "", DataViewRowState.Deleted);

                strSql = @"DELETE FROM BOM_Sys_Version WHERE ID=@ID";
                foreach (DataRow dr in drs)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ID";
                    sqlParam.SqlDbType = SqlDbType.BigInt;
                    sqlParam.Value = dr["ID", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
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
        #endregion
        //此类作废
        public void SaveMain(System.Data.DataSet ds)
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

                if (ds.Tables.Contains("BOM_Product_Structure") && ds.Tables["BOM_Product_Structure"].GetChanges() != null)
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = ds.Tables["BOM_Product_Structure"].Select("", "", DataViewRowState.Added);
                    strSql = @"INSERT INTO BOM_Product_Structure (GUID,ProGuid,StructGuid,StructValue,Remark) 
                                SELECT @GUID,@ProGuid,@StructGuid,@StructValue,@Remark";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ProGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StructGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["StructGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StructValue";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["StructValue"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["BOM_Product_Structure"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE BOM_Product_Structure SET ProGuid=@ProGuid,StructGuid=@StructGuid,StructValue=@StructValue,Remark=@Remark WHERE GUID=@GUID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ProGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StructGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["StructGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StructValue";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["StructValue"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["BOM_Product_Structure"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM BOM_Product_Structure WHERE GUID=@GUID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                }
                if (ds.Tables.Contains("BOM_Product") && ds.Tables["BOM_Product"].GetChanges() != null)
                {
                    DataTable dt = ds.Tables["BOM_Product"];
                    DataRow dr = dt.DefaultView[0].Row;
                    if (dr.RowState == DataRowState.Added)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO BOM_Product (GUID,ClassCode,Spec,UnitCode,Creater,CreaterName,CreateTime,Modifier,ModifierName,ModifyTime,Remark,Terminated,VersionID,VirCode) 
                                    SELECT @GUID,@ClassCode,@Spec,@UnitCode,@Creater,@CreaterName,@CreateTime,@Modifier,@ModifierName,@ModifyTime,@Remark,@Terminated,@VersionID,@VirCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ClassCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ClassCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Spec";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["Spec"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UnitCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["UnitCode"];
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
                        sqlParam.ParameterName = "@ModifierName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ModifierName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModifyTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ModifyTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VersionID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["VersionID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VirCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["VirCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();

                        sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlConn;
                        sqlCom.Transaction = sqlTrain;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "[BOMManage_Init]";

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        #region update基本资料
                        strSql = @"UPDATE BOM_Product SET ClassCode=@ClassCode,Spec=@Spec,UnitCode=@UnitCode,Creater=@Creater,CreaterName=@CreaterName,CreateTime=@CreateTime,Modifier=@Modifier,ModifierName=@ModifierName,ModifyTime=@ModifyTime,Remark=@Remark,Terminated=@Terminated,VersionID=@VersionID,VirCode=@VirCode WHERE GUID=@GUID";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ClassCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ClassCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Spec";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["Spec"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@UnitCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["UnitCode"];
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
                        sqlParam.ParameterName = "@ModifierName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ModifierName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ModifyTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ModifyTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VersionID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["VersionID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VirCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["VirCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();

                        sqlCom = new SqlCommand();
                        sqlCom.Connection = sqlConn;
                        sqlCom.Transaction = sqlTrain;
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        sqlCom.CommandText = "[BOMManage_Update]";

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GUID";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["GUID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
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
        public void Detele(string sGuid, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_Detele]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        #region 图片操作
        public void PicMoveLeft(string sGuid, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_MoveLeft]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void PicMoveRight(string sGuid, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_MoveRight]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void ProcessAdd(string sGuid,object objGuidBehind,string sProcessCode, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_ProcessAdd]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GuidBehind";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = objGuidBehind;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProcessCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sProcessCode;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void ProcessDel(string sGuid, long lID, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_ProcessDel]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lID;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void MaterialAdd(string sBOMGuid,string sProcessCode,List<BasicData.UserControls.ucMateiralItem.MateiralItemResult> listResult
            , out string strMsg, out int iReturn)
        {
            string sTmpGuid = Guid.NewGuid().ToString();
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
                #region 新增数据
               
                strSql = @"INSERT INTO BOM_Product_MaterialTemp (GUID,MaterialCode,SpecGuid,SupplierCode,Quantity,UnitCode) 
                    SELECT @GUID,@MaterialCode,@SpecGuid,@SupplierCode,@Quantity,@UnitCode";
                foreach (BasicData.UserControls.ucMateiralItem.MateiralItemResult data in listResult)
                {
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@GUID";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = sTmpGuid;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MaterialCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = data.MaterialCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SpecGuid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = data.SpecGuid;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SupplierCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = DBNull.Value;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Quantity";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 9;
                    sqlParam.Value = data.Quantity;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@UnitCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = data.UnitCode;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                //存入正式表
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[BOMManage_MaterialAdd]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@BOMGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sBOMGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProcessCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value =sProcessCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TempGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sTmpGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void MaterialRemove(string sBomGuid, string sGuid, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_MaterialRemove]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@BOMGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sBomGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GUID";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        #region 子件操作
        public void ChildAdd(string sBomGuid, string sChildGuid,decimal decQuantity, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_SFGAdd]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@BOMGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sBomGuid;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ChildGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sChildGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quantity";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = decQuantity;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
        public void ChildRemove(string sBomGuid, string sGuid, out string strMsg, out int iReturn)
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
                sqlCom.CommandText = "[BOMManage_SFGRemove]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@BOMGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sBomGuid;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Guid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
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
                sqlParam.Size = 30;
                sqlParam.Value = Common.CurrentUserInfo.UserName;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ReturnValue";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
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
                else
                    sqlTrain.Rollback();
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
