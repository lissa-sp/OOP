using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Line : Figure
    {
        public int endPointX;
        public int endPointY;

        public Line(int x, int y, Color color, int endX, int endY) : base(x, y, color)
        {
            endPointX = endX;
            endPointY = endY;
        }

        public override void Draw(Graphics g)
        {
            Point startPoint = new Point(centerX, centerY);
            Point endPoint = new Point(endPointX, endPointY);

            using (Pen pen = new Pen(shapeColor))
            {
                g.DrawLine(pen, startPoint, endPoint);
            }
        }

    }
}
