using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace WpfApp2
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

            DBSinglton.creatDbIfNotExists();
            DBSinglton._ConnectionString = "Data Source=MyDatabase.sqlite;Version=3;";

            DBSinglton._Query = "CREATE TABLE IF NOT EXISTS customers (id INT PRIMARY KEY , name TEXT, email TEXT);CREATE TABLE IF NOT EXISTS orders (id INT PRIMARY KEY , customer_id INT, total REAL, order_date TEXT,  FOREIGN KEY(customer_id) REFERENCES customers(id));";
            SQLiteConnection c = DBSinglton.CreateConnection();
            DBSinglton.ExecuteQuery(c);

            DBSinglton._Query = $"INSERT OR IGNORE INTO 'customers' (id,name,email) VALUES";
            for (int i = 0; i < 5; i++)
            {
                DBSinglton._Query += $"('{i}','N{i}','E{i}'),";

            }
            DBSinglton._Query = DBSinglton._Query.Remove(DBSinglton._Query.Length - 1, 1);
            DBSinglton._Query += ";";
            DBSinglton.ExecuteQuery(c);

            DBSinglton._Query = "SELECT  * FROM customers";
            DBSinglton.ExecuteQuery(c);

            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(DBSinglton._sqliteCmd);
            DataTable dataTable = new DataTable("customers");

            sQLiteDataAdapter.Fill(dataTable);
            CustomerGrid.ItemsSource = dataTable.DefaultView;
            sQLiteDataAdapter.Update(dataTable);

            DBSinglton.closeConnection();
            c.Close();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
            //this.Close();
        }

    }
}
