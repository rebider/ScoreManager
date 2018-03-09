
//*****************************************************************
//
// File Name:   RoleController.cs
//
// Description:  角色管理
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
using System.Text;
using System;
using MT.Common;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class RoleController : BaseController
    {
      
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Index(Page<RoleModel> model)
        {
           
            model.ItemsPerPage = 20;
            if (model.CurrentPage == 0)
                model.CurrentPage = 1;
            StringBuilder sbwhere = new StringBuilder(" where DelFlag=0 ");
            if (model.Item != null)
            {
                if (!string.IsNullOrEmpty(model.Item.Name))
                {
                    sbwhere.AppendFormat(" and Name like '%{0}%'", model.Item.Name);
                }
            }
            sbwhere.Append(" order by SortNo asc ");
            var items = RoleModel.Page(model.CurrentPage, model.ItemsPerPage, sbwhere.ToString());
            items.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Role");
            return View(items);
        }

        #region 添加

        [HttpGet]
        public ActionResult Add()
        {
            RoleModel model = new RoleModel();
            ViewData[EditFlag] = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            model.ID = "0";
            model.DelFlag = 0;
            model.CreateMan = Common.MTConfig.CurrentUserID.ToInt();
            model.CreateTime = DateTime.Now;
            model.ModifyMan = Common.MTConfig.CurrentUserID.ToInt();
            model.ModifyTime = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (model.Insert() != null)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Role");
                    return JsonSuccess(SaveSuccess, "/Admin/Role/Index" );
                }
            }

            return Error(SaveError);
        }

        #endregion

        #region 编辑

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ViewData[EditFlag] = true;
            RoleModel model = RoleModel.SingleOrDefault(id);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Role");
            return View(model);
        }

        /// <summary>
        /// 角色信息编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var item = RoleModel.Single(model.ID);

                model.DelFlag = item.DelFlag;
                model.CreateMan = item.CreateMan;
                model.CreateTime = model.CreateTime;
                model.ModifyTime = DateTime.Now;
                model.ModifyMan = MTConfig.CurrentUserID.ToInt();
                

                if (model.Update() > 0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Role");
                    return JsonSuccess(SaveSuccess, "/Admin/Role/Index" );
                }
            }

            return Error(SaveError);
        }

        #endregion

        #region 详情

        public ActionResult Details(string id)
        {
            var item = RoleModel.SingleOrDefault(id);
            return View(item);
        }

        #endregion

        #region 删除

        public ActionResult Delete(string id)
        {
            var first = new RoleModel{ID = ""};
            string[] tmp = id.Split(',');
            foreach (string item in tmp)
            {
                if (string.IsNullOrEmpty(first.ID))
                {
                    first = RoleModel.FirstOrDefault("where Id= @0", item);
                }
                RoleModel.Delete("where ID=@0", item);
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(RoleModel));
            }
            return JsonSuccess(DeleteSuccess, "/Admin/Group/Index?Item.ProductId=" + first.ProductId);
        }

        #endregion
    }
}

