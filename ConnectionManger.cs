using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class ConnectionManger
    {

        public static SqlConnection NewCon;

        public static string ConStr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            NewCon = new SqlConnection(ConStr);
            return NewCon;
        }

    }
}
