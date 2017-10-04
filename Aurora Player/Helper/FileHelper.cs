using System;
using System.IO;

namespace Aurora_Player
{
    class FileHelper
    {
        public static string GetAccurateTime(Int64 ms)
        {
            Int64 n_hour = 0;
            Int64 n_minute = 0;
            Int64 n_second = 0;
            string str_hour = "";
            string str_minute = "";
            string str_second = "";

            n_second = ms / 1000;
            if(n_second > 60)
            {
                n_minute = n_second / 60;
                n_second = n_second % 60;
            }
            if (n_minute > 60)
            {
                n_hour = n_minute / 60;
                n_minute = n_minute % 60;
            }

            if (n_second < 10)
                str_second = "0" + n_second.ToString();
            else
                str_second = n_second.ToString();
            if (n_minute < 10)
                str_minute = "0" + n_minute.ToString();
            else
                str_minute = n_minute.ToString();
            if (n_hour < 10)
                str_hour = "0" + n_hour.ToString();
            else
                str_hour = n_hour.ToString();

            return str_hour + ":" + str_minute + ":" + str_second;
        }

        public static string GetFileCreateTime(string str_file)
        {
            FileInfo fi = new FileInfo(str_file);
            return fi.CreationTime.ToString();
        }

        public static string GetFileLastAccessTime(string str_file)
        {
            FileInfo fi = new FileInfo(str_file);
            return fi.LastAccessTime.ToString();
        }

        public static void OpenSpecifiedFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }
    }
}
