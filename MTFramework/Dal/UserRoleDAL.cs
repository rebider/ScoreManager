
//*****************************************************************
//
// File Name:   UserRoleDal.cs
//
// Description:  UserRoleDal
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
    public class UserRoleDAL : BaseDAL<UserRoleModel>
    {

        public static List<UserRoleModel> GetAllRoleByUserID(string userID)
        {
            try
            {
                List<UserRoleModel> userRoleList = new List<UserRoleModel>();
                userRoleList = UserRoleModel.Fetch("where User_ID= @0", userID);
                return userRoleList;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }


        
    }
}
