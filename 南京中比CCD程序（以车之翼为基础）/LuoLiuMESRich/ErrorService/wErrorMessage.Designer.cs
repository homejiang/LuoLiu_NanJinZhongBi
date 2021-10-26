namespace ErrorService
{
	partial class wErrorMessage
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
            this.panErrorMessage = new System.Windows.Forms.TableLayoutPanel();
            this.panTitle = new System.Windows.Forms.Panel();
            this.labErrorShow = new System.Windows.Forms.Label();
            this.labAppError = new System.Windows.Forms.Label();
            this.tbErrorMessage = new System.Windows.Forms.TextBox();
            this.panButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSendReport = new System.Windows.Forms.Button();
            this.linkHelp = new System.Windows.Forms.LinkLabel();
            this.panErrorMessage.SuspendLayout();
            this.panTitle.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panErrorMessage
            // 
            this.panErrorMessage.ColumnCount = 1;
            this.panErrorMessage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panErrorMessage.Controls.Add(this.panTitle, 0, 0);
            this.panErrorMessage.Controls.Add(this.tbErrorMessage, 0, 1);
            this.panErrorMessage.Controls.Add(this.panButtons, 0, 2);
            this.panErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panErrorMessage.Location = new System.Drawing.Point(0, 0);
            this.panErrorMessage.Name = "panErrorMessage";
            this.panErrorMessage.RowCount = 3;
            this.panErrorMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.panErrorMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panErrorMessage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.panErrorMessage.Size = new System.Drawing.Size(568, 348);
            this.panErrorMessage.TabIndex = 0;
            // 
            // panTitle
            // 
            this.panTitle.BackColor = System.Drawing.Color.White;
            this.panTitle.Controls.Add(this.linkHelp);
            this.panTitle.Controls.Add(this.labErrorShow);
            this.panTitle.Controls.Add(this.labAppError);
            this.panTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTitle.ForeColor = System.Drawing.Color.Black;
            this.panTitle.Location = new System.Drawing.Point(0, 0);
            this.panTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panTitle.Name = "panTitle";
            this.panTitle.Size = new System.Drawing.Size(568, 64);
            this.panTitle.TabIndex = 0;
            // 
            // labErrorShow
            // 
            this.labErrorShow.AutoSize = true;
            this.labErrorShow.Location = new System.Drawing.Point(54, 38);
            this.labErrorShow.Name = "labErrorShow";
            this.labErrorShow.Size = new System.Drawing.Size(221, 12);
            this.labErrorShow.TabIndex = 1;
            this.labErrorShow.Text = "系统在运行中发生错误，错误信息如下：";
            // 
            // labAppError
            // 
            this.labAppError.AutoSize = true;
            this.labAppError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labAppError.Location = new System.Drawing.Point(9, 9);
            this.labAppError.Name = "labAppError";
            this.labAppError.Size = new System.Drawing.Size(144, 25);
            this.labAppError.TabIndex = 0;
            this.labAppError.Text = "程序运行出错";
            // 
            // tbErrorMessage
            // 
            this.tbErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbErrorMessage.Location = new System.Drawing.Point(3, 67);
            this.tbErrorMessage.Multiline = true;
            this.tbErrorMessage.Name = "tbErrorMessage";
            this.tbErrorMessage.ReadOnly = true;
            this.tbErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbErrorMessage.Size = new System.Drawing.Size(562, 216);
            this.tbErrorMessage.TabIndex = 1;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.btnCancel);
            this.panButtons.Controls.Add(this.btnSendReport);
            this.panButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panButtons.Location = new System.Drawing.Point(3, 289);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(562, 56);
            this.panButtons.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(473, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "不发送";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSendReport
            // 
            this.btnSendReport.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendReport.ForeColor = System.Drawing.Color.Black;
            this.btnSendReport.Location = new System.Drawing.Point(367, 13);
            this.btnSendReport.Name = "btnSendReport";
            this.btnSendReport.Size = new System.Drawing.Size(96, 34);
            this.btnSendReport.TabIndex = 1;
            this.btnSendReport.Text = "发送错误报告";
            this.btnSendReport.UseVisualStyleBackColor = false;
            this.btnSendReport.Click += new System.EventHandler(this.btnSendReport_Click);
            // 
            // linkHelp
            // 
            this.linkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkHelp.AutoSize = true;
            this.linkHelp.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkHelp.Location = new System.Drawing.Point(474, 40);
            this.linkHelp.Name = "linkHelp";
            this.linkHelp.Size = new System.Drawing.Size(89, 20);
            this.linkHelp.TabIndex = 2;
            this.linkHelp.TabStop = true;
            this.linkHelp.Text = "联系我们";
            this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
            // 
            // wErrorMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 348);
            this.Controls.Add(this.panErrorMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "wErrorMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统运行发生错误";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.wErrorMessage_Load);
            this.panErrorMessage.ResumeLayout(false);
            this.panErrorMessage.PerformLayout();
            this.panTitle.ResumeLayout(false);
            this.panTitle.PerformLayout();
            this.panButtons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel panErrorMessage;
		private System.Windows.Forms.Panel panTitle;
		private System.Windows.Forms.Label labErrorShow;
		private System.Windows.Forms.Label labAppError;
		private System.Windows.Forms.TextBox tbErrorMessage;
        private System.Windows.Forms.Panel panButtons;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSendReport;
        private System.Windows.Forms.LinkLabel linkHelp;
	}
}