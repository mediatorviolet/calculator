using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string total = "0";
        private string subTotal;
        public MainWindow()
        {
            InitializeComponent();

            // Initialize ResultViewer
            ResultViewer.Text = total;
        }

        private void HandleBackspace_Btn(object sender, RoutedEventArgs e)
        {
            if (total != "0" && total.Length > 0)
            {
                total = total.Remove(total.Length - 1);
            }

            if (total.Length == 0)
            {
                total = "0";
            }

            ResultViewer.Text = total;

        }

        private void HandleCE_Btn(object sender, RoutedEventArgs e)
        {
            total = "0";
            ResultViewer.Text = total;
        }

        private void HandleC_Btn(object sender, RoutedEventArgs e)
        {
            total = "0";
            ResultViewer.Text = total;
        }

        private void Handle_int(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (total == "0")
            {
                total = "";
            }

            total += b.Content;
            ResultViewer.Text = total;
        }

        private void Handle_Operatorr(object sender, RoutedEventArgs e)
        {
            char[] operators = { '/', '*', '-', '+' };
            char c = total.Last();
            int pos = Array.IndexOf(operators, c);
            Button b = (Button)sender;

            subTotal = total + b.Content;
            total = "";
        }

        private void Handle_Operator(object sender, RoutedEventArgs e)
        {
            char[] operators = { '/', '*', '-', '+' };
            char c = total.Last();
            int pos = Array.IndexOf(operators, c);
            /*System.Diagnostics.Debug.WriteLine("----------------------------");
            System.Diagnostics.Debug.WriteLine(c);
            System.Diagnostics.Debug.WriteLine(pos);*/
            int iOp;

            Button b = (Button)sender;
            if (!operators.Any(total.Contains))
            {
                subTotal = total + b.Content;
                total = "";
                System.Diagnostics.Debug.WriteLine(total);
            }
            else
            {
                if (total.Contains("+"))
                {
                    iOp = total.IndexOf("+");
                }
                else if (total.Contains("-"))
                {
                    iOp = total.IndexOf("-");
                }
                else if (total.Contains("*"))
                {
                    iOp = total.IndexOf("*");
                }
                else if (total.Contains("/"))
                {
                    iOp = total.IndexOf("/");
                }
                else
                {
                    iOp = -1;
                }
                double op1 = Convert.ToDouble(total[..iOp]);
                double op2 = Convert.ToDouble(total.Substring(iOp + 1, total.Length - 2));

                if (total.Contains('+'))
                {
                    total = (op1 + op2).ToString() + b.Content;
                }
                else if (total.Contains('-'))
                {
                    total = (op1 - op2).ToString() + b.Content;
                }
                else if (total.Contains('*'))
                {
                    total = (op1 * op2).ToString() + b.Content;
                }
                else if (total.Contains('/'))
                {
                    total = (op1 / op2).ToString() + b.Content;
                }
            }
            System.Diagnostics.Debug.WriteLine(total);
            ResultViewer.Text = total;
        }

        private void Result()
        {
            string op;
            int iOp = 0;

            if (total.Contains("+"))
            {
                iOp = total.IndexOf("+");
            }
            else if (total.Contains("-"))
            {
                iOp = total.IndexOf("-");
            }
            else if (total.Contains("*"))
            {
                iOp = total.IndexOf("*");
            }
            else if (total.Contains("/"))
            {
                iOp = total.IndexOf("/");
            }
            else
            {
                // Error
            }

            op = total.Substring(iOp, 1);
            double op1 = Convert.ToDouble(total.Substring(0, iOp));
            double op2 = Convert.ToDouble(total.Substring(iOp + 1, total.Length - iOp - 1));

            switch (op)
            {
                case "+":
                    total += "=" + (op1 + op2);
                    break;
                case "-":
                    total += "=" + (op1 - op2);
                    break;
                case "*":
                    total += "=" + (op1 * op2);
                    break;
                case "/":
                    total += "=" + (op1 / op2);
                    break;
                default:
                    break;
            }
            ResultViewer.Text = total;
        }

        private void Evaluate(object sender, RoutedEventArgs e)
        {
            try
            {
                Result();
            }
            catch (Exception ex)
            {
                ResultViewer.Text = "Error: " + ex;
            }
        }
    }
}
