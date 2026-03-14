using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Rect : Figure
    {
        public int width;
        public int height;

        public Rect(int x, int y, Color color, int w, int h) : base(x, y, color)
        {
            width = w; 
            height = h;
        }
        
    }
}
