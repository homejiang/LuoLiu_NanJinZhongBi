namespace LuoLiuMES.TraceBack
{
    partial class frmTraceBackRich
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comSFGTypes = new System.Windows.Forms.ComboBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.tbSFGCode = new MyControl.MyTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panMk = new System.Windows.Forms.Panel();
            this.ucMk1 = new LuoLiuMES.TraceBack.ucMk();
            this.panMz = new System.Windows.Forms.Panel();
            this.ucMz1 = new LuoLiuMES.TraceBack.ucMz();
            this.panChengPin = new System.Windows.Forms.Panel();
            this.ucChengPin1 = new LuoLiuMES.TraceBack.ucChengPin();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panMk.SuspendLayout();
            this.panMz.SuspendLayout();
            this.panChengPin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 742);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comSFGTypes);
            this.panel1.Controls.Add(this.btSearch);
            this.panel1.Controls.Add(this.tbSFGCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 38);
            this.panel1.TabIndex = 2;
            // 
            // comSFGTypes
            // 
            this.comSFGTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.comSFGTypes.DropDownHeight = 306;
            this.comSFGTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSFGTypes.DropDownWidth = 243;
            this.comSFGTypes.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comSFGTypes.FormattingEnabled = true;
            this.comSFGTypes.IntegralHeight = false;
            this.comSFGTypes.Location = new System.Drawing.Point(91, 5);
            this.comSFGTypes.Name = "comSFGTypes";
            this.comSFGTypes.Size = new System.Drawing.Size(143, 25);
            this.comSFGTypes.TabIndex = 3;
            // 
            // btSearch
            // 
            this.btSearch.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSearch.Location = new System.Drawing.Point(569, 5);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(89, 28);
            this.btSearch.TabIndex = 2;
            this.btSearch.Text = "搜索";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // tbSFGCode
            // 
            this.tbSFGCode.FilterQuanJiao = true;
            this.tbSFGCode.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbSFGCode.IsUpper = false;
            this.tbSFGCode.Location = new System.Drawing.Point(240, 5);
            this.tbSFGCode.Name = "tbSFGCode";
            this.tbSFGCode.Size = new System.Drawing.Size(323, 27);
            this.tbSFGCode.TabIndex = 1;
            this.tbSFGCode.TextSplitWorld = "、";
            this.tbSFGCode.ValueSplitWorld = "|";
            this.tbSFGCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSFGCode_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "产品类型";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panMk);
            this.panel2.Controls.Add(this.panMz);
            this.panel2.Controls.Add(this.panChengPin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(959, 704);
            this.panel2.TabIndex = 3;
            // 
            // panMk
            // 
            this.panMk.Controls.Add(this.ucMk1);
            this.panMk.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMk.Location = new System.Drawing.Point(0, 500);
            this.panMk.Name = "panMk";
            this.panMk.Size = new System.Drawing.Size(942, 253);
            this.panMk.TabIndex = 2;
            // 
            // ucMk1
            // 
            this.ucMk1.BackColor = System.Drawing.SystemColors.Control;
            this.ucMk1.Location = new System.Drawing.Point(3, 5);
            this.ucMk1.Margin = new System.Windows.Forms.Padding(0);
            this.ucMk1.Name = "ucMk1";
            this.ucMk1.Size = new System.Drawing.Size(857, 241);
            this.ucMk1.TabIndex = 0;
            // 
            // panMz
            // 
            this.panMz.Controls.Add(this.ucMz1);
            this.panMz.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMz.Location = new System.Drawing.Point(0, 250);
            this.panMz.Name = "panMz";
            this.panMz.Size = new System.Drawing.Size(942, 250);
            this.panMz.TabIndex = 1;
            // 
            // ucMz1
            // 
            this.ucMz1.BackColor = System.Drawing.SystemColors.Control;
            this.ucMz1.Location = new System.Drawing.Point(0, 0);
            this.ucMz1.Name = "ucMz1";
            this.ucMz1.Size = new System.Drawing.Size(857, 241);
            this.ucMz1.TabIndex = 0;
            // 
            // panChengPin
            // 
            this.panChengPin.Controls.Add(this.ucChengPin1);
            this.panChengPin.Dock = System.Windows.Forms.DockStyle.Top;
            this.panChengPin.Location = new System.Drawing.Point(0, 0);
            this.panChengPin.Name = "panChengPin";
            this.panChengPin.Size = new System.Drawing.Size(942, 250);
            this.panChengPin.TabIndex = 0;
            // 
            // ucChengPin1
            // 
            this.ucChengPin1.BackColor = System.Drawing.SystemColors.Control;
            this.ucChengPin1.Location = new System.Drawing.Point(0, 0);
            this.ucChengPin1.Name = "ucChengPin1";
            this.ucChengPin1.Size = new System.Drawing.Size(857, 241);
            this.ucChengPin1.TabIndex = 0;
            // 
            // frmTraceBackRich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTraceBackRich";
            this.Text = "数据追溯";
            this.Load += new System.EventHandler(this.frmTraceBackRich_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panMk.ResumeLayout(false);
            this.panMz.ResumeLayout(false);
            this.panChengPin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comSFGTypes;
        private System.Windows.Forms.Button btSearch;
        private MyControl.MyTextBox tbSFGCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panMk;
        private System.Windows.Forms.Panel panMz;
        private System.Windows.Forms.Panel panChengPin;
        private ucChengPin ucChengPin1;
        private ucMk ucMk1;
        private ucMz ucMz1;
    }
}