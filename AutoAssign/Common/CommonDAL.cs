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
        //public static string DBConnString = @"Server=192.168.1.104\sqlexpress;Database=Dongtou;User=sa;Password=zxp;Connect Timeout=120;";
        //public static string DBConnString = @"Server=.;Database=YouBeiKangBao;User=sa;Password=zxp;Connect Timeout=120;";
        //public static string DBConnString = @"Server=.;Database=Proportioner;User=sa;Password=hzMr1983;Connect Timeout=120;";
        public static string RealDataDBConnString = @"Server=114.116.9.165;Database=RealData;User=sa;Password=hzMr1983;Connect Timeout=120;";
        //public static string DBConnString = @"Server=.;Database=PressureScanner;User=sa;Password=zxp;Connect Timeout=120;";
        public static string DBConnString = @"Server=.;Database=Bearing;User=sa;Password=zxp;Connect Timeout=120;";
        public static string DBConnStringRemoteMES = @"Server=.;Database=Bearing;User=sa;Password=zxp;Connect Timeout=120;";
        public static string DBConnStringBasic = @"Server=.;Database=Bearing;User=sa;Password=zxp;Connect Timeout=120;";
        public static string LocalDBConnString = "";//@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SAIFTestServer 20171005.mdb;Jet OLEDB:Database Password=atlascopco";
        public static string MainProgramName = "";
        /// <summary>
        /// 标识是否时组态打开的，如果是的要设置topmost=true
        /// </summary>
        public static bool OpenByZutai = false;
        
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
        public static class DoSqlCommandLocal
        {
            public static string INIFileName = "Config.ini";
            #region  获取DATATABLE
            public static DataTable GetDateTable(string strSql)
            {
                DataTable dtReturn = new DataTable();
                OleDbCommand sqlCom;
                OleDbConnection sqlConn = null;
                OleDbDataAdapter sqlDA;
                if (LocalDBConnString == string.Empty)
                {
                    Exception ex = new Exception("链接字符窜为空，请先设置数据库路径。");
                    throw (ex);
                }
                try
                {
                    sqlConn = new OleDbConnection(LocalDBConnString);
                    sqlCom = new OleDbCommand(strSql, sqlConn);
                    sqlDA = new OleDbDataAdapter(sqlCom);
                    sqlDA.Fill(dtReturn);
                    return dtReturn;
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                        sqlConn.Close();
                }
            }
            #region 操作数据库
            public static int DoSql(string strSql)
            {
                int iReturn;
                OleDbCommand sqlCom;
                OleDbConnection sqlConn = null;
                OleDbTransaction sqltrian = null;
                if (LocalDBConnString == string.Empty)
                {
                    Exception ex = new Exception("链接自负窜为空，请先设置数据库路径。");
                    throw (ex);
                }
                try
                {
                    sqlConn = new OleDbConnection(LocalDBConnString);
                    sqlConn.Open();
                    sqltrian = sqlConn.BeginTransaction();
                    sqlCom = new OleDbCommand(strSql, sqlConn, sqltrian);
                    iReturn = sqlCom.ExecuteNonQuery();
                    sqltrian.Commit();
                    return iReturn;
                }
                catch (Exception ex)
                {
                    if (sqltrian != null)
                        sqltrian.Rollback();
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
                OleDbCommand sqlCom;
                OleDbConnection sqlConn = null;
                OleDbTransaction sqltrian = null;
                if (LocalDBConnString == string.Empty)
                {
                    Exception ex = new Exception("链接自负窜为空，请先设置数据库路径。");
                    throw (ex);
                }
                try
                {
                    sqlConn = new OleDbConnection(LocalDBConnString);
                    sqlConn.Open();
                    sqltrian = sqlConn.BeginTransaction();
                    foreach (string str in listSql)
                    {
                        sqlCom = new OleDbCommand(str, sqlConn, sqltrian);
                        sqlCom.ExecuteNonQuery();
                    }
                    sqltrian.Commit();
                }
                catch (Exception ex)
                {
                    if (sqltrian != null)
                        sqltrian.Rollback();
                    throw (ex);
                }
                finally
                {
                    if (sqlConn != null && sqlConn.State == ConnectionState.Open)
                        sqlConn.Close();
                }
            }
            #endregion
            #endregion
        }
        public static class DoSqlCommandRealData
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(RealDataDBConnString);
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(RealDataDBConnString);
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(RealDataDBConnString);
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(RealDataDBConnString);
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(RealDataDBConnString);
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
                if (RealDataDBConnString == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    strSql1 = "SELECT * FROM " + strTableName;
                    sqlConn = new SqlConnection(RealDataDBConnString);
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

        public static class DoSqlCommandRemoteMES
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
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
            public static DataSet GetDateSet(string strSql, bool isSchemaSource)
            {
                if (String.IsNullOrEmpty(strSql))
                    return null;
                DataSet dsReturn = new DataSet();
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlDataAdapter sqlDA;
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
            #region 操作数据库
            public static int DoSql(string strSql)
            {
                int iReturn;
                SqlCommand sqlCom;
                SqlConnection sqlConn = null;
                SqlTransaction sqltrian = null;
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();

                    ErrorLog.WriteErrorLog(ex);
                    throw (ex);
                }
                try
                {
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
                if (DBConnStringRemoteMES == string.Empty)
                {
                    ExceptionIsEmpty ex = new ExceptionIsEmpty();
                    throw (ex);
                }
                try
                {
                    strSql1 = "SELECT * FROM " + strTableName;
                    sqlConn = new SqlConnection(DBConnStringRemoteMES);
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
            Common.CommonDAL.StartArg = Common.CommonFuns.ConfigINI.GetString("Server", "StartArg", string.Empty);
            string strServer = Common.CommonFuns.ConfigINI.GetString("Server", "IP", string.Empty);
            string strUser = Common.CommonFuns.ConfigINI.GetString("Server", "User", string.Empty);
            string strPwd = Common.CommonFuns.ConfigINI.GetString("Server", "pwd", string.Empty);
            string strDefaultUserCode = Common.CommonFuns.ConfigINI.GetString("Server", "DefaultUserCode", string.Empty);
            if(strServer.Length==0)
            {
                System.Windows.Forms.MessageBox.Show("请正确配置Server路径。", "系统提示");
                return false;
            }
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(strPwd);
            Common.CommonDAL.DBConnString = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                , strServer, "LuoLiuAssigner", strUser, strPwd);
            Common.CommonDAL.DBConnStringBasic = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                , strServer, "LuoLiuAssignerBasic", strUser, strPwd);
            ErrorDAL.DBConnString = DBConnString;
            strServer = Common.CommonFuns.ConfigINI.GetString("RemoteMES", "IP", string.Empty);
            string strDataBase = Common.CommonFuns.ConfigINI.GetString("RemoteMES", "DataBase", string.Empty);
            strUser = Common.CommonFuns.ConfigINI.GetString("RemoteMES", "User", string.Empty);
            strPwd = Common.CommonFuns.ConfigINI.GetString("RemoteMES", "pwd", string.Empty);
            strPwd = Common.CommonFuns.EncryptDecryptService.Base64Decrypt(strPwd);
            if (strServer.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("请正确配置RemoteMES路径。", "系统提示");
                return false;
            }
            Common.CommonDAL.DBConnStringRemoteMES = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                , strServer, strDataBase, strUser, strPwd);
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
        public static string MyCopyRight = "富通通信集团股份有限公司";
        /// <summary>
        /// 本公司名称
        /// </summary>
        public static string MyCompany = "富通通信集团股份有限公司";/// <summary>
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
        public static string SystemMainFormCaption = "光缆生产管理系统";
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
        public static void Logout()
        {
            CurrentUserInfo.UserCode = string.Empty;
            CurrentUserInfo.UserName = string.Empty;
            CurrentUserInfo.DeptCode = string.Empty;
            CurrentUserInfo.DeptName = string.Empty;
            CurrentUserInfo.DeptFullName = string.Empty;
        }
    }
    #endregion
}
