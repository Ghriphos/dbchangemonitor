using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Queries
    {
        public static void execute(Connection database)
        {
            SqlConnection connection = database.CreateConnection();

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_SCHEMA AS SchemaName, TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName FROM INFORMATION_SCHEMA.COLUMNS ORDER BY SchemaName, TableName, ColumnName;", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            connection.Close();

        }
    }
}
