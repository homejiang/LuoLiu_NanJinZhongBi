namespace SysSetting.UserControl
{
    partial class ucModuleAudit
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panItems = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panItems
            // 
            this.panItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.panItems.Location = new System.Drawing.Point(0, 0);
            this.panItems.Name = "panItems";
            this.panItems.Size = new System.Drawing.Size(456, 429);
            this.panItems.TabIndex = 0;
            // 
            // ucModuleAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panItems);
            this.Name = "ucModuleAudit";
            this.Size = new System.Drawing.Size(486, 429);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItems;
    }
}
