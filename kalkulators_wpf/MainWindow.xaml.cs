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

namespace kalkulators_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float operand1 = 0;
        float operand2 = 0;
        string operation = "";

        float result = 0;


        //Flow: ieraksta 1. operandu, uzspiežot operatoru, displejā parādās 0, tiek saglabāts 1. operands. Pēc tam ievada 2. operandu un veic aprēķinus.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_digit_1_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 1;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 1;
                display.Text = operand2.ToString();
            }

        }

        private void Button_digit_2_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 2;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 2;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_3_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 3;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 3;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_4_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 4;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 4;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_5_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 5;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 5;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_6_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 6;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 6;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_7_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 7;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 7;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_8_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 8;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 8;
                display.Text = operand2.ToString();
            }
        }

        private void Button_digit_9_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + 9;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + 9;
                display.Text = operand2.ToString();
            }
        }

        private void Button_operation_plus_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            operation = "+";

        }

        private void Button_operation_minus_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            operation = "-";

        }

        private void Button_operation_multiply_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            operation = "*";

        }

        private void Button_operation_division_Click(object sender, RoutedEventArgs e)
        {
            display.Text = "0";
            operation = "/";
        }



        private void Button_operation_equals_Click(object sender, RoutedEventArgs e)
        {
            switch(operation)
            {
                case "+":
                    result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    result = operand1 / operand2;
                    break;

            }
            operand1 = result;
            operand2 = 0;
            operation = "";
            display.Text = result.ToString();
        }

        private void Button_digit_0_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10;
                display.Text = operand2.ToString();
            }
        }

        private void Button_utiliy_clear_all_Click(object sender, RoutedEventArgs e)
        {
            operand1 = 0;
            operand2 = 0;
            operation = "";
            display.Text = "0";
        }

        private void Button_utiliy_clear_last_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                operand1 = 0;
            }
            else
            {
                operand2 = 0;
            }
            display.Text = "0";
        }

        private void Button_utiliy_clear_last_element_Click(object sender, RoutedEventArgs e)
        {
            if(operation == "")
            {
                string temp = operand1.ToString();

                if(temp.Length != 0)
                {
                    temp = temp.Remove(temp.Length - 1);
                }
                Console.WriteLine(temp);
                operand1 = float.Parse(temp);
                Console.WriteLine(operand1);

                display.Text = temp;
            }
            else
            {
                string temp = operand2.ToString();
                if (temp.Length != 0)
                {
                    temp = temp.Remove(temp.Length - 1);
                }
                operand2 = float.Parse(temp);
                display.Text = temp;


            }
        }
    }
}
