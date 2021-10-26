namespace LuoLiuMES.PlanM
{
    partial class frmModifyPlanDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifyPlanDetail));
            this.label1 = new System.Windows.Forms.Label();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numPans = new MyControl.NumericBox();
            this.tbOrgQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.btTrue.Location = new System.Drawing.Point(262, 209);
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
            this.label2.Location = new System.Drawing.Point(144, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "修改计划数";
            // 
            // numPans
            // 
            this.numPans.BindValue = ((object)(resources.GetObject("numPans.BindValue")));
            this.numPans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPans.FilterQuanJiao = false;
            this.numPans.Formart = "########0";
            this.numPans.IsHundred = false;
            this.numPans.IsPercent = false;
            this.numPans.Location = new System.Drawing.Point(262, 153);
            this.numPans.Name = "numPans";
            this.numPans.Size = new System.Drawing.Size(169, 30);
            this.numPans.TabIndex = 4;
            // 
            // tbOrgQty
            // 
            this.tbOrgQty.BackColor = System.Drawing.SystemColors.Control;
            this.tbOrgQty.Location = new System.Drawing.Point(262, 117);
            this.tbOrgQty.Name = "tbOrgQty";
            this.tbOrgQty.Size = new System.Drawing.Size(169, 30);
            this.tbOrgQty.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "当前计划数";
            // 
            // frmModifyPlanDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 269);
            this.Controls.Add(this.tbOrgQty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPans);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbInfo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModifyPlanDetail";
            this.ShowIcon = false;
            this.Text = "修改明细盘数";
            this.Load += new System.EventHandler(this.frmDetailAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label label2;
        private MyControl.NumericBox numPans;
        private System.Windows.Forms.TextBox tbOrgQty;
        private System.Windows.Forms.Label label3;
    }
}