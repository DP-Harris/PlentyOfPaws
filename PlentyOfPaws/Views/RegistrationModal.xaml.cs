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
            Console.WriteLine("Registration successful");
            db.RegisterUser(NewUser.UserName, NewUser.UserEmail, NewUser.UserPassword, NewUser.UserLocation);
        }

        private void userEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewUser.UserEmail = e.NewTextValue;
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewUser.UserName = e.NewTextValue;
        }

        private void userPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewUser.UserPassword = e.NewTextValue;
        }

        private void LocationAdded_TextChanged(object sender, TextChangedEventArgs e)
        {
           NewUser.UserLocation = e.NewTextValue;
        }

        private async void TermsandConditionsLabelClicke(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}