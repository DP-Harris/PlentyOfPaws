using MLToolkit.Forms.SwipeCardView.Core;
using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCardView : ContentPage
    {
        // Allows access to database methods. 
        DataBaseConnection db = new DataBaseConnection();

        // Creates a list that is can be binded to XAML binding. 
        public ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();

        public static List<Dog> dogs = new List<Dog>();

        // Initiates view for this page.
        public MainCardView()
        {
            InitializeComponent();

            loadAllDogs();
            BindingContext = this;
        }


        // Lets the dogs in the  ObservableCollectio to a dog profiles that will be used on the display cards in the MainCardView.XAML swipe card model. 
        public ObservableCollection<Dog> DogProfiles
        {
            get => _dogs;
            set
            {
                _dogs = value;
            }
        }

       

        // Gets dogs creates a new list of dogs
        // Populates that dog list from the database of tbl_dog, finds the users dogs gender and removes all the same gender types from the collection.
        // after we have the opposite gender creates new Observable objects of the remaining dogs setting properties for data binding in the XAML page.
        private void GetDogs()
        {
            
            dogs = db.GetAllDogs();

            string userdogsGender = getUsersDogGender(dogs).ToLower();

            foreach (Dog dog in dogs)
            {        
                if (dog.Gender.ToLower() != userdogsGender)
                {
                    _dogs.Add(new Dog() { DogName = dog.DogName, Age = dog.Age, DogID = dog.DogID, BreedOne = dog.BreedOne, Photo = ImageSource.FromStream(() => new MemoryStream(converttoblob(dog.DogImage))) });
                } 
            }    
        }


      
        // If user has no dogs he cant be matched so no dogs will be will
        // will be redirected to the registerDog page to create a dog. 
        private async void loadAllDogs()
        {
            if (db.UserHasDog() == true)
            {
                GetDogs();
            }
            else
            {
                await Shell.Current.GoToAsync("RegisterDog");
            }
        }

        // Finds the gender of the logged in users dog.
        private string getUsersDogGender(List<Dog> dogs)
        {
            for (int i = 0; i < dogs.Count(); i++)
            {
                if (dogs[i].UserID == User.ActiveUsers[0].UserID)
                {
                    return dogs[i].Gender;
                }
            }

            return null;
        }

        // Converts a data stream into a byte[] to be sent to a image source so photos from blob storage can be displayed. 
        private byte[] converttoblob(Stream stream)
        {
            var bytearray = new byte[stream.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                bytearray = ms.ToArray();
                ms.Dispose();
            }

            return bytearray;
        }

        private int FindCurrentDogID(List<Dog> dogs)
        {
            for (int i = 0; i < dogs.Count(); i++)
            {
                if (dogs[i].UserID == User.ActiveUsers[0].UserID)
                {
                    return dogs[i].DogID;
                }      
            }

            return 0;
        }

        private Dog _topItem;

        public Dog TopItem
        {
            get => _topItem;
            set
            {
                _topItem = value;
            //    RaisePropertyChanged();
            }
        }

        private int i;

        // On no click button will swipe card away and populate matching criteria. 
        private void nopeButton_Clicked(object sender, EventArgs e)
        {
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left);
            Console.WriteLine("Rejected");

            // Send Reject query here. 
        }

        
        // On like button clicked will swipe away card in the correct direction and populate matching criteria
        private void likeButton_Clicked(object sender, EventArgs e)
        {
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
            Console.WriteLine("Matched");

            //  var dog = TopItem.DogID;
            db.LogRightSwipes(User.ActiveUsers[0].UserID, FindCurrentDogID(dogs), TopItem.DogID);

        }
    }
}