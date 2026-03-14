using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
        Creator creator;

        public frmMain()
        {
            InitializeComponent();

            AddStaticFigures();

            this.Paint += Form1_Paint;
        }

        //Firstly create 6 static figures
        private void AddStaticFigures()
        {
            Circle circle = new Circle(300, 100, Color.Red, 50);
            figureList.Add(circle);

            Rect rect = new Rect(400, 200, Color.Blue, 100, 80);
            figureList.Add(rect);

            Triangle triangle = new Triangle(250, 300, Color.Green, 70, 60);
            figureList.Add(triangle);

            Rhomb rhomb = new Rhomb(450, 350, Color.Orange, 80, 60);
            figureList.Add(rhomb);

            Ellipse ellipse = new Ellipse(550, 150, Color.Purple, 90, 50);
            figureList.Add(ellipse);

            Line line = new Line(200, 400, Color.Black, 500, 420);
            figureList.Add(line);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; //Get grafics from the event
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

            //Create the paint area 
            Rectangle drawArea = new Rectangle(panel1.Width + 20, 20, this.Width - panel1.Width - 40, this.Height - 50);

            figureList.Clear();
            CreationParams par = new CreationParams();
            
            //Create list of figure creators
            List<Creator> creatorList = new List<Creator>()
            {
                new CircleCreator(), 
                new EllipseCreator(), 
                new LineCreator(), 
                new RectCreator(), 
                new RhombCreator(), 
                new TriangleCreator()
            };

            //Random placed 6 figures
            foreach (Creator creator in creatorList)
            {
                par.x0 = rnd.Next(drawArea.Left + 50, drawArea.Right - 50);
                par.y0 = rnd.Next(drawArea.Top + 50, drawArea.Bottom - 50);
                par.color = getRandomColor();
                par.radius = rnd.Next(30, 60);
                par.width = rnd.Next(40, 100);
                par.height = rnd.Next(40, 100);
                par.x1 = rnd.Next(drawArea.Left + 50, drawArea.Right - 50);
                par.y1 = rnd.Next(drawArea.Top + 50, drawArea.Bottom - 50);

                figureList.Add(creator.createFigure(par));

            }

            Invalidate();
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Circle";
            lblChosenFigure.Text = "Chosen: "+chosenFigure;
            creator = new CircleCreator();
        }

        private void btnDrawEllipse_Click(object sender, EventArgs e)
        {
            chosenFigure = "Ellipse";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
            creator = new EllipseCreator();
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            chosenFigure = "Triangle";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
            creator = new TriangleCreator();
        }

        private void btnDrawRect_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rectangle";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
            creator = new RectCreator();
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            chosenFigure = "Line";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
            creator = new LineCreator();
        }

        private void btnDrawRhomb_Click(object sender, EventArgs e)
        {
            chosenFigure = "Rhomb";
            lblChosenFigure.Text = "Chosen: " + chosenFigure;
            creator = new RhombCreator();
        }

        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {

            CreationParams par = new CreationParams();
            par.x0 = e.X;
            par.y0 = e.Y;
            par.color = getRandomColor();
            par.radius = rnd.Next(5, 50);
            par.width = rnd.Next(5, 80);
            par.height = rnd.Next(5, 80);
            par.x1 = rnd.Next(panel1.Width, panel1.Width + 200);
            par.y1 = rnd.Next(0, panel1.Height);

            if (creator != null)
            {
                figureList.Add(creator.createFigure(par));
            }

            Invalidate();
        }
    }
}
