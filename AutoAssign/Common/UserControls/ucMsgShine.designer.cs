namespace Common.UserControls
{
    partial class ucMsgShine
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
            this.labMsg = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.labMsg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picClose, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(431, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labMsg
            // 
            this.labMsg.BackColor = System.Drawing.Color.Transparent;
            this.labMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labMsg.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labMsg.ForeColor = System.Drawing.Color.White;
            this.labMsg.Location = new System.Drawing.Point(0, 0);
            this.labMsg.Margin = new System.Windows.Forms.Padding(0);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(405, 28);
            this.labMsg.TabIndex = 0;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labMsg.DoubleClick += new System.EventHandler(this.labMsg_DoubleClick);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Image = global::Common.Properties.Resources.chCloseButton_White;
            this.picClose.Location = new System.Drawing.Point(413, 2);
            this.picClose.Margin = new System.Windows.Forms.Padding(0, 2, 3, 0);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(15, 15);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picClose.TabIndex = 1;
            this.picClose.TabStop = false;
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            this.picClose.MouseHover += new System.EventHandler(this.picClose_MouseHover);
            // 
            // ucMsgShine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucMsgShine";
            this.Size = new System.Drawing.Size(431, 28);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labMsg;
        private System.Windows.Forms.PictureBox picClose;
    }
}
