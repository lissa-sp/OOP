using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeflatePlugin
{
    public class SettingsWindow : Form
    {
        private ComboBox cbCompressionLevels;

        public int compressionLevel { get; private set; }

        public SettingsWindow(int compLvl)
        {
            cbCompressionLevels = new ComboBox();
            cbCompressionLevels.Items.AddRange(new object[]{0, 1, 2});
            cbCompressionLevels.Location = new Point(10, 50);
            

            Controls.Add(cbCompressionLevels);

            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(10, 110);
            btnSave.Click += (s, e) =>
            {
                compressionLevel = (int)cbCompressionLevels.SelectedItem;
                DialogResult = DialogResult.OK;
                Close();
            };

            Controls.Add(btnSave);

            Label lbl = new Label();
            lbl.Text = "Level of compression";
            lbl.Location = new Point(10, 10);
            lbl.Size = new Size(100, 50);

            Controls.Add(lbl);

            this.Size = new Size(200, 200);
            this.Text = "Plugin deflate settings";

        }
    }
}
