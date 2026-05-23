using System;
using System.Collections.Generic;
using System.Linq;
using Lab1;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrianglePlugin
{
    public class Signature
    {
        public DateTime getStartDate() => new DateTime(2026, 5, 1);
        public DateTime getExpirDate() => new DateTime(2026, 5, 30);
    }

    public class Triangle : Figure
    {
        public int width;
        public int height;

        public Triangle(int x, int y, Color color, int w, int h) : base(x, y, color)
        {
            width = w;
            height = h;
        }
    }

    public class TriangleCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Triangle triangle = new Triangle(parametrs.x0, parametrs.y0, parametrs.color, parametrs.width, parametrs.height);
            triangle.Params = parametrs;
            return triangle;
        }
    }

    public class TriangleDrawer : Drawer
    {
        public override void DrawFigure(Graphics g, Figure figure)
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
