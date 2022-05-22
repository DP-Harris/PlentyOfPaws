using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlentyOfPaws.Models
{
    public class ByteArrayConverion
    {
        public static byte[] converttoblob(Stream stream)
        {
            var bytearray = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytearray = ms.ToArray();
                ms.Dispose();
            }

            return bytearray;
        }
    }
}
