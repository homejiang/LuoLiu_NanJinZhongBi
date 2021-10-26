using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ErrorService;

namespace LuoLiuMES
{
    public partial class mdiMyERP : Common.frmMdiBase
    {
        public static string _DesignGuidFromParent = string.Empty;
        public mdiMyERP()
        {
            InitializeComponent();
        }
        #region 私有属性
        /// <summary>
        /// 当前使用的设计方案
        /// </summary>
        private string _DesignGuid = string.Empty;
        #endregion
        private void mdiLuoLiuMES_Load(object sender, EventArgs e)
        {
            this._TabControl = this.tabControl1;
            this._PictureBox = this.pictureBox1;
            this.系统自动以ToolStripMenuItem.Visible = Common.CurrentUserInfo.IsSuper;
            this.系统预定义方案ToolStripMenuItem.Visible = Common.CurrentUserInfo.IsAdmin || Common.CurrentUserInfo.IsSuper;
            #region 设置当前登录信息
            #endregion
            if (_DesignGuidFromParent != string.Empty)
            {
                if (BindDesign(_DesignGuidFromParent))
                    _DesignGuid = _DesignGuidFromParent;
                else return;
            }
            else
            {
                if (!BindDesign()) return;
            }
            if (!BindDesignList()) return;
            if (!BindMsg()) return;
        }
        #region 加载应用方案
        private bool BindDesign()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("EXEC AutoExe_User_GetDefaultDesgin '{0}'"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            string strGuid=dt.Rows[0]["GUID"].ToString();
            if (strGuid == string.Empty)
            {
                if (Common.CurrentUserInfo.UserCode != string.Empty && this.IsUserConfirm("在您的账户下未找到任何一个应用设计方案，请问现在创建吗？"))
                {
                    AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
                    frm._UserCode = Common.CurrentUserInfo.UserCode;
                    frm.ShowDialog(this);
                    strGuid = frm.PrimaryValue == null ? string.Empty : frm.PrimaryValue.ToString();
                    if (strGuid != string.Empty)
                        BindDesignList();
                }
            }
            if (!this.BindDesign(strGuid))
            {
                return false;
            }
            this._DesignGuid = strGuid;
            return true;
        }
        private bool BindDesign(string sGuid)
        {
            bool blTb;
            string strName=string.Empty;
            #region 校验是否是同步方案
            DataTable dttb;
            try
            {
                dttb = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT DesignName,TongBuGuid FROM AutoExe_User_Designs WHERE GUID='{0}'"
                    , sGuid.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (dttb.Rows.Count>0 && dttb.Rows[0]["TongBuGuid"].ToString() != string.Empty)
            {
                blTb = true;
                sGuid = dttb.Rows[0]["TongBuGuid"].ToString();
            }
            else
            {
                blTb = false;
            }
            if (dttb.Rows.Count > 0)
                strName = dttb.Rows[0]["DesignName"].ToString();
            #endregion
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT GUID,DesignName FROM AutoExe_User_Designs WHERE GUID='{0}'",
                sGuid.Replace("'", "''")), "AutoExe_User_Designs"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT GUID,GroupName,IsExpand FROM AutoExe_User_Group WHERE DesignGuid='{0}' ORDER BY SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Group"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT A.ID,A.GroupGuid,A.SortID,A.FormCode,A.FormName,A.ForeColor,A.Underline,A.FontBold FROM AutoExe_User_Forms A LEFT JOIN AutoExe_User_Group B ON B.GUID=A.GroupGuid WHERE B.DesignGuid='{0}' ORDER BY A.SortID ASC",
                sGuid.Replace("'", "''")), "AutoExe_User_Forms"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            if (sGuid != string.Empty && ds.Tables["AutoExe_User_Designs"].Rows.Count == 0)
            {
                this.ShowMsg("传入的应用设计方案不存在或已经作废！");
                return false;
            }
            DataTable dtGroup = ds.Tables["AutoExe_User_Group"];
            DataTable dtForm = ds.Tables["AutoExe_User_Forms"];
            int iCount = dtGroup.Rows.Count - this.explorerBar1.Groups.Count;
            DevComponents.DotNetBar.ExplorerBarGroupItem group;
            DevComponents.DotNetBar.ButtonItem button;
            if (iCount > 0)
            {
                //添加新的组
                for (int i = 0; i < iCount; i++)
                {
                    group = new DevComponents.DotNetBar.ExplorerBarGroupItem();
                    #region 设置基本样式
                    group.BackStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
                    group.BackStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    group.BackStyle.BorderBottomColor = System.Drawing.SystemColors.Window;
                    group.BackStyle.BorderBottomWidth = 1;
                    group.BackStyle.BorderColor = System.Drawing.Color.White;
                    group.BackStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    group.BackStyle.BorderLeftColor = System.Drawing.SystemColors.Window;
                    group.BackStyle.BorderLeftWidth = 1;
                    group.BackStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    group.BackStyle.BorderRightColor = System.Drawing.SystemColors.Window;
                    group.BackStyle.BorderRightWidth = 1;
                    group.BackStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
                    group.BackStyle.BorderTopColor = System.Drawing.SystemColors.Window;
                    group.BackStyle.BorderTopWidth = 1;
                    group.Cursor = System.Windows.Forms.Cursors.Hand;
                    group.Expanded = true;
                    group.Name = "myGroup" + this.explorerBar1.Groups.Count.ToString();
                    group.StockStyle = DevComponents.DotNetBar.eExplorerBarStockStyle.SystemColors;
                    #endregion
                    this.explorerBar1.Groups.Add(group);
                }
            }
            else if (iCount < 0)
            {
                while (this.explorerBar1.Groups.Count > dtGroup.Rows.Count)
                {
                    group = this.explorerBar1.Groups[this.explorerBar1.Groups.Count - 1] as DevComponents.DotNetBar.ExplorerBarGroupItem;
                    for (int i = group.SubItems.Count; i > 0; i--)
                    {
                        button = group.SubItems[i - 1] as DevComponents.DotNetBar.ButtonItem;
                        group.SubItems.Remove(button);
                        button.Dispose();
                        button = null;
                    }
                    this.explorerBar1.Groups.Remove(group);
                    group.Dispose();
                    group = null;
                }
            }
            DataRow drGroup;
            DataRow[] drForms;
            for (int i = 0; i < dtGroup.DefaultView.Count; i++)
            {
                drGroup = dtGroup.DefaultView[i].Row;
                group = this.explorerBar1.Groups[i] as DevComponents.DotNetBar.ExplorerBarGroupItem;
                group.Text = drGroup["GroupName"].ToString();
                group.Expanded = !drGroup["IsExpand"].Equals(DBNull.Value) && (bool)drGroup["IsExpand"];
                #region 处理窗体
                drForms = dtForm.Select("GroupGuid='" + drGroup["GUID"].ToString() + "'", "SortID ASC");
                while (group.SubItems.Count < drForms.Length)
                {
                    button = new DevComponents.DotNetBar.ButtonItem();
                    #region 设置按钮基本样式
                    button.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways;
                    button.Cursor = System.Windows.Forms.Cursors.Hand;
                    //button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
                    button.HotFontUnderline = true;
                    button.HotForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(142)))), ((int)(((byte)(255)))));
                    button.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.None;
                    button.ImagePaddingHorizontal = 8;
                    button.Name = "mybt-" + group.Name + "-" + group.SubItems.Count.ToString();
                    button.Click += new EventHandler(buttonItem_Click);
                    #endregion
                    group.SubItems.Add(button);
                }
                while (group.SubItems.Count > drForms.Length)
                {
                    button = group.SubItems[group.SubItems.Count - 1] as DevComponents.DotNetBar.ButtonItem;
                    group.SubItems.Remove(button);
                    button.Dispose();
                    button = null;
                }
                for (int j = 0; j < drForms.Length; j++)
                {
                    button = group.SubItems[j] as DevComponents.DotNetBar.ButtonItem;
                    button.Text = drForms[j]["FormName"].ToString();
                    if (drForms[j]["ForeColor"].ToString() != string.Empty)
                        button.ForeColor = ColorTranslator.FromHtml(drForms[j]["ForeColor"].ToString());
                    else button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(93)))), ((int)(((byte)(198)))));
                    button.FontUnderline = !drForms[j]["Underline"].Equals(DBNull.Value) && (bool)drForms[j]["Underline"];
                    button.FontBold = !drForms[j]["FontBold"].Equals(DBNull.Value) && (bool)drForms[j]["FontBold"];
                    button.HotForeColor = button.ForeColor;
                    button.HotFontBold = button.FontBold;
                    button.HotFontUnderline = button.FontUnderline;
                    button.Tag = drForms[j]["FormCode"].ToString();
                }
                #endregion
            }
            explorerBar1.Refresh();//强制重汇子件
            #region 设置状态栏文本
            string strUserType;
            if (Common.CurrentUserInfo.IsSuper)
                strUserType = "超级管理员";
            else if (Common.CurrentUserInfo.IsAdmin)
                strUserType = "管理员";
            else strUserType = "普通用户";
            if (ds.Tables["AutoExe_User_Designs"].Rows.Count > 0)
            {
                DataRow drDesign = ds.Tables["AutoExe_User_Designs"].Rows[0];
                
                this.tsLabel.Text = string.Format("版本号：{0}  登录用户：{1}  所在部门：{2}  账户类型：{3}  应用设计方案：{4}"
                    , System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                , Common.CurrentUserInfo.UserName, Common.CurrentUserInfo.DeptFullName, strUserType, strName);
            }
            else
            {
                this.tsLabel.Text = string.Format("版本号：{0}  登录用户：{1}  所在部门：{2}  账户类型：{3}  应用设计方案：未加载"
                    , System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                , Common.CurrentUserInfo.UserName, Common.CurrentUserInfo.DeptFullName, strUserType);
            }

            #endregion
            return true;
        }
        private void buttonItem_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonItem button = sender as DevComponents.DotNetBar.ButtonItem;
            if (button == null || button.Tag == null || button.Tag.ToString() == string.Empty)
            {
                this.ShowMsg("控件参数丢失！");
                return;
            }
            DataSet ds;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT ClassName,ProjectName,CheckPower,UserLevel,IsMulti,DialogType,OpenedName FROM AutoExe_Sys_Forms where Code='{0}'",
                button.Tag.ToString().Replace("'", "''")), "AutoExe_Sys_Forms"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT PValue FROM AutoExe_Sys_Parameters WHERE FormCode='{0}' ORDER BY [ID] ASC",
                button.Tag.ToString().Replace("'", "''")), "AutoExe_Sys_Parameters"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT EnumNo,Powers FROM AutoExe_Sys_PowerList WHERE FormCode='{0}' ORDER BY [ID] ASC",
                button.Tag.ToString().Replace("'", "''")), "AutoExe_Sys_PowerList"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommand.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            DataTable dtForm = ds.Tables["AutoExe_Sys_Forms"];
            DataTable dtParameter = ds.Tables["AutoExe_Sys_Parameters"];
            DataTable dtPower = ds.Tables["AutoExe_Sys_PowerList"];
            if (dtForm.Rows.Count == 0)
            {
                this.ShowMsg("当前窗体已经被移除。(Code:" + button.Tag.ToString() + ")");
                return;
            }
            DataRow drForm = dtForm.Rows[0];
            #region 校验权限
            int iUserLevel;
            bool blPass = false;
            if (!int.TryParse(drForm["UserLevel"].ToString(), out iUserLevel))
                iUserLevel = 0;//未设置就是普通用户
            if (iUserLevel == 2)
            {
                if (!Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("此模块只有开发员才有权限。");
                    return;
                }
                else blPass=true;
            }
            else if (iUserLevel == 1)
            {
                if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
                {
                    this.ShowMsg("此模块只有管理员才有权限。");
                    return;
                }
                else blPass=true;
            }
            else
            {
                //普通用户的话需要校验权限
                if (!drForm["CheckPower"].Equals(DBNull.Value) && (bool)drForm["CheckPower"])
                {
                    int iEnumNo;
                    List<Common.MyEnums.OperatePower> listPower;
                    foreach (DataRowView drv in dtPower.DefaultView)
                    {
                        if (!int.TryParse(drv.Row["EnumNo"].ToString(), out iEnumNo))
                        {
                            this.ShowMsg("模块枚举值设置出错，请联系系统管理员补充完整。");
                            continue;
                        }
                        listPower = this.GetOperatePower((Common.MyEnums.Modules)iEnumNo);
                        if (listPower.Count == 0)
                        {
                            this.ShowMsg("您没有此模块的任何权限。");
                            continue;
                        }
                        if (drv.Row["Powers"].ToString() != string.Empty && drv.Row["Powers"].ToString().IndexOf("查看") < 0)
                        {
                            //当不设置查看权限的话，就需要用户有其他权限，这个需要根据后台设置的来校验
                            if (drv.Row["Powers"].ToString().IndexOf("新增") >= 0)
                            {
                                if (listPower.Contains(Common.MyEnums.OperatePower.New))
                                {
                                    blPass = true;
                                    break;
                                }
                            }
                            if (drv.Row["Powers"].ToString().IndexOf("编辑") >= 0)
                            {
                                if (listPower.Contains(Common.MyEnums.OperatePower.Eidt))
                                {
                                    blPass = true;
                                    break;
                                }
                            }
                            if (drv.Row["Powers"].ToString().IndexOf("删除") >= 0)
                            {
                                if (listPower.Contains(Common.MyEnums.OperatePower.Delete))
                                {
                                    blPass = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            blPass = true;
                            break;
                        }
                    }
                }
                else blPass = true;//无效校验权限
            }
            #endregion
            if (blPass)
            {
                #region 打开连接
                if (drForm["ClassName"].ToString() == string.Empty || drForm["ProjectName"].ToString() == string.Empty)
                {
                    this.ShowMsg("连接地址为空，请立即联系管理员。");
                    return;
                }
                Type t = System.Type.GetType(string.Format("{0},{1}", drForm["ClassName"].ToString(), drForm["ProjectName"].ToString()));
                if (t == null)
                {
                    this.ShowMsg("目标地址为空，请立即联系管理员。");
                    return;
                }
                object objReturn = System.Activator.CreateInstance(t);
                if (objReturn == null)
                {
                    this.ShowMsg("创建窗体失败，请立即联系管理员。");
                    return;
                }
                Common.frmBase frm = objReturn as Common.frmBase;
                if (dtParameter.DefaultView.Count > 0)
                {
                    //设置传入参数
                    string[] arr = new string[dtParameter.DefaultView.Count];
                    for (int i = 0; i < dtParameter.DefaultView.Count; i++)
                    {
                        arr[i] = dtParameter.DefaultView[i].Row["PValue"].ToString();
                    }
                    frm.InitParameters(arr);
                }
                //设置窗体标题
                if (drForm["OpenedName"].ToString() != string.Empty)
                    frm.Text = drForm["OpenedName"].ToString();
                //打开方式
                int iDialogType;
                if (!int.TryParse(drForm["DialogType"].ToString(), out iDialogType))
                    iDialogType = 0;//默认为普通打开方式
                if (iDialogType == 0)
                {
                    bool blMuitl = !drForm["IsMulti"].Equals(DBNull.Value) && (bool)drForm["IsMulti"];
                    this.ShowChildForm(frm.Text, frm, blMuitl);
                }
                else if (iDialogType == 1)
                {
                    frm.Show(this);
                }
                else if (iDialogType == 2)
                {
                    frm.ShowDialog(this);
                }
                #endregion
            }
        }
        private bool BindDesignList()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT GUID,DesignName FROM AutoExe_User_Designs WHERE UserCode='{0}' ORDER BY DesignName ASC"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            while (dt.DefaultView.Count > this.tsbNewExe.DropDownItems.Count)
            {
                System.Windows.Forms.ToolStripMenuItem childItem = new ToolStripMenuItem();
                childItem.Click += new EventHandler(NewExeItem_Click);
                this.tsbNewExe.DropDownItems.Add(childItem);
            }
            while (dt.DefaultView.Count < this.tsbNewExe.DropDownItems.Count)
            {
                ToolStripItem item = this.tsbNewExe.DropDownItems[this.tsbNewExe.DropDownItems.Count - 1];
                this.tsbNewExe.DropDownItems.Remove(item);
                item.Dispose();
                item = null;
            }
            for (int i = 0; i < dt.DefaultView.Count; i++)
            {
                this.tsbNewExe.DropDownItems[i].Text = dt.DefaultView[i].Row["DesignName"].ToString();
                this.tsbNewExe.DropDownItems[i].Tag = dt.DefaultView[i].Row["GUID"].ToString();
            }
            return true;
        }
        #endregion
        #region 文件
        protected void NewExeItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem item = sender as System.Windows.Forms.ToolStripMenuItem;
            if (item == null || item.Tag == null || item.Tag.ToString().Length == 0)
            {
                this.ShowMsg("参数获取失败。");
                return;
            }
            string strFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "LuoLiuMES.exe";
            if (!System.IO.File.Exists(strFile))
            {
                this.ShowMsg("未找到启动程序LuoLiuMES.exe。");
                return;
            }
            string strArg = string.Format("<DesignGuidFromParent>{0}</DesignGuidFromParent><UserCode>{1}</UserCode>"
                , item.Tag.ToString(), Common.CurrentUserInfo.UserCode);
            while (strArg.IndexOf(" ") >= 0)
            {
                strArg = strArg.Replace(" ", "[blank]");
            }
            try
            {
                System.Diagnostics.Process.Start(strFile, strArg);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
        }
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要退出程序吗？")) return;
            Application.Exit();
        }
        #endregion
        #region 用户应用方案
        private void 编辑其他应用方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserDesignList frm = new LuoLiuMES.AutoExe.frmUserDesignList();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            if (frm._DesignGuid == string.Empty) return;
            if(this.BindDesign(frm._DesignGuid))
                this._DesignGuid = frm._DesignGuid;
            BindDesignList();
        }
        private void 编辑当前应用方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_DesignGuid == string.Empty)
            {
                if (!this.IsUserConfirm("当前还未加载设计方案，请问现在添加一个吗？")) return;
                AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
                frm.PrimaryValue = string.Empty;
                frm.ShowDialog(this);
                this.BindDesign();
            }
            else
            {
                bool blTb;
                DataTable dtTb;
                try
                {
                    dtTb = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format("SELECT TongBuGuid FROM AutoExe_User_Designs WHERE GUID='{0}'"
                        , _DesignGuid.Replace("'", "''")));
                }
                catch (Exception ex)
                {
                    wErrorMessage.ShowErrorDialog(this, ex);
                    return;
                }
                if (dtTb.Rows.Count == 0)
                {
                    this.ShowMsg("方案获取失败，可能已被删除。");
                    return;
                }
                if (dtTb.Rows[0]["TongBuGuid"].ToString() == string.Empty)
                {
                    AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
                    frm._UserCode = Common.CurrentUserInfo.UserCode;
                    frm.PrimaryValue = _DesignGuid;
                    frm.ShowDialog(this);
                    this.BindDesign(_DesignGuid);
                }
                else
                {
                    AutoExe.frmUserTongbu frm = new LuoLiuMES.AutoExe.frmUserTongbu();
                    frm._UserCode = Common.CurrentUserInfo.UserCode;
                    frm.PrimaryValue = _DesignGuid;
                    if (DialogResult.OK == frm.ShowDialog(this))
                        this.BindDesign(_DesignGuid);
                }
            }
        }
        private void 刷新界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BindDesign(_DesignGuid);
        }
        

        private void 系统自动以ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有开发员才有权限");
                return;
            }
            AutoExe.frmSysForms frm = new LuoLiuMES.AutoExe.frmSysForms();
            this.ShowChildForm(frm.Text, frm);
        }

        private void 系统预定义方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.IsAdmin && !Common.CurrentUserInfo.IsSuper)
            {
                this.ShowMsg("只有管理员才有权限");
                return;
            }
            AutoExe.frmYdyDesignList frm = new LuoLiuMES.AutoExe.frmYdyDesignList();
            frm.ShowDialog(this);
        }

        private void 自定义ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserForms frm = new LuoLiuMES.AutoExe.frmUserForms();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog(this);
            if (frm.PrimaryValue != null && frm.PrimaryValue.ToString() != string.Empty)
                BindDesignList();
        }

        private void 与预定义方案同步ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoExe.frmUserTongbu frm = new LuoLiuMES.AutoExe.frmUserTongbu();
            frm._UserCode = Common.CurrentUserInfo.UserCode;
            frm.PrimaryValue = string.Empty;
            if (DialogResult.OK == frm.ShowDialog(this))
                BindDesignList();
        }
        #endregion
        #region 用户
        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strUser = Common.CurrentUserInfo.UserCode;
            Common.Login.frmLogin frmlogin1 = new Common.Login.frmLogin();
            if (DialogResult.OK != frmlogin1.ShowDialog(this))
                return;
            if (strUser != Common.CurrentUserInfo.UserCode)
            {
                this.BindDesign();
                BindMsg();
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.IsUserConfirm("您确定要注销吗？")) return;
            Common.CurrentUserInfo.Logout();
            this.BindDesign();
            BindMsg();
        }

        private void 修改登录密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Common.CurrentUserInfo.UserCode == string.Empty) return;
            Common.Login.frmModifyPwd frm = new Common.Login.frmModifyPwd();
            frm.UserCode = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog(this);
        }

        private void 查看当前登录信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region 帮助
        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.CommonFuns.SysHelp();
        }
        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Common.CommonFuns.StartUpdate(new string[] { }, Version.GetCurrentVersions());
        }
        #endregion
        #region 加载消息信息
        private bool BindMsg()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandLog.GetDateTable(string.Format("SELECT * FROM Msg_Sys_MySeting WHERE userCode='{0}'"
                    , Common.CurrentUserInfo.UserCode.Replace("'", "''")));
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return true;
            }
            bool blRemove = true;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (!dr["MainIsReceive"].Equals(DBNull.Value) && (bool)dr["MainIsReceive"])
                {
                    bool blIsAuto = !dr["MainIsAuto"].Equals(DBNull.Value) && (bool)dr["MainIsAuto"];
                    int iInterval = 0;
                    if (blIsAuto)
                    {
                        if (!int.TryParse(dr["MainInterval"].ToString(), out iInterval))
                            iInterval = 0;
                    }
                    Common.Msg.frmMsgList myMsg = new Common.Msg.frmMsgList();
                    myMsg._AutoRefrehs = blIsAuto;
                    if (blIsAuto)
                        myMsg._RefreshInterval = iInterval * 1000;
                    this.ShowMainForm(myMsg.Text, myMsg);
                    blRemove = false;
                    this.消息列表ToolStripMenuItem.Visible = false;
                }
            }
            if (blRemove)
            {
                if (this._TabControl.TabPages.Count > 0)
                {
                    System.Windows.Forms.TabPage tab = this._TabControl.TabPages[0];
                    if (tab.Controls.Count > 0)
                    {
                        Common.Msg.frmMsgList frmtmp = tab.Controls[0] as Common.Msg.frmMsgList;
                        if (frmtmp != null)
                        {
                            tab.Controls.Remove(frmtmp);
                            frmtmp.Close();
                            frmtmp.Dispose();
                            frmtmp = null;
                        }
                    }
                }
                this.消息列表ToolStripMenuItem.Visible = true;
            }
            return true;
        }
        #endregion
        private void 所有用户应用方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoExe.frmDesignList frm = new LuoLiuMES.AutoExe.frmDesignList();
            this.ShowChildForm(frm.Text, frm);
        }

        private void 接收消息设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            Common.Msg.frmReceiveSetting frm = new Common.Msg.frmReceiveSetting();
            frm.PrimaryValue = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog();
        }

        private void 自定义信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Common.CurrentUserInfo.CheckLogin()) return;
            Common.Msg.frmMySetting frm = new Common.Msg.frmMySetting();
            frm.PrimaryValue = Common.CurrentUserInfo.UserCode;
            frm.ShowDialog();
        }

        private void 消息列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Msg.frmMsgList1 frm = new Common.Msg.frmMsgList1();
            this.ShowChildForm(frm.Text, frm);
        }

        private void 已删除消息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Common.Msg.frmMsgRecycleList frm = new Common.Msg.frmMsgRecycleList();
            this.ShowChildForm(frm.Text, frm);
        }

        private void 系统版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVersion frm = new frmVersion();
            frm.Show();
        }

        private void 意见反馈ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_DoubleClick(object sender, EventArgs e)
        {
            value_Click(null, null);
        }
    }
}
