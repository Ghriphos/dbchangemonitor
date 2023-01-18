using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class TableSchema
    {
        public string Name { get; set; }
        public List<string> Columns { get; set; }

        public TableSchema(string Name)
        {
           this.Name = Name;
           this.Columns = new List<string>();
        }
    }
}