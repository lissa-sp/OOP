using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class TriangleDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Triangle triangle)
            {
                Point point1 = new Point(triangle.centerX, triangle.centerY - triangle.height / 2);//top vertex
                Point point2 = new Point(triangle.centerX - triangle.width / 2, triangle.centerY + triangle.height / 2);//left vertex
                Point point3 = new Point(triangle.centerX + triangle.width / 2, triangle.centerY + triangle.height / 2);//right vertex

                using (SolidBrush brush = new SolidBrush(triangle.shapeColor))
                {
                    Point[] points = { point1, point2, point3 };
                    g.FillPolygon(brush, points);
                }
            }
        }
    }
}
