using cn.jpush.api.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MT.Common.Helper
{
    public class PwdThreeEncrypt
    {
        /// <summary>
        /// 密码MD5加密三次
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string PasswordThreeMd5Encrypt(string str)
        {
            string encryptPwd = "";
            encryptPwd = "ant" + str + "tna";
            encryptPwd = Md5.getMD5Hash(encryptPwd);
            encryptPwd = Md5.getMD5Hash(encryptPwd);
            encryptPwd = Md5.getMD5Hash(encryptPwd);
            return encryptPwd;
        }
    }
}