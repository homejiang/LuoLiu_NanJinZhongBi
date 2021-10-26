namespace LuoLiuMESPrinter
{
    partial class frmStationConfig
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
            this.tbProcess = new System.Windows.Forms.TextBox();
            this.tbStation = new System.Windows.Forms.TextBox();
            this.linkStation = new System.Windows.Forms.LinkLabel();
            this.tbMac = new System.Windows.Forms.TextBox();
            this.linkMac = new System.Windows.Forms.LinkLabel();
            this.linkProcess = new System.Windows.Forms.LinkLabel();
            this.btTrue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbProcess
            // 
            this.tbProcess.BackColor = System.Drawing.Color.White;
            this.tbProcess.Location = new System.Drawing.Point(94, 22);
            this.tbProcess.Name = "tbProcess";
            this.tbProcess.ReadOnly = true;
            this.tbProcess.Size = new System.Drawing.Size(213, 24);
            this.tbProcess.TabIndex = 1;
            // 
            // tbStation
            // 
            this.tbStation.BackColor = System.Drawing.Color.White;
            this.tbStation.Location = new System.Drawing.Point(94, 53);
            this.tbStation.Name = "tbStation";
            this.tbStation.ReadOnly = true;
            this.tbStation.Size = new System.Drawing.Size(213, 24);
            this.tbStation.TabIndex = 3;
            // 
            // linkStation
            // 
            this.linkStation.AutoSize = true;
            this.linkStation.Location = new System.Drawing.Point(22, 57);
            this.linkStation.Name = "linkStation";
            this.linkStation.Size = new System.Drawing.Size(67, 15);
            this.linkStation.TabIndex = 2;
            this.linkStation.TabStop = true;
            this.linkStation.Text = "当前站点";
            this.linkStation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkStation_LinkClicked);
            // 
            // tbMac
            // 
            this.tbMac.BackColor = System.Drawing.Color.White;
            this.tbMac.Location = new System.Drawing.Point(94, 86);
            this.tbMac.Name = "tbMac";
            this.tbMac.ReadOnly = true;
            this.tbMac.Size = new System.Drawing.Size(213, 24);
            this.tbMac.TabIndex = 5;
            // 
            // linkMac
            // 
            this.linkMac.AutoSize = true;
            this.linkMac.Location = new System.Drawing.Point(9, 90);
            this.linkMac.Name = "linkMac";
            this.linkMac.Size = new System.Drawing.Size(82, 15);
            this.linkMac.TabIndex = 4;
            this.linkMac.TabStop = true;
            this.linkMac.Text = "当前设备号";
            this.linkMac.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMac_LinkClicked);
            // 
            // linkProcess
            // 
            this.linkProcess.AutoSize = true;
            this.linkProcess.Location = new System.Drawing.Point(23, 26);
            this.linkProcess.Name = "linkProcess";
            this.linkProcess.Size = new System.Drawing.Size(67, 15);
            this.linkProcess.TabIndex = 6;
            this.linkProcess.TabStop = true;
            this.linkProcess.Text = "当前工序";
            this.linkProcess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProcess_LinkClicked);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(123, 130);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(106, 39);
            this.btTrue.TabIndex = 7;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmStationConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 199);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.linkProcess);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.linkMac);
            this.Controls.Add(this.tbStation);
            this.Controls.Add(this.linkStation);
            this.Controls.Add(this.tbProcess);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStationConfig";
            this.Text = "站点相关信息设置";
            this.Load += new System.EventHandler(this.frmStationConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbProcess;
        private System.Windows.Forms.TextBox tbStation;
        private System.Windows.Forms.LinkLabel linkStation;
        private System.Windows.Forms.TextBox tbMac;
        private System.Windows.Forms.LinkLabel linkMac;
        private System.Windows.Forms.LinkLabel linkProcess;
        private System.Windows.Forms.Button btTrue;
    }
}