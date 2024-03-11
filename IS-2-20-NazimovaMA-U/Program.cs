using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_2_20_NazimovaMA_U
{
    static class Auth
    {
        public static string id = null;
        public static string title = null;
        public static string duration = null;
        public static string datetime = null;

    }
    public class Connectd
    {
        public static MySqlConnection Conn()
        {
            string connStr = "server=localhost;port=3306;user=maryanazim;database=maryadb;password=48985588;";
            //Переменная соединения
            MySqlConnection conn = new MySqlConnection(connStr);
            return conn;
        }


    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
