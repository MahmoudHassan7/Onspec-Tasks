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

namespace OnSpecTasksWPF
{
    /// <summary>
    /// Interaction logic for ArrayPage.xaml
    /// </summary>
    public partial class ArrayPage : Page
    {
        public ArrayPage()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                (sender as TextBox).Text = "";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((sender as TextBox).Text))
                    (sender as TextBox).Text = "Insert The numbers comma seprated e.g: 1,2,3";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((sender as TextBox).Text))
                    (sender as TextBox).Text = "Insert The Target as a number e.g.: 1";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void TextBox_KeyDown_Target(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.Key.ToString().Contains("NumPad") || e.Key.ToString().Contains("D")) && char.IsNumber(e.Key.ToString(), e.Key.ToString().Length - 1))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void TextBox_KeyDown_Array(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.Key.ToString().Contains("NumPad") || e.Key.ToString().Contains("D")) && char.IsNumber(e.Key.ToString(), e.Key.ToString().Length - 1))
                    e.Handled = false;
                else if (e.Key.ToString().Contains("Comma"))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private void GetIndicesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultText.Text = "";
                if (TargetTextBox.Text != "Insert The Target as a number e.g.: 1" 
                    && ArrayTextBox.Text != "Insert The numbers comma seprated e.g: 1,2,3")
                {
                    List<int> numbers = new List<int>();
                    foreach (string s in ArrayTextBox.Text.Split(','))
                        numbers.Add(int.Parse(s));

                    var query = numbers
                                  .SelectMany((num1, j) => numbers.Select((num2, i) => new { n1 = num1, n2 = num2, i = i, j = j }))
                                  .Where(x => x.n1 + x.n2 == int.Parse(TargetTextBox.Text) && x.i < x.j);

                    foreach (var x in query)
                        ResultText.Text += (x.n1 + " and " + x.n2 + " occur at " + x.i + "," + x.j + "\n");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
