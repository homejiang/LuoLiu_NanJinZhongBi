using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common.SystemHelp
{
    public class ProgramDebug
    {
        /// <summary>
        /// ���dtSource���޸ĵĵط�
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public string CheckModifyColumn(DataTable dtSource)
        {
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                if (dtSource.Rows[i].RowState == DataRowState.Unchanged) continue;
                if (dtSource.Rows[i].RowState == DataRowState.Deleted) return string.Format("��{0}���ѱ�ɾ��", i);
                if (dtSource.Rows[i].RowState == DataRowState.Modified)
                {
                    foreach (DataColumn dc in dtSource.Columns)
                    {
                        if (!dtSource.Rows[i][dc, DataRowVersion.Original].Equals(dtSource.Rows[i][dc, DataRowVersion.Current]))
                            return string.Format("��{0}�� �ֶ�\"" + dc.ColumnName + "\"�ѱ��޸�", i);
                        //if (dtSource.Rows[i][dc, DataRowVersion.Original].GetType().ToString()!=dtSource.Rows[i][dc, DataRowVersion.Current].GetType().ToString())
                        //    return string.Format("��{0}�� �ֶ�\"" + dc.ColumnName + "\"�ѱ��޸�", i);
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// ���dsSource���޸ĵĵط�
        /// </summary>
        /// <param name="dsSoruce"></param>
        /// <returns></returns>
        public string CheckModifyColumn(DataSet dsSoruce)
        {
            StringBuilder sb = new StringBuilder();
            string strModify;
            foreach (DataTable dt in dsSoruce.Tables)
            {
                strModify = this.CheckModifyColumn(dt);
                if (strModify.Length > 0)
                    sb.Append(string.Format("��\"{0}\"��{1}", dt.TableName, strModify));
            }
            return sb.ToString();
        }
    }
}
