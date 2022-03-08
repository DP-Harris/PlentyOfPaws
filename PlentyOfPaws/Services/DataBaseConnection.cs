using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PlentyOfPaws.Services
{
    public class DataBaseConnection
    {
        
        public static string server = "localhost";
        public static string database = "teststuff";
        public static string username = "root";
        public static string password = "";

        string ConnectionString = "SERVER="+server+";"+"DATABASE="+database+";"+"UID="+username+";"+"PASSWORD="+password+";";
        SqlConnection con;

        public void OpenConection()
        {
             con = new SqlConnection(ConnectionString);
             con.Open();

            Console.WriteLine(ConnectionString);
        }


        public void CloseConnection()
        {
            con.Close();
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }


        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public object ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

    }
}
