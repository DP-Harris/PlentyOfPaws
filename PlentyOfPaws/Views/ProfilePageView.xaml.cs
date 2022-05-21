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

        // Sends users to the Register dog page upon clicking the add dog button. 
        private async void AddDogPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterDog");
           
        }        
    }
}