namespace AutoAssign.UserControls
{
    partial class ucMyGroove
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
            this.comQuality = new System.Windows.Forms.ComboBox();
            this.tbTuoBtyCount = new System.Windows.Forms.TextBox();
            this.tbVMax = new System.Windows.Forms.TextBox();
            this.tbVMin = new System.Windows.Forms.TextBox();
            this.tbQualityDesc = new System.Windows.Forms.TextBox();
            this.linkQualityDesc = new System.Windows.Forms.LinkLabel();
            this.tbDianZuMax = new System.Windows.Forms.TextBox();
            this.tbDianZuMin = new System.Windows.Forms.TextBox();
            this.labNo = new System.Windows.Forms.Label();
            this.chkMes = new System.Windows.Forms.CheckBox();
            this.chkAutoMK = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comQuality
            // 
            this.comQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comQuality.FormattingEnabled = true;
            this.comQuality.Location = new System.Drawing.Point(306, 3);
            this.comQuality.Name = "comQuality";
            this.comQuality.Size = new System.Drawing.Size(69, 20);
            this.comQuality.TabIndex = 229;
            this.comQuality.SelectedIndexChanged += new System.EventHandler(this.comQuality_SelectedIndexChanged);
            // 
            // tbTuoBtyCount
            // 
            this.tbTuoBtyCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTuoBtyCount.Location = new System.Drawing.Point(249, 3);
            this.tbTuoBtyCount.Name = "tbTuoBtyCount";
            this.tbTuoBtyCount.Size = new System.Drawing.Size(45, 21);
            this.tbTuoBtyCount.TabIndex = 228;
            this.tbTuoBtyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTuoBtyCount.Leave += new System.EventHandler(this.tbTuoBtyCount_Leave);
            // 
            // tbVMax
            // 
            this.tbVMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVMax.Location = new System.Drawing.Point(189, 3);
            this.tbVMax.Name = "tbVMax";
            this.tbVMax.Size = new System.Drawing.Size(45, 21);
            this.tbVMax.TabIndex = 227;
            this.tbVMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbVMax.Leave += new System.EventHandler(this.tbVMax_Leave);
            // 
            // tbVMin
            // 
            this.tbVMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVMin.Location = new System.Drawing.Point(140, 3);
            this.tbVMin.Name = "tbVMin";
            this.tbVMin.Size = new System.Drawing.Size(45, 21);
            this.tbVMin.TabIndex = 226;
            this.tbVMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbVMin.Leave += new System.EventHandler(this.tbVMin_Leave);
            // 
            // tbQualityDesc
            // 
            this.tbQualityDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQualityDesc.Location = new System.Drawing.Point(102, 27);
            this.tbQualityDesc.Margin = new System.Windows.Forms.Padding(2);
            this.tbQualityDesc.Name = "tbQualityDesc";
            this.tbQualityDesc.Size = new System.Drawing.Size(273, 21);
            this.tbQualityDesc.TabIndex = 223;
            // 
            // linkQualityDesc
            // 
            this.linkQualityDesc.AutoSize = true;
            this.linkQualityDesc.Font = new System.Drawing.Font("黑体", 10F);
            this.linkQualityDesc.Location = new System.Drawing.Point(35, 30);
            this.linkQualityDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkQualityDesc.Name = "linkQualityDesc";
            this.linkQualityDesc.Size = new System.Drawing.Size(63, 14);
            this.linkQualityDesc.TabIndex = 230;
            this.linkQualityDesc.TabStop = true;
            this.linkQualityDesc.Text = "品质描述";
            this.linkQualityDesc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQualityDesc_LinkClicked);
            // 
            // tbDianZuMax
            // 
            this.tbDianZuMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDianZuMax.Location = new System.Drawing.Point(81, 3);
            this.tbDianZuMax.Name = "tbDianZuMax";
            this.tbDianZuMax.Size = new System.Drawing.Size(45, 21);
            this.tbDianZuMax.TabIndex = 225;
            this.tbDianZuMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDianZuMax.Leave += new System.EventHandler(this.tbDianZuMax_Leave);
            // 
            // tbDianZuMin
            // 
            this.tbDianZuMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDianZuMin.Location = new System.Drawing.Point(32, 3);
            this.tbDianZuMin.Name = "tbDianZuMin";
            this.tbDianZuMin.Size = new System.Drawing.Size(45, 21);
            this.tbDianZuMin.TabIndex = 224;
            this.tbDianZuMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDianZuMin.TextChanged += new System.EventHandler(this.tbDianZuMin_TextChanged);
            this.tbDianZuMin.Leave += new System.EventHandler(this.tbDianZuMin_Leave);
            // 
            // labNo
            // 
            this.labNo.BackColor = System.Drawing.Color.White;
            this.labNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.labNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labNo.ForeColor = System.Drawing.Color.Gray;
            this.labNo.Location = new System.Drawing.Point(0, 0);
            this.labNo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labNo.Name = "labNo";
            this.labNo.Size = new System.Drawing.Size(28, 52);
            this.labNo.TabIndex = 222;
            this.labNo.Text = "18";
            this.labNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMes
            // 
            this.chkMes.AutoSize = true;
            this.chkMes.Location = new System.Drawing.Point(391, 6);
            this.chkMes.Name = "chkMes";
            this.chkMes.Size = new System.Drawing.Size(42, 16);
            this.chkMes.TabIndex = 231;
            this.chkMes.Text = "MES";
            this.chkMes.UseVisualStyleBackColor = true;
            // 
            // chkAutoMK
            // 
            this.chkAutoMK.AutoSize = true;
            this.chkAutoMK.Location = new System.Drawing.Point(391, 28);
            this.chkAutoMK.Name = "chkAutoMK";
            this.chkAutoMK.Size = new System.Drawing.Size(48, 16);
            this.chkAutoMK.TabIndex = 232;
            this.chkAutoMK.Text = "自动";
            this.chkAutoMK.UseVisualStyleBackColor = true;
            // 
            // ucMyGroove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chkAutoMK);
            this.Controls.Add(this.chkMes);
            this.Controls.Add(this.comQuality);
            this.Controls.Add(this.tbTuoBtyCount);
            this.Controls.Add(this.tbVMax);
            this.Controls.Add(this.tbVMin);
            this.Controls.Add(this.tbQualityDesc);
            this.Controls.Add(this.linkQualityDesc);
            this.Controls.Add(this.tbDianZuMax);
            this.Controls.Add(this.tbDianZuMin);
            this.Controls.Add(this.labNo);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucMyGroove";
            this.Size = new System.Drawing.Size(442, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comQuality;
        private System.Windows.Forms.TextBox tbTuoBtyCount;
        private System.Windows.Forms.TextBox tbVMax;
        private System.Windows.Forms.TextBox tbVMin;
        private System.Windows.Forms.TextBox tbQualityDesc;
        private System.Windows.Forms.LinkLabel linkQualityDesc;
        private System.Windows.Forms.TextBox tbDianZuMax;
        private System.Windows.Forms.TextBox tbDianZuMin;
        private System.Windows.Forms.Label labNo;
        private System.Windows.Forms.CheckBox chkMes;
        private System.Windows.Forms.CheckBox chkAutoMK;
    }
}
