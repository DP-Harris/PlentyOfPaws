using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PlentyOfPaws.Models;
using Xamarin.Essentials;
using System.Linq;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePageView : ContentPage
    {
        public Command Command { get; }
        public ProfilePageView()
        {
            InitializeComponent();
            ChangeContent();
        }

        // Sends users to the Register dog page upon clicking the add dog button. 
        private async void AddDogPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("RegisterDog");
           
        }

      
        // If dog exists we can hide the add dog button else we can show the dogs information. 
        private void ChangeContent()
        {
            if (DogExists() == false)
            {
                RegisterDog.IsVisible = true;
            }
            else
            {
                RegisterDog.IsVisible = false;
            }
        }

        // Finds if the current user has already registered a dog. 
        public bool DogExists()
        {
            if (Dog.UsersDog.Count() < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}