
//*****************************************************************
//
// File Name:   UserDal.cs
//
// Description:  UserDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using System.Collections.Generic;
using MT.Models;
using MT.Common;
using System;
using System.Text;
using cn.jpush.api.util;
using MT.Areas.Admin.ViewModels;
using MT.Models.ViewModels;
using MT.Common.Helper;

namespace MT.Dal
{
    public class UserDAL : BaseDAL<UserModel>
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Login(ref UserModel model)
        {
            model = UserModel.FirstOrDefault("where Name=@0 and Password=@1 and DelFlag=0", model.Name, PwdThreeEncrypt.PasswordThreeMd5Encrypt(model.Password));
            LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "User");
            return model != null;
        }

        public static UserAuthModel TokenLogin(string token)
        {
            UserAuthModel model = new UserAuthModel();

            if (token != MTConfig.AdminToken)
            {
                return model;
            }

            model.User = UserModel.FirstOrDefault("where Id = 1 and DelFlag = 0 ");
            if (model.User != null)
            {
                model.RoleList = RoleDAL.GetAllRoleByUserID(model.User.ID);
                model.GroupList = GroupDAL.GetAllGroup();
                model.NodeList = NodeDAL.GetAccessNodeList(model.User.ID);
                int groupCount = model.GroupList.Count;
                for (int i = groupCount - 1; i >= 0; i--)
                {
                    if (!model.NodeList.Exists(m => m.GroupID.ToString() == model.GroupList[i].ID && m.NodeLevel != 1))
                    {
                        model.GroupList.RemoveAt(i);
                    }
                }
            }
            return model;
        }

        public static UserAuthModel GetAuth(int id)
        {
            UserAuthModel model = new UserAuthModel();
            model.User = UserModel.FirstOrDefault("where Id = @0 and DelFlag = 0 ", id);
            if (model.User != null)
            {
                model.RoleList = RoleDAL.GetAllRoleByUserID(model.User.ID);
                model.GroupList = GroupDAL.GetAllGroup();
                model.NodeList = NodeDAL.GetAccessNodeList(model.User.ID);
                int groupCount = model.GroupList.Count;
                for (int i = groupCount - 1; i >= 0; i--)
                {
                    if (!model.NodeList.Exists(m => m.GroupID.ToString() == model.GroupList[i].ID && m.NodeLevel != 1))
                    {
                        model.GroupList.RemoveAt(i);
                    }
                }
            }
            return model;
        }

        public static UserModel Login(string name, string password)
        {
           // password = Md5.getMD5Hash(password);
            UserModel user = UserModel.FirstOrDefault("where Name = @0 and Password = @1 and DelFlag = 0 ", name, password);
            if (user != null)
            {
                UserModel.repo.Execute("update [User] set LastLoginTime = @0 where Name = @1 and Password = @2 and DelFlag = 0", DateTime.Now, name, password);
            }
            return user;
        }

        public static UserInfoModel WebLogin(string name, string password)
        {
            password = PwdThreeEncrypt.PasswordThreeMd5Encrypt(password);
            //UserInfoModel user = UserInfoModel.FirstOrDefault("where Email = @0 and Password = @1  ", name, password);
            UserInfoModel user = UserInfoModel.FirstOrDefault("where LoginName = @0 and Password = @1 ", name, password);
            return user;
        }

        public static UserInfoModel WebLoginAgent(string name, string password)
        {
            password = PwdThreeEncrypt.PasswordThreeMd5Encrypt(password);
            //UserInfoModel user = UserInfoModel.FirstOrDefault("where Email = @0 and Password = @1  ", name, password);
            UserInfoModel user = UserInfoModel.FirstOrDefault("where LoginName = @0 and Password = @1  and AgentLevelID > 0 ", name, password);
            return user;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserModel GetUser(int id)
        {
            UserModel user = UserModel.FirstOrDefault("where Id = @0 and DelFlag = 0 ", id);
            return user;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UserInfoModel GetUserInfo(int id)
        {
            UserInfoModel user = UserInfoModel.FirstOrDefault("where UserID = @0  ", id);
            return user;
        }
        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(UserModel model, string[] roleIds)
        {
            UserModel.repo.BeginTransaction();
            StringBuilder sqlLog = new StringBuilder();
            try
            {
                if (string.IsNullOrEmpty(model.CreateMan+""))
                {
                    model.CreateMan = MTConfig.CurrentUserID.ToInt();
                }
                model.Password = PwdThreeEncrypt.PasswordThreeMd5Encrypt(model.Password);
                string newUserID = UserModel.repo.Insert(model).ToString();
                sqlLog.Append(UserModel.repo.LastCommand + "\n");

                if (roleIds != null)
                {
                    foreach (string roleId in roleIds)
                    {
                        RoleModel roles = new RoleModel();
                        roles = RoleModel.FirstOrDefault("where id = " + roleId);
                        UserProductModel userProduct = new UserProductModel();
                        userProduct.ProductId = roles.ProductId;
                        userProduct.UserId = newUserID.ToInt();
                        userProduct.Insert();
                        int i = 0;
                        if (int.TryParse(roleId, out i))
                        {
                            UserRoleModel userRole = new UserRoleModel();
                            userRole.UserID = newUserID.ToInt();
                            userRole.RoleID = roleId.ToInt();
                            userRole.CreateMan = !string.IsNullOrEmpty(model.CreateMan+"") ? model.CreateMan : MTConfig.CurrentUserID.ToInt();
                            userRole.Insert();
                            sqlLog.Append(UserModel.repo.LastCommand + "\n");
                        }
                    }
                }

                UserModel.repo.CompleteTransaction();
                LogDAL.AppendSQLLog(string.IsNullOrEmpty(model.CreateMan+"") ? MTConfig.CurrentUserID : model.CreateMan+"",
                                    "User", sqlLog.ToString());
            }
            catch (Exception)
            {
                UserModel.repo.AbortTransaction();
                sqlLog = null;
                return false;
            }

            return true;
        }


        /// <summary>
        /// 用户编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Edit(UserModel model, string[] roleIds)
        {
            UserModel.repo.BeginTransaction();
            StringBuilder sqlLog = new StringBuilder();
            try
            {
                model.CreateMan = MTConfig.CurrentUserID.ToInt();
                UserModel.repo.Save(model);
                sqlLog.Append(UserModel.repo.LastCommand);
                UserRoleModel.Delete("where UserID = @0", model.ID);
                sqlLog.Append(UserModel.repo.LastCommand + "\n");

                if (roleIds != null)
                {
                    foreach (string roleId in roleIds)
                    {

                        UserProductModel.Delete(" where UserID = @0", model.ID);
                        RoleModel roles = new RoleModel();
                        roles = RoleModel.FirstOrDefault("where id = " + roleId);
                        UserProductModel userProduct = new UserProductModel();
                        userProduct.ProductId = roles.ProductId;
                        userProduct.UserId = model.ID.ToInt();
                        userProduct.Insert();
                        int i = 0;
                        if (int.TryParse(roleId, out i))
                        {
                            UserRoleModel userRole = new UserRoleModel();
                            userRole.UserID = model.ID.ToInt();
                            userRole.RoleID = roleId.ToInt();
                            userRole.CreateMan = MTConfig.CurrentUserID.ToInt();
                            userRole.Insert();
                            sqlLog.Append(UserModel.repo.LastCommand + "\n");
                        }
                    }
                }

                UserModel.repo.CompleteTransaction();
                LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "User", sqlLog.ToString());
            }
            catch (Exception)
            {
                UserModel.repo.AbortTransaction();
                sqlLog = null;
                return false;
            }

            return true;
        }

        public static bool DeleteFlag(string id)
        {
            bool result = false;
            try
            {
                int rs = UserModel.Update("set DelFlag = 1 where ID=@0", id);
                if (rs == 1)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "SysUser");
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public static bool StartFlag(string id)
        {
            bool result = false;
            try
            {
                int rs = UserModel.Update("set DelFlag = 0 where ID=@0", id);
                if (rs == 1)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "SysUser");
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdatePassword(UserViewModel model)
        {
            bool result = false;
            try
            {
                model.ModifyPassword = PwdThreeEncrypt.PasswordThreeMd5Encrypt(model.ModifyPassword);
                int rs = UserModel.Update("set password = @0 where id = @1", model.ModifyPassword, model.Id);
                if (rs == 1)
                {
                    LogDAL.AppendSQLLog(MTConfig.CurrentUserID, "SysUser");
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

    }
}
