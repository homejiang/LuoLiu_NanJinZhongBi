namespace SysSetting.AuditDetail
{
    partial class ucAuditControlItem
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panAuditItemTable = new System.Windows.Forms.TableLayoutPanel();
            this.tbWaitAuditerName = new System.Windows.Forms.TextBox();
            this.labAuditNote = new System.Windows.Forms.Label();
            this.tbAuditNote = new System.Windows.Forms.TextBox();
            this.labFlowName = new System.Windows.Forms.Label();
            this.labAuditDate = new System.Windows.Forms.Label();
            this.labAuditState = new System.Windows.Forms.Label();
            this.panAuditState = new System.Windows.Forms.Panel();
            this.rbWait = new System.Windows.Forms.RadioButton();
            this.rbReject = new System.Windows.Forms.RadioButton();
            this.rbPass = new System.Windows.Forms.RadioButton();
            this.labAuditerName = new System.Windows.Forms.Label();
            this.tbAuditerName = new System.Windows.Forms.TextBox();
            this.llabWaitAuditer = new System.Windows.Forms.LinkLabel();
            this.tbAuditDate = new System.Windows.Forms.TextBox();
            this.panAuditItemTable.SuspendLayout();
            this.panAuditState.SuspendLayout();
            this.SuspendLayout();
            // 
            // panAuditItemTable
            // 
            this.panAuditItemTable.ColumnCount = 4;
            this.panAuditItemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.panAuditItemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panAuditItemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.panAuditItemTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.panAuditItemTable.Controls.Add(this.tbWaitAuditerName, 1, 1);
            this.panAuditItemTable.Controls.Add(this.labAuditNote, 0, 3);
            this.panAuditItemTable.Controls.Add(this.tbAuditNote, 1, 3);
            this.panAuditItemTable.Controls.Add(this.labFlowName, 0, 0);
            this.panAuditItemTable.Controls.Add(this.labAuditDate, 2, 2);
            this.panAuditItemTable.Controls.Add(this.labAuditState, 2, 1);
            this.panAuditItemTable.Controls.Add(this.panAuditState, 3, 1);
            this.panAuditItemTable.Controls.Add(this.labAuditerName, 0, 2);
            this.panAuditItemTable.Controls.Add(this.tbAuditerName, 1, 2);
            this.panAuditItemTable.Controls.Add(this.llabWaitAuditer, 0, 1);
            this.panAuditItemTable.Controls.Add(this.tbAuditDate, 3, 2);
            this.panAuditItemTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAuditItemTable.Location = new System.Drawing.Point(0, 0);
            this.panAuditItemTable.Name = "panAuditItemTable";
            this.panAuditItemTable.RowCount = 6;
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panAuditItemTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.panAuditItemTable.Size = new System.Drawing.Size(396, 150);
            this.panAuditItemTable.TabIndex = 0;
            // 
            // tbWaitAuditerName
            // 
            this.tbWaitAuditerName.BackColor = System.Drawing.Color.White;
            this.tbWaitAuditerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWaitAuditerName.Location = new System.Drawing.Point(77, 22);
            this.tbWaitAuditerName.Name = "tbWaitAuditerName";
            this.tbWaitAuditerName.ReadOnly = true;
            this.tbWaitAuditerName.Size = new System.Drawing.Size(87, 21);
            this.tbWaitAuditerName.TabIndex = 3;
            // 
            // labAuditNote
            // 
            this.labAuditNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAuditNote.Location = new System.Drawing.Point(3, 69);
            this.labAuditNote.Name = "labAuditNote";
            this.labAuditNote.Size = new System.Drawing.Size(68, 23);
            this.labAuditNote.TabIndex = 10;
            this.labAuditNote.Text = "签字备注：";
            this.labAuditNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAuditNote
            // 
            this.panAuditItemTable.SetColumnSpan(this.tbAuditNote, 3);
            this.tbAuditNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuditNote.Location = new System.Drawing.Point(77, 72);
            this.tbAuditNote.Multiline = true;
            this.tbAuditNote.Name = "tbAuditNote";
            this.tbAuditNote.ReadOnly = true;
            this.panAuditItemTable.SetRowSpan(this.tbAuditNote, 2);
            this.tbAuditNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbAuditNote.Size = new System.Drawing.Size(316, 70);
            this.tbAuditNote.TabIndex = 11;
            // 
            // labFlowName
            // 
            this.labFlowName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panAuditItemTable.SetColumnSpan(this.labFlowName, 4);
            this.labFlowName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labFlowName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labFlowName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labFlowName.Location = new System.Drawing.Point(0, 0);
            this.labFlowName.Margin = new System.Windows.Forms.Padding(0);
            this.labFlowName.Name = "labFlowName";
            this.labFlowName.Size = new System.Drawing.Size(396, 19);
            this.labFlowName.TabIndex = 1;
            this.labFlowName.Text = "审批流程名";
            this.labFlowName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labAuditDate
            // 
            this.labAuditDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAuditDate.Location = new System.Drawing.Point(170, 46);
            this.labAuditDate.Name = "labAuditDate";
            this.labAuditDate.Size = new System.Drawing.Size(65, 23);
            this.labAuditDate.TabIndex = 8;
            this.labAuditDate.Text = "签字日期：";
            this.labAuditDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labAuditState
            // 
            this.labAuditState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAuditState.Location = new System.Drawing.Point(170, 19);
            this.labAuditState.Name = "labAuditState";
            this.labAuditState.Size = new System.Drawing.Size(65, 27);
            this.labAuditState.TabIndex = 4;
            this.labAuditState.Text = "签字状态：";
            this.labAuditState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panAuditState
            // 
            this.panAuditState.Controls.Add(this.rbWait);
            this.panAuditState.Controls.Add(this.rbReject);
            this.panAuditState.Controls.Add(this.rbPass);
            this.panAuditState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAuditState.Location = new System.Drawing.Point(238, 19);
            this.panAuditState.Margin = new System.Windows.Forms.Padding(0);
            this.panAuditState.Name = "panAuditState";
            this.panAuditState.Size = new System.Drawing.Size(158, 27);
            this.panAuditState.TabIndex = 5;
            // 
            // rbWait
            // 
            this.rbWait.AutoSize = true;
            this.rbWait.Enabled = false;
            this.rbWait.Location = new System.Drawing.Point(109, 4);
            this.rbWait.Name = "rbWait";
            this.rbWait.Size = new System.Drawing.Size(47, 16);
            this.rbWait.TabIndex = 2;
            this.rbWait.TabStop = true;
            this.rbWait.Text = "待签";
            this.rbWait.UseVisualStyleBackColor = true;
            this.rbWait.Click += new System.EventHandler(this.rbWait_Click);
            // 
            // rbReject
            // 
            this.rbReject.AutoSize = true;
            this.rbReject.Enabled = false;
            this.rbReject.Location = new System.Drawing.Point(56, 4);
            this.rbReject.Name = "rbReject";
            this.rbReject.Size = new System.Drawing.Size(47, 16);
            this.rbReject.TabIndex = 1;
            this.rbReject.TabStop = true;
            this.rbReject.Text = "拒绝";
            this.rbReject.UseVisualStyleBackColor = true;
            this.rbReject.Click += new System.EventHandler(this.rbReject_Click);
            // 
            // rbPass
            // 
            this.rbPass.AutoSize = true;
            this.rbPass.Enabled = false;
            this.rbPass.Location = new System.Drawing.Point(3, 5);
            this.rbPass.Name = "rbPass";
            this.rbPass.Size = new System.Drawing.Size(47, 16);
            this.rbPass.TabIndex = 0;
            this.rbPass.TabStop = true;
            this.rbPass.Text = "通过";
            this.rbPass.UseVisualStyleBackColor = true;
            this.rbPass.Click += new System.EventHandler(this.rbPass_Click);
            // 
            // labAuditerName
            // 
            this.labAuditerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labAuditerName.Location = new System.Drawing.Point(3, 46);
            this.labAuditerName.Name = "labAuditerName";
            this.labAuditerName.Size = new System.Drawing.Size(68, 23);
            this.labAuditerName.TabIndex = 6;
            this.labAuditerName.Text = "审 批 人：";
            this.labAuditerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAuditerName
            // 
            this.tbAuditerName.BackColor = System.Drawing.Color.White;
            this.tbAuditerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuditerName.Location = new System.Drawing.Point(77, 49);
            this.tbAuditerName.Name = "tbAuditerName";
            this.tbAuditerName.ReadOnly = true;
            this.tbAuditerName.Size = new System.Drawing.Size(87, 21);
            this.tbAuditerName.TabIndex = 7;
            // 
            // llabWaitAuditer
            // 
            this.llabWaitAuditer.AutoSize = true;
            this.llabWaitAuditer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llabWaitAuditer.Location = new System.Drawing.Point(3, 19);
            this.llabWaitAuditer.Name = "llabWaitAuditer";
            this.llabWaitAuditer.Size = new System.Drawing.Size(68, 27);
            this.llabWaitAuditer.TabIndex = 12;
            this.llabWaitAuditer.TabStop = true;
            this.llabWaitAuditer.Text = "可审批人：";
            this.llabWaitAuditer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llabWaitAuditer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabWaitAuditer_LinkClicked);
            // 
            // tbAuditDate
            // 
            this.tbAuditDate.BackColor = System.Drawing.Color.White;
            this.tbAuditDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAuditDate.Location = new System.Drawing.Point(241, 49);
            this.tbAuditDate.Name = "tbAuditDate";
            this.tbAuditDate.ReadOnly = true;
            this.tbAuditDate.Size = new System.Drawing.Size(152, 21);
            this.tbAuditDate.TabIndex = 13;
            // 
            // ucAuditControlItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panAuditItemTable);
            this.Name = "ucAuditControlItem";
            this.Size = new System.Drawing.Size(396, 150);
            this.panAuditItemTable.ResumeLayout(false);
            this.panAuditItemTable.PerformLayout();
            this.panAuditState.ResumeLayout(false);
            this.panAuditState.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panAuditItemTable;
        private System.Windows.Forms.TextBox tbWaitAuditerName;
        private System.Windows.Forms.Label labAuditDate;
        private System.Windows.Forms.Label labAuditState;
        private System.Windows.Forms.Panel panAuditState;
        private System.Windows.Forms.RadioButton rbWait;
        private System.Windows.Forms.RadioButton rbReject;
        private System.Windows.Forms.RadioButton rbPass;
        private System.Windows.Forms.Label labAuditNote;
        private System.Windows.Forms.TextBox tbAuditNote;
        private System.Windows.Forms.Label labFlowName;
        private System.Windows.Forms.Label labAuditerName;
        private System.Windows.Forms.TextBox tbAuditerName;
        private System.Windows.Forms.LinkLabel llabWaitAuditer;
        private System.Windows.Forms.TextBox tbAuditDate;
    }
}
