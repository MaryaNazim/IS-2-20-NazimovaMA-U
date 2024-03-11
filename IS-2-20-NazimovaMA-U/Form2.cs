using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_2_20_NazimovaMA_U
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        class Connect
        {
            public static MySqlConnection GetConnect()
            {
                string connStr = "server=localhost;port=3306;user=maryanazim;database=maryadb;password=48985588;";
                //Переменная соединения
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }
        MySqlConnection conn = Connect.GetConnect();


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Соединение подключено");
                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка.");
            }

        }
    }
}
