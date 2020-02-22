using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double value = 0; //хранит значение первой переменной
        String operation = "";  //хранит операцию 
        bool operation_pressed = false; //Логическая переменная, нужная для того, чтобы не было возможности создать несколько операторов
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (result.Text == "0")
                result.Clear();
            Button b = (Button)sender;
            result.Text = result.Text + b.Text; //Выводим на текстовое поле значение текста нажатой кнопки
        }

        private void button16_Click(object sender, EventArgs e)
        {
            result.Text = "0"; //При нажатии на кнопку CE значение текстового поля равняется нулю
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender; //Создаем переменную типа Button
            operation = b.Text;
            value = Convert.ToDouble(result.Text);  //присваивает value значение текстового поля до того, как присваеваем ему нулевое значение(полю)
            operation_pressed = true;   //Кнопка операции была нажата
            result.Text = "0";

        }
        private void button18_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    result.Text = (value + Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    result.Text = (value - Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    result.Text = (value * Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(result.Text) == 0) result.Text = "На ноль делить нельзя!";
                    else
                        result.Text = (value / Double.Parse(result.Text)).ToString();
                    break;
                default:
                    break;
                case "^":
                    result.Text = (System.Math.Pow(value, Double.Parse(result.Text))).ToString();
                    break;
            }//конец выбора знака
            operation_pressed = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            string patch = @"C:\Users\Xiaomi\Desktop";
            DirectoryInfo dirinfo = new DirectoryInfo(patch);
            if (!dirinfo.Exists)
            {
                dirinfo.Create();
            }
            string text = result.Text;

            using (FileStream fstream = new FileStream(@"C:\Users\Xiaomi\Desktop\Подсчёт.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                fstream.Write(array, 0, array.Length);
            }
            using (FileStream fstream = File.OpenRead(@"C:\Users\Xiaomi\Desktop\Подсчёт.txt"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                label1.Text = textFromFile;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}