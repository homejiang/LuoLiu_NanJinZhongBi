namespace AutoAssign.ExpFuns
{
    partial class frmToExcel
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
            this.label1 = new System.Windows.Forms.Label();
            this.linkTarget = new System.Windows.Forms.LinkLabel();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.panContainer = new System.Windows.Forms.Panel();
            this.labProgress = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.panContainer.SuspendLayout();
            this.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(610, 62);
            this.label1.TabIndex = 10;
            this.label1.Text = "将批次“”数据导出值Excel文件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkTarget
            // 
            this.linkTarget.AutoSize = true;
            this.linkTarget.Location = new System.Drawing.Point(19, 98);
            this.linkTarget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkTarget.Name = "linkTarget";
            this.linkTarget.Size = new System.Drawing.Size(80, 18);
            this.linkTarget.TabIndex = 11;
            this.linkTarget.TabStop = true;
            this.linkTarget.Text = "目标路径";
            this.linkTarget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTarget_LinkClicked);
            // 
            // tbTarget
            // 
            this.tbTarget.BackColor = System.Drawing.Color.White;
            this.tbTarget.Location = new System.Drawing.Point(128, 84);
            this.tbTarget.Margin = new System.Windows.Forms.Padding(4);
            this.tbTarget.Multiline = true;
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.ReadOnly = true;
            this.tbTarget.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTarget.Size = new System.Drawing.Size(469, 73);
            this.tbTarget.TabIndex = 12;
            // 
            // panContainer
            // 
            this.panContainer.BackColor = System.Drawing.Color.Maroon;
            this.panContainer.Controls.Add(this.labProgress);
            this.panContainer.Location = new System.Drawing.Point(0, 240);
            this.panContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panContainer.Name = "panContainer";
            this.panContainer.Size = new System.Drawing.Size(608, 26);
            this.panContainer.TabIndex = 14;
            this.panContainer.Visible = false;
            // 
            // labProgress
            // 
            this.labProgress.BackColor = System.Drawing.Color.Lime;
            this.labProgress.Dock = System.Windows.Forms.DockStyle.Left;
            this.labProgress.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labProgress.Location = new System.Drawing.Point(0, 0);
            this.labProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labProgress.Name = "labProgress";
            this.labProgress.Size = new System.Drawing.Size(42, 26);
            this.labProgress.TabIndex = 0;
            this.labProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(257, 183);
            this.btTrue.Margin = new System.Windows.Forms.Padding(4);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(112, 45);
            this.btTrue.TabIndex = 15;
            this.btTrue.Text = "确认导出";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmToExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 264);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.panContainer);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.linkTarget);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(9);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToExcel";
            this.Text = "导出Excel文件";
            this.Load += new System.EventHandler(this.frmToExcel_Load);
            this.panContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkTarget;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.Panel panContainer;
        private System.Windows.Forms.Label labProgress;
        private System.Windows.Forms.Button btTrue;
    }
}