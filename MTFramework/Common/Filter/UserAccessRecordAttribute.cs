using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MT.Models;

namespace MT.Common.Filter
{
    public class UserAccessRecordAttribute : ActionFilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// 记录访问记录
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            //AccessRecordModel model = new AccessRecordModel();
            //model.RemoteIp = HttpContext.Current.Request.UserHostAddress;
            //model.AccessUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            //model.UrlReferer = (HttpContext.Current.Request.UrlReferrer != null
            //                        ? HttpContext.Current.Request.UrlReferrer.AbsoluteUri
            //                        : "");
            //model.CreateTime = DateTime.Now;
            //model.DelFlag = 0;
            //model.Insert();
        }

        /// <summary>
        /// 网站发生异常
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext filterContext)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            try
            {
            }
            catch
            {
            }
            filterContext.Result = new RedirectResult("/Home/Public/Exception");
        }
    }
}