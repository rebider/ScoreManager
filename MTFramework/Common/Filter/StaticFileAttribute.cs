using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System;
using MT.Dal;

namespace MT.Common.Helper
{
    /// <summary>
    /// 生成静态文件
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class StaticFileAttribute : ActionFilterAttribute, IResultFilter
    {
        #region 公共属性

        /// <summary>
        /// 过期时间，以小时为单位
        /// </summary>
        public int Expiration { get; set; }

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// 缓存目录
        /// </summary>
        public string CacheDirectory { get; set; }

        /// <summary>
        /// 指定生成的文件名
        /// </summary>
        public string FileName { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public StaticFileAttribute()
        {
            Expiration = 1;
            CacheDirectory = AppDomain.CurrentDomain.BaseDirectory + "Htmls\\";
        }

        #endregion

        #region 方法

        /// <summary>
        /// 判断缓存文件是否已经生成
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var fileInfo = GetCacheFileInfo(filterContext);
            if (fileInfo.Exists && fileInfo.CreationTime.AddHours(Expiration) > DateTime.Now)
            {
                using (StreamReader reader = new StreamReader(fileInfo.FullName))
                {
                    filterContext.Result = new ContentResult()
                    {
                        Content = reader.ReadToEnd()
                    };
                }
            }
        }

        /// <summary>
        /// 执行完成后将文件缓存到本地
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var fileInfo = GetCacheFileInfo(filterContext);

            if ((fileInfo.Exists && fileInfo.CreationTime.AddHours(Expiration) < DateTime.Now) || !fileInfo.Exists)
            {
                var deleted = false;

                try
                {
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                    }

                    deleted = true;
                }
                catch (Exception ex)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "generate_static", new string[] { ex.Message });
                }

                var created = false;

                try
                {
                    if (!fileInfo.Directory.Exists)
                    {
                        fileInfo.Directory.Create();
                    }

                    created = true;
                }
                catch (IOException ex)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "generate_static", new string[] { ex.Message });
                }

                if (deleted && created)
                {
                    FileStream fileStream = null;
                    StreamWriter streamWriter = null;

                    try
                    {
                        var viewResult = filterContext.Result as ViewResult;
                        fileStream = new FileStream(fileInfo.FullName, FileMode.CreateNew, FileAccess.Write, FileShare.None);
                        streamWriter = new StreamWriter(fileStream);
                        var viewContext = new ViewContext(filterContext.Controller.ControllerContext, viewResult.View, viewResult.ViewData, viewResult.TempData, streamWriter);
                        viewResult.View.Render(viewContext, streamWriter);
                    }
                    catch (Exception ex)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "generate_static", new string[] { ex.Message });
                    }
                    finally
                    {
                        if (streamWriter != null)
                        {
                            streamWriter.Close();
                        }

                        if (fileStream != null)
                        {
                            fileStream.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 生成文件Key
        /// </summary>
        /// <param name="controllerContext">ControllerContext</param>
        /// <returns>文件Key</returns>
        protected virtual string GenerateKey(ControllerContext controllerContext)
        {
            var url = controllerContext.HttpContext.Request.Url.ToString();

            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            return url.LongMD5();
        }

        /// <summary>
        /// 获取静态的文件信息
        /// </summary>
        /// <param name="controllerContext">ControllerContext</param>
        /// <returns>缓存文件信息</returns>
        protected virtual FileInfo GetCacheFileInfo(ControllerContext controllerContext)
        {
            var fileName = string.Empty;

            if (string.IsNullOrWhiteSpace(FileName))
            {
                var key = GenerateKey(controllerContext);

                if (!string.IsNullOrWhiteSpace(key))
                {
                    fileName = Path.Combine(CacheDirectory, string.IsNullOrWhiteSpace(Suffix) ? key : string.Format("{0}.{1}", key, Suffix));
                }
            }
            else
            {
                fileName = Path.Combine(CacheDirectory, FileName);
            }

            return new FileInfo(fileName);
        }

        #endregion
    }
}