using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Connection
    {
        public SqlConnection CreateConnection()
        {
            string connectionString = "server=localhost\\SQLEXPRESS08; Database=test;Integrated Security=SSPI;";
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            return sqlConnection;
        }
    }
}
