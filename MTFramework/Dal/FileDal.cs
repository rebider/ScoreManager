using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MT.Common;

namespace MT.Dal
{
    public class FileDal
    {
        /// <summary>
        /// 保存上传文件
        /// </summary>
        /// <param name="fileBase"></param>
        /// <returns></returns>
        public static string SaveFile(HttpPostedFileBase fileBase)
        {
            string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(fileBase.FileName);
            fileBase.SaveAs(HttpContext.Current.Server.MapPath("~" + MTConfig.UploadPath) + fileName);
            return MTConfig.UploadPath + fileName;
        }

        /// <summary>
        /// 保存手机错误日志
        /// </summary>
        /// <param name="log"></param>
        public static void SaveErrorLog(string log)
        {
            using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/log.txt"), true))
            {
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + log);
            }
        }

    }
}