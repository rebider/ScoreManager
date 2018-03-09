
//*****************************************************************
//
// File Name:   CacheController.cs
//
// Description:  Cache:统一配置系统使用到的缓存,确保缓存键值一致不冲突
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using System.Text;
using System.Web.Mvc;
using MT.Common;
using PetaPoco;
using MT.Dal;
using MT.Models;

namespace MT.Areas.Admin.Controllers
{
    public partial class CacheController : BaseController
    {
        public ActionResult Index(Page<CacheModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
  
            StringBuilder where = new StringBuilder("select c.*,u.ChName as Ssssname  from  Cache c left join XUser u on c.CacheValue = u.Id  where  c.DelFlag=0  ");
            if (model.Item != null)
            {
                if (!string.IsNullOrEmpty(model.Item.CacheKey))
                {
                    where.AppendFormat(" and CacheKey like '%{0}%' ", model.Item.CacheKey.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.Ssssname))
                {
                    where.AppendFormat(" and  u.ChName like '%{0}%' ", model.Item.Ssssname.Trim());
                }
            }
            where.AppendFormat(" order by c.createtime desc ");
            var page = CacheModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(CacheModel));

            return View(page);
        }

        #region 添加

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.EditFlag = true;
            return View();
        }

        [HttpPost]
        public ActionResult Add(CacheModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Insert() != null)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Cache");
                    return Success();
                }
            }

            TempData[Info] = SaveError;
            return Error();
        }

        #endregion

        #region 编辑

        [HttpGet]
        public ActionResult Edit(string id)
        {
            CacheModel model = CacheModel.SingleOrDefault(id);
            ViewBag.EditFlag = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CacheModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Update() > 0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Cache");
                    return Success();
                }
            }

            TempData[Info] = SaveError;
            return Error();
        }

        #endregion

        #region 详情

        public ActionResult Details(string id)
        {
            var item = CacheModel.SingleOrDefault(id);
            return View(item);
        }

        #endregion

        #region 删除

        public ActionResult Delete()
        {
            CacheModel.Delete(" where delflag =1 or ( (SELECT DATEADD(ss,cachetimes,CreateTime)) < getdate() and  cachetimes !=0) ");
            return Success();
        }

        #endregion
    }
}

