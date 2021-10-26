namespace BasicData.BOM
{
    partial class frmProcessAdd
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
            this.labNowPan = new System.Windows.Forms.Label();
            this.comProcess = new System.Windows.Forms.ComboBox();
            this.btTrue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labNowPan
            // 
            this.labNowPan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(88)))), ((int)(((byte)(136)))));
            this.labNowPan.Dock = System.Windows.Forms.DockStyle.Top;
            this.labNowPan.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.labNowPan.ForeColor = System.Drawing.Color.White;
            this.labNowPan.Location = new System.Drawing.Point(0, 0);
            this.labNowPan.Margin = new System.Windows.Forms.Padding(0);
            this.labNowPan.Name = "labNowPan";
            this.labNowPan.Size = new System.Drawing.Size(376, 41);
            this.labNowPan.TabIndex = 1;
            this.labNowPan.Text = "请选择要添加的工序";
            this.labNowPan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comProcess
            // 
            this.comProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comProcess.FormattingEnabled = true;
            this.comProcess.Location = new System.Drawing.Point(80, 62);
            this.comProcess.Name = "comProcess";
            this.comProcess.Size = new System.Drawing.Size(211, 25);
            this.comProcess.TabIndex = 2;
            // 
            // btTrue
            // 
            this.btTrue.Location = new System.Drawing.Point(122, 108);
            this.btTrue.Name = "btTrue";
            this.btTrue.Size = new System.Drawing.Size(90, 35);
            this.btTrue.TabIndex = 3;
            this.btTrue.Text = "确定";
            this.btTrue.UseVisualStyleBackColor = true;
            this.btTrue.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // frmProcessAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 164);
            this.Controls.Add(this.btTrue);
            this.Controls.Add(this.comProcess);
            this.Controls.Add(this.labNowPan);
            this.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProcessAdd";
            this.Text = "添加工序";
            this.Load += new System.EventHandler(this.frmProcessAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labNowPan;
        private System.Windows.Forms.ComboBox comProcess;
        private System.Windows.Forms.Button btTrue;
    }
}