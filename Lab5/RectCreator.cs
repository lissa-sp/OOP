using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class RectCreator : Creator
    {
        public override Figure createFigure(CreationParams parametrs)
        {
            Rect rect = new Rect(parametrs.x0, parametrs.y0, parametrs.color, parametrs.width, parametrs.height);
            rect.Params = parametrs;
            return rect;
        }
    }
}
