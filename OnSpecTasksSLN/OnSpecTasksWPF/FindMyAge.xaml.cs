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
    /// Interaction logic for FindMyAge.xaml
    /// </summary>
    public partial class FindMyAge : Page
    {
        public FindMyAge()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OnSpecCalender.SelectedDate != null)
                {
                    Result.Text = "";
                    Result.Text = $"Your current age is {Get_Age(OnSpecCalender.SelectedDate.Value)}";
                }
                else
                    MessageBox.Show("There is no selected date");
            }
            catch(Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }

        private static string Get_Age(DateTime dob)
        {
            DateTime today = DateTime.Today;

            int months = today.Month - dob.Month;
            int years = today.Year - dob.Year;

            if (today.Day < dob.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (today - dob.AddMonths((years * 12) + months)).Days;

            return string.Format("{0} year{1}, {2} month{3} and {4} day{5}",
                                 years, (years == 1) ? "" : "s",
                                 months, (months == 1) ? "" : "s",
                                 days, (days == 1) ? "" : "s");
        }
    }
}
