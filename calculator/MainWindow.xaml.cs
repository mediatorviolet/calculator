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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string total = "0";
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

        private void Handle_Operator(object sender, RoutedEventArgs e)
        {
            char[] operators = {'/', '*', '-', '+'};
            char c = total.Last();
            int pos = Array.IndexOf(operators, c);
            System.Diagnostics.Debug.WriteLine("----------------------------");
            System.Diagnostics.Debug.WriteLine(c);
            System.Diagnostics.Debug.WriteLine(pos);

            Button b = (Button)sender;
            if (pos == -1)
            {
                switch (b.Content)
                {
                    case "/":
                        total += "/";
                        System.Diagnostics.Debug.WriteLine(total);
                        break;
                    case "*":
                        total += "*";
                        System.Diagnostics.Debug.WriteLine(total);
                        break;
                    case "-":
                        total += "-";
                        System.Diagnostics.Debug.WriteLine(total);
                        break;
                    case "+":
                        total += "+";
                        System.Diagnostics.Debug.WriteLine(total);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Divide(string s)
        {
            int acc = 0;
            char op = '/';

            while (s.Contains(op))
            {
                int iOp = s.IndexOf(op);
                acc += s[iOp - 1] / s[iOp + 1];
                System.Diagnostics.Debug.WriteLine(iOp);
                s = s.Remove(iOp - 1, 3);
                s = s.Insert(iOp - 1, acc.ToString());
                acc = 0;
            }
            System.Diagnostics.Debug.WriteLine(s);
        }

        private int DivideAndMultiply(string c)
        {
            int acc = 0;
            char[] operators = { '/', '*' };
            while(c.Contains(operators[0]) || c.Contains(operators[1]))
            {
                int operatorIndex = c.IndexOf('/');
            }
            return 0;
        }

        private void Evaluate(object sender, RoutedEventArgs e)
        {
            Divide(total);
        }
    }
}
