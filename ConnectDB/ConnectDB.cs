using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDB
{
    public class ConnectDB
    {
            public static MySqlConnection Conn()
            {
                string connStr = "server=localhost;port=3306;user=maryanazim;database=maryadb;password=48985588;";
                //Переменная соединения
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }

    }
}
