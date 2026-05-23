using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CypherPlugin
{
    public class CypherPlugin
    {
        public string Password { get; set; } = "1234567";

        public byte[] Encrypt(byte[] data)
        {
            if (data == null) return null;
            byte[] result = new byte[data.Length];
            byte[] keyBytes = Encoding.UTF8.GetBytes(Password);

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(data[i] ^ keyBytes[i % keyBytes.Length]);
            }
            return result;
        }

        public byte[] Decrypt(byte[] encryptedData)
        {
            return Encrypt(encryptedData);
        }


    }
}
