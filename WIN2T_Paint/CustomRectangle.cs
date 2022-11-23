using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN2T_Paint
{
    class CustomRectangle : Shape
    {
        Graphics g;
        Point start;
        Point end;
        Color border;
        Color fill;
        int borderSize;
        bool isFilled;

        public CustomRectangle(Graphics g, Point start, Point end, Color border, Color fill, int borderSize, bool isFilled)
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
            g.DrawRectangle(new Pen(border, borderSize), start.X, start.Y, end.X - start.X, end.Y - start.Y);
            g.FillRectangle(new SolidBrush(fill), start.X, start.Y, end.X - start.X, end.Y - start.Y);
        }
    }
}
