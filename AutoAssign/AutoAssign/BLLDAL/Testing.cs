using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;

namespace AutoAssign.BLLDAL
{
    public class Testing
    {
        #region 存储电芯
        public void SaveDianXin(string sMacNo,string sTableName,short iScannerNo, string sSn0, string sSn1, string sSn2, string sSn3, string sSn4, string sSn5, string sSn6, string sSn7, string sSn8, string sSn9,
            bool isNG0, bool isNG1, bool isNG2, bool isNG3, bool isNG4, bool isNG5, bool isNG6, bool isNG7, bool isNG8, bool isNG9,
            bool isMBatchNumOK0, bool isMBatchNumOK1, bool isMBatchNumOK2, bool isMBatchNumOK3, bool isMBatchNumOK4, bool isMBatchNumOK5, bool isMBatchNumOK6, bool isMBatchNumOK7, bool isMBatchNumOK8, bool isMBatchNumOK9,
            bool IsSNChongFu0, bool IsSNChongFu1, bool IsSNChongFu2, bool IsSNChongFu3, bool IsSNChongFu4, bool IsSNChongFu5, bool IsSNChongFu6, bool IsSNChongFu7, bool IsSNChongFu8, bool IsSNChongFu9,
           out string sMyCode0, out string sMyCode1, out string sMyCode2, out string sMyCode3, out string sMyCode4, out string sMyCode5, out string sMyCode6, out string sMyCode7, out string sMyCode8, out string sMyCode9)
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
                sqlCom.CommandText = "[SaveDianXin]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@macNo";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 1;
                sqlParam.Value = sMacNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@tableName";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sTableName;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ScannerNo";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iScannerNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn0";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn0;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn9;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG0";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG0;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG1";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG2";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG3";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG4";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG5";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG6";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG7";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG8";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsNG9";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isNG9;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK0";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK0;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK1";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK2";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK3";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK4";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK5";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK6";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK7";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK8";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsMBatchNumOK9";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isMBatchNumOK9;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu0";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu0;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu1";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu2";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu3";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu4";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu5";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu6";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu7";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu8";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsSNChongFu9";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = IsSNChongFu9;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode0";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                sqlTrain.Commit();
                sMyCode0 = sqlCom.Parameters["@MyCode0"].Value != null ? sqlCom.Parameters["@MyCode0"].Value.ToString() : string.Empty;
                sMyCode1 = sqlCom.Parameters["@MyCode1"].Value != null ? sqlCom.Parameters["@MyCode1"].Value.ToString() : string.Empty;
                sMyCode2 = sqlCom.Parameters["@MyCode2"].Value != null ? sqlCom.Parameters["@MyCode2"].Value.ToString() : string.Empty;
                sMyCode3 = sqlCom.Parameters["@MyCode3"].Value != null ? sqlCom.Parameters["@MyCode3"].Value.ToString() : string.Empty;
                sMyCode4 = sqlCom.Parameters["@MyCode4"].Value != null ? sqlCom.Parameters["@MyCode4"].Value.ToString() : string.Empty;
                sMyCode5 = sqlCom.Parameters["@MyCode5"].Value != null ? sqlCom.Parameters["@MyCode5"].Value.ToString() : string.Empty;
                sMyCode6 = sqlCom.Parameters["@MyCode6"].Value != null ? sqlCom.Parameters["@MyCode6"].Value.ToString() : string.Empty;
                sMyCode7 = sqlCom.Parameters["@MyCode7"].Value != null ? sqlCom.Parameters["@MyCode7"].Value.ToString() : string.Empty;
                sMyCode8 = sqlCom.Parameters["@MyCode8"].Value != null ? sqlCom.Parameters["@MyCode8"].Value.ToString() : string.Empty;
                sMyCode9 = sqlCom.Parameters["@MyCode9"].Value != null ? sqlCom.Parameters["@MyCode9"].Value.ToString() : string.Empty;
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
        #region 读取原始信息
        public void GetDxOrgInfo(short iScannerNo, string sSn0, string sSn1, string sSn2, string sSn3, string sSn4, string sSn5, string sSn6, string sSn7, string sSn8, string sSn9
            , out decimal decCapacity0
            , out decimal decCapacity1
            , out decimal decCapacity2
            , out decimal decCapacity3
            , out decimal decCapacity4
            , out decimal decCapacity5
            , out decimal decCapacity6
            , out decimal decCapacity7
            , out decimal decCapacity8
            , out decimal decCapacity9
            , out decimal decR0
            , out decimal decR1
            , out decimal decR2
            , out decimal decR3
            , out decimal decR4
            , out decimal decR5
            , out decimal decR6
            , out decimal decR7
            , out decimal decR8
            , out decimal decR9
            , out decimal decV0
            , out decimal decV1
            , out decimal decV2
            , out decimal decV3
            , out decimal decV4
            , out decimal decV5
            , out decimal decV6
            , out decimal decV7
            , out decimal decV8
            , out decimal decV9
            )
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
                sqlCom.CommandText = "[NanJingZB_ReadOrgInfo]";
                
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ScannerNo";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iScannerNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn0";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn0;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Sn9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sSn9;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlCom.ExecuteNonQuery();
                sqlTrain.Commit();
                decCapacity0 = sqlCom.Parameters["@Capacity0"].Value == null || sqlCom.Parameters["@Capacity0"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity0"].Value;
                decCapacity1 = sqlCom.Parameters["@Capacity1"].Value == null || sqlCom.Parameters["@Capacity1"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity1"].Value;
                decCapacity2 = sqlCom.Parameters["@Capacity2"].Value == null || sqlCom.Parameters["@Capacity2"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity2"].Value;
                decCapacity3 = sqlCom.Parameters["@Capacity3"].Value == null || sqlCom.Parameters["@Capacity3"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity3"].Value;
                decCapacity4 = sqlCom.Parameters["@Capacity4"].Value == null || sqlCom.Parameters["@Capacity4"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity4"].Value;
                decCapacity5 = sqlCom.Parameters["@Capacity5"].Value == null || sqlCom.Parameters["@Capacity5"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity5"].Value;
                decCapacity6 = sqlCom.Parameters["@Capacity6"].Value == null || sqlCom.Parameters["@Capacity6"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity6"].Value;
                decCapacity7 = sqlCom.Parameters["@Capacity7"].Value == null || sqlCom.Parameters["@Capacity7"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity7"].Value;
                decCapacity8 = sqlCom.Parameters["@Capacity8"].Value == null || sqlCom.Parameters["@Capacity8"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity8"].Value;
                decCapacity9 = sqlCom.Parameters["@Capacity9"].Value == null || sqlCom.Parameters["@Capacity9"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@Capacity9"].Value;

                decR0 = sqlCom.Parameters["@R0"].Value == null || sqlCom.Parameters["@R0"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R0"].Value;
                decR1 = sqlCom.Parameters["@R1"].Value == null || sqlCom.Parameters["@R1"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R1"].Value;
                decR2 = sqlCom.Parameters["@R2"].Value == null || sqlCom.Parameters["@R2"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R2"].Value;
                decR3 = sqlCom.Parameters["@R3"].Value == null || sqlCom.Parameters["@R3"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R3"].Value;
                decR4 = sqlCom.Parameters["@R4"].Value == null || sqlCom.Parameters["@R4"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R4"].Value;
                decR5 = sqlCom.Parameters["@R5"].Value == null || sqlCom.Parameters["@R5"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R5"].Value;
                decR6 = sqlCom.Parameters["@R6"].Value == null || sqlCom.Parameters["@R6"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R6"].Value;
                decR7 = sqlCom.Parameters["@R7"].Value == null || sqlCom.Parameters["@R7"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R7"].Value;
                decR8 = sqlCom.Parameters["@R8"].Value == null || sqlCom.Parameters["@R8"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R8"].Value;
                decR9 = sqlCom.Parameters["@R9"].Value == null || sqlCom.Parameters["@R9"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@R9"].Value;

                decV0 = sqlCom.Parameters["@V0"].Value == null || sqlCom.Parameters["@V0"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V0"].Value;
                decV1 = sqlCom.Parameters["@V1"].Value == null || sqlCom.Parameters["@V1"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V1"].Value;
                decV2 = sqlCom.Parameters["@V2"].Value == null || sqlCom.Parameters["@V2"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V2"].Value;
                decV3 = sqlCom.Parameters["@V3"].Value == null || sqlCom.Parameters["@V3"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V3"].Value;
                decV4 = sqlCom.Parameters["@V4"].Value == null || sqlCom.Parameters["@V4"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V4"].Value;
                decV5 = sqlCom.Parameters["@V5"].Value == null || sqlCom.Parameters["@V5"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V5"].Value;
                decV6 = sqlCom.Parameters["@V6"].Value == null || sqlCom.Parameters["@V6"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V6"].Value;
                decV7 = sqlCom.Parameters["@V7"].Value == null || sqlCom.Parameters["@V7"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V7"].Value;
                decV8 = sqlCom.Parameters["@V8"].Value == null || sqlCom.Parameters["@V8"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V8"].Value;
                decV9 = sqlCom.Parameters["@V9"].Value == null || sqlCom.Parameters["@V9"].Value.Equals(DBNull.Value) ? 0M : (decimal)sqlCom.Parameters["@V9"].Value;

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
        #region 存储检测结果
        public void SaveResult(string sReusltTable,
            string Rt_Bat1Code, decimal Rt_Bat1V,decimal Rt_Bat1Dz,long Rt_Bat1CaoID, short Rt_Bat1NGCase,
            string Rt_Bat2Code, decimal Rt_Bat2V, decimal Rt_Bat2Dz, long Rt_Bat2CaoID, short Rt_Bat2NGCase,
            string Rt_Bat3Code, decimal Rt_Bat3V, decimal Rt_Bat3Dz, long Rt_Bat3CaoID, short Rt_Bat3NGCase,
            string Rt_Bat4Code, decimal Rt_Bat4V, decimal Rt_Bat4Dz, long Rt_Bat4CaoID, short Rt_Bat4NGCase,
            string Rt_Bat5Code, decimal Rt_Bat5V, decimal Rt_Bat5Dz, long Rt_Bat5CaoID, short Rt_Bat5NGCase,
            string Rt_Bat6Code, decimal Rt_Bat6V, decimal Rt_Bat6Dz, long Rt_Bat6CaoID, short Rt_Bat6NGCase,
            string Rt_Bat7Code, decimal Rt_Bat7V, decimal Rt_Bat7Dz, long Rt_Bat7CaoID, short Rt_Bat7NGCase,
            string Rt_Bat8Code, decimal Rt_Bat8V, decimal Rt_Bat8Dz, long Rt_Bat8CaoID, short Rt_Bat8NGCase,
            string Rt_Bat9Code, decimal Rt_Bat9V, decimal Rt_Bat9Dz, long Rt_Bat9CaoID, short Rt_Bat9NGCase,
            string Rt_Bat10Code, decimal Rt_Bat10V, decimal Rt_Bat10Dz, long Rt_Bat10CaoID, short Rt_Bat10NGCase,
            string Rt_Bat11Code, decimal Rt_Bat11V, decimal Rt_Bat11Dz, long Rt_Bat11CaoID, short Rt_Bat11NGCase,
            string Rt_Bat12Code, decimal Rt_Bat12V, decimal Rt_Bat12Dz, long Rt_Bat12CaoID, short Rt_Bat12NGCase,
            string Rt_Bat13Code, decimal Rt_Bat13V, decimal Rt_Bat13Dz, long Rt_Bat13CaoID, short Rt_Bat13NGCase,
            string Rt_Bat14Code, decimal Rt_Bat14V, decimal Rt_Bat14Dz, long Rt_Bat14CaoID, short Rt_Bat14NGCase,
            string Rt_Bat15Code, decimal Rt_Bat15V, decimal Rt_Bat15Dz, long Rt_Bat15CaoID, short Rt_Bat15NGCase,
            string Rt_Bat16Code, decimal Rt_Bat16V, decimal Rt_Bat16Dz, long Rt_Bat16CaoID, short Rt_Bat16NGCase,
            string Rt_Bat17Code, decimal Rt_Bat17V, decimal Rt_Bat17Dz, long Rt_Bat17CaoID, short Rt_Bat17NGCase,
            string Rt_Bat18Code, decimal Rt_Bat18V, decimal Rt_Bat18Dz, long Rt_Bat18CaoID, short Rt_Bat18NGCase,
            string Rt_Bat19Code, decimal Rt_Bat19V, decimal Rt_Bat19Dz, long Rt_Bat19CaoID, short Rt_Bat19NGCase,
            string Rt_Bat20Code, decimal Rt_Bat20V, decimal Rt_Bat20Dz, long Rt_Bat20CaoID, short Rt_Bat20NGCase
            , string sTuoPanCode1, string sTuoPanCode2, string sTuoPanCode3, string sTuoPanCode4, string sTuoPanCode5
            , string sTuoPanCode6, string sTuoPanCode7, string sTuoPanCode8, string sTuoPanCode9, string sTuoPanCode10
            , string sTuoPanCode11, string sTuoPanCode12, string sTuoPanCode13, string sTuoPanCode14, string sTuoPanCode15
            , string sTuoPanCode16, string sTuoPanCode17, string sTuoPanCode18, string sTuoPanCode19, string sTuoPanCode20
            , short iCaoIndex1, short iCaoIndex2, short iCaoIndex3, short iCaoIndex4, short iCaoIndex5
            , short iCaoIndex6, short iCaoIndex7, short iCaoIndex8, short iCaoIndex9, short iCaoIndex10
            , short iCaoIndex11, short iCaoIndex12, short iCaoIndex13, short iCaoIndex14, short iCaoIndex15
            , short iCaoIndex16, short iCaoIndex17, short iCaoIndex18, short iCaoIndex19, short iCaoIndex20
            , short iQuality1, short iQuality2, short iQuality3, short iQuality4, short iQuality5
            , short iQuality6, short iQuality7, short iQuality8, short iQuality9, short iQuality10
            , short iQuality11, short iQuality12, short iQuality13, short iQuality14, short iQuality15
            , short iQuality16, short iQuality17, short iQuality18, short iQuality19, short iQuality20
            , out int iBtyAddCount)
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
                sqlCom.CommandText = "[SaveResult]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@ResultTable";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sReusltTable;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat1Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat1Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat1V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat1V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat1Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat1Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat1CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat1CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat1NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat1NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat2Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat2Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat2V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat2V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat2Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat2Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat2CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat2CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat2NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat2NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat3Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat3Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat3V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat3V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat3Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat3Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat3CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat3CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat3NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat3NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat4Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat4Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat4V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat4V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat4Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat4Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat4CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat4CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat4NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat4NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat5Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat5Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat5V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat5V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat5Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat5Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat5CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat5CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat5NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat5NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat6Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat6Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat6V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat6V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat6Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat6Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat6CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat6CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat6NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat6NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat7Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat7Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat7V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat7V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat7Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat7Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat7CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat7CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat7NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat7NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat8Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat8Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat8V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat8V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat8Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat8Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat8CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat8CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat8NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat8NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat9Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat9Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat9V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat9V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat9Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat9Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat9CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat9CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat9NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat9NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat10Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat10Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat10V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat10V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat10Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat10Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat10CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat10CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat10NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat10NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat11Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat11Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat11V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat11V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat11Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat11Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat11CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat11CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat11NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat11NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat12Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat12Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat12V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat12V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat12Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat12Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat12CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat12CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat12NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat12NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat13Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat13Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat13V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat13V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat13Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat13Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat13CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat13CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat13NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat13NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat14Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat14Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat14V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat14V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat14Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat14Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat14CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat14CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat14NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat14NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat15Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat15Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat15V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat15V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat15Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat15Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat15CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat15CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat15NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat15NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat16Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat16Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat16V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat16V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat16Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat16Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat16CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat16CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat16NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat16NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat17Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat17Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat17V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat17V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat17Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat17Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat17CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat17CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat17NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat17NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat18Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat18Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat18V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat18V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat18Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat18Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat18CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat18CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat18NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat18NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat19Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat19Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat19V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat19V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat19Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat19Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat19CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat19CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat19NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat19NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat20Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = Rt_Bat20Code;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat20V";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat20V;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat20Dz";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Size = 9;
                sqlParam.Value = Rt_Bat20Dz;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat20CaoID";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = Rt_Bat20CaoID;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Rt_Bat20NGCase";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = Rt_Bat20NGCase;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode9;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode10";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode10;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode11";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode11;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode12";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode12;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode13";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode13;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode14";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode14;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode15";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode15;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode16";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode16;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode17";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode17;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode18";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode18;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode19";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode19;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode20";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTuoPanCode20;
                sqlCom.Parameters.Add(sqlParam);


                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex1";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex2";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex3";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex4";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex5";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex6";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex7";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex8";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex9";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex9;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex10";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex10;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex11";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex11;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex12";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex12;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex13";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex13;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex14";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex14;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex15";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex15;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex16";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex16;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex17";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex17;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex18";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex18;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex19";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex19;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@CaoIndex20";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iCaoIndex20;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality1";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality2";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality3";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality4";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality5";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality6";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality7";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality8";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality9";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality9;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality10";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality10;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality11";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality11;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality12";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality12;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality13";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality13;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality14";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality14;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality15";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality15;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality16";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality16;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality17";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality17;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality18";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality18;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality19";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality19;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Quality20";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iQuality20;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@AddBtyCount";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
                if (sqlCom.Parameters["@AddBtyCount"].Value == null || sqlCom.Parameters["@AddBtyCount"].Value.Equals(DBNull.Value))
                    iBtyAddCount = 0;
                else
                    iBtyAddCount = (int)sqlCom.Parameters["@AddBtyCount"].Value;
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
        #region 标识正在测试中
        public void SetTestingState(string sTestCode,short iTestState, out int iReturnValue, out string sMsg)
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
                sqlCom.CommandText = "[SetTestingState]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTestCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestState";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iTestState;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        #region 统计槽中电芯数据
        public void GrooveStatistic(string sTestCode,short iMacNo,
            long lGrooveID1,int iCount1,out string sTuoPanCode1,out int iGrooveBtyCont1,out int iTuoCount1,
            long lGrooveID2, int iCount2, out string sTuoPanCode2, out int iGrooveBtyCont2, out int iTuoCount2,
            long lGrooveID3, int iCount3, out string sTuoPanCode3, out int iGrooveBtyCont3, out int iTuoCount3,
            long lGrooveID4, int iCount4, out string sTuoPanCode4, out int iGrooveBtyCont4, out int iTuoCount4,
            long lGrooveID5, int iCount5, out string sTuoPanCode5, out int iGrooveBtyCont5, out int iTuoCount5,
            long lGrooveID6, int iCount6, out string sTuoPanCode6, out int iGrooveBtyCont6, out int iTuoCount6,
            long lGrooveID7, int iCount7, out string sTuoPanCode7, out int iGrooveBtyCont7, out int iTuoCount7,
            long lGrooveID8, int iCount8, out string sTuoPanCode8, out int iGrooveBtyCont8, out int iTuoCount8,
            long lGrooveID9, int iCount9, out string sTuoPanCode9, out int iGrooveBtyCont9, out int iTuoCount9,
            long lGrooveID10, int iCount10, out string sTuoPanCode10, out int iGrooveBtyCont10, out int iTuoCount10,
            long lGrooveID11, int iCount11, out string sTuoPanCode11, out int iGrooveBtyCont11, out int iTuoCount11,
            long lGrooveID12, int iCount12, out string sTuoPanCode12, out int iGrooveBtyCont12, out int iTuoCount12,
            long lGrooveID13, int iCount13, out string sTuoPanCode13, out int iGrooveBtyCont13, out int iTuoCount13,
            long lGrooveID14, int iCount14, out string sTuoPanCode14, out int iGrooveBtyCont14, out int iTuoCount14,
            long lGrooveID15, int iCount15, out string sTuoPanCode15, out int iGrooveBtyCont15, out int iTuoCount15,
            long lGrooveID16, int iCount16, out string sTuoPanCode16, out int iGrooveBtyCont16, out int iTuoCount16,
            long lGrooveID17, int iCount17, out string sTuoPanCode17, out int iGrooveBtyCont17, out int iTuoCount17,
            long lGrooveID18, int iCount18, out string sTuoPanCode18, out int iGrooveBtyCont18, out int iTuoCount18
            ,out int iTuoPanAddCnt,out bool blTuoPlanCompeleted,out int iTuoPlanFinished)
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
                sqlCom.CommandText = "[GrooveStatistic]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sTestCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MacNo";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iMacNo;
                sqlCom.Parameters.Add(sqlParam);
                //第1个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID1";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count1";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont1";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount1";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第2个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID2";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count2";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount2;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont2";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount2";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第1个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID3";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count3";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount3;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont3";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount3";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第4个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID4";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count4";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount4;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont4";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount4";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第5个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID5";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count5";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount5;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont5";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount5";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第6个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID6";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count6";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount6;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont6";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount6";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第7个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID7";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count7";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount7;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont7";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount7";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第8个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID8";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count8";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount8;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont8";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount8";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第9个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID9";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID9;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count9";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount9;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont9";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount9";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第10个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID10";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID10;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count10";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount10;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode10";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont10";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount10";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第11个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID11";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID11;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count11";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount11;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode11";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont11";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount11";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第12个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID12";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID12;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count12";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount12;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode12";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont12";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount12";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第13个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID13";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID13;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count13";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount13;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode13";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont13";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount13";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第14个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID14";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID14;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count14";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount14;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode14";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont14";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount14";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第15个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID15";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID15;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count15";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount15;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode15";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont15";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount15";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第16个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID16";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID16;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count16";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount16;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode16";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont16";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount16";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第17个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID17";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID17;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count17";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount17;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode17";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont17";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount17";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                //第18个槽
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveID18";
                sqlParam.SqlDbType = SqlDbType.BigInt;
                sqlParam.Size = 8;
                sqlParam.Value = lGrooveID18;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Count18";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iCount18;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanCode18";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@GrooveBtyCont18";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoCount18";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPanAddCnt";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TuoPlanCompeleted";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@PlanFinishedTuoCnt";
                sqlParam.Direction = ParameterDirection.Output;
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlCom.Parameters.Add(sqlParam);

                sqlCom.ExecuteNonQuery();
                sqlTrain.Commit();
                //第1个槽
                if (sqlCom.Parameters["@GrooveBtyCont1"].Value == null || sqlCom.Parameters["@GrooveBtyCont1"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont1 = 0;
                else
                    iGrooveBtyCont1 = (int)sqlCom.Parameters["@GrooveBtyCont1"].Value;
                if (sqlCom.Parameters["@TuoCount1"].Value == null || sqlCom.Parameters["@TuoCount1"].Value.Equals(DBNull.Value))
                    iTuoCount1 = 0;
                else
                    iTuoCount1 = (int)sqlCom.Parameters["@TuoCount1"].Value;
                sTuoPanCode1 = sqlCom.Parameters["@TuoPanCode1"].Value != null ? sqlCom.Parameters["@TuoPanCode1"].Value.ToString() : string.Empty;
                //第2个槽
                if (sqlCom.Parameters["@GrooveBtyCont2"].Value == null || sqlCom.Parameters["@GrooveBtyCont2"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont2 = 0;
                else
                    iGrooveBtyCont2 = (int)sqlCom.Parameters["@GrooveBtyCont2"].Value;
                if (sqlCom.Parameters["@TuoCount2"].Value == null || sqlCom.Parameters["@TuoCount2"].Value.Equals(DBNull.Value))
                    iTuoCount2 = 0;
                else
                    iTuoCount2 = (int)sqlCom.Parameters["@TuoCount2"].Value;
                sTuoPanCode2 = sqlCom.Parameters["@TuoPanCode2"].Value != null ? sqlCom.Parameters["@TuoPanCode2"].Value.ToString() : string.Empty;
                //第3个槽
                if (sqlCom.Parameters["@GrooveBtyCont3"].Value == null || sqlCom.Parameters["@GrooveBtyCont3"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont3 = 0;
                else
                    iGrooveBtyCont3 = (int)sqlCom.Parameters["@GrooveBtyCont3"].Value;
                if (sqlCom.Parameters["@TuoCount3"].Value == null || sqlCom.Parameters["@TuoCount3"].Value.Equals(DBNull.Value))
                    iTuoCount3 = 0;
                else
                    iTuoCount3 = (int)sqlCom.Parameters["@TuoCount3"].Value;
                sTuoPanCode3 = sqlCom.Parameters["@TuoPanCode3"].Value != null ? sqlCom.Parameters["@TuoPanCode3"].Value.ToString() : string.Empty;
                //第4个槽
                if (sqlCom.Parameters["@GrooveBtyCont4"].Value == null || sqlCom.Parameters["@GrooveBtyCont4"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont4 = 0;
                else
                    iGrooveBtyCont4 = (int)sqlCom.Parameters["@GrooveBtyCont4"].Value;
                if (sqlCom.Parameters["@TuoCount4"].Value == null || sqlCom.Parameters["@TuoCount4"].Value.Equals(DBNull.Value))
                    iTuoCount4 = 0;
                else
                    iTuoCount4 = (int)sqlCom.Parameters["@TuoCount4"].Value;
                sTuoPanCode4 = sqlCom.Parameters["@TuoPanCode4"].Value != null ? sqlCom.Parameters["@TuoPanCode4"].Value.ToString() : string.Empty;
                //第5个槽
                if (sqlCom.Parameters["@GrooveBtyCont5"].Value == null || sqlCom.Parameters["@GrooveBtyCont5"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont5 = 0;
                else
                    iGrooveBtyCont5 = (int)sqlCom.Parameters["@GrooveBtyCont5"].Value;
                if (sqlCom.Parameters["@TuoCount5"].Value == null || sqlCom.Parameters["@TuoCount5"].Value.Equals(DBNull.Value))
                    iTuoCount5 = 0;
                else
                    iTuoCount5 = (int)sqlCom.Parameters["@TuoCount5"].Value;
                sTuoPanCode5 = sqlCom.Parameters["@TuoPanCode5"].Value != null ? sqlCom.Parameters["@TuoPanCode5"].Value.ToString() : string.Empty;
                //第6个槽
                if (sqlCom.Parameters["@GrooveBtyCont6"].Value == null || sqlCom.Parameters["@GrooveBtyCont6"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont6 = 0;
                else
                    iGrooveBtyCont6 = (int)sqlCom.Parameters["@GrooveBtyCont6"].Value;
                if (sqlCom.Parameters["@TuoCount6"].Value == null || sqlCom.Parameters["@TuoCount6"].Value.Equals(DBNull.Value))
                    iTuoCount6 = 0;
                else
                    iTuoCount6 = (int)sqlCom.Parameters["@TuoCount6"].Value;
                sTuoPanCode6 = sqlCom.Parameters["@TuoPanCode6"].Value != null ? sqlCom.Parameters["@TuoPanCode6"].Value.ToString() : string.Empty;
                //第7个槽
                if (sqlCom.Parameters["@GrooveBtyCont7"].Value == null || sqlCom.Parameters["@GrooveBtyCont7"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont7 = 0;
                else
                    iGrooveBtyCont7 = (int)sqlCom.Parameters["@GrooveBtyCont7"].Value;
                if (sqlCom.Parameters["@TuoCount7"].Value == null || sqlCom.Parameters["@TuoCount7"].Value.Equals(DBNull.Value))
                    iTuoCount7 = 0;
                else
                    iTuoCount7 = (int)sqlCom.Parameters["@TuoCount7"].Value;
                sTuoPanCode7 = sqlCom.Parameters["@TuoPanCode7"].Value != null ? sqlCom.Parameters["@TuoPanCode7"].Value.ToString() : string.Empty;
                //第8个槽
                if (sqlCom.Parameters["@GrooveBtyCont8"].Value == null || sqlCom.Parameters["@GrooveBtyCont8"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont8 = 0;
                else
                    iGrooveBtyCont8 = (int)sqlCom.Parameters["@GrooveBtyCont8"].Value;
                if (sqlCom.Parameters["@TuoCount8"].Value == null || sqlCom.Parameters["@TuoCount8"].Value.Equals(DBNull.Value))
                    iTuoCount8 = 0;
                else
                    iTuoCount8 = (int)sqlCom.Parameters["@TuoCount8"].Value;
                sTuoPanCode8 = sqlCom.Parameters["@TuoPanCode8"].Value != null ? sqlCom.Parameters["@TuoPanCode8"].Value.ToString() : string.Empty;
                //第9个槽
                if (sqlCom.Parameters["@GrooveBtyCont9"].Value == null || sqlCom.Parameters["@GrooveBtyCont9"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont9 = 0;
                else
                    iGrooveBtyCont9 = (int)sqlCom.Parameters["@GrooveBtyCont9"].Value;
                if (sqlCom.Parameters["@TuoCount9"].Value == null || sqlCom.Parameters["@TuoCount9"].Value.Equals(DBNull.Value))
                    iTuoCount9 = 0;
                else
                    iTuoCount9 = (int)sqlCom.Parameters["@TuoCount9"].Value;
                sTuoPanCode9 = sqlCom.Parameters["@TuoPanCode9"].Value != null ? sqlCom.Parameters["@TuoPanCode9"].Value.ToString() : string.Empty;
                //第10个槽
                if (sqlCom.Parameters["@GrooveBtyCont10"].Value == null || sqlCom.Parameters["@GrooveBtyCont10"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont10 = 0;
                else
                    iGrooveBtyCont10 = (int)sqlCom.Parameters["@GrooveBtyCont10"].Value;
                if (sqlCom.Parameters["@TuoCount10"].Value == null || sqlCom.Parameters["@TuoCount10"].Value.Equals(DBNull.Value))
                    iTuoCount10 = 0;
                else
                    iTuoCount10 = (int)sqlCom.Parameters["@TuoCount10"].Value;
                sTuoPanCode10 = sqlCom.Parameters["@TuoPanCode10"].Value != null ? sqlCom.Parameters["@TuoPanCode10"].Value.ToString() : string.Empty;
                //第11个槽
                if (sqlCom.Parameters["@GrooveBtyCont11"].Value == null || sqlCom.Parameters["@GrooveBtyCont11"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont11 = 0;
                else
                    iGrooveBtyCont11 = (int)sqlCom.Parameters["@GrooveBtyCont11"].Value;
                if (sqlCom.Parameters["@TuoCount11"].Value == null || sqlCom.Parameters["@TuoCount11"].Value.Equals(DBNull.Value))
                    iTuoCount11 = 0;
                else
                    iTuoCount11 = (int)sqlCom.Parameters["@TuoCount11"].Value;
                sTuoPanCode11 = sqlCom.Parameters["@TuoPanCode11"].Value != null ? sqlCom.Parameters["@TuoPanCode11"].Value.ToString() : string.Empty;
                //第12个槽
                if (sqlCom.Parameters["@GrooveBtyCont12"].Value == null || sqlCom.Parameters["@GrooveBtyCont12"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont12 = 0;
                else
                    iGrooveBtyCont12 = (int)sqlCom.Parameters["@GrooveBtyCont12"].Value;
                if (sqlCom.Parameters["@TuoCount12"].Value == null || sqlCom.Parameters["@TuoCount12"].Value.Equals(DBNull.Value))
                    iTuoCount12 = 0;
                else
                    iTuoCount12 = (int)sqlCom.Parameters["@TuoCount12"].Value;
                sTuoPanCode12 = sqlCom.Parameters["@TuoPanCode12"].Value != null ? sqlCom.Parameters["@TuoPanCode12"].Value.ToString() : string.Empty;
                //第13个槽
                if (sqlCom.Parameters["@GrooveBtyCont13"].Value == null || sqlCom.Parameters["@GrooveBtyCont13"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont13 = 0;
                else
                    iGrooveBtyCont13 = (int)sqlCom.Parameters["@GrooveBtyCont13"].Value;
                if (sqlCom.Parameters["@TuoCount13"].Value == null || sqlCom.Parameters["@TuoCount13"].Value.Equals(DBNull.Value))
                    iTuoCount13 = 0;
                else
                    iTuoCount13 = (int)sqlCom.Parameters["@TuoCount13"].Value;
                sTuoPanCode13 = sqlCom.Parameters["@TuoPanCode13"].Value != null ? sqlCom.Parameters["@TuoPanCode13"].Value.ToString() : string.Empty;
                //第14个槽
                if (sqlCom.Parameters["@GrooveBtyCont14"].Value == null || sqlCom.Parameters["@GrooveBtyCont14"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont14 = 0;
                else
                    iGrooveBtyCont14 = (int)sqlCom.Parameters["@GrooveBtyCont14"].Value;
                if (sqlCom.Parameters["@TuoCount14"].Value == null || sqlCom.Parameters["@TuoCount14"].Value.Equals(DBNull.Value))
                    iTuoCount14 = 0;
                else
                    iTuoCount14 = (int)sqlCom.Parameters["@TuoCount14"].Value;
                sTuoPanCode14 = sqlCom.Parameters["@TuoPanCode14"].Value != null ? sqlCom.Parameters["@TuoPanCode14"].Value.ToString() : string.Empty;
                //第15个槽
                if (sqlCom.Parameters["@GrooveBtyCont15"].Value == null || sqlCom.Parameters["@GrooveBtyCont15"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont15 = 0;
                else
                    iGrooveBtyCont15 = (int)sqlCom.Parameters["@GrooveBtyCont15"].Value;
                if (sqlCom.Parameters["@TuoCount15"].Value == null || sqlCom.Parameters["@TuoCount15"].Value.Equals(DBNull.Value))
                    iTuoCount15 = 0;
                else
                    iTuoCount15 = (int)sqlCom.Parameters["@TuoCount15"].Value;
                sTuoPanCode15 = sqlCom.Parameters["@TuoPanCode15"].Value != null ? sqlCom.Parameters["@TuoPanCode15"].Value.ToString() : string.Empty;
                //第16个槽
                if (sqlCom.Parameters["@GrooveBtyCont16"].Value == null || sqlCom.Parameters["@GrooveBtyCont16"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont16 = 0;
                else
                    iGrooveBtyCont16 = (int)sqlCom.Parameters["@GrooveBtyCont16"].Value;
                if (sqlCom.Parameters["@TuoCount16"].Value == null || sqlCom.Parameters["@TuoCount16"].Value.Equals(DBNull.Value))
                    iTuoCount16 = 0;
                else
                    iTuoCount16 = (int)sqlCom.Parameters["@TuoCount16"].Value;
                sTuoPanCode16 = sqlCom.Parameters["@TuoPanCode16"].Value != null ? sqlCom.Parameters["@TuoPanCode16"].Value.ToString() : string.Empty;
                //第17个槽
                if (sqlCom.Parameters["@GrooveBtyCont17"].Value == null || sqlCom.Parameters["@GrooveBtyCont17"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont17 = 0;
                else
                    iGrooveBtyCont17 = (int)sqlCom.Parameters["@GrooveBtyCont17"].Value;
                if (sqlCom.Parameters["@TuoCount17"].Value == null || sqlCom.Parameters["@TuoCount17"].Value.Equals(DBNull.Value))
                    iTuoCount17 = 0;
                else
                    iTuoCount17 = (int)sqlCom.Parameters["@TuoCount17"].Value;
                sTuoPanCode17 = sqlCom.Parameters["@TuoPanCode17"].Value != null ? sqlCom.Parameters["@TuoPanCode17"].Value.ToString() : string.Empty;
                //第18个槽
                if (sqlCom.Parameters["@GrooveBtyCont18"].Value == null || sqlCom.Parameters["@GrooveBtyCont18"].Value.Equals(DBNull.Value))
                    iGrooveBtyCont18 = 0;
                else
                    iGrooveBtyCont18 = (int)sqlCom.Parameters["@GrooveBtyCont18"].Value;
                if (sqlCom.Parameters["@TuoCount18"].Value == null || sqlCom.Parameters["@TuoCount18"].Value.Equals(DBNull.Value))
                    iTuoCount18 = 0;
                else
                    iTuoCount18 = (int)sqlCom.Parameters["@TuoCount18"].Value;
                sTuoPanCode18 = sqlCom.Parameters["@TuoPanCode18"].Value != null ? sqlCom.Parameters["@TuoPanCode18"].Value.ToString() : string.Empty;
                //新增的托盘数量
                if (sqlCom.Parameters["@TuoPanAddCnt"].Value == null || sqlCom.Parameters["@TuoPanAddCnt"].Value.Equals(DBNull.Value))
                    iTuoPanAddCnt = 0;
                else
                    iTuoPanAddCnt = (int)sqlCom.Parameters["@TuoPanAddCnt"].Value;

                if (sqlCom.Parameters["@TuoPlanCompeleted"].Value == null || sqlCom.Parameters["@TuoPlanCompeleted"].Value.Equals(DBNull.Value))
                    blTuoPlanCompeleted = false;
                else
                    blTuoPlanCompeleted = (bool)sqlCom.Parameters["@TuoPlanCompeleted"].Value;

                if (sqlCom.Parameters["@PlanFinishedTuoCnt"].Value == null || sqlCom.Parameters["@PlanFinishedTuoCnt"].Value.Equals(DBNull.Value))
                    iTuoPlanFinished = 0;
                else
                    iTuoPlanFinished = (int)sqlCom.Parameters["@PlanFinishedTuoCnt"].Value;
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
        public void TestDelete(string sCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[DeleteTest]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode;
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
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        public void CompeletedTest(string sCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[CompeletedTest]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode;
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
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        public void StartTesting(DataTable dtSource,out string sRealTableBatterys,out string sRealTableResult, out int iReturnValue, out string sMsg)
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
                DataRow dr = dtSource.DefaultView[0].Row;
                if (dr.RowState == DataRowState.Added)
                {
                    #region insert基本资料
                    strSql = @"INSERT INTO Testing_Main (Code,Operator,OperatorName,ModeIsNeter,ModeIsScaner,ProductSpec,MbatchNum,MbatchNumCheckOn,SNContainCheckOn,GongYiType,ProcessCode,MacCode,StartTime,EndTime,State,BatterysTable,ResultTable,OrderNo,PeiFangName,TargetMKCnt,CharCheckOn,PactCode,AutoMKOn,Capacity,Capacity1) 
                SELECT @Code,@Operator,@OperatorName,@ModeIsNeter,@ModeIsScaner,@ProductSpec,@MbatchNum,@MbatchNumCheckOn,@SNContainCheckOn,@GongYiType,@ProcessCode,@MacCode,@StartTime,@EndTime,@State,@BatterysTable,@ResultTable,@OrderNo,@PeiFangName,@TargetMKCnt,@CharCheckOn,@PactCode,@AutoMKOn,@Capacity,@Capacity1";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Operator";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["Operator"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OperatorName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["OperatorName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModeIsNeter";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["ModeIsNeter"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModeIsScaner";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["ModeIsScaner"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProductSpec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["ProductSpec"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MbatchNum";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["MbatchNum"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MbatchNumCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["MbatchNumCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SNContainCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["SNContainCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@GongYiType";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["GongYiType"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProcessCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["ProcessCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MacCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["MacCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@StartTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["StartTime"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@EndTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["EndTime"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@State";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["State"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@BatterysTable";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["BatterysTable"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ResultTable";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["ResultTable"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrderNo";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["OrderNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@PeiFangName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["PeiFangName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@TargetMKCnt";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["TargetMKCnt"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CharCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["CharCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@PactCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["PactCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@AutoMKOn";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["AutoMKOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Capacity";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Capacity"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Capacity1";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Capacity1"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    #region update基本资料
                    strSql = @"UPDATE Testing_Main SET Code=@Code,Operator=@Operator,OperatorName=@OperatorName,ModeIsNeter=@ModeIsNeter,ModeIsScaner=@ModeIsScaner,ProductSpec=@ProductSpec,MbatchNum=@MbatchNum,MbatchNumCheckOn=@MbatchNumCheckOn,SNContainCheckOn=@SNContainCheckOn,GongYiType=@GongYiType,ProcessCode=@ProcessCode,MacCode=@MacCode,StartTime=@StartTime,EndTime=@EndTime,State=@State,BatterysTable=@BatterysTable,ResultTable=@ResultTable,OrderNo=@OrderNo,PeiFangName=@PeiFangName,TargetMKCnt=@TargetMKCnt,CharCheckOn=@CharCheckOn,PactCode=@PactCode,AutoMKOn=@AutoMKOn,Capacity=@Capacity,Capacity1=@Capacity1 WHERE Code=@OriginalCode";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Operator";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["Operator"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OperatorName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["OperatorName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModeIsNeter";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["ModeIsNeter"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ModeIsScaner";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["ModeIsScaner"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProductSpec";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["ProductSpec"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MbatchNum";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["MbatchNum"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MbatchNumCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["MbatchNumCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@SNContainCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["SNContainCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@GongYiType";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["GongYiType"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ProcessCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["ProcessCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@MacCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 10;
                    sqlParam.Value = dr["MacCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@StartTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["StartTime"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@EndTime";
                    sqlParam.SqlDbType = SqlDbType.DateTime;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["EndTime"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@State";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["State"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@BatterysTable";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["BatterysTable"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@ResultTable";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 100;
                    sqlParam.Value = dr["ResultTable"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OrderNo";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["OrderNo"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@PeiFangName";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = dr["PeiFangName"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@TargetMKCnt";
                    sqlParam.SqlDbType = SqlDbType.Int;
                    sqlParam.Size = 4;
                    sqlParam.Value = dr["TargetMKCnt"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@CharCheckOn";
                    sqlParam.SqlDbType = SqlDbType.Bit;
                    sqlParam.Size = 1;
                    sqlParam.Value = dr["CharCheckOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@PactCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["PactCode"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@AutoMKOn";
                    sqlParam.SqlDbType = SqlDbType.SmallInt;
                    sqlParam.Size = 2;
                    sqlParam.Value = dr["AutoMKOn"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Capacity";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Capacity"];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Capacity1";
                    sqlParam.SqlDbType = SqlDbType.Decimal;
                    sqlParam.Size = 8;
                    sqlParam.Value = dr["Capacity1"];
                    sqlCom.Parameters.Add(sqlParam);

                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@OriginalCode";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 30;
                    sqlParam.Value = dr["Code", DataRowVersion.Original];
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                    #endregion
                }
                //执行存储过程
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[TestDataSaveCompeleted]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MacNo";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = JPSConfig.MacNo;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = dtSource.DefaultView[0].Row["Code"].ToString();
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@RealTableBatterys";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@RealTableResult";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Direction = ParameterDirection.Output;
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
                sRealTableBatterys = sqlCom.Parameters["@RealTableBatterys"].Value != null ? sqlCom.Parameters["@RealTableBatterys"].Value.ToString() : string.Empty;
                sRealTableResult = sqlCom.Parameters["@RealTableResult"].Value != null ? sqlCom.Parameters["@RealTableResult"].Value.ToString() : string.Empty;
                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
                
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
        public static void SaveScanner1Log(string sLog)
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
                strSql = @"INSERT INTO LuoLiuAssignerLog.dbo.Scanner1Log (MyLog,times) values(@MyLog,getdate())";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyLog";
                sqlParam.SqlDbType = SqlDbType.Text;
                sqlParam.Value = sLog;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
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
        public static void SaveScanner2Log(string sLog)
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
                strSql = @"INSERT INTO LuoLiuAssignerLog.dbo.Scanner2Log (MyLog,times) values(@MyLog,getdate())";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyLog";
                sqlParam.SqlDbType = SqlDbType.Text;
                sqlParam.Value = sLog;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
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
        public static void SaveResultLog(string sLog)
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
                strSql = @"INSERT INTO LuoLiuAssignerLog.dbo.ResultLog (MyLog,times) values(@MyLog,getdate())";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyLog";
                sqlParam.SqlDbType = SqlDbType.Text;
                sqlParam.Value = sLog;
                sqlCom.Parameters.Add(sqlParam);
                sqlCom.ExecuteNonQuery();
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
        public void ExpFuns_SetTuopanCode(string sMacNo,string sCode1,int iMax, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[ExpFuns_SetTuopanCode]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MacNo";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 1;
                sqlParam.Value = sMacNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MaxCode";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iMax;
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
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        public void ExpFuns_SetTuopanCode4(string sMacNo, string sCode1, int iMax, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[ExpFuns_SetTuopanCode_4]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MacNo";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 1;
                sqlParam.Value = sMacNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Code";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode1;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MaxCode";
                sqlParam.SqlDbType = SqlDbType.Int;
                sqlParam.Size = 4;
                sqlParam.Value = iMax;
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
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        #region 仅4号机的功能
        public void DaoruSnDetails(DataTable dtBattery,DataTable dtResult,string sTestCode,string sBatteryTableName,string sResultTableName)
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

                if (dtBattery != null)
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = dtBattery.Select("", "", DataViewRowState.Added);
                    strSql = "INSERT INTO " + sBatteryTableName + " (Code,SN,ScannerNo,SortID,IsNG,IsSNChonghao,IsMBatchNumOK,Times) SELECT @Code,@SN,@ScannerNo,@SortID,@IsNG,@IsSNChonghao,@IsMBatchNumOK,@Times";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 12;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SN";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["SN"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ScannerNo";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["ScannerNo"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsNG";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["IsNG"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsSNChonghao";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["IsSNChonghao"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsMBatchNumOK";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dr["IsMBatchNumOK"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Times";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["Times"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                }
                if (dtResult != null)
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = dtResult.Select("", "", DataViewRowState.Added);
                    strSql = "INSERT INTO " + sResultTableName + " (MyCode,GrooveID,V,DianZu,TuoCode,NGCase,CaoIndex,Quality,Times,TestIndex) SELECT @MyCode, @GrooveID, @V, @DianZu, @TuoCode, @NGCase, @CaoIndex, @Quality, @Times, @TestIndex";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MyCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 12;
                        sqlParam.Value = dr["MyCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@GrooveID";
                        sqlParam.SqlDbType = SqlDbType.BigInt;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["GrooveID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@V";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["V"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZu";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZu"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["TuoCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@NGCase";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["NGCase"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CaoIndex";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["CaoIndex"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Quality";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["Quality"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Times";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["Times"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TestIndex";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["TestIndex"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                }
                //更新主表数据
                strSql = string.Format("UPDATE Testing_Grooves SET GrooveBtyCont=ISNULL(GrooveBtyCont,0)+{0} WHERE Code='{1}' and GrooveNo=1 "
                    , dtResult.DefaultView.Count, sTestCode);
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlCom.ExecuteNonQuery();
                
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
        #region 电芯上传至MES

        #endregion
        #region 自动插装系统
        public void Assemble_SaveDianXin(string sCode,short iMacNo,bool isFinished,bool blFirstSaveDx,string[] sMyCodes,out string sMkCode,out short iAsbCnt,out bool blPlanComeleted,out short iFinishedMKCnt, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[Assemble_SaveDianXin]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@TestCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sCode;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MacNo";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Value = iMacNo;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Finished";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = isFinished;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@IsFirstSave";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Value = blFirstSaveDx;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode1";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[0];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode2";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[1];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode3";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[2];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode4";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[3];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode5";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[4];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode6";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[5];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode7";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[6];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode8";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[7];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode9";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[8];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode10";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[9];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode11";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[10];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode12";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[11];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode13";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[12];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode14";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[13];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode15";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[14];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode16";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[15];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode17";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[16];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode18";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[17];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode19";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[18];
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MyCode20";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 12;
                sqlParam.Value = sMyCodes[19];
                sqlCom.Parameters.Add(sqlParam);


                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MKCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 15;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@AsbCnt";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MKCompeleted";
                sqlParam.SqlDbType = SqlDbType.Bit;
                sqlParam.Size = 1;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@FinishedMKCnt";
                sqlParam.SqlDbType = SqlDbType.SmallInt;
                sqlParam.Size = 2;
                sqlParam.Direction = ParameterDirection.Output;
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
                sMkCode = sqlCom.Parameters["@MKCode"].Value != null ? sqlCom.Parameters["@MKCode"].Value.ToString() : string.Empty;
                if (sqlCom.Parameters["@AsbCnt"].Value == null || sqlCom.Parameters["@AsbCnt"].Value.Equals(DBNull.Value))
                    iAsbCnt = 0;
                else
                    iAsbCnt = (short)sqlCom.Parameters["@AsbCnt"].Value;
                if (sqlCom.Parameters["@MKCompeleted"].Value == null || sqlCom.Parameters["@MKCompeleted"].Value.Equals(DBNull.Value))
                    blPlanComeleted = false;
                else
                    blPlanComeleted = (bool)sqlCom.Parameters["@MKCompeleted"].Value;

                if (sqlCom.Parameters["@FinishedMKCnt"].Value == null || sqlCom.Parameters["@FinishedMKCnt"].Value.Equals(DBNull.Value))
                    iFinishedMKCnt = 0;
                else
                    iFinishedMKCnt = (short)sqlCom.Parameters["@FinishedMKCnt"].Value;

                if (sqlCom.Parameters["@ReturnValue"].Value == null || sqlCom.Parameters["@ReturnValue"].Value.Equals(DBNull.Value))
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        public void Assemble_ClearRealMKData(out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[MK_ClearRealMKData]";
                
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
        public void MKDelete(string sMKCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
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
                sqlCom.CommandText = "[Assemble_DeleteMK]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@MKCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sMKCode;
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
                sqlParam.Size = 50;
                sqlParam.Value = Common.CurrentUserInfo.UserCode;
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
                    iReturnValue = -1;
                else
                    iReturnValue = (int)sqlCom.Parameters["@ReturnValue"].Value;
                sMsg = sqlCom.Parameters["@ErrMsg"].Value != null ? sqlCom.Parameters["@ErrMsg"].Value.ToString() : string.Empty;
                if (iReturnValue == 1)
                    sqlTrain.Commit();
                else sqlTrain.Rollback();
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
