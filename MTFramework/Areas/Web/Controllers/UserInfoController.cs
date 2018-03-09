using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using cn.jpush.api.util;
using MT.Common;
using MT.Models;
using PetaPoco;
using MT.Dal;
using MT.Common.Helper;
using MT.Models.ViewModels;

namespace MT.Areas.Web.Controllers
{
    [UserHomeAuthorize]
    public class UserInfoController : BaseController
    {



        public ActionResult Index()
        {
            return View();
        }

        
    }
}
