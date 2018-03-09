using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System;
using MT.Common;
using System.Text;
using PetaPoco.Internal;

namespace MT.Controllers
{
    public class InvitationPoliteController : BaseController
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.code = Request["code"];
            return View();
        }

    }
}
