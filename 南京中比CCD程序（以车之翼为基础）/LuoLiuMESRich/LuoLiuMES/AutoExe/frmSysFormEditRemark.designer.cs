namespace LuoLiuMES.AutoExe
{
    partial class frmSysFormEditRemark
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.htmlRemark = new Common.HTMLTextBox.HtmlEditor();
            this.SuspendLayout();
            // 
            // htmlRemark
            // 
            this.htmlRemark.BodyHTML = "";
            this.htmlRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlRemark.Location = new System.Drawing.Point(0, 0);
            this.htmlRemark.Name = "htmlRemark";
            this.htmlRemark.PublicUsers = "";
            this.htmlRemark.ShowPowerButton = false;
            this.htmlRemark.ShowSaveButton = false;
            this.htmlRemark.Size = new System.Drawing.Size(733, 434);
            this.htmlRemark.TabIndex = 27;
            this.htmlRemark.OnSave += new Common.HTMLTextBox.HtmlEditorSaveHandler(this.htmlRemark_OnSave);
            this.htmlRemark.OnExpButton += new Common.HTMLTextBox.HtmlEditorSaveHandler(this.htmlRemark_OnExpButton);
            // 
            // frmSysFormEditRemark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 434);
            this.Controls.Add(this.htmlRemark);
            this.Name = "frmSysFormEditRemark";
            this.Text = "编辑备注信息";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSysFormEditRemark_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.HTMLTextBox.HtmlEditor htmlRemark;
    }
}