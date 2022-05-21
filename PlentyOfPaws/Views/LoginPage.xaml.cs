using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws.Views
{
    public partial class LoginPage : ContentPage
    {   
        // Provides access to the database methods needed for user validation, information attachment and dog validation. 

        DataBaseConnection db = new DataBaseConnection();

        // Used to store entered information to check if user is registered or unregistered 
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

        // On Pressing login button will validate the email and password for the user 
        private async void Login(object sender, EventArgs e)
        {     
            // If email and password are valid will assign the users details from the database
            if (db.ValidateUser(email, password) == true)
            {
                db.GetUserDetails(email, password);

                // When users details are assigned will check to see if they have a dog registered
                // will direct to the main page and load dogs if so 
                // else will prompt them to the register a dog page. 

                if (db.UserHasDog() == true)
                {
                    await Shell.Current.GoToAsync("//main");
                }
                else
                {
                    await Shell.Current.GoToAsync("RegisterDog");
                }
                
            }

            // If validation has failed will pop up users with incorrect details and to try again. 
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
