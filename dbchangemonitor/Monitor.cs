using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class Monitor
    {
        public string TableName { get; set; }
        public string[] ColumnName{ get; set; }    
        public static void PickTableNames()
        {
           
        }
    }
}