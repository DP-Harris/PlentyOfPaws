using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PlentyOfPaws.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

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

        /*   private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
           {
               await Shell.Current.GoToAsync("//login/registration");
           }*/

        /*    private async void Register_btn_Clicked(object sender, EventArgs e)
            {
                await Shell.Current.GoToAsync("//login/registration");
            }*/
    }
}
