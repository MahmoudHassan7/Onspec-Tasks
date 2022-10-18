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

namespace Calculate_age
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime birthday = datepicker.SelectedDate.Value.Date;
                CalculateAge calc = new CalculateAge();
                String res= calc.Calculateage(birthday);
                result.Content = res;
                result.Foreground = Brushes.Green;
            }
            catch(Exception ex)
            {
                result.Content = ex.Message;
                result.Foreground = Brushes.Red;
            }
            
            
        }
    }
}
