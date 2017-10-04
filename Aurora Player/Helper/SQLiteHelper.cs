using System.Data.SQLite;

namespace Aurora_Player
{
    class SQLiteHelper
    {
        public static SQLiteConnection CreateSQLiteConnection(string str_db_path)
        {
            string str_conn = "Data Source=" + str_db_path + "; Version=3";
            SQLiteConnection SQLiteConn = new SQLiteConnection(str_conn);
            SQLiteConn.Open();
            return SQLiteConn;
        }
    }
}
