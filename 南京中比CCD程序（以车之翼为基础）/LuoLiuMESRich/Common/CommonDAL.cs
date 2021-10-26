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
        public static class DoSqlCommandLog
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
            #region �������ݿ�
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
            #region ����������������
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
            MainProgramName = Common.CommonFuns.ConfigINI.GetString("Server", "������", string.Empty);
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
                wErrorMessage.ShowErrorDialog(null, new Exception(string.Format("δ�ܼ���\"{0}\"��Զ�̷�����·����", sName)));
                return false;
            }
            sConnectedString= drs[0]["ConnectString"].ToString();
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
        public static string MyCopyRight = "����MES";
        /// <summary>
        /// ����˾����
        /// </summary>
        public static string MyCompany = "����MES";
        /// <summary>
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
        public static string SystemMainFormCaption = "����MES";
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
        /// <summary>
        /// ��ǰ��δ���
        /// </summary>
        public static string BanCi = string.Empty;
        /// <summary>
        /// ��ǰ�������
        /// </summary>
        public static string BanCiName = string.Empty;
        /// <summary>
        /// PC����MESϵͳ�еǼǵı��
        /// </summary>
        public static string TerminalCode = string.Empty;
        public static List<Common.MyEntity.Job> Assistants = null;
        /// <summary>
        /// ע����ǰ��½
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
                //System.Windows.Forms.MessageBox.Show("�û����롰" + sUserCode + "�������ڣ�");
                return false;
            }
            if (!dt.Rows[0]["Terminated"].Equals(DBNull.Value)
                && (bool)dt.Rows[0]["Terminated"])
            {
                //System.Windows.Forms.MessageBox.Show("�û����롰" + sUserCode + "���Ѿ���ͣ�ã���Ҫ��½����������ϵ����Ա�������ã�");
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
                    strErr = "����ʧ�ܣ�ԭ��δ֪��";
                System.Windows.Forms.MessageBox.Show(strErr);
                return false;
            }
            return true;
        }
    }
    #endregion
}
