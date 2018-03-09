using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.Models;

namespace MT.Common
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string reLoginUrl = string.Format("/Admin/Public/ReLogin?ReturnUrl={0}", HttpContext.Current.Request.Url.AbsolutePath);
            const string noAuthUrl = "/Admin/Public/NoAuth";


            if (!string.IsNullOrEmpty(HttpContext.Current.Request["token"]) &&
                HttpContext.Current.Request["token"] == MTConfig.AdminToken)
            {
                return;
            }

            //如果没有登录
            if (MTConfig.AuthInfo == null)
            {
                filterContext.Result = new RedirectResult(reLoginUrl);
                return;
            }

            var accessInfo = MTConfig.AuthInfo;
            var level2Info = accessInfo.Where(s => s.NodeLevel == 2).ToList();
            var level3Info = accessInfo.Where(s => s.NodeLevel == 3).ToList();
            var action = filterContext.RouteData.Values["action"].ToString().ToLower();
            var controller = filterContext.RouteData.Values["controller"].ToString().ToLower();

            var level2 = level2Info.FirstOrDefault(s => s.Name.ToLower() == controller);

            //没有权限
            if (level2 == null)
            {
                filterContext.Result = new RedirectResult(noAuthUrl);

                return;
            }

            var level3 = level3Info.FirstOrDefault(s => s.Name.ToLower() == action && s.Pid.ToInt() == Convert.ToInt32(level2.ID));

            //没有权限
            if (level3 == null)
            {
                filterContext.Result = new RedirectResult(noAuthUrl);
                return;
            }
        }

    }
}