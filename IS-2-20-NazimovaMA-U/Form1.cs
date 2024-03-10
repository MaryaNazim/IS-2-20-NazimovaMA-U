using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_2_20_NazimovaMA_U
{
    public partial class Form1 : Form
    {
        //Экземпляр класса
        Components component1;

        //Абстрактный класс "Комплектующие"
        abstract class Components
        {
            //Поля (цена, год выпуска, артикул)
            public decimal price;
            public int year;
            public object article;

            //Конструктор
            public Components(decimal pr, int yr, object art)
            {
                this.price = pr;
                this.year = yr;
                this.article = art;
            }

            //Вывод в MessageBox
            public void Display()
            {
                MessageBox.Show($"Цена:{price}\n Год выпуска:{year}\n Артикул:{article}");
            }
        }

        //Дочерний класс "Жёсткий диск"
        class HardDrive : Components
        {
            //Поля класса с автосвойствами
            private int Turnovers { get; set; }

            private string Interface { get; set; }
            private decimal Volume { get; set; }

            //Конструктор
            public HardDrive(decimal price, int year, object article, int tr, string itf, decimal vl)
                : base(price, year, article)
            {
                Turnovers = tr;
                Interface = itf;
                Volume = vl;
            }

            //Вывод в MessageBox
            public void Display(int tr, string itf, decimal vl)
            {
                MessageBox.Show($"Цена:{price}\n Год выпуска:{year}\n Артикул:{article}\n Количество оборотов:{tr}\n Интерфейс:{itf}\n Объём:{vl}ГБ");
            }
        }

        //Дочерний класс "Видеокарта"
        class GraphicAdapter : Components
        {
            //Поля класса с автосвойствами
            private int FrequencyGPU { get; set; }

            private string Manufacturer { get; set; }
            private decimal MemoryCapacity { get; set; }

            //Конструктор класса
            public GraphicAdapter(decimal price, int year, object article, int fr, string mf, decimal mc)
                : base(price, year, article)
            {
                FrequencyGPU = fr;
                Manufacturer = mf;
                MemoryCapacity = mc;
            }

            //Вывод в MessageBox
            public void Display(int fr, string mf, decimal mc)
            {
                MessageBox.Show($"Цена:{price}\n Год выпуска:{year}\n Артикул:{article}\n Количество оборотов:{fr}\n Интерфейс:{mf}\n Объём:{mc}ГБ");
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Инициализация экземпляра класса через textBox
            component1 = new HardDrive(Convert.ToDecimal(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToDecimal(textBox6.Text));
            component1.Display();
            //Вывод в ListBox
            listBox1.Items.Add($"Цена:{textBox1.Text}\n Год выпуска:{textBox2.Text}\n Артикул:{textBox3.Text}\n Количество оборотов:{textBox4.Text}\n Интерфейс:{textBox5.Text}\n Объём:{textBox6.Text}ГБ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Инициализация экземпляра класса через textBox
            component1 = new HardDrive(Convert.ToDecimal(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToDecimal(textBox6.Text));
            component1.Display();
            //Вывод в ListBox
            listBox1.Items.Add($"Цена:{textBox1.Text}\n Год выпуска:{textBox2.Text}\n Артикул:{textBox3.Text}\n Частота GPU:{textBox7.Text}МГц.\n Производитель:{textBox8.Text}\n Объём памяти:{textBox9.Text}ГБ");
        }
    }
}
