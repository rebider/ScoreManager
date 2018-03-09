
//*****************************************************************
//
// File Name:   UserLoginLogController.cs
//
// Description:  UserLoginLog:
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
    public partial class UserLoginLogController: BaseController
    {
        public ActionResult  UserLoginLogIndex(Page<UserLoginLogModel> model)
        {
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
                    if(model.Item.LoginTime != null){
                        where.AppendFormat(" and LoginTime = {0} ", model.Item.LoginTime);
                    }
                    if (!string.IsNullOrEmpty(model.Item.LoginIp))
                    {
                        where.AppendFormat(" and LoginIp like '%{0}%' ", model.Item.LoginIp.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.DeviceID))
                    {
                        where.AppendFormat(" and DeviceID like '%{0}%' ", model.Item.DeviceID.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.DeviceOS))
                    {
                        where.AppendFormat(" and DeviceOS like '%{0}%' ", model.Item.DeviceOS.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.AppVersion))
                    {
                        where.AppendFormat(" and AppVersion like '%{0}%' ", model.Item.AppVersion.Trim());
                    }
            }
            var page = UserLoginLogModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(UserLoginLogModel));
            return View(page);
        }
        
       
        
        #region 编辑
        
        [HttpGet]
        public ActionResult  UserLoginLogEdit(object id,int actiontype=0)
		{
            ViewData[EditFlag] = true;
             if (actiontype==1)
            {
             UserLoginLogModel model= new UserLoginLogModel();
               return View(model);
            }else {
            UserLoginLogModel model=UserLoginLogModel.SingleOrDefault(id);
            return View(model);
            }
			
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult  UserLoginLogEdit(UserLoginLogModel model)
		{
            if (string.IsNullOrEmpty(model.ID))
                {
                     ViewData[EditFlag] = true;
                    
                    if (model.Insert()!=null)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(UserLoginLogModel));
                        return JsonSuccess("");
                    }
                       return JsonError("");
            }
            else{
                ViewData[EditFlag] = true;
                if (model.Update()>0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(UserLoginLogModel));
                    return JsonSuccess("");
                }
               return JsonError("");
            }
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult UserLoginLogDetails(object id)
        {
            ViewData[EditFlag] = true;
            var item = UserLoginLogModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            UserLoginLogModel.Delete(" where ID in ('@0')",id);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(UserLoginLogModel));
            
            return JsonSuccess(DeleteSuccess);
        }
        
            public ActionResult DeleteForWhere(string Where)
        {
          
            UserLoginLogModel.Delete(Where);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(UserLoginLogModel));

            return JsonSuccess(DeleteSuccess);
        }
        
        #endregion
	}
}

