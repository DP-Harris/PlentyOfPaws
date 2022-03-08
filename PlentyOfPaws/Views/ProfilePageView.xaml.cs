using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlentyOfPaws.Models;
using Xamarin.Essentials;


namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePageView : ContentPage
    {
        IFilePicker file = new IFilePicker();

        public ProfilePageView()
        {
            InitializeComponent();
        }

        private void Image_Button_Clicked(object sender, EventArgs e)
        {
            file.PickMultipleFiles();
        }
    }
}