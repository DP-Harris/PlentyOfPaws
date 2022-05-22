using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PlentyOfPaws.Models
{
    public class User
    {
        // Keeps track of active user and all of there attributes, needed many times thoughout the application. 
        public static List<User> ActiveUsers = new List<User>();
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserLocation { get; set; }
 

        public User()
        {
           
        }

        // Allows us to add to the active users static list
        public void AddtoList(User user)
        {
            ActiveUsers.Add(user);
        }
    }
}
