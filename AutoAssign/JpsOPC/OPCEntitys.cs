using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpsOPC.OPCEntitys
{
    public class SwichABEntity
    {
        public SwichABEntity()
        {

        }
        public short CaoIndex = 0;
        /// <summary>
        /// A档最小值
        /// </summary>
        public float MinValueA = 0F;
        /// <summary>
        /// B档最小值
        /// </summary>
        public float MinValueB = 0F;
        /// <summary>
        /// A档最大值
        /// </summary>
        public float MaxValueA = 0F;
        /// <summary>
        /// B档最大值
        /// </summary>
        public float MaxValueB = 0F;
        /// <summary>
        /// A档数量
        /// </summary>
        public short QtyA = 0;
        /// <summary>
        /// B档数量
        /// </summary>
        public short QtyB = 0;

    }
    public class YaChaEntity
    {
        public float Yc1 = 0F;
        public float Yc2 = 0F;
        public float Yc3 = 0F;
        public float Yc4 = 0F;
        public float Yc5 = 0F;
        public float Yc6 = 0F;
        public float Yc7 = 0F;
        public float Yc8 = 0F;
        public float Yc9 = 0F;
        public float Yc10 = 0F;
        public float Yc11 = 0F;
        public float Yc12 = 0F;
        public float Yc13 = 0F;
        public float Yc14 = 0F;
        public float Yc15 = 0F;
        public float Yc16 = 0F;
        public float Yc17 = 0F;
        public float Yc18 = 0F;
        public float Yc19 = 0F;
        public float Yc20 = 0F;
    }
    public class NanJingZB_SJRVRange
    {
        public float SJ_V1min = 0F;
        public float SJ_V1max = 0F;
        public float SJ_R1min = 0F;
        public float SJ_R1max = 0F;
        public float SJ_V2min = 0F;
        public float SJ_V2max = 0F;
        public float SJ_R2min = 0F;
        public float SJ_R2max = 0F;
        public float SJ_V3min = 0F;
        public float SJ_V3max = 0F;
        public float SJ_R3min = 0F;
        public float SJ_R3max = 0F;
        public float SJ_V4min = 0F;
        public float SJ_V4max = 0F;
        public float SJ_R4min = 0F;
        public float SJ_R4max = 0F;
        public float SJ_V5min = 0F;
        public float SJ_V5max = 0F;
        public float SJ_R5min = 0F;
        public float SJ_R5max = 0F;
        public float SJ_V6min = 0F;
        public float SJ_V6max = 0F;
        public float SJ_R6min = 0F;
        public float SJ_R6max = 0F;
        public float SJ_V7min = 0F;
        public float SJ_V7max = 0F;
        public float SJ_R7min = 0F;
        public float SJ_R7max = 0F;
        public float SJ_V8min = 0F;
        public float SJ_V8max = 0F;
        public float SJ_R8min = 0F;
        public float SJ_R8max = 0F;
        public float SJ_V9min = 0F;
        public float SJ_V9max = 0F;
        public float SJ_R9min = 0F;
        public float SJ_R9max = 0F;
        public float SJ_V10min = 0F;
        public float SJ_V10max = 0F;
        public float SJ_R10min = 0F;
        public float SJ_R10max = 0F;
        public float SJ_V11min = 0F;
        public float SJ_V11max = 0F;
        public float SJ_R11min = 0F;
        public float SJ_R11max = 0F;
        public float SJ_V12min = 0F;
        public float SJ_V12max = 0F;
        public float SJ_R12min = 0F;
        public float SJ_R12max = 0F;
        public float SJ_V13min = 0F;
        public float SJ_V13max = 0F;
        public float SJ_R13min = 0F;
        public float SJ_R13max = 0F;
        public float SJ_V14min = 0F;
        public float SJ_V14max = 0F;
        public float SJ_R14min = 0F;
        public float SJ_R14max = 0F;
        public float SJ_V15min = 0F;
        public float SJ_V15max = 0F;
        public float SJ_R15min = 0F;
        public float SJ_R15max = 0F;
        public float SJ_V16min = 0F;
        public float SJ_V16max = 0F;
        public float SJ_R16min = 0F;
        public float SJ_R16max = 0F;
        public void SetValueFromDB(int iGroove,object objVmin,object objVmax,object objRmin,object objRmax)
        {
            switch(iGroove)
            {
                case 1:
                    this.SJ_V1min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V1max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R1min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R1max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 2:
                    this.SJ_V2min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V2max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R2min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R2max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 3:
                    this.SJ_V3min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V3max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R3min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R3max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 4:
                    this.SJ_V4min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V4max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R4min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R4max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 5:
                    this.SJ_V5min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V5max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R5min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R5max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 6:
                    this.SJ_V6min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V6max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R6min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R6max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 7:
                    this.SJ_V7min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V7max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R7min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R7max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 8:
                    this.SJ_V8min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V8max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R8min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R8max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 9:
                    this.SJ_V9min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V9max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R9min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R9max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 10:
                    this.SJ_V10min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V10max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R10min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R10max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 11:
                    this.SJ_V11min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V11max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R11min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R11max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 12:
                    this.SJ_V12min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V12max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R12min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R12max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 13:
                    this.SJ_V13min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V13max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R13min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R13max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 14:
                    this.SJ_V14min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V14max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R14min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R14max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 15:
                    this.SJ_V15min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V15max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R15min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R15max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
                case 16:
                    this.SJ_V16min = (float)(objVmin == null || objVmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmin.ToString()));
                    this.SJ_V16max = (float)(objVmax == null || objVmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objVmax.ToString()));
                    this.SJ_R16min = (float)(objRmin == null || objRmin.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmin.ToString()));
                    this.SJ_R16max = (float)(objRmax == null || objRmax.Equals(DBNull.Value) ? 0M : decimal.Parse(objRmax.ToString()));
                    break;
            }
        }

    }
    public class NanJingZB_SJResult
    {
        public decimal SJ_Resut1 = 0M;
        public decimal SJ_Resut2 = 0M;
        public decimal SJ_Resut3 = 0M;
        public decimal SJ_Resut4 = 0M;
        public decimal SJ_Resut5 = 0M;
        public decimal SJ_Resut6 = 0M;
        public decimal SJ_Resut7 = 0M;
        public decimal SJ_Resut8 = 0M;
        public decimal SJ_Resut9 = 0M;
        public decimal SJ_Resut10 = 0M;
        public decimal SJ_Resut11 = 0M;
        public decimal SJ_Resut12 = 0M;
        public decimal SJ_Resut13 = 0M;
        public decimal SJ_Resut14 = 0M;
        public decimal SJ_Resut15 = 0M;
        public decimal SJ_Resut16 = 0M;
        public bool IsOK()
        {
            return SJ_Resut1 != -1M
                && SJ_Resut1 != -1M
                && SJ_Resut3 != -1M
                && SJ_Resut4 != -1M
                && SJ_Resut5 != -1M
                && SJ_Resut6 != -1M
                && SJ_Resut7 != -1M
                && SJ_Resut8 != -1M
                && SJ_Resut9 != -1M
                && SJ_Resut10 != -1M
                && SJ_Resut11 != -1M
                && SJ_Resut12 != -1M
                && SJ_Resut13 != -1M
                && SJ_Resut14 != -1M
                && SJ_Resut15 != -1M
                && SJ_Resut16 != -1M;
        }
    }
}
