using System.Web.Mvc;

namespace ProductCatalog.Website.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Manager_default",
                "Manager/{controller}/{action}/{id}",
                new { Controller="Products", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}