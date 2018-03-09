
//*****************************************************************
//
// File Name:   ConfigController.cs
//
// Description:  Config:系统配置表
//
// Coder:       CodeSmith Generate
//
// Date:        2017-01-03 
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
using System.IO;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class ConfigController: BaseController
    {
        public ActionResult  ConfigIndex(Page<ConfigModel> model)
        {
            try
            {
                if (model.CurrentPage <= 0)
                {
                    model.CurrentPage = 1;
                }
                StringBuilder where = new StringBuilder("where 1=1 ");
                if (model.Item != null)
                {
                    if (model.Item.ID != null)
                    {
                        where.AppendFormat(" and ID = {0} ", model.Item.ID);
                    }
                    if (!string.IsNullOrEmpty(model.Item.ConfigKey))
                    {
                        where.AppendFormat(" and ConfigKey like '%{0}%' ", model.Item.ConfigKey.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.ConfigData))
                    {
                        where.AppendFormat(" and ConfigData like '%{0}%' ", model.Item.ConfigData.Trim());
                    }
                    if (!string.IsNullOrEmpty(model.Item.ConfigType))
                    {
                        where.AppendFormat(" and ConfigType like '%{0}%' ", model.Item.ConfigType.Trim());
                    }
                    if (model.Item.DelFlag != null)
                    {
                        where.AppendFormat(" and DelFlag = {0} ", model.Item.DelFlag);
                    }
                }
                where.Append(" order by CreateTime desc, ConfigKey asc");
                var page = ConfigModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
                page.Item = model.Item;
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(ConfigModel));
                return View(page);
            }
            catch (System.Exception e)
            {
                //===============================================================================
                FileStream fss = new FileStream("E:\\Web\\CRM\\gb.txt", FileMode.Create);                  //
                                                                                                           //获得字节数组                                                                  //
                byte[] datas = System.Text.Encoding.Default.GetBytes(e.Message);
                //开始写入
                fss.Write(datas, 0, datas.Length);
                //清空缓冲区、关闭流
                fss.Flush();
                fss.Close();
                //    //================================================================================ 
                throw;
            }
            
        }
        
       
        
        #region 编辑
        
        [HttpGet]
        public ActionResult  ConfigEdit(object id,int actiontype=0)
		{
            ViewData[EditFlag] = true;
             if (actiontype==1)
            {
             ConfigModel model= new ConfigModel();
               return View(model);
            }else {
            ConfigModel model=ConfigModel.SingleOrDefault(id);
            return View(model);
            }
			
		}
        
        [HttpPost]
        [ValidateInput(false)]
		public ActionResult  ConfigEdit(ConfigModel model)
		{
            if (string.IsNullOrEmpty(model.ID))
                {
                     ViewData[EditFlag] = true;
                    
                    if (model.Insert()!=null)
                    {
                        LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ConfigModel));
                        return JsonSuccess("");
                    }
                       return JsonError("");
            }
            else{
                ViewData[EditFlag] = true;
                if (model.Update()>0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ConfigModel));
                    return JsonSuccess("");
                }
               return JsonError("");
            }
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult ConfigDetails(object id)
        {
            ViewData[EditFlag] = true;
            var item = ConfigModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(string id)
        {
            ConfigModel.Delete(" where ID in ('@0')",id);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ConfigModel));
            
            return JsonSuccess(DeleteSuccess);
        }
        
            public ActionResult DeleteForWhere(string Where)
        {
          
            ConfigModel.Delete(Where);
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID,typeof(ConfigModel));

            return JsonSuccess(DeleteSuccess);
        }
        
        #endregion
	}
}

