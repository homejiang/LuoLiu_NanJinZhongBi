namespace AutoAssign.BasicData
{
    partial class frmSelectAutoMKMode
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
            this.btSame = new System.Windows.Forms.Button();
            this.btDiffrent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btSame
            // 
            this.btSame.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSame.Location = new System.Drawing.Point(24, 38);
            this.btSame.Name = "btSame";
            this.btSame.Size = new System.Drawing.Size(214, 65);
            this.btSame.TabIndex = 0;
            this.btSame.Text = "仅自动插装";
            this.btSame.UseVisualStyleBackColor = true;
            this.btSame.Click += new System.EventHandler(this.btSame_Click);
            // 
            // btDiffrent
            // 
            this.btDiffrent.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDiffrent.Location = new System.Drawing.Point(258, 38);
            this.btDiffrent.Name = "btDiffrent";
            this.btDiffrent.Size = new System.Drawing.Size(207, 65);
            this.btDiffrent.TabIndex = 1;
            this.btDiffrent.Text = "仅托盘模式";
            this.btDiffrent.UseVisualStyleBackColor = true;
            this.btDiffrent.Click += new System.EventHandler(this.btDiffrent_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(488, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 65);
            this.button1.TabIndex = 2;
            this.button1.Text = "混合模式";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSelectAutoMKMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(666, 151);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btDiffrent);
            this.Controls.Add(this.btSame);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectAutoMKMode";
            this.Text = "选择设备作业模式";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSame;
        private System.Windows.Forms.Button btDiffrent;
        private System.Windows.Forms.Button button1;
    }
}