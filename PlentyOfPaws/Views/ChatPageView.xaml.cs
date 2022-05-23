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
        DataBaseConnection db = new DataBaseConnection();

        // Creates a list that is can be binded to XAML binding. 
        public static ObservableCollection<User> _User = new ObservableCollection<User>();

        private List<User> Tempusers = new List<User>();

        public ChatPageView()
        {
            InitializeComponent();
            db.GetChatMatchs();
            GetUsersNameAndEmail(GetUsersID());
            BindingContext = this;
        }

        public ObservableCollection<User> UserProfiles
        {
            get => _User;
            set
            {
                _User = value;
            }
        }

        private List<int> GetUsersID()
        {
            List<int> MatchUserIDs = new List<int>();

            foreach (var User in Chat.UserChats)
            {
                MatchUserIDs.Add(User.UserIDB);
            }
           return MatchUserIDs;
        }

        private void GetUsersNameAndEmail(List<int> UsersID)
        {
            for (int i = 0; i < UsersID.Count; i++)
            {
                Tempusers = db.GetUserNameAndEmail(UsersID[i]);

                foreach (var u in Tempusers)
                {
                    _User.Add(new User() { UserName = u.UserName, UserEmail = u.UserEmail });
                }
            }
        }
    }
}