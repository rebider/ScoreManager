
//*****************************************************************
//
// File Name:   AccessDal.cs
//
// Description:  AccessDal
//
// Coder:        Liujianglin
//
// Date:        2013-06-26 
//
//*****************************************************************

using MT.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MT.Dal
{
    public class AccessDAL:BaseDAL<AccessModel>
    {
        public bool Add(string[] nodeIds, string roleId, ref List<string> sqlParams)
        {
            try
            {

                List<NodeModel> nodeList = NodeModel.Fetch("select Id from Node ");

                AccessModel.repo.BeginTransaction();

                AccessModel.Delete(string.Format(" where RoleID = {0} and NodeId in ({1}) ", roleId, string.Join(",", nodeList.Select(s=>s.ID))));

                sqlParams = new List<string>();

                sqlParams.Add(string.Format(" where RoleID = {0} and NodeId in ({1}) ", roleId, string.Join(",", nodeList.Select(s => s.ID))));

                foreach (string nodeId in nodeIds)
                {
                    if(nodeId == "")
                    {
                        break;
                    }

                    sqlParams.Add(string.Format("insert into Access(RoleID,NodeID) values ({0},{1})", roleId, nodeId));

                    AccessModel addAccess = new AccessModel();
                    addAccess.NodeID = Convert.ToInt32( nodeId);
                    addAccess.RoleID = Convert.ToInt32(roleId);

                    addAccess.Insert();

                }

                AccessModel.repo.CompleteTransaction();
            }
            catch (Exception)
            {
                AccessModel.repo.Dispose();
                return false;
            }

            return true;
        }

	}
    
}
