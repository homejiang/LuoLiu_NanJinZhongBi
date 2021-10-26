namespace LuoLiuMES.PactM
{
    partial class frmModifyState
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStateView = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comState = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "选中的明细行信息";
            // 
            // tbInfo
            // 
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbInfo.Location = new System.Drawing.Point(12, 34);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInfo.Size = new System.Drawing.Size(674, 77);
            this.tbInfo.TabIndex = 1;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(247, 185);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(169, 48);
            this.btTrue.TabIndex = 2;
            this.btTrue.Text = "确 认";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前状态";
            // 
            // tbStateView
            // 
            this.tbStateView.BackColor = System.Drawing.SystemColors.Control;
            this.tbStateView.Location = new System.Drawing.Point(247, 117);
            this.tbStateView.Name = "tbStateView";
            this.tbStateView.Size = new System.Drawing.Size(205, 30);
            this.tbStateView.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "修改状态";
            // 
            // comState
            // 
            this.comState.BackColor = System.Drawing.Color.White;
            this.comState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comState.FormattingEnabled = true;
            this.comState.Location = new System.Drawing.Point(247, 151);
            this.comState.Name = "comState";
            this.comState.Size = new System.Drawing.Size(205, 28);
            this.comState.TabIndex = 11;
            // 
            // frmModifyState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 299);
            this.Controls.Add(this.comState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStateView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyState";
            this.ShowIcon = false;
            this.Text = "修改明细备注内容";
            this.Load += new System.EventHandler(this.frmDetailAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStateView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comState;
    }
}