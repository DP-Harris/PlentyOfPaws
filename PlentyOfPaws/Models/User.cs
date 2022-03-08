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
        public string UserLatitude{ get; set; }
        public string UserLongitude { get; set; }

        public User()
        {
            UserID++;
        }

        public void AddtoList(User user)
        {
            ActiveUsers.Add(user);
        }

        public void PrintUserInfo(User user)
        {
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.UserEmail);
            Console.WriteLine(user.UserPassword);
            Console.WriteLine(user.UserLatitude.ToString());
            Console.WriteLine(user.UserLongitude.ToString());
            Console.WriteLine(UserID);
        }

        // User Location; 

       
       

    }
}
