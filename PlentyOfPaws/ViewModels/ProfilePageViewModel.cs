using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlentyOfPaws.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        public ProfilePageViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
            RestartCommand = new Command(() =>
            {
                Shell.Current.GoToAsync("//login");
            });

            LogoutCommand = new Command(() =>
            {
                Shell.Current.GoToAsync("//login");
            });

        }

        public ICommand OpenWebCommand { get; }

        public ICommand RestartCommand { get; }

        public ICommand LogoutCommand { get; }

        public ICommand BackCommand { get; }
    }
}