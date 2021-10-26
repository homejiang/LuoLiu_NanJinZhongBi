using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorService;

namespace ConsoleTestr
{
    public class Class1
    {
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
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@Capacity9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@R9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V0";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V1";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V2";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V3";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V4";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                ////sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V5";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                ////sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V6";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                ////sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V7";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                ////sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V8";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                //sqlParam.Size = 8;
                sqlParam.Scale = 6;
                sqlParam.Direction = ParameterDirection.Output;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@V9";
                sqlParam.SqlDbType = SqlDbType.Decimal;
                sqlParam.Scale = 6;
                //sqlParam.Size = 8;
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
    }
}
