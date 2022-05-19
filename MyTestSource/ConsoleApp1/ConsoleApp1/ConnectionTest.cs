using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConnectionTest
    {
        public void Test()
        {
            string connectionString = "Data Source=ivm-nc-dev-sqlmi.94243dd69f1b.database.windows.net;Initial Catalog=CSS-QA;Persist Security Info=True;User ID=JohnsonAdmin;Password=B4kL15uV2ZWOTkh4sl7X";

            //string connectionString = "Data Source=ivm-dev\\ivmdev;Initial Catalog=CSS;Persist Security Info=True;User ID=JohnsonAdmin;Password=B4kL15uV2ZWOTkh4sl7X";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close(); 
        } 


     
    }
}
