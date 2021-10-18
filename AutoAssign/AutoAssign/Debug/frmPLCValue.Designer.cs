namespace AutoAssign.Debug
{
    partial class frmPLCValue
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
            this.dgvList = new MyControl.MyDataGridView();
            this.btNewValue = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMyCodeStartValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbTimerIntveral = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btTimerStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.Size = new System.Drawing.Size(893, 396);
            this.dgvList.TabIndex = 0;
            // 
            // btNewValue
            // 
            this.btNewValue.Location = new System.Drawing.Point(224, 413);
            this.btNewValue.Name = "btNewValue";
            this.btNewValue.Size = new System.Drawing.Size(121, 38);
            this.btNewValue.TabIndex = 1;
            this.btNewValue.Text = "生成新的数据";
            this.btNewValue.UseVisualStyleBackColor = true;
            this.btNewValue.Click += new System.EventHandler(this.btNewValue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "起始ID";
            // 
            // tbMyCodeStartValue
            // 
            this.tbMyCodeStartValue.Location = new System.Drawing.Point(86, 423);
            this.tbMyCodeStartValue.Name = "tbMyCodeStartValue";
            this.tbMyCodeStartValue.Size = new System.Drawing.Size(100, 21);
            this.tbMyCodeStartValue.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "写入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbTimerIntveral
            // 
            this.tbTimerIntveral.Location = new System.Drawing.Point(599, 423);
            this.tbTimerIntveral.Name = "tbTimerIntveral";
            this.tbTimerIntveral.Size = new System.Drawing.Size(100, 21);
            this.tbTimerIntveral.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "间隔时间(ms)";
            // 
            // btTimerStart
            // 
            this.btTimerStart.Location = new System.Drawing.Point(737, 413);
            this.btTimerStart.Name = "btTimerStart";
            this.btTimerStart.Size = new System.Drawing.Size(121, 38);
            this.btTimerStart.TabIndex = 5;
            this.btTimerStart.Text = "开始";
            this.btTimerStart.UseVisualStyleBackColor = true;
            this.btTimerStart.Click += new System.EventHandler(this.btTimerStart_Click);
            // 
            // frmPLCValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 467);
            this.Controls.Add(this.tbTimerIntveral);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btTimerStart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbMyCodeStartValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btNewValue);
            this.Controls.Add(this.dgvList);
            this.Name = "frmPLCValue";
            this.Text = "frmPLCValue";
            this.Load += new System.EventHandler(this.frmPLCValue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyControl.MyDataGridView dgvList;
        private System.Windows.Forms.Button btNewValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMyCodeStartValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbTimerIntveral;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btTimerStart;
    }
}