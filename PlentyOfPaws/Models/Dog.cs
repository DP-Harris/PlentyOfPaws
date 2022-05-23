using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
//System.Drawing.Image:

namespace PlentyOfPaws.Models
{
    public class Dog
    {
        // Used to gain access to the users dog. 
        public static List<Dog> UsersDog = new List<Dog>();

        // All needed properties for dogs in the application, as the app was scaled down in complexity, some of these
        // are not currently needed but can easily be added upon and used in new version of the application. 
        public int UserID { get; set; }
        public int DogID { get; set; }
        public string DogName { get; set; }
        public string BreedOne { get; set; }
        public string BreedTwo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Bio { get; set; }
        public Stream DogImage { get; set; }
        public ImageSource Photo { get; set; }

        // Can populate the users dog into its respective list for use though tout the application. 
        public void AddtoList(Dog dog)
        {
            UsersDog.Add(dog);
        }

    }
}
