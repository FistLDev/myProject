using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ConnectSQLserver
{
    class DBUtils
    {
        public static SqlConnection GetDBconnection()
        {
            
            string datasource = @"database-1.cka14fguvby5.eu-west-3.rds.amazonaws.com,1433";
            string database = "main";
            string username = "admin";
            string password = "mypassword";
            return DBSQLserverUtils.GetDBconnection(datasource, database, username, password);
        }
    }
}
