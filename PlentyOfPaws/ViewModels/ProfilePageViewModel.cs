using PlentyOfPaws.Models;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace PlentyOfPaws.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
       // Profile page view model, view models are needed in some places for commands that can not be executed within xaml.cs pages. 
        public ProfilePageViewModel()
        {
            Title = "About";
         
            // handles app restarts 
            RestartCommand = new Command(() =>
            {
                Shell.Current.GoToAsync("//login");
            });

            // Allows users to logout. 
            LogoutCommand = new Command(() =>
            {
                Shell.Current.GoToAsync("//login");
            });
        }

            
         // Gets the user name,email and location from the list of active users, which will always only be 1 users
         public string Username { get; } = User.ActiveUsers[0].UserName;
         public string Email { get; } = User.ActiveUsers[0].UserEmail;    
         public string Location { get; } = User.ActiveUsers[0].UserLocation;

         // Gets the dogs name and photo from the list of active users dogs, which will always only be 1 users 
         public string DogName { get; } = Dog.UsersDog[0].DogName;

         // With dog photo as it is stored as a stream it needs to be converted into a blob then though a new memory stream, finally into a image source in order to be displayed to user.      
         public ImageSource DogPhoto { get;  } = ImageSource.FromStream(() => new MemoryStream(ByteArrayConversion.converttoblob(Dog.UsersDog[0].DogImage)));  


        // Commands used to control application flow. 
        public ICommand OpenWebCommand { get; }

        public ICommand RestartCommand { get; }

        public ICommand LogoutCommand { get; }

        public ICommand BackCommand { get; }
    }
}