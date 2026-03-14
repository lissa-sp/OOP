using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RectDrawer : Drawer
    {
        internal override void DrawFigure(Graphics g, Figure figure)
        {
            if (figure is Rect rect)
            {
                using (SolidBrush brush = new SolidBrush(rect.shapeColor))
                {
                    g.FillRectangle(brush, rect.centerX - rect.width / 2, rect.centerY - rect.height / 2, rect.width, rect.height);
                }
            }
        }
    }
}
