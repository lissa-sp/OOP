using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class frmMain : Form
    {
        private FigureList figureList = new FigureList();
        private string chosenFigure;

        public frmMain()
        {
            InitializeComponent();

            // Подключаем обработчик события Paint
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // Получаем графику из события
            figureList.DrawAll(g);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            lblChosenFigure.Text = "Chosen: ";
            Invalidate();
        }

        private Random rnd = new Random();

        private Color getRandomColor()
        {
            return Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void btnDrawAll_Click(object sender, EventArgs e)
        {
            lblChosenFigure.Text = "Chosen: ";

            // Определяем область рисования 
            Rectangle drawArea = new Rectangle(panel1.Width + 20, 20, this.Width - panel1.Width - 40, this.Height - 100);

            figureList.Clear();
            int x, y;
            Color color;

            for (int i = 0; i < 6; i++) 
            {
                x = rnd.Next(drawArea.Left + 50, drawArea.Right - 50);
                y = rnd.Next(drawArea.Top + 50, drawArea.Bottom - 50);
                color = getRandomColor();

                switch (i)
                {
                    case 0: 
                        figureList.Add(new Circle(x, y, color, rnd.Next(30, 60)));
                        break;
                    case 1:
                        figureList.Add(new Rect(x, y, color, rnd.Next(40, 100), rnd.Next(40, 100)));
                        break;
                    case 2: 
                        figureList.Add(new Triangle(x, y, color, rnd.Next(40, 80), rnd.Next(40, 80)));
                        break;
                    case 3: 
                        figureList.Add(new Rhomb(x, y, color, rnd.Next(40, 80), rnd.Next(40, 80)));
                        break;
                    case 4: 
                        figureList.Add(new Ellipse(x, y, color, rnd.Next(40, 90), rnd.Next(30, 70)));
                        break;
                    case 5: 
                        int x2 = rnd.Next(drawArea.Left + 50, drawArea.Right - 50);
                        int y2 = rnd.Next(drawArea.Top + 50, drawArea.Bottom - 50);
                        figureList.Add(new Line(x, y, color, x2, y2));
                        break;
                }
            }

            Invalidate();
        }
        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Circle";
            lblChosenFigure.Text = "Chosen: "+chosenFigure;
        }

        private void btnDrawEllipse_Click(object sender, EventArgs e)
        {
            chosenFigure = "Ellipse";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Triangle";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rectangle";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            chosenFigure = "Line";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
        }

        private void btnDrawRhomb_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rhomb";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            switch (chosenFigure)
            {
                case "Circle":
                   figureList.Add(new Circle(e.X, e.Y, getRandomColor(), rnd.Next(5, 60)));
                   break;
                case "Ellipse":
                    figureList.Add(new Ellipse(e.X, e.Y, getRandomColor(), rnd.Next(5, 80), rnd.Next(5, 80)));
                    break;
                case "Triangle":
                    figureList.Add(new Triangle(e.X, e.Y, getRandomColor(), rnd.Next(5, 80), rnd.Next(5, 80)));
                    break;
                case "Rectangle":
                    figureList.Add(new Rect(e.X, e.Y, getRandomColor(), rnd.Next(5, 80), rnd.Next(5, 80)));
                    break;
                case "Line":
                    figureList.Add(new Line(e.X, e.Y, getRandomColor(), rnd.Next(panel1.Width, panel1.Width+200), rnd.Next(panel1.Width, panel1.Width+200)));
                    break;
                case "Rhomb":
                    figureList.Add(new Rhomb(e.X, e.Y, getRandomColor(), rnd.Next(5, 80), rnd.Next(5, 80)));
                    break;

            }
            Invalidate();
        }
    }
}
