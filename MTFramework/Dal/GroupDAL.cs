
//*****************************************************************
//
// File Name:   GroupDal.cs
//
// Description:  GroupDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using MT.Models;
using System.Collections.Generic;

namespace MT.Dal
{
    public class GroupDAL : BaseDAL<GroupModel>
    {
        /// <summary>
        /// 读取所有节点分组
        /// </summary>
        /// <returns></returns>
        public static List<GroupModel> GetAllGroup()
        {
            string sql = "select * from [Group] where DelFlag=0   order by SortNo ";
            List<GroupModel> list = GroupModel.Fetch(sql);
            return list;
        }

    }
}
