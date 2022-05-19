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
        private static byte[] bytearray;
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
                // The user canceled or something went wrong
            }



        }

        public static byte[] GetPhoto()
        {
            return bytearray;
        }
    }
}


   

   

   
    

