using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;
using System.Windows.Forms;

namespace GZipPlugin
{
    public class GZipPlugin : IPluginContract
    {
        public int compresionLevel { get; private set; } = 0;

        public string Name
        {
            get
            {
                return "GZip";
            }
        }

        public byte[] Compress(byte[] initBytes)
        {

            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream gZipStream = new GZipStream(output, (CompressionLevel)compresionLevel))
                {
                    gZipStream.Write(initBytes, 0, initBytes.Length);
                }
                return output.ToArray();
            }

        }

        public byte[] Decompress(byte[] compressedBytes)
        {
            using (MemoryStream input = new MemoryStream(compressedBytes))
            using (GZipStream brotliStream = new GZipStream(input, CompressionMode.Decompress))
            using (MemoryStream output = new MemoryStream())
            {
                brotliStream.CopyTo(output);
                return output.ToArray();
            }
        }

        public void ShowSettings()
        {
            SettingsWindow settingWindow = new SettingsWindow(compresionLevel);
            if (settingWindow.ShowDialog() == DialogResult.OK)
            {
                compresionLevel = settingWindow.compressionLevel;
            }
        }
    }
}
