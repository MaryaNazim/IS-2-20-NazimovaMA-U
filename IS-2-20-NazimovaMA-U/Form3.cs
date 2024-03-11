using ConnectDB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_2_20_NazimovaMA_U
{
    public partial class Form3 : Form
    {
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
        public Form3()
        {
            InitializeComponent();
        }

        //Метод получения ID выделенной строки, для последующего вызова его в нужных методах
        public void GetSelectedIDString()
        {
            try
            {
                //Переменная для индекс выбранной строки в гриде
                string index_selected_rows;
                //Индекс выбранной строки
                index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                //ID конкретной записи в Базе данных, на основании индекса строки
                id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Магические строки
            dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            dataGridView1.CurrentRow.Selected = true;
            //Метод получения ID выделенной строки в глобальную переменную
            GetSelectedIDString();
        }

        public void Afisha(string id)
        {
            try
            {
                string sql = "SELECT * FROM afisha WHERE id_Afisha = @id";
                using (conn)
                {
                    using (MySqlCommand command = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        MySqlParameter nameParam = new MySqlParameter("@id", id);

                        command.Parameters.Add(nameParam);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            // элементы массива [] - это значения столбцов из запроса SELECT
                            Auth.id = reader[0].ToString();
                            Auth.title = reader[1].ToString();
                            Auth.duration = reader[2].ToString();
                            Auth.datetime = reader[3].ToString();
                        }
                        reader.Close(); // закрываем reader
                                        // закрываем соединение с БД
                        conn.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }

        }

        //вывод строки из таблицы по двойному щелчку
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string index_selected_rows;
                //Индекс выбранной строки
                index_selected_rows = dataGridView1.SelectedCells[0].RowIndex.ToString();
                //ID конкретной записи в Базе данных, на основании индекса строки
                id_selected_rows = dataGridView1.Rows[Convert.ToInt32(index_selected_rows)].Cells[0].Value.ToString();
                Afisha(id_selected_rows);
                // запрос

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    MessageBox.Show("ID: " + Auth.id +
                        "\nНазвание: " + Auth.title +
                        "\nПродолжительность: " + Auth.duration +
                        "\nДата: " + Auth.datetime);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }

        MySqlConnection conn = Connectd.Conn();

        public void DB()
        {
            string sql = $"SELECT id AS 'Код заказа', " +
            $"count_bilet AS 'Номер билета', " +
            $"id_Room AS 'Зал', " +
            $"id_Afish AS 'Представление', " +
            $"date AS 'Дата', " +
            $"time AS 'Время', " +
            $"price AS 'Цена'" +
            $"FROM afisharooms " +
            $"INNER JOIN afisha ON title = id_Afish";
            conn.Open();
            // объект для выполнения SQL-запроса
            MyDA.SelectCommand = new MySqlCommand(sql, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DB();
            try
            {
                //Видимость полей в гриде
                dataGridView1.Columns[0].Visible = true;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[6].Visible = true;

                //Ширина полей
                dataGridView1.Columns[0].FillWeight = 15;
                dataGridView1.Columns[1].FillWeight = 40;
                dataGridView1.Columns[2].FillWeight = 15;
                dataGridView1.Columns[3].FillWeight = 30;
                dataGridView1.Columns[4].FillWeight = 40;
                dataGridView1.Columns[5].FillWeight = 15;
                dataGridView1.Columns[6].FillWeight = 30;
                //Режим для полей "Только для чтения"
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                //Растягивание полей грида
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //Убираем заголовки строк
                dataGridView1.RowHeadersVisible = false;
                //Показываем заголовки столбцов
                dataGridView1.ColumnHeadersVisible = true;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка!");
            }
        }
    }
}
