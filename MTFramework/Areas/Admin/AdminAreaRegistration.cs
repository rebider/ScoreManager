using System.Web.Mvc;

namespace MT.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller="Public", action = "Login", id = UrlParameter.Optional },
                new string[]{"MT.Areas.Admin.Controllers"}
            );
        }
    }
}
