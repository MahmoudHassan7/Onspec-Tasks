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

namespace Question3_project
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

        private void Calc_Age_Btn_Clk(object sender, RoutedEventArgs e)
        {
            if (birthdatePicker.SelectedDate == null)
                Age_Output.Text = "NO BirthDate Selected";
            else
            {
                DateTime birthdate = birthdatePicker.SelectedDate.Value;
                if (birthdate > DateTime.Today)
                {
                    Age_Output.Text = "NOT Vaild BirthDate";
                }
                else
                {
                    // https://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-based-on-a-datetime-type-birthday
                    int Day_Age = DateTime.Today.Day - birthdate.Day;
                    int Month_Age = DateTime.Today.Month - birthdate.Month;
                    int Year_Age = DateTime.Today.Year - birthdate.Year;


                    if (DateTime.Today.Month < birthdate.Month || (DateTime.Today.Month == birthdate.Month && DateTime.Today.Day < birthdate.Day))
                    {
                        Year_Age--;
                        Month_Age += 12;
                    }
                    if (Day_Age < 0)
                    {
                        int daysInMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
                        Day_Age += daysInMonth;
                        Month_Age--;
                    }

                    // Output the age
                    Age_Output.Text = $"Your current age is\n {Year_Age} years, {Month_Age} months, {Day_Age} days";
                }
            }
        }
    }
}
