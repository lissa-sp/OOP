using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class frmMain : Form
    {
        private FigureList figureList = null;
        private string chosenFigure;
        Dictionary<Type, Creator> creators = new Dictionary<Type, Creator>();
        Dictionary<Type, Drawer> drawers = new Dictionary<Type, Drawer>();
        Type currChosenFigureType = null;

        Dictionary<string, string> checkingPlugins = new Dictionary<string, string>
        {
            { "RhombPlugin.dll", "932DC010083D0D419C20579F447084DC88967D227401894333BE0BBC542D7A85"},
            { "TrianglePlugin.dll", "B797C3BD9A33FC39D702ED62E932FE88044B40DEB3416433B5909B728D93B329" }
        };

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadInternalFigures();
            loadPluginFigures();

            //Create buttons for each loaded figure
            createButtons();

            figureList = new FigureList(drawers);

            this.Paint += Form1_Paint;
        }

        private void createButtons()
        {
            int y = 140;
            const int x = 15;
            foreach (Type typeOfFigure in creators.Keys)
            {
                Button btn = new Button();
                btn.Text = typeOfFigure.ToString().Split('.')[1];
                btn.Font = btnDrawAll.Font;
                btn.Location = new Point(x, y);
                btn.Size = new Size(130, 38);
                btn.Click += (s, e) =>
                {
                    chosenFigure = btn.Text;
                    lblChosenFigure.Text = "Chosen: " + chosenFigure;
                    currChosenFigureType = typeOfFigure;
                };
                panel1.Controls.Add(btn);
                y += 44;

            }
        }

        private void loadInternalFigures()
        {
            creators[typeof(Circle)] = new CircleCreator();
            drawers[typeof(Circle)] = new CircleDrawer();

            creators[typeof(Ellipse)] = new EllipseCreator();
            drawers[typeof(Ellipse)] = new EllipseDrawer();

            creators[typeof(Rect)] = new RectCreator();
            drawers[typeof(Rect)] = new RectDrawer();

            creators[typeof(Line)] = new LineCreator();
            drawers[typeof(Line)] = new LineDrawer();
        }

        private void loadPluginFigures()
        {
            string pathToPluginsFolder = Path.Combine(Application.StartupPath, "Plugins");   

            if (!Directory.Exists(pathToPluginsFolder))
            {
                Directory.CreateDirectory(pathToPluginsFolder);
                MessageBox.Show(
                    $"Плагины должны находится в папке Plugins. Путь: {pathToPluginsFolder}",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string[] dllFiles = Directory.GetFiles(pathToPluginsFolder, "*.dll");

            foreach (string currDll in dllFiles)
            {
                Assembly asm = Assembly.LoadFrom(currDll);

                Type[] types = asm.GetTypes();
                Type typeOfFigure = null;
                Type typeOfFigureCreator = null;
                Type typeOfFigureDrawer = null;
                Type typeOfSignature = null;

                Boolean isCorrectSignature = true;

                foreach (Type type in types)
                {
                    if (type.Name == "Signature")
                        typeOfSignature = type;
                    else if (type.IsSubclassOf(typeof(Figure)))
                        typeOfFigure = type;
                    else if (type.IsSubclassOf(typeof(Creator)))
                        typeOfFigureCreator = type;
                    else if (type.IsSubclassOf(typeof(Drawer)))
                        typeOfFigureDrawer = type;
                }


                //Checking for correct signature
                if (typeOfSignature != null)
                {
                    object signInstance = Activator.CreateInstance(typeOfSignature);

                    //Checking for correct time
                    DateTime currDate = DateTime.Today;

                    MethodInfo getStartDate = typeOfSignature.GetMethod("getStartDate");

                    if (getStartDate != null)
                    {
                        DateTime startDate = (DateTime)getStartDate.Invoke(signInstance, parameters: null);

                        if (startDate > currDate)
                            isCorrectSignature = false;

                    }

                    if (isCorrectSignature)
                    {
                        MethodInfo getExpirdate = typeOfSignature.GetMethod("getExpirDate");

                        if (getExpirdate != null)
                        {
                            DateTime expirDate = (DateTime)getExpirdate.Invoke(signInstance, parameters: null);

                            if (currDate > expirDate)
                                isCorrectSignature = false;
                        }
                    }

                    //Checking for correсt hash
                    if (isCorrectSignature)
                    {
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] bytesOfFile = File.ReadAllBytes(currDll);

                            byte[] hashBytes = sha256.ComputeHash(bytesOfFile);
                            string strHash = BitConverter.ToString(hashBytes).Replace("-", "");

                            string nameOfFile = Path.GetFileName(currDll);

                            if (checkingPlugins[nameOfFile] != strHash)
                                isCorrectSignature = false;
                        }

                    }
                }

                if (isCorrectSignature)
                {
                    if (typeOfFigureCreator != null && typeOfFigure != null)
                    {
                        object creatorInstance = Activator.CreateInstance(typeOfFigureCreator);
                        creators[typeOfFigure] = (Creator)creatorInstance;
                    }

                    if (typeOfFigureDrawer != null && typeOfFigure != null)
                    {
                        object drawerInstance = Activator.CreateInstance(typeOfFigureDrawer);
                        drawers[typeOfFigure] = (Drawer)drawerInstance;
                    }
                }

        }
        }


        public frmMain()
        {
            InitializeComponent();
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
            currChosenFigureType = null;
            Invalidate();
        }

        private Random rnd = new Random();

        private Color getRandomColor()
        {
            return Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }

        private void btnDrawAll_Click(object sender, EventArgs e)
        {
            currChosenFigureType = null;
            lblChosenFigure.Text = "Chosen: ";

            //Create the paint area 
            Rectangle drawArea = new Rectangle(panel1.Width + 20, 20, this.Width - panel1.Width - 40, this.Height - 50);

            figureList.Clear();
            CreationParams par = new CreationParams();

            //Random placed 6 figures
            foreach (Creator creator in creators.Values)
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

            if (currChosenFigureType != null && creators[currChosenFigureType] != null)
            {
                figureList.Add(creators[currChosenFigureType].createFigure(par));
            }

            Invalidate();
        }

    }
}
