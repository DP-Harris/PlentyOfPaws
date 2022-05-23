using PlentyOfPaws.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlentyOfPaws.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        // Login command instantiate the user into the application. 
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        // Upon login the user will be directed to main page card, showing dog photo cards. if the user does not have a dog, they will be forced to create one first. 
        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(MainCardView)}");
        }
    }
}
