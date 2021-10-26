namespace SysSetting.ModuleSetting
{
    partial class frmModuleSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModuleSetting));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tvModules = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.NvbtGroupAdd = new DevComponents.DotNetBar.ButtonItem();
            this.nvbtGroupEdit = new DevComponents.DotNetBar.ButtonItem();
            this.NvbtGroupRemove = new DevComponents.DotNetBar.ButtonItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.numEnumNo = new MyControl.NumericBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsAutoCode = new System.Windows.Forms.CheckBox();
            this.chkNeedAudit = new System.Windows.Forms.CheckBox();
            this.chkCanDelete = new System.Windows.Forms.CheckBox();
            this.chkCanEdit = new System.Windows.Forms.CheckBox();
            this.chkCanNew = new System.Windows.Forms.CheckBox();
            this.numSortID = new MyControl.NumericBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbModuleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.nvbtEdit = new DevComponents.DotNetBar.ButtonItem();
            this.nvbtRemove = new DevComponents.DotNetBar.ButtonItem();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btNew = new DevComponents.DotNetBar.ButtonItem();
            this.btOpen = new DevComponents.DotNetBar.ButtonItem();
            this.btDelete = new DevComponents.DotNetBar.ButtonItem();
            this.btPutOut = new DevComponents.DotNetBar.ButtonItem();
            this.btClose = new DevComponents.DotNetBar.ButtonItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(904, 524);
            this.splitContainer1.SplitterDistance = 132;
            this.splitContainer1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tvModules, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(132, 524);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tvModules
            // 
            this.tvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvModules.FullRowSelect = true;
            this.tvModules.HideSelection = false;
            this.tvModules.HotTracking = true;
            this.tvModules.Location = new System.Drawing.Point(3, 30);
            this.tvModules.Name = "tvModules";
            this.tvModules.Size = new System.Drawing.Size(126, 491);
            this.tvModules.TabIndex = 0;
            this.tvModules.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvGroup_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bar2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(132, 27);
            this.panel1.TabIndex = 1;
            // 
            // bar2
            // 
            this.bar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.NvbtGroupAdd,
            this.nvbtGroupEdit,
            this.NvbtGroupRemove});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(132, 28);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar2.TabIndex = 0;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // NvbtGroupAdd
            // 
            this.NvbtGroupAdd.Image = global::SysSetting.Properties.Resources.create;
            this.NvbtGroupAdd.ImagePaddingHorizontal = 8;
            this.NvbtGroupAdd.Name = "NvbtGroupAdd";
            this.NvbtGroupAdd.Text = "create";
            this.NvbtGroupAdd.Tooltip = "添加模块组";
            this.NvbtGroupAdd.Click += new System.EventHandler(this.NvbtGroupAdd_Click);
            // 
            // nvbtGroupEdit
            // 
            this.nvbtGroupEdit.Image = global::SysSetting.Properties.Resources.edit;
            this.nvbtGroupEdit.ImagePaddingHorizontal = 8;
            this.nvbtGroupEdit.Name = "nvbtGroupEdit";
            this.nvbtGroupEdit.Text = "edit";
            this.nvbtGroupEdit.Tooltip = "编辑模块组";
            this.nvbtGroupEdit.Click += new System.EventHandler(this.nvbtGroupEdit_Click);
            // 
            // NvbtGroupRemove
            // 
            this.NvbtGroupRemove.Image = global::SysSetting.Properties.Resources.del;
            this.NvbtGroupRemove.ImagePaddingHorizontal = 8;
            this.NvbtGroupRemove.Name = "NvbtGroupRemove";
            this.NvbtGroupRemove.Text = "del";
            this.NvbtGroupRemove.Tooltip = "移除模块组";
            this.NvbtGroupRemove.Click += new System.EventHandler(this.NvbtGroupRemove_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(768, 524);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.numEnumNo);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.chkIsAutoCode);
            this.groupPanel1.Controls.Add(this.chkNeedAudit);
            this.groupPanel1.Controls.Add(this.chkCanDelete);
            this.groupPanel1.Controls.Add(this.chkCanEdit);
            this.groupPanel1.Controls.Add(this.chkCanNew);
            this.groupPanel1.Controls.Add(this.numSortID);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.tbCode);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.btAdd);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.tbModuleName);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.DrawTitleBox = false;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(768, 82);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "新增模块";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(421, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "*";
            // 
            // numEnumNo
            // 
            this.numEnumNo.BindValue = ((object)(resources.GetObject("numEnumNo.BindValue")));
            this.numEnumNo.FilterQuanJiao = false;
            this.numEnumNo.Formart = "#######0";
            this.numEnumNo.IsHundred = false;
            this.numEnumNo.IsPercent = false;
            this.numEnumNo.Location = new System.Drawing.Point(361, 1);
            this.numEnumNo.Name = "numEnumNo";
            this.numEnumNo.Size = new System.Drawing.Size(56, 21);
            this.numEnumNo.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(318, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "标识码";
            // 
            // chkIsAutoCode
            // 
            this.chkIsAutoCode.AutoSize = true;
            this.chkIsAutoCode.BackColor = System.Drawing.Color.Transparent;
            this.chkIsAutoCode.Location = new System.Drawing.Point(472, 35);
            this.chkIsAutoCode.Name = "chkIsAutoCode";
            this.chkIsAutoCode.Size = new System.Drawing.Size(72, 16);
            this.chkIsAutoCode.TabIndex = 14;
            this.chkIsAutoCode.Text = "自动编码";
            this.chkIsAutoCode.UseVisualStyleBackColor = false;
            // 
            // chkNeedAudit
            // 
            this.chkNeedAudit.AutoSize = true;
            this.chkNeedAudit.BackColor = System.Drawing.Color.Transparent;
            this.chkNeedAudit.Location = new System.Drawing.Point(360, 35);
            this.chkNeedAudit.Name = "chkNeedAudit";
            this.chkNeedAudit.Size = new System.Drawing.Size(72, 16);
            this.chkNeedAudit.TabIndex = 13;
            this.chkNeedAudit.Text = "需要审批";
            this.chkNeedAudit.UseVisualStyleBackColor = false;
            // 
            // chkCanDelete
            // 
            this.chkCanDelete.AutoSize = true;
            this.chkCanDelete.BackColor = System.Drawing.Color.Transparent;
            this.chkCanDelete.Location = new System.Drawing.Point(233, 35);
            this.chkCanDelete.Name = "chkCanDelete";
            this.chkCanDelete.Size = new System.Drawing.Size(72, 16);
            this.chkCanDelete.TabIndex = 12;
            this.chkCanDelete.Text = "可以删除";
            this.chkCanDelete.UseVisualStyleBackColor = false;
            // 
            // chkCanEdit
            // 
            this.chkCanEdit.AutoSize = true;
            this.chkCanEdit.BackColor = System.Drawing.Color.Transparent;
            this.chkCanEdit.Location = new System.Drawing.Point(122, 35);
            this.chkCanEdit.Name = "chkCanEdit";
            this.chkCanEdit.Size = new System.Drawing.Size(72, 16);
            this.chkCanEdit.TabIndex = 11;
            this.chkCanEdit.Text = "可以编辑";
            this.chkCanEdit.UseVisualStyleBackColor = false;
            // 
            // chkCanNew
            // 
            this.chkCanNew.AutoSize = true;
            this.chkCanNew.BackColor = System.Drawing.Color.Transparent;
            this.chkCanNew.Location = new System.Drawing.Point(11, 36);
            this.chkCanNew.Name = "chkCanNew";
            this.chkCanNew.Size = new System.Drawing.Size(72, 16);
            this.chkCanNew.TabIndex = 10;
            this.chkCanNew.Text = "可以创建";
            this.chkCanNew.UseVisualStyleBackColor = false;
            // 
            // numSortID
            // 
            this.numSortID.BindValue = ((object)(resources.GetObject("numSortID.BindValue")));
            this.numSortID.FilterQuanJiao = false;
            this.numSortID.Formart = "#######0";
            this.numSortID.IsHundred = false;
            this.numSortID.IsPercent = false;
            this.numSortID.Location = new System.Drawing.Point(488, 2);
            this.numSortID.Name = "numSortID";
            this.numSortID.Size = new System.Drawing.Size(56, 21);
            this.numSortID.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(138, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(302, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "*";
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(60, 0);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(76, 21);
            this.tbCode.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "模块编码";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(561, 7);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 43);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "新 增";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(433, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "排序字段";
            // 
            // tbModuleName
            // 
            this.tbModuleName.Location = new System.Drawing.Point(199, 1);
            this.tbModuleName.Name = "tbModuleName";
            this.tbModuleName.Size = new System.Drawing.Size(100, 21);
            this.tbModuleName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(155, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "模块名";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.tableLayoutPanel3);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.DrawTitleBox = false;
            this.groupPanel2.Location = new System.Drawing.Point(0, 82);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(768, 442);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "已添加模块";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.dgvList, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(762, 418);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 28);
            this.panel2.TabIndex = 0;
            // 
            // bar1
            // 
            this.bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.nvbtEdit,
            this.nvbtRemove});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(762, 28);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // nvbtEdit
            // 
            this.nvbtEdit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.nvbtEdit.Image = global::SysSetting.Properties.Resources.edit;
            this.nvbtEdit.ImagePaddingHorizontal = 8;
            this.nvbtEdit.Name = "nvbtEdit";
            this.nvbtEdit.Text = "编辑";
            this.nvbtEdit.Click += new System.EventHandler(this.nvbtEdit_Click);
            // 
            // nvbtRemove
            // 
            this.nvbtRemove.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.nvbtRemove.Image = global::SysSetting.Properties.Resources.del;
            this.nvbtRemove.ImagePaddingHorizontal = 8;
            this.nvbtRemove.Name = "nvbtRemove";
            this.nvbtRemove.Text = "移除";
            this.nvbtRemove.Click += new System.EventHandler(this.nvbtRemove_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(3, 31);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 20;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(756, 384);
            this.dgvList.TabIndex = 1;
            this.dgvList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvList_CellMouseDoubleClick);
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "ModuleCode";
            this.Column4.HeaderText = "模块编码";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ModuleName";
            this.Column1.HeaderText = "模块名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "SortID";
            this.Column3.HeaderText = "排序字段";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "GroupName";
            this.Column2.HeaderText = "所属模块组";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 90;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "EnumNo";
            this.Column5.HeaderText = "模块标识符";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 88;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "CanNewView";
            this.Column6.HeaderText = "新增功能";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "CanEditView";
            this.Column7.HeaderText = "编辑功能";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 80;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "CanDeleteView";
            this.Column8.HeaderText = "删除功能";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "NeedAuditView";
            this.Column9.HeaderText = "是否需要审批";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "IsAutoCodeView";
            this.Column10.HeaderText = "可自动获取编码";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 120;
            // 
            // btNew
            // 
            this.btNew.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btNew.ImagePaddingHorizontal = 8;
            this.btNew.Name = "btNew";
            this.btNew.Text = "新建";
            // 
            // btOpen
            // 
            this.btOpen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btOpen.ImagePaddingHorizontal = 8;
            this.btOpen.Name = "btOpen";
            this.btOpen.Text = "打开";
            // 
            // btDelete
            // 
            this.btDelete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btDelete.ImagePaddingHorizontal = 8;
            this.btDelete.Name = "btDelete";
            this.btDelete.Text = "删除";
            // 
            // btPutOut
            // 
            this.btPutOut.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btPutOut.ImagePaddingHorizontal = 8;
            this.btPutOut.Name = "btPutOut";
            this.btPutOut.Text = "导出Excel";
            // 
            // btClose
            // 
            this.btClose.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btClose.ImagePaddingHorizontal = 8;
            this.btClose.Name = "btClose";
            this.btClose.Text = "关闭";
            // 
            // frmModuleSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 524);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmModuleSetting";
            this.Text = "模块设置";
            this.Load += new System.EventHandler(this.frmModuleSetting_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TreeView tvModules;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.ButtonItem btNew;
        private DevComponents.DotNetBar.ButtonItem btOpen;
        private DevComponents.DotNetBar.ButtonItem btDelete;
        private DevComponents.DotNetBar.ButtonItem btPutOut;
        private DevComponents.DotNetBar.ButtonItem btClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbModuleName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem nvbtEdit;
        private DevComponents.DotNetBar.ButtonItem nvbtRemove;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private MyControl.NumericBox numSortID;
        private System.Windows.Forms.CheckBox chkIsAutoCode;
        private System.Windows.Forms.CheckBox chkNeedAudit;
        private System.Windows.Forms.CheckBox chkCanDelete;
        private System.Windows.Forms.CheckBox chkCanEdit;
        private System.Windows.Forms.CheckBox chkCanNew;
        private MyControl.NumericBox numEnumNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private DevComponents.DotNetBar.ButtonItem NvbtGroupAdd;
        private DevComponents.DotNetBar.ButtonItem nvbtGroupEdit;
        private DevComponents.DotNetBar.ButtonItem NvbtGroupRemove;
    }
}