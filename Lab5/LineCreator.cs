using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class LineCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Line line = new Line(parametrs.x0, parametrs.y0, parametrs.color, parametrs.x1, parametrs.y1);
            line.Params = parametrs;
            return line;
        }
    }
}
