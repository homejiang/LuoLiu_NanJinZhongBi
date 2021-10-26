using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuoLiuMES.ProduceMoKuai
{
    public partial class frmProMkMain : Common.frmProduceBase
    {
        public frmProMkMain()
        {
            InitializeComponent();
            this.dgvList.AutoGenerateColumns = false;
        }
        private bool BindData()
        {
            this.tbDxCnt.Text = "96";
            this.tbStateView.Text = "待绑定模块号";
            this.tbPlanDetail.Text = "生产计划号:190425-001，订单编号:Gp0091-0013，计划量300个模块(96-23*54*23)，当前已完成190个。";
            this.tbBOMDesc.Text = "BOM规格：96-23*54*23，所需电芯数量：96，电芯规格：φ17mm";
            this.tbMkCode.Text = "MK-190420-001";
            DataTable dt = new DataTable();
            dt.Columns.Add("SN", Type.GetType("System.String"));
            dt.Columns.Add("Dz", Type.GetType("System.Decimal"));
            dt.Columns.Add("V", Type.GetType("System.Decimal"));
            string strCode;
            Random ran1 = new Random(1);
            for (int i=1;i<=96;i++)
            {
                strCode = i.ToString();
                if (strCode.Length == 1)
                    strCode = "000000" + strCode;
                else strCode = "00000" + strCode;
                
                decimal decDz = (decimal)(ran1.Next()*i) / 10000M;
                Random ran2 = new Random(1);
                decimal decV = (decimal)(ran1.Next() * (i+30)) / 10000M;
                DataRow drNew = dt.NewRow();
                drNew["SN"] = strCode;
                drNew["Dz"] = Math.Abs(decDz);
                drNew["V"] = Math.Abs(decV);
                dt.Rows.Add(drNew);
            }
            this.dgvList.DataSource = dt;
            return true;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbTuoPan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13) return;
            btRead_Click(null, null);
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            if (this.tbTuoPan.Text.Length == 0) return;
            this.BindData();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

        }
    }
}
