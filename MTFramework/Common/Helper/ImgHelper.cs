using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Newtonsoft.Json;
using MT.Dal;
using MT.Models;
using System.Web.Caching;
using MT.Common;

namespace MT.Common
{
    public class ImgHelper
    {

        #region 图片服务器相关方法


        /// <summary>
        /// 创建图片地址
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static string CreateImageShowUrl(string id, int width = 0, int height = 0)
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(id))
            {
                return string.Empty;
            }
            if (width == 0 && height == 0)
            {
                str = string.Format("/{1}/{2}?id={3}", MTConfig.ImageServer, "Home", "DownloadFile", id);
            }
            else
            {
                str = string.Format("/{1}/{2}?id={3}&width={4}&height={5}", MTConfig.ImageServer, "Home", "Img", id, width, height);
            }
            return str;
        }

        /// <summary>
        /// 上传图片至文件服务器
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string UploadImage(string path, string name)
        {
            WebClient client = new WebClient();
            byte[] res = client.UploadFile(CreateSaveUrl(name), path);
            string res_str = Encoding.UTF8.GetString(res);
            return res_str;
        }

        /// <summary>
        /// 异步上传图片至文件服务器
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        public static void UploadImageAsync(string path, string name)
        {
            WebClient client = new WebClient();
            client.UploadFileAsync(new Uri(CreateSaveUrl(name)), path);
        }

        /// <summary>
        /// 上传图片至文件服务器
        /// </summary>
        /// <param name="imgByte"></param>
        /// <param name="showName"></param>
        /// <returns></returns>
        public static string UploadImage(byte[] imgByte, string showName, string fileName)
        {
            HttpWebClient client = new HttpWebClient(CreateSaveUrl(showName));
            client.AttachFile(imgByte, fileName, "id");
            string res = client.GetString();
            return res;
        }

        /// <summary>
        /// 上传图片至文件服务器
        /// </summary>
        /// <param name="imgByte"></param>
        /// <param name="name"></param>
        public static void UploadImageAsync(byte[] imgByte, string name)
        {
            Task.Factory.StartNew(() =>
            {
                HttpWebClient client = new HttpWebClient(CreateSaveUrl(name));
                client.AttachFile(imgByte, name, "id");
                string res = client.GetString();
            });

        }

        /// <summary>
        /// 创建图片服务器保存地址
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string CreateSaveUrl(string name)
        {
            string str = string.Concat(MTConfig.ImageServer, "/Home", "/SaveFile?showName=", name);
            return str;
        }

        #endregion
    }
}