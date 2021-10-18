namespace AutoAssign.UserControls
{
    partial class ucCorrectItem
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
            this.labNo = new System.Windows.Forms.Label();
            this.tbDz = new System.Windows.Forms.TextBox();
            this.tbV = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labNo
            // 
            this.labNo.Location = new System.Drawing.Point(5, 6);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(42, 17);
            this.labNo.TabIndex = 0;
            this.labNo.Text = "组?";
            this.labNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDz
            // 
            this.tbDz.Location = new System.Drawing.Point(50, 3);
            this.tbDz.Name = "tbDz";
            this.tbDz.Size = new System.Drawing.Size(79, 21);
            this.tbDz.TabIndex = 1;
            this.tbDz.Text = "---";
            this.tbDz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbDz.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbDz_MouseDoubleClick);
            // 
            // tbV
            // 
            this.tbV.Location = new System.Drawing.Point(154, 3);
            this.tbV.Name = "tbV";
            this.tbV.Size = new System.Drawing.Size(79, 21);
            this.tbV.TabIndex = 2;
            this.tbV.Text = "---";
            this.tbV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tbV_MouseDoubleClick);
            // 
            // ucCorrectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbV);
            this.Controls.Add(this.tbDz);
            this.Controls.Add(this.labNo);
            this.Name = "ucCorrectItem";
            this.Size = new System.Drawing.Size(245, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.TextBox tbDz;
        private System.Windows.Forms.TextBox tbV;
    }
}
