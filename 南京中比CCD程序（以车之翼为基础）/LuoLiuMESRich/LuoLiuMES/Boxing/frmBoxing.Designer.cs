namespace LuoLiuMES.Boxing
{
    partial class frmBoxing
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labMyWeight = new System.Windows.Forms.Label();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btViewDetail = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.tbBOMSpec = new MyControl.MyTextBox();
            this.linkBOM = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMyCode = new MyControl.MyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbOperator = new MyControl.MyTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkPact = new System.Windows.Forms.LinkLabel();
            this.tbPactInfo = new MyControl.MyTextBox();
            this.linkBoxType = new System.Windows.Forms.LinkLabel();
            this.tbBoxType = new MyControl.MyTextBox();
            this.tbCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labQty = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucAutoSaveTimerShow1 = new Common.UserControls.ucAutoSaveTimerShow();
            this.btPrinterSetting = new System.Windows.Forms.Button();
            this.btCompeleted = new System.Windows.Forms.Button();
            this.linkClient = new System.Windows.Forms.LinkLabel();
            this.tbClient = new MyControl.MyTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbLog, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(873, 663);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(0, 176);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(873, 28);
            this.label2.TabIndex = 12;
            this.label2.Text = "   装托记录";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkClient);
            this.panel1.Controls.Add(this.tbClient);
            this.panel1.Controls.Add(this.labMyWeight);
            this.panel1.Controls.Add(this.panButtons);
            this.panel1.Controls.Add(this.tbBOMSpec);
            this.panel1.Controls.Add(this.linkBOM);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbMyCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbOperator);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.linkPact);
            this.panel1.Controls.Add(this.tbPactInfo);
            this.panel1.Controls.Add(this.linkBoxType);
            this.panel1.Controls.Add(this.tbBoxType);
            this.panel1.Controls.Add(this.tbCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labQty);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 176);
            this.panel1.TabIndex = 0;
            // 
            // labMyWeight
            // 
            this.labMyWeight.BackColor = System.Drawing.Color.White;
            this.labMyWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labMyWeight.Font = new System.Drawing.Font("黑体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMyWeight.Location = new System.Drawing.Point(615, 99);
            this.labMyWeight.Name = "labMyWeight";
            this.labMyWeight.Size = new System.Drawing.Size(250, 23);
            this.labMyWeight.TabIndex = 33;
            this.labMyWeight.Text = "净重:123.456kg，毛重:123.456kg";
            this.labMyWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btViewDetail);
            this.panButtons.Controls.Add(this.btAdd);
            this.panButtons.Controls.Add(this.btRemove);
            this.panButtons.Controls.Add(this.btPrint);
            this.panButtons.Location = new System.Drawing.Point(416, 131);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(454, 40);
            this.panButtons.TabIndex = 28;
            // 
            // btViewDetail
            // 
            this.btViewDetail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btViewDetail.Location = new System.Drawing.Point(348, 3);
            this.btViewDetail.Margin = new System.Windows.Forms.Padding(2);
            this.btViewDetail.Name = "btViewDetail";
            this.btViewDetail.Size = new System.Drawing.Size(101, 36);
            this.btViewDetail.TabIndex = 25;
            this.btViewDetail.Text = "查看明细";
            this.btViewDetail.UseVisualStyleBackColor = true;
            this.btViewDetail.Click += new System.EventHandler(this.btViewDetail_Click);
            // 
            // btAdd
            // 
            this.btAdd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btAdd.Location = new System.Drawing.Point(7, 2);
            this.btAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(97, 36);
            this.btAdd.TabIndex = 4;
            this.btAdd.Text = "添加";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRemove.Location = new System.Drawing.Point(116, 3);
            this.btRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(101, 36);
            this.btRemove.TabIndex = 22;
            this.btRemove.Text = "移除";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btPrint
            // 
            this.btPrint.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrint.Location = new System.Drawing.Point(229, 3);
            this.btPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(107, 36);
            this.btPrint.TabIndex = 24;
            this.btPrint.Text = "打印托号";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // tbBOMSpec
            // 
            this.tbBOMSpec.BackColor = System.Drawing.Color.White;
            this.tbBOMSpec.FilterQuanJiao = true;
            this.tbBOMSpec.IsUpper = false;
            this.tbBOMSpec.Location = new System.Drawing.Point(80, 99);
            this.tbBOMSpec.Name = "tbBOMSpec";
            this.tbBOMSpec.ReadOnly = true;
            this.tbBOMSpec.Size = new System.Drawing.Size(381, 23);
            this.tbBOMSpec.TabIndex = 27;
            this.tbBOMSpec.TextSplitWorld = "、";
            this.tbBOMSpec.ValueSplitWorld = "|";
            // 
            // linkBOM
            // 
            this.linkBOM.AutoSize = true;
            this.linkBOM.Location = new System.Drawing.Point(13, 102);
            this.linkBOM.Name = "linkBOM";
            this.linkBOM.Size = new System.Drawing.Size(63, 14);
            this.linkBOM.TabIndex = 26;
            this.linkBOM.TabStop = true;
            this.linkBOM.Text = "产品规格";
            this.linkBOM.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBOM_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(685, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "已装托数量";
            // 
            // tbMyCode
            // 
            this.tbMyCode.FilterQuanJiao = true;
            this.tbMyCode.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMyCode.IsUpper = false;
            this.tbMyCode.Location = new System.Drawing.Point(108, 135);
            this.tbMyCode.Name = "tbMyCode";
            this.tbMyCode.Size = new System.Drawing.Size(302, 30);
            this.tbMyCode.TabIndex = 21;
            this.tbMyCode.TextSplitWorld = "、";
            this.tbMyCode.ValueSplitWorld = "|";
            this.tbMyCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMyCode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 20;
            this.label4.Text = "扫描电池包";
            // 
            // tbOperator
            // 
            this.tbOperator.AcceptsReturn = true;
            this.tbOperator.FilterQuanJiao = true;
            this.tbOperator.IsUpper = false;
            this.tbOperator.Location = new System.Drawing.Point(533, 11);
            this.tbOperator.Name = "tbOperator";
            this.tbOperator.ReadOnly = true;
            this.tbOperator.Size = new System.Drawing.Size(77, 23);
            this.tbOperator.TabIndex = 19;
            this.tbOperator.TextSplitWorld = "、";
            this.tbOperator.ValueSplitWorld = "|";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(466, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "作业人员";
            // 
            // linkPact
            // 
            this.linkPact.AutoSize = true;
            this.linkPact.Location = new System.Drawing.Point(13, 43);
            this.linkPact.Name = "linkPact";
            this.linkPact.Size = new System.Drawing.Size(63, 14);
            this.linkPact.TabIndex = 17;
            this.linkPact.TabStop = true;
            this.linkPact.Text = "关联工单";
            this.linkPact.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPact_LinkClicked);
            // 
            // tbPactInfo
            // 
            this.tbPactInfo.BackColor = System.Drawing.Color.White;
            this.tbPactInfo.FilterQuanJiao = true;
            this.tbPactInfo.IsUpper = false;
            this.tbPactInfo.Location = new System.Drawing.Point(80, 39);
            this.tbPactInfo.Multiline = true;
            this.tbPactInfo.Name = "tbPactInfo";
            this.tbPactInfo.ReadOnly = true;
            this.tbPactInfo.Size = new System.Drawing.Size(530, 54);
            this.tbPactInfo.TabIndex = 16;
            this.tbPactInfo.TextSplitWorld = "、";
            this.tbPactInfo.ValueSplitWorld = "|";
            // 
            // linkBoxType
            // 
            this.linkBoxType.AutoSize = true;
            this.linkBoxType.Location = new System.Drawing.Point(222, 15);
            this.linkBoxType.Name = "linkBoxType";
            this.linkBoxType.Size = new System.Drawing.Size(63, 14);
            this.linkBoxType.TabIndex = 15;
            this.linkBoxType.TabStop = true;
            this.linkBoxType.Text = "托盘类型";
            this.linkBoxType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBoxType_LinkClicked);
            // 
            // tbBoxType
            // 
            this.tbBoxType.BackColor = System.Drawing.Color.White;
            this.tbBoxType.FilterQuanJiao = true;
            this.tbBoxType.IsUpper = false;
            this.tbBoxType.Location = new System.Drawing.Point(288, 11);
            this.tbBoxType.Name = "tbBoxType";
            this.tbBoxType.ReadOnly = true;
            this.tbBoxType.Size = new System.Drawing.Size(173, 23);
            this.tbBoxType.TabIndex = 14;
            this.tbBoxType.TextSplitWorld = "、";
            this.tbBoxType.ValueSplitWorld = "|";
            // 
            // tbCode
            // 
            this.tbCode.FilterQuanJiao = true;
            this.tbCode.IsUpper = false;
            this.tbCode.Location = new System.Drawing.Point(80, 11);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(133, 23);
            this.tbCode.TabIndex = 12;
            this.tbCode.TextSplitWorld = "、";
            this.tbCode.ValueSplitWorld = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "托盘号";
            // 
            // labQty
            // 
            this.labQty.BackColor = System.Drawing.Color.White;
            this.labQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labQty.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labQty.ForeColor = System.Drawing.Color.Black;
            this.labQty.Location = new System.Drawing.Point(615, 39);
            this.labQty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labQty.Name = "labQty";
            this.labQty.Size = new System.Drawing.Size(248, 54);
            this.labQty.TabIndex = 10;
            this.labQty.Text = "100/100";
            this.labQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbLog
            // 
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbLog.Location = new System.Drawing.Point(0, 204);
            this.tbLog.Margin = new System.Windows.Forms.Padding(0);
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(873, 408);
            this.tbLog.TabIndex = 1;
            this.tbLog.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucAutoSaveTimerShow1);
            this.panel2.Controls.Add(this.btPrinterSetting);
            this.panel2.Controls.Add(this.btCompeleted);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 615);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(867, 45);
            this.panel2.TabIndex = 13;
            // 
            // ucAutoSaveTimerShow1
            // 
            this.ucAutoSaveTimerShow1.Location = new System.Drawing.Point(498, 14);
            this.ucAutoSaveTimerShow1.Name = "ucAutoSaveTimerShow1";
            this.ucAutoSaveTimerShow1.Size = new System.Drawing.Size(282, 23);
            this.ucAutoSaveTimerShow1.TabIndex = 26;
            this.ucAutoSaveTimerShow1.TextFormat = "{0}秒创建新的托盘";
            this.ucAutoSaveTimerShow1.AutoSaveTimerStopNotice += new Common.UserControls.AutoSaveTimerStopCallBack(this.ucAutoSaveTimerShow1_AutoSaveTimerStopNotice);
            // 
            // btPrinterSetting
            // 
            this.btPrinterSetting.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrinterSetting.Location = new System.Drawing.Point(7, 4);
            this.btPrinterSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btPrinterSetting.Name = "btPrinterSetting";
            this.btPrinterSetting.Size = new System.Drawing.Size(102, 37);
            this.btPrinterSetting.TabIndex = 25;
            this.btPrinterSetting.Text = "打印机设置";
            this.btPrinterSetting.UseVisualStyleBackColor = true;
            this.btPrinterSetting.Click += new System.EventHandler(this.btPrinterSetting_Click);
            // 
            // btCompeleted
            // 
            this.btCompeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btCompeleted.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCompeleted.Location = new System.Drawing.Point(353, 4);
            this.btCompeleted.Margin = new System.Windows.Forms.Padding(2);
            this.btCompeleted.Name = "btCompeleted";
            this.btCompeleted.Size = new System.Drawing.Size(139, 36);
            this.btCompeleted.TabIndex = 23;
            this.btCompeleted.Text = "结束本次装托";
            this.btCompeleted.UseVisualStyleBackColor = true;
            this.btCompeleted.Click += new System.EventHandler(this.btCompeleted_Click);
            // 
            // linkClient
            // 
            this.linkClient.AutoSize = true;
            this.linkClient.Location = new System.Drawing.Point(467, 104);
            this.linkClient.Name = "linkClient";
            this.linkClient.Size = new System.Drawing.Size(63, 14);
            this.linkClient.TabIndex = 35;
            this.linkClient.TabStop = true;
            this.linkClient.Text = "对应客户";
            this.linkClient.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClient_LinkClicked);
            // 
            // tbClient
            // 
            this.tbClient.BackColor = System.Drawing.Color.White;
            this.tbClient.FilterQuanJiao = true;
            this.tbClient.IsUpper = false;
            this.tbClient.Location = new System.Drawing.Point(533, 99);
            this.tbClient.Name = "tbClient";
            this.tbClient.ReadOnly = true;
            this.tbClient.Size = new System.Drawing.Size(77, 23);
            this.tbClient.TabIndex = 34;
            this.tbClient.TextSplitWorld = "、";
            this.tbClient.ValueSplitWorld = "|";
            // 
            // frmBoxing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 663);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBoxing";
            this.Text = "成品装托";
            this.Load += new System.EventHandler(this.frmBoxing_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panButtons.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labQty;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label1;
        private MyControl.MyTextBox tbCode;
        private MyControl.MyTextBox tbBoxType;
        private System.Windows.Forms.LinkLabel linkBoxType;
        private System.Windows.Forms.LinkLabel linkPact;
        private MyControl.MyTextBox tbPactInfo;
        private MyControl.MyTextBox tbOperator;
        private System.Windows.Forms.Label label3;
        private MyControl.MyTextBox tbMyCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.RichTextBox tbLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btViewDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCompeleted;
        private System.Windows.Forms.LinkLabel linkBOM;
        private MyControl.MyTextBox tbBOMSpec;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.Button btPrinterSetting;
        private Common.UserControls.ucAutoSaveTimerShow ucAutoSaveTimerShow1;
        private System.Windows.Forms.Label labMyWeight;
        private System.Windows.Forms.LinkLabel linkClient;
        private MyControl.MyTextBox tbClient;
    }
}