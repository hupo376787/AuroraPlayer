using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Aurora_Player
{
    class MySqlHelper
    {
        //西部数码MySql     到期时间： 2016-07-26
        public static string str_Server = "";
        static string str_UserID = "";
        static string str_Password = "";
        static string str_Database = "";
        static string str_Port = "";

        public static MySqlConnection CreateMySqlConnection()
        {
            string str_Conn = String.Format("server={0};user id={1}; password={2}; database={3}; port={4}; pooling=false",
                str_Server, str_UserID, str_Password, str_Database, str_Port);
            MySqlConnection MySql_Conn = null;
            try
            {
                MySql_Conn = new MySqlConnection(str_Conn);
                MySql_Conn.Open();
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show("Error connecting to the server: " + ex.Message);
                AuroraMessageBox msg = null;
                msg = new AuroraMessageBox();
                msg.strCaption = "Aurora智能提示";
                msg.strMessage = "Aurora 服务器偷了个小懒, 请稍后再试.";
                msg.strButtonText = "确定";
                msg.StartPosition = FormStartPosition.CenterScreen;
                msg.ShowDialog();

                return null;
            }
            return MySql_Conn;
        }
    }
}
