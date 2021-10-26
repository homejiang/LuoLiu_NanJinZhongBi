namespace Common
{
    partial class frmExpMsgBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpMsgBox));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numAutoCloseSecond = new MyControl.NumericBox();
            this.lab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "知道了";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(980, 384);
            this.label1.TabIndex = 1;
            // 
            // numAutoCloseSecond
            // 
            this.numAutoCloseSecond.BindValue = ((object)(resources.GetObject("numAutoCloseSecond.BindValue")));
            this.numAutoCloseSecond.FilterQuanJiao = false;
            this.numAutoCloseSecond.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numAutoCloseSecond.Formart = "#########0";
            this.numAutoCloseSecond.IsHundred = false;
            this.numAutoCloseSecond.IsPercent = false;
            this.numAutoCloseSecond.Location = new System.Drawing.Point(870, 502);
            this.numAutoCloseSecond.Name = "numAutoCloseSecond";
            this.numAutoCloseSecond.Size = new System.Drawing.Size(92, 30);
            this.numAutoCloseSecond.TabIndex = 3;
            this.numAutoCloseSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lab
            // 
            this.lab.AutoSize = true;
            this.lab.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab.Location = new System.Drawing.Point(963, 509);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(29, 20);
            this.lab.TabIndex = 4;
            this.lab.Text = "秒";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmExpMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 535);
            this.Controls.Add(this.lab);
            this.Controls.Add(this.numAutoCloseSecond);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExpMsgBox";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息提示";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmExpMsgBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private MyControl.NumericBox numAutoCloseSecond;
        private System.Windows.Forms.Label lab;
        private System.Windows.Forms.Timer timer1;
    }
}