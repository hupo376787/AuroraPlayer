using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Aurora_Player
{
    class DirectoryHelper
    {
        //http://www.cnblogs.com/ahdung/p/4104217.html?utm_source=tuicool&utm_medium=referral4

        /// <summary>
        /// 获取指定目录中的匹配项（文件或目录）
        /// </summary>
        /// <param name="dir">要搜索的目录</param>
        /// <param name="regexPattern">项名模式（正则）。null表示忽略模式匹配，返回所有项</param>
        /// <param name="depth">递归深度。负数表示不限，0表示仅顶级</param>
        /// <param name="throwEx">是否抛异常</param>
        /// <returns></returns>
        public static string[] GetFileSystemEntries(string dir, string regexPattern = null, int depth = 0, bool throwEx = false)
        {
            List<string> lst = new List<string>();

            try
            {
                foreach (string item in Directory.GetFileSystemEntries(dir))
                {
                    try
                    {
                        if (regexPattern == null || Regex.IsMatch(Path.GetFileName(item), regexPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        { lst.Add(item); }

                        //递归
                        if (depth != 0 && (File.GetAttributes(item) & FileAttributes.Directory) == FileAttributes.Directory)
                        { lst.AddRange(GetFileSystemEntries(item, regexPattern, depth - 1, throwEx)); }
                    }
                    catch { if (throwEx) { throw; } }
                }
            }
            catch { if (throwEx) { throw; } }

            return lst.ToArray();
        }

        /// <summary>
        /// 获取指定目录中的匹配文件
        /// </summary>
        /// <param name="dir">要搜索的目录</param>
        /// <param name="regexPattern">文件名模式（正则）。null表示忽略模式匹配，返回所有文件</param>
        /// <param name="depth">递归深度。负数表示不限，0表示仅顶级</param>
        /// <param name="throwEx">是否抛异常</param>
        /// <returns></returns>
        public static string[] GetFiles(string dir, string regexPattern = null, int depth = 0, bool throwEx = false)
        {
            List<string> lst = new List<string>();

            try
            {
                foreach (string item in Directory.GetFileSystemEntries(dir))
                {
                    try
                    {
                        bool isFile = (File.GetAttributes(item) & FileAttributes.Directory) != FileAttributes.Directory;

                        if (isFile && (regexPattern == null || Regex.IsMatch(Path.GetFileName(item), regexPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline)))
                        { lst.Add(item); }

                        //递归
                        if (depth != 0 && !isFile) { lst.AddRange(GetFiles(item, regexPattern, depth - 1, throwEx)); }
                    }
                    catch { if (throwEx) { throw; } }
                }
            }
            catch { if (throwEx) { throw; } }

            return lst.ToArray();
        }

        /// <summary>
        /// 获取指定目录中的匹配目录
        /// </summary>
        /// <param name="dir">要搜索的目录</param>
        /// <param name="regexPattern">目fu录名模式（正则）。null表示忽略模式匹配，返回所有目录</param>
        /// <param name="depth">递归深度。负数表示不限，0表示仅顶级</param>
        /// <param name="throwEx">是否抛异常</param>
        /// <returns></returns>
        public static string[] GetDirectories(string dir, string regexPattern = null, int depth = 0, bool throwEx = false)
        {
            List<string> lst = new List<string>();

            try
            {
                foreach (string item in Directory.GetDirectories(dir))
                {
                    try
                    {
                        if (regexPattern == null || Regex.IsMatch(Path.GetFileName(item), regexPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        { lst.Add(item); }

                        //递归
                        if (depth != 0) { lst.AddRange(GetDirectories(item, regexPattern, depth - 1, throwEx)); }
                    }
                    catch { if (throwEx) { throw; } }
                }
            }
            catch { if (throwEx) { throw; } }

            return lst.ToArray();
        }
    }
}
