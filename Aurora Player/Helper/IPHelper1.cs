using System.IO;
using System.Net;
using System.Text;

namespace Aurora_Player
{
    class IPHelper1
    {
        //http://www.ipip.net/
        //http://freeapi.ipip.net/58.249.24.31
        //["中国","广东","广州","","联通"]
        public static string GetIpInfoFromIPIP(string strIP)
        {
            if (strIP == "")
                return string.Empty;
            string strWebResponse = string.Empty;
 
            string strURL = "freeapi.ipip.net/" + strIP;
            WebClient client = new WebClient();
            try
            {
                strWebResponse = client.DownloadString(strURL);
            }
            catch { }

            return strWebResponse;
        }

        //Sohu API【推荐】
        //var returnCitySN = {"cip": "58.249.24.31", "cid": "440100", "cname": "广东省广州市"};
        public static string GetIpInfoFromSohu()
        {
            string strWebResponse = string.Empty;
            string strURL = "http://pv.sohu.com/cityjson";
            WebClient client = new WebClient();
            try
            {
                strWebResponse = client.DownloadString(strURL);
            }
            catch { }

            return strWebResponse;
        }


        //Baidu API
        //JSON返回示例 :
        //{
        //    "errNum": 0,
        //    "errMsg": "success",
        //    "retData": {
        //        "ip": "117.89.35.58", //IP地址
        //        "country": "中国", //国家 
        //        "province": "江苏", //省份 国外的默认值为none
        //        "city": "南京", //城市  国外的默认值为none
        //        "district": "鼓楼",// 地区 国外的默认值为none
        //        "carrier": "中国电信" //运营商  特殊IP显示为未知
        //    }
        //}
        public static string GetIpInfoFromBaidu(string str_ip)
        {
            string url = "http://apis.baidu.com/apistore/iplookupservice/iplookup";
            string strURL = url + "?ip=" + str_ip;
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "fc19a9592dcd0bab90bce5fc83883715");
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            //Unicode转中文1：HttpUtility.UrlDecode(string str);
            //Unicode转中文2：Regex.Unescape(string str);
            string ss = System.Text.RegularExpressions.Regex.Unescape(strValue);
            return ss;
        }


    }
}
