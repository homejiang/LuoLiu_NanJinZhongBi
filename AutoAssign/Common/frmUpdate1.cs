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
                @TestCode nvarchar(30),--���Ա��
                @XunHuanNo Smallint,--ѭ����
                @SpeedIndex smallint,--�ٶȶκ�
                @CyRate SMALLINT,--������
                @ZjqNo SMALLINT--��ǰ�ǽ������
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
	                -----�������
	                SELECT
	                ---��ѹ����
	                '��ѹ���� (��λ��kpa)��ѭ����'+cast(@XunHuanNo as nvarchar(5))+'���ٶȶ�'+cast(@SpeedIndex as nvarchar(5)) AS TPres1,
	                ---���±���
	                '�������� (��λ����)��ѭ����'+cast(@XunHuanNo as nvarchar(5))+'���ٶȶ�'+cast(@SpeedIndex as nvarchar(5)) AS TTemp1, 
	                ---�ǽ���ѹ��
	                '�ǽ��� (��λ��kg)'+isnull(@ZjqCode,'')+' ѹ�����ߣ�ѭ����'+cast(@XunHuanNo as nvarchar(5))+'���ٶȶ�'+cast(@SpeedIndex as nvarchar(5)) AS TZjq1
                	 
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
            this.ShowMsgRich("���³ɹ���");
        }
    }
}