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
        public ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();
        public MainCardView()
        {
            InitializeComponent();
            GetDogs();
            //CardBinding();
            BindingContext = this;
        }

        //public void CardBinding()
        //{
        //    _dogs.Add(new Dog() { DogName = "Anil", Age = 22, BreedOne = "Collie", Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "Greg", Age = 18, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "James", Age = 31, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "Andy", Age = 26, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "Carol", Age = 77, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "Sppon", Age = 32, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "CPU", Age = 18, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "James", Age = 62, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "Dan", Age = 42, Photo = "testdog.jpg" });
        //    //Profiles.Add(new UserProfile() { Name = "MRHUM", Age = 34, Photo = "testdog.jpg" });

        //}

        public ObservableCollection<Dog> DogProfiles
        {
            get => _dogs;
            set
            {
                _dogs = value;
            }
        }

        private void GetDogs()
        {
            List<Dog> dogs = new List<Dog>();
            dogs = db.GetAllDogs();

            //GetDogsGender(dogs); 
            
            //RemoveOppisiteGender(dogs);
            //RemoveUsersDog(dogs);

            foreach (var d in dogs)
            {          
                _dogs.Add(new Dog() { DogName = d.DogName, Age = d.Age, BreedOne = d.BreedOne, Photo = ImageSource.FromStream(() => new MemoryStream(converttoblob(d.DogImage))) });
            }
        }

        private void RemoveUsersDog(List<Dog> dogs)
        {
            for (int i = 0; i < dogs.Count(); i++)
            {
                if (dogs[i].UserID == User.ActiveUsers[0].UserID)
                {
                    dogs.RemoveAt(i);
                }

            }
        }

        private string GetDogsGender(List<Dog> dogs)
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

        private void RemoveOppisiteGender(List<Dog> dogs)
        {
            for (int i = 0; i < dogs.Count(); i++)
            {
                if (dogs[i].Gender != GetDogsGender(dogs).ToLower())
                {
                    dogs.RemoveAt(i);
                }
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
            Console.WriteLine("Rejected");
        }

        private void likeButton_Clicked(object sender, EventArgs e)
        {
            SwipeView1.InvokeSwipe(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Right);
            Console.WriteLine("Matched");
        }
    }
}