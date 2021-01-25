using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double num1 = 0;
        double num2 = 0;
        string op = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string str = button.Content.ToString();
            if (TextBox1.Text == "0")
                TextBox1.Text = str;
            else
                TextBox1.Text += str;

            if (op == "")
            {
                num1 = Double.Parse(TextBox1.Text);
            }
            else
            {
                num2 = Double.Parse(TextBox1.Text);
            }
        }
        private void Btn_Oper_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            op = button.Content.ToString();
            TextBox1.Text = "0";
            
        }
        // Функция вычисления
        private void BtnEqauls_Click(object sender, RoutedEventArgs e)
        {
            double rezult = 0;
            switch (op)
            {
                case "+": rezult = num1 + num2; break;
                case "-": rezult = num1 - num2; break;
                case "*": rezult = num1 * num2; break;
                case "/": rezult = num1 / num2; break;
                case "Срд": rezult = (num1 + num2) / 2; break;
                case "Макс": rezult = Math.Max(num1,num2); break;
                case "Мин": rezult = Math.Min(num1, num2); break;
                case "x^y": rezult = Pow(num1, (int)num2); break;
            }
            TextBox1.Text = rezult.ToString();
            op = "";
            num1 = rezult;
            num2 = 0;
        }

        private double Pow(double num1, int num2)
        {
            if (num2 == 0) return 1;
            return Pow(num1, num2 - 1) * num1;
        }

        private void BtnC_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = "0";
            num1 = 0;
            num2 = 0;
            op = "";
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = DropLastChar(TextBox1.Text);
            if (op == "")
            {
                num1 = Double.Parse(TextBox1.Text);
            }
            else
            {
                num2 = Double.Parse(TextBox1.Text);
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length == 1)
            {
                text = "0";
            }
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length-1] == ',')
                    text = text.Remove(text.Length - 1, 1);

            }
               
       
            return text;
        }

        private void BtnCE_Click(object sender, RoutedEventArgs e)
        {
            if (op == "") num1 = 0;
            else num2 = 0;
            TextBox1.Text = "0";
        }

        private void BtnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
            {
                num1 = num1 * -1;
                TextBox1.Text = num1.ToString();
            } 
            else
            {
                num2 = num2 * -1;
                TextBox1.Text = num2.ToString();
            }
        }

        private void BtnZap_Click(object sender, RoutedEventArgs e)
        {
            if (op == "")
                SetComma(num1);
            else
                SetComma(num2);
        }

        private void SetComma(double num)
        {
            if (TextBox1.Text.Contains(','))
                return;
            TextBox1.Text+=',';
        }
    }
}
