using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RhombCreator : Creator
    {
        internal override Figure createFigure(CreationParams parametrs)
        {
            return new Rhomb(parametrs.x0, parametrs.y0, parametrs.color, parametrs.width, parametrs.height);
        }
    }
}
