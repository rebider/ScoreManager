using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MT.Models.ViewModels;
using NetDimension.Web;
using NetDimension.Weibo;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System;
using MT.Common;
using System.Text;
using PetaPoco.Internal;
using RennDotSDK;
using RennDotSDK.APIUtility;
using RennDotSDK.Model;

namespace MT.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        //#region QQ联合登录和绑定

        ///// <summary>
        ///// 根据js方法获得联合登录地址并跳转页面
        ///// </summary>
        ///// <param name="redirectUrl"></param>
        ///// <returns></returns>
        //public ActionResult QqLogin(string redirectUrl = "/Admin/Login/QqLogin2")
        //{
        //    ViewBag.redirectUrl = redirectUrl;
        //    return View();
        //}

        ///// <summary>
        ///// 接收令牌和openid登录
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult QqLogin2()
        //{
        //    string access_token = Request["access_token"];
        //    string openid = Request["openid"];

        //    WebClient client = new WebClient();
        //    byte[] bytes = new byte[] { };
        //    try
        //    {
        //        bytes =
        //                client.DownloadData("https://graph.qq.com/user/get_user_info?oauth_consumer_key=" + MTConfig.AppId +
        //                                    "&access_token=" + access_token + "&openid=" + openid + "&format=json");
        //    }
        //    catch (Exception)
        //    {
        //        bytes =
        //                client.DownloadData("https://graph.qq.com/user/get_user_info?oauth_consumer_key=" + MTConfig.AppId +
        //                                    "&access_token=" + access_token + "&openid=" + openid + "&format=json");
        //    }
        //    string json = Encoding.UTF8.GetString(bytes);

        //    //UserSoapClient soap = new UserSoapClient();
        //    //List<UserModel> userList = soap.GetUsers(string.Format("where Mac_QQ = '{0}'", openid)).ToList();
        //    //if (userList.Count > 0)
        //    //{
        //    //    MTConfig.CurrentUser = userList[0];

        //    //    return Login(MTConfig.CurrentUser.Name, MTConfig.CurrentUser.Password, "");
        //    //}

        //    JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    serializer.MaxJsonLength = int.MaxValue;
        //    QQViewModel qqViewModel = serializer.Deserialize<QQViewModel>(json);

        //    if (qqViewModel.ret.ToInt() < 0)
        //    {
        //        return Content(qqViewModel.msg);
        //    }

        //    ViewBag.openid = openid;
        //    return View();
        //}

        ///// <summary>
        ///// 验证是否存在该账户
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult QqLogin3()
        //{
        //    string name = Request["Name"];
        //    string password = Request["Password"];
        //    string openid = Request["openid"];

        //    UserSoapClient soap = new UserSoapClient();

        //    List<UserModel> tmpList = soap.GetUsers(string.Format(" where Mac_Qq = '{0}' ", openid)).ToList();
        //    if (tmpList.Count > 0)
        //    {
        //        return JsonError("该账号已绑定过账号！");
        //    }

        //    List<UserModel> userList = soap.GetUsers(string.Format("where Name = '{0}' ", name)).ToList();
        //    if (userList.Count == 0)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    if (userList[0].Password != password)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    userList[0].MacQq = openid;
        //    ServiceResponse response = soap.ModifyUser(userList[0]);

        //    if (response.Status == 0)
        //    {
        //        return JsonError("绑定失败！");
        //    }

        //    MTConfig.CurrentUser = soap.Login(userList[0].Name, userList[0].Password);

        //    return JsonSuccess("/Admin/Public/Index");
        //}

        ///// <summary>
        ///// QQ绑定显示信息界面
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult QqBind()
        //{
        //    return View();
        //}

        ///// <summary>
        ///// QQ绑定第二步 并跳转界面
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult QqBind2()
        //{
        //    string openid = Request["openid"];

        //    if (string.IsNullOrEmpty(openid))
        //    {
        //        return Content("未检测到openid");
        //    }

        //    UserSoapClient soap = new UserSoapClient();

        //    List<UserModel> userList = soap.GetUsers(string.Format("where Qq = '{0}'", openid)).ToList();
        //    if (userList.Count > 0)
        //    {
        //        return Content("该QQ账户已绑定过其他账户！");
        //    }

        //    UserModel user = MTConfig.CurrentUser;
        //    user.Qq = openid;

        //    ServiceResponse response = soap.ModifyUser(user);
        //    if (response.Status == 1)
        //    {
        //        MTConfig.CurrentUser = user;
        //        return Redirect("/Admin/Public/Index");
        //    }
        //    return Content("绑定失败！");
        //}

        //#endregion

        //#region 新浪微博联合登录

        ///// <summary>
        ///// 新浪微博登陆第一步
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult WeiboLogin(string code = "")
        //{
        //    NetDimension.Web.Cookie cookie = new NetDimension.Web.Cookie("Weibo", 24, TimeUnit.Hour);
        //    OAuth oauth = new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], ConfigurationManager.AppSettings["CallbackUrl"]);
        //    Client sina = new Client(oauth); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
        //    if (string.IsNullOrEmpty(code))
        //    {
        //        string url = oauth.GetAuthorizeURL();
        //        return Redirect(url);
        //    }
        //    else
        //    {
        //        var token = oauth.GetAccessTokenByAuthorizationCode(Request.QueryString["code"]);
        //        string accessToken = token.Token;

        //        cookie["AccessToken"] = accessToken;
        //        sina = new Client(new OAuth(ConfigurationManager.AppSettings["AppKey"], ConfigurationManager.AppSettings["AppSecret"], cookie["AccessToken"], null)); //用cookie里的accesstoken来实例化OAuth，这样OAuth就有操作权限了
        //        string openid = sina.API.Entity.Account.GetUID();

        //        UserSoapClient soap = new UserSoapClient();
        //        List<UserModel> userList = soap.GetUsers(string.Format("where Mac_Weibo = '{0}'", openid)).ToList();
        //        if (userList.Count > 0)
        //        {
        //            MTConfig.CurrentUser = userList[0];

        //            return Login(MTConfig.CurrentUser.Name, MTConfig.CurrentUser.Password, "");
        //        }
        //        ViewBag.openid = openid;
        //        return View();
        //    }
        //}

        ///// <summary>
        ///// 微博账号绑定
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult WeiboLogin2()
        //{
        //    string name = Request["Name"];
        //    string password = Request["Password"];
        //    string openid = Request["openid"];

        //    UserSoapClient soap = new UserSoapClient();

        //    List<UserModel> tmpList = soap.GetUsers(string.Format(" where Mac_Weibo = '{0}' ", openid)).ToList();
        //    if (tmpList.Count > 0)
        //    {
        //        return JsonError("该账号已绑定过账号！");
        //    }

        //    List<UserModel> userList = soap.GetUsers(string.Format("where Name = '{0}' ", name)).ToList();
        //    if (userList.Count == 0)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    if (userList[0].Password != password)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    userList[0].MacWeibo = openid;
        //    ServiceResponse response = soap.ModifyUser(userList[0]);

        //    if (response.Status == 0)
        //    {
        //        return JsonError("绑定失败！");
        //    }

        //    MTConfig.CurrentUser = soap.Login(userList[0].Name, userList[0].Password);

        //    return JsonError("/Admin/Public/Index");
        //}

        //#endregion

        //#region 人人网联合登录

        ///// <summary>
        ///// 人人网联合登录
        ///// </summary>
        ///// <param name="code"></param>
        //public ActionResult RenRenLogin(string code = "")
        //{
        //    RennClient rr = new RennClient();
        //    if (string.IsNullOrEmpty(code))
        //    {
        //        return Redirect(rr.GetAuthorizationCode());
        //    }
        //    else
        //    {
        //        APIValidation av = new APIValidation();
        //        List<APIParameter> parameters = new List<APIParameter>() { 
        //    new APIParameter("userId", av.GetUserId())
        //};
        //        string responseData = rr.Request("GET", "/v2/user/get", parameters);
        //        RennUserResponse resp = new JavaScriptSerializer().Deserialize<RennUserResponse>(responseData);
        //        string id = resp.response.id;
        //        UserSoapClient soap = new UserSoapClient();
        //        List<UserModel> userList = soap.GetUsers(string.Format("where Mac_RenRen = '{0}'", id)).ToList();
        //        if (userList.Count > 0)
        //        {
        //            MTConfig.CurrentUser = userList[0];

        //            return Login(MTConfig.CurrentUser.Name, MTConfig.CurrentUser.Password, "");
        //        }
        //        return Redirect("/Home/Login/RenRenLogin2?id=" + id);
        //    }
        //}

        ///// <summary>
        ///// 人人登录成功后绑定平台账号界面
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public ActionResult RenRenLogin2(string id)
        //{
        //    ViewBag.openid = id;
        //    return View();
        //}

        ///// <summary>
        ///// 人人登录成功后绑定平台账号提交
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult RenRenLogin3()
        //{
        //    string name = Request["Name"];
        //    string password = Request["Password"];
        //    string openid = Request["openid"];

        //    UserSoapClient soap = new UserSoapClient();

        //    List<UserModel> tmpList = soap.GetUsers(string.Format(" where Mac_RenRen = '{0}' ", openid)).ToList();
        //    if (tmpList.Count > 0)
        //    {
        //        return JsonError("该账号已绑定过账号！");
        //    }

        //    List<UserModel> userList = soap.GetUsers(string.Format("where Name = '{0}' ", name)).ToList();
        //    if (userList.Count == 0)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    if (userList[0].Password != password)
        //    {
        //        return JsonError("账号或密码错误！");
        //    }

        //    userList[0].MacRenren = openid;
        //    ServiceResponse response = soap.ModifyUser(userList[0]);

        //    if (response.Status == 0)
        //    {
        //        return JsonError("绑定失败！");
        //    }

        //    MTConfig.CurrentUser = soap.Login(userList[0].Name, userList[0].Password);

        //    return JsonSuccess("/Admin/Public/Index");
        //}

        //#endregion

        ///// <summary>
        ///// 联合登录通用登录逻辑
        ///// </summary>
        ///// <param name="account"></param>
        ///// <param name="password"></param>
        ///// <param name="remember"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public ActionResult Login(string account, string password, string remember)
        //{
        //    UserSoapClient client = new UserSoapClient();

        //    MTConfig.CurrentUser =
        //        client.Login(account, password);
        //    if (MTConfig.CurrentUser != null && !string.IsNullOrEmpty(MTConfig.CurrentUser.Id))
        //    {
        //        if (!string.IsNullOrEmpty(remember))
        //        {
        //            HttpCookie cookie = new HttpCookie(MTConfig.LoginRememberCookie);
        //            cookie.Values[MTConfig.UserInfoKey] = MTConfig.CurrentUserID;
        //            cookie.Expires = DateTime.MaxValue;
        //            Response.Cookies.Add(cookie);
        //        }

        //        if (MTConfig.CurrentUser.LastLoginTime.HasValue)
        //        {
        //            return Redirect("/Admin/Public/Index");
        //        }
        //        return Redirect("/Admin/Public/Index?FirstLogin=1");
        //    }

        //    return Content("请输入账户和密码！");
        //}
    }
}
