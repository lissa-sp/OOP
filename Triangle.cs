using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Triangle : Figure
    {
        public int width;
        public int height;

        public Triangle(int x, int y, Color color, int w, int h) : base(x,y,color)
        {
            width = w;
            height = h;
        }

        public override void Draw(Graphics g)
        {
            Point point1 = new Point(centerX, centerY - height / 2);//верхняя вершина
            Point point2 = new Point(centerX - width / 2, centerY + height / 2);//левая вершина
            Point point3 = new Point(centerX + width / 2, centerY + height / 2);//правая вершина

            using (SolidBrush brush = new SolidBrush(shapeColor))
            {
                Point[] points = { point1, point2, point3 };
                g.FillPolygon(brush, points);
            }
        }
    }
}
