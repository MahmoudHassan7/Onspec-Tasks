using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // "AS" keyword dose not work with me XD
            SQLiteConnection c = DBSinglton.CreateConnection();
            DBSinglton._Query = "SELECT name,  email FROM customers INNER JOIN (SELECT * FROM (SELECT * FROM orders WHERE total > 1000 GROUP By 2 HAVING count(*) >= 2)) ON customer_id = customers.id;";
            DBSinglton.ExecuteQuery(c);

            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(DBSinglton._sqliteCmd);
            DataTable dataTable = new DataTable();

            sQLiteDataAdapter.Fill(dataTable);
            qGrid.ItemsSource = dataTable.DefaultView;
            sQLiteDataAdapter.Update(dataTable);

            DBSinglton.closeConnection();
            c.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            test.Content = "Write a SQL query to retrieve the names and email addresses of customers \r\n" +
                "who haveplaced at least two orders with a total value greater than $1000.\r\n" +
                "SELECT name,  email FROM customers \r\n " +
                "INNER JOIN \r\n" +
                "(SELECT * FROM (SELECT * FROM orders WHERE total > 1000 GROUP By 2 HAVING count(*) >= 2)) \r\n" +
                "ON customer_id = customers.id;";
        }
    }
}
