using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RhombDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Rhomb rhomb)
            {
                Point point1 = new Point(rhomb.centerX, rhomb.centerY - rhomb.height / 2);//top vertex
                Point point2 = new Point(rhomb.centerX + rhomb.width / 2, rhomb.centerY);//right vertex
                Point point3 = new Point(rhomb.centerX, rhomb.centerY + rhomb.height / 2);//bottom vertex
                Point point4 = new Point(rhomb.centerX - rhomb.width / 2, rhomb.centerY);//left vertex

                Point[] vertexes = { point1, point2, point3, point4 };

                using (SolidBrush brush = new SolidBrush(rhomb.shapeColor))
                {
                    g.FillPolygon(brush, vertexes);
                }
            }
        }
    }
}
