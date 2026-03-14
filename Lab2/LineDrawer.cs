using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class LineDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Line line)
            {
                Point startPoint = new Point(line.centerX, line.centerY);
                Point endPoint = new Point(line.endPointX, line.endPointY);

                using (Pen pen = new Pen(line.shapeColor))
                {
                    g.DrawLine(pen, startPoint, endPoint);
                }
            }
        }
    }
}
