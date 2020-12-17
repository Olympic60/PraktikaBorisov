using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PieChart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            ArrayList data = new ArrayList();
            data.Add(new PieChartElement("East", (float)50.75));
            data.Add(new PieChartElement("West", (float)22));
            data.Add(new PieChartElement("North", (float)72.32));
            data.Add(new PieChartElement("South", (float)12));
            data.Add(new PieChartElement("Central", (float)44));

            chart.Image = drawPieChart(data, new Size(chart.Width, chart.Height));
        }

        private Image drawPieChart(ArrayList elements, Size s)
        {
            Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Green, 
                Color.Blue, Color.Indigo, Color.Violet, Color.DarkRed, 
                Color.DarkOrange, Color.DarkSalmon, Color.DarkGreen, 
                Color.DarkBlue, Color.Lavender, Color.LightBlue, Color.Coral };

            if (elements.Count > colors.Length)
            {
                throw new ArgumentException("Pie chart must have " + colors.Length + " or fewer elements");
            }

            Bitmap bm = new Bitmap(s.Width, s.Height);
            Graphics g = Graphics.FromImage(bm);
            g.SmoothingMode = SmoothingMode.HighQuality;

            float total = 0;

            foreach (PieChartElement e in elements)
            {
                if (e.value < 0)
                {
                    throw new ArgumentException("All elements must have positive values");
                }
                total += e.value;
            }

            if (!(total > 0))
            {
                throw new ArgumentException("Must provide at least one PieChartElement with a positive value");
            }

           
            Rectangle rect = new Rectangle(1, 1, (s.Width / 2) - 2, s.Height - 2);
            Pen p = new Pen(Color.Black, 1);           
            float startAngle = 0;
            int colorNum = 0;

           
            foreach (PieChartElement e in elements)
            {
              
                Brush b = new LinearGradientBrush(rect, colors[colorNum++], Color.White, (float)45);                        
                float sweepAngle = (e.value / total) * 360;                              
                g.FillPie(b, rect, startAngle, sweepAngle);               
                g.DrawPie(p, rect, startAngle, sweepAngle);             
                startAngle += sweepAngle;
            }

            
            Point lRectCorner = new Point((s.Width / 2) + 2, 1);
            Size lRectSize = new Size(s.Width - (s.Width / 2) - 4, s.Height - 2);
            Rectangle lRect = new Rectangle(lRectCorner, lRectSize);

           
            Brush lb = new SolidBrush(Color.White);
            Pen lp = new Pen(Color.Black, 1);
            g.FillRectangle(lb, lRect);
            g.DrawRectangle(lp, lRect);   
            int vert = (lRect.Height - 10) / elements.Count;           
            int legendWidth = lRect.Width / 5;        
            int legendHeight = (int) (vert * 0.75);           
            int buffer = (int)(vert - legendHeight) / 2;        
            int textX = lRectCorner.X + legendWidth + buffer * 2;          
            int textWidth = lRect.Width - (lRect.Width / 5) - (buffer * 2);       
            int currentVert = 5;
            int legendColor = 0;
            foreach (PieChartElement e in elements)
            {
                
                Rectangle thisRect = new Rectangle(lRectCorner.X + buffer, currentVert + buffer, legendWidth, legendHeight);
                Brush b = new LinearGradientBrush(thisRect, colors[legendColor++], Color.White, (float)45);              
                g.FillRectangle(b, thisRect);
                g.DrawRectangle(lp, thisRect);           
                RectangleF textRect = new Rectangle(textX, currentVert + buffer, textWidth, legendHeight);           
                Font tf = new Font("Arial", 12);               
                Brush tb = new SolidBrush(Color.Black);                
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;               
                g.DrawString(e.name + ": " + e.value.ToString(), tf, tb, textRect, sf);               
                currentVert += vert;
            }
            return bm;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".jpg";
            saveDialog.Filter = "JPEG files (*.jpg)|*.jpg;*.jpeg|All files (*.*)|*.*";

            if (saveDialog.ShowDialog() != DialogResult.Cancel)
            {
               
                Bitmap bm = (Bitmap)chart.Image;
                Graphics g = Graphics.FromImage(bm);
                Font f = new Font("Arial", 12);              
                Brush b = new SolidBrush(Color.White);             
                Brush bb = new SolidBrush(Color.Black);
                string ct = "Copyright 2006, Contoso, Inc.";
                g.DrawString(ct, f, bb, 4, 4);
                g.DrawString(ct, f, bb, 4, 6);
                g.DrawString(ct, f, bb, 6, 4);
                g.DrawString(ct, f, bb, 6, 6);                
                g.DrawString(ct, f, b, 5, 5);
                bm.Save(saveDialog.FileName, ImageFormat.Jpeg);
            }
        }
    }
}