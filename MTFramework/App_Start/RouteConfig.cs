using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DefaultNoParameter",
                url: "{controller}/{action}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MT.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MT.Controllers" }
            );

            routes.MapRoute(
                name: "DefaultNoParameterHtml",
                url: "{controller}/{action}.html",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MT.Controllers" }
            );

            routes.MapRoute(
                name: "DefaultHtml",
                url: "{controller}/{action}/{id}.html",
                defaults: new { controller = "Index", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MT.Controllers" }
            );
        }
    }
}