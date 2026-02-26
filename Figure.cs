using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class Figure
    {
        public int centerX; 
        public int centerY;
        public Color shapeColor;

        public Figure(int x, int y, Color color) {
            centerX = x;
            centerY = y;
            shapeColor = color;
        }

        public virtual void Draw(Graphics g) { }
    }
}
