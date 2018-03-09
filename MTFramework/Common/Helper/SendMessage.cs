using MT.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace MT.Common.Helper
{
    public static class SendMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone">接收手机号码</param>
        /// <param name="messagess">短信内容</param>
        /// <param name="name">接收人姓名（可为空）</param>
        /// <param name="id">接收人id</param>
        /// <returns></returns>
        public static bool SendPhoneMes(string phone, string messagess,string name="",string id="")
        {
            string mobile = phone,
                 message = messagess,
                 username = "api",
                 password = "key-c9a886a91ec89fe0f6499a8c85aad828",
                 url = "http://sms-api.luosimao.com/v1/send.json";

            byte[] byteArray = Encoding.UTF8.GetBytes("mobile=" + mobile + "&message=" + message);
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(url));
            string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(username + ":" + password));
            webRequest.Headers.Add("Authorization", auth);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;

            Stream newStream = webRequest.GetRequestStream();
            newStream.Write(byteArray, 0, byteArray.Length);
            newStream.Close();

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader php = new StreamReader(response.GetResponseStream(), Encoding.Default);
            string Message = php.ReadToEnd();


            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var json = serializer.Deserialize<Dictionary<string, string>>(Message);
            if (json["error"] == "0")
            {
                //SendMessageModel messageModel =new SendMessageModel();
                //messageModel.CreateMan = MTConfig.CurrentUserID;
                //messageModel.CreateTime = DateTime.Now;
                //messageModel.Message = messagess;
                //messageModel.Phone = phone;
                //messageModel.Name = name;
                //if (!string.IsNullOrEmpty(id))
                //{
                //    messageModel.ToUserId = id.ToInt();
                //}
                //messageModel.Insert();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}