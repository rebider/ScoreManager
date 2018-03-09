
//*****************************************************************
//
// File Name:   LogController.cs
//
// Description:  Log:日志记录表
//
// Coder:       CodeSmith Generate
//
// Date:        2014-04-03 
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
    public partial class LogController: BaseController
    {
        public ActionResult Index(Page<LogModel> model)
        {
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder("where 1=1");
            if (model.Item != null)
            {
                    if(model.Item.UserID != null){
                        where.AppendFormat(" and UserID = {0} ", model.Item.UserID.Value);
                    }
                    if (!string.IsNullOrEmpty(model.Item.TableName))
                    {
                        where.AppendFormat(" and TableName like '%{0}%' ", model.Item.TableName.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.LogType))
                    {
                        where.AppendFormat(" and LogType like '%{0}%' ", model.Item.LogType.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.SQLInfo))
                    {
                        where.AppendFormat(" and SQLInfo like '%{0}%' ", model.Item.SQLInfo.Trim());
                    }
                    if(model.Item.DelFlag != null){
                        where.AppendFormat(" and DelFlag = {0} ", model.Item.DelFlag.Value);
                    }
            }
            model = LogModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(LogModel));
            return View(model);
        }
        
        #region 添加
        
        [HttpGet]
        public ActionResult Add()
		{
            ViewData[EditFlag] = true;
			return View();
		}
        
        [HttpPost]
		public ActionResult Add(LogModel model)
		{
            ViewData[EditFlag] = true;
            if (model.Insert()!=null)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(LogModel));
                return Success();
            }
            return Error();
		}
        
        #endregion
        
        #region 编辑
        
        [HttpGet]
        public ActionResult Edit(object id)
		{
            ViewData[EditFlag] = true;
			LogModel model=LogModel.SingleOrDefault(id);
			return View(model);
		}
        
        [HttpPost]
		public ActionResult Edit(LogModel model)
		{
            ViewData[EditFlag] = true;
            if (model.Update()>0)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(LogModel));
                return Success();
            }
            return Error();
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult Details(object id)
        {
            ViewData[EditFlag] = true;
            var item = LogModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            string[] tmp = id.Split(',');
            foreach (string item in tmp)
            {
                LogModel.Delete("where ID=@0", item);
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(LogModel));
            }

            return Success();
        }
        
        #endregion
	}
}

