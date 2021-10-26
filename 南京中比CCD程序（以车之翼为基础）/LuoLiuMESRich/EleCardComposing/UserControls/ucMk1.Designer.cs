namespace EleCardComposing.UserControls
{
    partial class ucMk1
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
            this.components = new System.ComponentModel.Container();
            this.btDxDetail = new System.Windows.Forms.Button();
            this.tbMkCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btBind = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btDxDetail
            // 
            this.btDxDetail.Location = new System.Drawing.Point(889, 4);
            this.btDxDetail.Name = "btDxDetail";
            this.btDxDetail.Size = new System.Drawing.Size(57, 26);
            this.btDxDetail.TabIndex = 166;
            this.btDxDetail.Text = "详细";
            this.btDxDetail.UseVisualStyleBackColor = true;
            this.btDxDetail.Click += new System.EventHandler(this.btDxDetail_Click);
            // 
            // tbMkCode
            // 
            this.tbMkCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMkCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMkCode.Location = new System.Drawing.Point(66, 7);
            this.tbMkCode.Name = "tbMkCode";
            this.tbMkCode.Size = new System.Drawing.Size(137, 24);
            this.tbMkCode.TabIndex = 158;
            this.tbMkCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMkCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 157;
            this.label1.Text = "模块编码";
            // 
            // btBind
            // 
            this.btBind.Location = new System.Drawing.Point(207, 4);
            this.btBind.Name = "btBind";
            this.btBind.Size = new System.Drawing.Size(76, 26);
            this.btBind.TabIndex = 159;
            this.btBind.Text = "加载电芯";
            this.btBind.UseVisualStyleBackColor = true;
            this.btBind.Click += new System.EventHandler(this.btBindDxDetail_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 160;
            this.label3.Text = "模块信息";
            // 
            // tbInfo
            // 
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInfo.Location = new System.Drawing.Point(346, 7);
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.Size = new System.Drawing.Size(540, 21);
            this.tbInfo.TabIndex = 167;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucMk1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.btDxDetail);
            this.Controls.Add(this.tbMkCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btBind);
            this.Controls.Add(this.label3);
            this.Name = "ucMk1";
            this.Size = new System.Drawing.Size(953, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btDxDetail;
        private System.Windows.Forms.TextBox tbMkCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Timer timer1;
    }
}
