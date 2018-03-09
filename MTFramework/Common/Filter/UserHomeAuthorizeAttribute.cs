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
    public class UserHomeAuthorizeAttribute : AuthorizeAttribute
    {
        //锁对象
        private static object locker = new object();

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            const string noAuthUrl = "/Web/Public/NoAuth";

            //如果session为空
            if (MTConfig.CurrentUserInfo == null || MTConfig.CurrentUserInfo == null)
            {
                filterContext.Result = new RedirectResult(noAuthUrl);
            }
        }
    }
}