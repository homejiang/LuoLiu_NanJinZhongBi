namespace SysSetting.AuditDetail
{
    partial class frmAuditDetail
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbAuditStateView = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSendAuditDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSendAuditerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btClose = new System.Windows.Forms.Button();
            this.btTrue = new System.Windows.Forms.Button();
            this.pbRemove = new System.Windows.Forms.PictureBox();
            this.pbCreate = new System.Windows.Forms.PictureBox();
            this.btAudit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreate)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panDetail, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 214);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panDetail
            // 
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(0, 29);
            this.panDetail.Margin = new System.Windows.Forms.Padding(0);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(417, 150);
            this.panDetail.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbAuditStateView);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbSendAuditDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbSendAuditerName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 29);
            this.panel1.TabIndex = 1;
            // 
            // tbAuditStateView
            // 
            this.tbAuditStateView.BackColor = System.Drawing.Color.White;
            this.tbAuditStateView.Location = new System.Drawing.Point(331, 4);
            this.tbAuditStateView.Name = "tbAuditStateView";
            this.tbAuditStateView.ReadOnly = true;
            this.tbAuditStateView.Size = new System.Drawing.Size(76, 21);
            this.tbAuditStateView.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "审批状态";
            // 
            // tbSendAuditDate
            // 
            this.tbSendAuditDate.BackColor = System.Drawing.Color.White;
            this.tbSendAuditDate.Location = new System.Drawing.Point(172, 4);
            this.tbSendAuditDate.Name = "tbSendAuditDate";
            this.tbSendAuditDate.ReadOnly = true;
            this.tbSendAuditDate.Size = new System.Drawing.Size(101, 21);
            this.tbSendAuditDate.TabIndex = 3;
            this.tbSendAuditDate.Text = "2009-01-9 11:43";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "送审时间";
            // 
            // tbSendAuditerName
            // 
            this.tbSendAuditerName.BackColor = System.Drawing.Color.White;
            this.tbSendAuditerName.Location = new System.Drawing.Point(49, 4);
            this.tbSendAuditerName.Name = "tbSendAuditerName";
            this.tbSendAuditerName.ReadOnly = true;
            this.tbSendAuditerName.Size = new System.Drawing.Size(65, 21);
            this.tbSendAuditerName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "送审人";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btAudit);
            this.panel2.Controls.Add(this.pbRemove);
            this.panel2.Controls.Add(this.pbCreate);
            this.panel2.Controls.Add(this.btClose);
            this.panel2.Controls.Add(this.btTrue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 35);
            this.panel2.TabIndex = 2;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(253, 7);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(90, 7);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(75, 23);
            this.btTrue.TabIndex = 0;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // pbRemove
            // 
            this.pbRemove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbRemove.Image = global::SysSetting.Properties.Resources.del;
            this.pbRemove.Location = new System.Drawing.Point(36, 11);
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.Size = new System.Drawing.Size(16, 16);
            this.pbRemove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbRemove.TabIndex = 3;
            this.pbRemove.TabStop = false;
            this.pbRemove.Click += new System.EventHandler(this.pbRemove_Click);
            // 
            // pbCreate
            // 
            this.pbCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCreate.Image = global::SysSetting.Properties.Resources.create;
            this.pbCreate.Location = new System.Drawing.Point(9, 11);
            this.pbCreate.Name = "pbCreate";
            this.pbCreate.Size = new System.Drawing.Size(16, 16);
            this.pbCreate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCreate.TabIndex = 2;
            this.pbCreate.TabStop = false;
            this.pbCreate.Click += new System.EventHandler(this.pbCreate_Click);
            // 
            // btAudit
            // 
            this.btAudit.Location = new System.Drawing.Point(172, 7);
            this.btAudit.Name = "btAudit";
            this.btAudit.Size = new System.Drawing.Size(75, 23);
            this.btAudit.TabIndex = 4;
            this.btAudit.Text = "提交审批";
            this.btAudit.UseVisualStyleBackColor = true;
            this.btAudit.Click += new System.EventHandler(this.btAudit_Click);
            // 
            // frmAuditDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 214);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuditDetail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "审批明细";
            this.Load += new System.EventHandler(this.frmAuditDetail_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSendAuditDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSendAuditerName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.TextBox tbAuditStateView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbCreate;
        private System.Windows.Forms.PictureBox pbRemove;
        private System.Windows.Forms.Button btAudit;
    }
}