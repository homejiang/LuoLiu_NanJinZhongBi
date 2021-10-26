using System;
using System.Collections.Generic;
using System.Text;

namespace Common.MyEntity
{
    public class VersionEntity
    {
        public string Guid = string.Empty;
        public string Version = string.Empty;
        public VersionEntity()
        {
        }
        public VersionEntity(string sGuids)
        {
            string[] arr=sGuids.Split('|');
            if (arr.Length < 2) return;
            Guid = arr[0];
            Version = arr[1];
        }
        public VersionEntity(string sguid, string sVersion)
        {
            Guid = sguid;
            Version = sVersion;
        }
    }
}
