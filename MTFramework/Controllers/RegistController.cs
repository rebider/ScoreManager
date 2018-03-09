using cn.jpush.api.util;
using MT.Common;
using MT.Dal;
using MT.Models;
using MT.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Xfrog.Net;
using DotNet.Http.Core;
using System.Text;
using MT.Common.Helper;
using System.Text.RegularExpressions;

namespace MT.Controllers
{
    public class RegistController :BaseController
    {
        //
        // GET: /Regist/RegistUser
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserCode"> IB </param>    
        /// <returns></returns>
        #region 注册用户
        [HttpGet]
        public ActionResult RegistUser(string re="",string lang="")
        {
            if (MTConfig.UserLang == "En")
            {
                MTConfig.UserLang = "En";
            }
            else
            {
                MTConfig.UserLang = "Cn";
            }
            if (!string.IsNullOrEmpty(re))
            {
                if (re.Length > 10)
                {
                    re = Common.Helper.Encrypt.DeEncrypt_Base64(re);
                }
                //string data = Common.Helper.Encrypt.DeEncrypt_Base64(re);
                string[] arry = re.Split('&');
                ViewBag.RERegist = arry[0];
            }
            else
            {
                ViewBag.RERegist = re;

            }     
            return View();
        }
        [HttpPost]
        public ActionResult RegistUser(UserInfoModel model,string cofmemail = "",string cofmpassword = "",int IsEmployee = 0)
        {

           
            if (string.IsNullOrEmpty(model.Sex.ToString()))
            {
                return JsonError(SexError);
            }
            if (string.IsNullOrEmpty(model.Zip.ToString()) || string.IsNullOrEmpty(model.Address))
            {
                return JsonError(ZipAddressError);
            }
            if (string.IsNullOrEmpty(model.UserName))
            {
                return JsonError(UserNameError);
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                return JsonError(Email1);
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                return JsonError(Phone1);
            }
            if (model.Email != cofmemail)
            {
                return JsonError(Email5);
            }
            //邮箱作为登录名是否已经使用,（该方法不会用来注册代理，所以直接判断邮箱就行了，不用考虑代理号登录）
            UserInfoModel userInfo = UserInfoModel.FirstOrDefault("select * from UserInfo where LoginName=@0", model.Email);
            if (userInfo != null)
            {
                return JsonError(Email3);
            }
            //两次密码是否一致
            if (model.Password != cofmpassword) return JsonError(Passowrd1);
            if (Regex.IsMatch(model.Password, "^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,20}$") == false)
            {
                return JsonError(PassowrdRegex);
            }
            model.Password = PwdThreeEncrypt.PasswordThreeMd5Encrypt(model.Password);
            Regex r = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!r.IsMatch(model.Email))
            {
                return JsonError(Email2);
            }
            if (MTConfig.UserLang + "" == "")
            {
                model.Lang = "Cn";
            }
            else
            {
                model.Lang = MTConfig.UserLang; 
            }
            //名字插入
            //if (model.Lang == "En")
            //{
            //    //model.UserNameCn = model.UserName;
            //}
            //else
            //{
            //    if (string.IsNullOrEmpty(model.UserName))
            //    {
            //        return JsonError(UserNameError);
            //    }
            //}
           
            //获取国家电话前缀         
            if (model.Country != null)
            {
                CountryModel countrycode = CountryModel.FirstOrDefault(" where ID = @0",model.Country);
                if (countrycode != null)
                {
                    model.CountryCode = countrycode.AreaCode;
                }
            }
            bool result = Regex.IsMatch(model.Phone, @"^1[3|4|5|7|8][0-9]{9}$");
            if (result == false) return JsonError(Phone2);
            model.LastLoginTime = DateTime.Now;
            model.Birthday = DateTime.Now;
            //给用户更新登录名
            model.LoginName = model.Email;
            //给IB赋值 A代理没有IB    
            UserInfoModel IBModel = new UserInfoModel();
         
            if (model.Insert() != null)
                {
                     return JsonSuccess(SaveSuccess);
                }
                return JsonError(SaveError);
        }
     
        /// <summary>
        /// 根据中文名生成拼音英文名
        /// </summary>
        /// <param name="namecn"></param>
        /// <returns></returns>
        public ActionResult AutoUserName(string namecn="")
        {
            if (!string.IsNullOrEmpty(namecn))
             {
                string first = PinyinHelper.sub(namecn, 1);
                string firstpin = PinyinHelper.ToPinYin(first);
                int num = namecn.Length;
                string other = namecn.Substring(1);
                string otherpin = PinyinHelper.ToPinYin(other);
                string finalpinyin = otherpin + " " + firstpin;
                return Json(new { status = 1, data = finalpinyin }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { status = 1, data = "" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据国家的id查询手机号前缀
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetPhoneArea(string countryId)
        {

            CountryModel couutry = CountryModel.FirstOrDefault(" where ID=@0", countryId);
            if (couutry != null)
            {
                string AreaCode = couutry.AreaCode + "";
                AreaCode = AreaCode.Replace("00", "");
                return JsonSuccess("", new { AreaCode = AreaCode });
            }
            return JsonError(CountryNull);
        }
        #endregion



        #region 异步验证手机和邮箱
        //异步验证手机号
        public ActionResult CheckPhone(string Phone = "")
        {
            if (string.IsNullOrEmpty(Phone)) return JsonError(Phone1);
            bool result = System.Text.RegularExpressions.Regex.IsMatch(Phone, @"^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$");
            if (result == false) return JsonError(Phone2);
            UserInfoModel u1 = UserInfoModel.FirstOrDefault("select * from UserInfo where Phone=@0 ", Phone);
            if (u1 != null) return JsonError(Phone3);
            return JsonSuccess(Phone4);
        }
        //异步验证邮箱
        public ActionResult CheckEmail(string email = "")
        {
            if (string.IsNullOrEmpty(email)) return JsonError(Email1);
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!r.IsMatch(email)) return JsonError(Email2);
            //邮箱是否已经使用
            UserInfoModel userInfo = UserInfoModel.FirstOrDefault("select * from UserInfo where Email=@0", email);
            if (userInfo != null) return JsonError(Email3);
            return JsonSuccess(Email4);
        }
        #endregion

    }
}
