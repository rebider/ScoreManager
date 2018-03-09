
//*****************************************************************
//
// File Name:   GlobalSqlDal.cs
//
// Description:  GlobalSqlDal
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-26 
//
//*****************************************************************

using MT.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MT.Dal
{
    public class GlobalSqlDAL : BaseDAL<GlobalSqlModel>
    {
        /// <summary>
        /// 根据key找到tb_sql表中的语句并执行
        /// </summary>
        /// <param name="sqlKey"></param>
        /// <returns></returns>
        public List<SelectListItem> QueryDropDownListByKey(string sqlKey)
        {

            string sqlFormat = GetSqlByKey(sqlKey);

            //GlobalSqlModel model = GlobalSqlModel.SingleBySql(sqlFormat);

            return GlobalSqlModel.repo.Fetch<SelectListItem>(sqlFormat);
        }

        /// <summary>
        /// 根据key找到tb_sql表中的语句并执行
        /// </summary>
        /// <param name="sqlKey"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetDropDownListByKey(string sqlKey)
        {

            string sqlFormat = GetSqlByKey(sqlKey);

            //GlobalSqlModel model = GlobalSqlModel.SingleBySql(sqlFormat);

            return GlobalSqlModel.repo.Fetch<SelectListItem>(sqlFormat);
        }

        /// <summary>
        /// 根据键值读取对应语句
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSqlByKey(string key)
        {
            GlobalSqlModel model = GlobalSqlModel.SingleOrDefaultBySql(" where SQLKey=@0", key);
            string sql = string.Empty;
            if (null != model)
            {
                sql = model.SQLContent;
            }
            return sql;
        }
    }
}
