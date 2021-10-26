using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;
using System.Data.SqlClient;
using System.IO;

namespace UpdateERP
{
    public partial class frmUpdateExe : Common.frmBaseEdit
    {
        public frmUpdateExe()
        {
            InitializeComponent();
        }

        private void frmUpdateExe_Load(object sender, EventArgs e)
        {
            this.BindData();
        }
        private bool BindData()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT FileName,CAST((case when UpdateEXEEntity IS null then 0 else 1 end) AS BIT) as Updated FROM UpdateExe");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            bool blUpdated = false;
            if (dt.Rows.Count > 0)
            {
                this.textBox1.Text = dt.Rows[0]["FileName"].ToString();
                blUpdated = !dt.Rows[0]["Updated"].Equals(DBNull.Value) && (bool)dt.Rows[0]["Updated"];
            }
            if (blUpdated)
                this.labUpdated.Text = "文件已上传";
            else this.labUpdated.Text = "文件为空";
            return true;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            List<string> listSql = new List<string>();
            listSql.Add("DELETE FROM UpdateExe");
            listSql.Add(string.Format("Insert into UpdateExe(FileName) values('{0}')", this.textBox1.Text.Replace("'", "''")));
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("更新成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != this.openFileDialog1.ShowDialog(this)) return;
            string strFile = this.openFileDialog1.FileName;
            if (strFile.Length == 0) return;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                FileStream fs = fi.OpenRead();
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                this.Upload(this.textBox1.Text, bytes);
                fs.Close();
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsg("上传成功！");

        }
        public void Upload(string sfileName, byte[] bytes)
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
                //先执行删除
                strSql = @"DELETE FROM UpdateExe";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlCom.ExecuteNonQuery();
                //更新文件
                strSql = @"INSERT INTO UpdateExe(FileName,UpdateEXEEntity) values(@FileName,@UpdateEXEEntity)";
                sqlCom = new SqlCommand(strSql, sqlConn, sqlTrain);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "FileName";
                sqlParam.SqlDbType = SqlDbType.NVarChar;
                sqlParam.Size = 50;
                sqlParam.Value = sfileName;
                sqlCom.Parameters.Add(sqlParam);
                sqlParam = new SqlParameter();
                sqlParam.ParameterName = "@UpdateEXEEntity";
                sqlParam.SqlDbType = SqlDbType.Image;
                sqlParam.Value = bytes;
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
    }
}