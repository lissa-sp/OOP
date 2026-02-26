using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Ellipse : Figure
    {
        public int width;
        public int height;

        public Ellipse(int x, int y, Color color, int w, int h) : base(x, y, color)
        {
            width = w;
            height = h;
        }

        public override void Draw(Graphics g)
        {
            RectangleF rect = new RectangleF(centerX - width/2, centerY - height / 2, width, height);

            using (SolidBrush brush = new SolidBrush(shapeColor))
            {
                g.FillEllipse(brush, rect);
            }
        }
    }
}
