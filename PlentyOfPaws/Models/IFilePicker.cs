using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace PlentyOfPaws.Models
{
    public static class IFilePicker
    {
        // Creates a byte array to populate thought out the method below. 
        // Byte array is static as returning the byte array though external methods was causing loss of data and image distortion. 
        public static byte[] bytearray;
        
        // Opens user files on device and allows to pick a photo which is converted into a blob array. 
        public static async void PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    {
                        var stream = await result.OpenReadAsync();
                        // Console.WriteLine(stream);
                        // var image = ImageSource.FromStream(() => stream);
                        // Convert to BLOB a.k.a Byte Array
                        // Use memorystream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);
                            bytearray = ms.ToArray();
                            ms.Dispose();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}




   

   

   
    

