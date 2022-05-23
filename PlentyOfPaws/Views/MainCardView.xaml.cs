using MLToolkit.Forms.SwipeCardView.Core;
using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // MainCard View is the backend datasorting and methods needed to present data inside the MainCardView.
    public partial class MainCardView : ContentPage
    {
        

        // Allows access to database methods. 
        DataBaseConnection db = new DataBaseConnection();

        // Creates a list that is can be binded to XAML binding. 
        public static ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();

        // Keeps track of dogs the current user wants to match with. 
        public static List<int> LikedDogs = new List<int>();

        // Finds out how many dogs we have to choose from. 
        private int numberofdogs;


        // List to hold dogs needed for information and filtering before been sent to display dog list.
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
            // Retrieves all Dogs inside the database.
            dogs = db.GetAllDogs();

            // Removes dogs of the same gender as users dog from the list.
            string userdogsGender = getUsersDogGender(dogs).ToLower();

            // Populates a ObservableCollection of dogs in order to display them dynamically in databinding. 
            foreach (Dog dog in dogs)
            {        
                if (dog.Gender.ToLower() != userdogsGender)
                {
                    numberofdogs++;
                    _dogs.Add(new Dog() { DogName = dog.DogName, Age = dog.Age, DogID = dog.DogID, BreedOne = dog.BreedOne, Photo = ImageSource.FromStream(() => new MemoryStream(ByteArrayConversion.converttoblob(dog.DogImage))) });
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


        // Setting dog as topitem in order to access it from the dynamic data binding in the MainCard View.
        private Dog _topItem;

        // Sets topcards = to value so we can access the data from the topcard(dog) objects for matching purposes. 
        public Dog TopItem
        {
            get => _topItem;
            set
            {
                _topItem = value;
            }
        }

        // Used to know how many times users have pressed both buttons. 
        int totalcount = 0;

        // Button handler for cards swiping not like and card moves to the left. 
        private void nopeButton_Clicked(object sender, EventArgs e)
        {
            // Swipe view will direct visible card to the left indicating no match wanted 
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left);
            totalcount++;

            // Further implementations would see a LogallLeftSwipes method here to stop dogs user dislikes been re shown to them. 
        }


        // On like button clicked will swipe away card in the correct direction and populate matching criteria
        private async void likeButton_Clicked(object sender, EventArgs e)
        {
            // SwipeView is moved as card shifts to the right. 
            // Keeps track of button presses
            // Adds liked dogs to a local list to log later. 
            await SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
            totalcount++;

            if (numberofdogs < 1)
            {
                likeButton.IsVisible = false;
                nopeButton.IsVisible = false;
                await Application.Current.MainPage.DisplayAlert("Out Of Dogs", "Go to chat page", "Come Back Later");
            }
            else
            {
                LikedDogs.Add(TopItem.DogID);
            }
           

            // If total count is == to number of dogs then user has swiped on all dogs.
            // Logs that dogs have been matched and lets like and not like buttons in invisible.
            if (totalcount == numberofdogs)
            {
                LogAllRightSwipes(LikedDogs);
                FindAllMatches(LikedDogs);
                likeButton.IsVisible = false;
                nopeButton.IsVisible = false;
            }
        }


        // At the end of the users shown dogs will log all dogs swiped right on into the database for matching. 
        private void LogAllRightSwipes(List<int> LikedDogs)
        {
            for (int i = 0; i < LikedDogs.Count(); i++)
            {
                db.LogRightSwipes(User.ActiveUsers[0].UserID, Dog.UsersDog[0].DogID, LikedDogs[i]);
            }
        }

        // Finds all match's between 2 dogs on the database and if they exists creates a chat row for them. 
        private void FindAllMatches(List<int> LikedDogs)
        {
            for (int i = 0; i < LikedDogs.Count(); i++)
            {
                int OtherUsersID = db.FindMatch(Dog.UsersDog[0].DogID, LikedDogs[i]);
                db.CreateChatMatchRow(OtherUsersID);
            }
        }

    }
}