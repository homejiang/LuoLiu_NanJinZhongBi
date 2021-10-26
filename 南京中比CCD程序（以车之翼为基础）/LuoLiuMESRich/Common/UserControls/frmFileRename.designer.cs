namespace Common.UserControls
{
    partial class frmFileRename
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbFileName = new MyControl.MyTextBox();
            this.labExtension = new System.Windows.Forms.Label();
            this.btTure = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件名";
            // 
            // tbFileName
            // 
            this.tbFileName.FilterQuanJiao = true;
            this.tbFileName.IsUpper = false;
            this.tbFileName.Location = new System.Drawing.Point(52, 14);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(195, 21);
            this.tbFileName.TabIndex = 1;
            // 
            // labExtension
            // 
            this.labExtension.AutoSize = true;
            this.labExtension.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labExtension.ForeColor = System.Drawing.Color.Blue;
            this.labExtension.Location = new System.Drawing.Point(250, 18);
            this.labExtension.Name = "labExtension";
            this.labExtension.Size = new System.Drawing.Size(79, 14);
            this.labExtension.TabIndex = 2;
            this.labExtension.Text = "Extension";
            // 
            // btTure
            // 
            this.btTure.Location = new System.Drawing.Point(76, 55);
            this.btTure.Name = "btTure";
            this.btTure.Size = new System.Drawing.Size(75, 23);
            this.btTure.TabIndex = 3;
            this.btTure.Text = "确定";
            this.btTure.UseVisualStyleBackColor = true;
            this.btTure.Click += new System.EventHandler(this.btTure_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(169, 55);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 4;
            this.btClose.Text = "关闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmFileRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 90);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btTure);
            this.Controls.Add(this.labExtension);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFileRename";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "重命名";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyControl.MyTextBox tbFileName;
        private System.Windows.Forms.Label labExtension;
        private System.Windows.Forms.Button btTure;
        private System.Windows.Forms.Button btClose;
    }
}