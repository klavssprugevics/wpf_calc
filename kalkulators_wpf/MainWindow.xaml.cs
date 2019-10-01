using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	// Code is 90% from previous homework - windows form app calculator.

    public partial class MainWindow : Window
    {
		double operand1 = double.NaN;       // 1st operand, parsed after selecting an operation.
		double operand2 = double.NaN;       // 2nd operand, parsed after pressing "=" button.
		char operation;                     // Operation selected by the user with buttons.
		double result;                      // Result after an operation, afterwards Operand1 = result.

		string input = string.Empty;        // String that's being parsed into operand1/operand2.



		// All digit button click events definded here.
		private void Button_digit_1_Click(object sender, RoutedEventArgs e)
		{
			input += "1";
			this.display.Text += "1";
		}

		private void Button_digit_2_Click(object sender, RoutedEventArgs e)
		{
			input += "2";
			this.display.Text += "2";
		}

		private void Button_digit_3_Click(object sender, RoutedEventArgs e)
		{
			input += "3";
			this.display.Text += "3";
		}

		private void Button_digit_4_Click(object sender, RoutedEventArgs e)
		{
			input += "4";
			this.display.Text += "4";
		}

		private void Button_digit_5_Click(object sender, RoutedEventArgs e)
		{
			input += "5";
			this.display.Text += "5";
		}

		private void Button_digit_6_Click(object sender, RoutedEventArgs e)
		{
			input += "6";
			this.display.Text += "6";
		}

		private void Button_digit_7_Click(object sender, RoutedEventArgs e)
		{
			input += "7";
			this.display.Text += "7";
		}

		private void Button_digit_8_Click(object sender, RoutedEventArgs e)
		{
			input += "8";
			this.display.Text += "8";
		}

		private void Button_digit_9_Click(object sender, RoutedEventArgs e)
		{
			input += "9";
			this.display.Text += "9";
		}

		private void Button_digit_0_Click(object sender, RoutedEventArgs e)
		{
			input += "0";
			this.display.Text += "0";
		}

		private void Button_utility_floating_point_Click(object sender, RoutedEventArgs e)
		{
			if (is_last_character_operator())
			{
				return;
			}

			if (!this.display.Text.EndsWith("."))
			{
				this.display.Text += ".";
				input += ".";
			}
		}





		// All basic operation button click events defined here.
		private void Button_operation_plus_Click(object sender, RoutedEventArgs e)
		{
			// Doesnt allow to add just an operator to the input, in case first input is "-" = a negative number,
			// Changing the operation not allowed.
			if (input.Equals("") || input.Equals("-"))
			{
				return;
			}

			if (is_last_character_operator())
			{
				// If the user wants to change the operator, they can just change by pressing on a different one.
				this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1);
				this.display.Text += "+";
				operation = '+';
				return;
			}
			parse_two_operand_operation('+');
		}

		private void Button_operation_minus_Click(object sender, RoutedEventArgs e)
		{
			if (input.Equals(""))
			{
				input += "-";
				this.display.Text += "-";
				Console.WriteLine("First operand is negative!");
				return;
			}
			else if (is_last_character_operator() && operand1 != double.NaN)
			{
				this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1);
				this.display.Text += "-";
				operation = '-';
				return;
			}
			parse_two_operand_operation('-');
		}

		private void Button_operation_multiply_Click(object sender, RoutedEventArgs e)
		{
			if (input.Equals("") || input.Equals("-"))
			{
				return;
			}

			if (is_last_character_operator())
			{
				Console.WriteLine($"op1:{operand1} ");
				this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1);
				this.display.Text += "*";
				operation = '*';
				return;
			}
			parse_two_operand_operation('*');
		}

		private void Button_operation_division_Click(object sender, RoutedEventArgs e)
		{
			if (input.Equals("") || input.Equals("-"))
			{
				return;
			}

			if (is_last_character_operator())
			{
				this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1);
				this.display.Text += "/";
				operation = '/';
				return;
			}
			parse_two_operand_operation('/');
		}


		// All operations that require two operands are defined here.
		private void parse_two_operand_operation(char oper)
		{
			Console.WriteLine($"operand: {operand1}");
			Console.WriteLine("input: " + input);

			string negative_number_regex = @"^-\d+(\.)?(\d+)?";

			if (operand1.Equals(double.NaN) && input.Equals(""))
			{
				return;
			}
			else if (input.Equals(""))
			{
				this.display.Text = display.Text + oper;
				operation = oper;
			}
			else if (Regex.IsMatch(input, negative_number_regex))
			{
				input.Remove(0);
				operand1 = Double.Parse(input);
				this.display.Text = display.Text + oper;
				operation = oper;
				input = string.Empty;
			}
			else
			{
				operand1 = Double.Parse(input);
				this.display.Text = display.Text + oper;
				operation = oper;
				input = string.Empty;
			}
		}

		// Main function for calculating the result after "=" is clicked.
		private void Button_result_Click(object sender, RoutedEventArgs e)
		{
			// Checks whether the input(2nd operand) is empty.
			if (input == "" || input == "-")
			{
				return;
			}

			operand2 = Double.Parse(input);
			bool math_error = false;

			switch (operation)
			{
				case '+':
					result = operand1 + operand2;
					break;
				case '-':
					result = operand1 - operand2;
					break;
				case '*':
					result = operand1 * operand2;
					break;
				case '%':
					result = operand1 % operand2;
					break;
				case '^':
					result = Math.Pow(operand1, operand2);
					break;
				case '/':
					if (operand2 == 0)
					{
						math_error = true;
					}
					else
					{
						result = operand1 / operand2;
					}
					break;
				default:
					{
						return;
					}
			}

			if (math_error)
			{
				MessageBox.Show("MATH ERROR");
				this.display.Text = string.Empty;
				input = string.Empty;
				operand1 = double.NaN;
				operand2 = double.NaN;
			}
			else
			{
				operand1 = result;
				operation = ' ';

				this.display.Text = string.Concat(result);
				input = string.Concat(result);
			}
		}







		// Completely wipes everything except for the history.
		private void Button_utility_clear_all_Click(object sender, RoutedEventArgs e)
		{
			this.display.Text = string.Empty;
			input = string.Empty;
			operand1 = double.NaN;
			operand2 = double.NaN;
		}

		// Deletes the last character in the input (not operand).
		private void Button_utility_clear_last_element_Click(object sender, RoutedEventArgs e)
		{
			if (is_textbox_empty())
			{
				return;
			}

			if (is_last_character_operator() == false && input.Length != 0)
			{
				input = input.Remove(input.Length - 1);
			}
			this.display.Text = this.display.Text.Remove(this.display.Text.Length - 1);
		}

		// Deletes the last operand.
		private void Button_utility_clear_last_Click(object sender, RoutedEventArgs e)
		{
			if(!is_textbox_empty() && input.Length != 0)
			{
				// Removes only the text that containts the current operand.
				display.Text = display.Text.Remove(display.Text.Length - input.Length, input.Length);
				input = "";

			}
			else
			{
				return;

			}
		}

		// Reverses the sign of the active operand.
		private void Button_utility_reverse_Click(object sender, RoutedEventArgs e)
		{
			// TODO: Reverse only works with positive numbers.
			// You can only reverse one number (first operand) i.e. you cannot reverse the sign for a whole equation.
			if (!is_textbox_empty() && input.Length != 0)
			{
				double temp = double.Parse(input);
				Console.WriteLine($"Input: {input}");
				Console.WriteLine($"Operator: {operation}");

				if(temp > 0)
				{
					display.Text = display.Text.Insert(display.Text.Length-1, "-");

				}
				else if(temp < 0)
				{
					display.Text = display.Text.Remove(display.Text.Length);
				}
				temp = temp * (-1);
				input = temp.ToString();

			}
		}




		// Helper functions.
		// Checks whether the textbox is empty.
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

		// Checks whether the last character in the textbox is an operator.
		private bool is_last_character_operator()
		{
			if (is_textbox_empty())
			{
				Console.WriteLine("TextBox is empty!");
				return true;
			}
			char last_character = this.display.Text[this.display.Text.Length - 1];


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


	}
}
