using System;
using System.Collections.Generic;
using System.IO;
using MySqlConnector;
using PlentyOfPaws.Models;
using Xamarin.Forms;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        // Hold Query so we can just modify this query before using it.
        public static string query = "";

        // Password as string so can be changed if needed
        private static string passwsd = "root";

        // Change server ip to your local NIC.... so CMD on windows run ipconig and copy and paste your NIC ipv4 address. 
        private static string server = "172.23.112.1";
       // private static string server = "172.25.65.204";

        //Connection info
        // Connected to local host server on specified ip to the database we need using root as password. 
        private string MySQLConnectionString = $"server={server};database=db_account_info;user id=Dan;password={passwsd};";

        // Register User takes in a username,emal,password,and location.
        public void RegisterUser(string username, string email, string passhash, string location)
        {

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query we need to pass in updates private query in the class.
            query = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";

            // Opens database connection
            dbConnect.Open();

            // Preps query to be sent to database query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Runs the Query
            commanddb.ExecuteNonQuery();

            // Closes the database connection. 
            dbConnect.Close();

        }

        // Validate users login request, takes in email and password
        // if incorrect no database rows will be shown and we can return false
        // else will be true and user will be logged in. 
        public bool ValidateUser(string email, string password)
        {
            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query to be ran 
            query = $"SELECT* FROM tbl_user WHERE Email = '{email}' AND EncryptedPassword = '{password}'";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            // If rows is > 0 then email and password match and we can log the user in else we can fail validation.
            if (reader.HasRows)
            {
                return true;

            }
            else
            {
                // Always close reader
                reader.Close();
            }

            // make sure reader is closed and db is closed 
            reader.Close();

            // Cloes database connection. 
            dbConnect.Close();

            // No matches was found so we can return false to fail validation of the login attempt 
            return false;
        }

        public void GetUserDetails(string email, string password)
        {
            List<string> UserInfo = new List<string>();
            User CurrentUser = new User();

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query to be ran 
            query = $"SELECT* FROM tbl_user WHERE Email = '{email}' AND EncryptedPassword = '{password}'";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            // If rows is > 0 then email and password match and we can log the user in else we can fail validation.
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CurrentUser.UserName = reader["UserName"].ToString();
                    CurrentUser.UserEmail = email;
                    CurrentUser.UserLocation = reader["Location"].ToString();
                    CurrentUser.UserID = int.Parse(reader["UserID"].ToString());

                }

                dbConnect.Close();

                CurrentUser.AddtoList(CurrentUser);
            }
        }

        public void RegisterDog(int userid, string dogname, string breed, int age, string gender, string bio, byte[] img)
        {

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            query = $"INSERT INTO `tbl_dog` (`UserID`, `DogName`, `BreedOne`, `BreedTwo`, `Age`, `Gender`, `ImageOne`, `ImageTwo`, `ImageThree`, `ImageFour`, `ImageFive`, `Bio`) VALUES (@UserID, @DogName, @BreedOne, NULL, @Age, @Gender, @ImageOne, 'NULL', 'NULL', 'NULL', 'NULL', @Bio)\n";

            dbConnect.Open();

            //Runs query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);
            commanddb.Parameters.Add("@UserID", MySqlDbType.Int64).Value = userid;
            commanddb.Parameters.Add("@DogName", MySqlDbType.VarChar).Value = dogname;
            commanddb.Parameters.Add("@BreedOne", MySqlDbType.VarChar).Value = breed;
            commanddb.Parameters.Add("@age", MySqlDbType.Int64).Value = age;
            commanddb.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender;
            commanddb.Parameters.Add("@bio", MySqlDbType.VarChar).Value = bio;
            commanddb.Parameters.Add("@ImageOne", MySqlDbType.LongBlob).Value = img;

            commanddb.ExecuteNonQuery();

            dbConnect.Close();

        }

        public void AssignUserDog()
        {
            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);
            Dog UserDog = new Dog();
            // Query to be ran 
            query = $"SELECT* FROM tbl_dog WHERE UserID = '{User.ActiveUsers[0].UserID}'";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            // If rows is > 0 then email and password match and we can log the user in else we can fail validation.
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserDog.UserID = int.Parse(reader["UserID"].ToString());
                    UserDog.DogID = int.Parse(reader["DogID"].ToString());
                    UserDog.DogName = reader["DogName"].ToString();
                    UserDog.BreedOne = reader["BreedOne"].ToString();
                    UserDog.Age = int.Parse(reader["age"].ToString());
                    UserDog.Gender = reader["gender"].ToString();
                    UserDog.Bio = reader["bio"].ToString();
                    UserDog.DogImage = reader.GetStream(7);
                }

            }
                dbConnect.Close();

                Dog.UsersDog.Add(UserDog);
        }

        public List<Dog> GetAllDogs()
        {
            AssignUserDog();
            List<Dog> dogs = new List<Dog>();
            List<int> MatchedDogs = new List<int>();
            MatchedDogs = FilterMatchedDogs();

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            query = "SELECT * FROM `tbl_dog`";

            dbConnect.Open();

            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            MySqlDataReader reader = commanddb.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dog dog = new Dog();

                    dog.UserID = int.Parse(reader["UserID"].ToString());
                    dog.DogID = int.Parse(reader["DogID"].ToString());
                    dog.DogName = reader["DogName"].ToString();
                    dog.BreedOne = reader["BreedOne"].ToString();
                    dog.Age = int.Parse(reader["age"].ToString());
                    dog.Gender = reader["gender"].ToString();
                    dog.Bio = reader["bio"].ToString();
                    dog.DogImage = reader.GetStream(7);

                    if (MatchedDogs.Contains(dog.DogID))
                    {
                        Console.WriteLine("MAtched Removed as shown match blah blah");
                    }
                    else
                    {
                        dogs.Add(dog);
                    }

                   
                }

                dbConnect.Close();

               
               return dogs;

            }
            else
            {
                return dogs;
            }
        }

        
        // Checks to make sure user has a dog register on the database
        public bool UserHasDog()
        {
            // Opens SQL Connection. 
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query passed to the database should return rows if a dog is present. 
            query = $"SELECT* FROM tbl_dog WHERE UserID = '{User.ActiveUsers[0].UserID}';";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            // If rows is > 0 a dog is present on the database and return true. 
            if (reader.HasRows)
            {
                reader.Close();
                return true;

            }
            else
            {
                // Always close reader
                reader.Close();
            }

            // make sure reader is closed and db is closed 
            reader.Close();
            // Closes the connection to the database. 
            dbConnect.Close();

            // No matches was found so we can return false to fail validation of the login attempt 
            return false;

           
        }

        // Logs data in tbl_Swiperight to use for matching data later in the application, userid is the dogs owner, dog id is the current dog
        // otherdogid represents the dog that was liked and current user swiped right on.
        public void LogRightSwipes(int Userid, int Dogid, int OtherDogID)
        {        
                
                //Connects to DB
                MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

                // Query to log a row into the MySQL database
                query = $"INSERT INTO `tbl_swiperight` (`UserID`, `DogID`, `LikedDogID`) VALUES('{Userid}', '{Dogid}', '{OtherDogID}')";
               

                // Sets up the Query
                MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

                // Opens Database
                dbConnect.Open();

                // Runs the query 
                commanddb.ExecuteNonQuery();
                
                // Closes the connection to the database. 
                dbConnect.Close();
        }

        // Logs data in tbl_Swiperight to use for matching data later in the application, userid is the dogs owner, dog id is the current dog
        // otherdogid represents the dog that was liked and current user swiped right on.
        public void LogLeftSwipes(int Userid, int Dogid, int OtherDogID)
        {

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query to log a row into the MySQL database
            query = $"INSERT INTO `tbl_swipeleft` (`UserID`, `DogID`, `NotLikedDogID`) VALUES('{Userid}', '{Dogid}', '{OtherDogID}')";


            // Sets up the Query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Opens Database
            dbConnect.Open();

            // Runs the query 
            commanddb.ExecuteNonQuery();

            // Closes the connection to the database. 
            dbConnect.Close();
        }

        

        public int FindMatch(int UsersDogID, int LikedDogID)
        {
            int OtherUserID = 0;
            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Query to log a row into the MySQL database
            //SELECT UserID from tbl_SwipeRight where LikedDogID = 8 AND DogID = 9;

            query = $"SELECT UserID from tbl_SwipeRight where LikedDogID = '{UsersDogID}' AND DogID = '{LikedDogID}'";

            // Sets up the Query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Opens Database
            dbConnect.Open();

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

      

            if (reader.Read())
            {
 
                OtherUserID = int.Parse(reader["UserID"].ToString());

            }
            else
            {
                // Always close reader
                reader.Close();
            }


            // Closes the connection to the database. 
            dbConnect.Close();

            return OtherUserID;
        }

        public void CreateChatMatchRow(int OtherUsersID)
        {
            if (OtherUsersID != 0)
            {
                MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

                // Query to log a row into the MySQL database 
                query = $"INSERT INTO `tbl_chat` (`ChatID`, `UserA`, `UserB`, `ChatTimestamp`) VALUES(NULL,'{User.ActiveUsers[0].UserID}', '{OtherUsersID}', current_timestamp());";

                MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

                // Opens Database
                dbConnect.Open();

                // Runs the query 
                commanddb.ExecuteNonQuery();

                // Closes the connection to the database. 
                dbConnect.Close();
            }
        }

        public List<int> FilterMatchedDogs()
        {
            // Opens SQL Connection. 
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            List<int> MatchedDogs = new List<int>();

            // Query passed to the database should return rows if a dog is present. 
            query = $"SELECT LikedDogID FROM `tbl_swiperight` WHERE UserID = '{User.ActiveUsers[0].UserID}' AND DogID = '{Dog.UsersDog[0].DogID}';";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            // If rows is > 0 a dog is present on the database and return true. 

            while (reader.Read())
            {
                MatchedDogs.Add(reader.GetInt32(0));
            }

            // make sure reader is closed and db is closed 
            reader.Close();
            // Closes the connection to the database. 
            dbConnect.Close();


            return MatchedDogs;
        }      

        public void GetChatMatchs()
        {
            // Opens SQL Connection. 
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // Select all chats our user is the main participant in.
            query = $"SELECT * FROM `tbl_chat` WHERE UserA = '{User.ActiveUsers[0].UserID}'";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            if (reader.Read())
            {
                while (reader.Read())
                {
                    Chat UserChat = new Chat();

                    UserChat.ChatID = reader.GetInt32(0);
                    UserChat.UserIDA = reader.GetInt32(1);
                    UserChat.UserIDB = reader.GetInt32(2);

                    UserChat.AddChatToList(UserChat);

                }
            }
 
            // make sure reader is closed and db is closed 
            reader.Close();
            // Closes the connection to the database. 
            dbConnect.Close();

        }

        public List<User> GetUserNameAndEmail(int UserBID)
        {
            // Opens SQL Connection. 
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            List<User> MatchUsersDetails = new List<User>();

            // Select all chats our user is the main participant in.
            // SELECT UserName, Email FROM `tbl_user` WHERE UserID = 11;
            query = $"SELECT UserName, Email FROM `tbl_user` WHERE UserID = '{UserBID}';";

            // Opens Database connection
            dbConnect.Open();

            // Runs Query into the DB.
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            // Executes the Query.
            MySqlDataReader reader = commanddb.ExecuteReader();

            
                while (reader.Read())
                {
                   User MatchedUser = new User();

                    MatchedUser.UserName = reader.GetString(0);
                    MatchedUser.UserEmail = reader.GetString(1);

                    MatchUsersDetails.Add(MatchedUser);
                }
            

            // make sure reader is closed and db is closed 
            reader.Close();
            // Closes the connection to the database. 
            dbConnect.Close();

            return MatchUsersDetails;

        }
    }
}