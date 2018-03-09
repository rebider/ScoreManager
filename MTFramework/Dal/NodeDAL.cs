
//*****************************************************************
//
// File Name:   NodeDal.cs
//
// Description:  NodeDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using System.Collections.Generic;
using MT.Models;
using System.Linq;
using System;
using MT.Common;

namespace MT.Dal
{
    public class NodeDAL : BaseDAL<NodeModel>
    {

        public static List<NodeModel> GetAccessNodeList(string userid)
        {
            string sql = @"select distinct a.*, c.Name as NodeGroupName, c.Title as NodeGroupTitle from Node a
inner join Access b on a.ID = b.NodeID
inner join [Group] c on c.ID = a.GroupID
inner join UserRole d on b.RoleID = d.RoleID
where d.UserID = @userid   order by  a.SortNo asc "; //GlobalSqlDAL.GetSqlByKey("NodeDAL_GetAccessNodeList");
            List<NodeModel> list = NodeModel.Fetch(sql, new { userid });
            return list;
        }

        public static List<NodeModel> GetAccessByRole(int? roleId)
        {
            List<NodeModel> nodeList = NodeModel.Fetch("where Title like  '%后台%' and Pid = '0'  order by Id asc ");
            List<NodeModel> allList = new List<NodeModel>();
            
            foreach (var rootNode in nodeList)
            {
                List<NodeModel> list = new List<NodeModel>();
                string strSql = string.Format(@"select distinct Node.id as Id,
                                    Node.Pid as Pid,
                                    Node.Name as Name,
                                    Node.Title as Title,
                                    Node.SortNo as SortNO,
                                    Node.NodeLevel as NodeLevel,
                                    Node.GroupId as GroupID,
                                    case(select count(*) from Access where Access.roleid = {0} and Node.id = Access.nodeid) 
								                    when 0 then 'false' else 'true' end as 'IsChecked'
                      from Node
                      left join Access
                        on Node.id = Access.nodeid
                      where Node.Area = {1} 
                      order by Node.SortNo asc", roleId, rootNode.ID);
                list = NodeModel.Fetch(strSql);

                List<GroupModel> groupList = GroupModel.Fetch("where DelFlag = 0  order by SortNo asc");
                foreach (var node in list)
                {
                    if (node.Pid.ToInt() == rootNode.ID.ToInt())
                    {
                        var group = groupList.FirstOrDefault(s => s.ID.ToInt() == node.GroupID);
                        if (group == null)
                        {
                            continue;
                        }
                        group.HasUsed = true;
                        node.Pid = "g_" + group.ID;
                    }
                }
                foreach (var groupModel in groupList)
                {
                    if (!groupModel.HasUsed)
                    {
                        continue;
                    }
                    NodeModel node = new NodeModel();
                    node.ID = "g_" + groupModel.ID;
                    node.Name = groupModel.Name;
                    node.Title = groupModel.Title;
                    node.Pid = rootNode.ID;
                    node.nocheck = "false";
                    list.Add(node);
                }

                allList.AddRange(list);
            }

            return allList;
        }

        /// <summary>
        /// 删除当前节点以及下级节点
        /// </summary>
        /// <param name="nodeModel"></param>
        /// <returns></returns>
        public static bool DeleteSubNodes(NodeModel nodeModel)
        {
            NodeModel.repo.BeginTransaction();
            try
            {
                List<string> idList = new List<string>();
                idList.Add(nodeModel.ID);
                if (nodeModel.NodeLevel == 2)
                {
                    List<NodeModel> nodeList = NodeModel.Fetch("where Pid = @0", nodeModel.ID);
                    idList.AddRange(nodeList.Select(s => s.ID));
                }
                if (nodeModel.NodeLevel == 1)
                {
                    List<NodeModel> level2List = NodeModel.Fetch("where Pid = @0", nodeModel.ID);
                    List<NodeModel> level3List = NodeModel.Fetch(
                        string.Format("where Pid in ('{0}')", string.Join("','", level2List.Select(s => s.ID))));
                    idList.AddRange(level2List.Select(s => s.ID));
                    idList.AddRange(level3List.Select(s => s.ID));
                }
                if (idList.Count == 0)
                {
                    idList.Add("0");
                }

                NodeModel.Delete(string.Format("where Id in ('{0}')", string.Join("','", idList)));
                NodeModel.repo.CompleteTransaction();
                return true;
            }
            catch (Exception)
            {
                NodeModel.repo.AbortTransaction();
                return false;
            }
        }

        /// <summary>
        /// 根据区域获取该区域下所有节点 by姜正午
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public static List<NodeModel> GetNodeByArea(string area = "Home")
        {
            var tempRoot = NodeModel.FirstOrDefault("where Pid = '0' and Name = @0", area);
            var nodeList = NodeModel.Fetch("where Area = @0", tempRoot.ID);
            var root = nodeList.FirstOrDefault(s => s.Pid == "0");
            nodeList.Remove(root);
            return nodeList;
        }
    }
}
