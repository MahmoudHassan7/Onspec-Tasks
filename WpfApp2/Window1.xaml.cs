using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 w = new Window2();
            w.Show();
            //this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteConnection c = DBSinglton.CreateConnection();
            System.Random rand = new System.Random();
            DBSinglton._Query = $"INSERT OR IGNORE INTO 'orders' (id,customer_id,total,order_date) VALUES";

            for (int i = 0; i < 50; i++)
            {
                DBSinglton._Query += $"('{i}','{rand.Next(0,5)}','{rand.Next(500, 10000)}','D{i}'),";

            }
            DBSinglton._Query = DBSinglton._Query.Remove(DBSinglton._Query.Length - 1, 1);
            DBSinglton._Query += ";";
            DBSinglton.ExecuteQuery(c);

            DBSinglton._Query = "SELECT  * FROM orders";
            DBSinglton.ExecuteQuery(c);

            SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(DBSinglton._sqliteCmd);
            DataTable dataTable = new DataTable("orders");

            sQLiteDataAdapter.Fill(dataTable);
            ordersGrid.ItemsSource = dataTable.DefaultView;
            sQLiteDataAdapter.Update(dataTable);

            DBSinglton.closeConnection();
            c.Close();
        }
    }
}
