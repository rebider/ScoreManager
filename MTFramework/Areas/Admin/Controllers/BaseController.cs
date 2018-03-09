using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace MT.Areas.Admin.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        protected const string Info = "info";
        public const string Time = "time";
        protected const string EditFlag = "EditFlag";
        protected const string NoEmptyFlag = "NoEmptyFlag";
        protected const string SaveSuccess = "保存成功";
        protected const string SaveError = "保存失败";
        protected const string DeleteSuccess = "删除成功";
        protected const string DeleteError = "删除失败";
        protected const string VersionError = "用户版本错误";

        protected const string DeleteSuccess_Flag = "停用成功";
        protected const string DeleteError_Flag = "停用失败";

        protected const string DefaultPWD = "111111";

        protected const string AddSuccess_Flag = "启用成功";
        protected const string AddError_Flag = "启用失败";
        protected const int ErrorTime = 3;
        protected const int SuccessTime = 2;

        protected const string JumpUrl = "jumpUrl";

        #region 成功页面跳转
        public ActionResult JsonObject(bool isOk = true, string info = "", object data = null, object datas = null, string type = "info", long pagecount = 1)
        {
           
            return Json(new { isOk, info, data, datas, type, pagecount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Success()
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = SaveSuccess;
            routeValueDictionary["JumpUrl"] = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        public ActionResult Success(string info)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        public ActionResult Success(string info, IList<string> param)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index?" + string.Join("&", param);
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        public ActionResult Success(string info, string jumpUrl)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = jumpUrl;
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        public ActionResult Success(string info, string jumpUrl, int time)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = time;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = jumpUrl;
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        #endregion

        #region 错误页面跳转

        public ActionResult Error()
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = ErrorTime;
            routeValueDictionary["Info"] = SaveError;
            routeValueDictionary["JumpUrl"] = "javascript: history.go(-1)";
            return RedirectToAction("Error", "Public", routeValueDictionary);
        }

        public ActionResult Error(string info)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = ErrorTime;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = "javascript: history.go(-1)";
            return RedirectToAction("Error", "Public", routeValueDictionary);
        }

        public ActionResult Error(string info, int time)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = time;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = "javascript: history.go(-1)";
            return RedirectToAction("Error", "Public", routeValueDictionary);
        }

        public ActionResult Error(string info, int time, string jumpUrl)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = time;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = jumpUrl;
            return RedirectToAction("Error", "Public", routeValueDictionary);
        }

        public ActionResult Error(ModelStateDictionary states)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary[Time] = ErrorTime;
            string info = string.Empty;
            foreach (string key in states.Keys)
            {
                ModelState state = states[key];
                foreach (var error in state.Errors)
                {
                    info += error.ErrorMessage;
                }
            }
            routeValueDictionary[Info] = info;
            routeValueDictionary["JumpUrl"] = "javascript: history.go(-1)";
            return RedirectToAction("Error", "Public", routeValueDictionary);
        }
        #endregion

        #region ajax使用的json格式
        /// <summary>
        /// 返回json成功提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ActionResult JsonSuccess(string message, object obj = null)
        {
            return Json(new { status = 1, msg = message, data = obj }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回json错误提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public ActionResult JsonError(string message, object obj = null)
        {
            return Json(new { status = 0, msg = message, data = obj }, JsonRequestBehavior.AllowGet);

            //return Content("toptip('" + message + "');", "application/x-javascript");
        }

        /// <summary>
        /// 返回json成功提示 跳转页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jumpUrl"></param>
        /// <returns></returns>
        public ActionResult JsonSuccessJump(string message = SaveSuccess, string jumpUrl = "")
        {
            if (string.IsNullOrWhiteSpace(jumpUrl))
            {
                jumpUrl = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
            }
            //return JavaScript("tipreadurl('保存成功','" + jumpUrl + "');");
            return Content("tipreadurl('保存成功','" + jumpUrl + "');", "application/x-javascript");
            //return JavaScript("alert('插入失败')");
            //return Json(new { status = 1, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
        }
      
        /// <summary>
        /// 返回json错误提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jumpUrl"></param>
        /// <returns></returns>
        public ActionResult JsonErrorJump(string message = SaveError, string jumpUrl = "")
        {
            //return Json(new { status = 0, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
            return Content("tipreadurl('" + message + "','" + jumpUrl + "');", "application/x-javascript");
        }



        #endregion
    }
}
