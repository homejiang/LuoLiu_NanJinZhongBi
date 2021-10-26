namespace LuoLiuPCBTest
{
    partial class frmPCBTestDataEdit
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgHisRecord = new MyControl.MyDataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.myStation = new MyControl.MyTextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.myMacCode = new MyControl.MyTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.myTester = new MyControl.MyTextBox();
            this.linkUser = new System.Windows.Forms.LinkLabel();
            this.labResult = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tbRemark = new MyControl.MyTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSpendTime = new MyControl.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbModel = new MyControl.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLotNumber = new MyControl.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEndTime = new MyControl.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStartTime = new MyControl.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCellCount = new MyControl.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPcbCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHisRecord)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgHisRecord, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgHisRecord
            // 
            this.dgHisRecord.AllowUserToAddRows = false;
            this.dgHisRecord.AllowUserToDeleteRows = false;
            this.dgHisRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgHisRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHisRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column8,
            this.Column7,
            this.Column9,
            this.Column2,
            this.Column10,
            this.Column3});
            this.dgHisRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHisRecord.Location = new System.Drawing.Point(0, 219);
            this.dgHisRecord.Margin = new System.Windows.Forms.Padding(0);
            this.dgHisRecord.Name = "dgHisRecord";
            this.dgHisRecord.ReadOnly = true;
            this.dgHisRecord.RowHeadersWidth = 30;
            this.dgHisRecord.RowTemplate.Height = 23;
            this.dgHisRecord.ShowLineNo = true;
            this.dgHisRecord.Size = new System.Drawing.Size(887, 240);
            this.dgHisRecord.TabIndex = 221;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Node3";
            this.Column6.HeaderText = "测试项目";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 160;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Nature0";
            this.Column8.HeaderText = "位置";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 60;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Node4";
            this.Column7.HeaderText = "测试项目";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 160;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Nature1";
            this.Column9.HeaderText = "位置";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 60;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Value";
            this.Column2.HeaderText = "检测值";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Nature2";
            this.Column10.HeaderText = "测试结果";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Times";
            this.Column3.HeaderText = "时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 140;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.myStation);
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.myMacCode);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.myTester);
            this.panel2.Controls.Add(this.linkUser);
            this.panel2.Controls.Add(this.labResult);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.tbRemark);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbSpendTime);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbModel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbLotNumber);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbEndTime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbStartTime);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbCellCount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbPcbCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 96);
            this.panel2.TabIndex = 219;
            // 
            // myStation
            // 
            this.myStation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myStation.FilterQuanJiao = true;
            this.myStation.Font = new System.Drawing.Font("宋体", 9F);
            this.myStation.IsUpper = true;
            this.myStation.Location = new System.Drawing.Point(451, 26);
            this.myStation.Name = "myStation";
            this.myStation.Size = new System.Drawing.Size(98, 21);
            this.myStation.TabIndex = 131;
            this.myStation.TextSplitWorld = "、";
            this.myStation.ValueSplitWorld = "|";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(408, 29);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(41, 12);
            this.linkLabel2.TabIndex = 130;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "工作站";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // myMacCode
            // 
            this.myMacCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myMacCode.FilterQuanJiao = true;
            this.myMacCode.Font = new System.Drawing.Font("宋体", 9F);
            this.myMacCode.IsUpper = true;
            this.myMacCode.Location = new System.Drawing.Point(68, 25);
            this.myMacCode.Name = "myMacCode";
            this.myMacCode.Size = new System.Drawing.Size(180, 21);
            this.myMacCode.TabIndex = 129;
            this.myMacCode.TextSplitWorld = "、";
            this.myMacCode.ValueSplitWorld = "|";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 29);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 128;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "检测设备";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // myTester
            // 
            this.myTester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTester.FilterQuanJiao = true;
            this.myTester.Font = new System.Drawing.Font("宋体", 9F);
            this.myTester.IsUpper = true;
            this.myTester.Location = new System.Drawing.Point(307, 24);
            this.myTester.Name = "myTester";
            this.myTester.Size = new System.Drawing.Size(99, 21);
            this.myTester.TabIndex = 127;
            this.myTester.TextSplitWorld = "、";
            this.myTester.ValueSplitWorld = "|";
            // 
            // linkUser
            // 
            this.linkUser.AutoSize = true;
            this.linkUser.Location = new System.Drawing.Point(250, 29);
            this.linkUser.Name = "linkUser";
            this.linkUser.Size = new System.Drawing.Size(53, 12);
            this.linkUser.TabIndex = 126;
            this.linkUser.TabStop = true;
            this.linkUser.Text = "检测人员";
            this.linkUser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkUser_LinkClicked);
            // 
            // labResult
            // 
            this.labResult.BackColor = System.Drawing.Color.White;
            this.labResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labResult.Font = new System.Drawing.Font("宋体", 9F);
            this.labResult.Location = new System.Drawing.Point(791, 48);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(87, 41);
            this.labResult.TabIndex = 113;
            this.labResult.Text = "----";
            this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(846, 149);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(160, 105);
            this.richTextBox1.TabIndex = 112;
            this.richTextBox1.Text = "";
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.Font = new System.Drawing.Font("宋体", 9F);
            this.tbRemark.IsUpper = true;
            this.tbRemark.Location = new System.Drawing.Point(68, 49);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(669, 40);
            this.tbRemark.TabIndex = 49;
            this.tbRemark.TextSplitWorld = "、";
            this.tbRemark.ValueSplitWorld = "|";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.Location = new System.Drawing.Point(37, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "备注";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.Location = new System.Drawing.Point(739, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 46;
            this.label9.Text = "测试结果";
            // 
            // tbSpendTime
            // 
            this.tbSpendTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbSpendTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSpendTime.FilterQuanJiao = true;
            this.tbSpendTime.Font = new System.Drawing.Font("宋体", 9F);
            this.tbSpendTime.IsUpper = true;
            this.tbSpendTime.Location = new System.Drawing.Point(791, 26);
            this.tbSpendTime.Name = "tbSpendTime";
            this.tbSpendTime.ReadOnly = true;
            this.tbSpendTime.Size = new System.Drawing.Size(86, 21);
            this.tbSpendTime.TabIndex = 45;
            this.tbSpendTime.TextSplitWorld = "、";
            this.tbSpendTime.ValueSplitWorld = "|";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.Location = new System.Drawing.Point(740, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 44;
            this.label8.Text = "测试用时";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.SystemColors.Window;
            this.tbModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbModel.FilterQuanJiao = true;
            this.tbModel.Font = new System.Drawing.Font("宋体", 9F);
            this.tbModel.IsUpper = true;
            this.tbModel.Location = new System.Drawing.Point(307, 2);
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(99, 21);
            this.tbModel.TabIndex = 43;
            this.tbModel.TextSplitWorld = "、";
            this.tbModel.ValueSplitWorld = "|";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(273, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "型号";
            // 
            // tbLotNumber
            // 
            this.tbLotNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbLotNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLotNumber.FilterQuanJiao = true;
            this.tbLotNumber.Font = new System.Drawing.Font("宋体", 9F);
            this.tbLotNumber.IsUpper = true;
            this.tbLotNumber.Location = new System.Drawing.Point(451, 4);
            this.tbLotNumber.Name = "tbLotNumber";
            this.tbLotNumber.ReadOnly = true;
            this.tbLotNumber.Size = new System.Drawing.Size(98, 21);
            this.tbLotNumber.TabIndex = 41;
            this.tbLotNumber.TextSplitWorld = "、";
            this.tbLotNumber.ValueSplitWorld = "|";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.Location = new System.Drawing.Point(418, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 40;
            this.label5.Text = "批次";
            // 
            // tbEndTime
            // 
            this.tbEndTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEndTime.FilterQuanJiao = true;
            this.tbEndTime.Font = new System.Drawing.Font("宋体", 9F);
            this.tbEndTime.IsUpper = true;
            this.tbEndTime.Location = new System.Drawing.Point(612, 25);
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(125, 21);
            this.tbEndTime.TabIndex = 39;
            this.tbEndTime.TextSplitWorld = "、";
            this.tbEndTime.ValueSplitWorld = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.Location = new System.Drawing.Point(553, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "结束时间";
            // 
            // tbStartTime
            // 
            this.tbStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStartTime.FilterQuanJiao = true;
            this.tbStartTime.Font = new System.Drawing.Font("宋体", 9F);
            this.tbStartTime.IsUpper = true;
            this.tbStartTime.Location = new System.Drawing.Point(612, 2);
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(125, 21);
            this.tbStartTime.TabIndex = 37;
            this.tbStartTime.TextSplitWorld = "、";
            this.tbStartTime.ValueSplitWorld = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.Location = new System.Drawing.Point(553, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "开始时间";
            // 
            // tbCellCount
            // 
            this.tbCellCount.BackColor = System.Drawing.SystemColors.Window;
            this.tbCellCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCellCount.FilterQuanJiao = true;
            this.tbCellCount.Font = new System.Drawing.Font("宋体", 9F);
            this.tbCellCount.IsUpper = true;
            this.tbCellCount.Location = new System.Drawing.Point(791, 3);
            this.tbCellCount.Name = "tbCellCount";
            this.tbCellCount.ReadOnly = true;
            this.tbCellCount.Size = new System.Drawing.Size(86, 21);
            this.tbCellCount.TabIndex = 35;
            this.tbCellCount.TextSplitWorld = "、";
            this.tbCellCount.ValueSplitWorld = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(763, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "串数";
            // 
            // tbPcbCode
            // 
            this.tbPcbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPcbCode.FilterQuanJiao = true;
            this.tbPcbCode.Font = new System.Drawing.Font("宋体", 9F);
            this.tbPcbCode.IsUpper = true;
            this.tbPcbCode.Location = new System.Drawing.Point(68, 2);
            this.tbPcbCode.Name = "tbPcbCode";
            this.tbPcbCode.Size = new System.Drawing.Size(180, 21);
            this.tbPcbCode.TabIndex = 33;
            this.tbPcbCode.TextSplitWorld = "、";
            this.tbPcbCode.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.Location = new System.Drawing.Point(1, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "保护板编号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(881, 40);
            this.panel1.TabIndex = 217;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(881, 40);
            this.label11.TabIndex = 221;
            this.label11.Text = "保护板检测参数信息";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(881, 35);
            this.panel3.TabIndex = 220;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(881, 35);
            this.label10.TabIndex = 220;
            this.label10.Text = "保护板检测参数信息";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(887, 30);
            this.menuStrip1.TabIndex = 216;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Image = global::LuoLiuPCBTest.Properties.Resources.Save;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(65, 26);
            this.文件ToolStripMenuItem.Text = "修改";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::LuoLiuPCBTest.Properties.Resources.Del25;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(65, 26);
            this.toolStripMenuItem1.Text = "删除";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // frmPCBTestDataEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 459);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPCBTestDataEdit";
            this.Text = "保护板检测编辑界面";
            this.Load += new System.EventHandler(this.frmPCBTestDataEdit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHisRecord)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private MyControl.MyTextBox tbSpendTime;
        private System.Windows.Forms.Label label8;
        private MyControl.MyTextBox tbModel;
        private System.Windows.Forms.Label label7;
        private MyControl.MyTextBox tbLotNumber;
        private System.Windows.Forms.Label label5;
        private MyControl.MyTextBox tbEndTime;
        private System.Windows.Forms.Label label4;
        private MyControl.MyTextBox tbStartTime;
        private System.Windows.Forms.Label label3;
        private MyControl.MyTextBox tbCellCount;
        private System.Windows.Forms.Label label2;
        private MyControl.MyTextBox tbPcbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private MyControl.MyDataGridView dgHisRecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label11;
        private MyControl.MyTextBox myStation;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private MyControl.MyTextBox myMacCode;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private MyControl.MyTextBox myTester;
        private System.Windows.Forms.LinkLabel linkUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}