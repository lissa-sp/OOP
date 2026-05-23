using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public abstract class Drawer
    {
        public abstract void DrawFigure(Graphics g, Figure figure);
    }
}
