
//*****************************************************************
//
// File Name:   GroupController.cs
//
// Description:  Group:分组表
//
// Coder:       CodeSmith Generate
//
// Date:        2014-04-08 
//
//*****************************************************************

using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System.Collections.Generic;
using MT.Areas.Admin.Controllers;
using MT.Common;
using System.Text;
using MT.Areas.Admin.ViewModels;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class GroupController : BaseController
    {
        public ActionResult Index(Page<GroupModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder("where DelFlag = 0 ");
            if (model.Item != null)
            {
                where.AppendFormat(" and ProductId = {0} ", model.Item.ProductId);
                if (!string.IsNullOrEmpty(model.Item.Name))
                {
                    where.AppendFormat(" and Name like '%{0}%' ", model.Item.Name.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.Title))
                {
                    where.AppendFormat(" and Title like '%{0}%' ", model.Item.Title.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.Target))
                {
                    where.AppendFormat(" and Target like '%{0}%' ", model.Item.Target.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.Url))
                {
                    where.AppendFormat(" and Url like '%{0}%' ", model.Item.Url.Trim());
                }
                if (model.Item.SortNo != null)
                {
                    where.AppendFormat(" and SortNo = {0} ", model.Item.SortNo.Value);
                }
            }
            var page = GroupModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(GroupModel));
            return View(page);
        }

        #region 添加

        [HttpGet]
        public ActionResult Add(int? productId)
        {
            GroupModel model = new GroupModel()
                {
                    ProductId = productId
                };
            ViewData[EditFlag] = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(GroupModel model)
        {
            ViewData[EditFlag] = true;
            if (model.Insert() != null)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(GroupModel));
                return JsonSuccess(SaveSuccess, "/Admin/Group/Index?Item.ProductId=" + model.ProductId);
            }
            return Error();
        }

        #endregion

        #region 编辑

        [HttpGet]
        public ActionResult Edit(object id)
        {
            ViewData[EditFlag] = true;
            GroupModel model = GroupModel.SingleOrDefault(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GroupModel model)
        {
            ViewData[EditFlag] = true;
            if (model.Update() > 0)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(GroupModel));
                return JsonSuccess(SaveSuccess, "/Admin/Group/Index?Item.ProductId=" + model.ProductId);
            }
            return Error();
        }

        #endregion

        #region 详情

        public ActionResult Details(object id)
        {
            ViewData[EditFlag] = true;
            var item = GroupModel.SingleOrDefault(id);
            return View(item);
        }

        #endregion

        #region 删除

        public ActionResult Delete(string id)
        {
            var first = new GroupModel(){ID = ""};
            string[] tmp = id.Split(',');
            foreach (string item in tmp)
            {
                if (string.IsNullOrEmpty(first.ID))
                {
                    first = GroupModel.FirstOrDefault("where Id= @0", item);
                }
                GroupModel.Delete("where ID=@0", item);
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(GroupModel));
            }

            return JsonSuccess(DeleteSuccess, "/Admin/Group/Index?Item.ProductId=" + first.ProductId);
        }

        #endregion
    }
}

