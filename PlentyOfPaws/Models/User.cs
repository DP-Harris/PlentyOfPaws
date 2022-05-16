using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PlentyOfPaws.Models
{
    public class User
    {
        public List<User> ActiveUsers = new List<User>();
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserLocation { get; set; }
 

        public User()
        {
            UserID++;
        }

        public void AddtoList(User user)
        {
            ActiveUsers.Add(user);
        }

        public List<User> ReturnUser() { return ActiveUsers; }

        // User Location; 

       
       

    }
}
