namespace EleCardComposing.DataM
{
    partial class frmComposedData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvList = new MyControl.MyDataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labOfcListenStatus = new System.Windows.Forms.Label();
            this.tbPcbInfo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbPCBCode = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbBOMSpec = new MyControl.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStateView = new MyControl.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCnt = new MyControl.MyTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRangeR = new MyControl.MyTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbRangeV = new MyControl.MyTextBox();
            this.tbStation = new MyControl.MyTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMac = new MyControl.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOperator = new MyControl.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPactInfo = new MyControl.MyTextBox();
            this.tbFinishTime = new MyControl.MyTextBox();
            this.tbCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.tsbOutputExcel = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbdRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbdGradeView = new System.Windows.Forms.ToolStripButton();
            this.tsbPrinterSet = new System.Windows.Forms.ToolStripButton();
            this.tsbPrinting = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 575);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column11,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column1,
            this.Column9});
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(0, 341);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidth = 37;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.ShowLineNo = true;
            this.dgvList.Size = new System.Drawing.Size(890, 234);
            this.dgvList.TabIndex = 6;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "ChildCode";
            this.Column8.HeaderText = "模块编号";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 118;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Spec";
            this.Column2.HeaderText = "模块BOM结构";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "VersionNo";
            this.Column3.HeaderText = "版本号";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 68;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "DxCnt";
            this.Column11.HeaderText = "模块电芯数量";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 110;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "MinV";
            dataGridViewCellStyle17.Format = "#########0.######";
            this.Column13.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column13.HeaderText = "最小电压(v)";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "MaxV";
            dataGridViewCellStyle18.Format = "#########0.######";
            this.Column14.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column14.HeaderText = "最大电压(v)";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "MinR";
            dataGridViewCellStyle19.Format = "#########0.######";
            this.Column15.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column15.HeaderText = "最小电阻(mΩ)";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 110;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "MaxR";
            dataGridViewCellStyle20.Format = "#########0.######";
            this.Column16.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column16.HeaderText = "最大电阻(mΩ)";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 110;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "PactCode";
            this.Column1.HeaderText = "任务单号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "";
            this.Column9.MinimumWidth = 2;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labOfcListenStatus);
            this.panel1.Controls.Add(this.tbPcbInfo);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.tbPCBCode);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.tbBOMSpec);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbStateView);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbCnt);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.tbRangeR);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbRangeV);
            this.panel1.Controls.Add(this.tbStation);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tbMac);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbOperator);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbPactInfo);
            this.panel1.Controls.Add(this.tbFinishTime);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 310);
            this.panel1.TabIndex = 2;
            // 
            // labOfcListenStatus
            // 
            this.labOfcListenStatus.BackColor = System.Drawing.Color.White;
            this.labOfcListenStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labOfcListenStatus.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labOfcListenStatus.ForeColor = System.Drawing.Color.Black;
            this.labOfcListenStatus.Location = new System.Drawing.Point(545, 208);
            this.labOfcListenStatus.Name = "labOfcListenStatus";
            this.labOfcListenStatus.Size = new System.Drawing.Size(152, 25);
            this.labOfcListenStatus.TabIndex = 217;
            this.labOfcListenStatus.Text = "unkown";
            this.labOfcListenStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPcbInfo
            // 
            this.tbPcbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPcbInfo.Location = new System.Drawing.Point(77, 240);
            this.tbPcbInfo.Multiline = true;
            this.tbPcbInfo.Name = "tbPcbInfo";
            this.tbPcbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPcbInfo.Size = new System.Drawing.Size(803, 58);
            this.tbPcbInfo.TabIndex = 215;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 246);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 214;
            this.label8.Text = "检测信息";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(479, 214);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 14);
            this.label17.TabIndex = 213;
            this.label17.Text = "检测结果";
            // 
            // tbPCBCode
            // 
            this.tbPCBCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPCBCode.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPCBCode.Location = new System.Drawing.Point(77, 209);
            this.tbPCBCode.Name = "tbPCBCode";
            this.tbPCBCode.Size = new System.Drawing.Size(380, 24);
            this.tbPCBCode.TabIndex = 212;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 216);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 14);
            this.label16.TabIndex = 211;
            this.label16.Text = "保护板";
            // 
            // tbBOMSpec
            // 
            this.tbBOMSpec.AcceptsReturn = true;
            this.tbBOMSpec.BackColor = System.Drawing.Color.White;
            this.tbBOMSpec.FilterQuanJiao = true;
            this.tbBOMSpec.IsUpper = false;
            this.tbBOMSpec.Location = new System.Drawing.Point(77, 180);
            this.tbBOMSpec.Name = "tbBOMSpec";
            this.tbBOMSpec.ReadOnly = true;
            this.tbBOMSpec.Size = new System.Drawing.Size(380, 23);
            this.tbBOMSpec.TabIndex = 69;
            this.tbBOMSpec.TextSplitWorld = "、";
            this.tbBOMSpec.ValueSplitWorld = "|";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 14);
            this.label7.TabIndex = 68;
            this.label7.Text = "BOM结构";
            // 
            // tbStateView
            // 
            this.tbStateView.AcceptsReturn = true;
            this.tbStateView.BackColor = System.Drawing.Color.White;
            this.tbStateView.FilterQuanJiao = true;
            this.tbStateView.IsUpper = false;
            this.tbStateView.Location = new System.Drawing.Point(545, 180);
            this.tbStateView.Name = "tbStateView";
            this.tbStateView.ReadOnly = true;
            this.tbStateView.Size = new System.Drawing.Size(335, 23);
            this.tbStateView.TabIndex = 67;
            this.tbStateView.TextSplitWorld = "、";
            this.tbStateView.ValueSplitWorld = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 66;
            this.label6.Text = "模组状态";
            // 
            // tbCnt
            // 
            this.tbCnt.AcceptsReturn = true;
            this.tbCnt.BackColor = System.Drawing.Color.White;
            this.tbCnt.FilterQuanJiao = true;
            this.tbCnt.IsUpper = false;
            this.tbCnt.Location = new System.Drawing.Point(799, 69);
            this.tbCnt.Name = "tbCnt";
            this.tbCnt.ReadOnly = true;
            this.tbCnt.Size = new System.Drawing.Size(81, 23);
            this.tbCnt.TabIndex = 65;
            this.tbCnt.TextSplitWorld = "、";
            this.tbCnt.ValueSplitWorld = "|";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(734, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 64;
            this.label12.Text = "电芯数量";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(490, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 14);
            this.label11.TabIndex = 63;
            this.label11.Text = "电阻范围(v)";
            // 
            // tbRangeR
            // 
            this.tbRangeR.BackColor = System.Drawing.Color.White;
            this.tbRangeR.FilterQuanJiao = true;
            this.tbRangeR.IsUpper = false;
            this.tbRangeR.Location = new System.Drawing.Point(575, 70);
            this.tbRangeR.Name = "tbRangeR";
            this.tbRangeR.ReadOnly = true;
            this.tbRangeR.Size = new System.Drawing.Size(151, 23);
            this.tbRangeR.TabIndex = 62;
            this.tbRangeR.TextSplitWorld = "、";
            this.tbRangeR.ValueSplitWorld = "|";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 14);
            this.label10.TabIndex = 61;
            this.label10.Text = "电压范围(v)";
            // 
            // tbRangeV
            // 
            this.tbRangeV.BackColor = System.Drawing.Color.White;
            this.tbRangeV.FilterQuanJiao = true;
            this.tbRangeV.IsUpper = false;
            this.tbRangeV.Location = new System.Drawing.Point(336, 69);
            this.tbRangeV.Name = "tbRangeV";
            this.tbRangeV.ReadOnly = true;
            this.tbRangeV.Size = new System.Drawing.Size(151, 23);
            this.tbRangeV.TabIndex = 60;
            this.tbRangeV.TextSplitWorld = "、";
            this.tbRangeV.ValueSplitWorld = "|";
            // 
            // tbStation
            // 
            this.tbStation.AcceptsReturn = true;
            this.tbStation.BackColor = System.Drawing.Color.White;
            this.tbStation.FilterQuanJiao = true;
            this.tbStation.IsUpper = false;
            this.tbStation.Location = new System.Drawing.Point(77, 69);
            this.tbStation.Name = "tbStation";
            this.tbStation.ReadOnly = true;
            this.tbStation.Size = new System.Drawing.Size(165, 23);
            this.tbStation.TabIndex = 59;
            this.tbStation.TextSplitWorld = "、";
            this.tbStation.ValueSplitWorld = "|";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 58;
            this.label9.Text = "工作站";
            // 
            // tbMac
            // 
            this.tbMac.AcceptsReturn = true;
            this.tbMac.BackColor = System.Drawing.Color.White;
            this.tbMac.FilterQuanJiao = true;
            this.tbMac.IsUpper = false;
            this.tbMac.Location = new System.Drawing.Point(575, 42);
            this.tbMac.Name = "tbMac";
            this.tbMac.ReadOnly = true;
            this.tbMac.Size = new System.Drawing.Size(151, 23);
            this.tbMac.TabIndex = 57;
            this.tbMac.TextSplitWorld = "、";
            this.tbMac.ValueSplitWorld = "|";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 56;
            this.label5.Text = "作业机台";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 48;
            this.label4.Text = "关联任务";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 14);
            this.label2.TabIndex = 47;
            this.label2.Text = "锁装完成时间";
            // 
            // tbOperator
            // 
            this.tbOperator.AcceptsReturn = true;
            this.tbOperator.BackColor = System.Drawing.Color.White;
            this.tbOperator.FilterQuanJiao = true;
            this.tbOperator.IsUpper = false;
            this.tbOperator.Location = new System.Drawing.Point(799, 42);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.ReadOnly = true;
            this.tbOperator.Size = new System.Drawing.Size(81, 23);
            this.tbOperator.TabIndex = 42;
            this.tbOperator.TextSplitWorld = "、";
            this.tbOperator.ValueSplitWorld = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(734, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 41;
            this.label3.Text = "作业人员";
            // 
            // tbPactInfo
            // 
            this.tbPactInfo.BackColor = System.Drawing.Color.White;
            this.tbPactInfo.FilterQuanJiao = true;
            this.tbPactInfo.IsUpper = false;
            this.tbPactInfo.Location = new System.Drawing.Point(77, 97);
            this.tbPactInfo.Multiline = true;
            this.tbPactInfo.Name = "tbPactInfo";
            this.tbPactInfo.ReadOnly = true;
            this.tbPactInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbPactInfo.Size = new System.Drawing.Size(803, 77);
            this.tbPactInfo.TabIndex = 39;
            this.tbPactInfo.TextSplitWorld = "、";
            this.tbPactInfo.ValueSplitWorld = "|";
            // 
            // tbFinishTime
            // 
            this.tbFinishTime.BackColor = System.Drawing.Color.White;
            this.tbFinishTime.FilterQuanJiao = true;
            this.tbFinishTime.IsUpper = false;
            this.tbFinishTime.Location = new System.Drawing.Point(336, 42);
            this.tbFinishTime.Name = "tbFinishTime";
            this.tbFinishTime.ReadOnly = true;
            this.tbFinishTime.Size = new System.Drawing.Size(151, 23);
            this.tbFinishTime.TabIndex = 37;
            this.tbFinishTime.TextSplitWorld = "、";
            this.tbFinishTime.ValueSplitWorld = "|";
            // 
            // tbCode
            // 
            this.tbCode.FilterQuanJiao = true;
            this.tbCode.IsUpper = false;
            this.tbCode.Location = new System.Drawing.Point(77, 42);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(165, 23);
            this.tbCode.TabIndex = 36;
            this.tbCode.Text = "WXCA000A3097E0006LN4";
            this.tbCode.TextSplitWorld = "、";
            this.tbCode.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 35;
            this.label1.Text = "模组编号";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDel,
            this.tsbPrinting,
            this.tsbPrinterSet,
            this.tsbOutputExcel,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(890, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDel
            // 
            this.tsbDel.Image = global::EleCardComposing.Properties.Resources.Del25;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(103, 29);
            this.tsbDel.Text = "删除锁装数据";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // tsbOutputExcel
            // 
            this.tsbOutputExcel.Image = global::EleCardComposing.Properties.Resources.EXCEL;
            this.tsbOutputExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOutputExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOutputExcel.Name = "tsbOutputExcel";
            this.tsbOutputExcel.Size = new System.Drawing.Size(89, 29);
            this.tsbOutputExcel.Text = "导出Excel";
            this.tsbOutputExcel.Click += new System.EventHandler(this.tsbOutputExcel_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::EleCardComposing.Properties.Resources.exit25;
            this.tsbClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Margin = new System.Windows.Forms.Padding(15, 1, 0, 2);
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(61, 29);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbdRefresh,
            this.tsbdGradeView});
            this.toolStrip2.Location = new System.Drawing.Point(0, 310);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(890, 31);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbdRefresh
            // 
            this.tsbdRefresh.Image = global::EleCardComposing.Properties.Resources.refresh_18;
            this.tsbdRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdRefresh.Name = "tsbdRefresh";
            this.tsbdRefresh.Size = new System.Drawing.Size(74, 28);
            this.tsbdRefresh.Text = "刷新数据";
            // 
            // tsbdGradeView
            // 
            this.tsbdGradeView.Image = global::EleCardComposing.Properties.Resources.expExe;
            this.tsbdGradeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbdGradeView.Name = "tsbdGradeView";
            this.tsbdGradeView.Size = new System.Drawing.Size(76, 28);
            this.tsbdGradeView.Text = "列表显示";
            this.tsbdGradeView.Click += new System.EventHandler(this.tsbdGradeView_Click);
            // 
            // tsbPrinterSet
            // 
            this.tsbPrinterSet.Image = global::EleCardComposing.Properties.Resources.print;
            this.tsbPrinterSet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrinterSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrinterSet.Name = "tsbPrinterSet";
            this.tsbPrinterSet.Size = new System.Drawing.Size(100, 29);
            this.tsbPrinterSet.Text = "设置打印机";
            this.tsbPrinterSet.Click += new System.EventHandler(this.tsbPrinterSet_Click);
            // 
            // tsbPrinting
            // 
            this.tsbPrinting.Image = global::EleCardComposing.Properties.Resources.print;
            this.tsbPrinting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrinting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrinting.Name = "tsbPrinting";
            this.tsbPrinting.Size = new System.Drawing.Size(112, 29);
            this.tsbPrinting.Text = "打印成品标签";
            this.tsbPrinting.Click += new System.EventHandler(this.tsbPrinting_Click);
            // 
            // frmComposedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmComposedData";
            this.Text = "电芯模块锁装记录";
            this.Load += new System.EventHandler(this.frmBoxedData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripButton tsbOutputExcel;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private MyControl.MyTextBox tbOperator;
        private System.Windows.Forms.Label label3;
        private MyControl.MyTextBox tbPactInfo;
        private MyControl.MyTextBox tbFinishTime;
        private MyControl.MyTextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private MyControl.MyTextBox tbMac;
        private System.Windows.Forms.Label label5;
        private MyControl.MyTextBox tbStation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private MyControl.MyTextBox tbRangeV;
        private System.Windows.Forms.Label label11;
        private MyControl.MyTextBox tbRangeR;
        private MyControl.MyTextBox tbCnt;
        private System.Windows.Forms.Label label12;
        private MyControl.MyTextBox tbStateView;
        private System.Windows.Forms.Label label6;
        private MyControl.MyTextBox tbBOMSpec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labOfcListenStatus;
        private System.Windows.Forms.TextBox tbPcbInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbPCBCode;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbdRefresh;
        private System.Windows.Forms.ToolStripButton tsbdGradeView;
        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ToolStripButton tsbPrinterSet;
        private System.Windows.Forms.ToolStripButton tsbPrinting;
    }
}