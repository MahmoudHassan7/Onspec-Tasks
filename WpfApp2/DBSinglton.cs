using System;
using System.Data.SQLite;
using System.Windows;

namespace WpfApp2
{
    static class DBSinglton
    {
        static private SQLiteConnection sqlite_conn;
        static private string ConnectionString;
        static private string Query;
        static private SQLiteCommand sqliteCmd;

        public static void creatDbIfNotExists()
        {
            if (!System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "MyDatabase.sqlite"))
            {
                try
                {
                    SQLiteConnection.CreateFile("MyDatabase.sqlite");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex+"");
                }
                
            }
                
        }

        public static SQLiteConnection CreateConnection()
        {
            // Create a new database connection:

            try
            {
                sqlite_conn = new SQLiteConnection(ConnectionString);
                sqlite_conn.Open();
                return sqlite_conn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
                return sqlite_conn;
            }
            
        }

        public static void ExecuteQuery(SQLiteConnection con)
        {

            try
            {
                sqliteCmd = con.CreateCommand();
                sqliteCmd.CommandText = Query;
                sqliteCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }


        }

        public static void closeConnection()
        {
            sqlite_conn.Close();
        }

        public static string _ConnectionString
        {
            get { return ConnectionString; }
            set { ConnectionString = value; }
        }

        public static string _Query
        {
            get { return Query; }
            set { Query = value; }
        }

        public static SQLiteCommand _sqliteCmd
        {
            get { return sqliteCmd; }
            set { sqliteCmd = value; }
        }
    }
}
