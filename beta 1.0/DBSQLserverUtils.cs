using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConnectSQLserver
{
    class DBSQLserverUtils
    {
        public static SqlConnection GetDBconnection(string datasource, string database, string username, string password)
        {
            //Data Source=database-1.cka14fguvby5.eu-west-3.rds.amazonaws.com,1433;Initial Catalog=main;Persist Security Info=True;User ID=admin;Password=***********
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }

    }
}