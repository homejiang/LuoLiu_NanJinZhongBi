using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace Common
{
    public partial class frmUpdate1 : Common.frmBase
    {
        public frmUpdate1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSql = @"ALTER PROCEDURE [dbo].[GetReportDataSource1] 
                (
                @TestCode nvarchar(30),--测试编号
                @XunHuanNo Smallint,--循环号
                @SpeedIndex smallint,--速度段号
                @CyRate SMALLINT,--采样率
                @ZjqNo SMALLINT--当前涨紧器序号
                )
                AS
                BEGIN
	                -- SET NOCOUNT ON added to prevent extra result sets from
	                -- interfering with SELECT statements.
	                SET NOCOUNT ON;
	                DECLARE @ZjqCode nvarchar(30)
	                select 
	                @ZjqCode=(CASE when @ZjqNo=1 then Zjq1Code 
	                when @ZjqNo=2 then Zjq2Code 
	                when @ZjqNo=3 then Zjq3Code 
	                when @ZjqNo=4 then Zjq4Code END)
	                from Test_Main where TestCode=@TestCode
	                -----输出数据
	                SELECT
	                ---油压标题
	                '油压曲线 (单位：kpa)：循环号'+cast(@XunHuanNo as nvarchar(5))+'，速度段'+cast(@SpeedIndex as nvarchar(5)) AS TPres1,
	                ---油温标题
	                '油温曲线 (单位：℃)：循环号'+cast(@XunHuanNo as nvarchar(5))+'，速度段'+cast(@SpeedIndex as nvarchar(5)) AS TTemp1, 
	                ---涨紧器压力
	                '涨紧器 (单位：kg)'+isnull(@ZjqCode,'')+' 压力曲线：循环号'+cast(@XunHuanNo as nvarchar(5))+'，速度段'+cast(@SpeedIndex as nvarchar(5)) AS TZjq1
                	 
                END";
            //strSql = strSql.Replace("'", "''");
            try
            {
                Common.CommonDAL.DoSqlCommand.DoSql(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.ShowMsgRich("更新成功！");
        }
    }
}