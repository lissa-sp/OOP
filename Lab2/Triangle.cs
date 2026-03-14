using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Triangle : Figure
    {
        public int width;
        public int height;

        public Triangle(int x, int y, Color color, int w, int h) : base(x,y,color)
        {
            width = w;
            height = h;
        }
    }
}
