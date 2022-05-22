using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlentyOfPaws.Models
{
    public class ByteArrayConversion
    {
        // Used when converting streams to byte arrays; 
        // When storing user image they have to be stored in a non-blob format
        // method allows to convert back to a blob format before passing into a imagesource object for displaying. 
        public static byte[] converttoblob(Stream stream)
        {
            var bytearray = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytearray = ms.ToArray();

                // Clears memory stream after each use to prevent pixels been distorted by leftover data. 
                ms.Dispose();
            }

            return bytearray;
        }
    }
}
