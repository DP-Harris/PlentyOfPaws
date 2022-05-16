using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws.Views
{
    public partial class LoginPage : ContentPage
    {
        private string email;
        private string password;

        public LoginPage()
        {
            InitializeComponent();
        }

        // Once user enters email state will be added to to email var
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

        // Send username and password and email to databse 
        // Display error and rediect to login if invalid 
        // If valid send to main

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//main");
        }

        private async void RegisterGesture_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//login/registration");
        }

        //public bool ValidateLoginDetails(string EmailAddress, string Password)
        //{
        //    OpenConnection();
        //    //Setting up the Query command passing in the necessary parameters 
        //    string Query = "SELECT * FROM usertable WHERE emailAddress = @emailAddress AND password = @password";
        //    MySqlCommand Command = new MySqlCommand(Query, Connection);
        //    Command.Parameters.Add("@emailAddress", MySqlDbType.VarChar).Value = EmailAddress;
        //    Command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Password;

        //    MySqlDataReader DataReader = Command.ExecuteReader();
        //    bool Result = DataReader.HasRows;
        //    CloseConnection();
        //    return Result;
        //}
    }
}
