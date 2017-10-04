using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.IO;

namespace Aurora_Player
{
    class EmailHelper
    {
        //http://sendcloud.sohu.com/doc/email_v2/code/#csharp
        //API 返回码
        //API 返回的结果是 JSON 格式, 示例如下:

        //# 请求成功
        //{
        //  "result": true,
        //  "statusCode": 200,
        //  "message": "请求成功",
        //  "info": {}
        //}
        //# 认证失败
        //{
        //  "result": false,
        //  "statusCode": 40005,
        //  "message": "认证失败",
        //  "info": {}
        //}
        //# 数据获取成功
        //{
        //  "statusCode": 200,
        //  "info": {
        //    "data": {
        //      "gmtCreated": "2015-10-19 15:39:27",
        //      "gmtUpdated": "2015-10-19 15:39:27",
        //      "labelId": ***,
        //      "labelName": "test"
        //    }
        //  },
        //  "message": "请求成功",
        //  "result": true
        //}
        //result: API 请求是否成功
        //statusCode: API 返回码
        //message: API 返回码的中文解释
        //info: 数据信息

        static string url = "http://api.sendcloud.net/apiv2/mail/send";
        static string api_user = "AuroraPlayer001";//AuroraPlayer001.AuroraPlayer002    现在免费用户每天只能发【200】封邮件
        static string api_key = "IwmgavYdA755uHbW";
        static string from = "Admin@auroraplayer.com";
        static string fromName = "Aurora Player";
        public static string subject = "Aurora Player账户注册";
        public static string html = "您的验证码是：456789<br/>Aurora Robot自动发送，请勿回复本邮件！";

        // 普通发送
        //string tos = "to1@sendcloud.org;to2@sendcloud.org";
        public static string SendCommon(string tos)
        {
            HttpClient client = null;
            HttpResponseMessage response = null;

            try
            {
                client = new HttpClient();

                List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();

                paramList.Add(new KeyValuePair<string, string>("apiUser", api_user));
                paramList.Add(new KeyValuePair<string, string>("apiKey", api_key));
                paramList.Add(new KeyValuePair<string, string>("from", from));
                paramList.Add(new KeyValuePair<string, string>("fromName", fromName));
                paramList.Add(new KeyValuePair<string, string>("to", tos));
                paramList.Add(new KeyValuePair<string, string>("subject", subject));
                paramList.Add(new KeyValuePair<string, string>("html", html));

                response = client.PostAsync(url, new FormUrlEncodedContent(paramList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("result:{0}", result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }
        }

        //普通发送&&附件
        //string tos = "to1@sendcloud.org;to2@sendcloud.org";
        public static string SendCommonWithAttachment(string tos)
        {
            HttpClient client = null;
            HttpResponseMessage response = null;

            try
            {
                client = new HttpClient();

                List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();
                paramList.Add(new KeyValuePair<string, string>("apiUser", api_user));
                paramList.Add(new KeyValuePair<string, string>("apiKey", api_key));
                paramList.Add(new KeyValuePair<string, string>("from", from));
                paramList.Add(new KeyValuePair<string, string>("fromName", fromName));
                paramList.Add(new KeyValuePair<string, string>("to", tos));
                paramList.Add(new KeyValuePair<string, string>("subject", subject));
                paramList.Add(new KeyValuePair<string, string>("html", html));

                var multipartFormDataContent = new MultipartFormDataContent();
                foreach (var keyValuePair in paramList)
                {
                    multipartFormDataContent.Add(new StringContent(keyValuePair.Value), string.Format("\"{0}\"", keyValuePair.Key));
                }

                multipartFormDataContent.Add(createStream("D:\\附件2.txt", "attachments", "附件名称2.txt"));

                multipartFormDataContent.Add(createStream("D:\\附件1.txt", "attachments", "附件名称1.txt"));

                response = client.PostAsync(url, multipartFormDataContent).Result;

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("result:{0}", result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }
        }

        private static StreamContent createStream(string filePath, string paramKey, string fileName)
        {
            FileStream fs = File.OpenRead(filePath);
            StreamContent streamContent = new StreamContent(fs);
            streamContent.Headers.Add("Content-Type", "application/octet-stream");
            string headerValue = "form-data; name=\"" + paramKey + "\"; filename=\"" + fileName + "\"";
            byte[] bytes1 = Encoding.UTF8.GetBytes(headerValue);
            headerValue = "";
            foreach (byte b1 in bytes1)
            {
                headerValue += (Char)b1;
            }
            streamContent.Headers.Add("Content-Disposition", headerValue);
            return streamContent;
        }

        //模板发送
        //string xsmtpapi = "{\"to\": [\"test@163.com\", \"test@qq.com\"], \"sub\" : { \"%name%\" : [\"name1\", \"name2\"], \"%money%\" : [\"1000\", \"2000\"]}}";
        public static string SendTemplete(string xsmtpapi)
        {
            HttpClient client = null;
            HttpResponseMessage response = null;

            try
            {
                client = new HttpClient();

                List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();

                paramList.Add(new KeyValuePair<string, string>("apiUser", api_user));
                paramList.Add(new KeyValuePair<string, string>("apiKey", api_key));
                paramList.Add(new KeyValuePair<string, string>("from", from));
                paramList.Add(new KeyValuePair<string, string>("fromName", fromName));
                paramList.Add(new KeyValuePair<string, string>("xsmtpapi", xsmtpapi));
                paramList.Add(new KeyValuePair<string, string>("subject", subject));
                paramList.Add(new KeyValuePair<string, string>("templateInvokeName", "test_template"));

                response = client.PostAsync(url, new FormUrlEncodedContent(paramList)).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("result:{0}", result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }
        }

        //模板发送&&附件
        //string xsmtpapi = "{\"to\": [\"test@163.com\", \"test@qq.com\"], \"sub\" : { \"%name%\" : [\"name1\", \"name2\"], \"%money%\" : [\"1000\", \"2000\"]}}";
        public static string SendTempleteWithAttachment(string xsmtpapi)
        {
            HttpClient client = null;
            HttpResponseMessage response = null;

            try
            {
                client = new HttpClient();

                List<KeyValuePair<string, string>> paramList = new List<KeyValuePair<string, string>>();

                paramList.Add(new KeyValuePair<string, string>("apiUser", api_user));
                paramList.Add(new KeyValuePair<string, string>("apiKey", api_key));
                paramList.Add(new KeyValuePair<string, string>("from", from));
                paramList.Add(new KeyValuePair<string, string>("fromName", fromName));
                paramList.Add(new KeyValuePair<string, string>("xsmtpapi", xsmtpapi));
                paramList.Add(new KeyValuePair<string, string>("subject", subject));
                paramList.Add(new KeyValuePair<string, string>("templateInvokeName", "test_template"));

                var multipartFormDataContent = new MultipartFormDataContent();
                foreach (var keyValuePair in paramList)
                {
                    multipartFormDataContent.Add(new StringContent(keyValuePair.Value), string.Format("\"{0}\"", keyValuePair.Key));
                }

                multipartFormDataContent.Add(createStream("D:\\附件2.txt", "attachments", "附件名称2.txt"));

                multipartFormDataContent.Add(createStream("D:\\附件1.txt", "attachments", "附件名称1.txt"));

                response = client.PostAsync(url, multipartFormDataContent).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine("result:{0}", result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }
            finally
            {
                if (null != client)
                {
                    client.Dispose();
                }
            }
        }

        public static void SMTP(string tos)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // 收件人地址，用正确邮件地址替代
                mailMsg.To.Add(new MailAddress(tos));
                // 发信人，用正确邮件地址替代
                mailMsg.From = new MailAddress(fromName, "fromname");

                // 邮件主题
                mailMsg.Subject = "Smtp C# Smtp Example";

                // 邮件正文内容
                //string text = "欢迎使用SendCloud";
                //string html = @"欢迎使用<a href=""http://api.sendcloud.net"">SendCloud</a>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(subject, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // 添加附件
                string file = "E:\\1.txt ";
                Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                mailMsg.Attachments.Add(data);

                // 连接到sendcloud服务器
                SmtpClient smtpClient = new SmtpClient("smtp.sendcloud.net", Convert.ToInt32(25));
                // 使用api_user和api_key进行验证
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(api_user, api_key);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
