
//*****************************************************************
//
// File Name:   SystemParamController.cs
//
// Description:  SystemParam:
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
    public partial class SystemParamController: BaseController
    {
        public ActionResult  SystemParamIndex(Page<SystemParamModel> model , string orderby)
        {
            ViewBag.orderby = orderby;
            if (model.CurrentPage <= 0)
            {
                model.CurrentPage = 1;
            }
            StringBuilder where = new StringBuilder(" where 1=1 ");
            if (model.Item != null)
            {
                    if(model.Item.ParamID != null){
                        where.AppendFormat(" and ParamID = {0} ", model.Item.ParamID);
                    }
                    if (!string.IsNullOrEmpty(model.Item.ParamName))
                    {
                        where.AppendFormat(" and ParamName like '%{0}%' ", model.Item.ParamName.Trim());
                    }
                    if(model.Item.OrderNo != null){
                        where.AppendFormat(" and OrderNo = {0} ", model.Item.OrderNo);
                    }
            }
            
            if (string.IsNullOrEmpty(orderby))
            {
                where.AppendFormat(" Order by OrderNo desc");
            }
            else
            {
                where.AppendFormat(" order by " + orderby);
            }
            var page = SystemParamModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemParamModel));
            return View(page);
        }
        
       
        
        #region 编辑
        
        [HttpGet]
        public ActionResult  SystemParamEdit(object id,int actiontype=0)
		{
            ViewData[EditFlag] = true;
             if (actiontype==1)
            {
             SystemParamModel model= new SystemParamModel();
               return View(model);
            }else {
            SystemParamModel model=SystemParamModel.SingleOrDefault(id);
            return View(model);
            }
			
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult  SystemParamEdit(SystemParamModel model)
		{
            if (model.OrderNo!=null && model.ParamName!=null && model.ParamValue!=null)
            {
                if (string.IsNullOrEmpty(model.ParamID))
                {
                    ViewData[EditFlag] = true;

                    if (model.Insert() != null)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(SystemParamModel));
                        return JsonSuccess("保存成功");
                    }
                    return JsonError("保存失败");
                }
                else
                {
                    ViewData[EditFlag] = true;
                    if (model.Update() > 0)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(SystemParamModel));
                        return JsonSuccess("保存成功");
                    }
                    return JsonError("保存失败");
                }
            }
            else
            {
                return JsonError("请填写完整信息");
            }
            
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult SystemParamDetails(object id)
        {
            ViewData[EditFlag] = true;
            var item = SystemParamModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            SystemParamModel.Delete(" where ParamID in ("+id+ ")");
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemParamModel));
            
            return JsonSuccess(DeleteSuccess);
        }
        
            public ActionResult DeleteForWhere(string Where)
        {
          
            SystemParamModel.Delete(Where);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(SystemParamModel));

            return JsonSuccess(DeleteSuccess);
        }
        
        #endregion
	}
}

