//*****************************************************************
//
// File Name:   Encrypt.cs
//
// Description: 加密类
//
// Coder:       mengxiangji
//
// Date:        2012-12-21 12:43:01
//
// History:     1、2012-12-21 12:43:06 create     
//*****************************************************************
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using cn.jpush.api.util;
using System.Text.RegularExpressions;

namespace MT.Common.Helper
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class Encrypt
    {
        /// <summary>
        /// 变异MD5 by ChengQing
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static String VariationMd5(string password)
        {
            password = GetMD5(password);
            password = GetMD5(password.Substring(0, 14)) + password.Substring(14);
            return password;
        }

        public static string GetMD5(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] InBytes = Encoding.Default.GetBytes(password);
            byte[] OutBytes = md5.ComputeHash(InBytes);
            string OutString = string.Empty;
            for (int i = 0; i < OutBytes.Length; i++)
            {
                OutString += OutBytes[i].ToString("x2");
            }
            return OutString;
        }

        public static String md5(String s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }

        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UserMd5(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 

                pwd = pwd + s[i].ToString("X");

            }
            return pwd;
        }

        private static char[] constantNum =
          {
            '0','1','2','3','4','5','6','7','8','9'
          };
        private static char[] constantABC =
          {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
          };
        public static string RandomNum(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constantNum[rd.Next(10)]);
            }
            return newRandom.ToString();
        }
        public static string RandomABC(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constantABC[rd.Next(10)]);
            }
            return newRandom.ToString();
        }
        public static string Encrypt_Base64(string data)
        {
            string lastStr = data.Substring(data.Length - 1, 1);
            if (Regex.Matches(lastStr, "[a-zA-Z]").Count > 0)
            {
                data = data + RandomNum(2);
            }
            else if (Regex.IsMatch(lastStr, @"^[+-]?\d*[.]?\d*$"))
            {
                data = data + RandomABC(2);
            }
            data = Base64.getBase64Encode(data);
            data = RandomABC(1) + RandomNum(2) + data + RandomNum(1) + RandomABC(1);
            return data;
        }

        public static string DeEncrypt_Base64(string data)
        {
            data = data.Substring(0, data.Length - 2);
            data = data.Substring(3, data.Length - 3);
            data = Base64.DecodeBase64(data);
            return data.Substring(0, data.Length - 2);
        }
    }
}