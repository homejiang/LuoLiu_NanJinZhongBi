using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ErrorService;
using Common.MyEnums;
using AutoAssign.JPSEntity;

namespace AutoAssign.PeiFang
{
    public partial class frmPeiFangEdit : Common.frmBase
    {
        #region 窗体数据连接实例
        private BLLDAL.PeiFang _dal = null;
        /// <summary>
        /// 窗体数据连接实例
        /// </summary>
        public BLLDAL.PeiFang BllDAL
        {
            get
            {
                if (_dal == null)
                    _dal = new BLLDAL.PeiFang();
                return _dal;
            }
        }
        #endregion 
        public string _Guid = string.Empty;
        /// <summary>
        /// 标识是否已经更新了
        /// </summary>
        public bool _Updated = false;
        ModeView _TestMode = null;
        public frmPeiFangEdit()
        {
            InitializeComponent();
        }
        
        #region  处理函数
        private bool CheckUserPower()
        {
            if(!Common.CurrentUserInfo.IsAdmin)
            {
                this.ShowMsg("您不是管理员，不能操作。");
                return false;
            }
            return true;
        }
        #endregion
        #region 加载数据
        private bool Perinit()
        {
            _TestMode = new ModeView();
            //工艺师固定值
            this.comGongYiType.Items.Add("同工艺");
            this.comGongYiType.Items.Add("多工艺");
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_ProductClass where ISNULL(Terminated,0)=0", "JC_ProductClass"));
            //listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_ProductSpec where ISNULL(Terminated,0)=0", "JC_ProductSpec"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy("SELECT * FROM DBO.JC_Process where ISNULL(Terminated,0)=0", "JC_Process"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "基础数据加载");
                return false;
            }
            this.comProdctSpec.DisplayMember = "Text";
            this.comProcessCode.DisplayMember = "Text";
            foreach (DataRow dr in ds.Tables["JC_Process"].Rows)
            {
                this.comProcessCode.Items.Add(new Common.MyEntity.ComboBoxItem(dr["Code"].ToString(), dr["Code"].ToString()));
            }
            this.comProductClass.DisplayMember = "Text";
            foreach (DataRow dr in ds.Tables["JC_ProductClass"].Rows)
            {
                this.comProductClass.Items.Add(new Common.MyEntity.ComboBoxItem(dr["ClassName"].ToString(), dr["Value"].ToString()));
            }
            comGongYiType_SelectedIndexChanged(null, null);
            return true;
        }
        private bool BindData(string sGuid)
        {
            DataSet ds = null;
            List<Common.CommonDAL.SqlSearchEntiy> listSql = new List<Common.CommonDAL.SqlSearchEntiy>();
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM PeiFang_Main where GUID='{0}'", sGuid.Replace("'", "''")), "PeiFang_Main"));
            listSql.Add(new Common.CommonDAL.SqlSearchEntiy(string.Format("SELECT * FROM PeiFang_Grooves where GUID='{0}'", sGuid.Replace("'", "''")), "PeiFang_Grooves"));
            try
            {
                ds = Common.CommonDAL.DoSqlCommandBasic.GetDateSet(listSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "数据加载");
                return false;
            }
            DataRow dr;
            DataTable dt = ds.Tables["PeiFang_Main"];
            DataTable dtDetail = ds.Tables["PeiFang_Grooves"];
            if (ds.Tables["PeiFang_Main"].DefaultView.Count == 0)
            {
                if (sGuid.Length > 0)
                {
                    this.ShowMsg("传入的配方不存在或已经被删除。");
                    return false;
                }
                #region 主表添加一新行
                dr = dt.NewRow();
                //设置默认值
                dr["GUID"] = Guid.NewGuid().ToString(); ;
                DateTime detCreate;
                if (!Common.CommonFuns.GetSysCurrentDateTime(out detCreate))
                    return false;
                dr["CreateTime"] = detCreate;
                dr["Creater"] = Common.CurrentUserInfo.UserCode;
                dr["CreaterName"] = Common.CurrentUserInfo.UserName;
                dt.Rows.Add(dr);
                #endregion
            }
            else
            {
                //此时数据有获取，可能是编辑数据，也可能为复制数据
                if (this.FormState == FormStates.New || this.FormState == FormStates.Copy)
                {
                    //if(ds.GetChanges()!=null)
                    //    return false;//如果有修改过，是不允许复制的，但这种情况是不可能存在的，因为数据直接从服务器读取过来，不做任何修改
                    string strNewGuid = Guid.NewGuid().ToString();
                    #region 数据为拷贝
                    dt.Rows[0].SetAdded();//将改行设置为新增行
                    #region 设置主表默认数据
                    dt.Rows[0]["GUID"] = strNewGuid;
                    DateTime detCreate;
                    if (!Common.CommonFuns.GetSysCurrentDateTime(out detCreate))
                        return false;
                    dt.Rows[0]["CreateTime"] = detCreate;
                    dt.Rows[0]["Creater"] = Common.CurrentUserInfo.UserCode;
                    dt.DefaultView[0].Row["CreaterName"] = Common.CurrentUserInfo.UserName;
                    #endregion
                    #region 设置明细表信息
                    foreach (DataRow drtemp in dtDetail.Rows)
                    {
                        drtemp.SetAdded();
                        drtemp["GUID"] = strNewGuid;
                    }
                    #endregion
                    #endregion
                    //复制和新增状态统一设置为FromStates.New,系统加载后将不会再有copy状态
                    if (this.FormState == FormStates.Copy)
                    {
                        this.FormState = FormStates.New;
                        this._Guid = string.Empty;
                    }
                }
                dr = dt.DefaultView[0].Row;
            }
            this.tbPeiFangName.Text = dr["PeiFangName"].ToString();
            this.tbCreaterName.Text = dr["CreaterName"].ToString();
            this.tbCreateTime.Text = Common.CommonFuns.FormatData.GetStringByDateTime(dr["CreateTime"], "yyyy-MM-dd HH:mm");
            this._TestMode.ModeIsNeter = dr["ModeIsNeter"];
            this._TestMode.ModeIsScaner = dr["ModeIsScaner"];
            this.tbModeView.Text = JPSFuns.GetModeView(this._TestMode);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProcessCode, new Common.MyEntity.ComboBoxItem(string.Empty, dr["ProcessCode"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProductClass, new Common.MyEntity.ComboBoxItem(string.Empty, dr["ProductClassValue"].ToString()), 0);
            Common.CommonFuns.FormatData.SetComboBoxText(this.comProdctSpec, new Common.MyEntity.ComboBoxItem(string.Empty, dr["ProductSpec"].ToString()), 0);
            if (dr["GongYiType"].Equals(DBNull.Value)) this.comGongYiType.SelectedIndex = -1;
            else
            {
                int iGongYi = int.Parse(dr["GongYiType"].ToString());
                if (iGongYi == 1)
                    this.comGongYiType.SelectedIndex = 0;
                else if (iGongYi == 2)
                    this.comGongYiType.SelectedIndex = 1;
                else this.comGongYiType.SelectedIndex = -1;
            }
            this.chkTerminated.Checked = !dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"];
            //加载各槽数据
            if (!this.BindGrooves(dtDetail)) return false;
            this.DataSource = ds;
            return true;
        }
        private bool BindGrooves(DataTable dtDetail)
        {
            this.uc1.BindData(dtDetail);
            this.uc2.BindData(dtDetail);
            this.uc3.BindData(dtDetail);
            this.uc4.BindData(dtDetail);
            this.uc5.BindData(dtDetail);
            this.uc6.BindData(dtDetail);
            this.uc7.BindData(dtDetail);
            this.uc8.BindData(dtDetail);
            this.uc9.BindData(dtDetail);
            this.uc10.BindData(dtDetail);
            this.uc11.BindData(dtDetail);
            this.uc12.BindData(dtDetail);
            this.uc13.BindData(dtDetail);
            this.uc14.BindData(dtDetail);
            this.uc15.BindData(dtDetail);
            this.uc16.BindData(dtDetail);
            this.uc17.BindData(dtDetail);
            this.uc18.BindData(dtDetail);
            return true;
        }
        #endregion
        #region 保存数据
        private bool ReadForm(DataSet ds)
        {
            DataTable dtMain = ds.Tables["PeiFang_Main"];
            DataTable dtDetail = ds.Tables["PeiFang_Grooves"];
            if(dtMain.DefaultView.Count==0)
            {
                this.ShowMsg("主表数据返回了0行！");
                return false;
            }
            DataRow dr = dtMain.DefaultView[0].Row;
            if (this.tbPeiFangName.Text.Length==0)
            {
                this.ShowMsg("请输入配方名称");
                return false;
            }
            if (dr["PeiFangName"].ToString() != this.tbPeiFangName.Text)
            {
                #region 判断是否重号
                DataTable dtCheck;
                try
                {
                    dtCheck = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(string.Format("SELECT COUNT(*) FROM PeiFang_Main WHERE PeiFangName='{0}' AND GUID<>'{1}'"
                        , this.tbPeiFangName.Text.Replace("'", "''"), this._Guid.Replace("'", "''")));
                }
                catch(Exception ex)
                {
                    wErrorMessage.ShowErrorDialog1(this, ex, "校验配方名称");
                    return false;
                }
                if(int.Parse(dtCheck.Rows[0][0].ToString())>0)
                {
                    this.ShowMsg("配方名称已经存在，请更换。");
                    return false;
                }
                #endregion
                dr["PeiFangName"] = this.tbPeiFangName.Text;
            }
            if (this._TestMode.ModeIsNeter.Equals(DBNull.Value) || this._TestMode.ModeIsScaner.Equals(DBNull.Value))
            {
                this.ShowMsg("请明确测试模式。");
                return false;
            }
            if (!dr["ModeIsNeter"].Equals(this._TestMode.ModeIsNeter))
                dr["ModeIsNeter"] = this._TestMode.ModeIsNeter;
            if (!dr["ModeIsScaner"].Equals(this._TestMode.ModeIsScaner))
                dr["ModeIsScaner"] = this._TestMode.ModeIsScaner;
            Common.MyEntity.ComboBoxItem item = this.comProcessCode.SelectedItem as Common.MyEntity.ComboBoxItem;
            if(item==null || item.Value==null || item.Value.ToString().Length==0)
            {
                this.ShowMsg("请选择工序");
                return false;
            }
            if (dr["ProcessCode"].ToString() != item.Value.ToString())
                dr["ProcessCode"] = item.Value.ToString();

            item = this.comProductClass.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
            {
                this.ShowMsg("请选择产品分类");
                return false;
            }
            if (dr["ProductClassValue"].ToString() != item.Value.ToString())
                dr["ProductClassValue"] = item.Value.ToString();

            item = this.comProdctSpec.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
            {
                this.ShowMsg("请选择产品规格");
                return false;
            }
            if (dr["ProductSpec"].ToString() != item.Value.ToString())
                dr["ProductSpec"] = item.Value.ToString();
            if (this.comGongYiType.SelectedIndex == -1)
            {
                this.ShowMsg("请选择工艺。");
                return false;
            }
            short iGongYi;
            if (this.comGongYiType.SelectedIndex == 0) iGongYi = 1;
            else iGongYi = 2;
            if (dr["GongYiType"].ToString() != iGongYi.ToString())
                dr["GongYiType"] = iGongYi;

            if ((!dr["Terminated"].Equals(DBNull.Value) && (bool)dr["Terminated"])!=this.chkTerminated.Checked)
                dr["Terminated"] = this.chkTerminated.Checked;
            //读取明细
            string sErr;
            if (!this.uc1.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc2.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc3.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc4.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc5.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc6.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc7.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc8.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc9.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc10.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc11.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc12.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc13.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc14.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc15.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc16.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc17.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            if (!this.uc18.ReadForm(dtDetail, out sErr))
            {
                this.ShowMsg(sErr);
                return false;
            }
            //遍历明细主键
            foreach(DataRowView drv in dtDetail.DefaultView)
            {
                if (drv.Row["guid"].ToString() != dr["guid"].ToString())
                    drv.Row["guid"] = dr["guid"].ToString();
            }
            return true;
        }
        private bool Save()
        {
            if (this.DataSource == null)
            {
                this.ShowMsg("数据源为空，请重新加载数据！");
                return false;
            }
            DataSet dsCopy = this.DataSource.Copy();
            if (!this.ReadForm(dsCopy)) return false;
            if (dsCopy.GetChanges() == null) return true;
            try
            {
                this.BllDAL.SavePeiFang(dsCopy);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "SavePeifang");
                return false;
            }
            if (!this._Updated) this._Updated = true;
            this._Guid = dsCopy.Tables["PeiFang_Main"].DefaultView[0].Row["GUID"].ToString();
            return true;
        }
        #endregion

        private void frmPeiFangEdit_Load(object sender, EventArgs e)
        {
            if(!this.Perinit())
            {
                this.FormState = FormStates.None;
                return;
            }
            if (!this.BindData(this._Guid))
            {
                this.FormState = FormStates.None;
                return;
            }
        }
        #region 顶部工具条
        private void tsbSave_Click(object sender, EventArgs e)
        {
            if(this.FormState==FormStates.None)
            {
                this.ShowMsg("当前窗口状态无效。");
                return;
            }
            if (this.FormState == FormStates.Readonly)
            {
                this.ShowMsg("当前窗口状态为只读。");
                return;
            }
            if (!CheckUserPower()) return;
            if (!this.Save()) return;
            this.ShowMsgRich("保存成功。");
            this.BindData(this._Guid);
        }
        #endregion

        private void tsbNew_Click(object sender, EventArgs e)
        {
            if (!CheckUserPower()) return;
            this.FormState = FormStates.New;
            if (this.BindData(string.Empty))
            {
                this.ShowMsgRich("新建成功！");
                this._Guid= string.Empty;
                return;
            }
            else
            {
                //加载失败在窗口设为无效
                this.FormState = FormStates.None;
                return;
            }
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态无效。");
                return;
            }
            if (!CheckUserPower()) return;
            this.FormState = FormStates.Copy;
            if (this.BindData(this._Guid))
            {
                this.ShowMsgRich("复制成功！");
                return;
            }
            else
            {
                //加载失败在窗口设为无效
                this.FormState = FormStates.None;
                return;
            }
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            if (this.FormState == FormStates.None)
            {
                this.ShowMsg("当前窗口状态无效。");
                return;
            }
            if (!CheckUserPower()) return;
            if (!this.IsUserConfirm("您确定要删除吗？")) return;
            int iReturnValue;
            string strMsg;
            try
            {
                this.BllDAL.PeiFangDelete(this._Guid, out iReturnValue, out strMsg);
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog1(this, ex, "Delete PeiFang");
                return;
            }
            if(iReturnValue!=1)
            {
                if (strMsg.Length == 0) strMsg = "配方删除失败，原因未知。";
                this.ShowMsg(strMsg);
                return;
            }
            if (!this._Updated) this._Updated = true;
            this.FormColse();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.FormColse();
        }

        private void linkMode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BasicData.frmSelectMode frm = new BasicData.frmSelectMode();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            this._TestMode.ModeIsNeter = frm._ModeIsNeter;
            this._TestMode.ModeIsScaner = frm._ModeIsScaner;
            this.tbModeView.Text = JPSFuns.GetModeView(this._TestMode);
        }

        private void comGongYiType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.linkSettingKuaiJie.Visible = this.comGongYiType.SelectedIndex == 0;
        }

        private void comProductClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.comProductClass.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0) return;
            string strSql = string.Format("select * from JC_ProductSpec where ClassValue={0} ", item.Value.ToString());
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommandBasic.GetDateTable(strSql);
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return;
            }
            this.comProdctSpec.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                this.comProdctSpec.Items.Add(new Common.MyEntity.ComboBoxItem(dr["Spec"].ToString(), dr["guid"].ToString()));
            }
        }

        private void tsbKuaiJieSet_Click(object sender, EventArgs e)
        {

        }

        private void linkSettingKuaiJie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this.DataSource==null)
            {
                this.ShowMsg("数据源为空！");
                return;
            }
            frmGongYiSetting frm = new frmGongYiSetting();
            if (DialogResult.OK != frm.ShowDialog(this)) return;
            DataTable dtDetail = this.DataSource.Tables["PeiFang_Grooves"];
            string strErr;
            frm._MyGroove.GrooveNo = 1;
            if(!frm._MyGroove.ReadForm(dtDetail,out strErr))
            {
                this.ShowMsg(strErr);
                return;
            }
            for (short i = 2; i <= 18; i++)
            {
                frm._MyGroove.GrooveNo = i;
                frm._MyGroove.ReadForm(dtDetail, out strErr);
            }
            this.BindGrooves(dtDetail);
        }
    }
}
