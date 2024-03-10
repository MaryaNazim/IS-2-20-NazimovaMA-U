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

        //Строка подключения к БД
        string connStr = "server=localhost;port=3306;user=maryanazim;database=maryadb;password=48985588;";
        //Переменная соединения
        MySqlConnection conn;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Открываем соединение с БД
                conn.Open();
                //Сообщение при удачной попытке подключиться к БД
                MessageBox.Show("Подключено");
            }
            catch
            {
                //При исключении закрываем соединение с БД
                conn.Close();
                //Сообщение при возникновении исключения
                MessageBox.Show("Возникло исключение");
            }
            finally
            {
                //Закрываем соединение с БД
                conn.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Инициализируем соединение с подходящей строкой
            conn = new MySqlConnection(connStr);
        }
    }
}
