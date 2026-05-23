using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace DeflatePlugin
{
    public class DeflatePlugin : IPluginContract
    {
        public int compressionLevel { get; private set; } = 0;
        public string Name { get { return "Deflate"; } }

        public byte[] Compress(byte[] initBytes)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (DeflateStream deflate = new DeflateStream(output, (CompressionLevel)compressionLevel))
                {
                    deflate.Write(initBytes, 0, initBytes.Length);
                    
                }
                return output.ToArray();
            }
            
        }

        public byte[] Decompress(byte[] compressedBytes)
        {
            using (MemoryStream input = new MemoryStream(compressedBytes))
            using (DeflateStream deflate = new DeflateStream(input, CompressionMode.Decompress))
            using (MemoryStream output = new MemoryStream())
            {
                deflate.CopyTo(output);
                return output.ToArray();
            }
        }

        public void ShowSettings()
        {
            SettingsWindow settingsWindow = new SettingsWindow(compressionLevel);

            if (settingsWindow.ShowDialog() == DialogResult.OK)
            {
                compressionLevel = settingsWindow.compressionLevel;

            }
        }
    }
}
