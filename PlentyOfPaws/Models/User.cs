using System;
using System.Collections.Generic;
using System.Text;

namespace PlentyOfPaws.Models
{
    public class User
    {
        public List<User> ActiveUsers = new List<User>();
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public void AddtoList(User user)
        {
            ActiveUsers.Add(user);
        }

        public void PrintUserInfo(User user)
        {
            Console.WriteLine(user.UserName);
            Console.WriteLine(user.UserEmail);
            Console.WriteLine(user.UserPassword);
        }

        // User Location; 

       
       

    }
}
