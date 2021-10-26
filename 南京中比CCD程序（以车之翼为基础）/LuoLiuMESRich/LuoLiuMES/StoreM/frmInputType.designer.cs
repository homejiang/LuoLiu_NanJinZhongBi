namespace LuoLiuMES.StoreM
{
    partial class frmInputType
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
            this.btType1 = new System.Windows.Forms.Button();
            this.btType2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btType1
            // 
            this.btType1.Location = new System.Drawing.Point(24, 41);
            this.btType1.Name = "btType1";
            this.btType1.Size = new System.Drawing.Size(151, 79);
            this.btType1.TabIndex = 0;
            this.btType1.Text = "电池包编号";
            this.btType1.UseVisualStyleBackColor = true;
            this.btType1.Click += new System.EventHandler(this.btType1_Click);
            // 
            // btType2
            // 
            this.btType2.Location = new System.Drawing.Point(203, 41);
            this.btType2.Name = "btType2";
            this.btType2.Size = new System.Drawing.Size(151, 79);
            this.btType2.TabIndex = 1;
            this.btType2.Text = "模组编号";
            this.btType2.UseVisualStyleBackColor = true;
            this.btType2.Click += new System.EventHandler(this.btType2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 79);
            this.button1.TabIndex = 2;
            this.button1.Text = "模块编号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInputType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 166);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btType2);
            this.Controls.Add(this.btType1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInputType";
            this.ShowIcon = false;
            this.Text = "扫描类型";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btType1;
        private System.Windows.Forms.Button btType2;
        private System.Windows.Forms.Button button1;
    }
}