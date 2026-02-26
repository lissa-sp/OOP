using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Circle : Figure
    {
        public int radius;

        public Circle(int x, int y, Color color, int radius) : base(x,y,color)
        {
            this.radius = radius;
        }

        public override void Draw(Graphics g)
        {
            using (SolidBrush brush = new SolidBrush(shapeColor))
            {
                g.FillEllipse(brush, centerX - radius, centerY - radius, 2 * radius, 2 * radius);
            }
        }
    }
}
