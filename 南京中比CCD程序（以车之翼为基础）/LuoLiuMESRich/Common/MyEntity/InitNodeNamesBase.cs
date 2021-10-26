using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    public class InitNodeNamesBase
    {
        /// <summary>
        /// ����ļ������ڣ��򴴽�
        /// </summary>
        public void CreatesInifileName(string sInifileName)
        {
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += sInifileName;
            try
            {
                if (!System.IO.File.Exists(strFile))
                {
                    System.IO.FileStream file = System.IO.File.Create(strFile);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
