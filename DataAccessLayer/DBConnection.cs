using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=critterpedia_plus;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
