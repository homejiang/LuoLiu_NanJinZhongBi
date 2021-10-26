namespace Common.UserControls
{
    partial class ucFile
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
            this.panTitle = new System.Windows.Forms.Panel();
            this.labCreateTime = new System.Windows.Forms.Label();
            this.labCreater = new System.Windows.Forms.Label();
            this.labFileName = new System.Windows.Forms.Label();
            this.picICO = new System.Windows.Forms.PictureBox();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitle
            // 
            this.panTitle.Controls.Add(this.labCreateTime);
            this.panTitle.Controls.Add(this.labCreater);
            this.panTitle.Controls.Add(this.labFileName);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panTitle.Location = new System.Drawing.Point(0, 78);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(131, 49);
            this.panTitle.TabIndex = 1;
            // 
            // labCreateTime
            // 
            this.labCreateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.labCreateTime.ForeColor = System.Drawing.Color.Gray;
            this.labCreateTime.Location = new System.Drawing.Point(0, 33);
            this.labCreateTime.Margin = new System.Windows.Forms.Padding(0);
            this.labCreateTime.Name = "labCreateTime";
            this.labCreateTime.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labCreateTime.Size = new System.Drawing.Size(131, 15);
            this.labCreateTime.TabIndex = 2;
            this.labCreateTime.Text = "上传时间:2012-09-09";
            this.labCreateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labCreater
            // 
            this.labCreater.Dock = System.Windows.Forms.DockStyle.Top;
            this.labCreater.ForeColor = System.Drawing.Color.Gray;
            this.labCreater.Location = new System.Drawing.Point(0, 20);
            this.labCreater.Margin = new System.Windows.Forms.Padding(0);
            this.labCreater.Name = "labCreater";
            this.labCreater.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labCreater.Size = new System.Drawing.Size(131, 13);
            this.labCreater.TabIndex = 1;
            this.labCreater.Text = "Creater";
            this.labCreater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labFileName
            // 
            this.labFileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labFileName.Location = new System.Drawing.Point(0, 0);
            this.labFileName.Margin = new System.Windows.Forms.Padding(0);
            this.labFileName.Name = "labFileName";
            this.labFileName.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.labFileName.Size = new System.Drawing.Size(131, 20);
            this.labFileName.TabIndex = 0;
            this.labFileName.Text = "FileName.Extension";
            this.labFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picICO
            // 
            this.picICO.Dock = System.Windows.Forms.DockStyle.Top;
            this.picICO.Location = new System.Drawing.Point(0, 0);
            this.picICO.Name = "picICO";
            this.picICO.Size = new System.Drawing.Size(131, 62);
            this.picICO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picICO.TabIndex = 0;
            this.picICO.TabStop = false;
            // 
            // ucFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panTitle);
            this.Controls.Add(this.picICO);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ucFile";
            this.Size = new System.Drawing.Size(131, 127);
            this.DoubleClick += new System.EventHandler(this.ucFile_DoubleClick);
            this.Load += new System.EventHandler(this.ucFile_Load);
            this.Click += new System.EventHandler(this.ucFile_Click);
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picICO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picICO;
        private System.Windows.Forms.Panel panTitle;
        private System.Windows.Forms.Label labCreateTime;
        private System.Windows.Forms.Label labCreater;
        private System.Windows.Forms.Label labFileName;
    }
}
