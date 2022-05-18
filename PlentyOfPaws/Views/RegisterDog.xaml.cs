using PlentyOfPaws.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterDog : ContentPage
    {
        private string Dogname;
        private string Breed;
        private int Age;
        private string Gender;
        private string Bio; 

        public RegisterDog()
        {
            InitializeComponent();
        }

        private void RegButton_Clicked(object sender, EventArgs e)
        {

        }

        private void PhotoPicker_Clicked(object sender, EventArgs e)
        {
            //  IFilePicker.PickMultipleFiles();
            IFilePicker.PickAndShow(PickOptions.Images);
        }
    }
}