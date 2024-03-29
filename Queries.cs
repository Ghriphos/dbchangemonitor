﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Database;


namespace Database
{
    public class Queries
    {
        public static Dictionary<string, TableSchema> fetchTableSchema(Connection database)
        {
            SqlConnection connection = database.CreateConnection();

            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_SCHEMA AS SchemaName, TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName FROM INFORMATION_SCHEMA.COLUMNS ORDER BY SchemaName, TableName, ColumnName;", connection);

            SqlDataReader reader = cmd.ExecuteReader();

            Dictionary<string, TableSchema> TableColumnMap = new Dictionary<string, TableSchema>();
            
            while(reader.Read())
            {
                string TableName = (string)reader["TableName"];
                string ColumnName = (string)reader["ColumnName"];

                if (!TableColumnMap.ContainsKey(TableName))
                {
                    TableColumnMap.Add(TableName, new TableSchema(TableName));
                }
                TableSchema Schema = TableColumnMap[TableName];
                Schema.Columns.Add(ColumnName);
            }
            connection.Close();

            return TableColumnMap;
        }

        public static Dictionary<string, int> tableRowsCount(Connection database, Dictionary<string, TableSchema> schemas){
            Dictionary<string, int> totalRowsPerTable = new Dictionary<string, int>();
            
            SqlConnection connection = database.CreateConnection();
            

            foreach(KeyValuePair<string, TableSchema> entry in schemas){
                connection.Open();

                TableSchema table = entry.Value;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from " + (string)table.Name, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()){
                    totalRowsPerTable.Add(table.Name, (int)reader[0]);
                }

                connection.Close();
            }
            

            return totalRowsPerTable;
        }

        public static StringBuilder createOutputCSV(Dictionary<string, int> LineCount){
            StringBuilder output = new StringBuilder();
            
            foreach(KeyValuePair<string, int> entry in LineCount){
                String tableName = entry.Key;
                Int128 count = entry.Value;
                String countString = count.ToString();

                output.AppendLine(string.Join(",", new String[]{tableName, countString}));
            }
            return output;
        }
    }
}

