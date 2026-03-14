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
        private Dictionary<Type, Drawer> drawers= new Dictionary<Type, Drawer>();

        public FigureList()
        {
            drawers[typeof(Circle)] = new CircleDrawer();
            drawers[typeof(Ellipse)] = new EllipseDrawer(); 
            drawers[typeof(Line)] = new LineDrawer();
            drawers[typeof(Rect)] = new RectDrawer();
            drawers[typeof(Rhomb)] = new RhombDrawer();
            drawers[typeof(Triangle)] = new TriangleDrawer();
        }

        public void Add(Figure f)
        {
            figures.Add(f);
        }

        public void Clear()
        {
            figures.Clear();
        }

        public void DrawAll(Graphics g)
        {
            foreach (Figure f in figures)
            {
                drawers[f.GetType()].DrawFigure(g, f);
            }

        }
    }
}
