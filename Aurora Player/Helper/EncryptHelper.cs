using System;
using System.Text;
using System.Security.Cryptography;

namespace Aurora_Player
{
    class EncryptHelper
    {
        //16位MD5加密
        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        //32位MD5加密
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }

        //64位的MD5加密
        public static string MD5Encrypt64(string password)
        {
            string cl = password;
            //string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            return Convert.ToBase64String(s);
        }

        //SHA1加密
        public static string SHA1Encrypt(string password)
        {
            string result = "";
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(password);
            byte[] str2 = sha1.ComputeHash(str1);
            for (int i = 0; i < str2.Length; i++)
            {
                result += str2[i].ToString("X");
            }
            sha1.Clear();
            return result;
        }

        //SHA 512位加密
        public static string SHA512Encrypt(string password)
        {
            string result = "";
            SHA512 sha512 = new SHA512Managed();
            byte[] s = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < s.Length; i++)
            {
                result += s[i].ToString("X");
            }
            sha512.Clear();
            return result;
        }












    }
}
