using System.Text.RegularExpressions;

namespace Aurora_Player
{
    class CharHelper
    {
        // 获得字符串中开始和结束字符串中间得值
        public static string GetMiddleValue(string strinput, string start, string end)
        {
            Regex rg = new Regex("(?<=(" + start + "))[.\\s\\S]*?(?=(" + end + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(strinput).Value;
        }

        public static bool IsAlphabet(string input)
        {
            string pattern = @"^[A-Za-z]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        public static bool IsNumeric(string value)
        {
            if (value == string.Empty)
                return false;
            else
                return Regex.IsMatch(value, @"^[+-]?\d+[.]?\d+$");
        }

        public static bool IsHanZi(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if ((int)value[i] > 127)
                    return true;
                else
                    return false;
            }
            return false;
            //for (int i = 0; i < value.Length; i++)
            //{
            //    if (Regex.IsMatch(value[i].ToString(), @"[\u4e00-\u9fbb]+{1}"))
            //       return true;
            //   else
            //        return false;
            //}
            //return false;
        }

        public static bool IsEmail(string email)
        {
            string regexEmail = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);

            Regex regEmail = new Regex(regexEmail, options);
            if (regEmail.IsMatch(email))//email 填写符合正则表达式 
            {
                return true;
            }
            return false;
        }
    }
}