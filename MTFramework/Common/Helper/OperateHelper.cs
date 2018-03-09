using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MT.Models;

namespace MT.Common
{
    public static class OperateHelper
    {
        /// <summary>
        /// 判断该操作是否拥有权限
        /// </summary>
        /// <param name="html"></param>
        /// <param name="area"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool IsAuth(this HtmlHelper html, string area, string controller, string action)
        {
            //RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            List<NodeModel> level1List = MTConfig.AuthInfo1;
            List<NodeModel> level2List = MTConfig.AuthInfo2;
            List<NodeModel> level3List = MTConfig.AuthInfo3;

            NodeModel level1Node = null, level2Node = null, level3Node = null;
            foreach (NodeModel node1 in level1List)
            {
                if (node1.Name.ToLower() == area.ToLower())
                {
                    level1Node = node1;
                    break;
                }
            }

            if (level1Node == null)
            {
                return false;
            }

            foreach(NodeModel node2 in level2List)
            {
                if(node2.Name.ToLower() == controller.ToLower())
                {
                    level2Node = node2;
                    break;
                }
            }

            if (level2Node == null)
            {
                return false;
            }

            foreach (NodeModel node3 in level3List)
            {
                if (node3.Name.ToLower() == action.ToLower() && node3.Pid == level2Node.ID)
                {
                    level3Node = node3;
                    break;
                }
            }

            if (level3Node == null)
            {
                return false;
            }

            return true;
        }

    }
}