using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Common.BLLDAL
{
    class Client
    {
        /// <summary>
        /// 获取某一客户的联系人
        /// </summary>
        /// <param name="strClient"></param>
        /// <returns></returns>
        public static List<Common.BLLDAL.Client.ContactersEntity> GetClientContacters(string strClient)
        {
            DataTable dt = null;
            List<Common.BLLDAL.Client.ContactersEntity> listReturn = new List<ContactersEntity>();
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT * FROM V_JC_ClientContacters WHERE ClientCode='{0}' ORDER BY SortID", strClient.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            Common.BLLDAL.Client.ContactersEntity con;
            dt.DefaultView.Sort = "SortID ASC";
            foreach (DataRowView drv in dt.DefaultView)
            {
                con = new ContactersEntity();
                con.SortID = int.Parse(drv.Row["SortID"].ToString());
                con.Code = drv.Row["ContacterCode"].ToString();
                con.CNName = drv.Row["CNName"].ToString();
                con.ENName = drv.Row["ENName"].ToString();
                con.Postion = drv.Row["Postion"].ToString();
                con.Sex = drv.Row["Sex"].Equals(DBNull.Value) ? 0 : int.Parse(drv.Row["Sex"].ToString());
                con.Tels = drv.Row["Tels"].ToString();
                con.MobileTels = drv.Row["MobileTels"].ToString();
                con.Emails = drv.Row["Emails"].ToString();
                con.Faxs = drv.Row["Faxs"].ToString();
                con.SexView = drv.Row["SexView"].ToString();
                con.Remark = drv.Row["Remark"].ToString();
                listReturn.Add(con);
            }
            return listReturn;
            
        }
        #region 客户联系人
        public class ContactersEntity:Common.BLLDAL.Contacter.ContacterEntity
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
    }
}
