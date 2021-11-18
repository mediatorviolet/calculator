using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double total = 0;
        private List<string> opHistory = new List<string>();
        private bool doneOp = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleBackspace_Btn(object sender, RoutedEventArgs e)
        {
            // Si ça marche pas on puet essayer de faire les opérations sur 
            // `ResultViewer.Text` et update `total` à la fin 
            if (total != 0)
            {
                total = Convert.ToDouble(total.ToString().Remove(ResultViewer.Text.Length - 1));
            }

            if (total.ToString().Length == 1)
            {
                total = 0;
            }
            UpdateViewer(total);
        }

        private void UpdateNum(double d)
        {
            if (total == 0 || doneOp)
            {
                total = d;
                doneOp = false;
            }
            else
            {
                total = Convert.ToDouble(total.ToString() + d);
            }
            UpdateViewer(total);
        }

        private void UpdateSign()
        {
            total = -total;
            UpdateViewer(total);
        }

        private void Handle_IntBtn(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            UpdateNum(Convert.ToDouble(b.Content.ToString()));
        }

        private void UpdateViewer(double d)
        {
            ResultViewer.Text = d.ToString();
        }

        private void HandleCE_Btn(object sender, RoutedEventArgs e)
        {
            HardReset();
        }

        private void HandleC_Btn(object sender, RoutedEventArgs e)
        {
            HardReset();
        }

        private void SoftReset()
        {
            total = 0;
            UpdateViewer(total);
        }

        private void HardReset()
        {
            SoftReset();
            opHistory.Clear();
        }

        private void Handle_Btn(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            switch (b.Content.ToString())
            {
                case "+/-":
                    UpdateSign();
                    break;
                case "+":
                    Operate(b.Content.ToString());
                    break;
                case "-":
                    Operate(b.Content.ToString());
                    break;
                case "*":
                    Operate(b.Content.ToString());
                    break;
                case "/":
                    Operate(b.Content.ToString());
                    break;
                default:
                    break;
            }
        }

        private void Operate(string o)
        {
            double tmpTotal = 0;
            opHistory.Add(total.ToString());

            if (opHistory.Count == 3)
            {
                switch (opHistory[1])
                {
                    case "+":
                        tmpTotal = Convert.ToDouble(opHistory[0]) + Convert.ToDouble(opHistory[2]);
                        break;
                    case "-":
                        tmpTotal = Convert.ToDouble(opHistory[0]) - Convert.ToDouble(opHistory[2]);
                        break;
                    case "*":
                        tmpTotal = Convert.ToDouble(opHistory[0]) * Convert.ToDouble(opHistory[2]);
                        break;
                    case "/":
                        if (opHistory[2] == "0")
                        {
                            SoftReset();
                            ResultViewer.Text = "Erreur : Division par 0... UwU";
                        }
                        else
                        {
                            tmpTotal = Convert.ToDouble(opHistory[0]) / Convert.ToDouble(opHistory[2]);
                        }
                        break;
                }
                opHistory.Clear();
                opHistory.Add(tmpTotal.ToString());
                total = tmpTotal;
                UpdateViewer(total);
                doneOp = true;
            }
            else
            {
                SoftReset();
            }

            opHistory.Add(o);
        }

        private void Evaluate(object sender, RoutedEventArgs e)
        {

        }
    }
}
