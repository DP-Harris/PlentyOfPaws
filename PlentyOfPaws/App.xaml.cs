using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlentyOfPaws.Services;
using PlentyOfPaws.Views;

namespace PlentyOfPaws
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected async override void OnStart()
        {
            DataBaseConnection Database = new DataBaseConnection();
            // Handle when your app starts
            if (Database.IsDatabaseConnection() == false)
            {   //If the database connection fails this lets the user know and exits the app.
                await Current.MainPage.DisplayAlert("Connection Error:", "Connection to the server has failed please try later.", "OK");
                System.Environment.Exit(0);
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
