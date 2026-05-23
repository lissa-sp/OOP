using System;
using Lab1;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RhombPlugin
{
    public class Signature
    {
        public DateTime getStartDate() => new DateTime(2026, 5, 1);
        public DateTime getExpirDate() => new DateTime(2026, 5, 30);
    }

    public class Rhomb : Figure
    {
        public int width;
        public int height;

        public Rhomb(int x, int y, Color color, int w, int h) : base(x, y, color)
        {
            width = w;
            height = h;
        }

    }

    public class RhombCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Rhomb rhomb= new Rhomb(parametrs.x0, parametrs.y0, parametrs.color, parametrs.width, parametrs.height);
            rhomb.Params = parametrs;
            return rhomb;
        }
    }

    public class RhombDrawer : Drawer
    {
        public override void DrawFigure(Graphics g, Figure figure)
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