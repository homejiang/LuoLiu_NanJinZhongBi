using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using ErrorService;

namespace BasicData.BLLDAL
{
    public class Client:Common.MyInterface.IDataDAL
    {
        /// <summary>
        /// 获取某一客户的联系人
        /// </summary>
        /// <param name="strClient"></param>
        /// <returns></returns>
        public static List<BasicData.BLLDAL.Client.ContacterEntity> GetClientContacters(string strClient)
        {
            DataTable dt = null;
            List<BasicData.BLLDAL.Client.ContacterEntity> listReturn = new List<BasicData.BLLDAL.Client.ContacterEntity>();
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_JC_ClientContacters  WHERE ClientCode='{0}' ORDER BY SortID", strClient.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            BasicData.BLLDAL.Client.ContacterEntity con;
            dt.DefaultView.Sort = "SortID ASC";
            foreach (DataRowView drv in dt.DefaultView)
            {
                con = new BasicData.BLLDAL.Client.ContacterEntity();
                con.SortID = int.Parse(drv.Row["SortID"].ToString());
                con.Code = drv.Row["ContacterCode"].ToString();
                con.CNName = drv.Row["ContactCNName"].ToString();
                con.ENName = drv.Row["ContactENName"].ToString();
                con.Postion = drv.Row["Postion"].ToString();
                con.Sex = drv.Row["Sex"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["Sex"].ToString());
                con.Tels = drv.Row["ContactTels"].ToString();
                con.MobileTels = drv.Row["MobileTels"].ToString();
                con.Emails = drv.Row["Emails"].ToString();
                con.Faxs = drv.Row["ContactFaxs"].ToString();
                con.SexView = drv.Row["SexView"].ToString();
                con.Remark = drv.Row["Remark"].ToString();
                listReturn.Add(con);
            }
            return listReturn;

        }
      
        #region 客户联系人实体类
        public class ContacterEntity : BasicData.BLLDAL.Contacter.ContacterEntity
        {
            private int _iSortID = -1;
            /// <summary>
            /// 排序字段
            /// </summary>
            public int SortID
            {
                get { return this._iSortID; }
                set { this._iSortID = value; }
            }
        }
        #endregion
　　　　 #region IDataDAL 成员
        public void Save(DataSet ds)
        {
            int iReturnValue;
            string strMsg;
            this.Save(ds, out strMsg, out iReturnValue);
        }

        public void Detele(string strCode)
        {
            int iReturnValue;
            string strMsg;
            this.Detele(strCode, out strMsg, out iReturnValue);
        }

        public void Save(DataSet ds, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            string strSqls;
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                DataRow[] drs;

                if (ds.Tables.Contains("JC_Client"))
                {
                    DataTable dt = ds.Tables["JC_Client"];
                    if (dt.DefaultView[0].Row.RowState == DataRowState.Added)
                    {
                        #region insert基本资料
                        strSql = @"INSERT INTO JC_Client (Code,CNName,ENName,ShortName,Address,Tels,Faxs,Postalcode,CountryCode,ProvinceCode,Remark,OpenBank,Account,SwiftCode,IsSys,Terminated,VirCode) 
                                  SELECT @Code,@CNName,@ENName,@ShortName,@Address,@Tels,@Faxs,@Postalcode,@CountryCode,@ProvinceCode,@Remark,@OpenBank,@Account,@SwiftCode,@IsSys,@Terminated,@VirCode";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CNName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["CNName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["ENName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ShortName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 20;
                        sqlParam.Value = dt.DefaultView[0].Row["ShortName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Address";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Address"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Tels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Faxs";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Faxs"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Postalcode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dt.DefaultView[0].Row["Postalcode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CountryCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["CountryCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProvinceCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["ProvinceCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dt.DefaultView[0].Row["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OpenBank";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["OpenBank"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Account";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["Account"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SwiftCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["SwiftCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsSys";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dt.DefaultView[0].Row["IsSys"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dt.DefaultView[0].Row["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VirCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 3;
                        sqlParam.Value = dt.DefaultView[0].Row["VirCode"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                    else if (dt.DefaultView[0].Row.RowState == DataRowState.Modified)
                    {
                        #region update基本资料
                        strSql = @"UPDATE JC_Client SET Code=@Code,CNName=@CNName,ENName=@ENName,ShortName=@ShortName,Address=@Address,Tels=@Tels,Faxs=@Faxs,Postalcode=@Postalcode,CountryCode=@CountryCode,ProvinceCode=@ProvinceCode,Remark=@Remark,OpenBank=@OpenBank,Account=@Account,SwiftCode=@SwiftCode,IsSys=@IsSys,Terminated=@Terminated,VirCode=@VirCode where Code=@Code";
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CNName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["CNName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["ENName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ShortName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 20;
                        sqlParam.Value = dt.DefaultView[0].Row["ShortName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Address";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Address"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Tels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Faxs";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 200;
                        sqlParam.Value = dt.DefaultView[0].Row["Faxs"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Postalcode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 100;
                        sqlParam.Value = dt.DefaultView[0].Row["Postalcode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CountryCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["CountryCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ProvinceCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dt.DefaultView[0].Row["ProvinceCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dt.DefaultView[0].Row["Remark"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@OpenBank";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["OpenBank"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Account";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["Account"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SwiftCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dt.DefaultView[0].Row["SwiftCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@IsSys";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dt.DefaultView[0].Row["IsSys"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Terminated";
                        sqlParam.SqlDbType = SqlDbType.Bit;
                        sqlParam.Size = 1;
                        sqlParam.Value = dt.DefaultView[0].Row["Terminated"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@VirCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 3;
                        sqlParam.Value = dt.DefaultView[0].Row["VirCode"];
                        sqlCom.Parameters.Add(sqlParam);



                        sqlCom.ExecuteNonQuery();
                        #endregion
                    }
                }

                if (ds.Tables.Contains("V_JC_ClientContacters"))
                {
                    #region 保存联系人明细
                    #region 新增数据
                    drs = ds.Tables["V_JC_ClientContacters"].Select("", "", DataViewRowState.Added);
                    #region 添加到联系表
                    strSqls = @"INSERT INTO JC_Contacters (Code,CNName,ENName,Postion,Sex,Tels,MobileTels,Emails,Faxs,SexView,Remark) 
                                         SELECT @Code ,@CNName,@ENName,@Postion,@Sex,@Tels,@MobileTels,@Emails,@Faxs,@SexView,@Remark";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSqls, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Code";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["Code"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@CNName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["CNName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ENName";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ENName"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Postion";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["Postion"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Sex";
                        sqlParam.SqlDbType = SqlDbType.SmallInt;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["Sex"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Tels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 800;
                        sqlParam.Value = dr["Tels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@MobileTels";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 800;
                        sqlParam.Value = dr["MobileTels"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Emails";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 800;
                        sqlParam.Value = dr["Emails"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Faxs";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 800;
                        sqlParam.Value = dr["Faxs"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SexView";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 2;
                        sqlParam.Value = dr["SexView"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@Remark";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 400;
                        sqlParam.Value = dr["Remark"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 添加到供应商
                    strSql = @"INSERT INTO JC_SupplierContacters (SupplierCode,SortID,ContacterCode) 
                               SELECT @SupplierCode,@SortID,@ContacterCode";

                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["SupplierCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ContacterCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ContacterCode"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                    #region 更新数据
                    drs = ds.Tables["V_JC_ClientContacters"].Select("", "", DataViewRowState.ModifiedCurrent);
                    strSql = @"UPDATE JC_ClientContacters SET SupplierCode=@SupplierCode,SortID=@SortID,ContacterCode=@ContacterCode WHERE ContacterCode=@ContacterCode";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);

                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SupplierCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["SupplierCode"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@SortID";
                        sqlParam.SqlDbType = SqlDbType.Int;
                        sqlParam.Size = 4;
                        sqlParam.Value = dr["SortID"];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ContacterCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 30;
                        sqlParam.Value = dr["ContacterCode"];
                        sqlCom.Parameters.Add(sqlParam);

                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #region 删除数据
                    drs = ds.Tables["V_JC_ClientContacters"].Select("", "", DataViewRowState.Deleted);
                    strSql = @"DELETE FROM JC_SupplierContacters WHERE ContacterCode=@ContacterCode";
                    foreach (DataRow dr in drs)
                    {
                        sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                        sqlParam = new SqlParameter();
                        sqlParam.ParameterName = "@ContacterCode";
                        sqlParam.SqlDbType = SqlDbType.NVarChar;
                        sqlParam.Size = 50;
                        sqlParam.Value = dr["ContacterCode", DataRowVersion.Original];
                        sqlCom.Parameters.Add(sqlParam);
                        sqlCom.ExecuteNonQuery();
                    }
                    #endregion
                    #endregion
                }
                sqlTrain.Commit();
                iReturn = 1;
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

        public void Detele(object obj, out string strMsg, out int iReturn)
        {
            strMsg = string.Empty;
            iReturn = -1;
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
            string[] arrTable = new string[] { "JC_Client" };
            try
            {
                sqlConn = new SqlConnection(Common.CommonDAL.DBConnString);
                sqlConn.Open();
                sqlTrain = sqlConn.BeginTransaction();
                foreach (string str in arrTable)
                {
                    strSql = "DELETE FROM " + str + " WHERE Code=@Code";
                    sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                    sqlParam = new SqlParameter();
                    sqlParam.ParameterName = "@Code";
                    sqlParam.SqlDbType = SqlDbType.NVarChar;
                    sqlParam.Size = 50;
                    sqlParam.Value = obj;
                    sqlCom.Parameters.Add(sqlParam);
                    sqlCom.ExecuteNonQuery();
                }
                sqlTrain.Commit();
                iReturn = 1;
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

        public void SaveGroup(DataSet ds, out string strMsg, out int iReturn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void DeteleGroup(object obj, out string strMsg, out int iReturn)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
