using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using MT.Common;

namespace MT.Areas.Web.Controllers
{
    public class BaseController : System.Web.Mvc.Controller
    {
        #region 返回参数
        public string Time = "time";

        protected string Info = "info";

        protected string EditFlag = "EditFlag";

        protected string SaveSuccess = MTConfig.UserLang == "En" ? "Save Success" : "保存成功";

        protected string SaveError = MTConfig.UserLang == "En" ? "Save Failed" : "保存失败";

        protected string DeleteSuccess = MTConfig.UserLang == "En" ? "Delete Success" : "删除成功";

        protected string DeleteError = MTConfig.UserLang == "En" ? "Delete Failed" : "删除失败";

        protected string ResetSuccess = MTConfig.UserLang == "En" ? "Reset successful" : "重置成功";
        protected string ResetEmaiSuccess = MTConfig.UserLang == "En" ? "Successful submission of replacement application, modified password link has been sent to your mail" : "重置申请提交成功，修改密码链接已发送到您邮件";

        protected string CreateAccountSuccess = MTConfig.UserLang == "En" ? "Created MT4 account Successfully , please be patient for review" : "成功创建MT4账户，请耐心等待审核";

        protected string ResetSuccess1 = MTConfig.UserLang == "En" ? "Please Login Email for checking your password" : "请登录邮箱，确认密码";

        protected string NoUser = MTConfig.UserLang == "En" ? "User Does Not Exist" : "用户不存在";

        protected string SuccessNoEmail = MTConfig.UserLang == "En" ? "Reset success, but email error,please contact administrator" : "重置成功，但邮件未发送，请联系管理员";

        protected string ResetFailed = MTConfig.UserLang == "En" ? "Reset failed" : "重置失败";

        protected string FormatFailed = MTConfig.UserLang == "En" ? "The format of email is error" : "电子邮箱格式错误";

        protected string EmptyEmail = MTConfig.UserLang == "En" ? "The email can not empty" : "邮箱不能为空";

        protected string SettleSuccess = MTConfig.UserLang == "En" ? "Settle Success" : "结算成功";

        protected string SettleFailed = MTConfig.UserLang == "En" ? "Settle Failed" : "结算失败";

        protected string NoCommision = MTConfig.UserLang == "En" ? "No Commision" : "无佣金可结算";

        protected string CommisionIn = MTConfig.UserLang == "En" ? "Commision Into Wallet" : "佣金转入";

        protected string ProCommisionIn = MTConfig.UserLang == "En" ? "Recommended rewards" : "推荐奖励";

        protected string SettleError = MTConfig.UserLang == "En" ? "Settle Success But Stream Of Option Write Error" : "结算成功但记录流水错误 ！";

        protected string CodeError = MTConfig.UserLang == "En" ? "System Error,Please contact administrator" : "发生内部错误，请联系管理员";

        protected string MoneyEmpty = MTConfig.UserLang == "En" ? "The money can not empty" : "金额不能为空";

        protected string ChangeSuccess = MTConfig.UserLang == "En" ? "Operation Success" : "调整成功";

        protected string NotFoundUser = MTConfig.UserLang == "En" ? "User Not Found" : "此用户不存在";

        protected string MeToMe = MTConfig.UserLang == "En" ? "Can Not Into Wallet Of Yourself" : "不能转到自己的钱包";

        protected string ChangeFailed = MTConfig.UserLang == "En" ? "Operation Failed" : "调整失败";

        protected string BalanceNotEnough = MTConfig.UserLang == "En" ? "Balance Not Enough" : "余额不足";

        protected string UserUpdateError = MTConfig.UserLang == "En" ? "User Update Error" : "用户更新失败";

        protected string AddAccountError = MTConfig.UserLang == "En" ? "Trading accounts are already reach the limit. If you want to open more accounts, please contact customer service." : "交易账户达到上限。若要再创建交易账户，请联系客服";

        protected string AddSuccess = MTConfig.UserLang == "En" ? "Add Success" : "添加成功,审核中...";

        protected string AddFailed = MTConfig.UserLang == "En" ? "Add Failed" : "添加失败";

        protected string LogOut = MTConfig.UserLang == "En" ? "Are you sure to exit?" : "你真的要退出吗？";

        protected string PhoneExist = MTConfig.UserLang == "En" ? "The phone number already exists" : "该电话号码已存在";

        protected string Repeat = MTConfig.UserLang == "En" ? "30 Sseconds Can Not Be Repeat Submit" : "5秒之内不能重复操作";

        protected string Refresh = MTConfig.UserLang == "En" ? "5 Minutes Can Not Be Repeated Refresh" : "5分钟之内不可重复刷新";

        protected string VersionError = "用户版本错误";

        protected string DeleteSuccess_Flag = "停用成功";

        protected string DeleteError_Flag = "停用失败";

        protected string AddSuccess_Flag = "启用成功";

        protected string AddError_Flag = "启用失败";

        protected string JumpUrl = "jumpUrl";

        protected int ErrorTime = 3;

        protected int SuccessTime = 2;

        //Mt4账户提取
        //protected string Mt4TradingAccount = MTConfig.UserLang == "En" ? "Mt4 Trading Account" : "Mt4交易账户";
        //protected string NewEmailAddress = MTConfig.UserLang == "En" ? "New Email Address" : "新Email地址 ";
        //protected string MakeSureEmailAddress = MTConfig.UserLang == "En" ? "Make Sure Email Address" : "确认Email地址 "; 
        protected string Mt4TradingAccount = MTConfig.UserLang == "En" ? "This mail has been registered,Please change the registered mail" : "此邮箱已经注册，请更换注册邮箱";
        protected string SuccessfulExtraction = MTConfig.UserLang == "En" ? "Successful Extraction" : "提取成功";
        protected string FailExtraction = MTConfig.UserLang == "En" ? "Extraction failure" : "提取失败";
        protected string FailExtraction1 = MTConfig.UserLang == "En" ? "Extraction failure，please check mt4 account and password" : "提取失败,请检查mt4账号及密码是否正确";
        protected string PleasechecktheMt4 = MTConfig.UserLang == "En" ? "Please check the Mt4 account is correc" : "请检查Mt4账号是否正确";
        protected string Incorrectmailboxformat = MTConfig.UserLang == "En" ? "Incorrect mailbox format" : "邮箱格式不正确";
        protected string Incorrectmailboxformat1 = MTConfig.UserLang == "En" ? "The mailbox has been registered" : "邮箱已注册";
        protected string Theaccounthasbeenextracted = MTConfig.UserLang == "En" ? "The account has been extracted " : "该账户已提取";
        protected string Incorrect = MTConfig.UserLang == "En" ? "Specifies that the login password has been sent to the specified mailbox. Please log in to view it" : "指定成功，登录密码已发送到指定邮箱，请登录邮箱进行查看";
        protected string Theaccounthasbeene = MTConfig.UserLang == "En" ? "Specified successfully, but the message failed to send successfully. Please contact the administrator " : "指定成功，但邮件未发送成功，请联系管理员";
        //入金
        protected string MoneyPayBtn_4 = MTConfig.UserLang == "En" ? "the currency exchange rate" : "此币种汇率暂无，请重新选择";
        protected string MoneyPayBtn_1 = MTConfig.UserLang == "En" ? "Input amount inconformity criterion" : "输入金额不符合规范";
        protected string MoneyPayBtn_2 = MTConfig.UserLang == "En" ? "Data access error" : "数据接入错误";
        protected string MoneyPayBtn_3 = MTConfig.UserLang == "En" ? "This type of currency is not supported" : "不支持该货币";

        //出金
        protected string MoneyTake_1 = MTConfig.UserLang == "En" ? "Take money request has been sent" : "出金请求已发送";
        protected string MoneyTake_2 = MTConfig.UserLang == "En" ? "Take money request fail" : "出金请求失败";
        protected string MoneyTake_3 = MTConfig.UserLang == "En" ? "no data" : "无数据";
        protected string MoneyTake_4 = MTConfig.UserLang == "En" ? "the amount of gold must be more than $50" : "一次出金金额不能少于$50";
        protected string MoneyTake_5 = MTConfig.UserLang == "En" ? "The amount of the gold is only supported by the cent" : "出金金额只支持到分";
        //认证
        protected string SaveVerifySuccess = MTConfig.UserLang == "En" ? "Certification submitted successfully , undering review" : "认证提交成功,审核中";
        protected string SaveVerifyFailed = MTConfig.UserLang == "En" ? "Certification submitted failed" : "认证提交失败";
        protected string NoUserID = MTConfig.UserLang == "En" ? "User ID cannot be empty" : "用户id不能为空";

        //出金入金接口返回
        protected string OperationsSuccessfully = MTConfig.UserLang == "En" ? "operations to complete successfully" : "操作成功";
        protected string ParameterError = MTConfig.UserLang == "En" ? "parameter error" : "参数错误";
        protected string NoGold = MTConfig.UserLang == "En" ? "You have open orders, and the amount of withdraw must not exceed 50%  equilty of the account." : "您有未平仓单子，出金金额不能大于账户净值的50%";
        protected string NoEnough = MTConfig.UserLang == "En" ? "Account balance is not enough" : "账号余额不足";
        protected string ServerFailed = MTConfig.UserLang == "En" ? "Connection server failed" : "连接服务器失败";
        protected string OperationTimeout = MTConfig.UserLang == "En" ? "Operation timeout" : "操作超时";
        protected string ServerError = MTConfig.UserLang == "En" ? "Server error, please try again later" : "服务器错误 请稍后再试";

        //邮件
        protected string CurrentAccount = MTConfig.UserLang == "En" ? "Current account does not exist" : "当前用户不存在";
        protected string ContactAdministrator = MTConfig.UserLang == "En" ? "Reset Success but The message was not sent successfully,Please contact administrator" : "重置成功，但邮件未发送成功，请联系管理员";
        protected string ResetFail = MTConfig.UserLang == "En" ? "Reset Fail" : "当前用户不存在";
        protected string Passowrd1 = MTConfig.UserLang == "En" ? "Two passwords are inconsistent" : "两次密码不一致";
        protected string Passowrd2 = MTConfig.UserLang == "En" ? "Old password is incorrect" : "旧密码不正确";
        #endregion

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
        //public ActionResult JsonSuccessJump(string message = SaveSuccess, string jumpUrl = "")
        //{
        //    if (string.IsNullOrWhiteSpace(jumpUrl))
        //    {
        //        jumpUrl = "/Admin/" + this.ControllerContext.RouteData.Values["controller"] +
        //                                      "/Index";
        //    }
        //    //return JavaScript("tipreadurl('保存成功','" + jumpUrl + "');");
        //    return Content("tipreadurl('保存成功','" + jumpUrl + "');", "application/x-javascript");
        //    //return JavaScript("alert('插入失败')");
        //    //return Json(new { status = 1, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
        //}

        /// <summary>
        /// 返回json错误提示
        /// </summary>
        /// <param name="message"></param>
        /// <param name="jumpUrl"></param>
        /// <returns></returns>
        //public ActionResult JsonErrorJump(string message = SaveError, string jumpUrl = "")
        //{
        //    //return Json(new { status = 0, msg = message, jumpUrl }, JsonRequestBehavior.AllowGet);
        //    return Content("tipreadurl('" + message + "','" + jumpUrl + "');", "application/x-javascript");
        //}



        #endregion
    }
}
