using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RennDotSDK.APIUtility
{
    public class APIConfig
    {
        public APIConfig()
        {
        }

        public static string GetValueFromConfig(string key)
        {
            string value = String.Empty;
            return ConfigurationManager.AppSettings[key];
        }

        public static string ApiKey
        {
            get { return GetValueFromConfig("ApiKey"); }
        }
        public static string SecretKey
        {
            get { return GetValueFromConfig("SecretKey"); }
        }

        public static string Format
        {
            get { return GetValueFromConfig("Format"); }
        }

        public static string AuthorizationURL
        {
            get { return GetValueFromConfig("AthCodeURL"); }
        }

        public static string AccessURL
        {
            get { return GetValueFromConfig("ATURL"); }
        }
        
        public static string SessionURL
        {
            get { return GetValueFromConfig("SessionURL"); }
        }
        
        public static string RennAPIURL
        {
            get { return GetValueFromConfig("RRAPIURL"); }
        }
        
        public static string CallBackURL
        {
            get { return GetValueFromConfig("CallBack"); }
        }
    }
}
