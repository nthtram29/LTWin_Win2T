using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIN2T_Paint
{
    class Line : Shape
    {
        Graphics g;
        Point start;
        Point end;
        Color border;
        int borderSize;

        public Line(Graphics g, Point start, Point end, Color border, int borderSize)
        {
            this.g = g;
            this.start = start;
            this.end = end;
            this.border = border;
            this.borderSize = borderSize;
        }

        public void DrawShape()
        {
            g.DrawLine(new Pen(border, borderSize), start, end);
        }
    }
}
