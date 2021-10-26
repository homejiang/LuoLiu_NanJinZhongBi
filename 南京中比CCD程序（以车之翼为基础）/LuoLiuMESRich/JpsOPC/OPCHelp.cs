using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace JpsOPC
{
    public class OPCHelperBase
    {
        public const int TransIDMainform = 2012;
        public const int TransIDSetttings = 2013;
        public string OPCItemTitle = "1200.1217.";
        public int _ClientHandle = 0;
        public bool IsDebug = false;
        public bool InitSucessfully = false;
    }
    public class Debug
    {
        public static short ResultValue = 0;
        public static string Code = string.Empty;
        public static bool IsErr = false;
    }
    public class OPCHelperCCD : OPCHelperBase
    {
        public OPCHelperCCD()
        {
           
        }
        public event ShowMsgCallback LogNotice = null;
        public event ShowMsgCallback ErrorNotice = null;
        OPCServer _Server = null;
        OPCGroups _ServerGroups = null;
        public OPCGroup _MyGroup_CCD = null;
        //获取槽号
        public JpsOPC.MyItemValue RT_Code = null;
        public JpsOPC.MyItemValue Rt_CCD = null;
        public JpsOPC.MyItemValue At_Err1 = null;
        #region 公共函数
        public bool InitServer(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                return true;
            }
            if (_Server == null)
            {
                try
                {
                    this._Server = new OPCServer();
                }
                catch (Exception ex)
                {
                    sErr = "OPC：初始化Server出错：" + ex.Message + "(" + ex.Source + ")";
                    return false;
                }
            }
            if (this._Server.ServerState != (int)OPCServerState.OPCRunning)
            {
                try
                {
                    this._Server.Connect("KEPware.KEPServerEx.V6", "");
                }
                catch (Exception ex)
                {
                    sErr = string.Format("ResultOPC：server初始化出错：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
                //重新连接过的话重新定义组
                _ServerGroups = null;
                if (this.RT_Code != null)
                    this.RT_Code.InitItem();
                if (this.Rt_CCD != null)
                    this.Rt_CCD.InitItem();
                if (this.At_Err1 != null)
                    this.At_Err1.InitItem();
            }
            //添加组
            if (_ServerGroups == null)
            {
                _ServerGroups = this._Server.OPCGroups;
                _ServerGroups.DefaultGroupIsActive = true; //设置组集合默认为激活状态
                //下面这个几个暂时不设定，看看是否有异常，因为DefaultGroupUpdateRate这个值很关键，估计是与写入和读取的频率相关了，应该设置到某个单一的节点为好。
                _ServerGroups.DefaultGroupDeadband = 0;    //设置死区
                _ServerGroups.DefaultGroupUpdateRate = 100;//设置更新频率
                try
                {
                    this._MyGroup_CCD = _ServerGroups.Add("jpsCCDGroup");
                    this._MyGroup_CCD.UpdateRate = 100;
                    this._MyGroup_CCD.IsActive = true;
                }
                catch (Exception ex)
                {
                    sErr = string.Format("创建各组失败：{0}({1})", ex.Message, ex.Source);
                    return false;
                }
            }
            if (!this.InitMyItems(out sErr))
            {
                return false;
            }
            sErr = string.Empty;
            return true;
        }
        public bool InitMyItems(out string sErr)
        {

            if (this.RT_Code == null)
                RT_Code = new MyItemValue(DataTypes.Int16, OPCItemTitle + "RT_Code");
            if (this.Rt_CCD == null)
                Rt_CCD = new MyItemValue(DataTypes.Int16,OPCItemTitle + "Rt_CCD");
            if (this.At_Err1 == null)
                At_Err1 = new MyItemValue(DataTypes.Bool, OPCItemTitle + "At_Err1");
            
            if (this._MyGroup_CCD == null)
            {
                sErr = "CCD结果组item时失败，因为group2为空。";
                return false;
            }
            if (_MyGroup_CCD.OPCItems == null)
            {
                sErr = "CCD结果组item时失败，因为group2.OPCItems为空。";
                return false;
            }
            //处理标识
            if (!InitMyItems_AddItem(this.RT_Code, this._MyGroup_CCD, true, out sErr))
            {
                return false;
            }
            //处理标识
            if (!InitMyItems_AddItem(this.Rt_CCD, this._MyGroup_CCD, true, out sErr))
            {
                return false;
            }
            if (!InitMyItems_AddItem(this.At_Err1, this._MyGroup_CCD, true, out sErr))
            {
                return false;
            }
            return true;
        }
        private bool InitMyItems_AddItem(MyItemValue myItem, OPCGroup targetGroup, bool saveItem, out string sErr)
        {
            if (myItem.ServerHandle <= 0)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    return true;
                }
                //此时添加Item
                _ClientHandle++;
                OPCItem item = null;
                string strTagName = myItem.TagName;
                try
                {
                    item = targetGroup.OPCItems.AddItem(strTagName, _ClientHandle);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("添加Item：{0}，出错:{1}({2})", myItem.TagName, ex.Message, ex.Source);
                    return false;
                }
                if (item == null)
                {
                    sErr = string.Format("添加Item：{0}失败，返回为空。", myItem.TagName);
                    return false;
                }
                if (item.ServerHandle <= 0)
                {
                    sErr = string.Format("添加Item：{0}失败，返回值ServerHandle为{1}。", myItem.TagName, myItem.ServerHandle);
                    return false;
                }
                myItem.ServerHandle = item.ServerHandle;
                myItem.ClientHandle = this._ClientHandle;
                if (saveItem)
                    myItem._OPCItem = item;
            }
            sErr = string.Empty;
            return true;
        }
        public bool CloseOPC(out string sErr)
        {
            sErr = "";
            if (this._Server == null) return true;
            try
            {
                this._Server.Disconnect();
            }
            catch (Exception ex)
            {
                sErr = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
        #region 特殊功能函数
        public bool ReadMKCode(CCDDataEntity data, out string sErr)
        {
            sErr = string.Empty;
            this.ShowLogAsyn("开始读取CCD所有数据");
            if (this.IsDebug)
            {
                this.ShowLogAsyn("OPCHelperA当前为Debug模式");
                data.Code = Debug.Code;
                data.SpecValue = Debug.ResultValue;
                sErr = string.Empty;
                return true;
            }
            Array values = null;
            #region serverHandles
            Array serverHandles = new int[3] { 0
               , this.RT_Code.ServerHandle
                , this.Rt_CCD.ServerHandle
            };
            #endregion
            object objQ;
            object objT;
            Array errors;
            try
            {
                this._MyGroup_CCD.SyncRead(1, 2, ref serverHandles, out values, out errors, out objQ, out objT);
            }
            catch (Exception ex)
            {
                sErr = string.Format("_MyGroup_CCD读取出错01：{0}({1})", ex.Message, ex.Source);
                return false;
            }
            this.ShowLogAsyn("_MyGroup_CCD的Read已经执行，开始分析返回数据。");
            if (values == null)
            {
                sErr = "_MyGroup_CCD读取出错02:values为空！";
                return false;
            }
            if (values.Length != 2)
            {
                sErr = string.Format("_MyGroup_CCD读取出错03:values长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            Array arrQ = objQ as Array;
            if (arrQ == null)
            {
                sErr = "_MyGroup_CCD读取出错04:qualitys为空！";
                return false;
            }
            if (arrQ.Length != 2)
            {
                sErr = string.Format("_MyGroup_CCD读取出错05:qualitys长度为{0}，不是预期的2！", values.Length);
                return false;
            }
            this.ShowLogAsyn("_MyGroup_CCD的Read结果长度分析无误，开始分析数据格式。");
            object objValue;
            short iValue;
            string strMkCode;
            int iIndex = 1;
            string sTag;
            //RT_Code
            sTag = "模块编号";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetMKCode(sTag, objValue, objQ, out strMkCode, ref sErr)) return false;
            data.Code = strMkCode;
            this.ShowLogAsyn(sTag + "获取为：" + data.Code);
            //CCD检测结果
            iIndex++;
            sTag = "CCD检测结果";
            objValue = values.GetValue(iIndex);
            objQ = arrQ.GetValue(iIndex);
            if (!this.GetShortValue(sTag, objValue, objQ, out iValue, ref sErr)) return false;
            data.SpecValue = iValue;
            this.ShowLogAsyn(sTag + "获取为：" + data.SpecValue.ToString());
            return true;
        }
        private bool GetMKCode(string sTagName, object objValue, object objQ, out string sMKCode, ref string sErr)
        {
            if (objQ == null)
            {
                sMKCode = string.Empty;
                sErr = string.Format("GMKCode读取出错Rx1：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                sMKCode = string.Empty;
                sErr = string.Format("GMKCode读取出错Rx2：Tag[{0}]返回的Quality为{1}不是预期的192！值为[{2}]", sTagName, objQ.ToString(), objValue == null ? "NUL" : objValue.ToString());
                //return false;
            }
            sMKCode = objValue == null ? string.Empty : objValue.ToString();
            return true;
        }
        private bool GetShortValue(string sTagName, object objValue, object objQ, out short iValue, ref string sErr)
        {

            if (objQ == null)
            {
                iValue = 0;
                sErr = string.Format("GShortValue读取出错Rs1：Tag[{0}]返回的Quality为空！", sTagName);
                return false;
            }
            if (objQ.ToString() != "192")
            {
                iValue = 0;
                sErr = string.Format("GShortValue读取出错Rs2：Tag[{0}]返回的Quality为{1}不是预期的192！对应的值为[{2}]", sTagName, objQ.ToString(), objValue == null ? "NUL" : objValue.ToString());
                //return false;
            }
            if (objValue == null)
                iValue = 0;
            else
            {
                if (!short.TryParse(objValue.ToString(), out iValue))
                {
                    sErr = string.Format("GroupHanjieA读取出错Rs3：Tag[{0}]返回的Value为{1}不是有效的ini16！", sTagName, objValue.ToString());
                    iValue = 0;
                    return false;
                }
            }
            return true;
        }
        public bool ReadCCDResult(out string sErr)
        {
            if(this.IsDebug)
            {
                sErr = string.Empty;
                this.Rt_CCD.Value_Short = Debug.ResultValue;
                return true;
            }
            if (this.Rt_CCD == null)
            {
                sErr = "result槽号为空！";
                return false;
            }
            else if (this.Rt_CCD._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "CCD结果值的OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (this.Rt_CCD.ServerHandle <= 0)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "CCD结果值的OPCItemHandle值为0，但重新初始化时出错：" + sErr;
                    return false;
                }
            }
            //此时有效了，直接读取值
            object objValue;
            if (!this.Rt_CCD.ReadData(out objValue, out sErr))
            {
                sErr = "CCD结果值的OPCItem(AT_ReadResult)读取出错：" + sErr;
                return false;
            }
            if (objValue == null)
            {
                sErr = string.Format("CCD结果值读取出错：item对象[{0}]的返回值NULL。", this.Rt_CCD.TagName);
                return false;
            }
            //此时读取成功了，则转换
            string strValue = objValue.ToString();
            short iValue;
            if(!short.TryParse(strValue,out iValue))
            {
                sErr = string.Format("读取到的CCD结果值\"{0}\"不是有效整型！", strValue);
                return false;
            }
            this.Rt_CCD.Value_Short = iValue;
            return true;
        }
        public bool InitCCDResult(out string sErr)
        {
            if (this.IsDebug)
            {
                if (this.IsDebug)
                {
                    sErr = string.Empty;
                    Debug.ResultValue = 0;
                    return true;
                }
            }
            if (this.Rt_CCD == null)
            {
                sErr = "Rt_CCD设置失败：opc为空！";
                return false;
            }
            else if (this.Rt_CCD._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "Rt_CCD设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            short iValue = 0;
            if (!this.Rt_CCD.WriteData(iValue, out sErr))
            {
                sErr = "Rt_CCD写入出错：" + sErr;
                return false;
            }
            return true;
        }
        public bool SetErr1(out string sErr)
        {
            if (this.IsDebug)
            {
                sErr = string.Empty;
                Debug.IsErr = true;
                return true;
            }
            if (this.At_Err1 == null)
            {
                sErr = "At_Err1设置失败：opc为空！";
                return false;
            }
            else if (this.At_Err1._OPCItem == null)
            {
                //此时还未初始化
                if (!this.InitServer(out sErr))
                {
                    sErr = "At_Err1设置失败：OPCItem为空，且初始化出错：" + sErr;
                    return false;
                }
            }
            if (!this.At_Err1.WriteData(true, out sErr))
            {
                sErr = "At_Err1写入出错：" + sErr;
                return false;
            }
            return true;
        }
        #endregion
        #region 消息
        private void ShowLogAsyn(string sMsg)
        {
            if (this.LogNotice == null) return;
            this.LogNotice(sMsg);
        }
        private void ShowErrAsyn(string sMsg)
        {
            if (this.ErrorNotice == null) return;
            this.ErrorNotice(sMsg);
        }
        #endregion
    }
    public enum DataTypes
    {
        Bool = 1,
        Float = 2,
        Int16 = 3
    }
    public class MyItemValue
    {
        public DataTypes MyType;
        public OPCItem _OPCItem = null;
        public MyItemValue(DataTypes dataType, string sTagName)
        {
            this.TagName = sTagName;
            this.MyType = dataType;
        }
        public string Value_String = string.Empty;
        public decimal Value_Decimal = 0M;
        public float Value_Float = 0F;
        public bool Value_Bool = false;
        public short Value_Short = 0;
        public int ClientHandle = 0;
        public int ServerHandle = 0;
        public string TagName = string.Empty;
        public void InitItem()
        {
            this.ServerHandle = 0;
            this._OPCItem = null;
        }
        public bool ReadData(out object value, out string sErr)
        {
            if (this._OPCItem == null)
            {
                value = "";
                sErr = "OPCItem地址为空";
                return false;
            }
            else
            {
                object objQ;
                object objT;
                try
                {
                    this._OPCItem.Read(1, out value, out objQ, out objT);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("OPCItem[{0}]Exception:", this.TagName, ex.Message);
                    value = "";
                    return false;
                }
                if (objQ == null)
                {
                    sErr = "读取[" + this.TagName + "]的值时Quality值不是预期的192。(quality IS NULL)";
                    return false;
                }
                if (objQ.ToString() != "192")
                {
                    sErr = "读取[" + this.TagName + "]的值时的Quality值不是预期的192。(quality:" + objQ.ToString() + ")";
                    return false;
                }
                sErr = string.Empty;
                return true;
            }
        }
        public bool WriteData(object value, out string sErr)
        {
            if (this._OPCItem == null)
            {
                sErr = string.Format("OPCItem[{0}]写入失败：地址为空！", this.TagName);
                return false;
            }
            else
            {
                try
                {
                    this._OPCItem.Write(value);
                }
                catch (Exception ex)
                {
                    sErr = string.Format("OPCItem[{0}]写入出错:{1}({2})", this.TagName, ex.Message, ex.Source);
                    return false;
                }
                sErr = string.Empty;
                return true;
            }
        }
    }
    public class CCDDataEntity
    {
        public string Code = string.Empty;
        public short SpecValue = 0;
        public bool IsMKCodeChange(string sCode)
        {
            return string.Compare(sCode, this.Code, true) != 0;
        }
    }
    public delegate void ShowMsgCallback(string sMsg);
    #region 读取版本信息
    public class Version
    {
        public static string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        public static string GetGuid()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attrs = ass.GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            Guid id = new Guid(((System.Runtime.InteropServices.GuidAttribute)attrs[0]).Value);
            return id.ToString();
        }
        public static string GetTitle()
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            object[] attributes = ass.GetCustomAttributes(typeof(System.Reflection.AssemblyTitleAttribute), false);
            System.Reflection.AssemblyTitleAttribute titleAttribute = (System.Reflection.AssemblyTitleAttribute)attributes[0];
            return titleAttribute.Title;
        }
        public static string GetStrForUpdate()
        {
            return GetGuid() + "|" + GetVersion();
        }

        public static void ContainGuids(List<string> list)
        {
            if (list == null)
                list = new List<string>();
            string str = GetStrForUpdate();
            if (!list.Contains(str))
                list.Add(str);

            Common.Version.ContainGuids(list);
        }
        public static List<Common.MyEntity.VersionEntity> GetCurrentVersions()
        {
            List<Common.MyEntity.VersionEntity> listV = new List<Common.MyEntity.VersionEntity>();
            List<string> listGuids = new List<string>();
            ContainGuids(listGuids);
            if (listGuids != null)
            {
                foreach (string str in listGuids)
                    listV.Add(new Common.MyEntity.VersionEntity(str));
            }
            return listV;
        }
    }
    #endregion
}

