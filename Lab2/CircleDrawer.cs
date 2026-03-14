using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class CircleDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Circle circle)
            {
                using (SolidBrush brush = new SolidBrush(circle.shapeColor))
                {
                    g.FillEllipse(brush, circle.centerX - circle.radius, circle.centerY - circle.radius, 2 * circle.radius, 2 * circle.radius);
                }
            }
        }
    }
}
