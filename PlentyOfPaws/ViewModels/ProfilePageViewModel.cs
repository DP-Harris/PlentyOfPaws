﻿using PlentyOfPaws.Models;
using System;
using System.IO;
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

            //AddDogCommand = new Command(() =>
            //{
            //   Shell.Current.GoToAsync("//adddog");
            //});

        }


         public string Username { get; } = User.ActiveUsers[0].UserName;

         public string Email { get; } = User.ActiveUsers[0].UserEmail;    
         public string Location { get; } = User.ActiveUsers[0].UserLocation;

         public string DogName { get; } = Dog.UsersDog[0].DogName;

         public ImageSource DogPhoto { get;  } = ImageSource.FromStream(() => new MemoryStream(ByteArrayConverion.converttoblob(Dog.UsersDog[0].DogImage)));  



        public ICommand OpenWebCommand { get; }

      //  public ICommand AddDogCommand { get; }

        public ICommand RestartCommand { get; }

        public ICommand LogoutCommand { get; }

        public ICommand BackCommand { get; }
    }
}