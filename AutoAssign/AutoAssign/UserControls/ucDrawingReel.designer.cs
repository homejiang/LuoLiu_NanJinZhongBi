namespace AutoAssign.UserControls
{
    partial class ucDrawingReel
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
            this.labReelStyle = new System.Windows.Forms.Label();
            this.labPanNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labReelStyle
            // 
            this.labReelStyle.BackColor = System.Drawing.Color.White;
            this.labReelStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labReelStyle.Font = new System.Drawing.Font("楷体", 9F);
            this.labReelStyle.ForeColor = System.Drawing.Color.Black;
            this.labReelStyle.Location = new System.Drawing.Point(0, 0);
            this.labReelStyle.Margin = new System.Windows.Forms.Padding(0);
            this.labReelStyle.Name = "labReelStyle";
            this.labReelStyle.Size = new System.Drawing.Size(98, 64);
            this.labReelStyle.TabIndex = 219;
            this.labReelStyle.Text = "等待扫描";
            this.labReelStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPanNo
            // 
            this.labPanNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.labPanNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labPanNo.Font = new System.Drawing.Font("黑体", 9F);
            this.labPanNo.ForeColor = System.Drawing.Color.White;
            this.labPanNo.Location = new System.Drawing.Point(0, 64);
            this.labPanNo.Name = "labPanNo";
            this.labPanNo.Size = new System.Drawing.Size(98, 30);
            this.labPanNo.TabIndex = 220;
            this.labPanNo.Text = "?";
            this.labPanNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucDrawingReel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labPanNo);
            this.Controls.Add(this.labReelStyle);
            this.Name = "ucDrawingReel";
            this.Size = new System.Drawing.Size(98, 95);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labReelStyle;
        private System.Windows.Forms.Label labPanNo;
    }
}
