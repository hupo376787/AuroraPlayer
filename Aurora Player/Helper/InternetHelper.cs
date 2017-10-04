using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

namespace Aurora_Player
{
    class InternetHelper
    {
        public static bool IsConnectedToInternet()
        {
            DateTime dt = DateTime.Now;
            Ping ping = new Ping();
            PingOptions poptions = new PingOptions();
            poptions.DontFragment = true;
            string data = string.Empty;
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2000;
            try
            {
                //PingReply reply = ping.Send("https://www.baidu.com/", timeout);//一定要加上http://，否则ping执行的很慢!!!!!!
                PingReply reply = ping.Send(MySqlHelper.str_Server, timeout, buffer, poptions); //云数据库
                if (reply.Status == IPStatus.Success)
                    return true;
            }
            catch
            {
                DateTime dt1 = DateTime.Now;
                Console.WriteLine((dt1 - dt).TotalMilliseconds);
                return false;
            }
            //DateTime dt1 = DateTime.Now;
            //Console.WriteLine((dt1 - dt).TotalMilliseconds);
            return false;
        }

        public static bool isConn()
        {
            Ping ping;
            PingReply res;
            ping = new Ping();
            try
            {
                res = ping.Send("http://www.baidu.com");
                if (res.Status != IPStatus.Success)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsHostAlive()
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            TcpClient tc = new TcpClient();
            tc.SendTimeout = 2000;
            tc.ReceiveTimeout = 2000;
            bool isAlive;
            try
            {
                tc.Connect(MySqlHelper.str_Server, 80);
                isAlive = true;
            }
            catch
            {
                isAlive = false;
            }
            finally
            {
                tc.Close();
            }
            Console.WriteLine("测试网络是否连接耗时 " + st.ElapsedMilliseconds);
            return isAlive;
        }
    }
}
