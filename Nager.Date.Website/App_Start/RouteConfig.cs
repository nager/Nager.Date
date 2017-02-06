using System.Web.Mvc;
using System.Web.Routing;

namespace Nager.Date.Website
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{countrycode}/{year}",
                defaults: new { controller = "Home", action = "Index", countrycode = UrlParameter.Optional, year = UrlParameter.Optional }
            );
        }
    }
}
