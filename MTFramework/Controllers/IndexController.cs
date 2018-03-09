using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.Common;
using MT.Common.Filter;
using MT.Common.Helper;
using MT.Dal;
using MT.Models;

namespace MT.Controllers
{
    public class IndexController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string ib = Request.Url.ToString().Substring(7, 2);
            if (ib == "ib")
            {
                return Redirect("/web/public/loginAgent");
            }
            return Redirect("/web/public/login");

        }

    }
}
