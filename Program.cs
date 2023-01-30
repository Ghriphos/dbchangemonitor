using Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {
        Connection database = new Connection();

        Dictionary<string, TableSchema> schemas = Queries.fetchTableSchema(database);
        Dictionary<string, int> countPerTable = Queries.tableRowsCount(database, schemas);

        Console.WriteLine("\r\n" + "Contagem de Linhas" + "\r\n");

        foreach(TableSchema schema in schemas.Values){
            Console.WriteLine(schema.Name + ": " + countPerTable[schema.Name]);
        }
        StringBuilder output = Queries.createOutputCSV(countPerTable);
        String file = @"C:\workspace\dbchangemonitor\outputs\filename.csv";
        File.AppendAllText(file, output.ToString());
    }
}

