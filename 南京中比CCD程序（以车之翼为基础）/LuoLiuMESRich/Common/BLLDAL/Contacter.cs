using System;
using System.Collections.Generic;
using System.Text;

namespace Common.BLLDAL
{
    class Contacter
    {
        #region 联系人类
        public class ContacterEntity
        {
            private string _strCode = string.Empty;
            public string Code
            {
                get { return this._strCode; }
                set { this._strCode = value; }
            }

            private string _strCNName = string.Empty;
            public string CNName
            {
                get { return this._strCNName; }
                set { this._strCNName = value; }
            }

            private string _strENName = string.Empty;
            public string ENName
            {
                get { return this._strENName; }
                set { this._strENName = value; }
            }

            private string _strPostion = string.Empty;
            public string Postion
            {
                get { return this._strPostion; }
                set { this._strPostion = value; }
            }

            private int _iSex = -1;
            public int Sex
            {
                get { return this._iSex; }
                set { this._iSex = value; }
            }

            private string _strTels = string.Empty;
            public string Tels
            {
                get { return this._strTels; }
                set { this._strTels = value; }
            }

            private string _strMobileTels = string.Empty;
            public string MobileTels
            {
                get { return this._strMobileTels; }
                set { this._strMobileTels = value; }
            }

            private string _strEmails = string.Empty;
            public string Emails
            {
                get { return this._strEmails; }
                set { this._strEmails = value; }
            }

            private string _strFaxs = string.Empty;
            public string Faxs
            {
                get { return this._strFaxs; }
                set { this._strFaxs = value; }
            }

            private string _strSexView = string.Empty;
            public string SexView
            {
                get { return this._strSexView; }
                set { this._strSexView = value; }
            }

            private string _strRemark = string.Empty;
            public string Remark
            {
                get { return this._strRemark; }
                set { this._strRemark = value; }
            }
            public string ContacterName
            {
                get
                {
                    if (this.CNName.Length > 0) return this.CNName;
                    if (this.ENName.Length > 0) return this.ENName;
                    return string.Empty;
                }
            }
            /// <summary>
            /// 姓名加上性别
            /// </summary>
            public string NameAndSex
            {
                get
                {
                    return this.ContacterName + " " + this.SexView;
                }
            }
        }
        #endregion
    }
}
