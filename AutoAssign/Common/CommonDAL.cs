using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ErrorService;
using System.Data.OleDb;

namespace Common
{
    #region ϵͳ���ݴ���
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
        /// ��ʶ�Ƿ�ʱ��̬�򿪵ģ�����ǵ�Ҫ����topmost=true
        /// </summary>
        public static bool OpenByZutai = false;
        
        public static class DoSqlCommand
        {
            #region  ��ȡDATATABLE
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
            #region �������ݿ�
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
            #region ��ȡDATASET
            /// <summary>
            /// ��ȡ����
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
            #region ����������������
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
            #region  ��ȡDATATABLE
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
            #region �������ݿ�
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
            #region ��ȡDATASET
            /// <summary>
            /// ��ȡ����
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
            #region ����������������
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
            #region  ��ȡDATATABLE
            public static DataTable GetDateTable(string strSql)
            {
                DataTable dtReturn = new DataTable();
                OleDbCommand sqlCom;
                OleDbConnection sqlConn = null;
                OleDbDataAdapter sqlDA;
                if (LocalDBConnString == string.Empty)
                {
                    Exception ex = new Exception("�����ַ���Ϊ�գ������������ݿ�·����");
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
            #region �������ݿ�
            public static int DoSql(string strSql)
            {
                int iReturn;
                OleDbCommand sqlCom;
                OleDbConnection sqlConn = null;
                OleDbTransaction sqltrian = null;
                if (LocalDBConnString == string.Empty)
                {
                    Exception ex = new Exception("�����Ը���Ϊ�գ������������ݿ�·����");
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
                    Exception ex = new Exception("�����Ը���Ϊ�գ������������ݿ�·����");
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
            #region  ��ȡDATATABLE
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
            #region �������ݿ�
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
            #region ��ȡDATASET
            /// <summary>
            /// ��ȡ����
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
            #region ����������������
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
            #region  ��ȡDATATABLE
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
            #region �������ݿ�
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
            #region ��ȡDATASET
            /// <summary>
            /// ��ȡ����
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
            #region ����������������
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
            //��ѯ���
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
            /// ����
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
            /// ��ȡ��ṹ
            /// </summary>
            public bool IsSchemaSource
            {
                get { return this._blSchemaSource; }
                set { this._blSchemaSource = value; }
            }
        }
        public class ExceptionIsEmpty : Exception
        {
            private string _strMessage = "���������ַ���Ϊ��,�����µ�½";
            public ExceptionIsEmpty()
            {
            }
            //��ʼ������
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
                System.Windows.Forms.MessageBox.Show("�����ļ�Server.ini��ʧ��", "ϵͳ��ʾ");
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
                System.Windows.Forms.MessageBox.Show("����ȷ����Server·����", "ϵͳ��ʾ");
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
                System.Windows.Forms.MessageBox.Show("����ȷ����RemoteMES·����", "ϵͳ��ʾ");
                return false;
            }
            Common.CommonDAL.DBConnStringRemoteMES = string.Format("Server={0};Database={1};User={2};Password={3};Connect Timeout=120;"
                , strServer, strDataBase, strUser, strPwd);
            return true;
        }
    }
    #endregion
    #region ϵͳ���ݴ���(�Զ���)
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
        #region  ��ȡDATATABLE
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
                Exception ex = new Exception("�����ַ���Ϊ�ա�");
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
        #region �������ݿ�
        public int DoSql(string strSql)
        {
            int iReturn;
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlTransaction sqltrian = null;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("�����ַ���Ϊ�ա�");

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
                Exception ex = new Exception("�����ַ���Ϊ�ա�");

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
        #region ��ȡDATASET
        /// <summary>
        /// ��ȡ����
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
                Exception ex = new Exception("�����ַ���Ϊ�ա�");

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
                Exception ex = new Exception("�����ַ���Ϊ�ա�");

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
        #region ����������������
        public void SaveTable(DataTable dt, string strTableName)
        {
            SqlDataAdapter sqlDA1;
            SqlCommandBuilder sqlCB1;
            SqlConnection sqlConn = null;
            SqlTransaction sqlTran = null;
            string strSql1;
            if (DBConnString == string.Empty)
            {
                Exception ex = new Exception("�����ַ���Ϊ�ա�");
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
    #region ϵͳ����
    public class CommonConfig
    {
        /// <summary>
        /// ϵͳ�汾��
        /// </summary>
        public static string MyVersion = "";
        /// <summary>
        /// ��Ȩ����
        /// </summary>
        public static string MyCopyRight = "��ͨͨ�ż��Źɷ����޹�˾";
        /// <summary>
        /// ����˾����
        /// </summary>
        public static string MyCompany = "��ͨͨ�ż��Źɷ����޹�˾";/// <summary>
        /// ����˾���룬���ֶ����ڱ��������ʱ��
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
        /// ���������̧ͷ
        /// </summary>
        public static string SystemMainFormCaption = "������������ϵͳ";
        /// <summary>
        /// ��ȡϵͳĬ�ϵ����ļ��Ĵ��·��
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultOutputFolder()
        {
            string strFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFolder.EndsWith("\\"))
                strFolder += "\\";
            strFolder += "ϵͳ�����ļ�";
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
        /// ϵͳ�쳣��Ϣ����
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultExpInfoFolder()
        {
            string strFolder = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFolder.EndsWith("\\"))
                strFolder += "\\";
            strFolder += "ϵͳ�쳣��Ϣ����";
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
        /// ϵͳ�����ʽ1���Ŀ¼
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
        /// ϵͳִ��ʧ��ʱ��ʾ������
        /// </summary>
        public static string SoundErr = "Sound\\MCITEST.WAV";
        /// <summary>
        /// ϵͳִ�гɹ�ʱ��ʾ������
        /// </summary>
        public static string SoundOk = "Sound\\ding.wav";
    }
    #endregion
    #region ��ǰ��¼�û�����Ϣ
    public class CurrentUserInfo
    {
        /// <summary>
        /// �û�����
        /// </summary>
        private static string _strUserCode = "";
        /// <summary>
        /// �û�����
        /// </summary>
        private static string _strUserName = "";
        /// <summary>
        /// ���ű���
        /// </summary>
        public static string DeptCode = "";
        /// <summary>
        /// ��������
        /// </summary>
        public static string DeptName = "";
        /// <summary>
        /// ����ȫ�ƣ���������������Ϣ��
        /// </summary>
        public static string DeptFullName = "";
        /// <summary>
        /// �Ƿ����Ա
        /// </summary>
        public static bool IsAdmin = false;
        /// <summary>
        /// �Ƿ�Ϊ�����û�
        /// </summary>
        public static bool IsSuper = true;
        /// <summary>
        /// ϵͳĬ���û�
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
