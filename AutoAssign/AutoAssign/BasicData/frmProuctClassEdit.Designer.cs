namespace AutoAssign.BasicData
{
    partial class frmProuctClassEdit
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
            this.tbClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btTrue = new System.Windows.Forms.Button();
            this.labErr = new System.Windows.Forms.Label();
            this.tbPLCValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioScanner1 = new System.Windows.Forms.RadioButton();
            this.radioScanner2 = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // tbClassName
            // 
            this.tbClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbClassName.Location = new System.Drawing.Point(140, 44);
            this.tbClassName.Name = "tbClassName";
            this.tbClassName.Size = new System.Drawing.Size(276, 26);
            this.tbClassName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "电芯分类名称";
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(172, 122);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(97, 37);
            this.btTrue.TabIndex = 4;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // labErr
            // 
            this.labErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labErr.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labErr.ForeColor = System.Drawing.Color.Red;
            this.labErr.Location = new System.Drawing.Point(0, 163);
            this.labErr.Name = "labErr";
            this.labErr.Size = new System.Drawing.Size(439, 19);
            this.labErr.TabIndex = 5;
            this.labErr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPLCValue
            // 
            this.tbPLCValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPLCValue.Location = new System.Drawing.Point(140, 12);
            this.tbPLCValue.Name = "tbPLCValue";
            this.tbPLCValue.Size = new System.Drawing.Size(110, 26);
            this.tbPLCValue.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "电芯分类PLC代码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "对应扫描枪";
            // 
            // radioScanner1
            // 
            this.radioScanner1.AutoSize = true;
            this.radioScanner1.Location = new System.Drawing.Point(141, 80);
            this.radioScanner1.Name = "radioScanner1";
            this.radioScanner1.Size = new System.Drawing.Size(82, 20);
            this.radioScanner1.TabIndex = 9;
            this.radioScanner1.TabStop = true;
            this.radioScanner1.Text = "扫描枪1";
            this.radioScanner1.UseVisualStyleBackColor = true;
            // 
            // radioScanner2
            // 
            this.radioScanner2.AutoSize = true;
            this.radioScanner2.Location = new System.Drawing.Point(234, 80);
            this.radioScanner2.Name = "radioScanner2";
            this.radioScanner2.Size = new System.Drawing.Size(82, 20);
            this.radioScanner2.TabIndex = 10;
            this.radioScanner2.TabStop = true;
            this.radioScanner2.Text = "扫描枪2";
            this.radioScanner2.UseVisualStyleBackColor = true;
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Location = new System.Drawing.Point(334, 78);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(74, 20);
            this.radioNone.TabIndex = 11;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "不定义";
            this.radioNone.UseVisualStyleBackColor = true;
            // 
            // frmProuctClassEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 182);
            this.Controls.Add(this.radioNone);
            this.Controls.Add(this.radioScanner2);
            this.Controls.Add(this.radioScanner1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPLCValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labErr);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.tbClassName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProuctClassEdit";
            this.Text = "编辑电芯分类";
            this.Load += new System.EventHandler(this.frmProuctClassEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbClassName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btTrue;
        private System.Windows.Forms.Label labErr;
        private System.Windows.Forms.TextBox tbPLCValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioScanner1;
        private System.Windows.Forms.RadioButton radioScanner2;
        private System.Windows.Forms.RadioButton radioNone;
    }
}