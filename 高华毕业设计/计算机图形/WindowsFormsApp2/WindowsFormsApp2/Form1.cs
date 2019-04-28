using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        class Line
        {
            public PointF start_po;
            public PointF end_po;
            public bool beSelected;
            public Line(PointF start_po, PointF end_po)
            {
                this.start_po = start_po;
                this.end_po = end_po;
                this.beSelected = false;
            }
        }

        class Train
        {
            public List<Line> sections;
            public bool beSelected;
            public Train(List<Line> sections)
            {
                this.sections = sections;
                this.beSelected = false;
            }
        }

        List<Train> trains;

        PointF start_po, end_po;
        bool ifclickonce = false;
        List<Line> lstLines;

        public Form1()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            picDraw.MouseMove += new MouseEventHandler(picMouse_Move);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(picDraw.Width * 2, picDraw.Height * 2);
            lstLines = new List<Line>();
            trains = new List<Train>();
        }

        private void picDraw_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool hasLineBeSelected = false;
                foreach (Train train in trains)
                    foreach (Line line in train.sections)
                    {
                        float k = (line.end_po.Y - line.start_po.Y) / (line.end_po.X - line.start_po.X);
                        float deltX = e.X - line.start_po.X;
                        if (Math.Abs(line.start_po.Y + k * deltX - e.Y) < 5)
                        {
                            line.beSelected = true;
                            hasLineBeSelected = true;
                            train.beSelected = true;
                            break;
                        }
                    }
                if (hasLineBeSelected) return;
                if (!ifclickonce)
                {
                    start_po = new PointF(e.X, e.Y);
                    ifclickonce = true;
                }
                else
                {
                    end_po = new PointF(e.X, e.Y);
                    lstLines.Add(new Line(start_po, end_po));
                    start_po = end_po;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                trains.Add(new Train(lstLines));
                lstLines = new List<Line>();
                ifclickonce = false;
            }
        }

        private void picMouse_Move(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red, 3f);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            foreach (Train train in trains)
            {
                pen.Color = train.beSelected ? Color.Yellow : Color.Red;
                foreach (Line line in train.sections)
                {
                    g.DrawLine(pen, line.start_po, line.end_po);
                }
            }

            foreach (Line line in lstLines)
            {
                pen.Color = Color.Red;
                g.DrawLine(pen, line.start_po, line.end_po);
            }

            end_po = new PointF(e.X, e.Y);
            if (ifclickonce) g.DrawLine(new Pen(Color.Red), start_po, end_po);
            g.Dispose();
            picDraw.Image = bmp;
        }
    }
}
