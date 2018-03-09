using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using NSoup.Nodes;

namespace MT.Common.Helper
{
    public class IpToAddress
    {

        public string GetClientIPv4Address()
        {
            string ipv4 = String.Empty;

            foreach (IPAddress ip in Dns.GetHostAddresses(GetClientIP()))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ipv4 = ip.ToString();
                    break;
                }
            }

            if (ipv4 != String.Empty)
            {
                return ipv4;
            }
            // 利用 Dns.GetHostEntry 方法，由获取的 IPv6 位址反查 DNS 纪录，
            // 再逐一判断何者为 IPv4 协议，即可转为 IPv4 位址。
            foreach (IPAddress ip in Dns.GetHostEntry(GetClientIP()).AddressList)
            //foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ipv4 = ip.ToString();
                    break;
                }
            }

            return ipv4;
        }
        public static string GetClientIP()
        {
            if (null == HttpContext.Current.Request.ServerVariables["HTTP_VIA"])
            {
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
        }

        /// <summary>  
        /// 获取真ip  
        /// </summary>  
        /// <returns></returns>  
        public string GetRealIP()
        {
            string result = String.Empty;
            result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //可能有代理   
            if (!string.IsNullOrWhiteSpace(result))
            {
                //没有"." 肯定是非IP格式  
                if (result.IndexOf(".") == -1)
                {
                    result = null;
                }
                else
                {
                    //有","，估计多个代理。取第一个不是内网的IP。  
                    if (result.IndexOf(",") != -1)
                    {
                        result = result.Replace(" ", string.Empty).Replace("\"", string.Empty);

                        string[] temparyip = result.Split(",;".ToCharArray());

                        if (temparyip != null && temparyip.Length > 0)
                        {
                            for (int i = 0; i < temparyip.Length; i++)
                            {
                                //找到不是内网的地址  
                                if (IsIPAddress(temparyip[i]) && temparyip[i].Substring(0, 3) != "10." && temparyip[i].Substring(0, 7) != "192.168" && temparyip[i].Substring(0, 7) != "172.16.")
                                {
                                    return temparyip[i];
                                }
                            }
                        }
                    }
                    //代理即是IP格式  
                    else if (IsIPAddress(result))
                    {
                        return result;
                    }
                    //代理中的内容非IP  
                    else
                    {
                        result = null;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }



        public bool IsIPAddress(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 7 || str.Length > 15)
                return false;

            string regformat = @"^(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(str);
        }


        /// <summary>
        /// 从http://www.ip138.com/读取IP地址
        /// </summary>
        /// <returns></returns>
        public string GetIpAddress(string Ip)
        {
            string[] result;
            if (string.IsNullOrEmpty(Ip.Trim()))
            {
                return null;
            }
            //WebClient client = new WebClient();
            //client.Encoding = System.Text.Encoding.GetEncoding("GB2312");
            //string url = "http://www.ip138.com/ips138.asp";
            //string post = "ip=" + Ip + "&action=2";
            //client.Headers.Set("Content-Type", "application/x-www-form-urlencoded");
            //string response = client.UploadString(url, post);

            //string p = @"<li>参考数据二：(?<location>[^<>]+?)</li>";
            //Match match = Regex.Match(response, p);
            //string m_Location = match.Groups["location"].Value.Trim();
            //result = m_Location.Split(' ');
            //return result[0];
            string strResult;
            string str;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create("http://www.ip138.com/ips138.asp?ip=" + Ip + "&action=2");
                myReq.Timeout = 3000;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                strResult = sr.ReadToEnd();
                NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(strResult);
                Element element = doc.Body.GetElementsByTag("table")[0];
                strResult = element.GetElementsByTag("tr")[2].GetElementsByTag("td")[0].GetElementsByTag("ul")[0].GetElementsByTag("li")[0].Text();
                str = strResult.Substring(6);
            }
            catch (Exception exp)
            {
                str = "未知";
            }
            return str;

        }



        /// <summary>
        /// 从http://www.ip138.com/读取IP地址
        /// </summary>
        /// <returns></returns>
        public string IpAddress(string Ip)
        {
            string strResult = "";
            WebRequest request = HttpWebRequest.Create("http://int.dpool.sina.com.cn/iplookup/iplookup.php?format=x&ip="+ Ip);
            WebResponse response = request.GetResponse();
            try
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312")))
                {
                    string str = reader.ReadToEnd();
                    str = String2Json(str);
                    strResult = str.Replace(@"1", "").Replace(" ", "").Replace("-", "").Replace(@"\t", "");
                }
            }
            catch (Exception exception)
            {
                strResult = "未知";
            }
            return strResult;

        }

        /// <summary>  
        /// 过滤特殊字符  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        private static string String2Json(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        if ((c >= 0 && c <= 31) || c == 127)//在ASCⅡ码中，第0～31号及第127号(共33个)是控制字符或通讯专用字符
                        {
                            //TODO
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            return sb.ToString();
        }

        public string IpRequest(string param)
        {
            string url = "http://apis.baidu.com/apistore/iplookupservice/iplookup";
            param = "ip=" + param;
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
            StreamReader Reader = new StreamReader(s, Encoding.Default);
            while ((StrDate = Reader.ReadLine()) != null)
            {
                strValue += StrDate + "\r\n";
            }
            return strValue;
        }


    }
}