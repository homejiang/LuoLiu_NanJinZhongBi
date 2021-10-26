namespace Common.Msg
{
    partial class frmMySetting
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
            this.chkMainIsReceive = new System.Windows.Forms.CheckBox();
            this.chkMainIsAuto = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMainInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDeskIsStart = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDeskInterval = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labDeskFileCheck = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMainIsReceive
            // 
            this.chkMainIsReceive.AutoSize = true;
            this.chkMainIsReceive.Location = new System.Drawing.Point(15, 37);
            this.chkMainIsReceive.Name = "chkMainIsReceive";
            this.chkMainIsReceive.Size = new System.Drawing.Size(116, 19);
            this.chkMainIsReceive.TabIndex = 1;
            this.chkMainIsReceive.Text = "启用消息功能";
            this.chkMainIsReceive.UseVisualStyleBackColor = true;
            this.chkMainIsReceive.CheckedChanged += new System.EventHandler(this.chkMainIsReceive_CheckedChanged);
            // 
            // chkMainIsAuto
            // 
            this.chkMainIsAuto.AutoSize = true;
            this.chkMainIsAuto.Location = new System.Drawing.Point(11, 67);
            this.chkMainIsAuto.Name = "chkMainIsAuto";
            this.chkMainIsAuto.Size = new System.Drawing.Size(116, 19);
            this.chkMainIsAuto.TabIndex = 2;
            this.chkMainIsAuto.Text = "自动接受消息";
            this.chkMainIsAuto.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "秒";
            // 
            // tbMainInterval
            // 
            this.tbMainInterval.Location = new System.Drawing.Point(241, 63);
            this.tbMainInterval.Name = "tbMainInterval";
            this.tbMainInterval.Size = new System.Drawing.Size(56, 24);
            this.tbMainInterval.TabIndex = 4;
            this.tbMainInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "自动刷新间隔";
            // 
            // chkDeskIsStart
            // 
            this.chkDeskIsStart.AutoSize = true;
            this.chkDeskIsStart.Location = new System.Drawing.Point(9, 23);
            this.chkDeskIsStart.Name = "chkDeskIsStart";
            this.chkDeskIsStart.Size = new System.Drawing.Size(146, 19);
            this.chkDeskIsStart.TabIndex = 6;
            this.chkDeskIsStart.Text = "开机启动消息进程";
            this.chkDeskIsStart.UseVisualStyleBackColor = true;
            this.chkDeskIsStart.CheckedChanged += new System.EventHandler(this.chkDeskIsStart_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "秒";
            // 
            // tbDeskInterval
            // 
            this.tbDeskInterval.Location = new System.Drawing.Point(110, 54);
            this.tbDeskInterval.Name = "tbDeskInterval";
            this.tbDeskInterval.Size = new System.Drawing.Size(56, 24);
            this.tbDeskInterval.TabIndex = 8;
            this.tbDeskInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "自动刷新间隔";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbMainInterval);
            this.groupBox1.Controls.Add(this.chkMainIsReceive);
            this.groupBox1.Controls.Add(this.chkMainIsAuto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 104);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主程序消息设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labDeskFileCheck);
            this.groupBox2.Controls.Add(this.tbDeskInterval);
            this.groupBox2.Controls.Add(this.chkDeskIsStart);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(397, 91);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "开机启动消息设置";
            // 
            // labDeskFileCheck
            // 
            this.labDeskFileCheck.AutoSize = true;
            this.labDeskFileCheck.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDeskFileCheck.ForeColor = System.Drawing.Color.Red;
            this.labDeskFileCheck.Location = new System.Drawing.Point(159, 23);
            this.labDeskFileCheck.Name = "labDeskFileCheck";
            this.labDeskFileCheck.Size = new System.Drawing.Size(199, 15);
            this.labDeskFileCheck.TabIndex = 10;
            this.labDeskFileCheck.Text = "注：目录中未包含启动程序";
            this.labDeskFileCheck.Visible = false;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(153, 220);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(106, 36);
            this.btTrue.TabIndex = 12;
            this.btTrue.Text = "保 存";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmMySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 267);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMySetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "消息个人设置";
            this.Load += new System.EventHandler(this.frmMySetting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMainIsReceive;
        private System.Windows.Forms.CheckBox chkMainIsAuto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMainInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDeskIsStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDeskInterval;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labDeskFileCheck;
    }
}