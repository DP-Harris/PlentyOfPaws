using System;
using MySqlConnector;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        public void run()
        {
            string query = "UPDATE `tbl_user` SET `UserName` = 'THORN' WHERE `tbl_user`.`UserID` = 1";

            string passwsd = "root";

            //Connection info
            // Change server ip to your local NIC.... so CMD on windows run ipconig and copy and paste your NIC ipv4 address. 
            string MySQLConnectionString = $"server=172.20.10.6;database=db_account_info;user id=Dan;password={passwsd};";

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            //Runs query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);
            commanddb.CommandTimeout = 60;

            MySqlCommand newCommand = new MySqlCommand();

                
                dbConnect.Open();

                MySqlDataReader reader = commanddb.ExecuteReader();
               
        }
    }
}
