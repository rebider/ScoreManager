using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System;
using MT.Common;
using System.Text;
using PetaPoco.Internal;

namespace MT.Controllers
{
    public class BaseController : Controller
    {

        #region 返回参数

       
        protected const string Info = "info";
        public const string Time = "time";
        protected const string EditFlag = "EditFlag";
        protected const string NoEmptyFlag = "NoEmptyFlag";
        protected const string SaveSuccess1 =  "保存成功";
        protected const string SaveError1 =  "保存失败";
        protected  string SaveSuccess = MTConfig.UserLang == "En" ? "Save Success" : "保存成功";
        protected string SexError = MTConfig.UserLang == "En" ? "Please select gender" : "请选择性别";
        protected string CountryNull = MTConfig.UserLang == "En" ? "Not Find Country" : "国家为空";
        protected string InputPwd = MTConfig.UserLang == "En" ? "Please enter your password" : "请输入密码";
        protected string ZipAddressError = MTConfig.UserLang == "En" ? "Please enter zip code and address" : "请输入邮编和地址";
        protected string UserNameError = MTConfig.UserLang == "En" ? "Please enter your name" : "请输入姓名";
        protected  string SaveError = MTConfig.UserLang == "En" ? "Save Failed" : "保存失败";
        protected string EmailError = MTConfig.UserLang=="En" ? "Registration failed, please contact customer service" : "注册失败，请及时联系客服";
        protected string RegistEmailSuccess = MTConfig.UserLang == "En" ? "Dear customer, your activation link has been sent to your" : "您好，您的激活链接已发送至您的";
        protected string RegistEmailSuccess1 = MTConfig.UserLang == "En" ? "mailbox. Please check it" : "邮箱，请注意查收";
        protected string PassowrdRegex = MTConfig.UserLang == "En" ? "The  password must contain 6-20 numbers and letters" : "密码必须是6-20包含英文大小写加数字";
        protected string IBError = MTConfig.UserLang == "En" ? "The person who filled the IB does not exist" : "所填IB推荐人不存在";
        protected string PhoneEmailExistError= MTConfig.UserLang == "En" ? "The message or mobile phone number already exists" : "所填信息邮箱或手机号码已存在";
        //CheckPhone
        protected string Phone1 = MTConfig.UserLang == "En" ? "Please enter your phone number!" : "请输入手机号码！";
        protected string Phone2 = MTConfig.UserLang == "En" ? "Wrong format of phone number!" : "手机号码格式错误！";
        protected string Phone3 = MTConfig.UserLang == "En" ? "Mobile phone number has been registered!" : "手机号码已经注册过了！";
        protected string Phone4 = MTConfig.UserLang == "En" ? "can use！" : "可以使用！";
        //CheckEmail
        protected string Email1 = MTConfig.UserLang == "En" ? "Please fill in the registration email!" : "请填写注册邮箱！";
        protected string Email2 = MTConfig.UserLang == "En" ? "E-mail format is wrong!" : "电子邮箱格式错误！";
        protected string Email3 = MTConfig.UserLang == "En" ? "E-mail binding other account!" : "电子邮箱绑定其他账号！";
        protected string Email4 = MTConfig.UserLang == "En" ? "Congratulations, this email is available!" : "恭喜您，此邮箱可用！";
        protected string Email5 = MTConfig.UserLang == "En" ? "Two mailbox numbers are inconsistent!" : "两次邮箱号不一致";
        protected string Passowrd1 = MTConfig.UserLang == "En" ? "Two passwords are inconsistent" : "两次密码不一致";


        protected const string DeleteSuccess = "删除成功";
        protected const string DeleteError = "删除失败";

        protected const string DeleteSuccess_Flag = "停用成功";
        protected const string DeleteError_Flag = "停用失败";


        protected const string AddSuccess_Flag = "启用成功";
        protected const string AddError_Flag = "启用失败";
        protected const int ErrorTime = 3;
        protected const int SuccessTime = 2;

        protected const string JumpUrl = "jumpUrl";

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            //类别绑定
            //List<ActivityTypeModel> activityTypeList = ActivityTypeModel.Fetch(" where del_flag = 0 order by sort_no desc ");
            //ViewBag.activityTypeList = activityTypeList;
        }
        #endregion


        #region 成功页面跳转

        public ActionResult Success()
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = SaveSuccess;
            routeValueDictionary["JumpUrl"] = "/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
            return RedirectToAction("Success", "Public", routeValueDictionary);
        }

        public ActionResult Success(string info)
        {
            var routeValueDictionary = new RouteValueDictionary();
            routeValueDictionary["Time"] = SuccessTime;
            routeValueDictionary["Info"] = info;
            routeValueDictionary["JumpUrl"] = "/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
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
        }

        /// <summary>
        /// 返回json成功提示 跳转页面
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jumpUrl"></param>
        /// <returns></returns>
        public ActionResult JsonSuccessJump(string message = SaveSuccess1, string jumpUrl = "")
        {
            if (string.IsNullOrWhiteSpace(jumpUrl))
            {
                jumpUrl = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
                                              "/Index";
            }
            return Json(new { status = 1, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 返回json错误提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jumpUrl"></param>
        /// <returns></returns>
        public ActionResult JsonErrorJump(string message = SaveError1, string jumpUrl = "")
        {
            return Json(new { status = 0, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
