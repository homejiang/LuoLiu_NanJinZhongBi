namespace AutoAssign.Debug
{
    partial class frmDebug
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btOpc = new System.Windows.Forms.Button();
            this.chkBat_Bool2 = new System.Windows.Forms.CheckBox();
            this.chkBat_Bool1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numSysNew = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numCompeleted = new System.Windows.Forms.NumericUpDown();
            this.btCompeleted = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSysNew)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCompeleted)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btOpc);
            this.groupBox1.Controls.Add(this.chkBat_Bool2);
            this.groupBox1.Controls.Add(this.chkBat_Bool1);
            this.groupBox1.Location = new System.Drawing.Point(36, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "电池组1";
            // 
            // btOpc
            // 
            this.btOpc.Location = new System.Drawing.Point(142, 32);
            this.btOpc.Name = "btOpc";
            this.btOpc.Size = new System.Drawing.Size(75, 23);
            this.btOpc.TabIndex = 2;
            this.btOpc.Text = "写入";
            this.btOpc.UseVisualStyleBackColor = true;
            this.btOpc.Click += new System.EventHandler(this.btOpc_Click);
            // 
            // chkBat_Bool2
            // 
            this.chkBat_Bool2.AutoSize = true;
            this.chkBat_Bool2.Location = new System.Drawing.Point(24, 53);
            this.chkBat_Bool2.Name = "chkBat_Bool2";
            this.chkBat_Bool2.Size = new System.Drawing.Size(96, 16);
            this.chkBat_Bool2.TabIndex = 1;
            this.chkBat_Bool2.Text = "Bat_Bool2为0";
            this.chkBat_Bool2.UseVisualStyleBackColor = true;
            // 
            // chkBat_Bool1
            // 
            this.chkBat_Bool1.AutoSize = true;
            this.chkBat_Bool1.Location = new System.Drawing.Point(24, 21);
            this.chkBat_Bool1.Name = "chkBat_Bool1";
            this.chkBat_Bool1.Size = new System.Drawing.Size(96, 16);
            this.chkBat_Bool1.TabIndex = 0;
            this.chkBat_Bool1.Text = "Bat_Bool1为0";
            this.chkBat_Bool1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numSysNew);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(36, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(247, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SysNew";
            // 
            // numSysNew
            // 
            this.numSysNew.Location = new System.Drawing.Point(34, 32);
            this.numSysNew.Name = "numSysNew";
            this.numSysNew.Size = new System.Drawing.Size(86, 21);
            this.numSysNew.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numCompeleted);
            this.groupBox3.Controls.Add(this.btCompeleted);
            this.groupBox3.Location = new System.Drawing.Point(36, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SysCompeleted";
            // 
            // numCompeleted
            // 
            this.numCompeleted.Location = new System.Drawing.Point(34, 32);
            this.numCompeleted.Name = "numCompeleted";
            this.numCompeleted.Size = new System.Drawing.Size(86, 21);
            this.numCompeleted.TabIndex = 3;
            // 
            // btCompeleted
            // 
            this.btCompeleted.Location = new System.Drawing.Point(142, 32);
            this.btCompeleted.Name = "btCompeleted";
            this.btCompeleted.Size = new System.Drawing.Size(75, 23);
            this.btCompeleted.TabIndex = 2;
            this.btCompeleted.Text = "写入";
            this.btCompeleted.UseVisualStyleBackColor = true;
            this.btCompeleted.Click += new System.EventHandler(this.btCompeleted_Click);
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 344);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDebug";
            this.Text = "开发员调试窗口";
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSysNew)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCompeleted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBat_Bool2;
        private System.Windows.Forms.CheckBox chkBat_Bool1;
        private System.Windows.Forms.Button btOpc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numSysNew;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numCompeleted;
        private System.Windows.Forms.Button btCompeleted;
    }
}