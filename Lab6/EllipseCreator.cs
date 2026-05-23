using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class EllipseCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Ellipse ellipse = new Ellipse(parametrs.x0, parametrs.y0, parametrs.color, parametrs.width, parametrs.height);
            ellipse.Params = parametrs;
            return ellipse;
        }
    }
}
