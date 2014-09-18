using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Protobuf.Components;

namespace Protobuf
{
    public class Protobuf_Codec
    {
        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] Encode(Location msg)
        {
            return null;
        }
        public static Stream WriteTo(Location msg)
        {
            return null;
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Location Decode(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            return ParseForm(ms);
        }
        public static Location ParseForm(Stream stream)
        {
           
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            //for (int i = 0; i < data.Length; i++)
            //{
            //    if (data[i] > 127)
            //    {
            //        data[i] -= byte.MaxValue - 1;
            //    }
            //}

            Location loc = Location.ParseFrom(data);
            return loc;
        }

    }
}
