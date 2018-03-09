
//*****************************************************************
//
// File Name:   DemoController.cs
//
// Description:  Demo:
//
// Coder:       CodeSmith Generate
//
// Date:        2016-12-26 
//
//*****************************************************************

using System;
using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System.Collections.Generic;
using MT.Areas.Admin.Controllers;
using MT.Common;
using System.Text;
using System.Web;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class DemoController : BaseController
    {
        public ActionResult DemoIndex(Page<DemoModel> model)
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
                if (model.Item.DemoRedioButton != null)
                {
                    where.AppendFormat(" and DemoRedioButton = {0} ", model.Item.DemoRedioButton.Value);
                }
                if (!string.IsNullOrEmpty(model.Item.DemoCheckBox))
                {
                    where.AppendFormat(" and DemoCheckBox like '%{0}%' ", model.Item.DemoCheckBox.Trim());
                }
                if (model.Item.DemoSelected != null)
                {
                    where.AppendFormat(" and DemoSelected = {0} ", model.Item.DemoSelected.Value);
                }
                if (!string.IsNullOrEmpty(model.Item.DemoTextArea))
                {
                    where.AppendFormat(" and DemoTextArea like '%{0}%' ", model.Item.DemoTextArea.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.DemoText))
                {
                    where.AppendFormat(" and DemoText like '%{0}%' ", model.Item.DemoText.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.Phone))
                {
                    where.AppendFormat(" and Phone like '%{0}%' ", model.Item.Phone.Trim());
                }
                if (!string.IsNullOrEmpty(model.Item.IDCard))
                {
                    where.AppendFormat(" and IDCard like '%{0}%' ", model.Item.IDCard.Trim());
                }
                if (model.Item.DelFlag != null)
                {
                    where.AppendFormat(" and DelFlag = {0} ", model.Item.DelFlag.Value);
                }
            }
            var page = DemoModel.Page(model.CurrentPage, MTConfig.ItemsPerPage, where.ToString(), model.Item);
            page.Item = model.Item;
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(DemoModel));
            return View(page);
        }

        #region 添加

        [HttpGet]
        public ActionResult DemoAdd()
        {
            ViewData[EditFlag] = true;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DemoAdd(DemoModel model)
        {
            ViewData[EditFlag] = true;
            if (model.Insert() != null)
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(DemoModel));
                return JsonSuccessJump();
            }
            return JsonErrorJump();
        }

        #endregion

        #region 编辑

        [HttpGet]
        public ActionResult DemoEdit(object id, int actiontype = 0)
        {
            ViewData[EditFlag] = true;
            if (actiontype == 1)
            {
                return View();
            }
            else
            {
                DemoModel model = DemoModel.SingleOrDefault(id);
                return View(model);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult DemoEdit(DemoModel model)
        {
            if (string.IsNullOrEmpty(model.ID))
            {
                ViewData[EditFlag] = true;

                if (model.Insert() != null)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(DemoModel));
                    return JsonSuccess("");
                }
                return JsonError("");
            }
            else
            {
                ViewData[EditFlag] = true;
                if (model.Update() > 0)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(DemoModel));
                    return JsonSuccess("");
                }
                return JsonError("");
            }
        }

        #endregion


   
        #region 详情

        public ActionResult Details(object id)
        {
            ViewData[EditFlag] = true;
            var item = DemoModel.SingleOrDefault(id);
            return View(item);
        }

        #endregion

        #region 删除

        public ActionResult Delete(string id)
        {
            string[] tmp = id.Split(',');
            foreach (string item in tmp)
            {
                DemoModel.Update("set DelFlag = 1 where ID=@0", item);
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, typeof(DemoModel));
            }

            return JsonSuccess(DeleteSuccess);
        }

        #endregion
    }
}

