using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void listViewItem_Selected(object sender, RoutedEventArgs e)
        {
            PagesFrame.Navigate(new Uri(@"/MainPage.xaml", UriKind.RelativeOrAbsolute));
            PagesFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void listViewItem1_Selected(object sender, RoutedEventArgs e)
        {
            PagesFrame.Source = new Uri(@"/ArrayPage.xaml", UriKind.RelativeOrAbsolute);
            PagesFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }


        private void listViewItem2_Selected(object sender, RoutedEventArgs e)
        {
            PagesFrame.Source = new Uri(@"/LinkedListPage.xaml", UriKind.RelativeOrAbsolute);
            PagesFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void listViewItem3_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Check Out the SQL_Query.SQL File Attached to the project files");
        }

        private void listViewItem4_Selected(object sender, RoutedEventArgs e)
        {
            PagesFrame.Source = new Uri(@"/FindMyAge.xaml", UriKind.RelativeOrAbsolute);
            PagesFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
    }
}
