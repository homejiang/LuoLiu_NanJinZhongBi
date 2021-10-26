namespace LuoLiuMES.Boxing
{
    partial class frmBoxTypeEdit
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
            this.btTrue = new System.Windows.Forms.Button();
            this.chkTerminated = new System.Windows.Forms.CheckBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTypeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMyWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(143, 119);
            this.btTrue.Margin = new System.Windows.Forms.Padding(4);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(115, 38);
            this.btTrue.TabIndex = 5;
            this.btTrue.Text = "确 定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // chkTerminated
            // 
            this.chkTerminated.AutoSize = true;
            this.chkTerminated.Location = new System.Drawing.Point(222, 17);
            this.chkTerminated.Margin = new System.Windows.Forms.Padding(4);
            this.chkTerminated.Name = "chkTerminated";
            this.chkTerminated.Size = new System.Drawing.Size(56, 19);
            this.chkTerminated.TabIndex = 4;
            this.chkTerminated.Text = "停用";
            this.chkTerminated.UseVisualStyleBackColor = true;
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(83, 14);
            this.tbCode.Margin = new System.Windows.Forms.Padding(4);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(132, 24);
            this.tbCode.TabIndex = 9;
            this.tbCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(14, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "系统编码";
            // 
            // tbTypeName
            // 
            this.tbTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTypeName.Location = new System.Drawing.Point(83, 46);
            this.tbTypeName.Margin = new System.Windows.Forms.Padding(4);
            this.tbTypeName.Name = "tbTypeName";
            this.tbTypeName.Size = new System.Drawing.Size(286, 24);
            this.tbTypeName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "托盘类型";
            // 
            // tbQty
            // 
            this.tbQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQty.Location = new System.Drawing.Point(83, 78);
            this.tbQty.Margin = new System.Windows.Forms.Padding(4);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(92, 24);
            this.tbQty.TabIndex = 12;
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "成品数量";
            // 
            // tbMyWeight
            // 
            this.tbMyWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMyWeight.Location = new System.Drawing.Point(285, 78);
            this.tbMyWeight.Margin = new System.Windows.Forms.Padding(4);
            this.tbMyWeight.Name = "tbMyWeight";
            this.tbMyWeight.Size = new System.Drawing.Size(84, 24);
            this.tbMyWeight.TabIndex = 14;
            this.tbMyWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(183, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "托盘重量(kg)";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(390, 15);
            this.label5.TabIndex = 16;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBoxTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 178);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbMyWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbTypeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTerminated);
            this.Controls.Add(this.btTrue);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoxTypeEdit";
            this.Text = "托盘类型编辑";
            this.Load += new System.EventHandler(this.frmUnitEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.CheckBox chkTerminated;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTypeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMyWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}