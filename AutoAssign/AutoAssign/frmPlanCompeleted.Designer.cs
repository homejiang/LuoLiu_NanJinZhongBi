namespace AutoAssign
{
    partial class frmPlanCompeleted
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
            this.labTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labPlanNotice = new System.Windows.Forms.Label();
            this.labNewPlan = new System.Windows.Forms.Label();
            this.tbNewPlan = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioNewPlan = new System.Windows.Forms.RadioButton();
            this.radioStopTest = new System.Windows.Forms.RadioButton();
            this.labErr = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labTitle.Font = new System.Drawing.Font("微软雅黑 Light", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.Color.Black;
            this.labTitle.Location = new System.Drawing.Point(0, 0);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(780, 121);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "当前计划的?个托盘已全部完成。\r\n请选择继续或终止测试";
            this.labTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labPlanNotice);
            this.panel1.Controls.Add(this.labNewPlan);
            this.panel1.Controls.Add(this.tbNewPlan);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.radioNewPlan);
            this.panel1.Controls.Add(this.radioStopTest);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 159);
            this.panel1.TabIndex = 1;
            // 
            // labPlanNotice
            // 
            this.labPlanNotice.AutoSize = true;
            this.labPlanNotice.ForeColor = System.Drawing.Color.Gray;
            this.labPlanNotice.Location = new System.Drawing.Point(347, 82);
            this.labPlanNotice.Name = "labPlanNotice";
            this.labPlanNotice.Size = new System.Drawing.Size(255, 15);
            this.labPlanNotice.TabIndex = 5;
            this.labPlanNotice.Text = "如果您希望新的计划不限量，请输入0";
            // 
            // labNewPlan
            // 
            this.labNewPlan.AutoSize = true;
            this.labNewPlan.Location = new System.Drawing.Point(149, 82);
            this.labNewPlan.Name = "labNewPlan";
            this.labNewPlan.Size = new System.Drawing.Size(82, 15);
            this.labNewPlan.TabIndex = 4;
            this.labNewPlan.Text = "新增计划数";
            // 
            // tbNewPlan
            // 
            this.tbNewPlan.Location = new System.Drawing.Point(236, 78);
            this.tbNewPlan.Name = "tbNewPlan";
            this.tbNewPlan.Size = new System.Drawing.Size(100, 24);
            this.tbNewPlan.TabIndex = 3;
            this.tbNewPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(340, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioNewPlan
            // 
            this.radioNewPlan.AutoSize = true;
            this.radioNewPlan.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioNewPlan.Location = new System.Drawing.Point(27, 79);
            this.radioNewPlan.Name = "radioNewPlan";
            this.radioNewPlan.Size = new System.Drawing.Size(103, 23);
            this.radioNewPlan.TabIndex = 1;
            this.radioNewPlan.TabStop = true;
            this.radioNewPlan.Text = "新建计划";
            this.radioNewPlan.UseVisualStyleBackColor = true;
            this.radioNewPlan.CheckedChanged += new System.EventHandler(this.radioNewPlan_CheckedChanged);
            // 
            // radioStopTest
            // 
            this.radioStopTest.AutoSize = true;
            this.radioStopTest.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioStopTest.Location = new System.Drawing.Point(27, 31);
            this.radioStopTest.Name = "radioStopTest";
            this.radioStopTest.Size = new System.Drawing.Size(331, 23);
            this.radioStopTest.TabIndex = 0;
            this.radioStopTest.TabStop = true;
            this.radioStopTest.Text = "终止测试（设备会将多余电芯排出）";
            this.radioStopTest.UseVisualStyleBackColor = true;
            this.radioStopTest.CheckedChanged += new System.EventHandler(this.radioStopTest_CheckedChanged);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Top;
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 280);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(780, 30);
            this.labErr.TabIndex = 5;
            // 
            // frmPlanCompeleted
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 309);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labTitle);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPlanCompeleted";
            this.Text = "计划完成通知";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPlanCompeleted_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioNewPlan;
        private System.Windows.Forms.RadioButton radioStopTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labNewPlan;
        private System.Windows.Forms.TextBox tbNewPlan;
        private System.Windows.Forms.Label labErr;
        private System.Windows.Forms.Label labPlanNotice;
    }
}