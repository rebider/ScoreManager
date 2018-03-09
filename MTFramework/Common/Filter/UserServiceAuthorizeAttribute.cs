//*****************************************************************
//
// File Name:   StyleReference
//
// Description: 获取样式项目地址
//
// Coder:       
//
// Date:        2013-07-04
//
// History:     
//   
//*****************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.Models;
using System.Configuration;
using System.Web.Configuration;
using MT.Dal;

namespace MT.Common
{
    public class UserServiceAuthorizeAttribute : AuthorizeAttribute
    {
        //锁对象
        private static object locker = new object();

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string token = HttpContext.Current.Request["token"];
            bool isOk = false;
            string info = "登录超时";
            object data = null;
            object datas = null;
            string type = "info";

            JsonResult jsonResult = new JsonResult()
            {
                Data = new { isOk, info, data, datas, type },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }; 

            if (string.IsNullOrWhiteSpace(token))
            {
                filterContext.Result = jsonResult;
                return;
            }

            CacheModel cache = CacheModel.FirstOrDefault("where cache_key = @0", token);
            if (cache == null)
            {
                filterContext.Result = jsonResult;
            }
        }
    }
}