using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
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
            db.RegisterDog(User.ActiveUsers[0].UserID ,Dogname, Breed, Age, Gender, Bio, IFilePicker.bytearray);
            await Shell.Current.GoToAsync("..");

           // IFilePicker.bytearray.GetLength(0);
        }

        private void PhotoPicker_Clicked(object sender, EventArgs e)
        {
            IFilePicker.PickAndShow(PickOptions.Images);
           
           // DogImage = IFilePicker.GetPhoto();
           
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