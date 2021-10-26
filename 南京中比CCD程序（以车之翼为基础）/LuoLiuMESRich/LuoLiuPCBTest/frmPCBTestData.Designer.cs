namespace LuoLiuPCBTest
{
    partial class frmPCBTestData
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPCBTestData));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看登录信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备异常单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.历史记录查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前工作站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置测试文件存储路径ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动隐藏设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空窗口数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止结果读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMsfForm = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucTitle1 = new Common.UserControls.ucTitle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkSelRemark = new System.Windows.Forms.LinkLabel();
            this.ucAutoSaveTimerShow1 = new Common.UserControls.ucAutoSaveTimerShow();
            this.label11 = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.btRemark = new System.Windows.Forms.Button();
            this.tbRemark = new MyControl.MyTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSpendTime = new MyControl.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbModel = new MyControl.MyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLobNumber = new MyControl.MyTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEndTime = new MyControl.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStartTime = new MyControl.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCellCount = new MyControl.MyTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPcbCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgHisRecord = new MyControl.MyDataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHisRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgHisRecord, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(901, 417);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 244);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(901, 27);
            this.label10.TabIndex = 219;
            this.label10.Text = "历史检测记录(F2刷新)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.用户ToolStripMenuItem,
            this.导航ToolStripMenuItem,
            this.数据toolStripMenuItem1,
            this.设置ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 28);
            this.menuStrip1.TabIndex = 215;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 更新ToolStripMenuItem
            // 
            this.更新ToolStripMenuItem.Name = "更新ToolStripMenuItem";
            this.更新ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.更新ToolStripMenuItem.Text = "更新";
            this.更新ToolStripMenuItem.Click += new System.EventHandler(this.更新ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 用户ToolStripMenuItem
            // 
            this.用户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.注销ToolStripMenuItem,
            this.切换用户ToolStripMenuItem,
            this.修改密码ToolStripMenuItem,
            this.查看登录信息ToolStripMenuItem});
            this.用户ToolStripMenuItem.Name = "用户ToolStripMenuItem";
            this.用户ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.用户ToolStripMenuItem.Text = "用户";
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // 切换用户ToolStripMenuItem
            // 
            this.切换用户ToolStripMenuItem.Name = "切换用户ToolStripMenuItem";
            this.切换用户ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.切换用户ToolStripMenuItem.Text = "切换用户";
            this.切换用户ToolStripMenuItem.Click += new System.EventHandler(this.切换用户ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 查看登录信息ToolStripMenuItem
            // 
            this.查看登录信息ToolStripMenuItem.Name = "查看登录信息ToolStripMenuItem";
            this.查看登录信息ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.查看登录信息ToolStripMenuItem.Text = "查看登录信息";
            // 
            // 导航ToolStripMenuItem
            // 
            this.导航ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备异常单ToolStripMenuItem});
            this.导航ToolStripMenuItem.Name = "导航ToolStripMenuItem";
            this.导航ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.导航ToolStripMenuItem.Text = "导航";
            // 
            // 设备异常单ToolStripMenuItem
            // 
            this.设备异常单ToolStripMenuItem.Name = "设备异常单ToolStripMenuItem";
            this.设备异常单ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.设备异常单ToolStripMenuItem.Text = "设备异常单";
            this.设备异常单ToolStripMenuItem.Click += new System.EventHandler(this.设备异常单ToolStripMenuItem_Click);
            // 
            // 数据toolStripMenuItem1
            // 
            this.数据toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.历史记录查询ToolStripMenuItem});
            this.数据toolStripMenuItem1.Name = "数据toolStripMenuItem1";
            this.数据toolStripMenuItem1.Size = new System.Drawing.Size(49, 24);
            this.数据toolStripMenuItem1.Text = "数据";
            // 
            // 历史记录查询ToolStripMenuItem
            // 
            this.历史记录查询ToolStripMenuItem.Name = "历史记录查询ToolStripMenuItem";
            this.历史记录查询ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.历史记录查询ToolStripMenuItem.Text = "历史检测记录";
            this.历史记录查询ToolStripMenuItem.Click += new System.EventHandler(this.历史记录查询ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前工作站ToolStripMenuItem,
            this.设置测试文件存储路径ToolStripMenuItem,
            this.自动隐藏设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 当前工作站ToolStripMenuItem
            // 
            this.当前工作站ToolStripMenuItem.Name = "当前工作站ToolStripMenuItem";
            this.当前工作站ToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.当前工作站ToolStripMenuItem.Text = "当前工作站";
            this.当前工作站ToolStripMenuItem.Click += new System.EventHandler(this.当前工作站ToolStripMenuItem_Click);
            // 
            // 设置测试文件存储路径ToolStripMenuItem
            // 
            this.设置测试文件存储路径ToolStripMenuItem.Name = "设置测试文件存储路径ToolStripMenuItem";
            this.设置测试文件存储路径ToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.设置测试文件存储路径ToolStripMenuItem.Text = "设置测试文件存储路径";
            this.设置测试文件存储路径ToolStripMenuItem.Click += new System.EventHandler(this.设置测试文件存储路径ToolStripMenuItem_Click);
            // 
            // 自动隐藏设置ToolStripMenuItem
            // 
            this.自动隐藏设置ToolStripMenuItem.Name = "自动隐藏设置ToolStripMenuItem";
            this.自动隐藏设置ToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.自动隐藏设置ToolStripMenuItem.Text = "自动隐藏设置";
            this.自动隐藏设置ToolStripMenuItem.Click += new System.EventHandler(this.自动隐藏设置ToolStripMenuItem_Click);
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空窗口数据ToolStripMenuItem,
            this.终止结果读取ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 清空窗口数据ToolStripMenuItem
            // 
            this.清空窗口数据ToolStripMenuItem.Name = "清空窗口数据ToolStripMenuItem";
            this.清空窗口数据ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.清空窗口数据ToolStripMenuItem.Text = "清空窗口数据";
            this.清空窗口数据ToolStripMenuItem.Click += new System.EventHandler(this.清空窗口数据ToolStripMenuItem_Click);
            // 
            // 终止结果读取ToolStripMenuItem
            // 
            this.终止结果读取ToolStripMenuItem.Name = "终止结果读取ToolStripMenuItem";
            this.终止结果读取ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.终止结果读取ToolStripMenuItem.Text = "终止结果读取";
            this.终止结果读取ToolStripMenuItem.Click += new System.EventHandler(this.终止结果读取ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.联系管理员ToolStripMenuItem,
            this.软件版本信息ToolStripMenuItem,
            this.tsbMsfForm});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.关于我们ToolStripMenuItem_Click);
            // 
            // 联系管理员ToolStripMenuItem
            // 
            this.联系管理员ToolStripMenuItem.Name = "联系管理员ToolStripMenuItem";
            this.联系管理员ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.联系管理员ToolStripMenuItem.Text = "联系管理员";
            this.联系管理员ToolStripMenuItem.Click += new System.EventHandler(this.联系管理员ToolStripMenuItem_Click);
            // 
            // 软件版本信息ToolStripMenuItem
            // 
            this.软件版本信息ToolStripMenuItem.Name = "软件版本信息ToolStripMenuItem";
            this.软件版本信息ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.软件版本信息ToolStripMenuItem.Text = "软件版本信息";
            this.软件版本信息ToolStripMenuItem.Click += new System.EventHandler(this.软件版本信息ToolStripMenuItem_Click);
            // 
            // tsbMsfForm
            // 
            this.tsbMsfForm.Name = "tsbMsfForm";
            this.tsbMsfForm.Size = new System.Drawing.Size(162, 24);
            this.tsbMsfForm.Text = "显示日志窗口";
            this.tsbMsfForm.Click += new System.EventHandler(this.tsbMsfForm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucTitle1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 34);
            this.panel1.TabIndex = 216;
            // 
            // ucTitle1
            // 
            this.ucTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTitle1.Location = new System.Drawing.Point(0, 0);
            this.ucTitle1.Mac = "--";
            this.ucTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.ucTitle1.Name = "ucTitle1";
            this.ucTitle1.Operator = "已注销";
            this.ucTitle1.Process = "CCD检测";
            this.ucTitle1.Size = new System.Drawing.Size(901, 34);
            this.ucTitle1.Station = "L-1-1";
            this.ucTitle1.TabIndex = 221;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.linkSelRemark);
            this.panel2.Controls.Add(this.ucAutoSaveTimerShow1);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.labResult);
            this.panel2.Controls.Add(this.btRemark);
            this.panel2.Controls.Add(this.tbRemark);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbSpendTime);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbModel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbLobNumber);
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
            this.panel2.Location = new System.Drawing.Point(3, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 174);
            this.panel2.TabIndex = 218;
            // 
            // linkSelRemark
            // 
            this.linkSelRemark.AutoSize = true;
            this.linkSelRemark.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkSelRemark.Location = new System.Drawing.Point(42, 75);
            this.linkSelRemark.Name = "linkSelRemark";
            this.linkSelRemark.Size = new System.Drawing.Size(35, 14);
            this.linkSelRemark.TabIndex = 116;
            this.linkSelRemark.TabStop = true;
            this.linkSelRemark.Text = "备注";
            this.linkSelRemark.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSelRemark_LinkClicked);
            // 
            // ucAutoSaveTimerShow1
            // 
            this.ucAutoSaveTimerShow1.Location = new System.Drawing.Point(501, 139);
            this.ucAutoSaveTimerShow1.Name = "ucAutoSaveTimerShow1";
            this.ucAutoSaveTimerShow1.Size = new System.Drawing.Size(282, 23);
            this.ucAutoSaveTimerShow1.TabIndex = 115;
            this.ucAutoSaveTimerShow1.TextFormat = "{0}秒后自动隐藏窗口";
            this.ucAutoSaveTimerShow1.AutoSaveTimerStopNotice += new Common.UserControls.AutoSaveTimerStopCallBack(this.ucAutoSaveTimerShow1_AutoSaveTimerStopNotice);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.Location = new System.Drawing.Point(626, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 14);
            this.label11.TabIndex = 114;
            this.label11.Text = "秒";
            // 
            // labResult
            // 
            this.labResult.BackColor = System.Drawing.Color.White;
            this.labResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labResult.Location = new System.Drawing.Point(731, 39);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(146, 26);
            this.labResult.TabIndex = 113;
            this.labResult.Text = "----";
            this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btRemark
            // 
            this.btRemark.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRemark.Location = new System.Drawing.Point(357, 127);
            this.btRemark.Name = "btRemark";
            this.btRemark.Size = new System.Drawing.Size(138, 40);
            this.btRemark.TabIndex = 50;
            this.btRemark.Text = "更新备注";
            this.btRemark.UseVisualStyleBackColor = true;
            this.btRemark.Click += new System.EventHandler(this.btRemark_Click);
            // 
            // tbRemark
            // 
            this.tbRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRemark.FilterQuanJiao = true;
            this.tbRemark.Font = new System.Drawing.Font("宋体", 10F);
            this.tbRemark.IsUpper = true;
            this.tbRemark.Location = new System.Drawing.Point(80, 70);
            this.tbRemark.Multiline = true;
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(798, 48);
            this.tbRemark.TabIndex = 49;
            this.tbRemark.TextSplitWorld = "、";
            this.tbRemark.ValueSplitWorld = "|";
            this.tbRemark.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbRemark_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10F);
            this.label9.Location = new System.Drawing.Point(666, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 46;
            this.label9.Text = "测试结果";
            // 
            // tbSpendTime
            // 
            this.tbSpendTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbSpendTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSpendTime.FilterQuanJiao = true;
            this.tbSpendTime.Font = new System.Drawing.Font("宋体", 10F);
            this.tbSpendTime.IsUpper = true;
            this.tbSpendTime.Location = new System.Drawing.Point(510, 41);
            this.tbSpendTime.Multiline = true;
            this.tbSpendTime.Name = "tbSpendTime";
            this.tbSpendTime.ReadOnly = true;
            this.tbSpendTime.Size = new System.Drawing.Size(112, 26);
            this.tbSpendTime.TabIndex = 45;
            this.tbSpendTime.TextSplitWorld = "、";
            this.tbSpendTime.ValueSplitWorld = "|";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(447, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 44;
            this.label8.Text = "测试用时";
            // 
            // tbModel
            // 
            this.tbModel.BackColor = System.Drawing.SystemColors.Window;
            this.tbModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbModel.FilterQuanJiao = true;
            this.tbModel.Font = new System.Drawing.Font("宋体", 10F);
            this.tbModel.IsUpper = true;
            this.tbModel.Location = new System.Drawing.Point(329, 40);
            this.tbModel.Multiline = true;
            this.tbModel.Name = "tbModel";
            this.tbModel.ReadOnly = true;
            this.tbModel.Size = new System.Drawing.Size(115, 26);
            this.tbModel.TabIndex = 43;
            this.tbModel.TextSplitWorld = "、";
            this.tbModel.ValueSplitWorld = "|";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(291, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 42;
            this.label7.Text = "型号";
            // 
            // tbLobNumber
            // 
            this.tbLobNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbLobNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLobNumber.FilterQuanJiao = true;
            this.tbLobNumber.Font = new System.Drawing.Font("宋体", 10F);
            this.tbLobNumber.IsUpper = true;
            this.tbLobNumber.Location = new System.Drawing.Point(80, 40);
            this.tbLobNumber.Multiline = true;
            this.tbLobNumber.Name = "tbLobNumber";
            this.tbLobNumber.ReadOnly = true;
            this.tbLobNumber.Size = new System.Drawing.Size(207, 26);
            this.tbLobNumber.TabIndex = 41;
            this.tbLobNumber.TextSplitWorld = "、";
            this.tbLobNumber.ValueSplitWorld = "|";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(42, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 14);
            this.label5.TabIndex = 40;
            this.label5.Text = "批次";
            // 
            // tbEndTime
            // 
            this.tbEndTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbEndTime.FilterQuanJiao = true;
            this.tbEndTime.Font = new System.Drawing.Font("宋体", 10F);
            this.tbEndTime.IsUpper = true;
            this.tbEndTime.Location = new System.Drawing.Point(731, 9);
            this.tbEndTime.Multiline = true;
            this.tbEndTime.Name = "tbEndTime";
            this.tbEndTime.ReadOnly = true;
            this.tbEndTime.Size = new System.Drawing.Size(146, 26);
            this.tbEndTime.TabIndex = 39;
            this.tbEndTime.TextSplitWorld = "、";
            this.tbEndTime.ValueSplitWorld = "|";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(666, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 38;
            this.label4.Text = "结束时间";
            // 
            // tbStartTime
            // 
            this.tbStartTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbStartTime.FilterQuanJiao = true;
            this.tbStartTime.Font = new System.Drawing.Font("宋体", 10F);
            this.tbStartTime.IsUpper = true;
            this.tbStartTime.Location = new System.Drawing.Point(510, 11);
            this.tbStartTime.Multiline = true;
            this.tbStartTime.Name = "tbStartTime";
            this.tbStartTime.ReadOnly = true;
            this.tbStartTime.Size = new System.Drawing.Size(153, 26);
            this.tbStartTime.TabIndex = 37;
            this.tbStartTime.TextSplitWorld = "、";
            this.tbStartTime.ValueSplitWorld = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(447, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "开始时间";
            // 
            // tbCellCount
            // 
            this.tbCellCount.BackColor = System.Drawing.SystemColors.Window;
            this.tbCellCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCellCount.FilterQuanJiao = true;
            this.tbCellCount.Font = new System.Drawing.Font("宋体", 10F);
            this.tbCellCount.IsUpper = true;
            this.tbCellCount.Location = new System.Drawing.Point(329, 10);
            this.tbCellCount.Multiline = true;
            this.tbCellCount.Name = "tbCellCount";
            this.tbCellCount.ReadOnly = true;
            this.tbCellCount.Size = new System.Drawing.Size(115, 26);
            this.tbCellCount.TabIndex = 35;
            this.tbCellCount.TextSplitWorld = "、";
            this.tbCellCount.ValueSplitWorld = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(291, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 34;
            this.label2.Text = "串数";
            // 
            // tbPcbCode
            // 
            this.tbPcbCode.BackColor = System.Drawing.SystemColors.Window;
            this.tbPcbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPcbCode.FilterQuanJiao = true;
            this.tbPcbCode.Font = new System.Drawing.Font("宋体", 10F);
            this.tbPcbCode.IsUpper = true;
            this.tbPcbCode.Location = new System.Drawing.Point(80, 10);
            this.tbPcbCode.Multiline = true;
            this.tbPcbCode.Name = "tbPcbCode";
            this.tbPcbCode.Size = new System.Drawing.Size(207, 26);
            this.tbPcbCode.TabIndex = 33;
            this.tbPcbCode.TextSplitWorld = "、";
            this.tbPcbCode.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 32;
            this.label1.Text = "保护板编号";
            // 
            // dgHisRecord
            // 
            this.dgHisRecord.AllowUserToAddRows = false;
            this.dgHisRecord.AllowUserToDeleteRows = false;
            this.dgHisRecord.BackgroundColor = System.Drawing.Color.White;
            this.dgHisRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgHisRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgHisRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column4,
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgHisRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgHisRecord.Location = new System.Drawing.Point(0, 271);
            this.dgHisRecord.Margin = new System.Windows.Forms.Padding(0);
            this.dgHisRecord.Name = "dgHisRecord";
            this.dgHisRecord.ReadOnly = true;
            this.dgHisRecord.RowHeadersWidth = 30;
            this.dgHisRecord.RowTemplate.Height = 23;
            this.dgHisRecord.ShowLineNo = true;
            this.dgHisRecord.Size = new System.Drawing.Size(901, 146);
            this.dgHisRecord.TabIndex = 220;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "StationName";
            this.Column5.HeaderText = "工作站";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MacName";
            this.Column4.HeaderText = "测试机台";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "OperatorName";
            this.Column6.HeaderText = "测试人员";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "StartTime";
            this.Column1.HeaderText = "开始时间";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 140;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "EndTime";
            this.Column2.HeaderText = "结束时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "QualityName";
            this.Column3.HeaderText = "测试结果";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "保护板数据采集";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // frmPCBTestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 417);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPCBTestData";
            this.Text = "保护板检测结果采集";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PCBTestData_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgHisRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看登录信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前工作站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备异常单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空窗口数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 终止结果读取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件版本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsbMsfForm;
        private System.Windows.Forms.Panel panel1;
        private Common.UserControls.ucTitle ucTitle1;
        private System.Windows.Forms.Panel panel2;
        private MyControl.MyTextBox tbPcbCode;
        private System.Windows.Forms.Label label1;
        private MyControl.MyTextBox tbEndTime;
        private System.Windows.Forms.Label label4;
        private MyControl.MyTextBox tbStartTime;
        private System.Windows.Forms.Label label3;
        private MyControl.MyTextBox tbCellCount;
        private System.Windows.Forms.Label label2;
        private MyControl.MyTextBox tbLobNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private MyControl.MyTextBox tbSpendTime;
        private System.Windows.Forms.Label label8;
        private MyControl.MyTextBox tbModel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btRemark;
        private System.Windows.Forms.Label label10;
        private MyControl.MyDataGridView dgHisRecord;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.ToolStripMenuItem 数据toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 历史记录查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置测试文件存储路径ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label11;
        private MyControl.MyTextBox tbRemark;
        private System.Windows.Forms.ToolStripMenuItem 自动隐藏设置ToolStripMenuItem;
        private Common.UserControls.ucAutoSaveTimerShow ucAutoSaveTimerShow1;
        private System.Windows.Forms.LinkLabel linkSelRemark;
    }
}