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

namespace KnowYourAge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            datePickerBirthday.SelectedDate = DateTime.Now;
            textResult.Content = "";
        }

        private void buttonCalc_Click(object sender, RoutedEventArgs e)
        {
            DateTime birthday = datePickerBirthday.SelectedDate ?? DateTime.Now;
            CalculateAge(birthday);
        }

        private void CalculateAge(DateTime birthday)
        {
            int birthDay = birthday.Day, birthMonth = birthday.Month,
                birthYear = birthday.Year;

            int currentDay = DateTime.Now.Day, currentMonth = DateTime.Now.Month,
                currentYear = DateTime.Now.Year;

            int[] daysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (birthDay > currentDay)
            {
                currentMonth--;
                currentDay += daysPerMonth[birthMonth - 1];
            }
            
            if (birthMonth > currentMonth)
            {
                currentYear--;
                currentMonth += 12;
            }

            int resultDays = currentDay - birthDay;
            int resultMoths = currentMonth - birthMonth;
            int resultYears = currentYear - birthYear;

            textResult.FontSize = 18;
            textResult.Content = String.Format("Your current age is {0} years, {1} months and {2} days",
                resultYears, resultMoths, resultDays);
        }
    }
}
