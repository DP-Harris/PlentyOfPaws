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
        public Command Command { get; }
        public ProfilePageView()
        {
            InitializeComponent();
    

        }

        private async void GoToAddDogPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/Dogregistration");
           
        }
        
    }
}