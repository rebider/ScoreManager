using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using MT.Models.ViewModels;
using NSoup.Nodes;


namespace MT.Common.Helper
{
    public static class PhoneAttribution
    {
        /// <summary>
        /// 获取手机归属地
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public static string GetAttribution2(string phone)
        {
            string strResult = "";
            WebRequest request = HttpWebRequest.Create(string.Format("http://tcc.taobao.com/cc/json/mobile_tel_segment.htm?tel={0}", phone));
            WebResponse response = request.GetResponse();
            try
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    string str = reader.ReadToEnd();
                    str = str.Substring(str.IndexOf('=') + 1, str.Length - str.IndexOf('=') - 1);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    PhoneAddressViewModel model = serializer.Deserialize<PhoneAddressViewModel>(str);
                    strResult = model.carrier;
                }
            }
            catch (Exception exception)
            {
                strResult = "未知";
            }
            return strResult;




        }

        /// <summary>
        /// 获取手机归属地
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public static string GetAttribution(string phone)
        {
            string strResult = "";
            WebRequest request = HttpWebRequest.Create(string.Format("http://life.tenpay.com/cgi-bin/mobile/MobileQueryAttribution.cgi?chgmobile={0}", phone));
            WebResponse response = request.GetResponse();
            try
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    string str = reader.ReadToEnd();

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(str);
                   
                    XmlElement root = doc.DocumentElement;
                    XmlNode node = root.SelectSingleNode("/root/province");
                    XmlNode node2 = root.SelectSingleNode("/root/city");
                        XmlNode node3 = root.SelectSingleNode("/root/supplier");
                        strResult = node.InnerText.Trim() + "-" + node2.InnerText.Trim() + "(" + node3.InnerText.Trim() + ")";
                }
            }
            catch (Exception exception)
            {
                strResult = "未知";
            }
            return strResult;




        }



        /// <summary>
        /// 百度API查询手机号码归属地
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string PhoneRequest(string param)
        {
            param = "tel=" + param;
            string url = "http://apis.baidu.com/apistore/mobilephoneservice/mobilephone";
            string strURL = url + '?' + param;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "GET";
            // 添加header
            request.Headers.Add("apikey", "73447ad7a89a75b4ad7ce845cac62c32");
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();
            string StrDate = "";
            string strValue = "";
            StreamReader Reader = new StreamReader(s, Encoding.UTF8);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }

            return strValue;

        }

    }
}