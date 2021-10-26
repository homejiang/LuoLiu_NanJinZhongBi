namespace LuoLiuCCD.Communication
{
    partial class frmDebug
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
            this.btMkCode = new System.Windows.Forms.Button();
            this.tbPIndex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btResult = new System.Windows.Forms.Button();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labIsErr = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpecValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btMkCode
            // 
            this.btMkCode.Location = new System.Drawing.Point(169, 18);
            this.btMkCode.Name = "btMkCode";
            this.btMkCode.Size = new System.Drawing.Size(78, 27);
            this.btMkCode.TabIndex = 4;
            this.btMkCode.Text = "写入";
            this.btMkCode.UseVisualStyleBackColor = true;
            this.btMkCode.Click += new System.EventHandler(this.btMkCode_Click);
            // 
            // tbPIndex
            // 
            this.tbPIndex.Location = new System.Drawing.Point(66, 60);
            this.tbPIndex.Name = "tbPIndex";
            this.tbPIndex.Size = new System.Drawing.Size(69, 21);
            this.tbPIndex.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "PIndex";
            // 
            // btResult
            // 
            this.btResult.Location = new System.Drawing.Point(169, 60);
            this.btResult.Name = "btResult";
            this.btResult.Size = new System.Drawing.Size(78, 27);
            this.btResult.TabIndex = 13;
            this.btResult.Text = "写入";
            this.btResult.UseVisualStyleBackColor = true;
            this.btResult.Click += new System.EventHandler(this.btResult_Click);
            // 
            // chkError
            // 
            this.chkError.AutoSize = true;
            this.chkError.Location = new System.Drawing.Point(88, 25);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(15, 14);
            this.chkError.TabIndex = 14;
            this.chkError.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Error";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labIsErr
            // 
            this.labIsErr.Location = new System.Drawing.Point(21, 99);
            this.labIsErr.Name = "labIsErr";
            this.labIsErr.Size = new System.Drawing.Size(153, 29);
            this.labIsErr.TabIndex = 16;
            this.labIsErr.Text = "Error";
            this.labIsErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(66, 167);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(188, 21);
            this.tbCode.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "code";
            // 
            // tbSpecValue
            // 
            this.tbSpecValue.Location = new System.Drawing.Point(66, 194);
            this.tbSpecValue.Name = "tbSpecValue";
            this.tbSpecValue.Size = new System.Drawing.Size(69, 21);
            this.tbSpecValue.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "specValue";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 27);
            this.button1.TabIndex = 21;
            this.button1.Text = "写入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSpecValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labIsErr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkError);
            this.Controls.Add(this.btResult);
            this.Controls.Add(this.tbPIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btMkCode);
            this.Name = "frmDebug";
            this.Text = "frmDebug";
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btMkCode;
        private System.Windows.Forms.TextBox tbPIndex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btResult;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labIsErr;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSpecValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}