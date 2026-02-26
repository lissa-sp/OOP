using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class FigureList
    {
        private List<Figure> figures = new List<Figure>();

        public void Add(Figure f)
        {
            figures.Add(f);
        }

        public void Remove(Figure f)
        {
            figures.Remove(f);
        }

        public void Clear()
        {
            figures.Clear();
        }

        public void DrawAll(Graphics g)
        {
            foreach (Figure f in figures)
            {
                f.Draw(g);
            }

        }
    }
}
