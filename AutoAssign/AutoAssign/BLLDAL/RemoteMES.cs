using ErrorService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoAssign.BLLDAL
{
    public class RemoteMES
    {
        public static void Save2Mes(DataSet ds)
        {
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            string strSql;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnStringRemoteMES);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                if (ds.Tables.Contains("Produce_Assign_TuoPan"))
                {
                    DataTable dt = ds.Tables["Produce_Assign_TuoPan"];
                    DataRow dr = dt.DefaultView[0].Row;
                    if (dr.RowState == DataRowState.Added)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO Produce_Assign_TuoPan (TuoPan,Operator,StationCode,MacCode,PlanGuid,FinishedTime,Times,StMinR,StMaxR,StMinV,StMaxV,Capacity,Capacity1) 
                SELECT @TuoPan,@Operator,@StationCode,@MacCode,@PlanGuid,@FinishedTime,getdate(),@StMinR,@StMaxR,@StMinV,@StMaxV,@Capacity,@Capacity1";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoPan";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["TuoPan"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Operator";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["Operator"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StationCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 5;
                        sqlParam.Value = dr["StationCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MacCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 5;
                        sqlParam.Value = dr["MacCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PlanGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["PlanGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FinishedTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["FinishedTime"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMinR";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMinR"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMaxR";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMaxR"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMinV";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMinV"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMaxV";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMaxV"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Capacity";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Capacity"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Capacity1";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Capacity1"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        #region update基本资料
                        strSql = @"UPDATE Produce_Assign_TuoPan SET Operator=@Operator,StationCode=@StationCode,MacCode=@MacCode,PlanGuid=@PlanGuid,FinishedTime=@FinishedTime,Times=@Times,StMinR=@StMinR,StMaxR=@StMaxR,StMinV=@StMinV,StMaxV=@StMaxV,Capacity=@Capacity,Capacity1=@Capacity1 WHERE TuoPan=@TuoPan";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Operator";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 10;
                        sqlParam.Value = dr["Operator"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StationCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 5;
                        sqlParam.Value = dr["StationCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MacCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 5;
                        sqlParam.Value = dr["MacCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@PlanGuid";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["PlanGuid"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@FinishedTime";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["FinishedTime"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Times";
                        sqlParam.SqlDbType = SqlDbType.DateTime;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["Times"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMinR";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMinR"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMaxR";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMaxR"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMinV";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMinV"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@StMaxV";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["StMaxV"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Capacity";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Capacity"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Capacity1";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["Capacity1"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoPan";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["TuoPan", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }
                if (ds.Tables.Contains("Produce_Assign_Dx"))
                {
                    #region 保存明细
                    DataRow[] drs;
                    #region 新增数据
                    drs = ds.Tables["Produce_Assign_Dx"].Select("", "", DataViewRowState.Added);
                    strSql = @"INSERT INTO Produce_Assign_Dx (TuoPan,DxSn,DianZu,V) 
                    SELECT @TuoPan,@DxSn,@DianZu,@V";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoPan";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["TuoPan"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DxSn";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["DxSn"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZu";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZu"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@V";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["V"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["Produce_Assign_Dx"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE Produce_Assign_Dx SET TuoPan=@TuoPan,DxSn=@DxSn,DianZu=@DianZu,V=@V WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@TuoPan";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["TuoPan"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DxSn";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["DxSn"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@DianZu";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["DianZu"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@V";
                        sqlParam.SqlDbType = SqlDbType.Decimal;
                        sqlParam.Size = 9;
                        sqlParam.Value = dr["V"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.BigInt;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ID"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["Produce_Assign_Dx"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM Produce_Assign_Dx WHERE ID=@ID";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ID";
                        sqlParam.SqlDbType = SqlDbType.BigInt;
                        sqlParam.Size = 8;
                        sqlParam.Value = dr["ID", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
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
    }
}
