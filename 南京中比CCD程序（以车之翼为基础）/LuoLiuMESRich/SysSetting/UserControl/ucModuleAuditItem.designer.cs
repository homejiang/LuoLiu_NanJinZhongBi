namespace SysSetting.UserControl
{
    partial class ucModuleAuditItem
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbWaitAuditerNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFlowName = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.llabRemove = new System.Windows.Forms.LinkLabel();
            this.llabUp = new System.Windows.Forms.LinkLabel();
            this.llabDown = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbWaitAuditerNames, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbFlowName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 86);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tbWaitAuditerNames
            // 
            this.tbWaitAuditerNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWaitAuditerNames.Location = new System.Drawing.Point(77, 35);
            this.tbWaitAuditerNames.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tbWaitAuditerNames.Name = "tbWaitAuditerNames";
            this.tbWaitAuditerNames.Size = new System.Drawing.Size(254, 21);
            this.tbWaitAuditerNames.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "审批流程名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFlowName
            // 
            this.tbFlowName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFlowName.Location = new System.Drawing.Point(77, 5);
            this.tbFlowName.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tbFlowName.Name = "tbFlowName";
            this.tbFlowName.Size = new System.Drawing.Size(254, 21);
            this.tbFlowName.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkLabel1.Location = new System.Drawing.Point(3, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(71, 30);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "待审批人";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.llabRemove);
            this.panel1.Controls.Add(this.llabUp);
            this.panel1.Controls.Add(this.llabDown);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(111, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 20);
            this.panel1.TabIndex = 4;
            // 
            // llabRemove
            // 
            this.llabRemove.AutoSize = true;
            this.llabRemove.Location = new System.Drawing.Point(176, 2);
            this.llabRemove.Name = "llabRemove";
            this.llabRemove.Size = new System.Drawing.Size(29, 12);
            this.llabRemove.TabIndex = 2;
            this.llabRemove.TabStop = true;
            this.llabRemove.Text = "移除";
            this.llabRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabRemove_LinkClicked);
            // 
            // llabUp
            // 
            this.llabUp.AutoSize = true;
            this.llabUp.Location = new System.Drawing.Point(102, 2);
            this.llabUp.Name = "llabUp";
            this.llabUp.Size = new System.Drawing.Size(29, 12);
            this.llabUp.TabIndex = 1;
            this.llabUp.TabStop = true;
            this.llabUp.Text = "上移";
            this.llabUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabUp_LinkClicked);
            // 
            // llabDown
            // 
            this.llabDown.AutoSize = true;
            this.llabDown.Location = new System.Drawing.Point(140, 2);
            this.llabDown.Name = "llabDown";
            this.llabDown.Size = new System.Drawing.Size(29, 12);
            this.llabDown.TabIndex = 0;
            this.llabDown.TabStop = true;
            this.llabDown.Text = "下移";
            this.llabDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabDown_LinkClicked);
            // 
            // ucModuleAuditItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucModuleAuditItem";
            this.Size = new System.Drawing.Size(331, 86);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFlowName;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox tbWaitAuditerNames;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llabRemove;
        private System.Windows.Forms.LinkLabel llabUp;
        private System.Windows.Forms.LinkLabel llabDown;
    }
}
