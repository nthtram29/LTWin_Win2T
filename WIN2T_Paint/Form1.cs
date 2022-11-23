using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WIN2T_Paint
{
    public partial class Form1 : Form
    {

        private Color fill;
        private Color border;
        private bool mouse_is_down = false;
        private Point start;
        private Graphics g;
        List<Shape> listShape;
        Shape currentShape;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            border = Color.Black;
            btnBoderColor.BackColor = border;
            fill = Color.White;
            btnFillColor.BackColor = fill;
            listShape = new List<Shape>();
            bmp = new Bitmap(panel1.Width, panel1.Height);
            g = Graphics.FromImage(bmp);
        }

        private void btnBoderColor_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog dl = new ColorDialog();
            dl.FullOpen = true;
            dl.AnyColor = true;
            if (dl.ShowDialog() == DialogResult.OK)
            {
                btnBoderColor.BackColor = dl.Color;
                border = dl.Color;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_is_down = true;
            start = new Point(e.X, e.Y);
            //MessageBox.Show();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_is_down = false;
            listShape.Add(currentShape);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_is_down)
            {
                g.Clear(panel1.BackColor);
                //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                panel1.Invalidate();
                if (listShape.Count != 0)
                {
                    foreach (var x in listShape) { x.DrawShape(); }
                }
                Point end = new Point(e.X, e.Y);
                switch (cboType.SelectedIndex)
                {
                    case 0:
                        Shape line = new Line(g, start, end, border, (int)nudBorderSize.Value);
                        line.DrawShape();
                        currentShape = line;
                        break;
                    case 1:
                        Shape ellipse = new CustomEllipse(g, start, end, border, fill, (int)nudBorderSize.Value, false);
                        ellipse.DrawShape();
                        currentShape = ellipse;
                        break;
                    case 2:
                        Shape ellipseFilled = new CustomEllipse(g, start, end, border, fill, (int)nudBorderSize.Value, true);
                        ellipseFilled.DrawShape();
                        currentShape = ellipseFilled;
                        break;
                    case 3:
                        Shape rectangle = new CustomRectangle(g, start, end, border, fill, (int)nudBorderSize.Value, false);
                        rectangle.DrawShape();
                        currentShape = rectangle;
                        break;
                    case 4:
                        Shape rectangleFilled = new CustomRectangle(g, start, end, border, fill, (int)nudBorderSize.Value, true);
                        rectangleFilled.DrawShape();
                        currentShape = rectangleFilled;
                        break;
                    case 5:
                        Shape triangle = new Triangle(g, border, fill, (int)nudBorderSize.Value, start, end, false);
                        triangle.DrawShape();
                        currentShape = triangle;
                        break;
                    case 6:
                        Shape triangleFilled = new Triangle(g, border, fill, (int)nudBorderSize.Value, start, end, true);
                        triangleFilled.DrawShape();
                        currentShape = triangleFilled;
                        break;
                    case 7:
                        Shape parallelogram = new Parallelogram(g, start, end, border, fill, (int)nudBorderSize.Value, false);
                        parallelogram.DrawShape();
                        currentShape = parallelogram;
                        break;
                    case 8:
                        Shape parallelogramFilled = new Parallelogram(g, start, end, border, fill, (int)nudBorderSize.Value, true);
                        parallelogramFilled.DrawShape();
                        currentShape = parallelogramFilled;
                        break;
                    default:
                        break;
                }
            }
            //panel1.Invalidate();
            
        }

        private void btnFillColor_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog dl = new ColorDialog();
            dl.FullOpen = true;
            dl.AnyColor = true;
            if (dl.ShowDialog() == DialogResult.OK)
            {
                btnFillColor.BackColor = dl.Color;
                fill = dl.Color;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.CheckFileExists = false;
            save.CheckPathExists = true;
            //save.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            save.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png|BMP|*.bmp";
            save.InitialDirectory = @"C:\Users\";

            DialogResult result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                Rectangle rectangle = new Rectangle(0, 0, panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bmp, rectangle);
                bmp.Save(save.FileName);

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, Point.Empty);
        }
    }
}
