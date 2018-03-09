using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.Models;

namespace MT.Dal
{
    public class AreaDAL:BaseDAL<AreaModel>
    {
        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public  ActionResult  GetProvince(string pcode)
        {
            List<AreaModel> area = AreaModel.Fetch(" where ParentCode = 000000");
            JsonResult json = new JsonResult();
            json.Data = area;
            return json;
        }
        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public  string GetCaty(string pcode)
        {

            return "";
        }
        /// <summary>
        /// 获取省
        /// </summary>
        /// <returns></returns>
        public  string GetArea(string pcode)
        {

            return "";
        }
    }
}