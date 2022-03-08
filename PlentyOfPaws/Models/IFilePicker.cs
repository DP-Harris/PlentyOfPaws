using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlentyOfPaws.Models
{
    public class IFilePicker
    {
        public async void PickMultipleFiles()
        {
            var pickResult = await FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Pick Images"
            });

            if (pickResult != null)
            {
                var imagelist = new List<ImageSource>();

                foreach (var item in pickResult)
                {
                    var stream = await item.OpenReadAsync();

                    imagelist.Add(ImageSource.FromStream(() => stream));
                    Console.WriteLine(imagelist.Count); ;
                    
                }
            }
        }
    }
}

