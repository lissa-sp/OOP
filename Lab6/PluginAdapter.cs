using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    internal class PluginAdapter : IPluginContract
    {
        public string Name { get; }
        private Type pluginType;
        private object plugin;
      
        public PluginAdapter(Type type)
        {
            MethodInfo encrypt = type.GetMethod("Encrypt");
            MethodInfo decrypt = type.GetMethod("Decrypt");

            if (encrypt != null && decrypt != null)
            {
                this.plugin = Activator.CreateInstance(type);
                this.pluginType = type;
                this.Name = "Cypher algorithm";
            }
        }

        public byte[] Compress(byte[] initBytes)
        {
            if (plugin == null) 
                return initBytes;

            MethodInfo encrypt = pluginType.GetMethod("Encrypt");
            if (encrypt != null)
                return (byte[])encrypt.Invoke(plugin, new object[] { initBytes });
 
            return null;
        }

        public byte[] Decompress(byte[] compBytes)
        {
            if (plugin == null)
                return compBytes;

            MethodInfo decrypt = pluginType.GetMethod("Decrypt");
            if (decrypt != null)
                return (byte[])decrypt.Invoke(plugin, new object[] { compBytes });

            return null;
        }

        public void ShowSettings()
        {
            PropertyInfo passwordProperty = pluginType.GetProperty("Password");

            string currPassword = "1234567";
            if (passwordProperty != null)
                currPassword = (string)passwordProperty.GetValue(plugin);

            Form settingsForm = new Form();
            settingsForm.Text = "Cypher/decypher settings";
            settingsForm.Size = new Size(200, 200);

            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(10, 10);
            lblPassword.Size = new Size(80, 25);

            TextBox txtPassword = new TextBox();
            txtPassword.Text = currPassword;
            txtPassword.Location = new Point(10, 50);
            txtPassword.Size = new Size(100, 25);

            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(10, 110);
            btnSave.Click += (s, e) =>
            {
                currPassword = txtPassword.Text;
                if (passwordProperty != null)
                    passwordProperty.SetValue(plugin, currPassword);

                settingsForm.DialogResult = DialogResult.OK;
                settingsForm.Close();
            };

            settingsForm.Controls.Add(lblPassword);
            settingsForm.Controls.Add(txtPassword);
            settingsForm.Controls.Add(btnSave);

            settingsForm.ShowDialog();
        }

        public bool IsValid() => plugin != null;
    }
}
