using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlentyOfPaws.Models;
using Xamarin.Essentials;
using PlentyOfPaws.Services;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationModal : ContentPage
    {
        User NewUser = new User();
        DataBaseConnection db = new DataBaseConnection();
        Location Location = new Location();
        string FirstPass;
        string SecoundPass;

        public RegistrationModal()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login");
        }

        private async void Register_User_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login");
            AssignPass();
            Console.WriteLine("Registration successful");
            Location = await Geolocation.GetLocationAsync();
            NewUser.UserLatitude = Location.Latitude.ToString();
            NewUser.UserLongitude = Location.Longitude.ToString();
            NewUser.AddtoList(NewUser);
            NewUser.PrintUserInfo(NewUser);
            db.run();
        }

        private void userEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Validate email.
            NewUser.UserEmail = e.NewTextValue;
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewUser.UserName = e.NewTextValue;
        }

        private void userPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
           FirstPass = e.NewTextValue;
        }

        private void confirmuserPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
           SecoundPass = e.NewTextValue;
        }

        private void AssignPass()
        {
            if (FirstPass == SecoundPass)
            {
                NewUser.UserPassword = FirstPass;
            }
        }

        private async void TermsandConditionsLabelClicke(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login");
        }
    }
}