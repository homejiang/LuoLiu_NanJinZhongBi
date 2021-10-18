namespace AutoAssign.BasicData
{
    partial class frmSelectSwitchMode
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
            this.SuspendLayout();
            // 
            // btSame
            // 
            this.btSame.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSame.Location = new System.Drawing.Point(32, 38);
            this.btSame.Name = "btSame";
            this.btSame.Size = new System.Drawing.Size(183, 65);
            this.btSame.TabIndex = 0;
            this.btSame.Text = "普通分档";
            this.btSame.UseVisualStyleBackColor = true;
            this.btSame.Click += new System.EventHandler(this.btSame_Click);
            // 
            // btDiffrent
            // 
            this.btDiffrent.Font = new System.Drawing.Font("宋体", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDiffrent.Location = new System.Drawing.Point(278, 38);
            this.btDiffrent.Name = "btDiffrent";
            this.btDiffrent.Size = new System.Drawing.Size(166, 65);
            this.btDiffrent.TabIndex = 1;
            this.btDiffrent.Text = "分AB档";
            this.btDiffrent.UseVisualStyleBackColor = true;
            this.btDiffrent.Click += new System.EventHandler(this.btDiffrent_Click);
            // 
            // frmSelectSwitchMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(479, 151);
            this.Controls.Add(this.btDiffrent);
            this.Controls.Add(this.btSame);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectSwitchMode";
            this.Text = "选择分档模式";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btSame;
        private System.Windows.Forms.Button btDiffrent;
    }
}