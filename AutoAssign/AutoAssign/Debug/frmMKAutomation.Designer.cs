namespace AutoAssign.Debug
{
    partial class frmMKAutomation
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBatCodes = new System.Windows.Forms.TextBox();
            this.btCreateBatCodes = new System.Windows.Forms.Button();
            this.btWriteOPCBatCodes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numFinished = new System.Windows.Forms.NumericUpDown();
            this.btWriteOPCFinished = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMKCode_Timer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbErr = new System.Windows.Forms.TextBox();
            this.btReadOPCBatCodes = new System.Windows.Forms.Button();
            this.tbBatCodes_timer = new System.Windows.Forms.TextBox();
            this.numFinished_Timer = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btClearMKCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numFinished)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinished_Timer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "电芯序列号";
            // 
            // tbBatCodes
            // 
            this.tbBatCodes.Location = new System.Drawing.Point(80, 12);
            this.tbBatCodes.Multiline = true;
            this.tbBatCodes.Name = "tbBatCodes";
            this.tbBatCodes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBatCodes.Size = new System.Drawing.Size(509, 66);
            this.tbBatCodes.TabIndex = 1;
            // 
            // btCreateBatCodes
            // 
            this.btCreateBatCodes.Location = new System.Drawing.Point(604, 17);
            this.btCreateBatCodes.Name = "btCreateBatCodes";
            this.btCreateBatCodes.Size = new System.Drawing.Size(75, 23);
            this.btCreateBatCodes.TabIndex = 2;
            this.btCreateBatCodes.Text = "生成Code";
            this.btCreateBatCodes.UseVisualStyleBackColor = true;
            // 
            // btWriteOPCBatCodes
            // 
            this.btWriteOPCBatCodes.Location = new System.Drawing.Point(604, 55);
            this.btWriteOPCBatCodes.Name = "btWriteOPCBatCodes";
            this.btWriteOPCBatCodes.Size = new System.Drawing.Size(75, 23);
            this.btWriteOPCBatCodes.TabIndex = 3;
            this.btWriteOPCBatCodes.Text = "写入OPC";
            this.btWriteOPCBatCodes.UseVisualStyleBackColor = true;
            this.btWriteOPCBatCodes.Click += new System.EventHandler(this.btWriteOPCBatCodes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "插装完成标识";
            // 
            // numFinished
            // 
            this.numFinished.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numFinished.Location = new System.Drawing.Point(96, 168);
            this.numFinished.Name = "numFinished";
            this.numFinished.Size = new System.Drawing.Size(73, 30);
            this.numFinished.TabIndex = 5;
            this.numFinished.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btWriteOPCFinished
            // 
            this.btWriteOPCFinished.Location = new System.Drawing.Point(199, 168);
            this.btWriteOPCFinished.Name = "btWriteOPCFinished";
            this.btWriteOPCFinished.Size = new System.Drawing.Size(75, 30);
            this.btWriteOPCFinished.TabIndex = 6;
            this.btWriteOPCFinished.Text = "写入OPC";
            this.btWriteOPCFinished.UseVisualStyleBackColor = true;
            this.btWriteOPCFinished.Click += new System.EventHandler(this.btWriteOPCFinished_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "模块标识";
            // 
            // tbMKCode_Timer
            // 
            this.tbMKCode_Timer.Location = new System.Drawing.Point(80, 232);
            this.tbMKCode_Timer.Name = "tbMKCode_Timer";
            this.tbMKCode_Timer.Size = new System.Drawing.Size(332, 21);
            this.tbMKCode_Timer.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbErr
            // 
            this.tbErr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbErr.ForeColor = System.Drawing.Color.Red;
            this.tbErr.Location = new System.Drawing.Point(0, 269);
            this.tbErr.Multiline = true;
            this.tbErr.Name = "tbErr";
            this.tbErr.Size = new System.Drawing.Size(768, 99);
            this.tbErr.TabIndex = 9;
            // 
            // btReadOPCBatCodes
            // 
            this.btReadOPCBatCodes.Location = new System.Drawing.Point(604, 105);
            this.btReadOPCBatCodes.Name = "btReadOPCBatCodes";
            this.btReadOPCBatCodes.Size = new System.Drawing.Size(75, 23);
            this.btReadOPCBatCodes.TabIndex = 10;
            this.btReadOPCBatCodes.Text = "刷新";
            this.btReadOPCBatCodes.UseVisualStyleBackColor = true;
            this.btReadOPCBatCodes.Click += new System.EventHandler(this.btReadOPCBatCodes_Click);
            // 
            // tbBatCodes_timer
            // 
            this.tbBatCodes_timer.Location = new System.Drawing.Point(80, 84);
            this.tbBatCodes_timer.Multiline = true;
            this.tbBatCodes_timer.Name = "tbBatCodes_timer";
            this.tbBatCodes_timer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbBatCodes_timer.Size = new System.Drawing.Size(509, 66);
            this.tbBatCodes_timer.TabIndex = 11;
            // 
            // numFinished_Timer
            // 
            this.numFinished_Timer.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numFinished_Timer.Location = new System.Drawing.Point(350, 168);
            this.numFinished_Timer.Name = "numFinished_Timer";
            this.numFinished_Timer.Size = new System.Drawing.Size(73, 30);
            this.numFinished_Timer.TabIndex = 12;
            this.numFinished_Timer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "实时值";
            // 
            // btClearMKCode
            // 
            this.btClearMKCode.Location = new System.Drawing.Point(446, 226);
            this.btClearMKCode.Name = "btClearMKCode";
            this.btClearMKCode.Size = new System.Drawing.Size(75, 30);
            this.btClearMKCode.TabIndex = 14;
            this.btClearMKCode.Text = "清空";
            this.btClearMKCode.UseVisualStyleBackColor = true;
            this.btClearMKCode.Click += new System.EventHandler(this.btClearMKCode_Click);
            // 
            // frmMKAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 368);
            this.Controls.Add(this.btClearMKCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numFinished_Timer);
            this.Controls.Add(this.tbBatCodes_timer);
            this.Controls.Add(this.btReadOPCBatCodes);
            this.Controls.Add(this.tbErr);
            this.Controls.Add(this.tbMKCode_Timer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btWriteOPCFinished);
            this.Controls.Add(this.numFinished);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btWriteOPCBatCodes);
            this.Controls.Add(this.btCreateBatCodes);
            this.Controls.Add(this.tbBatCodes);
            this.Controls.Add(this.label1);
            this.Name = "frmMKAutomation";
            this.Text = "自动插装模块调试";
            this.Load += new System.EventHandler(this.frmMKAutomation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFinished)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFinished_Timer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBatCodes;
        private System.Windows.Forms.Button btCreateBatCodes;
        private System.Windows.Forms.Button btWriteOPCBatCodes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numFinished;
        private System.Windows.Forms.Button btWriteOPCFinished;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMKCode_Timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbErr;
        private System.Windows.Forms.Button btReadOPCBatCodes;
        private System.Windows.Forms.TextBox tbBatCodes_timer;
        private System.Windows.Forms.NumericUpDown numFinished_Timer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btClearMKCode;
    }
}