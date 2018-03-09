
//*****************************************************************
//
// File Name:   ProductController.cs
//
// Description:  Product:
//
// Coder:       CodeSmith Generate
//
// Date:        2014-06-05 
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

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class ProductController: BaseController
    {
        public ActionResult Index(Page<ProductModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder("where 1=1");
            if (model.Item != null)
            {
                    if (!string.IsNullOrEmpty(model.Item.Name))
                    {
                        where.AppendFormat(" and Name like '%{0}%' ", model.Item.Name.Trim());
                    }
                 
            }
            var page = ProductModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ProductModel));
            return View(page);
        }
        
        #region 添加
        
        [HttpGet]
        public ActionResult Add()
		{
            ViewData[EditFlag] = true;
			return View();
		}
        
        [HttpPost]
		public ActionResult Add(ProductModel model)
		{
            ViewData[EditFlag] = true;
            if (model.Insert()!=null)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ProductModel));
                return JsonSuccess("");
            }
            return Error();
		}
        
        #endregion
        
        #region 编辑
        
        [HttpGet]
        public ActionResult Edit(object id)
		{
            ViewData[EditFlag] = true;
			ProductModel model=ProductModel.SingleOrDefault(id);
			return View(model);
		}
        
        [HttpPost]
		public ActionResult Edit(ProductModel model)
		{
            ViewData[EditFlag] = true;
            if (model.Update()>0)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ProductModel));
                return JsonSuccess("");
            }
            return Error();
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult Details(object id)
        {
            ViewData[EditFlag] = true;
            var item = ProductModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
	}
}

