using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ErrorService;
using System.Data.OleDb;

namespace Common
{
    #region 系统数据处理
    public class CommonDAL
    {
        public static string DBConnString = @"Server=.\JPS2008;Database=LuoLiuMES;User=sa;Password=zxp;Connect Timeout=120;";
        public static string DBCPrintConnString = @"ODBC;DRIVER=SQL Server;SERVER=.\JPS2008;UID=sa;PWD=zxp;APP=Microsoft Office 2003;WSID=KFB011;DATABASE=LuoLiuMES";
        public static string DBERPLogConnString
        {
            get
            {
                return DBConnString;
            }
        }
        public static string DBConnStringBasic
        {
            get
            {
                return DBConnString;
            }
        }
        public static string MainProgramName = "";
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

                    ErrorLog.WriteErrorLog(ex);
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
            public static DataSet GetDateSet(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataSet dsReturn = new DataSet();
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
                    sqlCom = new SqlCommand(strSql, sqlConn);
                    sqlDA = new SqlDataAdapter(sqlCom);
                    if (isSchemaSource)
                        sqlDA.FillSchema(dsReturn, SchemaType.Source);
                    sqlDA.Fill(dsReturn);
                    return dsReturn;
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
        public static class DoSqlCommandBasic
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
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringBasic);
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
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringBasic);
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
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringBasic);
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
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringBasic);
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
            public static DataSet GetDateSet(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringBasic);
                    sqlCom = new SqlCommand(strSql, sqlConn);
                    sqlDA = new SqlDataAdapter(sqlCom);
                    if (isSchemaSource)
                        sqlDA.FillSchema(dsReturn, SchemaType.Source);
                    sqlDA.Fill(dsReturn);
                    return dsReturn;
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
                if (DBConnStringBasic == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    strSql1 = "SELECT * FROM " + strTableName;
                    sqlConn = new SqlConnection(DBConnStringBasic);
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
        public static class DoSqlCommandLog
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
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBERPLogConnString);
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
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBERPLogConnString);
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
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBERPLogConnString);
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
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBERPLogConnString);
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
            public static DataSet GetDateSet(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBERPLogConnString);
                    sqlCom = new SqlCommand(strSql, sqlConn);
                    sqlDA = new SqlDataAdapter(sqlCom);
                    if (isSchemaSource)
                        sqlDA.FillSchema(dsReturn, SchemaType.Source);
                    sqlDA.Fill(dsReturn);
                    return dsReturn;
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
                if (DBERPLogConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    strSql1 = "SELECT * FROM " + strTableName;
                    sqlConn = new SqlConnection(DBERPLogConnString);
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
        public static string StartArg = "";
        public static int UpdateProcessID = -1;
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
            MainProgramName = Common.CommonFuns.ConfigINI.GetString("Server", "主程序", string.Empty);
            StartArg = Common.CommonFuns.ConfigINI.GetString("Server", "StartArg", string.Empty);
            string strServer = Common.CommonFuns.ConfigINI.GetString("Server", "IP", string.Empty);
            string strDataBase = Common.CommonFuns.ConfigINI.GetString("Server", "DataBase", string.Empty);
            string strUser = Common.CommonFuns.ConfigINI.GetString("Server", "User", string.Empty);
            string strPwd = Common.CommonFuns.ConfigINI.GetString("Server", "pwd", string.Empty);
            CurrentUserInfo.DefaultUserCode = Common.CommonFuns.ConfigINI.GetString("Server", "DefaultUserCode", string.Empty);
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(strPwd);
            CommonDAL.DBConnString = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                    , strServer, strDataBase, strUser, strPwd);
            CommonDAL.DBCPrintConnString = string.Format("ODBC;DRIVER=SQL Server;SERVER={0};UID={1};PWD={2};APP=Microsoft Office 2003;WSID=KFB011;DATABASE={3}"
                    , strServer, strUser, strPwd, strDataBase);
            return true;
        }
        private static bool GetMyDBString(DataTable dtSource,string sName,out string sConnectedString)
        {
            sConnectedString = string.Empty;
            DataRow[] drs = dtSource.Select("DBName='" + sName + "'");
            if (drs.Length == 0)
            {
                wErrorMessage.ShowErrorDialog(null, new Exception(string.Format("未能加载\"{0}\"的远程服务器路径。", sName)));
                return false;
            }
            sConnectedString= drs[0]["ConnectString"].ToString();
            return true;
        }
    }
    #endregion
    #region 系统数据处理(自定义)
    public class SqlServerCommand
    {
        public string DBConnString = @"Server=JIANGPENGSONGPC\SQLEXPRESS;Database=CableERP;User=sa;Password=zxp;Connect Timeout=120;";
        public SqlServerCommand()
        {
        }
        public SqlServerCommand(string sDBConstring)
        {
            if (sDBConstring.Length > 0)
                DBConnString = sDBConstring;
        }
        #region  获取DATATABLE
        public DataTable GetDateTable(string strSql)
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
        public DataTable GetDateTable(string strSql, bool isSchemaSource)
        {
            if (String.IsNullOrEmpty(strSql))
                return null;
            DataTable dtReturn = new DataTable();
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlDataAdapter sqlDA;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");
                ErrorLog.WriteErrorLog(ex);
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
        public int DoSql(string strSql)
        {
            int iReturn;
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlTransaction sqltrian = null;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");

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
        public void DoSql(List<string> listSql)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlTransaction sqltrian = null;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");

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
        public DataSet GetDateSet(List<Common.CommonDAL.SqlSearchEntiy> listSqls)
        {
            DataSet ds = new DataSet();
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlDataAdapter sqlDA;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");

                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(DBConnString);
                foreach (Common.CommonDAL.SqlSearchEntiy sqls in listSqls)
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
        public DataSet GetDateSet(string strSql, bool isSchemaSource)
        {
            if (String.IsNullOrEmpty(strSql))
                return null;
            DataSet dsReturn = new DataSet();
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlDataAdapter sqlDA;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");

                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(DBConnString);
                sqlCom = new SqlCommand(strSql, sqlConn);
                sqlDA = new SqlDataAdapter(sqlCom);
                if (isSchemaSource)
                    sqlDA.FillSchema(dsReturn, SchemaType.Source);
                sqlDA.Fill(dsReturn);
                return dsReturn;
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
        public void SaveTable(DataTable dt, string strTableName)
        {
            SqlDataAdapter sqlDA1;
            SqlCommandBuilder sqlCB1;
            SqlConnection sqlConn = null;
            SqlTransaction sqlTran = null;
            string strSql1;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("连接字符串为空。");
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
    #endregion
    #region 系统配置
    public class CommonConfig
    {
        /// <summary>
        /// 系统版本号
        /// </summary>
        public static string MyVersion = "";
        /// <summary>
        /// 版权所属
        /// </summary>
        public static string MyCopyRight = "洛柳MES";
        /// <summary>
        /// 本公司名称
        /// </summary>
        public static string MyCompany = "洛柳MES";
        /// <summary>
        /// 本公司代码，此字段用于辨别多个工厂时用
        /// </summary>
        private static string MyCompanyCode = "";
        public static string GetMyCompanyCode()
        {
            if (MyCompanyCode != "") return MyCompanyCode;
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT dbo.Commom_MyCompanyCode()");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return string.Empty;
            }
            MyCompanyCode = dt.Rows[0][0].ToString();
            return MyCompanyCode;
        }
        /// <summary>
        /// 软件主窗体抬头
        /// </summary>
        public static string SystemMainFormCaption = "洛柳MES";
        /// <summary>
        /// 获取系统默认导出文件的存放路径
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultOutputFolder()
        {
            string strFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFolder.EndsWith("\\"))
                strFolder += "\\";
            strFolder += "系统导出文件";
            try
            {
                if (!System.IO.Directory.Exists(strFolder))
                    System.IO.Directory.CreateDirectory(strFolder);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strFolder;
        }
        /// <summary>
        /// 系统异常信息导出
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultExpInfoFolder()
        {
            string strFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFolder.EndsWith("\\"))
                strFolder += "\\";
            strFolder += "系统异常信息导出";
            try
            {
                if (!System.IO.Directory.Exists(strFolder))
                    System.IO.Directory.CreateDirectory(strFolder);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return strFolder;
        }
        /// <summary>
        /// 系统报表格式1存放目录
        /// </summary>
        public static string GetReport1Directory(bool isfullPath)
        {
            string strFolder = string.Empty;
            if (isfullPath)
            {
                strFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                if (!strFolder.EndsWith("\\"))
                    strFolder += "\\";
            }
            return strFolder + "Report1\\";
        }
        /// <summary>
        /// 系统执行失败时提示的声音
        /// </summary>
        public static string SoundErr = "Sound\\MCITEST.WAV";
        /// <summary>
        /// 系统执行成功时提示的声音
        /// </summary>
        public static string SoundOk = "Sound\\ding.wav";
    }
    #endregion
    #region 当前登录用户的信息
    public class CurrentUserInfo
    {
        /// <summary>
        /// 用户代码
        /// </summary>
        private static string _strUserCode = "";
        /// <summary>
        /// 用户名称
        /// </summary>
        private static string _strUserName = "";
        /// <summary>
        /// 部门编码
        /// </summary>
        public static string DeptCode = "";
        /// <summary>
        /// 部门名称
        /// </summary>
        public static string DeptName = "";
        /// <summary>
        /// 部门全称（包含父级部门信息）
        /// </summary>
        public static string DeptFullName = "";
        /// <summary>
        /// 是否管理员
        /// </summary>
        public static bool IsAdmin = false;
        /// <summary>
        /// 是否为超级用户
        /// </summary>
        public static bool IsSuper = true;
        /// <summary>
        /// 系统默认用户
        /// </summary>
        public static string DefaultUserCode = "";
        /// <summary>
        /// 当前班次代码
        /// </summary>
        public static string BanCi = string.Empty;
        /// <summary>
        /// 当前班次名称
        /// </summary>
        public static string BanCiName = string.Empty;
        /// <summary>
        /// PC机在MES系统中登记的编号
        /// </summary>
        public static string TerminalCode = string.Empty;
        public static List<Common.MyEntity.Job> Assistants = null;
        /// <summary>
        /// 注销当前登陆
        /// </summary>
        public static void Logout()
        {
            UserCode = string.Empty;
            UserName = string.Empty;
            DeptCode = string.Empty;
            DeptName = string.Empty;
            IsAdmin = false;
            IsSuper = false;
            BanCi = string.Empty;
            BanCiName = string.Empty;
            if (Assistants != null) Assistants = null;
        }
        public static bool CheckLogin()
        {
            if (UserCode != string.Empty) return true;
            Common.Login.frmLogin frmlogin = new Common.Login.frmLogin();
            if (System.Windows.Forms.DialogResult.OK != frmlogin.ShowDialog())
                return false;
            return true;
        }
        public static bool CheckAssistants(string sProcessCode,string sMacCode)
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC JC_Jobs_GetMacJob '{0}','{1}'"
                    , sProcessCode.Replace("'", "''"), sMacCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0) return true;
            List<Common.MyEntity.Job> list = new List<Common.MyEntity.Job>();
            foreach (DataRow dr in dt.Rows)
            {
                Common.MyEntity.Job job = new Common.MyEntity.Job();
                job.JobCode = dr["JobCode"].ToString();
                job.JobName = dr["JobName"].ToString();
                job.JobDesc = dr["JobDesc"].ToString();
                list.Add(job);
            }
            Login.frmAssistants frm = new Common.Login.frmAssistants();
            frm._SelectedData = list;
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return false;
            CurrentUserInfo.Assistants = frm._SelectedData;
            return true;
        }
        public static string UserCode
        {
            get
            {
                return _strUserCode;
            }
            set
            {
                _strUserCode = value;
                ErrorService.ErrorUserInfo.UserCode = value;
            }
        }
        public static string UserName
        {
            get
            {
                return _strUserName;
            }
            set
            {
                _strUserName = value;
                ErrorService.ErrorUserInfo.UserName = value;
            }
        }
        public static bool AutoInitUser(string sUserCode)
        {
            DataTable dt = null;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT *,dbo.SysSetting_GetDeptFullName(DeptCode) AS DeptFullName FROM V_sys_users WHERE UserCode='{0}'", sUserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                //System.Windows.Forms.MessageBox.Show("用户编码“" + sUserCode + "”不存在！");
                return false;
            }
            if (!dt.Rows[0]["Terminated"].Equals(DBNull.Value)
                && (bool)dt.Rows[0]["Terminated"])
            {
                //System.Windows.Forms.MessageBox.Show("用户编码“" + sUserCode + "”已经被停用，如要登陆，您可以联系管理员重新启用！");
                return false;
            }
            Common.CurrentUserInfo.UserCode = dt.Rows[0]["UserCode"].ToString();
            Common.CurrentUserInfo.UserName = dt.Rows[0]["UserName"].ToString();
            Common.CurrentUserInfo.DeptCode = dt.Rows[0]["DeptCode"].ToString();
            Common.CurrentUserInfo.DeptName = dt.Rows[0]["DeptName"].ToString();
            Common.CurrentUserInfo.DeptFullName = dt.Rows[0]["DeptFullName"].ToString();
            Common.CurrentUserInfo.IsAdmin = !dt.Rows[0]["IsAdmin"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsAdmin"];
            Common.CurrentUserInfo.IsSuper = !dt.Rows[0]["IsSuper"].Equals(DBNull.Value) && (bool)dt.Rows[0]["IsSuper"];
            return true;
        }
        public static bool UpdateMacOperator(string sMacCode)
        {
            return UpdateMacOperator(sMacCode, Common.CurrentUserInfo.Assistants);
        }
        public static bool UpdateMacOperator(string sMacCode, List<Common.MyEntity.Job> assistants)
        {
            BLLDAL.Users dal = new Common.BLLDAL.Users();
            string strAssistants = UserCode + ",";
            string str2 = string.Empty;
            string strTmp;
            if (assistants != null)
            {
                foreach (Common.MyEntity.Job job in assistants)
                {
                    strTmp = string.Format("{0}|{1},", job.JobCode, job.UserCode);
                    if ((strAssistants.Length + strTmp.Length) > 4000)
                        str2 += strTmp;
                    else strAssistants += strTmp;
                }
            }
            int iReturnValue;
            string strErr;
            try
            {
                dal.MacOperatorUpdate(sMacCode, strAssistants, str2, out strErr, out iReturnValue);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(null, ex);
                return false;
            }
            if (iReturnValue != 1)
            {
                if (strErr.Length == 0)
                    strErr = "操作失败，原因未知！";
                System.Windows.Forms.MessageBox.Show(strErr);
                return false;
            }
            return true;
        }
    }
    #endregion
}
