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
            //Ограничиваем область отрисовки
            Rectangle clipRect = new Rectangle(panel1.Width, 0, frmMain.ActiveForm.Width - panel1.Width, frmMain.ActiveForm.Height);
            e.Graphics.SetClip(clipRect);

            figureList.DrawAll(g);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            Invalidate();
        }

        private Random rnd = new Random();

        private Color getRandomColor()
        {
            return Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
        private int margin;
        private void btnDrawAll_Click(object sender, EventArgs e)
        {
            Rectangle clientRect = this.ClientRectangle;

            Color currColor = getRandomColor();
            
            Circle circle = new Circle(280, 80, currColor, 60);
            figureList.Add(circle);

            currColor = getRandomColor();
            Rect rect = new Rect(400, 250, currColor, 100, 150);
            figureList.Add(rect);

            currColor = getRandomColor();
            Triangle triangle = new Triangle(250, 200, currColor, 70, 60);
            figureList.Add(triangle);

            currColor = getRandomColor();
            Rhomb rhomb = new Rhomb(450, 80, currColor, 70, 80);
            figureList.Add(rhomb);

            currColor = getRandomColor();
            Ellipse ellipse = new Ellipse(550, 250, currColor, 70, 80);
            figureList.Add(ellipse);

            currColor = getRandomColor();
            Line line = new Line(200, 320, currColor, 400, 370);
            figureList.Add(line);

            Invalidate();
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Circle";
        }

        private void btnDrawEllipse_Click(object sender, EventArgs e)
        {
            chosenFigure = "Ellipse";
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Triangle";
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rectangle";
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            chosenFigure = "Line";
        }

        private void btnDrawRhomb_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rhomb";
        }
    }
}
