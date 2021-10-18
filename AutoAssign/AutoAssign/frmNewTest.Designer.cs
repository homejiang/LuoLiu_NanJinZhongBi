namespace AutoAssign
{
    partial class frmNewTest
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
            this.labNotice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labNotice
            // 
            this.labNotice.Dock = System.Windows.Forms.DockStyle.Top;
            this.labNotice.Font = new System.Drawing.Font("微软雅黑", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNotice.Location = new System.Drawing.Point(0, 0);
            this.labNotice.Name = "labNotice";
            this.labNotice.Size = new System.Drawing.Size(573, 68);
            this.labNotice.TabIndex = 0;
            this.labNotice.Text = "设备数据初始化中.....";
            this.labNotice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(0, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(573, 43);
            this.label1.TabIndex = 1;
            // 
            // frmNewTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labNotice);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewTest";
            this.Text = "新建测试";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labNotice;
        private System.Windows.Forms.Label label1;
    }
}