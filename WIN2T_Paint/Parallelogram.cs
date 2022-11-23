using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN2T_Paint
{
    class Parallelogram : Shape
    {
        Graphics g;
        Point start;
        Point end;
        Color border;
        Color fill;
        int borderSize;
        bool isFilled;

        public Parallelogram(Graphics g, Point start, Point end, Color border, Color fill, int borderSize, bool isFilled)
        {
            this.g = g;
            this.start = start;
            this.end = end;
            this.border = border;
            this.fill = fill;
            this.borderSize = borderSize;
            this.isFilled = isFilled;
        }

        public void DrawShape()
        {
            Point UpperLeftCornor = new Point(start.X + ((end.X - start.X) / 3), start.Y);
            Point BottomRightCornor = new Point(start.X + (end.X - UpperLeftCornor.X), end.Y);

            g.DrawLine(new Pen(border, borderSize), UpperLeftCornor, new Point(end.X, start.Y));
            g.DrawLine(new Pen(border, borderSize), new Point(start.X, end.Y), BottomRightCornor);
            g.DrawLine(new Pen(border, borderSize), new Point(start.X, end.Y), UpperLeftCornor);
            g.DrawLine(new Pen(border, borderSize), new Point(end.X, start.Y), BottomRightCornor);

            Point[] points = new Point[]
            {
                new Point(UpperLeftCornor.X + 1, UpperLeftCornor.Y + 1),
                new Point(start.X + 1, end.Y - 1),
                new Point(BottomRightCornor.X - 1, BottomRightCornor.Y - 1),
                new Point(end.X, start.Y)
            };

            if (isFilled)
                g.FillPolygon(new SolidBrush(fill), points);
        }
    }
}
