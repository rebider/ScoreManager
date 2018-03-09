
//*****************************************************************
//
// File Name:   RoleDal.cs
//
// Description:  RoleDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using MT.Models;
using System.Collections.Generic;
using System.Text;
using MT.Common;
using System.Linq;

namespace MT.Dal
{
    public class RoleDAL:BaseDAL<RoleModel>
    {

        UserRoleDAL userRoleDAL = new UserRoleDAL();

        /// <summary>
        /// 获取全部有效角色信息
        /// </summary>
        /// <returns></returns>
        public static List<RoleModel> GetAllRole()
        {
            try
            {
                List<RoleModel> result = new List<RoleModel>();
                StringBuilder where = new StringBuilder("where DelFlag = 0 ");
                if (MTConfig.CurrentRole.FirstOrDefault(s => s.Name.Contains("管理员")) != null)
                {
                    where.Append("");
                }
                else if(MTConfig.CurrentRole.FirstOrDefault(s=>s.Name.Contains("总经理")) != null)
                {
                    where.Append("");
                }
                else if (MTConfig.CurrentRole.FirstOrDefault(s => s.Name.Contains("培训部主管")) != null)
                {
                    where.Append(" and Name like '%培训部%' ");
                }
                else if (MTConfig.CurrentRole.FirstOrDefault(s => s.Name.Contains("中介部主管")) != null)
                {
                    where.Append(" and Name like '%中介部%' ");
                }
                else if (MTConfig.CurrentRole.FirstOrDefault(s => s.Name.Contains("培训部员工")) != null)
                {
                    where.Append(" and Name = '培训部员工' ");
                }
                else if (MTConfig.CurrentRole.FirstOrDefault(s => s.Name.Contains("中介部员工")) != null)
                {
                    where.Append(" and Name = '中介部员工' ");
                }
                result = RoleModel.Fetch(where.ToString());
                return result;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public static List<RoleModel> GetAllRoleByUserID(string userId)
        {
            try
            {
                return RoleModel.Fetch(@"select r.* from Role r
inner join UserRole ur on r.ID = ur.RoleID
where ur.UserID = @0 ", userId);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        

	}
}
