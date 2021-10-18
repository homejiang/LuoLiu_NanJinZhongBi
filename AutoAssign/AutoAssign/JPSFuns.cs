using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAssign
{
    public class JPSFuns
    {
        public static string GetModeView(JPSEntity.ModeView mode)
        {
            return GetModeView(mode.ModeIsNeter, mode.ModeIsScaner);
        }
        public static string GetModeView(object isModeIsNeter, object isModeIsScaner)
        {
            string strText;
            if (isModeIsNeter == null || isModeIsNeter.Equals(DBNull.Value))
                strText = "?";
            else
            {
                if ((bool)isModeIsNeter) strText = "网络版";
                else strText = "单机版";
            }
            strText += "+";
            if (isModeIsScaner == null || isModeIsScaner.Equals(DBNull.Value))
                strText += "?";
            else
            {
                if ((bool)isModeIsScaner) strText += "扫码";
                else strText += "不扫码";
            }
            return strText;
        }
        public static string GetGongYiTypeName(JPSEnum.GongYiTypes type)
        {
            if (type == JPSEnum.GongYiTypes.None) return "";
            if (type == JPSEnum.GongYiTypes.Same) return "同工艺";
            if (type == JPSEnum.GongYiTypes.Deffrent) return "多工艺";
            return "未知";
        }
        public static string GetOnOffView(JPSEnum.OnOff type)
        {
            if (type == JPSEnum.OnOff.None) return "";
            if (type == JPSEnum.OnOff.On) return "打开";
            if (type == JPSEnum.OnOff.Off) return "关闭";
            return "未知";
        }
        public static bool CheckUserPower()
        {
            if (!Common.CurrentUserInfo.IsAdmin)
            {
                System.Windows.Forms.MessageBox.Show("您不是管理员，不能操作。", "系统提示");
                return false;
            }
            return true;
        }
        public static string GetByteToHex(byte[] bs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bs)
            {
                string shex = Convert.ToString(b, 16);
                if (shex.Length < 2) shex = "0" + shex;
                sb.Append(shex);
            }
            return sb.ToString();
        }
        public static int GetInt32ByBit(bool[] bits)
        {
            //设置当前变量
            int iValue = 0;
            int iBitNum;
            int iBitValue;
            for (short i =0;i<bits.Length;i++)
            {
                iBitNum = i;
                iBitValue = bits[i] ? 1 : 0;
                iValue &= ~(0x1 << iBitNum);
                iValue |= iBitValue << iBitNum;
            }
            return iValue;
        }
    }
}
