namespace EleCardComposing.UserControls
{
    partial class ucMk
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
            this.btDxDetail = new System.Windows.Forms.Button();
            this.tbMkCode = new System.Windows.Forms.TextBox();
            this.tbRangeR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btBind = new System.Windows.Forms.Button();
            this.tbRangeV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDxCnt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btDxDetail
            // 
            this.btDxDetail.Location = new System.Drawing.Point(869, 4);
            this.btDxDetail.Name = "btDxDetail";
            this.btDxDetail.Size = new System.Drawing.Size(76, 26);
            this.btDxDetail.TabIndex = 166;
            this.btDxDetail.Text = "电芯明细";
            this.btDxDetail.UseVisualStyleBackColor = true;
            this.btDxDetail.Click += new System.EventHandler(this.btDxDetail_Click);
            // 
            // tbMkCode
            // 
            this.tbMkCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMkCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMkCode.Location = new System.Drawing.Point(69, 5);
            this.tbMkCode.Name = "tbMkCode";
            this.tbMkCode.Size = new System.Drawing.Size(160, 24);
            this.tbMkCode.TabIndex = 158;
            this.tbMkCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMkCode_KeyDown);
            // 
            // tbRangeR
            // 
            this.tbRangeR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRangeR.Location = new System.Drawing.Point(736, 6);
            this.tbRangeR.Name = "tbRangeR";
            this.tbRangeR.ReadOnly = true;
            this.tbRangeR.Size = new System.Drawing.Size(120, 21);
            this.tbRangeR.TabIndex = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 157;
            this.label1.Text = "模块编码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(649, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 164;
            this.label2.Text = "电阻范围(mΩ)";
            // 
            // btBind
            // 
            this.btBind.Location = new System.Drawing.Point(237, 5);
            this.btBind.Name = "btBind";
            this.btBind.Size = new System.Drawing.Size(87, 26);
            this.btBind.TabIndex = 159;
            this.btBind.Text = "加载电芯";
            this.btBind.UseVisualStyleBackColor = true;
            this.btBind.Click += new System.EventHandler(this.btBindDxDetail_Click);
            // 
            // tbRangeV
            // 
            this.tbRangeV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRangeV.Location = new System.Drawing.Point(525, 6);
            this.tbRangeV.Name = "tbRangeV";
            this.tbRangeV.ReadOnly = true;
            this.tbRangeV.Size = new System.Drawing.Size(120, 21);
            this.tbRangeV.TabIndex = 163;
            this.tbRangeV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(328, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 160;
            this.label3.Text = "电芯数量";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 162;
            this.label4.Text = "电压范围(V)";
            // 
            // tbDxCnt
            // 
            this.tbDxCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDxCnt.Location = new System.Drawing.Point(386, 7);
            this.tbDxCnt.Name = "tbDxCnt";
            this.tbDxCnt.ReadOnly = true;
            this.tbDxCnt.Size = new System.Drawing.Size(60, 21);
            this.tbDxCnt.TabIndex = 161;
            // 
            // ucMk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btDxDetail);
            this.Controls.Add(this.tbMkCode);
            this.Controls.Add(this.tbRangeR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btBind);
            this.Controls.Add(this.tbRangeV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDxCnt);
            this.Name = "ucMk";
            this.Size = new System.Drawing.Size(953, 34);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDxDetail;
        private System.Windows.Forms.TextBox tbMkCode;
        private System.Windows.Forms.TextBox tbRangeR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btBind;
        private System.Windows.Forms.TextBox tbRangeV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDxCnt;
    }
}
