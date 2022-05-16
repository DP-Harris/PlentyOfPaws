using PlentyOfPaws.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDog : ContentView
    {

        IFilePicker file = new IFilePicker();

        public AddDog()
        {
            InitializeComponent();
        }

        private void Image_Button_Clicked(object sender, EventArgs e)
        {
            file.PickMultipleFiles();
        }
    }
}