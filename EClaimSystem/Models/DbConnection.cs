using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EClaimSystem.Models
{
    public class DbConnection
    {
        public SqlConnection connection;
        
        public DbConnection()
        {
            connection = new SqlConnection("Data Source=DESKTOP-P714P32;Initial Catalog=eClaimDB;Integrated Security=True");
        }
    }
}
