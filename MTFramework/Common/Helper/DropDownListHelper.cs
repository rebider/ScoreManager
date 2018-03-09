using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using MT.Dal;
using MT.Models;

namespace MT.Common.Helper
{
    public static class DropDownListHelper
    {
        /// <summary>
        /// 生成select下拉控件
        /// </summary>
        /// <param name="viewdatakey">执行的sqlkey(在sql语句中添加的key)</param>
        /// <param name="classstr">样式</param>
        /// <param name="customtype">自定义样式,如( name="name" id="id" )</param>
        /// <param name="lists">需要绑定的列表 </param>
        /// <param name="optiontitle">添加默认选项 </param>
        /// <param name="selectindex">默认选中的value</param>
        /// <returns></returns>
        public static string GetDropDownList(string viewdatakey, string classstr, string customtype = "", string optiontitle = "", string selectindex = "", List<SelectListItem> lists = null)
        {
            if (!string.IsNullOrEmpty(viewdatakey))
            {
                var bll = new GlobalSqlDAL();
                List<SelectListItem> list = bll.QueryDropDownListByKey(viewdatakey);
                lists = list;
            }
            StringBuilder selehtml = new StringBuilder();
            selehtml.AppendFormat(@"<select class='{0}' {1}>", classstr, customtype);
            if (!string.IsNullOrEmpty(optiontitle))
            {
                selehtml.AppendFormat(@"<option value = '' >{0}</option>", optiontitle);

            }
            foreach (var item in lists)
            {
                if (!string.IsNullOrEmpty(selectindex))
                {
                    if (item.Value == selectindex)
                    {
                        selehtml.AppendFormat(@"<option value = '{0}' selected='selected' >{1}</option>", item.Value, item.Text);
                    }
                    else
                    {
                        selehtml.AppendFormat(@"<option value = '{0}'  >{1}</option>", item.Value, item.Text);
                    }
                }
                else
                {
                    selehtml.AppendFormat(@"<option value = '{0}'  >{1}</option>", item.Value, item.Text);
                }
            }
            if (!string.IsNullOrEmpty(optiontitle))
            {
                selehtml.AppendFormat(@"<option value = '' >{0}</option>", optiontitle);

            }

            selehtml.Append("</select>");
            return selehtml.ToString();
        }


        /// <summary>
        /// 生成select下拉控件
        /// </summary>
        /// <param name="viewdatakey">执行的sqlkey(在sql语句中添加的key)</param>
        /// <param name="classstr">样式</param>
        /// <param name="customtype">自定义样式,如( name="name" id="id" )</param>
        /// <param name="lists">需要绑定的列表 </param>
        /// <param name="optiontitle">添加默认选项 </param>
        /// <param name="selectindex">默认选中的value</param>
        /// <returns></returns>
        public static string GetDropDownListParmater(string viewdatakey,string classstr, string customtype = "", string optiontitle = "", string selectindex = "", List<SelectListItem> lists = null)
        {
            if (!string.IsNullOrEmpty(viewdatakey))
            {
                var bll = new GlobalSqlDAL();
                List<SelectListItem> list = bll.QueryDropDownListByKey(viewdatakey);
                lists = list;
            }
            StringBuilder selehtml = new StringBuilder();
            selehtml.AppendFormat(@"<select class='{0}' {1}>", classstr, customtype);
            if (!string.IsNullOrEmpty(optiontitle))
            {
                selehtml.AppendFormat(@"<option value = '' >{0}</option>", optiontitle);

            }
            foreach (var item in lists)
            {
                if (!string.IsNullOrEmpty(selectindex))
                {
                    if (item.Value == selectindex)
                    {
                        selehtml.AppendFormat(@"<option value = '{0}' selected='selected' >{1}</option>", item.Value, item.Text);
                    }
                    else
                    {
                        selehtml.AppendFormat(@"<option value = '{0}'  >{1}</option>", item.Value, item.Text);
                    }
                }
                else
                {
                    selehtml.AppendFormat(@"<option value = '{0}'  >{1}</option>", item.Value, item.Text);
                }
            }
            if (!string.IsNullOrEmpty(optiontitle))
            {
                selehtml.AppendFormat(@"<option value = '' >{0}</option>", optiontitle);

            }

            selehtml.Append("</select>");
            return selehtml.ToString();
        }


    }
}