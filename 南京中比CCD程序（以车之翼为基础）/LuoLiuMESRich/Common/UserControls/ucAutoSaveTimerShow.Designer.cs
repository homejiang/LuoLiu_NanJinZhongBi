namespace Common.UserControls
{
    partial class ucAutoSaveTimerShow
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panAutoSave = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labAutoSave = new System.Windows.Forms.Label();
            this.timer_AutoSave = new System.Windows.Forms.Timer(this.components);
            this.panAutoSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panAutoSave
            // 
            this.panAutoSave.Controls.Add(this.pictureBox1);
            this.panAutoSave.Controls.Add(this.labAutoSave);
            this.panAutoSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAutoSave.Location = new System.Drawing.Point(0, 0);
            this.panAutoSave.Name = "panAutoSave";
            this.panAutoSave.Size = new System.Drawing.Size(282, 23);
            this.panAutoSave.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Common.Properties.Resources.Close1;
            this.pictureBox1.Location = new System.Drawing.Point(139, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // labAutoSave
            // 
            this.labAutoSave.AutoSize = true;
            this.labAutoSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.labAutoSave.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAutoSave.Location = new System.Drawing.Point(0, 0);
            this.labAutoSave.Name = "labAutoSave";
            this.labAutoSave.Size = new System.Drawing.Size(139, 20);
            this.labAutoSave.TabIndex = 1;
            this.labAutoSave.Text = "3秒后自动清空";
            this.labAutoSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer_AutoSave
            // 
            this.timer_AutoSave.Tick += new System.EventHandler(this.timer_AutoSave_Tick);
            // 
            // ucAutoSaveTimerShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panAutoSave);
            this.Name = "ucAutoSaveTimerShow";
            this.Size = new System.Drawing.Size(282, 23);
            this.panAutoSave.ResumeLayout(false);
            this.panAutoSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panAutoSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labAutoSave;
        private System.Windows.Forms.Timer timer_AutoSave;
    }
}
