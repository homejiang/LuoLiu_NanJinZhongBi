namespace AutoAssign.Setting
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
            this.tbStation = new System.Windows.Forms.TextBox();
            this.linkStation = new System.Windows.Forms.LinkLabel();
            this.tbMac = new System.Windows.Forms.TextBox();
            this.linkMac = new System.Windows.Forms.LinkLabel();
            this.btTrue = new System.Windows.Forms.Button();
            this.numMacNo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMacNo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbStation
            // 
            this.tbStation.BackColor = System.Drawing.Color.White;
            this.tbStation.Location = new System.Drawing.Point(107, 13);
            this.tbStation.Name = "tbStation";
            this.tbStation.ReadOnly = true;
            this.tbStation.Size = new System.Drawing.Size(213, 24);
            this.tbStation.TabIndex = 3;
            // 
            // linkStation
            // 
            this.linkStation.AutoSize = true;
            this.linkStation.Location = new System.Drawing.Point(36, 17);
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
            this.tbMac.Location = new System.Drawing.Point(107, 46);
            this.tbMac.Name = "tbMac";
            this.tbMac.ReadOnly = true;
            this.tbMac.Size = new System.Drawing.Size(213, 24);
            this.tbMac.TabIndex = 5;
            // 
            // linkMac
            // 
            this.linkMac.AutoSize = true;
            this.linkMac.Location = new System.Drawing.Point(22, 50);
            this.linkMac.Name = "linkMac";
            this.linkMac.Size = new System.Drawing.Size(82, 15);
            this.linkMac.TabIndex = 4;
            this.linkMac.TabStop = true;
            this.linkMac.Text = "当前设备号";
            this.linkMac.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMac_LinkClicked);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(127, 114);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(106, 39);
            this.btTrue.TabIndex = 7;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // numMacNo
            // 
            this.numMacNo.Location = new System.Drawing.Point(107, 76);
            this.numMacNo.Name = "numMacNo";
            this.numMacNo.Size = new System.Drawing.Size(76, 24);
            this.numMacNo.TabIndex = 9;
            this.numMacNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "分选机序号";
            // 
            // frmStationConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 173);
            this.Controls.Add(this.numMacNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.linkMac);
            this.Controls.Add(this.tbStation);
            this.Controls.Add(this.linkStation);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStationConfig";
            this.Text = "站点相关信息设置";
            this.Load += new System.EventHandler(this.frmStationConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMacNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbStation;
        private System.Windows.Forms.LinkLabel linkStation;
        private System.Windows.Forms.TextBox tbMac;
        private System.Windows.Forms.LinkLabel linkMac;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.NumericUpDown numMacNo;
        private System.Windows.Forms.Label label1;
    }
}