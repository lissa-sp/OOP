using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Circle : Figure
    {
        public int radius;

        public Circle(int x, int y, Color color, int radius) : base(x, y, color)
        {
            this.radius = radius;
        }


    }


}
