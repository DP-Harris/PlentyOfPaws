using System;
using MySqlConnector;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        public void run()
        {
            string query = "SELECT * FROM tbl_user";

            string passwsd = "";

            //Connection info
            string MySQLConnectionString = $"server=127.0.0.1;database=db_account_info;user id=root;password={passwsd};";

            //Connects to DB
            MySqlConnection dbConnect = new MySqlConnection(MySQLConnectionString);

            //Runs query
            MySqlCommand commanddb = new MySqlCommand(query, dbConnect);
            commanddb.CommandTimeout = 60;

            try
            {
                Console.WriteLine("NOT OPEN");
                Console.WriteLine(MySQLConnectionString);
                dbConnect.Open();
                Console.WriteLine("OPEN");

                MySqlDataReader reader = commanddb.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //1 GetString() per row
                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4));
                        Console.WriteLine("Worked");
                    }
                }
            }
            catch (Exception e)
            {
                //Error msg
                Console.WriteLine("Something went wrong\n" + e.StackTrace);
            }
        }
    }
}
