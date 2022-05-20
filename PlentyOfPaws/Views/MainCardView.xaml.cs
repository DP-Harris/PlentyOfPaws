using PlentyOfPaws.Models;
using PlentyOfPaws.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        DataBaseConnection db = new DataBaseConnection();
        public ObservableCollection<UserProfile> _profile = new ObservableCollection<UserProfile>();
        public MainCardView()
        {
            InitializeComponent();
            GetDogs();
            CardBinding();
            BindingContext = this;
        }

        public void CardBinding()
        {
            Profiles.Add(new UserProfile() { Name = "Anil", Age = 22, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "Greg", Age = 18, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "James", Age = 31, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "Andy", Age = 26, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "Carol", Age = 77, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "Sppon", Age = 32, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "CPU", Age = 18, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "James", Age = 62, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "Dan", Age = 42, Photo = "testdog.jpg" });
            //Profiles.Add(new UserProfile() { Name = "MRHUM", Age = 34, Photo = "testdog.jpg" });

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
            public ImageSource Photo { get; set; }

        }

        private void GetDogs()
        {
            List<Dog> dogs = new List<Dog>();
            dogs = db.GetAllDogs();
            foreach (var d in dogs)
            {
                //Console.WriteLine(d.UserID.ToString());
                //Console.WriteLine(d.DogName);
                //Console.WriteLine(d.BreedOne);
                //Console.WriteLine(d.Gender);
                //Console.WriteLine(d.Age);
                //Console.WriteLine(d.Bio);



                Profiles.Add(new UserProfile() { Name = d.DogName, Age = d.Age, Photo = ImageSource.FromStream(() => new MemoryStream(converttoblob(d.DogImage))) });

               //Console.WriteLine(converttoblob(d.DogImage).Length);
               ImageSource img = ImageSource.FromStream(() => new MemoryStream(converttoblob(d.DogImage)));
            }
        }

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