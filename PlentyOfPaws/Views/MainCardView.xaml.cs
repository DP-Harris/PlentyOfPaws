using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlentyOfPaws.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCardView : ContentPage
    {
        public ObservableCollection<UserProfile> _profile = new ObservableCollection<UserProfile>();
        public MainCardView()
        {
            InitializeComponent();
            CardBinding();
            BindingContext = this;
        }

        public void CardBinding()
        {
            Profiles.Add(new UserProfile() { Name = "Anil", Age = 22, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "Greg", Age = 18, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "James", Age = 31, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "Andy", Age = 26, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "Carol", Age = 77, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "Sppon", Age = 32, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "CPU", Age = 18, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "James", Age = 62, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "Dan", Age = 42, Photo = "testdog.jpg" });
            Profiles.Add(new UserProfile() { Name = "MRHUM", Age = 34, Photo = "testdog.jpg" });

        }

        public ObservableCollection<UserProfile> Profiles
        {
            get => _profile;
            set
            {
                _profile = value;
            }
        }

        public class UserProfile
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Photo { get; set; }

        }

        private void nopeButton_Clicked(object sender, EventArgs e)
        {
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left);
        }

        private void likeButton_Clicked(object sender, EventArgs e)
        {
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
        }
    }
}