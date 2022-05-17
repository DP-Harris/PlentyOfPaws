using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws.Views
{
    public partial class LoginPage : ContentPage
    {
        DataBaseConnection db = new DataBaseConnection();
        private string email;
        private string password;

        public LoginPage()
        {
            InitializeComponent();
        }

        // Once user enters email state will be added to email var
        private void EmailEntered(object sender, TextChangedEventArgs e)
        {
            // User email .
            email = e.NewTextValue;
        }

        // once user enters password its final state will be added to the password var 
        private void PasswordEntered(object sender, TextChangedEventArgs e)
        {
            // User password .
            password = e.NewTextValue;
        }

        // Send user name and password and email to database 
        // Display error and redirect to login if invalid 
        // If valid send to main

        private async void Login(object sender, EventArgs e)
        {

            // await Shell.Current.GoToAsync("//main");
            if (db.ValidateUser(email, password) == true)
            {
                db.GetUserDetails(email, password);
                await Shell.Current.GoToAsync("//main");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login", "You have entered incorrect details", "TRY AGAIN");
            }


        }

        private async void RegisterGesture_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}
