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

    public partial class MainWindow : Window
    {
        double operand1 = 0;
        double operand2 = 0;
        string operation = "";

        double result = double.NaN;


        //Flow: ieraksta 1. operandu, uzspiežot operatoru, displejā parādās 0, tiek saglabāts 1. operands. Pēc tam ievada 2. operandu un veic aprēķinus.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void input_digit(int digit)
        {
            if (operation == "")
            {
                operand1 = operand1 * 10 + digit;
                display.Text = operand1.ToString();
            }
            else
            {
                operand2 = operand2 * 10 + digit;
                display.Text += digit.ToString();
            }
        }


        private void Button_digit_1_Click(object sender, RoutedEventArgs e)
        {
            input_digit(1);

        }

        private void Button_digit_2_Click(object sender, RoutedEventArgs e)
        {
            input_digit(2);

        }

        private void Button_digit_3_Click(object sender, RoutedEventArgs e)
        {
            input_digit(3);


        }

        private void Button_digit_4_Click(object sender, RoutedEventArgs e)
        {
            input_digit(4);

        }

        private void Button_digit_5_Click(object sender, RoutedEventArgs e)
        {
            input_digit(5);

        }

        private void Button_digit_6_Click(object sender, RoutedEventArgs e)
        {
            input_digit(6);

        }

        private void Button_digit_7_Click(object sender, RoutedEventArgs e)
        {
            input_digit(7);

        }

        private void Button_digit_8_Click(object sender, RoutedEventArgs e)
        {
            input_digit(8);

        }

        private void Button_digit_9_Click(object sender, RoutedEventArgs e)
        {
            input_digit(9);

        }

        private void Button_digit_0_Click(object sender, RoutedEventArgs e)
        {
            input_digit(0);

        }

        private void Button_operation_plus_Click(object sender, RoutedEventArgs e)
        {
			if(!is_textbox_empty())
			{
				if (!is_last_character_operator())
				{
					display.Text += "+";
					operation = "+";
				}
			}

        }

        private void Button_operation_minus_Click(object sender, RoutedEventArgs e)
        {
			if (!is_textbox_empty())
			{
				if (!is_last_character_operator())
				{
					display.Text += "-";
					operation = "-";
				}
			}
		}

        private void Button_operation_multiply_Click(object sender, RoutedEventArgs e)
        {
			if (!is_textbox_empty())
			{
				if (!is_last_character_operator())
				{
					display.Text += "*";
					operation = "*";
				}
			}

		}

        private void Button_operation_division_Click(object sender, RoutedEventArgs e)
        {
			if (!is_textbox_empty())
			{
				if (!is_last_character_operator())
				{
					display.Text += "/";
					operation = "/";
				}
			}
		}

		private bool is_textbox_empty()
		{
			if (this.display.Text.Length == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private bool is_last_character_operator()
		{ 

			char last_character = display.Text[display.Text.Length - 1];


			if (last_character.Equals('+') || last_character.Equals('-') || last_character.Equals('/') ||
				last_character.Equals('*') || last_character.Equals('%') || last_character.Equals('^'))
			{
				Console.WriteLine($"Last character:{last_character} ");
				return true;
			}
			else
			{
				return false;
			}
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
