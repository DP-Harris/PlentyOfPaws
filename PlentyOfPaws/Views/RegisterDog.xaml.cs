using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // Dog Registration performs all needed back end methods and data manipulation needed for registering dogs to the database. 
    public partial class RegisterDog : ContentPage
    {
        // Creates a database connection object to gain access to its methods. 
        DataBaseConnection Database = new DataBaseConnection();

        // Private class variables used to assign user entered data 
        // into format for dog registration. 
        private string Dogname;
        private string Breed;
        private int Age;
        private string Gender;
        private string Bio;

        // Temp to store age before we parse to int. 
        private string tempage;
       
        // Makes page usable within the application by instantiating it as a object.
        public RegisterDog()
        {
            InitializeComponent();
        }

        // On register button all variables should be set and used to send the dogs information to 
        // the database and associates the dog with the logged in current user. 
        private async void RegButton_Clicked(object sender, EventArgs e)
        {
            // If gender is wrong hits a user prompt to re enter the gender. 
            if (CheckGender() == false || ConvertAgeToInt() == false)
            {
                await Application.Current.MainPage.DisplayAlert("Incorrect Details", "You have entered incorrect Gender or wrong type for age, numbers only please", "Re Type");
            }
            else
            {
                Database.RegisterDog(User.ActiveUsers[0].UserID, Dogname, Breed, Age, Gender, Bio, IFilePicker.bytearray);
                await Shell.Current.GoToAsync("..");
            }
        }

        // Photo picker opens users files and enable user to select a photo from there phone.
        // This method picks the photo and turns the file into a file stream which is then converted to a byte[] for blob storage. 
        private void PhotoPicker_Clicked(object sender, EventArgs e)
        {
            IFilePicker.PickAndShow(PickOptions.Images);              
        }

        // Sets dogs name to the text changed event, from dogsname entry on view page.
        private void DogsName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dogname = e.NewTextValue;
        }

        // Sets dogs breed to the new text changed event. 
        private void DogsBreed_TextChanged(object sender, TextChangedEventArgs e)
        {
            Breed = e.NewTextValue;
        }

        // Sets dogs ages from the text changed event. 
        // Needs validation prior to assignments as errors occur when other then a int is entered. 
        private void DogsAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            tempage = e.NewTextValue;
        }

        // Sets Dogs bio to text entered in the dogsgender text entry field. 
        // Needs further validation adding so only male or female can be entered. 
        private void DogsGender_TextChanged(object sender, TextChangedEventArgs e)
        {
             Gender = e.NewTextValue.ToLower();
        }

        // Text Changed event handler to
        // Set dogs bio information to text entered inside the dog bio text. 
        private void DogBio_TextChanged(object sender, TextChangedEventArgs e)
        {
            Bio = e.NewTextValue;
        }

        // Checks if the gender entered is in the correct form. 
        private bool CheckGender()
        {
            if (Gender.ToLower() == "Female".ToLower())
            {
                return true;
            }
            else if (Gender.ToLower() == "Male".ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Checks all chars are numbers within the given string. 
        private bool ConvertAgeToInt()
        {
            if (tempage.All(char.IsDigit))
            {
                Age = int.Parse(tempage);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}