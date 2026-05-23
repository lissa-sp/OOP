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
        private List<IObserver> observers = new List<IObserver>();

        internal FigureList(Dictionary<Type, Drawer> dr)
        {
            drawers = dr;
        }

        public void Subscribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }


        public List<Figure> GetAllFigures()
        {
            return figures;
        }

        public void Add(Figure f) 
        {
            figures.Add(f);
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }

        public void Clear() 
        {
            figures.Clear();
            NotifyObservers();
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
