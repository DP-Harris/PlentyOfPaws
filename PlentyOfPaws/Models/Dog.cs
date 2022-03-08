using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
//System.Drawing.Image:

namespace PlentyOfPaws.Models
{
    public class Dog
    {
        public int UserID { get; set; }
        public int DogID { get; set; }
        public string DogName { get; set; }
        public string BreedOne { get; set; }
        public string BreedTwo { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        // Example how to query a database to read a blob data type into a image and draw image. 

        // Query.Append("SELECT * FROM TABLE;");
        // cmd = MySQLCommand(Query.ToString(), conn);
        /*  byte[] imageBytes = (byte[])cmd.ExecuteReader(); ["headshot"];

        using (var ms = new MemoryStream(imageBytes))
        {
          headshot.Headshot = System.Drawing.Image.FromStream(ms);
        }*/



        // Image_One
        // Image_Two
        // Image_Three
        // Image_Four
        // Image_Five
    }
}
