
//*****************************************************************
//
// File Name:   FileController.cs
//
// Description:  File:
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
    public partial class FileController: BaseController
    {
        public ActionResult  FileIndex(Page<FileModel> model)
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
                    if (!string.IsNullOrEmpty(model.Item.PathName))
                    {
                        where.AppendFormat(" and PathName like '%{0}%' ", model.Item.PathName.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.ShowName))
                    {
                        where.AppendFormat(" and ShowName like '%{0}%' ", model.Item.ShowName.Trim());
                    }
            }
            var page = FileModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(),model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(FileModel));
            return View(page);
        }
        
       
        
        #region 编辑
        
        [HttpGet]
        public ActionResult  FileEdit(object id,int actiontype=0)
		{
            ViewData[EditFlag] = true;
             if (actiontype==1)
            {
             FileModel model= new FileModel();
               return View(model);
            }else {
            FileModel model=FileModel.SingleOrDefault(id);
            return View(model);
            }
			
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult  FileEdit(FileModel model)
		{
            if (string.IsNullOrEmpty(model.ID))
                {
                     ViewData[EditFlag] = true;
                    
                    if (model.Insert()!=null)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(FileModel));
                        return JsonSuccess("");
                    }
                       return JsonError("");
            }
            else{
                ViewData[EditFlag] = true;
                if (model.Update()>0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(FileModel));
                    return JsonSuccess("");
                }
               return JsonError("");
            }
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult FileDetails(object id)
        {
            ViewData[EditFlag] = true;
            var item = FileModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            FileModel.Delete(" where ID in ('@0')",id);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(FileModel));
            
            return JsonSuccess(DeleteSuccess);
        }
        
            public ActionResult DeleteForWhere(string Where)
        {
          
            FileModel.Delete(Where);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(FileModel));

            return JsonSuccess(DeleteSuccess);
        }
        
        #endregion
	}
}

