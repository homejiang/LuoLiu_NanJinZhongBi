namespace Common
{
    partial class frmSetDbFile
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
            this.linkSelDb = new System.Windows.Forms.LinkLabel();
            this.tbDbFile = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linkSelDb
            // 
            this.linkSelDb.AutoSize = true;
            this.linkSelDb.Location = new System.Drawing.Point(12, 23);
            this.linkSelDb.Name = "linkSelDb";
            this.linkSelDb.Size = new System.Drawing.Size(82, 15);
            this.linkSelDb.TabIndex = 0;
            this.linkSelDb.TabStop = true;
            this.linkSelDb.Text = "选择数据库";
            this.linkSelDb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelDb_LinkClicked);
            // 
            // tbDbFile
            // 
            this.tbDbFile.BackColor = System.Drawing.Color.White;
            this.tbDbFile.Location = new System.Drawing.Point(100, 20);
            this.tbDbFile.Multiline = true;
            this.tbDbFile.Name = "tbDbFile";
            this.tbDbFile.ReadOnly = true;
            this.tbDbFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDbFile.Size = new System.Drawing.Size(323, 61);
            this.tbDbFile.TabIndex = 1;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(175, 98);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(111, 34);
            this.btTrue.TabIndex = 2;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmSetDbFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 146);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbDbFile);
            this.Controls.Add(this.linkSelDb);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetDbFile";
            this.ShowIcon = false;
            this.Text = "选择数据库";
            this.Load += new System.EventHandler(this.frmSetDbFile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkSelDb;
        private System.Windows.Forms.TextBox tbDbFile;
        private System.Windows.Forms.Button btTrue;
    }
}