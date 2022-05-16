using System;
using MySqlConnector;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        public static string query = "";

        private static string passwsd = "root";

        //    string server = "172.22.32.1";
        private static string server = "172.25.65.204";

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
    }
}
