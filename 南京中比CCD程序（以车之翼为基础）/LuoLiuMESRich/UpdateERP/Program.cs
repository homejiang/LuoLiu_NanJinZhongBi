using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UpdateERP
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            #region  读取数据库配置文件
            if (!Common.CommonDAL.ReadInifile()) return;
            if (!UpdateERP.BLLDAL.UpdateDAL.ReadInifile()) return;
            #endregion
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            Application.Run(frmlogin1);
            if (frmlogin1.DialogResult != DialogResult.OK)
                return;
            if (!Common.CurrentUserInfo.IsSuper)
            {
                MessageBox.Show("只有超级管理员才能添加更新文件。");
                return;
            }
            frmUpdateVersion frm = new frmUpdateVersion();
            Application.Run(frm);
        }
    }
}