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
    public class BasicData
    {
        #region 删除用户
        public void UserDelete(string sDelCode, out int iReturnValue, out string sMsg)
        {
            iReturnValue = -1;
            sMsg = string.Empty;
            SqlCommand sqlCom;
            SqlConnection sqlConn = null;
            SqlParameter sqlParam;
            SqlTransaction sqlTrain = null;
            if (Common.CommonDAL.DBConnStringBasic == string.Empty)
            {
                Common.CommonDAL.ExceptionIsEmpty ex = new Common.CommonDAL.ExceptionIsEmpty();
                ErrorLog.WriteErrorLog(ex);
                throw (ex);
            }
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnStringBasic);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                sqlCom = new SqlCommand();
                sqlCom.Connection = sqlConn;
                sqlCom.Transaction = sqlTrain;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "[User_Delete]";

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@DelCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
                sqlParam.Value = sDelCode;
                sqlCom.Parameters.Add(sqlParam);

                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UserCode";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 30;
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
