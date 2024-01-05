using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ADO_Connected_Arch_Demo.Util
{
    static class UtilClass
    {
        static SqlConnection connection = null;
        //public static SqlConnection GetConnection(string connectionString)
        //{
        //    connection.ConnectionString = connectionString;
        //    return connection;
        //}
        //(or)
        public static SqlConnection GetConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
           // connection.ConnectionString = @"DataSource=(localdb)\MSSQLLocalDB;Initial Catalog=Hexaware_Dec_23;Integrated Security=True;";
            return connection;
        }
    }
}
