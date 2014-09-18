using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "38.057843";
            byte[] data = Encoding.UTF8.GetBytes(str);
            string p = "";
            foreach (byte item in data)
            {
                p += item+" ";
            }
            Console.WriteLine(p);
            MemoryStream ms = new MemoryStream(data);
            string q = "";
            while (ms.Position < ms.Length)
            {
                q += ms.ReadByte() + " ";
            }
            Console.WriteLine(q);
            Console.ReadKey();
        }
    }
}
