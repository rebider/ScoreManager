using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using MT.Areas.Admin.ViewModels;
using MT.Dal;
using MT.Models;
using MT.Common;
using System.IO;
using System;
using System.Collections;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;

namespace MT.Controllers
{
    public class PublicController : System.Web.Mvc.Controller
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            ////类别绑定
            //List<ActivityTypeModel> activityTypeList = ActivityTypeModel.Fetch(" where del_flag = 0 order by sort_no desc ");
            //ViewBag.activityTypeList = activityTypeList;
        }

        public ActionResult Success(int time, string info, string jumpUrl)
        {
            ViewBag.time = time;
            ViewBag.info = info;
            ViewBag.jumpUrl = jumpUrl;
            return View("~/Views/Public/Success.cshtml");
        }

        public ActionResult Error(int time, string info, string jumpUrl)
        {
            ViewBag.time = time;
            ViewBag.info = info;
            ViewBag.jumpUrl = jumpUrl;
            return View("~/Views/Public/Error.cshtml");
        }

      

       
    }
}
