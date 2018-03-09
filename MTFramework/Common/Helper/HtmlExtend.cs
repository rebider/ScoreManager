using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Linq.Expressions;
using MT.Areas.Admin.ViewModels;
using MT.Common;
using MT.Models;
using NSoup.Helper;
using PetaPoco;
using MT.Dal;


namespace System.Web.Mvc
{
    public static class HtmlExtend
    {
        /// <summary>
        /// 前台分页控件 上一页 1 2 3 4 下一页 url不友好 by姜正午   //包含中英文切换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="page"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static HtmlString ViewPage<T>(this HtmlHelper html, Page<T> page, string area = "Home") where T : new()
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
        var queryString = html.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = HttpUtility.HtmlEncode(queryString[key]);

            var formString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in formString.Keys)
                vs[key] = HttpUtility.HtmlEncode(formString[key]);
            vs.Remove("CurrentPage");

            var builder = new StringBuilder();
        var classDict = new Dictionary<string, object>();

        builder.Append("<div> <div class=\"f-fr mart10 marr10\">  <div class=\"m-page m-page-sr m-page-sm\">");

            vs.Add("CurrentPage", "");

            vs["CurrentPage"] = (page.CurrentPage - 1) > 0 ? (page.CurrentPage - 1) : 1;
            //如果当前是第一页 上一页不可用
            if (page.CurrentPage == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"first pageprv z-dis\"><span class=\"pagearr\"><<</span></a>");
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&lt;</span></a>", "first pageprv z-dis");
            }
            else
            {
                //上一页不是第一页 上一页的url参数
                var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                if (string.IsNullOrWhiteSpace(area))
                {
                    builder.AppendFormat("<a href=\"/Admin/{0}?CurrentPage = 1\" class=\"{2}\"><span class=\"pagearr\"><<</span></a>"
                      , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                      , string.Join("&", list)
                      , "first pageprv z-diss");
                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&lt;</span></a>"
                       , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                       , string.Join("&", list)
                       , "first pageprv");
                }
                else
                {
                    builder.AppendFormat("<a href=\"/{0}?CurrentPage = 1\" class=\"{2}\"><span class=\"pagearr\"><<</span></a>"
                      , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                      , string.Join("&", list)
                      , "first pageprv z-diss");

                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&lt;</span></a>"
                       , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                       , string.Join("&", list)
                       , "first pageprv");
                }
            }

            classDict["class"] = "";
            int i = 0;
            //如果本页到第一页的距离小于3 生成1 2 3 4格式的页码
            if (page.CurrentPage - 3 > 1)
            {
                vs["CurrentPage"] = 1;
                builder.AppendFormat(Html.LinkExtensions.ActionLink(html, "1", vs["action"].ToString(), vs, classDict).ToString());
                builder.Append("<i>...</i>");

                for (i = (int)page.CurrentPage - 2; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\"  class=\"z-crt\">{0}</a>", i);
                    }
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }
            //如果本页到第一页的距离大于3 生成1 ... 3 4 5格式的页码
            else
            {
                for (i = 1; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    //如果是当前页面 当前页不可以点中
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\" class=\"z-crt\">{0}</a>", i);
                    }
                    //如果不是当前页面 可以选中
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }

            classDict["class"] = "";
            //如果当前页距离尾页大于3 生成 5 6 7 ... 10的样式
            if (page.CurrentPage + 3 < page.TotalPages)
            {
                for (i = (int)(page.CurrentPage + 1); i<page.CurrentPage + 3; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
                builder.Append("<i>...</i>");
                vs["CurrentPage"] = page.TotalPages;
                builder.Append(
                    Html.LinkExtensions.ActionLink(html, page.TotalPages.ToString(), vs["action"].ToString(), vs, classDict)
                        .ToString());
            }
            //如果当前页到尾页小于3 生成 5 6 7 8的样式
            else
            {
                for (i = (int)(page.CurrentPage + 1); i <= page.TotalPages; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
            }

            vs["CurrentPage"] = (page.CurrentPage + 1) < page.TotalPages? (page.CurrentPage + 1) : page.TotalPages;
            //如果没有数据的情况下 下一页不可用
            if (page.CurrentPage == page.TotalPages || page.TotalPages == 0 || page.TotalPages == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&gt;</span></a>", "last pagenxt z-dis");
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">>></span></a>", "last pagenxt z-dis");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(area))
                {
                    //生成下一页的参数
                    var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&gt;</span></a>"
                        , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                        , string.Join("&", list)
                        , "last pagenxt");
                    builder.AppendFormat("<a href=\"/Admin/{0}?CurrentPage={1}\" class=\"{2}\"><span class=\"pagearr\">>></span></a>"
                     , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                     , page.TotalPages
                     , "last pagenxt");

                }
                else
                {
                    //生成下一页的参数
                    var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&gt;</span></a>"
                        , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                        , string.Join("&", list)
                        , "last pagenxt");
                    builder.AppendFormat("<a href=\"/{0}?CurrentPage={1}\" class=\"{2}\"><span class=\"pagearr\">>></span></a>"
                       , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                       , page.TotalPages
                       , "last pagenxt");

                }
            }

            builder.AppendFormat("</div></div>");
            builder.AppendFormat("<div class=\"f-fr mart20 marr10\">");
            builder.AppendFormat("<span lang='total'></span>:&nbsp;{0}<span lang='record'></span>，<span lang='perpage'></span>：&nbsp;{1}<span lang='record'></span>", page.TotalItems, page.ItemsPerPage);
            builder.Append("</div></div>");
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 分页控件 上一页 1 2 3 4 下一页 url不友好 by姜正午
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="page"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static HtmlString RenderPage<T>(this HtmlHelper html, Page<T> page, string area = "Home") where T : new()
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = HttpUtility.HtmlEncode(queryString[key]);

            var formString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in formString.Keys)
                vs[key] = HttpUtility.HtmlEncode(formString[key]);
            vs.Remove("CurrentPage");

            var builder = new StringBuilder();
            var classDict = new Dictionary<string, object>();

            builder.Append("<div> <div class=\"f-fr mart10 marr10\">  <div class=\"m-page m-page-sr m-page-sm\">");

            vs.Add("CurrentPage", "");

            vs["CurrentPage"] = (page.CurrentPage - 1) > 0 ? (page.CurrentPage - 1) : 1;
            //如果当前是第一页 上一页不可用
            if (page.CurrentPage == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"first pageprv z-dis\"><span class=\"pagearr\"><<</span></a>");
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&lt;</span></a>", "first pageprv z-dis");
            }
            else
            {
                //上一页不是第一页 上一页的url参数
                var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                if (string.IsNullOrWhiteSpace(area))
                {
                    builder.AppendFormat("<a href=\"/Admin/{0}?CurrentPage = 1\" class=\"{2}\"><span class=\"pagearr\"><<</span></a>"
                      , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                      , string.Join("&", list)
                      , "first pageprv z-diss");
                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&lt;</span></a>"
                       , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                       , string.Join("&", list)
                       , "first pageprv");
                }
                else
                {
                    builder.AppendFormat("<a href=\"/{0}?CurrentPage = 1\" class=\"{2}\"><span class=\"pagearr\"><<</span></a>"
                      , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                      , string.Join("&", list)
                      , "first pageprv z-diss");

                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&lt;</span></a>"
                       , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                       , string.Join("&", list)
                       , "first pageprv");
                }
            }

            classDict["class"] = "";
            int i = 0;
            //如果本页到第一页的距离小于3 生成1 2 3 4格式的页码
            if (page.CurrentPage - 3 > 1)
            {
                vs["CurrentPage"] = 1;
                builder.AppendFormat(Html.LinkExtensions.ActionLink(html, "1", vs["action"].ToString(), vs, classDict).ToString());
                builder.Append("<i>...</i>");

                for (i = (int)page.CurrentPage - 2; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\"  class=\"z-crt\">{0}</a>", i);
                    }
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }
            //如果本页到第一页的距离大于3 生成1 ... 3 4 5格式的页码
            else
            {
                for (i = 1; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    //如果是当前页面 当前页不可以点中
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\" class=\"z-crt\">{0}</a>", i);
                    }
                    //如果不是当前页面 可以选中
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }

            classDict["class"] = "";
            //如果当前页距离尾页大于3 生成 5 6 7 ... 10的样式
            if (page.CurrentPage + 3 < page.TotalPages)
            {
                for (i = (int)(page.CurrentPage + 1); i < page.CurrentPage + 3; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
                builder.Append("<i>...</i>");
                vs["CurrentPage"] = page.TotalPages;
                builder.Append(
                    Html.LinkExtensions.ActionLink(html, page.TotalPages.ToString(), vs["action"].ToString(), vs, classDict)
                        .ToString());
            }
            //如果当前页到尾页小于3 生成 5 6 7 8的样式
            else
            {
                for (i = (int)(page.CurrentPage + 1); i <= page.TotalPages; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
            }

            vs["CurrentPage"] = (page.CurrentPage + 1) < page.TotalPages ? (page.CurrentPage + 1) : page.TotalPages;
            //如果没有数据的情况下 下一页不可用
            if (page.CurrentPage == page.TotalPages || page.TotalPages == 0 || page.TotalPages == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&gt;</span></a>", "last pagenxt z-dis");
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">>></span></a>", "last pagenxt z-dis");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(area))
                {
                    //生成下一页的参数
                    var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&gt;</span></a>"
                        , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                        , string.Join("&", list)
                        , "last pagenxt");
                    builder.AppendFormat("<a href=\"/Admin/{0}?CurrentPage={1}\" class=\"{2}\"><span class=\"pagearr\">>></span></a>"
                     , string.Join("/", new[] { vs["controller"].ToString(), vs["action"].ToString() })
                     , page.TotalPages
                     , "last pagenxt");

                }
                else
                {
                    //生成下一页的参数
                    var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                    builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&gt;</span></a>"
                        , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                        , string.Join("&", list)
                        , "last pagenxt");
                    builder.AppendFormat("<a href=\"/{0}?CurrentPage={1}\" class=\"{2}\"><span class=\"pagearr\">>></span></a>"
                       , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                       , page.TotalPages
                       , "last pagenxt");

                }
            }

            builder.AppendFormat("</div></div>");
            builder.AppendFormat("<div class=\"f-fr mart20 marr10\">");
            builder.AppendFormat("共: {0} 条，每页： {1} 条", page.TotalItems, page.ItemsPerPage);
            builder.Append("</div></div>");
            return new HtmlString(builder.ToString());
        }


        /// <summary>
        /// 分页控件 上一页 1 2 3 4 下一页 友好url by姜正午
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="page"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static HtmlString RenderPageUpdate<T>(this HtmlHelper html, Page<T> page, string area = "Home") where T : new()
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = queryString[key];

            var formString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in formString.Keys)
                vs[key] = formString[key];
            vs.Remove("CurrentPage");

            var builder = new StringBuilder();
            var classDict = new Dictionary<string, object>();

            builder.Append("<div class=\"m-page m-page-sr m-page-sm\">");

            vs.Add("CurrentPage", "");

            vs["CurrentPage"] = (page.CurrentPage - 1) > 0 ? (page.CurrentPage - 1) : 1;
            //如果当前是第一页 上一页不可用
            if (page.CurrentPage == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&lt;</span>上一页</a>", "first pageprv z-dis");
            }
            else
            {
                //上一页不是第一页 上一页的url参数
                var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\"><span class=\"pagearr\">&lt;</span>上一页</a>"
                    , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                    , string.Join("&", list)
                    , "first pageprv");
            }

            classDict["class"] = "";
            int i = 0;
            //如果本页到第一页的距离小于3 生成1 2 3 4格式的页码
            if (page.CurrentPage - 3 > 1)
            {
                vs["CurrentPage"] = 1;
                builder.AppendFormat(Html.LinkExtensions.ActionLink(html, "1", vs["action"].ToString(), vs, classDict).ToString());
                builder.Append("<i>...</i>");

                for (i = (int)page.CurrentPage - 2; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\"  class=\"z-crt\">{0}</a>", i);
                    }
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }
            //如果本页到第一页的距离大于3 生成1 ... 3 4 5格式的页码
            else
            {
                for (i = 1; i <= page.CurrentPage; i++)
                {
                    vs["CurrentPage"] = i;
                    //如果是当前页面 当前页不可以点中
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\" class=\"z-crt\">{0}</a>", i);
                    }
                    //如果不是当前页面 可以选中
                    else
                    {
                        classDict["class"] = "";
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }

            classDict["class"] = "";
            //如果当前页距离尾页大于3 生成 5 6 7 ... 10的样式
            if (page.CurrentPage + 3 < page.TotalPages)
            {
                for (i = (int)(page.CurrentPage + 1); i < page.CurrentPage + 3; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
                builder.Append("<i>...</i>");
                vs["CurrentPage"] = page.TotalPages;
                builder.Append(
                    Html.LinkExtensions.ActionLink(html, page.TotalPages.ToString(), vs["action"].ToString(), vs, classDict)
                        .ToString());
            }
            //如果当前页到尾页小于3 生成 5 6 7 8的样式
            else
            {
                for (i = (int)(page.CurrentPage + 1); i <= page.TotalPages; i++)
                {
                    vs["CurrentPage"] = i;
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
            }

            vs["CurrentPage"] = (page.CurrentPage + 1) < page.TotalPages ? (page.CurrentPage + 1) : page.TotalPages;
            //如果没有数据的情况下 下一页不可用
            if (page.CurrentPage == page.TotalPages || page.TotalPages == 0 || page.TotalPages == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\">下一页<span class=\"pagearr\">&gt;</span></a>", "last pagenxt z-dis");
            }
            else
            {
                //生成下一页的参数
                var list = (from o in vs where o.Key != "controller" && o.Key != "action" select o.Key + "=" + o.Value).ToList();
                builder.AppendFormat("<a href=\"/{0}?{1}\" class=\"{2}\">下一页<span class=\"pagearr\">&gt;</span></a>"
                    , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                    , string.Join("&", list)
                    , "last pagenxt");
            }

            builder.Append("</div>");

            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 显示分页信息
        /// </summary>
        /// <param name="html"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static HtmlString RenderPage2<T>(this HtmlHelper html, Page<T> page) where T : new()
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = queryString[key];

            var FormString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in FormString.Keys)
                vs[key] = FormString[key];
            vs.Remove("CurrentPage");

            var builder = new StringBuilder();
            var classDict = new Dictionary<string, object>();
            classDict.Add("class", "pageGo");
            classDict.Add("onclick", "this.href=(this.href.indexOf('?') > -1) ? (this.href + '&CurrentPage=' + document.getElementById('tbGo').value) : (this.href + '?CurrentPage=' + document.getElementById('tbGo').value);");

            builder.Append("<div class=\"mainContent width100p\">");
            builder.Append("<div class=\"page marginRigh10\">");
            builder.AppendFormat(Html.LinkExtensions.ActionLink(html, " ", vs["action"].ToString(), vs, classDict).ToString());
            builder.AppendFormat("<span class=\"marginLef5\">页</span><span class=\"marginLef5\"><input id=\"tbGo\" type=\"text\" value=\"\" />");
            builder.AppendFormat("</span><span class=\"marginLef10\">跳转到第</span><span class=\"marginLef10\">共{0}条</span>", page.TotalItems);
            builder.AppendFormat("<span class=\"marginLef5\">第{0}页/共{1}页</span>", page.CurrentPage, page.TotalPages);

            classDict.Remove("onclick");
            vs.Add("CurrentPage", "");
            classDict["class"] = "lastPage";
            vs["CurrentPage"] = page.TotalPages;
            builder.Append(Html.LinkExtensions.ActionLink(html, " ", vs["action"].ToString(), vs, classDict)); //

            classDict["class"] = "pageDown";
            vs["CurrentPage"] = (page.CurrentPage + 1) < page.TotalPages ? (page.CurrentPage + 1) : page.TotalPages;
            builder.Append(Html.LinkExtensions.ActionLink(html, " ", vs["action"].ToString(), vs, classDict)); //

            classDict["class"] = "pageUp";
            vs["CurrentPage"] = (page.CurrentPage - 1) > 0 ? (page.CurrentPage - 1) : 1;
            builder.Append(Html.LinkExtensions.ActionLink(html, " ", vs["action"].ToString(), vs, classDict)); //

            classDict["class"] = "fistPage";
            vs["CurrentPage"] = 1;
            builder.Append(Html.LinkExtensions.ActionLink(html, " ", vs["action"].ToString(), vs, classDict)); //

            builder.Append("</div>");
            builder.Append("</div>");

            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 分页控件 上一页 1 2 3 4 下一页 url友好 by姜正午
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="html"></param>
        /// <param name="page"></param>
        /// <param name="area"></param>
        /// <param name="pageIndex"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static HtmlString RenderPage3<T>(this HtmlHelper html, Page<T> page, string area = "Home", int pageIndex = 6, string splitChar = "-") where T : new()
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;

            if (!vs.ContainsKey("id"))
            {
                return new HtmlString("");
            }

            //根据分割字符分割的字符串
            string[] splits = vs["id"].ToString().Split(splitChar.ToCharArray());
            var queryString = html.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString.Keys)
                if (queryString[key] != null && !string.IsNullOrEmpty(key))
                    vs[key] = queryString[key];

            var formString = html.ViewContext.HttpContext.Request.Form;
            foreach (string key in formString.Keys)
                vs[key] = formString[key];

            var builder = new StringBuilder();
            var classDict = new Dictionary<string, object>();

            builder.Append("<div class=\"m-page m-page-sr m-page-sm\">");

            //如果是第一页 上一页不可用
            if (page.CurrentPage == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\"><span class=\"pagearr\">&lt;</span>上一页</a>", "first pageprv z-dis");
            }
            else
            {
                //生成上一页的标签
                splits[pageIndex] = (page.CurrentPage - 1).ToString();
                builder.AppendFormat("<a href=\"/{0}/{1}.html\" class=\"{2}\"><span class=\"pagearr\">&lt;</span>上一页</a>"
                    , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                    , string.Join(splitChar, splits)
                    , "first pageprv");
            }

            classDict["class"] = "";
            int i = 0;
            //如果当前页距离第一页长度大于3 生成1 ... 3 4 5格式的分页
            if (page.CurrentPage - 3 > 1)
            {
                splits[pageIndex] = "1";
                vs["id"] = string.Join(splitChar, splits);
                builder.AppendFormat(Html.LinkExtensions.ActionLink(html, "1", vs["action"].ToString(), vs, classDict).ToString());
                builder.Append("<i>...</i>");

                for (i = (int)page.CurrentPage - 2; i <= page.CurrentPage; i++)
                {
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\"  class=\"z-crt\">{0}</a>", i);
                    }
                    else
                    {
                        classDict["class"] = "";
                        splits[pageIndex] = i.ToString();
                        vs["id"] = string.Join(splitChar, splits);
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }
            else
            {
                //当前页距离第一页长度小于3 生成1 2 3 4格式的分页
                for (i = 1; i <= page.CurrentPage; i++)
                {
                    if (i == page.CurrentPage)
                    {
                        builder.AppendFormat("<a href=\"javascript:;\" class=\"z-crt\">{0}</a>", i);
                    }
                    else
                    {
                        classDict["class"] = "";
                        splits[pageIndex] = i.ToString();
                        vs["id"] = string.Join(splitChar, splits);
                        builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                    }
                }
            }

            classDict["class"] = "";
            //如果当前页距离最后
            if (page.CurrentPage + 3 < page.TotalPages)
            {
                for (i = (int)(page.CurrentPage + 1); i < page.CurrentPage + 3; i++)
                {
                    splits[pageIndex] = i.ToString();
                    vs["id"] = string.Join(splitChar, splits);
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
                builder.Append("<i>...</i>");
                splits[pageIndex] = page.TotalPages.ToString();
                vs["id"] = string.Join(splitChar, splits);
                builder.Append(
                    Html.LinkExtensions.ActionLink(html, page.TotalPages.ToString(), vs["action"].ToString(), vs, classDict)
                        .ToString());
            }
            else
            {
                for (i = (int)(page.CurrentPage + 1); i <= page.TotalPages; i++)
                {
                    splits[pageIndex] = i.ToString();
                    vs["id"] = string.Join(splitChar, splits);
                    builder.AppendFormat(Html.LinkExtensions.ActionLink(html, i.ToString(), vs["action"].ToString(), vs, classDict).ToString());
                }
            }

            if (page.CurrentPage == page.TotalPages || page.TotalPages == 0 || page.TotalPages == 1)
            {
                builder.AppendFormat("<a href=\"javascript:;\" class=\"{0}\">下一页<span class=\"pagearr\">&gt;</span></a>", "last pagenxt z-dis");
            }
            else
            {
                splits[pageIndex] = (page.CurrentPage + 1).ToString();
                builder.AppendFormat("<a href=\"/{0}/{1}.html\" class=\"{2}\">下一页<span class=\"pagearr\">&gt;</span></a>"
                    , string.Join("/", new[] { area, vs["controller"].ToString(), vs["action"].ToString() })
                    , string.Join(splitChar, splits)
                    , "last pagenxt");
            }

            builder.Append("</div>");

            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 生成一个查询按钮
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static HtmlString RenderSearch(this HtmlHelper html)
        {
            RouteValueDictionary vs = html.ViewContext.RouteData.Values;
            var builder = new StringBuilder();

            string script = string.Format("var form = $(this).closest('form'); var query = form.serialize(); location.href= '/{0}/{1}?PageInfo.PageIndex=1&' + query; ", vs["controller"].ToString(), vs["action"].ToString());

            builder.AppendFormat("<input type=\"button\" value=\"查询\" onclick=\"{0}\" />", script);
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 多选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="selectList"></param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> selectList)
        {
            return CheckBoxList(helper, name, selectList, new { });
        }

        /// <summary>
        /// 多选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString CheckBoxList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Dictionary<string, object> HtmlAttributes = new Dictionary<string, object>();
            HtmlAttributes.Add("name", name);

            foreach (SelectListItem selectItem in selectList)
            {
                IDictionary<string, object> newHtmlAttributes = HtmlAttributes.DeepCopy();
                newHtmlAttributes.Add("value", selectItem.Value);
                stringBuilder.AppendFormat(@"<label>{0}  {1}</label>",
                    string.Format("<input type=\"checkbox\" name=\"{0}\" value=\"{1}\" {2} />", name, selectItem.Value, selectItem.Selected ? "checked=\"checked\"" : "")
                   , selectItem.Text);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 单选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="selectList"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> selectList)
        {
            return RadioButtonList(helper, name, selectList, new { });
        }

        /// <summary>
        /// 单选列表
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="selectList"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString RadioButtonList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Dictionary<string, object> HtmlAttributes = new Dictionary<string, object>();
            HtmlAttributes.Add("name", name);

            foreach (SelectListItem selectItem in selectList)
            {
                IDictionary<string, object> newHtmlAttributes = HtmlAttributes.DeepCopy();
                newHtmlAttributes.Add("value", selectItem.Value);
                stringBuilder.AppendFormat(@"<label>{0}  {1}</label>",
                   string.Format("<input type=\"radio\" name=\"{0}\" value=\"{1}\" {2} />", name, selectItem.Value, selectItem.Selected ? "checked=\"checked\"" : "")
                    , selectItem.Text);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        private static IDictionary<string, object> DeepCopy(this IDictionary<string, object> ht)
        {
            Dictionary<string, object> _ht = new Dictionary<string, object>(); foreach (var p in ht) { _ht.Add(p.Key, p.Value); } return _ht;
        }

        /// <summary>
        /// 生成后台页面的二级面包屑导航 by姜正午
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderNavHtml(this HtmlHelper helper)
        {
            //从Session中读取当前用户拥有权限的
            List<NodeModel> nodeList = MTConfig.AuthInfo;
            if (nodeList == null || nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            StringBuilder stringBuilder = new StringBuilder("<div class=\"m-tt  marr20 marb10 \">");
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            var level2List = nodeList.Where(s => s.NodeLevel == 2);
            var level3List = nodeList.Where(s => s.NodeLevel == 3);
            var group = level2List.FirstOrDefault(s => s.Name.ToLower() == controller);
            if (null == group)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            stringBuilder.AppendFormat("{0}", group.NodeGroupTitle);
            var node = level3List.FirstOrDefault(s => "" + s.Pid == group.ID && s.Name.ToLower() == action);
            if (null == node)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            //显示两级目录
            if ("Index".Equals(action, StringComparison.CurrentCultureIgnoreCase))
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\" >{0}</a></div>", group.Title);
            }
            else
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\">{0}</a></div>", group.Title);
            }
            stringBuilder.Append("</div>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 生成没有底线的二级页面包屑导航
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderNuSeNavHtml(this HtmlHelper helper)
        {
            //从Session中读取当前用户拥有权限的
            List<NodeModel> nodeList = MTConfig.AuthInfo;
            if (nodeList == null || nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            StringBuilder stringBuilder = new StringBuilder("<div class=\"m-tt  marr20 \">");
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            var level2List = nodeList.Where(s => s.NodeLevel == 2);
            var level3List = nodeList.Where(s => s.NodeLevel == 3);
            var group = level2List.FirstOrDefault(s => s.Name.ToLower() == controller);
            if (null == group)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            stringBuilder.AppendFormat("{0}", group.NodeGroupTitle);
            var node = level3List.FirstOrDefault(s => "" + s.Pid == group.ID && s.Name.ToLower() == action);
            if (null == node)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            //显示两级目录
            if ("Index".Equals(action, StringComparison.CurrentCultureIgnoreCase))
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\" >{0}</a></div>", group.Title);
            }
            else
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\">{0}</a></div>", group.Title);
            }
            stringBuilder.Append("</div>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 生成后台页面的二级面包屑导航仅适用于控制台样式
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderNaveHtml(this HtmlHelper helper)
        {
            //从Session中读取当前用户拥有权限的
            List<NodeModel> nodeList = MTConfig.AuthInfo;
            if (nodeList == null || nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            StringBuilder stringBuilder = new StringBuilder("<div class=\"m-tf  marr20 \">");
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            var level2List = nodeList.Where(s => s.NodeLevel == 2);
            var level3List = nodeList.Where(s => s.NodeLevel == 3);
            var group = level2List.FirstOrDefault(s => s.Name.ToLower() == controller);
            if (null == group)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            stringBuilder.AppendFormat("{0}", group.NodeGroupTitle);
            var node = level3List.FirstOrDefault(s => "" + s.Pid == group.ID && s.Name.ToLower() == action);
            if (null == node)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            //显示两级目录
            if ("Index".Equals(action, StringComparison.CurrentCultureIgnoreCase))
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\" >{0}</a></div>", group.Title);
            }
            else
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\">{0}</a></div>", group.Title);
            }
            stringBuilder.Append("</div>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }


        /// <summary>
        /// 生成后台页面的二级面包屑导航(添加编辑页面)
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString AddOrEditNavHtml(this HtmlHelper helper, string url = "")
        {
            //从Session中读取当前用户拥有权限的
            List<NodeModel> nodeList = MTConfig.AuthInfo;
            if (nodeList == null || nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            StringBuilder stringBuilder = new StringBuilder("<div class=\"m-tt  marr20 \">");
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            var level2List = nodeList.Where(s => s.NodeLevel == 2);
            var level3List = nodeList.Where(s => s.NodeLevel == 3);
            var group = level2List.FirstOrDefault(s => s.Name.ToLower() == controller);
            if (null == group)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            stringBuilder.AppendFormat("{0}", group.NodeGroupTitle);
            var node = level3List.FirstOrDefault(s => "" + s.Pid == group.ID && s.Name.ToLower() == action);
            if (null == node)
            {
                stringBuilder.Append("</div>");
                return MvcHtmlString.Create(stringBuilder.ToString());
            }
            //显示两级目录
            if ("Index".Equals(action, StringComparison.CurrentCultureIgnoreCase))
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\" >{0}</a></div>", node.Title);
            }
            else
            {
                stringBuilder.AppendFormat("<div class=\"f-fl\"><i style=\"height: 15px; width: 2px;margin-left: -8px; background: #88B7E0; display: block; float: left; margin-top: 5px;\"></i><a href=\"javascript:void(0);\" style=\"color:#333\">{0}</a></div>", node.Title);
            }
            if (url != "" )
            {
                stringBuilder.Append(" <div class=\"f-back f-fl\"><a  href=\" "+url+"\" ><i></i><span>返回上级列表</span></a></div>");
            }
            else 
            {
                stringBuilder.Append(" <div class=\"f-back f-fl\"><a onclick=\"back();\"><i></i><span>返回上级列表</span></a></div>");

            }
            stringBuilder.Append("</div>");



            return MvcHtmlString.Create(stringBuilder.ToString());
        }


        /// <summary>
        /// 生成前台页面的面包屑导航 by姜正午
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderCrumbHtml(this HtmlHelper helper, string title)
        {
            //从Session中读取当前用户拥有权限的
  
            List<NodeModel> nodeList = NodeDAL.GetNodeByArea( ).ToList();
            if (nodeList == null || nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            StringBuilder stringBuilder = new StringBuilder("<div class=\"m-crumb\"><ul><li>您所在的位置：</li>");
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            stringBuilder.AppendFormat("<li><a href=\"{0}\">首页</a></li>", helper.StaticUrl("Home", "Index", "Index"));
            var level2Node = nodeList.FirstOrDefault(s => s.Name.ToLower() == controller);
            if (level2Node != null)
            {
                stringBuilder.AppendFormat("<li>&gt;</li><li><a href=\"{0}\">{1}</a></li>", helper.StaticUrl(GetArea(), level2Node.Name), level2Node.Title);

                var level3Node =
                    nodeList.FirstOrDefault(s => s.Name.ToLower() == action && s.Pid.ToInt() == level2Node.ID.ToInt());
                if (level3Node != null)
                {
                    stringBuilder.AppendFormat("<li>&gt;</li><li><a href=\"{0}\">{1}</a></li>", "javascript:void(0);", level3Node.Title);
                }
            }

            if (!string.IsNullOrEmpty(title))
            {
                stringBuilder.AppendFormat("<li>&gt;</li><li><a href=\"{0}\">{1}</a></li>", "javascript:void(0);", title);
            }

            stringBuilder.Append("</ul></div>");
            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        /// <summary>
        /// 生成前台页面的面包屑导航 by姜正午
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static MvcHtmlString RenderCrumbUlHtml(this HtmlHelper helper, string title = "")
        {
            //从Session中读取当前用户拥有权限的
       
            List<NodeModel> nodeList = NodeDAL.GetNodeByArea().ToList();
            if (nodeList.Count == 0)
            {
                return MvcHtmlString.Create(string.Empty);
            }
            RouteValueDictionary vd = helper.ViewContext.RouteData.Values;
            string action = vd["action"].ToString().ToLower();
            string controller = vd["controller"].ToString().ToLower();
            string link = "/" + string.Join("/", new[] { GetArea(), controller, action });
            var parentNode = nodeList.FirstOrDefault(s => !string.IsNullOrEmpty(s.Link) && s.Link.ToLower() == link);
            List<string> list = new List<string>();

            list.Insert(0,
                        !string.IsNullOrEmpty(title)
                            ? string.Format("<li><a>{0}</a></li>", title)
                            : string.Format("<li><a>{0}</a></li>", parentNode.Title));


            while (true)
            {
                if (parentNode == null)
                {
                    break;
                }
                var node = nodeList.FirstOrDefault(s => s.ID.ToInt() == parentNode.Pid.ToInt());
                if (node != null)
                {

                    list.Insert(0, string.Format("<li><a href=\"{0}\">{1}</a></li>", node.Link.Contains(".html") ? node.Link : (node.Link + ".html"), node.Title));
                    parentNode = node;
                }
                else
                {
                    break;
                }
            }
            return MvcHtmlString.Create(string.Format("<ul><li>您所在的位置：</li>{0}</ul>", string.Join("<li>&gt;</li>", list)));
        }

        /// <summary>
        /// 获得当前的area controller action
        /// </summary>
        /// <returns></returns>
        public static string GetArea()
        {
            string area = HttpContext.Current.Request.Url.AbsolutePath.Trim('/').Split('/')[0];
            return area.ToLower();
        }

        /// <summary>
        /// 创建一个iframe上传控件
        /// </summary>
        /// <param name="html"></param>
        /// <param name="onclick"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HtmlString CreateBackIframeUpload(this HtmlHelper html, string onclick = "", string value = "选择文件")
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("<input type=\"button\" class=\"u-btn\" value=\"{1}\" onclick=\"{0}\" />", onclick, value);
            return new HtmlString(builder.ToString());
        }

        /// <summary>
        /// 动态加载图片
        /// </summary>
        /// <param name="className">样式</param>
        /// <param name="url">路径</param>
        /// <returns></returns>
        public static HtmlString CreateImgLoading(this HtmlHelper html, string url, string alt = "", string className = "", string style = "", int width = 0, int height = 0)
        {
            string imgurl = "<img style='" + style + "' class='scrollLoading " + className + "' data-url='" + url + "' alt='" + alt + "' " + (height != 0 ? string.Format("height='{0}'", height) : "") + " " + (width != 0 ? string.Format("width='{0}'", width) : "") + " />";
            return new HtmlString(imgurl);
        }

        public static HtmlString CreateEnNum(this HtmlHelper html, int num)
        {
            switch (num)
            {
                case 1:
                    return new HtmlString("ONE");
                    break;
                case 2:
                    return new HtmlString("TWO");
                    break;
                case 3:
                    return new HtmlString("THREE");
                case 4:
                    return new HtmlString("FOUR");
                default:
                    return new HtmlString("ONE");
                    break;
            }
        }

        public static String StaticUrl(this HtmlHelper html, string areaName = "",
                                                string controllerName = "",
                                                string actionName = "",
                                                string idName = "",
                                                string paramtersName = "")
        {
            string url = "";

            if (!string.IsNullOrWhiteSpace(areaName))
            {
                url += "/" + areaName;
            }

            if (!string.IsNullOrWhiteSpace(controllerName))
            {
                url += "/" + controllerName;
            }

            if (!string.IsNullOrWhiteSpace(actionName))
            {
                url += "/" + actionName;
            }

            if (!string.IsNullOrEmpty(idName))
            {
                url += "/" + idName;
            }

            url += ".html";

            return url + paramtersName;
        }

        public static HtmlString AppendParams(this HtmlHelper html, string key, string value)
        {
            HtmlString htmlString = new HtmlString("");
            List<string> keyValues = new List<string>();
            bool exist = false;

            foreach (var k in HttpContext.Current.Request.QueryString.Keys)
            {
                if (k.ToString() == key)
                {
                    exist = true;
                    List<string> arr = HttpContext.Current.Request.QueryString[k.ToString()].Split(',').ToList();
                    if (arr.FirstOrDefault(s => s == value && !string.IsNullOrWhiteSpace(s)) == null)
                    {
                        arr.Add(value);
                    }
                    keyValues.Add(k + "=" + string.Join(",", arr));
                }
                else
                {
                    keyValues.Add(k + "=" + HttpContext.Current.Request.QueryString[k.ToString()]);
                }
            }
            if (!exist)
            {
                keyValues.Add(key + "=" + value);
            }

            htmlString = new HtmlString(string.Join("&", keyValues));
            return htmlString;
        }

        public static HtmlString RemoveParams(this HtmlHelper html, string key, string value)
        {
            HtmlString htmlString = new HtmlString("");
            List<string> keyValues = new List<string>();

            foreach (var k in HttpContext.Current.Request.QueryString.Keys)
            {
                if (k.ToString() == key)
                {
                    List<string> arr = HttpContext.Current.Request.QueryString[k.ToString()].Split(',').ToList();
                    arr = arr.Where(s => s != value && !string.IsNullOrWhiteSpace(s)).ToList();
                    keyValues.Add(k + "=" + string.Join(",", arr));
                }
                else
                {
                    keyValues.Add(k + "=" + HttpContext.Current.Request.QueryString[k.ToString()]);
                }
            }

            htmlString = new HtmlString(string.Join("&", keyValues));
            return htmlString;
        }

        public static HtmlString ReplaceParams(this HtmlHelper html, string key, string value)
        {
            HtmlString htmlString = new HtmlString("");
            List<string> keyValues = new List<string>();
            bool exist = false;

            foreach (var k in HttpContext.Current.Request.QueryString.Keys)
            {
                if (k.ToString() == key)
                {
                    exist = true;
                    keyValues.Add(k + "=" + value);
                }
                else
                {
                    keyValues.Add(k + "=" + HttpContext.Current.Request.QueryString[k.ToString()]);
                }
            }

            if (!exist)
            {
                keyValues.Add(key + "=" + value);
            }

            htmlString = new HtmlString(string.Join("&", keyValues));
            return htmlString;
        }

        public static HtmlString MaskMiddle(this HtmlHelper html, string str)
        {
            List<char> charList = str.ToCharArray().ToList();
            for (int i = 2; i < charList.Count - 2; i++)
            {
                charList[i] = '*';
            }
            return new HtmlString(new string(charList.ToArray()));
        }

        public static string TimeTableCssClass(this HtmlHelper html, string name)
        {
            if (name == MTConfig.CourseTableStatus.已排课)
            {
                return "arrange";
            }
            if (name == MTConfig.CourseTableStatus.无法预约)
            {
                return "disable";
            }
            if (name == MTConfig.CourseTableStatus.未预约)
            {
                return "disable";
            }
            return "enable";
        }

    }
}
