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
    public partial class frmMain : Form, IObserver
    {
        private FigureList figureList = null;
        private string chosenFigure;
        Dictionary<Type, Creator> creators = new Dictionary<Type, Creator>();
        Dictionary<Type, Drawer> drawers = new Dictionary<Type, Drawer>();
        Type currChosenFigureType = null;

        Dictionary<string, IPluginContract> compressors = new Dictionary<string, IPluginContract>();
        Dictionary<string, Type> figureTypes = new Dictionary<string, Type>();
        IPluginContract activeCompressor = null;

        Dictionary<string, string> checkingPlugins = new Dictionary<string, string>
        {
            { "RhombPlugin.dll", "9C9071566A3CFC9FB2417B67650EC51356ADC3F988D0856ADCD1DDA721482349"},
            { "TrianglePlugin.dll", "43E2689B5A788BF4A01FF5832C7A9CB8FFBF19A1D93B1F2A1EAFC943E99C802F" }
        };

        public void Update()
        {
            Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            loadInternalFigures();
            loadPluginFigures();

            loadFunctionalPlugins();
            
            //Adding plugins to combobox in ui
            foreach (string compressorName in compressors.Keys)
            {
                cbChoosePlugin.Items.Add(compressorName);
            }

            //Create buttons for each loaded figure
            createButtons();

            figureList = new FigureList(drawers);
            figureList.Subscribe(this);

            this.Paint += Form1_Paint;
        }

        private void registerFigureType(Type figureType)
        {
            string typeName = figureType.Name;  
            if (!figureTypes.ContainsKey(typeName))
            {
                figureTypes[typeName] = figureType;
            }
        }

        private void loadFunctionalPlugins()
        {
            string pathToPluginFolder = Path.Combine(Application.StartupPath, "Processors");

            if (!Directory.Exists(pathToPluginFolder))
            {
                Directory.CreateDirectory(pathToPluginFolder);
                MessageBox.Show(
                   $"Plugins should be in the directory named Processors. Path: {pathToPluginFolder}",
                   "Message",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }

            string[] dllFiles = Directory.GetFiles(pathToPluginFolder, "*.dll");

            foreach (string dllFile in dllFiles)
            {
                Assembly asm = Assembly.LoadFrom(dllFile);

                Type[] types = asm.GetTypes();

                foreach (Type type in types)
                {
                    if (typeof(IPluginContract).IsAssignableFrom(type))
                    {
                        IPluginContract plugin = (IPluginContract)Activator.CreateInstance(type);
                        compressors[plugin.Name] = plugin;
                    }
                }

            }

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

        //Figures serialization
        private byte[] SerializeFigures()
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(output))
                {
                    List<Figure> allFigures = figureList.GetAllFigures();

                    writer.Write(allFigures.Count);

                    foreach (Figure currFigure in allFigures)
                    {
                        writer.Write(currFigure.GetType().Name);

                        CreationParams figureParams = currFigure.Params;
                        writer.Write(figureParams.x0);
                        writer.Write(figureParams.y0);
                        writer.Write(figureParams.color.ToArgb());
                        writer.Write(figureParams.radius);
                        writer.Write(figureParams.width);
                        writer.Write(figureParams.height);
                        writer.Write(figureParams.x1);
                        writer.Write(figureParams.y1);

                    }
                    return output.ToArray();
                }
            }

        }

        //Figures deserialization
        private void DeserializeFigures(byte[] data)
        {
            using (MemoryStream input = new MemoryStream(data))
            {
                using (BinaryReader reader = new BinaryReader(input))
                {
                    int amountOfFigures = reader.ReadInt32();
                    
                    for (int i = 0; i < amountOfFigures; i++)
                    {
                        //Read the type of figure
                        string strType = reader.ReadString();
                        Type figureType = figureTypes[strType];

                        //Read parametrs
                        CreationParams figureParams = new CreationParams();
                        figureParams.x0 = reader.ReadInt32();
                        figureParams.y0 = reader.ReadInt32();
                        figureParams.color = Color.FromArgb(reader.ReadInt32());
                        figureParams.radius = reader.ReadInt32();
                        figureParams.width = reader.ReadInt32();
                        figureParams.height = reader.ReadInt32();
                        figureParams.x1 = reader.ReadInt32();
                        figureParams.y1 = reader.ReadInt32();

                        Figure currFigure = creators[figureType].createFigure(figureParams);
                        figureList.Add(currFigure);
                    }
                    
                }
            }
        }

        private void loadInternalFigures()
        {
            creators[typeof(Circle)] = new CircleCreator();
            drawers[typeof(Circle)] = new CircleDrawer();
            registerFigureType(typeof(Circle));

            creators[typeof(Ellipse)] = new EllipseCreator();
            drawers[typeof(Ellipse)] = new EllipseDrawer();
            registerFigureType(typeof(Ellipse));

            creators[typeof(Rect)] = new RectCreator();
            drawers[typeof(Rect)] = new RectDrawer();
            registerFigureType(typeof(Rect));

            creators[typeof(Line)] = new LineCreator();
            drawers[typeof(Line)] = new LineDrawer();
            registerFigureType(typeof(Line));
        }

        private void loadPluginFigures()
        {
            string pathToPluginsFolder = Path.Combine(Application.StartupPath, "Plugins");   

            if (!Directory.Exists(pathToPluginsFolder))
            {
                Directory.CreateDirectory(pathToPluginsFolder);
                MessageBox.Show(
                    $"Plugins should be in the directory named Plugins. Path: {pathToPluginsFolder}",
                    "Message",
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
                        registerFigureType(typeOfFigure);
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
            

            //Random placed 6 figures
            foreach (Creator creator in creators.Values)
            {
                CreationParams par = new CreationParams();
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

        
        }

        private void cbChoosePlugin_SelectedIndexChanged(object sender, EventArgs e)
        {
            activeCompressor = compressors[cbChoosePlugin.SelectedItem.ToString()];
        }

        private void btnPluginSettings_Click(object sender, EventArgs e)
        {
            if (activeCompressor == null)
            {
                MessageBox.Show(
                   $"Choose a compression algorithm!",
                   "Message",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
            }
            else
            {
                activeCompressor.ShowSettings();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (activeCompressor == null)
            {
                MessageBox.Show(
                   $"Choose a compression algorithm!",
                   "Message",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save figures";
            saveDialog.Filter = "Compressed files|*.dat|All files|*.*";
            saveDialog.DefaultExt = "dat";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    byte[] initBytes = SerializeFigures();

                    byte[] compressedBytes = activeCompressor.Compress(initBytes);

                    using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.Create))
                    {
                        using (BinaryWriter writer = new BinaryWriter(fs))
                        {
                            //Saving the name of compressing algorithm for right decompression
                            writer.Write(activeCompressor.Name);
                            writer.Write(compressedBytes.Length);
                            writer.Write(compressedBytes);

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving: {ex.Message}", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Load figures";
            fileDialog.Filter = "Compressed files|*.dat|All files|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Open))
                    {
                        using (BinaryReader reader = new BinaryReader(fs))
                        {
                            string compressorAlgName = reader.ReadString();
                            IPluginContract compressor = compressors[compressorAlgName];

                            int lengthOfData = reader.ReadInt32();
                            byte[] data = reader.ReadBytes(lengthOfData);

                            byte[] initBytes = compressor.Decompress(data);

                            DeserializeFigures(initBytes);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving: {ex.Message}", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
