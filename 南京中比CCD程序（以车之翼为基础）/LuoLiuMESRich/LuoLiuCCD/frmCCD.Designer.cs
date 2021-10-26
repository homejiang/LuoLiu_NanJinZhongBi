namespace LuoLiuCCD
{
    partial class frmCCD
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucTitle1 = new Common.UserControls.ucTitle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看登录信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前工作站ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自动读取测试结果ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导航ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设备异常单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史绑定记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单进度查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空窗口数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.终止结果读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.撤销模块领用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接设备ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开设备连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看错误信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbMsfForm = new System.Windows.Forms.ToolStripMenuItem();
            this.调试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkStopShowErr = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rtbErrMsg = new System.Windows.Forms.RichTextBox();
            this.tbMkCode = new MyControl.MyTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rtbPactInfo = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtbProcess = new System.Windows.Forms.RichTextBox();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.labListenStatus = new System.Windows.Forms.Label();
            this.tbBOMDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDxCnt = new System.Windows.Forms.TextBox();
            this.btRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgDxs = new MyControl.MyDataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucStatistic11 = new Common.UserControls.ucStatistic1();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDxs)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ucTitle1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgDxs, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 319F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 545);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ucTitle1
            // 
            this.ucTitle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ucTitle1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTitle1.Location = new System.Drawing.Point(0, 30);
            this.ucTitle1.Mac = "--";
            this.ucTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.ucTitle1.Name = "ucTitle1";
            this.ucTitle1.Operator = "已注销";
            this.ucTitle1.Process = "CCD检测";
            this.ucTitle1.Size = new System.Drawing.Size(959, 30);
            this.ucTitle1.Station = "L-1-1";
            this.ucTitle1.TabIndex = 220;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.用户ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.导航ToolStripMenuItem,
            this.数据ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 28);
            this.menuStrip1.TabIndex = 214;
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
            this.查看登录信息ToolStripMenuItem.Click += new System.EventHandler(this.查看登录信息ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前工作站ToolStripMenuItem,
            this.自动读取测试结果ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 当前工作站ToolStripMenuItem
            // 
            this.当前工作站ToolStripMenuItem.Name = "当前工作站ToolStripMenuItem";
            this.当前工作站ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.当前工作站ToolStripMenuItem.Text = "当前工作站";
            this.当前工作站ToolStripMenuItem.Click += new System.EventHandler(this.当前工作站ToolStripMenuItem_Click);
            // 
            // 自动读取测试结果ToolStripMenuItem
            // 
            this.自动读取测试结果ToolStripMenuItem.Name = "自动读取测试结果ToolStripMenuItem";
            this.自动读取测试结果ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.自动读取测试结果ToolStripMenuItem.Text = "自动读取测试结果";
            this.自动读取测试结果ToolStripMenuItem.Click += new System.EventHandler(this.自动读取测试结果ToolStripMenuItem_Click);
            // 
            // 导航ToolStripMenuItem
            // 
            this.导航ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设备异常单ToolStripMenuItem});
            this.导航ToolStripMenuItem.Name = "导航ToolStripMenuItem";
            this.导航ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.导航ToolStripMenuItem.Text = "导航";
            this.导航ToolStripMenuItem.Click += new System.EventHandler(this.导航ToolStripMenuItem_Click);
            // 
            // 设备异常单ToolStripMenuItem
            // 
            this.设备异常单ToolStripMenuItem.Name = "设备异常单ToolStripMenuItem";
            this.设备异常单ToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.设备异常单ToolStripMenuItem.Text = "设备异常单";
            this.设备异常单ToolStripMenuItem.Click += new System.EventHandler(this.设备异常单ToolStripMenuItem_Click);
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.历史绑定记录ToolStripMenuItem,
            this.订单进度查看ToolStripMenuItem});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.数据ToolStripMenuItem.Text = "数据";
            // 
            // 历史绑定记录ToolStripMenuItem
            // 
            this.历史绑定记录ToolStripMenuItem.Name = "历史绑定记录ToolStripMenuItem";
            this.历史绑定记录ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.历史绑定记录ToolStripMenuItem.Text = "历史测试记录";
            this.历史绑定记录ToolStripMenuItem.Click += new System.EventHandler(this.历史绑定记录ToolStripMenuItem_Click);
            // 
            // 订单进度查看ToolStripMenuItem
            // 
            this.订单进度查看ToolStripMenuItem.Name = "订单进度查看ToolStripMenuItem";
            this.订单进度查看ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.订单进度查看ToolStripMenuItem.Text = "订单进度查看";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空窗口数据ToolStripMenuItem,
            this.终止结果读取ToolStripMenuItem,
            this.撤销模块领用ToolStripMenuItem,
            this.连接设备ToolStripMenuItem,
            this.断开设备连接ToolStripMenuItem});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 清空窗口数据ToolStripMenuItem
            // 
            this.清空窗口数据ToolStripMenuItem.Name = "清空窗口数据ToolStripMenuItem";
            this.清空窗口数据ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.清空窗口数据ToolStripMenuItem.Text = "清空窗口数据";
            this.清空窗口数据ToolStripMenuItem.Click += new System.EventHandler(this.清空窗口数据ToolStripMenuItem_Click);
            // 
            // 终止结果读取ToolStripMenuItem
            // 
            this.终止结果读取ToolStripMenuItem.Name = "终止结果读取ToolStripMenuItem";
            this.终止结果读取ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.终止结果读取ToolStripMenuItem.Text = "终止结果读取";
            this.终止结果读取ToolStripMenuItem.Click += new System.EventHandler(this.终止结果读取ToolStripMenuItem_Click);
            // 
            // 撤销模块领用ToolStripMenuItem
            // 
            this.撤销模块领用ToolStripMenuItem.Name = "撤销模块领用ToolStripMenuItem";
            this.撤销模块领用ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.撤销模块领用ToolStripMenuItem.Text = "撤销当前模块领用";
            this.撤销模块领用ToolStripMenuItem.Click += new System.EventHandler(this.撤销模块领用ToolStripMenuItem_Click);
            // 
            // 连接设备ToolStripMenuItem
            // 
            this.连接设备ToolStripMenuItem.Name = "连接设备ToolStripMenuItem";
            this.连接设备ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.连接设备ToolStripMenuItem.Text = "连接设备";
            this.连接设备ToolStripMenuItem.Click += new System.EventHandler(this.连接设备ToolStripMenuItem_Click);
            // 
            // 断开设备连接ToolStripMenuItem
            // 
            this.断开设备连接ToolStripMenuItem.Name = "断开设备连接ToolStripMenuItem";
            this.断开设备连接ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.断开设备连接ToolStripMenuItem.Text = "断开设备连接";
            this.断开设备连接ToolStripMenuItem.Click += new System.EventHandler(this.断开设备连接ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem,
            this.联系管理员ToolStripMenuItem,
            this.软件版本信息ToolStripMenuItem,
            this.查看错误信息ToolStripMenuItem,
            this.tsbMsfForm,
            this.调试ToolStripMenuItem});
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
            // 
            // 查看错误信息ToolStripMenuItem
            // 
            this.查看错误信息ToolStripMenuItem.Name = "查看错误信息ToolStripMenuItem";
            this.查看错误信息ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.查看错误信息ToolStripMenuItem.Text = "查看错误信息";
            // 
            // tsbMsfForm
            // 
            this.tsbMsfForm.Name = "tsbMsfForm";
            this.tsbMsfForm.Size = new System.Drawing.Size(162, 24);
            this.tsbMsfForm.Text = "显示日志窗口";
            this.tsbMsfForm.Click += new System.EventHandler(this.tsbMsfForm_Click);
            // 
            // 调试ToolStripMenuItem
            // 
            this.调试ToolStripMenuItem.Name = "调试ToolStripMenuItem";
            this.调试ToolStripMenuItem.Size = new System.Drawing.Size(162, 24);
            this.调试ToolStripMenuItem.Text = "调试";
            this.调试ToolStripMenuItem.Click += new System.EventHandler(this.调试ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkStopShowErr);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.tbMkCode);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.labResult);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.tbHistory);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.labListenStatus);
            this.panel1.Controls.Add(this.tbBOMDesc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbDxCnt);
            this.panel1.Controls.Add(this.btRead);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 313);
            this.panel1.TabIndex = 216;
            // 
            // chkStopShowErr
            // 
            this.chkStopShowErr.AutoSize = true;
            this.chkStopShowErr.Location = new System.Drawing.Point(14, 211);
            this.chkStopShowErr.Name = "chkStopShowErr";
            this.chkStopShowErr.Size = new System.Drawing.Size(54, 18);
            this.chkStopShowErr.TabIndex = 139;
            this.chkStopShowErr.Text = "停止";
            this.chkStopShowErr.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.Location = new System.Drawing.Point(12, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 138;
            this.label7.Text = "异常消息";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rtbErrMsg);
            this.panel5.Location = new System.Drawing.Point(70, 179);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(715, 128);
            this.panel5.TabIndex = 137;
            // 
            // rtbErrMsg
            // 
            this.rtbErrMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbErrMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbErrMsg.Font = new System.Drawing.Font("楷体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbErrMsg.ForeColor = System.Drawing.Color.Red;
            this.rtbErrMsg.Location = new System.Drawing.Point(0, 0);
            this.rtbErrMsg.Name = "rtbErrMsg";
            this.rtbErrMsg.Size = new System.Drawing.Size(713, 126);
            this.rtbErrMsg.TabIndex = 0;
            this.rtbErrMsg.Text = "";
            // 
            // tbMkCode
            // 
            this.tbMkCode.FilterQuanJiao = true;
            this.tbMkCode.IsUpper = true;
            this.tbMkCode.Location = new System.Drawing.Point(70, 9);
            this.tbMkCode.Name = "tbMkCode";
            this.tbMkCode.Size = new System.Drawing.Size(211, 23);
            this.tbMkCode.TabIndex = 31;
            this.tbMkCode.TextSplitWorld = "、";
            this.tbMkCode.ValueSplitWorld = "|";
            this.tbMkCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMkCode_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "通讯状态";
            // 
            // labResult
            // 
            this.labResult.BackColor = System.Drawing.Color.White;
            this.labResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labResult.Location = new System.Drawing.Point(69, 145);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(212, 28);
            this.labResult.TabIndex = 29;
            this.labResult.Text = "----";
            this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 28;
            this.label5.Text = "工艺路线";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rtbPactInfo);
            this.panel4.Location = new System.Drawing.Point(69, 37);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(876, 53);
            this.panel4.TabIndex = 27;
            // 
            // rtbPactInfo
            // 
            this.rtbPactInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPactInfo.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbPactInfo.Location = new System.Drawing.Point(0, 0);
            this.rtbPactInfo.Name = "rtbPactInfo";
            this.rtbPactInfo.Size = new System.Drawing.Size(874, 51);
            this.rtbPactInfo.TabIndex = 0;
            this.rtbPactInfo.Text = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rtbProcess);
            this.panel3.Location = new System.Drawing.Point(69, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(876, 47);
            this.panel3.TabIndex = 26;
            // 
            // rtbProcess
            // 
            this.rtbProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProcess.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtbProcess.ForeColor = System.Drawing.Color.Maroon;
            this.rtbProcess.Location = new System.Drawing.Point(0, 0);
            this.rtbProcess.Margin = new System.Windows.Forms.Padding(0);
            this.rtbProcess.Name = "rtbProcess";
            this.rtbProcess.Size = new System.Drawing.Size(874, 45);
            this.rtbProcess.TabIndex = 0;
            this.rtbProcess.Text = "";
            // 
            // tbHistory
            // 
            this.tbHistory.Font = new System.Drawing.Font("楷体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbHistory.Location = new System.Drawing.Point(791, 145);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.ReadOnly = true;
            this.tbHistory.Size = new System.Drawing.Size(154, 162);
            this.tbHistory.TabIndex = 22;
            this.tbHistory.Text = "2019-08-05 08:32:32->NG\r\n2019-08-05 08:32:32->NG\r\n2019-08-05 08:32:32->NG";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑 Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(694, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 20);
            this.label19.TabIndex = 21;
            this.label19.Text = "历史检测记录→";
            // 
            // labListenStatus
            // 
            this.labListenStatus.BackColor = System.Drawing.Color.Lime;
            this.labListenStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labListenStatus.Location = new System.Drawing.Point(362, 144);
            this.labListenStatus.Name = "labListenStatus";
            this.labListenStatus.Size = new System.Drawing.Size(179, 28);
            this.labListenStatus.TabIndex = 20;
            this.labListenStatus.Text = "结果获取中...";
            this.labListenStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbBOMDesc
            // 
            this.tbBOMDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBOMDesc.Location = new System.Drawing.Point(595, 10);
            this.tbBOMDesc.Name = "tbBOMDesc";
            this.tbBOMDesc.ReadOnly = true;
            this.tbBOMDesc.Size = new System.Drawing.Size(349, 23);
            this.tbBOMDesc.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "CCD结果";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(533, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 14);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "模块BOM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(388, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "总电芯数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "订单信息";
            // 
            // tbDxCnt
            // 
            this.tbDxCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDxCnt.Location = new System.Drawing.Point(455, 10);
            this.tbDxCnt.Name = "tbDxCnt";
            this.tbDxCnt.ReadOnly = true;
            this.tbDxCnt.Size = new System.Drawing.Size(70, 23);
            this.tbDxCnt.TabIndex = 6;
            this.tbDxCnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(296, 5);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(80, 30);
            this.btRead.TabIndex = 2;
            this.btRead.Text = "刷新数据";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "模块编号";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 379);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(959, 28);
            this.label6.TabIndex = 217;
            this.label6.Text = "电芯明细";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgDxs
            // 
            this.dgDxs.AllowUserToAddRows = false;
            this.dgDxs.AllowUserToDeleteRows = false;
            this.dgDxs.BackgroundColor = System.Drawing.Color.White;
            this.dgDxs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDxs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgDxs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDxs.Location = new System.Drawing.Point(0, 407);
            this.dgDxs.Margin = new System.Windows.Forms.Padding(0);
            this.dgDxs.Name = "dgDxs";
            this.dgDxs.ReadOnly = true;
            this.dgDxs.RowTemplate.Height = 23;
            this.dgDxs.ShowLineNo = true;
            this.dgDxs.Size = new System.Drawing.Size(959, 130);
            this.dgDxs.TabIndex = 218;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DxSN";
            this.Column1.HeaderText = "电芯编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 240;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "DianZu";
            this.Column2.HeaderText = "内阻值(Ω)";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "V";
            this.Column3.HeaderText = "电压(uV)";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucStatistic11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 537);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 8);
            this.panel2.TabIndex = 219;
            // 
            // ucStatistic11
            // 
            this.ucStatistic11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucStatistic11.Location = new System.Drawing.Point(0, 0);
            this.ucStatistic11.Margin = new System.Windows.Forms.Padding(0);
            this.ucStatistic11.Name = "ucStatistic11";
            this.ucStatistic11.Size = new System.Drawing.Size(959, 8);
            this.ucStatistic11.TabIndex = 0;
            this.ucStatistic11.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 545);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmCCD";
            this.Text = "模块CCD检测";
            this.Load += new System.EventHandler(this.frmCCD_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDxs)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看登录信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导航ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设备异常单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件版本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看错误信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsbMsfForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDxCnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBOMDesc;
        private System.Windows.Forms.Label label6;
        private MyControl.MyDataGridView dgDxs;
        private System.Windows.Forms.Panel panel2;
        private Common.UserControls.ucTitle ucTitle1;
        private System.Windows.Forms.ToolStripMenuItem 当前工作站ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史绑定记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单进度查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.Label labListenStatus;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tbHistory;
        private Common.UserControls.ucStatistic1 ucStatistic11;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbProcess;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RichTextBox rtbPactInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 终止结果读取ToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labResult;
        private System.Windows.Forms.ToolStripMenuItem 清空窗口数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调试ToolStripMenuItem;
        private MyControl.MyTextBox tbMkCode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 撤销模块领用ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem 自动读取测试结果ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接设备ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开设备连接ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RichTextBox rtbErrMsg;
        private System.Windows.Forms.CheckBox chkStopShowErr;
        private System.Windows.Forms.Label label7;
    }
}