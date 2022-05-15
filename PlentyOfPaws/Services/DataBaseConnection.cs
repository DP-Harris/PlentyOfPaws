using System;
using MySqlConnector;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        // string query = "UPDATE `tbl_user` SET `UserName` = 'Airpod' WHERE `tbl_user`.`UserID` = 1";

      // public static string query = $"";

       //private static string passwsd = "root";

       //private static string server = "172.22.32.1";

       // //Connection info
       // // Change server ip to your local NIC.... so CMD on windows run ipconig and copy and paste your NIC ipv4 address. 
       // public readonly string MySQLConnectionString = $"server={server};database=db_account_info;user id=Dan;password={passwsd};";

        public void run(string username, string email, string passhash, string location)
        {
          //  string query = "UPDATE `tbl_user` SET `UserName` = 'Airpod' WHERE `tbl_user`.`UserID` = 1";

            string query = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";

            string passwsd = "root";

            string server = "172.22.32.1";

            //Connection info
            // Change server ip to your local NIC.... so CMD on windows run ipconig and copy and paste your NIC ipv4 address. 
            string MySQLConnectionString = $"server={server};database=db_account_info;user id=Dan;password={passwsd};";

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

           // Runs query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);
            commanddb.CommandTimeout = 60;


            MySqlCommand newCommand = new MySqlCommand();


            dbConnect.Open();

            MySqlDataReader reader = commanddb.ExecuteReader();

        }

        //public void RegisterUser(string username, string email, string passhash, string location)
        //{

        //    //Connects to DB
        //    MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);



        //    // string AddUserQuery = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";
        //    string query = $"INSERT INTO `tbl_user` (`UserID`, `UserName`, `Email`, `EncryptedPassword`, `Location`) VALUES(NULL, '{username}', '{email}', '{passhash}', '{location}')";

        //     //Runs query
        //    MySqlCommand commanddb = new MySqlCommand(query, dbConnect);
        //    commanddb.CommandTimeout = 60;


        //}
    }
}
