using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public partial class frmBaseEdit : frmBase
    {
        public frmBaseEdit()
        {
            InitializeComponent();
        }
        public string mMyFormName;
        public string MyFormName
        {
            get { return this.mMyFormName; }
            set { this.mMyFormName = value; }
        }
        public virtual string SetMyFormText(string sCode, Common.MyEnums.FormStates formState)
        {
            string strText = string.Empty;
            if (formState == Common.MyEnums.FormStates.Readonly)
            {
                strText = string.Format("{0}{1}(ֻ��)", this.MyFormName, sCode);
            }
            else if (formState == Common.MyEnums.FormStates.None)
            {
                strText = string.Format("{0}{1}(����ʧ��)", this.MyFormName, sCode);
            }
            else if (formState == Common.MyEnums.FormStates.Edit)
            {
                strText = string.Format("{0}{1}", this.MyFormName, sCode);
            }
            else if (formState == Common.MyEnums.FormStates.New || formState == Common.MyEnums.FormStates.Copy)
            {
                strText = string.Format("�½�_{0}", this.MyFormName);
            }
            this.ChangeWinTitle(strText);
            return strText;
        }
        /// <summary>
        /// ���ô��ڱ��⣬����״̬Ϊ��this.FormState
        /// </summary>
        public string SetMyFormText(string sCode)
        {
            return this.SetMyFormText(sCode, this.FormState);
        }
        /// <summary>
        /// ���ô��ڱ��⣬�ؼ����Ϊthis.PrimaryValue������״̬Ϊ��this.FormState
        /// </summary>
        public string SetMyFormText()
        {
            return this.SetMyFormText(this.PrimaryValue == null ? string.Empty : this.PrimaryValue.ToString());
        }
    }
}