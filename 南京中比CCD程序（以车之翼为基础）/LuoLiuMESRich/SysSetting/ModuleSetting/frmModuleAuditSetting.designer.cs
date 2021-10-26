namespace SysSetting.ModuleSetting
{
    partial class frmModuleAuditSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleAuditSetting));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvModule = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btAddAuditItem = new DevComponents.DotNetBar.ButtonX();
            this.btSave = new DevComponents.DotNetBar.ButtonX();
            this.ucModuleAudit1 = new SysSetting.UserControl.ucModuleAudit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvModule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(846, 535);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvModule
            // 
            this.tvModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModule.FullRowSelect = true;
            this.tvModule.HideSelection = false;
            this.tvModule.HotTracking = true;
            this.tvModule.Location = new System.Drawing.Point(0, 0);
            this.tvModule.Name = "tvModule";
            this.tvModule.Size = new System.Drawing.Size(205, 535);
            this.tvModule.TabIndex = 0;
            this.tvModule.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModule_AfterSelect);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucModuleAudit1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(637, 535);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btAddAuditItem);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 39);
            this.panel1.TabIndex = 0;
            // 
            // btAddAuditItem
            // 
            this.btAddAuditItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btAddAuditItem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btAddAuditItem.Location = new System.Drawing.Point(107, 5);
            this.btAddAuditItem.Name = "btAddAuditItem";
            this.btAddAuditItem.Size = new System.Drawing.Size(88, 30);
            this.btAddAuditItem.TabIndex = 1;
            this.btAddAuditItem.Text = "添加流程";
            this.btAddAuditItem.Click += new System.EventHandler(this.btAddAuditItem_Click);
            // 
            // btSave
            // 
            this.btSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btSave.Location = new System.Drawing.Point(13, 5);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(68, 30);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "保存";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // ucModuleAudit1
            // 
            this.ucModuleAudit1.AuditItems = ((System.Collections.Generic.List<Common.MyEntity.ModuleAuditItem>)(resources.GetObject("ucModuleAudit1.AuditItems")));
            this.ucModuleAudit1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucModuleAudit1.EditPower = false;
            this.ucModuleAudit1.Location = new System.Drawing.Point(3, 42);
            this.ucModuleAudit1.Name = "ucModuleAudit1";
            this.ucModuleAudit1.Size = new System.Drawing.Size(481, 490);
            this.ucModuleAudit1.TabIndex = 1;
            // 
            // frmModuleAuditSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 535);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmModuleAuditSetting";
            this.Text = "模块审批流程设置";
            this.Load += new System.EventHandler(this.frmModuleAuditSetting_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvModule;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btSave;
        private DevComponents.DotNetBar.ButtonX btAddAuditItem;
        private SysSetting.UserControl.ucModuleAudit ucModuleAudit1;
    }
}