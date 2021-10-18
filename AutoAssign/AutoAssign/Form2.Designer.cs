namespace AutoAssign
{
    partial class Form2
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
            this.btadd = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btDel = new System.Windows.Forms.Button();
            this.tbBits = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbInt32 = new System.Windows.Forms.TextBox();
            this.tbBitsMoir = new System.Windows.Forms.TextBox();
            this.ucDrawingReel1 = new AutoAssign.UserControls.ucDrawingReel();
            this.tbBitLens = new System.Windows.Forms.TextBox();
            this.ucDrawingReel2 = new AutoAssign.UserControls.ucDrawingReel();
            this.myDataGridView1 = new MyControl.MyDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(72, 75);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 0;
            this.btadd.Text = "add";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 130);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btDel
            // 
            this.btDel.Location = new System.Drawing.Point(188, 74);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(75, 23);
            this.btDel.TabIndex = 2;
            this.btDel.Text = "remove";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // tbBits
            // 
            this.tbBits.Location = new System.Drawing.Point(295, 158);
            this.tbBits.Name = "tbBits";
            this.tbBits.Size = new System.Drawing.Size(209, 21);
            this.tbBits.TabIndex = 4;
            this.tbBits.TextChanged += new System.EventHandler(this.tbBits_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "低位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(510, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "高位";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 202);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "int32";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbInt32
            // 
            this.tbInt32.Location = new System.Drawing.Point(357, 247);
            this.tbInt32.Name = "tbInt32";
            this.tbInt32.Size = new System.Drawing.Size(75, 21);
            this.tbInt32.TabIndex = 8;
            // 
            // tbBitsMoir
            // 
            this.tbBitsMoir.Location = new System.Drawing.Point(295, 115);
            this.tbBitsMoir.Name = "tbBitsMoir";
            this.tbBitsMoir.Size = new System.Drawing.Size(209, 21);
            this.tbBitsMoir.TabIndex = 4;
            // 
            // ucDrawingReel1
            // 
            this.ucDrawingReel1.Location = new System.Drawing.Point(62, 184);
            this.ucDrawingReel1.MyText = "---";
            this.ucDrawingReel1.Name = "ucDrawingReel1";
            this.ucDrawingReel1.PanNo = "?";
            this.ucDrawingReel1.PanNoUpdateTime = "";
            this.ucDrawingReel1.Size = new System.Drawing.Size(85, 127);
            this.ucDrawingReel1.TabIndex = 3;
            // 
            // tbBitLens
            // 
            this.tbBitLens.Location = new System.Drawing.Point(295, 185);
            this.tbBitLens.Name = "tbBitLens";
            this.tbBitLens.Size = new System.Drawing.Size(40, 21);
            this.tbBitLens.TabIndex = 9;
            // 
            // ucDrawingReel2
            // 
            this.ucDrawingReel2.Location = new System.Drawing.Point(49, 295);
            this.ucDrawingReel2.MyText = "---";
            this.ucDrawingReel2.Name = "ucDrawingReel2";
            this.ucDrawingReel2.PanNo = "?";
            this.ucDrawingReel2.PanNoUpdateTime = "";
            this.ucDrawingReel2.Size = new System.Drawing.Size(98, 95);
            this.ucDrawingReel2.TabIndex = 10;
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myDataGridView1.Location = new System.Drawing.Point(202, 260);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.RowTemplate.Height = 23;
            this.myDataGridView1.Size = new System.Drawing.Size(240, 150);
            this.myDataGridView1.TabIndex = 11;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 440);
            this.Controls.Add(this.myDataGridView1);
            this.Controls.Add(this.ucDrawingReel2);
            this.Controls.Add(this.tbBitLens);
            this.Controls.Add(this.tbInt32);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBitsMoir);
            this.Controls.Add(this.tbBits);
            this.Controls.Add(this.ucDrawingReel1);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btadd);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btDel;
        private AutoAssign.UserControls.ucDrawingReel ucDrawingReel1;
        private System.Windows.Forms.TextBox tbBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbInt32;
        private System.Windows.Forms.TextBox tbBitsMoir;
        private System.Windows.Forms.TextBox tbBitLens;
        private UserControls.ucDrawingReel ucDrawingReel2;
        private MyControl.MyDataGridView myDataGridView1;
    }
}