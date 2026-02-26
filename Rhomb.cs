using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Rhomb : Figure
    {
        public int width;
        public int height;

        public Rhomb(int x, int y, Color color, int w, int h) : base(x, y, color)
        {
            width = w;
            height = h;
        }

        public override void Draw(Graphics g)
        {
            Point point1 = new Point(centerX, centerY - height / 2);//верхняя вершина
            Point point2 = new Point(centerX + width / 2, centerY);//правая вершина
            Point point3 = new Point(centerX, centerY + height / 2);//нижняя вершина
            Point point4 = new Point(centerX - width / 2, centerY);//левая вершина

            Point[] vertexes = {point1, point2, point3, point4};

            using (SolidBrush brush = new SolidBrush(shapeColor))
            {
                g.FillPolygon(brush, vertexes);
            }
        }
    }
}
