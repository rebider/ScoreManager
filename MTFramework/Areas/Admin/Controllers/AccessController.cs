
//*****************************************************************
//
// File Name:   AccessController.cs
//
// Description:  Access:权限表
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
using MT.Common;

namespace MT.Areas.Admin.Controllers
{
    [UserAuthorize]
    public partial class AccessController: BaseController
    {
        AccessDAL accessDal = new AccessDAL();

        public ActionResult Index(int? roleId)
        {
            string url = Request.Url.AbsoluteUri;
            List<RoleModel> roleList = RoleModel.Fetch("select Id , Name  from Role where DelFlag = 0 order by SortNo asc");
            roleList.Insert(0, new RoleModel()
                {
                ID = "",Name = "请选择"
                });
            ViewBag.roleList = roleList;
            AccessModel model = new AccessModel();
            model.ID = roleId.ToString() ?? "";
            ViewData[EditFlag] = true;
            return View(model);

        }

        /// <summary>
        /// 获得所有节点
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult TreeNode( int? roleId)
        {
            List<NodeModel> accessList = NodeDAL.GetAccessByRole(roleId);
            return Json(accessList, JsonRequestBehavior.AllowGet);
        }
        
        #region 添加
        
        [HttpGet]
        public ActionResult Add()
		{
			ViewData[EditFlag] = true;
			return View();
		}
        
        [HttpPost]
        public ActionResult Add(string nodeIds, string roleId)
		{
            List<string> sqlParams = new List<string>();

            if (accessDal.Add(Request["nodeIds"].Split(','), roleId, ref sqlParams))
            {
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "Access",sqlParams.ToArray());

                return JsonSuccess(SaveSuccess,"" );
            }

            return Error(SaveError);
		}
        
        #endregion
        
        #region 编辑
        
        [HttpGet]
        public ActionResult Edit(string id)
		{
			AccessModel model=AccessModel.SingleOrDefault(id);
			return View(model);
		}
        
        [HttpPost]
		public ActionResult Edit(AccessModel model)
		{
            if(ModelState.IsValid)
            {
                if (model.Update()>0)
                {
                    return Success();
                }
            }

			TempData[Info] = SaveError;
            return Error();
		}
        
        #endregion
        
        #region 详情
        
        public ActionResult Details(string id)
        {
            var item = AccessModel.SingleOrDefault(id);
            return View(item);
        }
        
        #endregion
        
	}
}

