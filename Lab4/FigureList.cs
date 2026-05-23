using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class FigureList
    {
        private List<Figure> figures = new List<Figure>();
        private Dictionary<Type, Drawer> drawers = new Dictionary<Type, Drawer>();

        internal FigureList(Dictionary<Type, Drawer> dr)
        {
            drawers = dr;
        }

        public void Add(Figure f) 
        {
            figures.Add(f);
        }

        public void Clear()
        {
            figures.Clear();
        }

        public void DrawAll(Graphics g )
        {
            foreach (Figure f in figures)
            {
                drawers[f.GetType()].DrawFigure(g, f);
            }

        }
    }
}
