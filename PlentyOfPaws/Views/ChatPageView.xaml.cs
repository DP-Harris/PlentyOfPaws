using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatPageView : ContentPage
    {
        // Allows access to database methods. 
        DataBaseConnection Database = new DataBaseConnection();

        // Creates a list that is can be binded to XAML binding. 
        public static ObservableCollection<User> _User = new ObservableCollection<User>();

        // Temp list of users is need here to stop the ObservableCollection of users been directly added to or removed as xamarin will error if this occurs after loading
        // and loading is done up page instantiation.
        private List<User> Tempusers = new List<User>();

        // Initializes page and calls all needed methods to find appropriate users name and email to display matches to users on the chat page. 
        public ChatPageView()
        {
            InitializeComponent();
            Database.GetChatMatchs();
            GetUsersNameAndEmail(GetUsersID());

            // binding = this lets the data we bind in the view page to ObervableCollection of UserProfiles. 
            BindingContext = this;
        }

        // Makes the List of users we populate visible on the view page. 
        public ObservableCollection<User> UserProfiles
        {
            get => _User;
            set
            {
                _User = value;
            }
        }

        // Finds the ID of all users in the chat static lists, if a user is present within the list a match has already occurred 
        // we can use this information to find the user data we wish to display. 
        private List<int> GetUsersID()
        {
            List<int> MatchUserIDs = new List<int>();

            foreach (var User in Chat.UserChats)
            {
                MatchUserIDs.Add(User.UserIDB);
            }
           return MatchUserIDs;
        }

        // Using data from GetUserID() we can find the emails and names of users we have matched with and add them to the list of users before making
        // this list  Observable. 
        private void GetUsersNameAndEmail(List<int> UsersID)
        {
            for (int i = 0; i < UsersID.Count; i++)
            {
                Tempusers = Database.GetUserNameAndEmail(UsersID[i]);

                foreach (var u in Tempusers)
                {
                    _User.Add(new User() { UserName = u.UserName, UserEmail = u.UserEmail });
                }
            }
        }
    }
}