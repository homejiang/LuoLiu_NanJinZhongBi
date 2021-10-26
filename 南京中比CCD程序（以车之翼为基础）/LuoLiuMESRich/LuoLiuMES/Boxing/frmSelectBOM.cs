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

namespace LuoLiuMES.Boxing
{
    public partial class frmSelectBOM : Common.frmBase
    {
        public string _MyType = string.Empty;
        public int _MyYear = 0;
        public string _BOMGuid = string.Empty;
        public frmSelectBOM()
        {
            InitializeComponent();
        }
        private bool Perinit()
        {
            DataTable dt;
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable("SELECT * FROM JC_PackTypeCode where isnull(Terminated,0)=0");
            }
            catch(Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comMyType.DisplayMember = "Text";
            this.comMyType.Items.Add(new Common.MyEntity.ComboBoxItem("无", string.Empty));
            foreach (DataRow dr in dt.Rows)
            {
                this.comMyType.Items.Add(new Common.MyEntity.ComboBoxItem(dr["CodeName"].ToString(), dr["Code"].ToString()));
            }
            //添加年份
            this.comMyYear.Items.Clear();
            this.comMyYear.Items.Add("1");
            this.comMyYear.Items.Add("2");
            this.comMyYear.Items.Add("3");
            this.comMyYear.Items.Add("4");
            this.comMyYear.Items.Add("5");
            //添加BOM结构
            try
            {
                dt = Common.CommonDAL.DoSqlCommand.GetDateTable(@"SELECT B.GUID,B.Spec,C.VersionNo
                    FROM Produce_SFG3 A LEFT JOIN BOM_Product B ON B.GUID = A.BOMGuid
                    LEFT JOIN BOM_Sys_Version C ON C.ID = B.VersionID
                    GROUP BY B.GUID,B.Spec, C.VersionNo");
            }
            catch (Exception ex)
            {
                wErrorMessage.ShowErrorDialog(this, ex);
                return false;
            }
            this.comBOM.DisplayMember = "Text";
            this.comBOM.Items.Add(new Common.MyEntity.ComboBoxItem("无", string.Empty));
            foreach (DataRow dr in dt.Rows)
            {
                string str = string.Format("{0}(版本:{1})", dr["Spec"].ToString(), dr["VersionNo"]);
                this.comBOM.Items.Add(new Common.MyEntity.ComboBoxItem(str, dr["GUID"].ToString()));
            }
            return true;
        }
        private bool BindData()
        {
            Common.MyEntity.ComboBoxItem item;
            int iSel;
            if(_MyType.Length>0)
            {
                iSel = -1;
                for(int i=0;i<this.comMyType.Items.Count;i++)
                {
                    item = this.comMyType.Items[i] as Common.MyEntity.ComboBoxItem;
                    if (item == null)
                        continue;
                    if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                        continue;
                    if (string.Compare(_MyType, item.Value.ToString(), true) != 0) continue;
                    iSel = i;
                    break;
                }
                this.comMyType.SelectedIndex = iSel;
            }
            if (this._MyYear > 0)
                this.comMyYear.Text = this._MyYear.ToString();
            if(this._BOMGuid.Length>0)
            {
                iSel = -1;
                for (int i = 0; i < this.comBOM.Items.Count; i++)
                {
                    item = this.comBOM.Items[i] as Common.MyEntity.ComboBoxItem;
                    if (item == null)
                        continue;
                    if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                        continue;
                    if (string.Compare(this._BOMGuid, item.Value.ToString(), true) != 0) continue;
                    iSel = i;
                    break;
                }
                if (iSel == -1)
                {
                    //此时没有则重新添加
                    DataTable dt;
                    try
                    {
                        dt = Common.CommonDAL.DoSqlCommand.GetDateTable(string.Format(@"SELECT GUID,Spec,C.VersionNo FROM
                BOM_Product B LEFT JOIN BOM_Sys_Version C ON C.ID = B.VersionID
                where b.guid = '{0}'", this._BOMGuid.Replace("'", "''")));
                    }
                    catch (Exception ex)
                    {
                        wErrorMessage.ShowErrorDialog(this, ex);
                        return false;
                    }
                    if (dt.Rows.Count > 0)
                    {
                        string str = string.Format("{0}(版本:{1})", dt.Rows[0]["Spec"].ToString(), dt.Rows[0]["VersionNo"]);
                        iSel = this.comBOM.Items.Add(new Common.MyEntity.ComboBoxItem(str, dt.Rows[0]["GUID"].ToString()));
                    }
                }
                this.comBOM.SelectedIndex = iSel;
            }
            return true;
        }

        private void frmSelectBOM_Load(object sender, EventArgs e)
        {
            Perinit();
            this.BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.MyEntity.ComboBoxItem item = this.comMyType.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                this._MyType = string.Empty;
            else this._MyType = item.Value.ToString();
            if (this.comMyYear.Text.Length == 0)
                this._MyYear = 0;
            else
            {
                if (!int.TryParse(this.comMyYear.Text, out this._MyYear))
                {
                    this.ShowMsg("\"" + this.comMyYear.Text + "\"不是有效的整数");
                    return;
                }
            }
            item = this.comBOM.SelectedItem as Common.MyEntity.ComboBoxItem;
            if (item == null || item.Value == null || item.Value.ToString().Length == 0)
                this._BOMGuid = string.Empty;
            else this._BOMGuid = item.Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
