using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlentyOfPaws.Models;
using Xamarin.Essentials;
using PlentyOfPaws.Services;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // RegistrationModal.xaml.cs is the backend methods need to for users to interact with the visual elements present in the RegistrationModel.xaml view page.
    public partial class RegistrationModal : ContentPage
    {
        // DataBaseConnection object to gain access to needed methods within the class.
        DataBaseConnection Database = new DataBaseConnection();

        // variables To hold entered user details to register a user.
        private string UserName;
        private string UserEmail;
        private string UserPassword;
        private string UserLocation;

        // Initializes the page for us within the application. 
        public RegistrationModal()
        {
            InitializeComponent();
        }

        // On button tapped will move user navigation to the login screen. 
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login");
        }

        // On pressing user details will be sent to the database and register as a new user
        // after registration users will be sent to the login screen. 
        private async void Register_User_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login");
            Database.RegisterUser(UserName, UserEmail, UserPassword, UserLocation);
            Console.WriteLine("Registration successful");
        }

        // e.NewTextValue is the users email we assign to UserEmail for registration. 
        private void userEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserEmail = e.NewTextValue;
        }

        // e.NewTextValue is the users name we assign to UserName for registration. 
        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserName = e.NewTextValue;
        }

        // e.NewTextValue is the users Password we assign to UserPassword for registration. 
        // Futher implementation for password checking and hashing to be implemented. 
        private void userPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserPassword = e.NewTextValue;
        }

        // e.NewTextValue is the users Location we assign to UserLocation for registration. 
        private void LocationAdded_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserLocation = e.NewTextValue; 
        }

        // Presenting terms and conditions currently routes to registration. 
        // Needs further implementation to show the Apps terms and conditions screen 
        private async void TermsandConditionsLabelClicke(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }
    }
}