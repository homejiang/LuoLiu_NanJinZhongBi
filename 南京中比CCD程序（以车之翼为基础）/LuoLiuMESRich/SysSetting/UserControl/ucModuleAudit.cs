using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace SysSetting.UserControl
{
    [Serializable]
    public partial class ucModuleAudit : System.Windows.Forms.UserControl
    {
        #region 事件

        #endregion
        public ucModuleAudit()
        {
            InitializeComponent();
        }
        #region 私有属性
        private List<ucModuleAuditItem> _objItems = null;
        /// <summary>
        /// 包含的ucModuleAuditItem子控件
        /// </summary>
        private List<ucModuleAuditItem> Items
        {
            get
            {
                if (this._objItems == null)
                    this._objItems = new List<ucModuleAuditItem>();
                return this._objItems;
            }
            set { this._objItems = value; }
        }
        #endregion
        #region 公共属性
        /// <summary>
        /// 审批流程集合
        /// </summary>
        public List<Common.MyEntity.ModuleAuditItem> AuditItems
        {
            get 
            {
                List<Common.MyEntity.ModuleAuditItem> items = new List<Common.MyEntity.ModuleAuditItem>();
                foreach (ucModuleAuditItem uc in this.Items)
                {
                    items.Add(uc.ModuleAuditItem);
                }
                return items;
            }
            set 
            {
                this.panItems.Controls.Clear();
                this.Items=null;
                if (value != null)
                {
                    for (int i = 0; i < value.Count; i++)
                    {
                        ucModuleAuditItem ucItem = new ucModuleAuditItem();
                        ucItem.Name = this.Name + "-Items-" + i.ToString();
                        ucItem.ModuleAuditItem = value[i];
                        ucItem.ModuleAuditItemEvent += new ModuleAuditItemEventHandler(ucItem_ModuleAuditItemEvent);
                        ucItem.Top = ucItem.Height * i;
                        this.panItems.Controls.Add(ucItem);
                        if (this.Items == null)
                            this.Items = new List<ucModuleAuditItem>();
                        this.Items.Add(ucItem);
                    }
                }
            }
        }
        private bool _blEditPower = false;
        /// <summary>
        /// 编辑权限
        /// </summary>
        public bool EditPower
        {
            get { return this._blEditPower; }
            set { this._blEditPower = value; }
        }
        #endregion
        #region 控件事件
        protected void ucItem_ModuleAuditItemEvent(OperateType type, int iSortID)
        {
            if(!this.EditPower)
            {
                this.ShowMsg("您没有编辑的权限。");
                return;
            }
            List<Common.MyEntity.ModuleAuditItem> listItem = this.AuditItems;
            if (type == OperateType.Up)
            {
                Common.MyEntity.ModuleAuditItem item1, item2;
                item1 = null;
                item2 = null;
                for (int i = 0; i < listItem.Count; i++)
                {
                    if (iSortID != listItem[i].SortID)
                        item1 = listItem[i];
                    else
                    {
                        item2 = listItem[i];
                        break;
                    }
                }
                if (item1 == null || item2 == null)
                    return;
                Common.MyEntity.ModuleAuditItem itemTemp = new Common.MyEntity.ModuleAuditItem();
                itemTemp.SortID = item1.SortID;
                itemTemp.WaitAuditers = item1.WaitAuditers;
                itemTemp.FlowName = item1.FlowName;
                item1.SortID = item2.SortID;
                item1.WaitAuditers = item2.WaitAuditers;
                item1.FlowName = item2.FlowName;
                item2.SortID = itemTemp.SortID;
                item2.WaitAuditers = itemTemp.WaitAuditers;
                item2.FlowName = itemTemp.FlowName;
                this.AuditItems = listItem;//重新绑定
            }
            else if (type == OperateType.Down)
            {
                Common.MyEntity.ModuleAuditItem item1, item2;
                item1 = null;
                item2 = null;
                for (int i = listItem.Count-1; i >= 0; i--)
                {
                    if (iSortID != listItem[i].SortID)
                        item1 = listItem[i];
                    else
                    {
                        item2 = listItem[i];
                        break;
                    }
                }
                if (item1 == null || item2 == null)
                    return;
                Common.MyEntity.ModuleAuditItem itemTemp = new Common.MyEntity.ModuleAuditItem();
                itemTemp.SortID = item1.SortID;
                itemTemp.WaitAuditers = item1.WaitAuditers;
                itemTemp.FlowName = item1.FlowName;
                item1.SortID = item2.SortID;
                item1.WaitAuditers = item2.WaitAuditers;
                item1.FlowName = item2.FlowName;
                item2.SortID = itemTemp.SortID;
                item2.WaitAuditers = itemTemp.WaitAuditers;
                item2.FlowName = itemTemp.FlowName;
                this.AuditItems = listItem;//重新绑定
            }
            else if (type == OperateType.Delete)
            {
                for (int i = 0; i < listItem.Count; i++)
                {
                    if (iSortID == listItem[i].SortID)
                    {
                        listItem.RemoveAt(i);
                        this.AuditItems = listItem;
                        break;
                    }
                }
            }
            else if (type == OperateType.SelectWaitAuditer)
            {
                //此时为选择待审批
                Common.MyEntity.ModuleAuditItem item = null;
                for (int i = 0; i < listItem.Count; i++)
                {
                    if (iSortID == listItem[i].SortID)
                    {
                        item = listItem[i];
                        break;
                    }
                }
                if (item == null)
                    return;
                SysSetting.DeptUsers.frmSelectUserSample frm = new SysSetting.DeptUsers.frmSelectUserSample();
                frm.SelectedUserCodes = item.WaitAuditers;
                if (DialogResult.OK != frm.ShowDialog(this))
                    return;
                item.WaitAuditers = frm.SelectedUserCodes;
                item.WaitAuditerNames = frm.SelectedUserNames;
                this.AuditItems = listItem;
            }
        }
        #endregion
        #region 公共方法
        public void AddItem()
        {
            //获取最大sortid
            List<Common.MyEntity.ModuleAuditItem> listItem = this.AuditItems;
            int iSortID;
            if (listItem == null || listItem.Count == 0)
                iSortID = 0;
            else
            {
                iSortID = listItem[listItem.Count - 1].SortID;
                iSortID++;
            }
            Common.MyEntity.ModuleAuditItem newitem = new Common.MyEntity.ModuleAuditItem();
            newitem.SortID = iSortID;
            listItem.Add(newitem);
            this.AuditItems = listItem;
        }
        #endregion
        public virtual void ShowMsg(string strMsg)
        {
            MessageBox.Show(this, strMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
