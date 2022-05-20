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
        public static string query = "";

        private static string passwsd = "root";

        private static string server = "172.23.112.1";
       // private static string server = "172.25.65.204";

        //Connection info
        // Change server ip to your local NIC.... so CMD on windows run ipconig and copy and paste your NIC ipv4 address. 
        private string MySQLConnectionString = $"server={server};database=db_account_info;user id=Dan;password={passwsd};";

        public void RegisterUser(string username, string email, string passhash, string location)
        {

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // string AddUserQuery = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";
            query = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";

            dbConnect.Open();

            //Runs query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            commanddb.ExecuteNonQuery();

            dbConnect.Close();

        }

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
                    CurrentUser.UserID = int.Parse( reader["UserID"].ToString());

                }

                dbConnect.Close();

                CurrentUser.AddtoList(CurrentUser);
            }
        }

        public void RegisterDog(int userid, string dogname, string breed, int age, string gender, string bio, byte[] img)
        {

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // string AddUserQuery = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";
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
           // Command.Parameters.Add("@password", MySqlDbType.VarChar).Value = Password;

            commanddb.ExecuteNonQuery();

            dbConnect.Close();

        }

        public List<Dog> GetAllDogs()
        {
            List<Dog> dogs = new List<Dog>();

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // string AddUserQuery = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";
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

                  //  dog.DogImage = reader.GetBytes
                  // dog.DogImage = ImageSource.FromStream(() => new MemoryStream(IFilePicker.converttoblob(reader.GetStream(7))));

                    dogs.Add(dog);
                }

                dbConnect.Close();

                return dogs;

            }
            else
            {
                return dogs;
            }
        }

        public void GetChats()
        {
            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            // string AddUserQuery = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";
            query = "SELECT * FROM `tbl_match`";

            dbConnect.Open();

            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);

            MySqlDataReader reader = commanddb.ExecuteReader();

            // get users id who is logged in 
            // find all there matchs from the database 

            // froms matches download there name and chats 


        }
    }
}
