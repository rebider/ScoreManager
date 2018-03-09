
//*****************************************************************
//
// File Name:   UserInfoController.cs
//
// Description:  UserInfo:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
//
//*****************************************************************

using System;
using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MT.Areas.Admin.Controllers;
using MT.Common;
using System.Text;
using MT.Common.Helper;
using cn.jpush.api.util;
using MT.Models.ViewModels;

namespace MT.Areas.Admin.Controllers
{
    public partial class UserInfoController : BaseController
    {
        public ActionResult UserInfoIndex(Page<UserInfoModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }

            StringBuilder where = new StringBuilder("select * from Userinfo where 1=1");
            if (model.Item != null)
            {
                if (!string.IsNullOrEmpty(model.Item.UserName))
                {
                    where.AppendFormat(" and UserName like '%{0}%' ", model.Item.UserName.Trim());
                }
            }
            var page = UserInfoModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
            page.Item = model.Item;
            return View(page);
        }

        #region 编辑

        [HttpGet]
        public ActionResult UserInfoEdit(object id, int actiontype = 0)
        {
            ViewData[EditFlag] = true;
            if (actiontype == 1)
            {
                return View(new UserInfoModel());
            }
            else
            {
                UserInfoModel model = UserInfoModel.SingleOrDefault(id);
                return View(model);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UserInfoEdit(UserInfoModel model)
        {
            if (string.IsNullOrEmpty(model.UserID))
            {
                ViewData[EditFlag] = true;

                if (model.Insert() != null)
                {
                    return JsonSuccess("");
                }
                return JsonError("");
            }
            ViewData[EditFlag] = true;
            if (model.Update() > 0)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(UserInfoModel));
                return JsonSuccess("");
            }
            return JsonError("");
        }

        #endregion

        public ActionResult Assign(string userId)
        {
            UserInfoModel model = new UserInfoModel();
            return View(model);
        }

        public ActionResult GetUserList(string roleId)
        {
            List<UserModel> list = UserModel.Fetch("select u.id,u.NickName from [user] u left join UserRole ur on u.id = ur.UserID LEFT join Role r on r.Id = ur.RoleID where ur.RoleID = @0", roleId);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }

}

