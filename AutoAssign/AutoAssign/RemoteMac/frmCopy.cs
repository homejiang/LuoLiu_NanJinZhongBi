using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoAssign.RemoteMac
{
    public partial class frmCopy : Common.frmBase
    {
        JPSEntity.MyPing _MyPing = null;
        public JPSEntity.RemoteSNCopyControler _RemoteSNCopyControler = null;
        public frmCopy()
        {
            InitializeComponent();
            this._MyPing = new JPSEntity.MyPing(this, JPSConfig.RemoteMacConfig._IP1, JPSConfig.RemoteMacConfig._IP2, JPSConfig.RemoteMacConfig._IP3);
            _MyPing.MyPingFinishedNotice += _MyPing_MyPingFinishedNotice;
        }

        private void _MyPing_MyPingFinishedNotice(short iIndex, bool blSucessfully)
        {
            UserControls.ucCopySNProgress uc = null;
            if(iIndex==1)
            {
                uc = this.ucCopySNProgress1;
            }
            else if (iIndex == 2)
            {
                uc = this.ucCopySNProgress2;
            }
            else if (iIndex == 3)
            {
                uc = this.ucCopySNProgress3;
            }
            if(uc!=null)
            {
                if (blSucessfully)
                    uc.SetStatus(UserControls.CopyStates.Free);
                else uc.SetStatus(UserControls.CopyStates.UnConnected);
            }
        }

        private void frmCopy_Load(object sender, EventArgs e)
        {
            if (this._RemoteSNCopyControler != null)
                this._RemoteSNCopyControler.Stop();
            //匹配IP地址
            if(JPSConfig.MacNo==1)
            {
                this.ucCopySNProgress1.SetIP(this, JPSConfig.RemoteMacConfig._IP1, 2);
                this.ucCopySNProgress2.SetIP(this, JPSConfig.RemoteMacConfig._IP2, 3);
                this.ucCopySNProgress3.SetIP(this, JPSConfig.RemoteMacConfig._IP3, 4);
            }
            else if (JPSConfig.MacNo == 2)
            {
                this.ucCopySNProgress1.SetIP(this, JPSConfig.RemoteMacConfig._IP1, 1);
                this.ucCopySNProgress2.SetIP(this, JPSConfig.RemoteMacConfig._IP2, 3);
                this.ucCopySNProgress3.SetIP(this, JPSConfig.RemoteMacConfig._IP3, 4);
            }
            else if (JPSConfig.MacNo == 3)
            {
                this.ucCopySNProgress1.SetIP(this, JPSConfig.RemoteMacConfig._IP1, 1);
                this.ucCopySNProgress2.SetIP(this, JPSConfig.RemoteMacConfig._IP2, 2);
                this.ucCopySNProgress3.SetIP(this, JPSConfig.RemoteMacConfig._IP3, 4);
            }
            else if (JPSConfig.MacNo == 4)
            {
                this.ucCopySNProgress1.SetIP(this, JPSConfig.RemoteMacConfig._IP1, 1);
                this.ucCopySNProgress2.SetIP(this, JPSConfig.RemoteMacConfig._IP2, 2);
                this.ucCopySNProgress3.SetIP(this, JPSConfig.RemoteMacConfig._IP3, 3);
            }
            if (JPSConfig.RemoteMacConfig._IP1.Length == 0)
                this.ucCopySNProgress1.SetStatus(UserControls.CopyStates.UnDefinitional);
            else this.ucCopySNProgress1.SetStatus(UserControls.CopyStates.UnConnected);

            if (JPSConfig.RemoteMacConfig._IP2.Length == 0)
                this.ucCopySNProgress2.SetStatus(UserControls.CopyStates.UnDefinitional);
            else this.ucCopySNProgress2.SetStatus(UserControls.CopyStates.UnConnected);

            if (JPSConfig.RemoteMacConfig._IP3.Length == 0)
                this.ucCopySNProgress3.SetStatus(UserControls.CopyStates.UnDefinitional);
            else this.ucCopySNProgress3.SetStatus(UserControls.CopyStates.UnConnected);
            string strErr;
            if (!this._MyPing.StartListenning(out strErr))
                this.ShowMsg(strErr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ucCopySNProgress1.StartCopy();
            this.ucCopySNProgress2.StartCopy();
            this.ucCopySNProgress3.StartCopy();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if(this.ucCopySNProgress1._State==UserControls.CopyStates.Copying)
            {
                this.ShowMsg("请先结束任务！");
                e.Cancel = true;
            }
            if (this.ucCopySNProgress2._State == UserControls.CopyStates.Copying)
            {
                this.ShowMsg("请先结束任务！");
                e.Cancel = true;
            }
            if (this.ucCopySNProgress3._State == UserControls.CopyStates.Copying)
            {
                this.ShowMsg("请先结束任务！");
                e.Cancel = true;
            }

            base.OnClosing(e);
        }
    }
}
