
//*****************************************************************
//
// File Name:   GlobalSqlController.cs
//
// Description:  Global_Sql:系统SQL统一管理
//
// Coder:       CodeSmith Generate
//
// Date:        2015-03-25 
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
    public partial class GlobalSqlController: BaseController
    {
        public ActionResult Index(Page<GlobalSqlModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder("where 1=1 and ISNULL(DelFlag,0) = 0 ");
            if (model.Item != null)
            {
                    if (!string.IsNullOrEmpty(model.Item.SQLKey))
                    {
                        where.AppendFormat(" and SQLKey like '%{0}%' ", model.Item.SQLKey.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.SQLContent))
                    {
                        where.AppendFormat(" and SQLContent like '%{0}%' ", model.Item.SQLContent.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.SqlConnection))
                    {
                        where.AppendFormat(" and SqlConnection like '%{0}%' ", model.Item.SqlConnection.Trim());
                    }
                    if(model.Item.DelFlag != null){
                        where.AppendFormat(" and DelFlag = {0} ", model.Item.DelFlag.Value);
                    }
            }
            where.Append(" order by CreateTime desc ");
            var page = GlobalSqlModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(GlobalSqlModel));
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
        [ValidateInput(false)]
		public ActionResult Add(GlobalSqlModel model)
        {
            GlobalSqlModel gmodel = GlobalSqlModel.FirstOrDefault(" where SqlKey= @0", model.SQLKey);
            if (gmodel!= null)
            {
                return JsonError("SqlKey已存在！");
            }
            ViewData[EditFlag] = true;
            if (model.Insert()!=null)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(GlobalSqlModel));
                return JsonSuccess("");
            }
            return JsonError("");
        }
        
        #endregion
        
        #region 编辑
        
        [HttpGet]
        public ActionResult Edit(object id)
		{
            ViewData[EditFlag] = true;
			GlobalSqlModel model=GlobalSqlModel.SingleOrDefault(id);
			return View(model);
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult Edit(GlobalSqlModel model)
		{
            ViewData[EditFlag] = true;
            if (model.Update()>0)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(GlobalSqlModel));
                return JsonSuccess("");
            }
            return JsonError("");
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult Details(object id)
        {
            ViewData[EditFlag] = true;
            var item = GlobalSqlModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            string[] tmp = id.Split(',');
            foreach (string item in tmp)
            {
                GlobalSqlModel.Update("set DelFlag = 1 where ID=@0", item);
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(GlobalSqlModel));
            }

            return JsonSuccess("");
        }
        
        #endregion
	}
}

