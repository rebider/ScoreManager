using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common.Helper
{
    public class RandomCodeHelper
    {
        string str = @"0123456789abcdefghigklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ";
        
        public string GetMix(Random rnd)
        {
            // 返回数字
            // return rnd.Next(10).ToString();

            // 返回小写字母
            // return str.Substring(10+rnd.Next(26),1);

            // 返回大写字母
            //  return str.Substring(36+rnd.Next(26),1);

            // 返回大小写字母混合
            //  return str.Substring(10+rnd.Next(52),1);

            //  返回小写字母和数字混合
            // return str.Substring(0 + rnd.Next(36), 1);

            // 返回大写字母和数字混合
            //  return str.Substring(0 + rnd.Next(36), 1).ToUpper();

            // 返回大小写字母和数字混合
            return str.Substring(0 + rnd.Next(61), 1);
        }
    }
}