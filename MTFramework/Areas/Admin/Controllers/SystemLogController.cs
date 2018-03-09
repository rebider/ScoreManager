
//*****************************************************************
//
// File Name:   SystemLogController.cs
//
// Description:  SystemLog:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-30 
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
    public partial class SystemLogController: BaseController
    {
        public ActionResult  SystemLogIndex(Page<SystemLogModel> model,string orderby = "")
        {
            ViewBag.orderby = orderby;
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder("where 1=1 ");
            if (model.Item != null)
            {
                    if(model.Item.ID != null){
                        where.AppendFormat(" and ID = {0} ", model.Item.ID);
                    }
                    if(model.Item.UserID != null){
                        where.AppendFormat(" and UserID = {0} ", model.Item.UserID);
                    }
                    if(model.Item.Type != null){
                        where.AppendFormat(" and Type = {0} ", model.Item.Type);
                    }
                    if (!string.IsNullOrEmpty(model.Item.LogInfo))
                    {
                        where.AppendFormat(" and LogInfo like '%{0}%' ", model.Item.LogInfo.Trim());
                    }
                    if(model.Item.InsTime != null){
                        where.AppendFormat(" and CONVERT(varchar(100),InsTime,23) = '{0}' ", model.Item.InsTime.Value.ToString("yyyy-MM-dd"));
                    }
                    if (!string.IsNullOrEmpty(model.Item.IP))
                    {
                        where.AppendFormat(" and IP like '%{0}%' ", model.Item.IP.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.Parameters))
                    {
                        where.AppendFormat(" and Parameters like '%{0}%' ", model.Item.Parameters.Trim());
                    }
            }
            if (string.IsNullOrEmpty(orderby))
            {
                where.Append(" order  by ID desc");
            }
            else
            {
                where.Append(" order  by  " + orderby + "");
            }
            var page = SystemLogModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemLogModel));
            return View(page);
        }
        
       
        
        #region 编辑
        
        [HttpGet]
        public ActionResult  SystemLogEdit(object id,int actiontype=0)
		{
            ViewData[EditFlag] = true;

             if (actiontype==1)
            {
             SystemLogModel model= new SystemLogModel();
               return View(model);
            }else {
            SystemLogModel model=SystemLogModel.SingleOrDefault(id);
            return View(model);
            }
			
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult  SystemLogEdit(SystemLogModel model)
		{
            if (string.IsNullOrEmpty(model.ID))
                {
                     ViewData[EditFlag] = true;
                    model.InsTime = System.DateTime.Now;
                    if (model.Insert()!=null)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemLogModel));
                        return JsonSuccess("");
                    }
                       return JsonError("");
            }
            else{
                ViewData[EditFlag] = true;
                model.InsTime = System.DateTime.Now;
                if (model.Update()>0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemLogModel));
                    return JsonSuccess("");
                }
               return JsonError("");
            }
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult SystemLogDetails(object id)
        {
            ViewData[EditFlag] = true;
            var item = SystemLogModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            SystemLogModel.Delete(" where ID in (" + id + ")");
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemLogModel));
            
            return JsonSuccess(DeleteSuccess);
        }
        
            public ActionResult DeleteForWhere(string Where)
        {
          
            SystemLogModel.Delete(Where);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemLogModel));

            return JsonSuccess(DeleteSuccess);
        }
        
        #endregion
	}
}

