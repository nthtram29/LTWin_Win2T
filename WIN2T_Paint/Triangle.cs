using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN2T_Paint
{
    class Triangle : Shape
    {
        Graphics g;
        Point start;
        Point end;
        Color border;
        Color fill;
        int borderSize;
        bool isFilled;

        public Triangle(Graphics g, Color border, Color fill, int borderSize, Point start, Point end, bool isFilled)
        {
            this.g = g;
            this.border = border;
            this.fill = fill;
            this.borderSize = borderSize;
            this.start = start;
            this.end = end;
            this.isFilled = isFilled;
        }

        public void DrawShape()
        {
            g.DrawLine(new Pen(border, borderSize), 
                        new Point(start.X, end.Y), 
                        new Point((start.X + end.X) / 2, start.Y));
            g.DrawLine(new Pen(border, borderSize),
                        new Point((start.X + end.X) / 2, start.Y),
                        new Point(end.X, end.Y));
            g.DrawLine(new Pen(border, borderSize),
                        new Point(start.X, end.Y),
                        new Point(end.X, end.Y));
            Point[] points = new Point[]
            {
                new Point(start.X + 1, end.Y - 1),
                new Point((start.X + end.X) / 2, start.Y + 1),
                new Point(end.X - 1, end.Y - 1)
            };
            if (isFilled)
                g.FillPolygon(new SolidBrush(fill), points);
        }
    }
}
