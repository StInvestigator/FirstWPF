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

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isAnsw = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNumberClick(object sender, RoutedEventArgs e)
        {
            if((sender as Button).Content.ToString()[0] >= '0'&& (sender as Button).Content.ToString()[0] <= '9' && isAnsw == true)
            {
                TBBottom.Text = "";
            }
            TBBottom.Text += (sender as Button).Content;
            isAnsw = false;
        }

        private void ButtonBackClick(object sender, RoutedEventArgs e)
        {
            if(TBBottom.Text!="")
            TBBottom.Text = TBBottom.Text.Remove(TBBottom.Text.Length-1);
        }
        private void ButtonCEClick(object sender, RoutedEventArgs e)
        {
            TBBottom.Text = "";
        }

        private void ButtonCClick(object sender, RoutedEventArgs e)
        {
            TBBottom.Text = "";
            TBTop.Text = "";
        }
        private void ButtonEqualClick(object sender, RoutedEventArgs e)
        {
            if (TBBottom.Text[0]=='0' && TBBottom.Text[1] != '.')
            {
                MessageBox.Show("Wrong input!","Error",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            List<double> numbers = new List<double>();
            string txt = "";
            char prev = '0';
            foreach (var item in TBBottom.Text +"/")
            {
                if(item >= '0' && item <= '9' || item == ',')
                {
                    txt += item;
                    continue;
                }
                else if (prev == '*')
                {
                    numbers[numbers.Count - 1] *= Convert.ToDouble(txt);
                }
                else if (prev == '/')
                {
                    numbers[numbers.Count - 1] /= Convert.ToDouble(txt);
                }
                else if (prev == '-')
                {
                    numbers.Add(-Convert.ToDouble(txt));
                }
                else if (prev == '+')
                {
                    numbers.Add(Convert.ToDouble(txt));
                }
                else
                {
                    try
                    {
                        numbers.Add(Convert.ToDouble(txt));
                    }
                    catch
                    {}
                }
                if (item == '+' || item == '-' || item == '*' || item == '/') 
                {
                    prev = item;
                }
                txt = "";
            }
            if (numbers.Count > 1)
            {
                TBTop.Text = TBBottom.Text;
            }
            TBBottom.Text = Math.Round(numbers.Sum(x => x), 8).ToString();
            isAnsw = true;
        }
    }
}