using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace RennDotSDK.APIUtility
{
    public class APIValidation
    {
        /// <summary>
        /// 获取Access Token,
        /// 通过第一步返回的URL获得参数Code的值，就为Authorization Code
        /// </summary>
        /// <returns>返回获得的Access Token</returns>
        public string GetAccessToken()
        {
            string accessToken = "";
            try
            {
                if (System.Web.HttpContext.Current.Session["accessToken"] == null)
                {
                    string authorizationCode = System.Web.HttpContext.Current.Request["code"] ?? "";
                    if (authorizationCode != "")
                    {
                        List<APIParameter> parameters = new List<APIParameter>() { 
                        new APIParameter("grant_type","authorization_code"),
                        new APIParameter("code",authorizationCode),
                        new APIParameter("client_id",APIConfig.ApiKey),
                        new APIParameter("client_secret",APIConfig.SecretKey),
                        new APIParameter("redirect_uri",APIConfig.CallBackURL)
                    };
                        string content = new SyncHttp().HttpRequest("POST", APIConfig.AccessURL, parameters);
                        JObject jo = JObject.Parse(content);
                        accessToken = jo["access_token"].ToString();
                        System.Web.HttpContext.Current.Session["accessToken"] = accessToken;
                    }
                }
                else
                {
                    accessToken = System.Web.HttpContext.Current.Session["accessToken"] as string;
                }
            }
            catch
            {
                accessToken = "";
            }
            // 由于获得Json字符串通过JSON.NET获取之后，还是以字符串形式存在，形如“xxxxx”，包括双引号
            // 所以必须替换掉双引号
            accessToken = accessToken.Replace("\"", "");
            return accessToken;
        }

        /// <summary>
        /// 获取已登录用户的UserId
        /// 从accessToken中解析而得到
        /// </summary>
        /// <returns>返回已登录用户的UserId</returns>
        public string GetUserId()
        {
            string accessToken = GetAccessToken();
            if (accessToken.Length > 0)
            {
                string[] seperator = { "-" };
                string[] array = accessToken.Split(seperator, 2, System.StringSplitOptions.None);
                return array[1];
            }
            else
            {
                return "";
            }
        }
    }
}
