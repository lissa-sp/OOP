using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class EllipseDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Ellipse ellipse)
            {
                RectangleF rect = new RectangleF(ellipse.centerX - ellipse.width / 2, ellipse.centerY - ellipse.height / 2, ellipse.width, ellipse.height);

                using (SolidBrush brush = new SolidBrush(ellipse.shapeColor))
                {
                    g.FillEllipse(brush, rect);
                }
            }
        }
    }
}
