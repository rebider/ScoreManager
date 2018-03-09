
//*****************************************************************
//
// File Name:   UserController.cs
//
// Description:  User:用户表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using MT.Common;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using cn.jpush.api.util;
using MT.Areas.Admin.ViewModels;
using MT.Common.Helper;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class UserController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(Page<UserModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }

            StringBuilder where = new StringBuilder("where 1 = 1 ");

            //if (MTConfig.CurrentUser.UserType != MTConfig.UserType.Administrator)
            //{
            //    where.AppendFormat(" and UserDepartment = '{0}' ", MTConfig.CurrentUser.UserDepartment);
            //    where.AppendFormat(" and Id != 0 ");
            //}

            if (null != model.Item)
            {
                if (!string.IsNullOrEmpty(model.Item.Name))
                {
                    model.Item.Name = "%" + model.Item.Name + "%";
                    where.AppendFormat(" and Name like @Name");
                }
                if (!string.IsNullOrEmpty(model.Item.UserType))
                {
                    model.Item.UserType = model.Item.UserType;
                    where.AppendFormat(" and UserType = @UserType");
                }
                if (model.Item.DelFlag != null)
                {
                    model.Item.DelFlag = model.Item.DelFlag;
                    where.AppendFormat(" and DelFlag = @DelFlag");
                }
                if (!string.IsNullOrEmpty(model.Item.NickName))
                {
                    model.Item.NickName = "%" + model.Item.NickName + "%";
                    where.Append(" and NickName like @NickName ");
                }
                if (model.Item.CompanyId.HasValue)
                {
                    where.AppendFormat(" and CompanyId = {0} ", model.Item.CompanyId);
                }
            }

            var page = UserModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
            page.Item = model.Item;

            //LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "User");

            return View(page);
        }
        [HttpGet]
        public ActionResult UpdatePas()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdatePas(FormCollection form)
        {
            string pass = form["pass"];
            string pass1 = form["pass1"];
            string pass2 = form["pass2"];
            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(pass1) && !string.IsNullOrEmpty(pass2))
            {
                pass = PwdThreeEncrypt.PasswordThreeMd5Encrypt(pass);
                pass1 = PwdThreeEncrypt.PasswordThreeMd5Encrypt(pass1);
                pass2 = PwdThreeEncrypt.PasswordThreeMd5Encrypt(pass2);
            }
            if (pass1 != pass2)
            {
                return Error("新密码不一致，请重新输入！");
            }
            UserModel users = new UserModel();
            users = UserModel.FirstOrDefault("  where Password = '" + pass + "' and Name = '" + MTConfig.CurrentUser.Name + "' ");
            if (users != null && users.Name != "")
            {
                if (UserModel.Update(" set Password = '" + pass1 + "' where  name = '" + MTConfig.CurrentUser.Name + "' ") > 0)
                {
                    return Success(SaveSuccess, "/Admin/User/UpdatePas");
                }
                else
                {
                    return Error();
                }
            }
            else
            {
                return Error("用户密码错误！");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewData[EditFlag] = true;
            UserProductViewModel userpor = new UserProductViewModel();

            userpor.ProductList = ProductModel.Fetch("");
            userpor.RoleList = RoleModel.Fetch("");
            return View(userpor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(UserProductViewModel model, string[] roleIds)
        {
            if (UserDAL.Add(model.User, roleIds))
            {
                return JsonSuccess("");
            }
            ViewData[Info] = SaveError;
            return JsonError("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public ActionResult Details(int? id)
        //{
        //    var item = UserModel.Single(id);
        //    return View(item);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int? id,int actiontype=0)
        {
            UserProductViewModel userpor = new UserProductViewModel();
            ViewBag.actiontype = actiontype;
            if (actiontype==1)
            {
                ViewData[EditFlag] = true;
                userpor.ProductList = ProductModel.Fetch("");
                userpor.RoleList = RoleModel.Fetch("");
                return View(userpor);
            }
            userpor.ProductList = ProductModel.Fetch("");
            userpor.UserProductList = UserProductModel.Fetch(" where userid = " + id);
            userpor.RoleList = RoleModel.Fetch("");
            userpor.UserRoleList = UserRoleModel.Fetch(" where userid = " + id);
            userpor.User = UserModel.FirstOrDefault(" where id = " + id);
            ViewData[EditFlag] = true;
            return View(userpor);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(UserProductViewModel model, string[] roleIds)
        {
            if (string.IsNullOrEmpty(model.User.ID))
            {
                if (UserDAL.Add(model.User, roleIds))
                {
                    return JsonSuccess("");
                }
                ViewData[Info] = SaveError;
                return JsonError("");
            }
            else
            {
                if (UserDAL.Edit(model.User, roleIds))
                {
                    return JsonSuccess("");
                }
            }
          
            ViewData[Info] = SaveError;
            return JsonError("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            if (UserDAL.DeleteFlag(id))
            {
                return Success("停用成功！");
            }
            return Error("停用失败！");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Start(string id)
        {
            if (UserDAL.StartFlag(id))
            {
                return Success("启用成功！");
            }
            return Error("启用失败！");
        }

        [HttpGet]
        public ActionResult ModifyPassword()
        {
            UserViewModel model = new UserViewModel();
            ViewData[EditFlag] = true;
            return View();
        }

        [HttpPost]
        public ActionResult ModifyPassword(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = MTConfig.CurrentUserID.ToInt();
                if (UserDAL.UpdatePassword(model))
                {
                    return Success(SaveSuccess, "/Admin/User/ModifyPassword");
                }
                return Error();
            }
            return Error();
        }
    }
}

