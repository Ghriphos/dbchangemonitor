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
        Queries.fetchTableSchema(database);
    }
}

