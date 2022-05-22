using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace PlentyOfPaws.Models
{
    public class User
    {

        public static List<User> ActiveUsers = new List<User>();
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserLocation { get; set; }
 

        public User()
        {
           
        }

        public void AddtoList(User user)
        {
            ActiveUsers.Add(user);
        }

        public List<User> ReturnUser()
        { return ActiveUsers; }

        public static User GetUser()
        {
            return ActiveUsers[0];
        }

        // User Location; 

       
       

    }
}
