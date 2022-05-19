﻿using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterDog : ContentPage
    {
        DataBaseConnection db = new DataBaseConnection();
        private string Dogname;
        private string Breed;
        private int Age;
        private string Gender;
        private string Bio;
        private byte[] DogImage;

        public RegisterDog()
        {
            InitializeComponent();
        }

        private async void RegButton_Clicked(object sender, EventArgs e)
        {
            db.RegisterDog(User.ActiveUsers[0].UserID ,Dogname, Breed, Age, Gender, Bio, DogImage);
            await Shell.Current.GoToAsync("..");
        }

        private void PhotoPicker_Clicked(object sender, EventArgs e)
        {
            //  IFilePicker.PickMultipleFiles();
            // var ImageStream = IFilePicker.PickAndShow(PickOptions.Images);
            // var g = IFilePicker.GetPhotoAsByteArray(ImageStream);
          //  DogImage = IFilePicker.GetImageStreamAsBytes();
        }

        private void DogsName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dogname = e.NewTextValue;
        }

        private void DogsBreed_TextChanged(object sender, TextChangedEventArgs e)
        {
            Breed = e.NewTextValue;
        }

        private void DogsAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            Age = int.Parse(e.NewTextValue);
        }

        private void DogsGender_TextChanged(object sender, TextChangedEventArgs e)
        {
            Gender = e.NewTextValue;
        }

        private void DogBio_TextChanged(object sender, TextChangedEventArgs e)
        {
            Bio = e.NewTextValue;
        }
    }
}