﻿using System;
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

    }
}
