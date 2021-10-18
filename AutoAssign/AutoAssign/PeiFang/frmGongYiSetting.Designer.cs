namespace AutoAssign.PeiFang
{
    partial class frmGongYiSetting
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
            this.uc1 = new AutoAssign.UserControls.ucMyGroove();
            this.button1 = new System.Windows.Forms.Button();
            this.labMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uc1
            // 
            this.uc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uc1.GrooveNo = ((short)(1));
            this.uc1.Location = new System.Drawing.Point(9, 14);
            this.uc1.Margin = new System.Windows.Forms.Padding(0);
            this.uc1.Name = "uc1";
            this.uc1.Size = new System.Drawing.Size(440, 52);
            this.uc1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 32);
            this.button1.TabIndex = 24;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labMsg
            // 
            this.labMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labMsg.Location = new System.Drawing.Point(0, 114);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(461, 23);
            this.labMsg.TabIndex = 25;
            this.labMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmGongYiSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 137);
            this.Controls.Add(this.labMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.uc1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGongYiSetting";
            this.Text = "快捷设置";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucMyGroove uc1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labMsg;
    }
}