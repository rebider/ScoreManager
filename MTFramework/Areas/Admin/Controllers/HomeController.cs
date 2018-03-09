using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Net;
using MT.Models;
using MT.Common;

namespace MediaServer.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveFile()
        {
            FileModel file = new FileModel();
            string ext = Path.GetExtension(Request.Files[0].FileName);
            file.PathName = Guid.NewGuid().ToString("N") + ext;
            Request.Files[0].SaveAs(MTConfig.SaveBasePath + file.PathName);

            if (!string.IsNullOrEmpty(Request["showName"]))
            {
                file.ShowName = Request["showName"] + ext;
            }
            else
            {
                file.ShowName = Request.Files[0].FileName;
            }
            file.CreateTime = DateTime.Now;

            file.Insert();
            return Json(file);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DownloadFile(int? Id)
        {
            FileModel fileModel = FileModel.SingleOrDefault(Id);
            using (FileStream fileStream = System.IO.File.OpenRead(MTConfig.SaveBasePath + fileModel.PathName))
            {
                int len = (int)fileStream.Length;
                byte[] buffer = new byte[len];
                fileStream.Read(buffer, 0, len);
                return File(buffer, fileModel.PathName.ToContentType(), fileModel.ShowName);
            }
        }

        [HttpGet]
        public ActionResult ViewFile(int? Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        /// <summary>
        /// 下载图片 可以自动生成对应大小的文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [OutputCache(Duration = 3600)]
        public void Img(string id, int? width, int? height)
        {
            var t = this.Request.Headers;
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            FileModel fileModel = FileModel.FirstOrDefault("where id = @id", new { id });
            if (fileModel != null)
            {
                fileModel.PathName = MTConfig.SaveBasePath + fileModel.PathName;
            }
            string imgName = fileModel.PathName;
            if (null != width && null != height)
            {
                string dir = Path.GetDirectoryName(fileModel.PathName);
                string name = Path.GetFileName(fileModel.PathName);
                string ext = Path.GetExtension(fileModel.PathName);
                imgName = dir + "\\" + name.Replace(ext, "") + "_" + width + "_" + height + ext;
            }
            //物理路径
            string saveFilePath = imgName;

            //不存在该图片
            if (!System.IO.File.Exists(saveFilePath))
            {

                //判断源文件是否存在
                string sourceSaveFilePath = fileModel.PathName;

                if (!System.IO.File.Exists(sourceSaveFilePath))
                {
                    return;
                }
                //生成缩略图
                ImageUtil.GetPicThumbnail(sourceSaveFilePath, saveFilePath, height.Value, width.Value);
            }
            Response.ContentType = saveFilePath.ToContentType();
            using (FileStream stream = new FileStream(saveFilePath, FileMode.Open, FileAccess.Read))
            {
                int len = (int)stream.Length;
                byte[] buffer = new byte[len];
                stream.Read(buffer, 0, len);
                Response.OutputStream.Write(buffer, 0, len);
            };
        }
    }
}
