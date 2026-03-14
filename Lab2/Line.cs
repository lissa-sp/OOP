using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Line : Figure
    {
        public int endPointX;
        public int endPointY;

        public Line(int x, int y, Color color, int endX, int endY) : base(x, y, color)
        {
            endPointX = endX;
            endPointY = endY;
        }
    }
}
