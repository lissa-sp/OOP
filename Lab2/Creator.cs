using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal abstract class Creator
    {
        internal abstract Figure createFigure(CreationParams parametrs);
    }

}
