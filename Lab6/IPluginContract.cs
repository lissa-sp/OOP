using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IPluginContract
    {
        string Name { get; }

        byte[] Compress(byte[] initBytes);
        byte[] Decompress(byte[] comprBytes);

        void ShowSettings();
    }
}
