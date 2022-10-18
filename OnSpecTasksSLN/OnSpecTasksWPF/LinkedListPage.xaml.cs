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
    public partial class LinkedListPage : Page
    {
        public LinkedListPage()
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
                    (sender as TextBox).Text = "Insert The list comma seprated e.g: 1,2,3";
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
                    (sender as TextBox).Text = "Insert N as a number e.g.: 1";
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

        private void GetHeadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool error = false;
                ResultText.Text = "";
                if (TargetTextBox.Text != "Insert N as a number e.g.: 1" 
                    && ListTextBox.Text != "Insert The list comma seprated e.g: 1,2,3")
                {
                    List<int> numbers = new List<int>();
                    foreach (string s in ListTextBox.Text.Split(','))
                    {
                        if (int.Parse(s) <= 100)
                            numbers.Add(int.Parse(s));
                        else
                            error = true;
                    }
                    if (1 <= numbers.Count && numbers.Count <= 30 && int.Parse(TargetTextBox.Text) <= numbers.Count && !error)
                    {
                        numbers.RemoveAt(numbers.Count - int.Parse(TargetTextBox.Text));
                        ResultText.Text = $"Head = [{string.Join(",", numbers)}]";
                    }
                    else
                        MessageBox.Show("");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
