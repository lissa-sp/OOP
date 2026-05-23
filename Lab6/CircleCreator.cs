using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class CircleCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Circle circle = new Circle(parametrs.x0, parametrs.y0, parametrs.color, parametrs.radius);
            circle.Params = parametrs;
            return circle;
        }

    }
}
