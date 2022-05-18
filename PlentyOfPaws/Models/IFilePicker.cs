using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlentyOfPaws.Models
{
    public static class IFilePicker
    {
        public static async void PickMultipleFiles()
        {
            var file = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick Images"
            });

            System.IO.File.ReadAllBytes(file.ToString());
           // var ImageData = file;
         //   Console.WriteLine(file.FullPath);
            //var pickResult = await FilePicker.PickMultipleAsync(new PickOptions
            //{
            //    FileTypes = FilePickerFileType.Images,
            //    PickerTitle = "Pick Images"
            //});

            //if (pickResult != null)
            //{
            //    var imagelist = new List<ImageSource>();

            //    foreach (var item in pickResult)
            //    {
            //        var stream = await item.OpenReadAsync();

            //        imagelist.Add(ImageSource.FromStream(() => stream));
            //        Console.WriteLine(imagelist.Count); ;

        }

        public static async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    var Text = $"File Name: {result.FileName}";
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        Console.WriteLine(stream);
                        var image = ImageSource.FromStream(() => stream);
                    }
                }
              
                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
    }
  }
    

