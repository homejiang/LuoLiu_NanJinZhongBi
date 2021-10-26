namespace LuoLiuMES.Boxing
{
    partial class frmSelectBOM
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
            this.label1 = new System.Windows.Forms.Label();
            this.comMyType = new System.Windows.Forms.ComboBox();
            this.comMyYear = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.comBOM = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "电池组类型";
            // 
            // comMyType
            // 
            this.comMyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comMyType.FormattingEnabled = true;
            this.comMyType.Location = new System.Drawing.Point(105, 15);
            this.comMyType.Name = "comMyType";
            this.comMyType.Size = new System.Drawing.Size(91, 23);
            this.comMyType.TabIndex = 1;
            // 
            // comMyYear
            // 
            this.comMyYear.FormattingEnabled = true;
            this.comMyYear.Location = new System.Drawing.Point(329, 12);
            this.comMyYear.Name = "comMyYear";
            this.comMyYear.Size = new System.Drawing.Size(101, 23);
            this.comMyYear.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "电池组规格";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(39, 53);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(61, 15);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "BOM结构";
            // 
            // comBOM
            // 
            this.comBOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBOM.FormattingEnabled = true;
            this.comBOM.Location = new System.Drawing.Point(105, 50);
            this.comBOM.Name = "comBOM";
            this.comBOM.Size = new System.Drawing.Size(325, 23);
            this.comBOM.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSelectBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 151);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comBOM);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.comMyYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comMyType);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectBOM";
            this.Text = "选择产品类型";
            this.Load += new System.EventHandler(this.frmSelectBOM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comMyType;
        private System.Windows.Forms.ComboBox comMyYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ComboBox comBOM;
        private System.Windows.Forms.Button button1;
    }
}