using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ErrorService;
using System.IO;

namespace UpdateERP.BLLDAL
{
    public class UpdateVersion
    {
        #region 保存
        public void SaveProject(string sName, string sVersion, string sGuid, string sRemark, string sCurrentRemark, FileInfo[] files,string sNewExes)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (UpdateDAL.DBConnString == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            string strSql;
            try
            {
                sqlConn = new SqlConnection(UpdateDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                #region 新增模块引用
                if (sNewExes != string.Empty)
                {
                    strSql = @"DELETE FROM Update_NewProject WHERE ProjectGuid=@ProjectGuid";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProjectGuid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = sGuid;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    strSql = @"INSERT INTO Update_NewProject (ProjectGuid,ForProjectName) 
                        SELECT @ProjectGuid,@ForProjectName";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProjectGuid";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = sGuid;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ForProjectName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 400;
                    sqlParam.Value = sNewExes;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                #endregion
                strSql = @"DELETE FROM Update_Version WHERE ProjectGuid=@ProjectGuid";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProjectGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                strSql = @"DELETE FROM update_Files WHERE ProjectGuid=@ProjectGuid";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProjectGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                strSql = @"INSERT INTO Update_Version(projectGuid,Projectname,Version,updatedate,Remark,CurrentRemark)
                VALUES(@projectGuid,@Projectname,@Version,GETDATE(),@Remark,@CurrentRemark)";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ProjectGuid";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sGuid;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Projectname";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 200;
                sqlParam.Value = sName;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Version";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sVersion;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Remark";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 4000;
                sqlParam.Value = sRemark;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CurrentRemark";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 4000;
                sqlParam.Value = sCurrentRemark;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (files != null)
                {

                    foreach (FileInfo file in files)
                    {
                        FileStream fs = file.OpenRead();
                        byte[] bytes = new byte[fs.Length];
                        fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                        strSql = @"INSERT INTO Update_files(ProjectGuid,[FileName],FileEntity)
                            VALUES(@ProjectGuid,@FileName,@FileEntity)";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProjectGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = sGuid;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FileName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = file.Name;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FileEntity";
                        sqlParam.SqlDbType = SqlDbType.Image;
                        sqlParam.Value = bytes;
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
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
        #endregion
    }
    public class UpdateDAL
    {
        public static string DBConnString = @"Server=JIANGPENGSONGPC\SQLEXPRESS;Database=CableERP;User=sa;Password=zxp;Connect Timeout=120;";
        public static class DoSqlCommand
        {
            #region  获取DATATABLE
            public static DataTable GetDateTable(string strSql)
            {
                try
                {
                    return GetDateTable(strSql, false);
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            public static DataTable GetDateTable(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataTable dtReturn = new DataTable();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnString);
                    sqlCom = new SqlCommand(strSql, sqlConn);
                    sqlDA = new SqlDataAdapter(sqlCom);
                    if (isSchemaSource)
                        sqlDA.FillSchema(dtReturn, SchemaType.Source);
                    sqlDA.Fill(dtReturn);
                    return dtReturn;
                }
                catch (Exception ex)
                {
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
            #region 操作数据库
            public static int DoSql(string strSql)
            {
                int iReturn;
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlTransaction sqltrian = null;
                if (DBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnString);
                    sqlConn.Open();
                    sqltrian = sqlConn.BeginTransaction();
                    sqlCom = new SqlCommand(strSql, sqlConn, sqltrian);
                    iReturn = sqlCom.ExecuteNonQuery();
                    sqltrian.Commit();
                    return iReturn;
                }
                catch (Exception ex)
                {
                    if (sqltrian != null)
                        sqltrian.Rollback();
                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                finally
                {
                    if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                        sqlConn.Close();
                }
            }
            public static void DoSql(List<string> listSql)
            {
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlTransaction sqltrian = null;
                if (DBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnString);
                    sqlConn.Open();
                    sqltrian = sqlConn.BeginTransaction();
                    foreach (string str in listSql)
                    {
                        sqlCom = new SqlCommand(str, sqlConn, sqltrian);
                        sqlCom.ExecuteNonQuery();
                    }
                    sqltrian.Commit();
                }
                catch (Exception ex)
                {
                    if (sqltrian != null)
                        sqltrian.Rollback();
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
            #region 获取DATASET
            /// <summary>
            /// 获取表集合
            /// </summary>
            /// <param name="listSqls"></param>
            /// <returns></returns>
            public static DataSet GetDateSet(List<SqlSearchEntiy> listSqls)
            {
                DataSet ds = new DataSet();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnString);
                    foreach (SqlSearchEntiy sqls in listSqls)
                    {
                        sqlCom = new SqlCommand(sqls.Sql, sqlConn);
                        sqlDA = new SqlDataAdapter(sqlCom);
                        if (!String.IsNullOrEmpty(sqls.TableName))
                        {
                            if (sqls.IsSchemaSource)
                                sqlDA.FillSchema(ds, SchemaType.Source, sqls.TableName);
                            sqlDA.Fill(ds, sqls.TableName);
                        }
                        else
                        {
                            if (sqls.IsSchemaSource)
                                sqlDA.FillSchema(ds, SchemaType.Source);
                            sqlDA.Fill(ds);
                        }
                    }
                    return ds;
                }
                catch (Exception ex)
                {
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
            #region 用设配器保存数据
            public static void SaveTable(DataTable dt, string strTableName)
            {
                SqlDataAdapter sqlDA1;
                SqlCommandBuilder sqlCB1;
                SqlConnection sqlConn = null;
                SqlTransaction sqlTran = null;
                string strSql1;
                if (DBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    strSql1 = "SELECT * FROM " + strTableName;
                    sqlConn = new SqlConnection(DBConnString);
                    sqlConn.Open();
                    sqlDA1 = new SqlDataAdapter(strSql1, sqlConn);
                    sqlCB1 = new SqlCommandBuilder(sqlDA1);
                    sqlDA1.InsertCommand = sqlCB1.GetInsertCommand();
                    sqlDA1.UpdateCommand = sqlCB1.GetUpdateCommand();
                    sqlDA1.DeleteCommand = sqlCB1.GetDeleteCommand();
                    sqlTran = sqlConn.BeginTransaction();
                    if (dt != null && dt.GetChanges() != null)
                    {
                        sqlDA1.InsertCommand.Transaction = sqlTran;
                        sqlDA1.UpdateCommand.Transaction = sqlTran;
                        sqlDA1.DeleteCommand.Transaction = sqlTran;
                        sqlDA1.Update(dt);
                    }
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    if (sqlTran != null)
                        sqlTran.Rollback();
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
        public class SqlSearchEntiy
        {
            private string _strSql;
            private string _strTableName = "";
            private bool _blSchemaSource = false;
            public SqlSearchEntiy()
            {

            }
            public SqlSearchEntiy(string strSql, string strTableName)
            {
                this._strSql = strSql;
                this._strTableName = strTableName;
            }
            public SqlSearchEntiy(string strSql, string strTableName, bool isSchemaSource)
            {
                this._strSql = strSql;
                this._strTableName = strTableName;
                this._blSchemaSource = isSchemaSource;
            }
            //查询语句
            public string Sql
            {
                get
                {
                    return this._strSql;
                }
                set
                {
                    this._strSql = value;
                }
            }
            /// <summary>
            /// 表名
            /// </summary>
            public string TableName
            {
                get
                {
                    return this._strTableName;
                }
                set
                {
                    this._strTableName = value;
                }
            }
            /// <summary>
            /// 获取表结构
            /// </summary>
            public bool IsSchemaSource
            {
                get { return this._blSchemaSource; }
                set { this._blSchemaSource = value; }
            }
        }
        public class ExceptionIsEmpty : Exception
        {
            private string _strMessage = "数据连接字符窜为空,请重新登陆";
            public ExceptionIsEmpty()
            {
            }
            //出始化错误
            public ExceptionIsEmpty(string strMessage)
            {
                this._strMessage = strMessage;
            }
            public override string Message
            {
                get
                {
                    return this._strMessage;
                }
            }
        }
        public static bool ReadInifile()
        {
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "Server.ini";
            if (!System.IO.File.Exists(strFile))
            {
                System.Windows.Forms.MessageBox.Show("配置文件Server.ini丢失。", "系统提示");
                return false;
            }
            Common.CommonFuns.ConfigINI.INIFileName = "Server.ini";
            string strServer = Common.CommonFuns.ConfigINI.GetString("Update", "IP", string.Empty);
            string strDataBase = Common.CommonFuns.ConfigINI.GetString("Update", "DataBase", string.Empty);
            string strUser = Common.CommonFuns.ConfigINI.GetString("Update", "User", string.Empty);
            string strPwd = Common.CommonFuns.ConfigINI.GetString("Update", "pwd", string.Empty);
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(strPwd);
            string strDbCon = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                , strServer, strDataBase, strUser, strPwd);
            DBConnString = strDbCon;
            return true;
        }
    }

}
