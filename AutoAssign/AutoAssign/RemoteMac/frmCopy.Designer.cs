namespace AutoAssign.RemoteMac
{
    partial class frmCopy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.ucCopySNProgress1 = new AutoAssign.UserControls.ucCopySNProgress();
            this.ucCopySNProgress2 = new AutoAssign.UserControls.ucCopySNProgress();
            this.ucCopySNProgress3 = new AutoAssign.UserControls.ucCopySNProgress();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(209, 161);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "全部拷贝";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucCopySNProgress1
            // 
            this.ucCopySNProgress1.Location = new System.Drawing.Point(9, 42);
            this.ucCopySNProgress1.Margin = new System.Windows.Forms.Padding(0);
            this.ucCopySNProgress1.Name = "ucCopySNProgress1";
            this.ucCopySNProgress1.Size = new System.Drawing.Size(506, 37);
            this.ucCopySNProgress1.TabIndex = 4;
            this.ucCopySNProgress1.Title = "设备？";
            // 
            // ucCopySNProgress2
            // 
            this.ucCopySNProgress2.Location = new System.Drawing.Point(9, 79);
            this.ucCopySNProgress2.Margin = new System.Windows.Forms.Padding(0);
            this.ucCopySNProgress2.Name = "ucCopySNProgress2";
            this.ucCopySNProgress2.Size = new System.Drawing.Size(506, 37);
            this.ucCopySNProgress2.TabIndex = 5;
            this.ucCopySNProgress2.Title = "设备？";
            // 
            // ucCopySNProgress3
            // 
            this.ucCopySNProgress3.Location = new System.Drawing.Point(9, 116);
            this.ucCopySNProgress3.Margin = new System.Windows.Forms.Padding(0);
            this.ucCopySNProgress3.Name = "ucCopySNProgress3";
            this.ucCopySNProgress3.Size = new System.Drawing.Size(506, 37);
            this.ucCopySNProgress3.TabIndex = 6;
            this.ucCopySNProgress3.Title = "设备？";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(524, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "从其他设备拷贝电芯编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 213);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucCopySNProgress3);
            this.Controls.Add(this.ucCopySNProgress2);
            this.Controls.Add(this.ucCopySNProgress1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopy";
            this.Text = "同步数据";
            this.Load += new System.EventHandler(this.frmCopy_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private UserControls.ucCopySNProgress ucCopySNProgress1;
        private UserControls.ucCopySNProgress ucCopySNProgress2;
        private UserControls.ucCopySNProgress ucCopySNProgress3;
        private System.Windows.Forms.Label label1;
    }
}