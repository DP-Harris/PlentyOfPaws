﻿using System;
using MySqlConnector;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        public static string query = "";

        private static string passwsd = "root";

        private static string server = "172.17.224.1";
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
    }
}
