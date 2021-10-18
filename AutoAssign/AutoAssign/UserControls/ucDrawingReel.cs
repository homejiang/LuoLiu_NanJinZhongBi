using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoAssign.UserControls
{
    public partial class ucDrawingReel : UserControl
    {
        public ucDrawingReel()
        {
            InitializeComponent();
        }
        
        DrawingReelSatus mReelSatus = DrawingReelSatus.None;
        public void SetMyReelSatus(DrawingReelSatus value)
        {
            if (this.mReelSatus == value) return;
            this.mReelSatus = value;
            //绘制样式
            Bitmap img = new Bitmap(this.Width, this.labReelStyle.Height);
            Graphics graph = System.Drawing.Graphics.FromImage(img);
            graph.Clear(Color.White);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int iCyH = 64;
            int iCyWMarginLeft = (this.labReelStyle.Width - iCyH) / 2;
            if (iCyWMarginLeft < 0) iCyWMarginLeft = 0;
            if (value == DrawingReelSatus.Bursh_Free)
            {
                Brush bush = new SolidBrush(Color.White);//填充的颜色
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.Black;
            }
            else if (value == DrawingReelSatus.Bursh_Normal)
            {
                Brush bush = new SolidBrush(Color.Lime);
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.Black;
            }
            else if (value == DrawingReelSatus.Bursh_JingGao)
            {
                Brush bush = new SolidBrush(Color.Yellow);
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.Black;
            }
            else if (value == DrawingReelSatus.Bursh_BaoJing)
            {
                Brush bush = new SolidBrush(Color.Maroon);
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.White;
            }
            else if (value == DrawingReelSatus.Pen_Free || value == DrawingReelSatus.Pen_Normal)
            {
                Pen pen = new Pen(Color.Black);//画笔颜色       
                graph.DrawEllipse(pen, iCyWMarginLeft, 0, iCyH, iCyH);//
                this.labReelStyle.ForeColor = Color.Black;
            }
            else if (value == DrawingReelSatus.Pen_JingGao)
            {
                Pen pen = new Pen(Color.Black);//画笔颜色       
                graph.DrawEllipse(pen, iCyWMarginLeft, 0, iCyH, iCyH);//
                Brush bush = new SolidBrush(Color.Yellow);
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.Black;
            }
            else if (value == DrawingReelSatus.Pen_BaoJing)
            {
                Pen pen = new Pen(Color.Black);//画笔颜色       
                graph.DrawEllipse(pen, iCyWMarginLeft, 0, iCyH, iCyH);//
                Brush bush = new SolidBrush(Color.Maroon);
                graph.FillEllipse(bush, iCyWMarginLeft, 0, iCyH, iCyH);
                this.labReelStyle.ForeColor = Color.White;
            }
            this.labReelStyle.Image = img;
        }
        public void SetMyText(string sText)
        {
            if (this.MyText != sText)
                this.MyText = sText;
        }
        public string MyText
        {
            get
            {
                return this.labReelStyle.Text;
            }
            set
            {
                this.labReelStyle.Text = value;
            }
        }
        public string PanNo
        {
            get
            {
                return this.labPanNo.Text;
            }
            set
            {
                if (this.labPanNo.Text != value)
                    this.labPanNo.Text = value;
            }
        }
        public string PanNoUpdateTime
        {
            get
            {
                return string.Empty;
                //return this.labPanNoUpdateTime.Text;
            }
            set
            {
                //if (this.labPanNoUpdateTime.Text != value)
                //    this.labPanNoUpdateTime.Text = value;
            }
        }
        public void ClearData()
        {
            //清除数据

        }
    }
    public enum DrawingReelSatus
    {
        None,
        /// <summary>
        /// 显示空闲
        /// </summary>
        Bursh_Free,
        /// <summary>
        /// 显示正常
        /// </summary>
        Bursh_Normal,
        Bursh_JingGao,
        Bursh_BaoJing,
        Pen_Free,
        Pen_Normal,
        Pen_JingGao,
        Pen_BaoJing
    }
}
