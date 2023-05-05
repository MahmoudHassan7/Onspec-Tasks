using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
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

        private void Data_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!data.SelectedDate.HasValue)
            {
                LabelCont.Content = "Select dates";
                return;
            }
            DateTime start = data.SelectedDate.Value.Date;
            DateTime finish = DateTime.Now;
            TimeSpan Span = finish - start;
            
            try
            {
                DateTime Age = DateTime.MinValue + Span;
                int Years = Age.Year - 1;
                int Months = Age.Month - 1;
                int Days = Age.Day - 1;
                LabelCont.Content = $"Your current age is \r\n {Years} years, {Months} months and {Days} days";
            }
            catch
            {
                LabelCont.Content = "Date error";
            }
            
        }
    }
}
