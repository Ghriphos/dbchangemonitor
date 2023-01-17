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
        public static void fetchTableSchema(Connection database)
        {
            SqlConnection connection = database.CreateConnection();

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_SCHEMA AS SchemaName, TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName FROM INFORMATION_SCHEMA.COLUMNS ORDER BY SchemaName, TableName, ColumnName;", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, List<string>> TableColumnMap = new Dictionary<string, List<string>>();
            
            while(reader.Read())
            {
                string TableName = (string)reader["TableName"];
                string ColumnName = (string)reader["ColumnName"];

                if (!TableColumnMap.ContainsKey(TableName))
                {
                    TableColumnMap.Add(TableName, new List<string>());
                }
                List<string> Columns = TableColumnMap[TableName];
                Columns.Add(ColumnName);
            }
            foreach(KeyValuePair<string, List<string>> entry in TableColumnMap)
            {
                Console.WriteLine(entry.Key);
                Console.WriteLine(string.Join(",", entry.Value));
            }

            connection.Close();
        }
    }
}
