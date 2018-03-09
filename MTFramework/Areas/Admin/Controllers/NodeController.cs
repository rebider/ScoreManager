
//*****************************************************************
//
// File Name:   NodeController.cs
//
// Description:  Node:节点
//
// Coder:       Liujianglin
//
// Date:        2013-06-26 
//
//*****************************************************************

using System.Web.Mvc;
using PetaPoco;
using MT.Dal;
using MT.Models;
using System.Collections.Generic;
using System;
using MT.Common;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class NodeController: BaseController
    {
        public ActionResult Index()
        {
           
            ViewData[EditFlag] = true;
            ViewData[NoEmptyFlag] = true;
            NodeModel model = new NodeModel();
            List<SelectListItem> selectListItems =
                GroupModel.repo.Fetch<SelectListItem>("select Id as Value, Title as Text from [Group] ");
            ViewBag.groupList = selectListItems;
            ViewBag.areaList = GroupModel.repo.Fetch<SelectListItem>("select Id as Value,Title as Text from Node where NodeLevel = 1 and Pid = 0 ");
       
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
		public ActionResult Add(NodeModel model)
		{
            model.Pid = model.ID;

            if(ModelState.IsValid)
            {
                if (model.Insert()!=null)
                {
                    if (model.NodeLevel == 1)
                    {
                        model.Area = model.ID;
                        model.Update();
                    }
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Node");
                    return JsonSuccess(SaveSuccess, "/Admin/Node/Index" );
                }
            }

            return Error(SaveError);
		}
        
        #endregion
        
        #region 编辑
        
        [HttpGet]
        public ActionResult Edit(string id)
		{
			NodeModel model=NodeModel.SingleOrDefault(id);
			return View(model);
		}
        
        [HttpPost]
		public ActionResult Edit(NodeModel model)
		{
            if (ModelState.IsValid)
            {
                if (model.Update() > 0)
                {
                    if (model.NodeLevel == 2)
                    {
                        List<NodeModel> nodeList = NodeModel.Fetch("where pid = @0", model.ID);
                        foreach (var nodeModel in nodeList)
                        {
                            nodeModel.GroupID = model.GroupID;
                            nodeModel.Area = model.Area;
                            nodeModel.Update();
                        }
                    }
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Node");
                    return JsonSuccess(SaveSuccess, "/Admin/Node/Index");
                }
            }
            return Error();
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult Details(string id)
        {
            var item = NodeModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
        #region 删除
        
        public ActionResult Delete(NodeModel model)
        {
            if (NodeDAL.DeleteSubNodes(model))
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Node");
                return JsonSuccess(DeleteSuccess, "/Admin/Node/Index" );
            }
            
            return Error(DeleteError);
        }
        
        #endregion

        /// <summary>
        /// 获得所有的节点
        /// </summary>
        /// <returns></returns>
        public ActionResult TreeNode()
        {
            List<NodeModel> nodeList = NodeModel.Fetch(" order by SortNo asc");

            return Json(nodeList, JsonRequestBehavior.AllowGet);
        }
	}
}

