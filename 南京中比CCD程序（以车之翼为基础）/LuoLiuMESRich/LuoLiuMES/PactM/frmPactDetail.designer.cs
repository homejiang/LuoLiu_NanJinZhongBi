namespace LuoLiuMES.PactM
{
    partial class frmPactDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPactDetail));
            this.label2 = new System.Windows.Forms.Label();
            this.comBom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbVersionDesc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBomDesc = new System.Windows.Forms.TextBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dptDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComFenXj = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "BOM规格";
            // 
            // comBom
            // 
            this.comBom.BackColor = System.Drawing.Color.White;
            this.comBom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBom.FormattingEnabled = true;
            this.comBom.Location = new System.Drawing.Point(89, 29);
            this.comBom.Name = "comBom";
            this.comBom.Size = new System.Drawing.Size(325, 23);
            this.comBom.TabIndex = 2;
            this.comBom.SelectedIndexChanged += new System.EventHandler(this.comBom_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(598, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "任务单信息";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ComFenXj);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbVersionDesc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbBomDesc);
            this.panel1.Controls.Add(this.tbRemark);
            this.panel1.Controls.Add(this.btTrue);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.dptDeliveryDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbQty);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.comBom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 417);
            this.panel1.TabIndex = 7;
            // 
            // tbVersionDesc
            // 
            this.tbVersionDesc.BackColor = System.Drawing.Color.White;
            this.tbVersionDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbVersionDesc.Location = new System.Drawing.Point(476, 29);
            this.tbVersionDesc.Name = "tbVersionDesc";
            this.tbVersionDesc.ReadOnly = true;
            this.tbVersionDesc.Size = new System.Drawing.Size(119, 24);
            this.tbVersionDesc.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "版本号";
            // 
            // tbBomDesc
            // 
            this.tbBomDesc.BackColor = System.Drawing.SystemColors.Window;
            this.tbBomDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBomDesc.Location = new System.Drawing.Point(89, 56);
            this.tbBomDesc.Multiline = true;
            this.tbBomDesc.Name = "tbBomDesc";
            this.tbBomDesc.ReadOnly = true;
            this.tbBomDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbBomDesc.Size = new System.Drawing.Size(506, 298);
            this.tbBomDesc.TabIndex = 10;
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.Location = new System.Drawing.Point(294, 95);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRemark.Size = new System.Drawing.Size(25, 29);
            this.tbRemark.TabIndex = 18;
            // 
            // btTrue
            // 
            this.btTrue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btTrue.Location = new System.Drawing.Point(239, 362);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(134, 43);
            this.btTrue.TabIndex = 28;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 15);
            this.label13.TabIndex = 17;
            this.label13.Text = "任务单备注";
            // 
            // dptDeliveryDate
            // 
            this.dptDeliveryDate.Location = new System.Drawing.Point(200, 2);
            this.dptDeliveryDate.Name = "dptDeliveryDate";
            this.dptDeliveryDate.Size = new System.Drawing.Size(127, 24);
            this.dptDeliveryDate.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "交货期";
            // 
            // tbQty
            // 
            this.tbQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQty.Location = new System.Drawing.Point(89, 3);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(54, 24);
            this.tbQty.TabIndex = 9;
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "数量(个)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "结构说明";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "分选机收料盒比例";
            // 
            // ComFenXj
            // 
            this.ComFenXj.BackColor = System.Drawing.Color.White;
            this.ComFenXj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComFenXj.FormattingEnabled = true;
            this.ComFenXj.Location = new System.Drawing.Point(475, 3);
            this.ComFenXj.Name = "ComFenXj";
            this.ComFenXj.Size = new System.Drawing.Size(120, 23);
            this.ComFenXj.TabIndex = 32;
            // 
            // frmPactDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 447);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPactDetail";
            this.Text = "任务明细编辑";
            this.Load += new System.EventHandler(this.frmPactDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dptDeliveryDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbBomDesc;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbVersionDesc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComFenXj;
        private System.Windows.Forms.Label label3;
    }
}