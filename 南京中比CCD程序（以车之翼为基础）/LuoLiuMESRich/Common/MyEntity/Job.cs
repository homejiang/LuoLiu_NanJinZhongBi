using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    public class Job
    {
        public Job()
        {
        }
        private object _strJobCode;
        /// <summary>
        ///
        /// </summary>
        public object JobCode
        {
            get { return this._strJobCode; }
            set { this._strJobCode = value; }
        }
        private object _strUserCode;
        /// <summary>
        ///
        /// </summary>
        public object UserCode
        {
            get { return this._strUserCode; }
            set { this._strUserCode = value; }
        }

        private object _strUserName;
        /// <summary>
        ///
        /// </summary>
        public object UserName
        {
            get { return this._strUserName; }
            set { this._strUserName = value; }
        }
        private object _strJobName;
        /// <summary>
        ///
        /// </summary>
        public object JobName
        {
            get { return this._strJobName; }
            set { this._strJobName = value; }
        }
        private object _strJobDesc;
        /// <summary>
        ///
        /// </summary>
        public object JobDesc
        {
            get { return this._strJobDesc; }
            set { this._strJobDesc = value; }
        }
    }
}
